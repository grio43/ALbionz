using SharedComponents.EVE;
using SharedComponents.EVEAccountCreator;
using SharedComponents.EVEAccountCreator.Curl;
//using SharedComponents.IMAP;
using SharedComponents.Socks5.Socks5Relay;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace EVESharpLauncher
{
    public partial class EveAccountCreatorForm : Form
    {
        #region Fields

        private CancellationTokenSource cTokenSource;

        private KeyValuePair<EmailProvider, Tuple<string, string>> CurrentEmailProvider;
        private List<IDisposable> drivers = new List<IDisposable>();

        private Dictionary<EmailProvider, Tuple<string, string>> EmailProviders = new Dictionary<EmailProvider, Tuple<string, string>>()
        {
            {EmailProvider.Google, new Tuple<string, string>("imap.gmail.com", "@gmail.com")},
            {EmailProvider.Yandex, new Tuple<string, string>("imap.yandex.com", "@yandex.com")},
            {EmailProvider.Outlook, new Tuple<string, string>("imap-mail.outlook.com", "@outlook.com")},
        };

        private List<Task<Tuple<bool, string, string, string>>> Tasks;

        #endregion Fields

        #region Constructors

        public EveAccountCreatorForm()
        {
            InitializeComponent();
            Tasks = new List<Task<Tuple<bool, string, string, string>>>();
            cTokenSource = new CancellationTokenSource();
            CurrentEmailProvider = EmailProviders.Last();
        }

        #endregion Constructors

        #region Enums

        private enum EmailProvider
        {
            Google,
            Yandex,
            Outlook
        }

        #endregion Enums

        #region Properties

        private bool IsIndicatingProgress { get; set; }

        #endregion Properties

        #region Methods

        private void button1_Click(object sender, EventArgs e)
        {
            StopAllTasks();
        }

        private void ButtonAbortEmailValidation_Click(object sender, EventArgs e)
        {
            StopAllTasks();
        }

        private void ButtonAddTrial_Click(object sender, EventArgs e)
        {
            cTokenSource = new CancellationTokenSource();
            var upDownValue = (int)numericUpDown1.Value;
            Tasks = new List<Task<Tuple<bool, string, string, string>>>();

            new Thread(() =>
            {
                try
                {
                    Invoke(new Action(() => buttonStartAlphaCreation.Enabled = false));

                    var prx = (Proxy)Invoke(new Func<Proxy>(() => (Proxy)comboBoxProxies.SelectedItem));

                    if (prx == null || !prx.CheckInternetConnectivity() || !prx.IsValid)
                    {
                        Cache.Instance.Log("Internet connectivity seems to be unavailable through the proxy.");
                        return;
                    }

                    RunProgressbar();

                    var eveAccounts = new List<Tuple<string, string, string>>();

                    for (var i = 0; i < upDownValue; i++)
                    {
                        var eveUsername = UserPassGen.Instance.GenerateUsername();
                        var evePassword = UserPassGen.Instance.GeneratePassword();
                        var n = i;
                        var t =
                            Task.Run(
                                async () =>
                                {
                                    return await new EveAccountCreatorImpl(n).CreateEveAlphaAccountAndValidate(string.Empty, eveUsername, evePassword,
                                        prx.GetIpPort(), prx.GetUserPassword(), cTokenSource.Token);
                                }, cTokenSource.Token);

                        Tasks.Add(t);
                    }

                    foreach (var task in Tasks)
                        try
                        {
                            task.Wait();
                        }
                        catch (AggregateException)
                        {
                            continue;
                        }

                    foreach (var task in Tasks)
                    {
                        if (task.Exception != null)
                            continue;
                        if (task.Result != null && task.Result.Item1)
                            eveAccounts.Add(new Tuple<string, string, string>(task.Result.Item2, task.Result.Item3, task.Result.Item4));
                    }

                    foreach (var a in eveAccounts)
                    {
                        var eA = new EveAccount(a.Item1, a.Item1, a.Item2, DateTime.UtcNow, DateTime.UtcNow, false);
                        eA.HWSettings = new HWSettings();
                        eA.HWSettings.GenerateRandomProfile();
                        eA.HWSettings.Proxy = prx;
                        eA.Email = a.Item3;
                        Invoke(new Action(() => Cache.Instance.EveAccountSerializeableSortableBindingList.List.Add(eA)));
                    }
                }
                catch (Exception ex)
                {
                    Cache.Instance.Log(ex.ToString());
                    Debug.WriteLine(ex.ToString());
                }
                finally
                {
                    try
                    {
                        IsIndicatingProgress = false;
                        Invoke(new Action(() => buttonStartAlphaCreation.Enabled = true));
                    }
                    catch (Exception exception)
                    {
                        Cache.Instance.Log(exception.ToString());
                        Debug.WriteLine(exception);
                    }
                }
            }).Start();
        }

        private void ButtonCreateEmailAccount_Click(object sender, EventArgs e)
        {
            var p = GetProxy();
            if (p == null)
            {
                Cache.Instance.Log("Select a proxy.");
                return;
            }

            if (!p.CheckInternetConnectivity())
            {
                Cache.Instance.Log("Internet connectivity seems to be unavailable through the proxy.");
                return;
            }

            switch (CurrentEmailProvider.Key)
            {
                case EmailProvider.Google:
                    break;

                case EmailProvider.Yandex:
                    var yandexImpl = new YandexCurl();
                    yandexImpl.CreateYandexEmail(textBoxEmailAddress.Text, textBoxPassword.Text, GetProxy());
                    break;

                case EmailProvider.Outlook:
                    var outlookImpl = new Outlook();
                    drivers.Add(outlookImpl);
                    new Task(() =>
                    {
                        try
                        {
                            outlookImpl.CreateOutlookEmail(textBoxEmailAddress.Text.Split('@')[0], textBoxPassword.Text, p, textBoxRecoveryEmailAddress.Text);
                        }
                        catch (Exception ex)
                        {
                            Cache.Instance.Log("Exception: " + ex);
                        }
                    }).Start();
                    break;
            }
        }

        private void ButtonCreateEveAccount_Click(object sender, EventArgs e)
        {
            if (GetProxy() != null)
            {
                var p = GetProxy();
                if (!p.CheckInternetConnectivity() || !GetProxy().IsValid)
                {
                    Cache.Instance.Log("Internet connectivity seems to be unavailable through the proxy.");
                    return;
                }
                //                using (var curlWorker = new CurlWorker())
                //                {
                //                    var res = new EveAccountCreatorImpl(0).CreateEveAccount(string.Empty, textBoxEmailAddress.Text, textBoxEveAccountName.Text,
                //                        textBoxPassword.Text, p.GetIpPort(), p.GetUserPassword(), curlWorker);
                //
                //                    if (res)
                //                    {
                //                        var msg = string.Format("Eve account created. Email [{0}] Acc [{1}] Password [{2}]", textBoxEmailAddress.Text,
                //                            textBoxEveAccountName.Text,
                //                            textBoxPassword.Text);
                //                        Cache.Instance.Log(msg);
                //                        Debug.WriteLine(msg);
                //                    }
                //                }

                //p.StartFireFoxInject("https://secure.eveonline.com/signup/");
            }
        }

        private void ButtonGenerateRandom_Click(object sender, EventArgs e)
        {
            GenerateRandom();
        }

        private void ButtonOpenFirefox_Click(object sender, EventArgs e)
        {
            //var p = (Proxy)comboBoxProxies.SelectedItem;
            //if (p != null)
            //    p.StartFireFoxInject();
        }

        private void ButtonValidateEveAccount_Click(object sender, EventArgs e)
        {
            var p = GetProxy();

            if (p == null)
            {
                Cache.Instance.Log("No proxy was selected.");
                return;
            }

            if (p != null)
                if (!GetProxy().CheckInternetConnectivity() || !GetProxy().IsValid)
                {
                    Cache.Instance.Log("Internet connectivity seems to be unavailable through the proxy.");
                    return;
                }

            cTokenSource = new CancellationTokenSource();

            //new Thread(() =>
            //{
            //    try
            //    {
            //        Invoke(new Action(() => buttonValidateEveAccount.Enabled = false));

            //        RunProgressbar();

            //        var t = new Task(() =>
            //        {
            //            var emailFound = false;
            //            while (!emailFound)
            //            {
            //                Cache.Instance.Log("Validation task running.");
            //                try
            //                {
            //                    if (cTokenSource.Token.IsCancellationRequested)
            //                        return;

            //                    var emails = Imap.GetInboxEmails(textBoxIMAPHost.Text, 993, SslProtocols.Default, true, p.Ip, Convert.ToInt32(p.Port),
            //                        p.Username, p.Password,
            //                        textBoxEmailAddress.Text, textBoxPassword.Text);

            //                    foreach (var email in emails)
            //                    {
            //                        Cache.Instance.Log(email.Body.Text);
            //                        Cache.Instance.Log(email.Body.Html);
            //                        try
            //                        {
            //                            var htmlDoc = new HtmlDocument();
            //                            htmlDoc.LoadHtml(email.Body.Html);
            //                            var nodes = htmlDoc.DocumentNode.SelectNodes("//a[contains(@href, 'http://click.service.ccpgames.com/?')]");

            //                            if (nodes.Count > 0 && nodes.Count == 2)
            //                            {
            //                                Cache.Instance.Log("We found a node with the link. Nodes: " + nodes.Count);
            //                                var node = nodes.FirstOrDefault();

            //                                if (node != null)
            //                                {
            //                                    var verificationUrl = node.Attributes["href"].Value;
            //                                    Cache.Instance.Log(string.Format("Verification url found [{0}]", verificationUrl));

            //                                    p.StartFireFoxInject(verificationUrl);

            //                                    Cache.Instance.Log($"Added account {textBoxEveAccountName.Text}");
            //                                    var eA = new EveAccount(textBoxEveAccountName.Text, textBoxEveAccountName.Text, textBoxPassword.Text,
            //                                        DateTime.UtcNow, DateTime.UtcNow, false);
            //                                    eA.HWSettings = new HWSettings();
            //                                    eA.HWSettings.GenerateRandomProfile();
            //                                    eA.HWSettings.Proxy = p;
            //                                    eA.Email = textBoxEmailAddress.Text;
            //                                    eA.IMAPHost = textBoxIMAPHost.Text;
            //                                    Invoke(new Action(() => Cache.Instance.EveAccountSerializeableSortableBindingList.List.Add(eA)));

            //                                    emailFound = true;
            //                                }
            //                                else
            //                                {
            //                                    Cache.Instance.Log("Node is null.");
            //                                }
            //                            }
            //                            else
            //                            {
            //                                Cache.Instance.Log("No nodes found.");
            //                            }
            //                        }
            //                        catch (Exception ex)
            //                        {
            //                            Cache.Instance.Log("Exception: " + ex);
            //                        }
            //                    }
            //                }
            //                catch (Exception exception)
            //                {
            //                    Cache.Instance.Log("Exception:" + exception);
            //                }
            //                finally
            //                {
            //                    if (!emailFound)
            //                        Task.Delay(500);
            //                }
            //            }
            //        });

            //        t.Start();
            //        t.Wait();
            //    }
            //    catch (Exception ex)
            //    {
            //        Cache.Instance.Log(ex.ToString());
            //        Debug.WriteLine(ex.ToString());
            //    }
            //    finally
            //    {
            //        try
            //        {
            //            IsIndicatingProgress = false;
            //            Invoke(new Action(() => buttonValidateEveAccount.Enabled = true));
            //        }
            //        catch (Exception exception)
            //        {
            //            Cache.Instance.Log(exception.ToString());
            //            Debug.WriteLine(exception);
            //        }
            //    }
            //}).Start();
        }

        private void ComboBoxProxies_SelectedIndexChanged(object sender, EventArgs e)
        {
            var p = GetProxy();
            if (p != null)
                try
                {
                    var s = p.GetUserPassword() + "@" + p.GetIpPort();
                    Debug.WriteLine("Relaying args: " + s);
                    //DsocksHandler.StartChain(new string[] { s });
                }
                catch (Exception ex)
                {
                    Cache.Instance.Log(ex.ToString());
                }
        }

        private void EveAccountCreatorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var d in drivers)
                if (d != null)
                    try
                    {
                        d.Dispose();
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine(exception);
                    }
        }

        private void EveAccountCreatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopAllTasks();
            //DsocksHandler.Dispose();
            Outlook.KillGeckoDrivers();
        }

        private void EveAccountCreatorForm_Load(object sender, EventArgs e)
        {
            Outlook.KillGeckoDrivers();

            comboBoxProxies.DataSource = Cache.Instance.EveSettings.Proxies;
            comboBoxProxies.DisplayMember = "Description";
            comboBoxProxies.SelectedIndex = -1;
        }

        private void EveAccountCreatorForm_Shown(object sender, EventArgs e)
        {
            GenerateRandom();
            comboBoxProxies.Select();
        }

        private void GenerateRandom()
        {
            textBoxEmailAddress.Text = UserPassGen.Instance.GenerateUsername() + CurrentEmailProvider.Value.Item2;
            textBoxPassword.Text = UserPassGen.Instance.GeneratePassword();
            textBoxEveAccountName.Text = UserPassGen.Instance.GenerateUsername();
            textBoxRecoveryEmailAddress.Text = Cache.Instance.EveSettings.ReceiverEmailAddress;
        }

        private Proxy GetProxy()
        {
            return (Proxy)comboBoxProxies.SelectedItem;
        }

        private void RadioButtonGmail_CheckedChanged(object sender, EventArgs e)
        {
            CurrentEmailProvider = EmailProviders.Where(em => em.Key == EmailProvider.Google).First();
            textBoxIMAPHost.Text = CurrentEmailProvider.Value.Item1;
            GenerateRandom();
        }

        private void RadioButtonOutlook_CheckedChanged(object sender, EventArgs e)
        {
            CurrentEmailProvider = EmailProviders.Where(em => em.Key == EmailProvider.Outlook).First();
            textBoxIMAPHost.Text = CurrentEmailProvider.Value.Item1;
            GenerateRandom();
        }

        private void RadioButtonYandex_CheckedChanged(object sender, EventArgs e)
        {
            CurrentEmailProvider = EmailProviders.Where(em => em.Key == EmailProvider.Yandex).First();
            textBoxIMAPHost.Text = CurrentEmailProvider.Value.Item1;
            GenerateRandom();
        }

        private void RunProgressbar()
        {
            if (IsIndicatingProgress)
                return;

            IsIndicatingProgress = true;
            new Thread(() =>
            {
                while (IsIndicatingProgress)
                {
                    Thread.Sleep(1000);
                    try
                    {
                        progressBar1.Invoke(new Action(() =>
                        {
                            if (progressBar1.Value == progressBar1.Maximum)
                                progressBar1.Value = 0;
                            progressBar1.PerformStep();
                        }));
                    }
                    catch (Exception)
                    {
                    }
                }

                progressBar1.Invoke(new Action(() => { progressBar1.Value = 0; }));
            }).Start();
        }

        private void StopAllTasks()
        {
            Cache.Instance.Log("Cancellation of all tasks requested.");
            cTokenSource.Cancel();
        }

        #endregion Methods
    }
}