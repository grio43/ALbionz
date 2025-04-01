using SharedComponents.CurlUtil;
using SharedComponents.EVE;
using SharedComponents.Utility;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVESharpLauncher
{
    public partial class ProxiesForm : Form
    {
        #region Constructors

        public ProxiesForm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

       
            foreach (var p in Cache.Instance.EveSettings.Proxies)
                p.Clear();

            button2.Enabled = false;

                int numberOfThreads = Cache.Instance.EveSettings.Proxies.Count;
            CountdownEvent countdownEvent = new CountdownEvent(numberOfThreads);

            foreach (var p in Cache.Instance.EveSettings.Proxies)
            {
                new Thread(() =>
                {
                    try
                    {
                        var result = CurlWorker.CheckInternetConnectivity(p.GetIpPort(), p.GetUserPassword());
                        result = !result ? CurlWorker.CheckInternetConnectivity(p.GetIpPort(), p.GetUserPassword()) : result;

                        Invoke((MethodInvoker)delegate
                        {
                            p.IsAlive = result;
                            p.LastCheck = DateTime.UtcNow;
                            if (!p.IsAlive)
                                p.LastFail = DateTime.UtcNow;
                        });

                        if (p.IsAlive)
                        {
                            var ip = p.GetExternalIp(5);
                            ip = ip == String.Empty ? p.GetExternalIp(5) : ip;

                            Invoke((MethodInvoker)delegate { p.ExtIp = ip; });
                        }
                    }
                    catch (Exception ex)
                    {
                        Cache.Instance.Log("Exception: " + ex);
                    }
                    finally
                    {
                        countdownEvent.Signal(); // Signal that this thread has completed
                    }
                }).Start();
            }

            // Wait for all threads to finish
            ThreadPool.QueueUserWorkItem((state) =>
            {
                try
                {
                    countdownEvent.Wait(); // Wait until countdownEvent count reaches zero
                    // This code will execute when all threads have finished
                    Invoke((MethodInvoker)delegate { UpdateLinks(); });
                    Invoke((MethodInvoker)delegate { button2.Enabled = true; });
                }
                catch (Exception exception)
                {
                }

            });
            }
            catch (Exception exception)
            {
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Cache.Instance.EveSettings.Proxies.Clear();
                foreach (var eA in Cache.Instance.EveAccountSerializeableSortableBindingList.List)
                    eA.HWSettings.ProxyId = -1;
            }
            catch (Exception exception)
            {
                Cache.Instance.Log("Exception: " + exception);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cache.Instance.EveSettings.Proxies.Add(new Proxy("", "", "", "", Cache.Instance.EveSettings.Proxies));
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var dgv = ActiveControl as DataGridView;
            if (dgv == null) return;
            var selected = dgv.SelectedCells[0].OwningRow.Index;

            if (selected >= 0)
            {
                var p = Cache.Instance.EveSettings.Proxies.ElementAt(selected);
                foreach (
                    var eA in
                    Cache.Instance.EveAccountSerializeableSortableBindingList.List.Where(
                        a => a.HWSettings != null && a.HWSettings.Proxy != null && a.HWSettings.Proxy.Id == p.Id))
                {
                    var hw = eA.HWSettings;
                    hw.ProxyId = -1;
                    eA.HWSettings = hw;
                }

                Cache.Instance.EveSettings.Proxies.RemoveAt(selected);
            }
        }

        private void ProxiesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cache.Instance.EveSettingsSerializeableSortableBindingList.List.XmlSerialize(
                Cache.Instance.EveSettingsSerializeableSortableBindingList.FilePathName);
        }

        private void ProxiesForm_Load(object sender, EventArgs e)
        {
            if (Cache.Instance.EveSettings.Proxies == null)
                Cache.Instance.EveSettings.Proxies = new ConcurrentBindingList<Proxy>();

            dataGridProxies.DataSource = Cache.Instance.EveSettings.Proxies;
        }

        private void ProxiesForm_Shown(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate { UpdateLinks(); });
        }

        private void UpdateLinks()
        {
            foreach (var p in Cache.Instance.EveSettings.Proxies)
            {
                p.LinkedAccounts = string.Empty;
                var eAs = Cache.Instance.EveAccountSerializeableSortableBindingList.List.Where(
                    a => a.HWSettings != null && a.HWSettings.Proxy != null && a.HWSettings.Proxy == p);
                if (eAs.Any())
                {
                    p.LinkedAccounts = string.Empty;
                    var i = 0;
                    foreach (var eA in eAs)
                    {
                        if (i == 0)
                            p.LinkedAccounts += eA.AccountName;
                        else
                            p.LinkedAccounts += ", " + eA.AccountName;
                        i++;
                    }
                }
            }
        }

        #endregion Methods
    }
}