using EVESharpLauncher.SocksServer;
using SharedComponents.CurlUtil;
using SharedComponents.EVE;
using SharedComponents.IPC.TCP;
using SharedComponents.Notifcations;
using SharedComponents.SharpLogLite.Model;
using SharedComponents.Utility;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace EVESharpLauncher
{
    public partial class SettingsForm : Form
    {
        #region Constructors

        public SettingsForm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void buttonSendTestEmail_Click(object sender, EventArgs e)
        {
            Email.SendGmail(textBoxGmailPassword.Text, textBoxGmailUser.Text, textBoxReceiverEmailAddress.Text, "EVESharp Event: Test", "Test email.");
        }

        private void CheckBox1CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUseTorProxy.Checked) TorImpl.Instance.StartTorSocksProxy();
            else TorImpl.Instance.StopTorSocksProxy();

            Cache.Instance.EveSettings.UseTorSocksProxy = checkBoxUseTorProxy.Checked;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            textBoxEveLocation.Text = Cache.Instance.EveSettings.EveDirectory;
            textBoxGmailUser.Text = Cache.Instance.EveSettings.GmailUser;
            textBoxGmailPassword.Text = Cache.Instance.EveSettings.GmailPassword;
            textBoxReceiverEmailAddress.Text = Cache.Instance.EveSettings.ReceiverEmailAddress;
            checkBoxUseTorProxy.Checked = Cache.Instance.EveSettings.UseTorSocksProxy;
            trackBar1.Minimum = Cache.Instance.EveSettings.BackgroundFPSMin;
            trackBar1.Maximum = Cache.Instance.EveSettings.BackgroundFPSMax;
            if (Cache.Instance.EveSettings.BackgroundFPS < trackBar1.Minimum)
                Cache.Instance.EveSettings.BackgroundFPS = trackBar1.Minimum;
            if (Cache.Instance.EveSettings.BackgroundFPS > trackBar1.Maximum)
                Cache.Instance.EveSettings.BackgroundFPS = trackBar1.Maximum;
            trackBar1.Value = Cache.Instance.EveSettings.BackgroundFPS;

            if (Cache.Instance.EveSettings.TimeBetweenEVELaunchesMin < trackBar2.Minimum)
                Cache.Instance.EveSettings.TimeBetweenEVELaunchesMin = trackBar2.Minimum;
            if (Cache.Instance.EveSettings.TimeBetweenEVELaunchesMin > trackBar2.Maximum)
                Cache.Instance.EveSettings.TimeBetweenEVELaunchesMin = trackBar2.Maximum;
            trackBar2.Value = Cache.Instance.EveSettings.TimeBetweenEVELaunchesMin;

            if (Cache.Instance.EveSettings.TimeBetweenEVELaunchesMax < trackBar3.Minimum)
                Cache.Instance.EveSettings.TimeBetweenEVELaunchesMax = trackBar3.Minimum;
            if (Cache.Instance.EveSettings.TimeBetweenEVELaunchesMax > trackBar3.Maximum)
                Cache.Instance.EveSettings.TimeBetweenEVELaunchesMax = trackBar3.Maximum;
            trackBar3.Value = Cache.Instance.EveSettings.TimeBetweenEVELaunchesMax;

            comboBox1.DataSource = Enum.GetValues(typeof(LogSeverity));
            comboBox1.SelectedItem = Cache.Instance.EveSettings.SharpLogLiteLogSeverity;
            comboBox1.SelectedIndexChanged += delegate (object o, EventArgs args)
            {
                Cache.Instance.EveSettings.SharpLogLiteLogSeverity = (LogSeverity)comboBox1.SelectedItem;
            };


            comboBox2.DataSource = Enum.GetValues(typeof(RecorderEncoderSetting));
            comboBox2.SelectedItem = Cache.Instance.EveSettings.RecorderEncoderSetting;
            comboBox2.SelectedIndexChanged += delegate (object o, EventArgs args)
            {
                Cache.Instance.EveSettings.RecorderEncoderSetting = (RecorderEncoderSetting)comboBox2.SelectedItem;
            };

            checkBox1.Checked = Cache.Instance.EveSettings.AutoStartScheduler;
            checkBox2.Checked = Cache.Instance.EveSettings.AutoUpdateEve;
            checkBox3.Checked = Cache.Instance.EveSettings.DisableTLSVerifcation;
            CurlWorker.DisableSSLVerifcation = checkBox3.Checked;


            string fwRuleName = Cache.Instance.EveLocation;
            checkBox5.Checked = FirewallRuleHelper.CheckIfRuleNameExists(fwRuleName);

            if (Cache.Instance.EveSettings.BlockEveTelemetry)
            {
                // Recall block default in case of changes, will not update file if no changes
                HostsHelper.BlockDefault();
                checkBox4.Checked = true;
            }

            checkBox6.Checked = Cache.Instance.EveSettings.UseLegacyLogin;

            checkBox7.Checked = Cache.Instance.EveSettings.RemoteWCFServer; 
            checkBox8.Checked = Cache.Instance.EveSettings.RemoteWCFClient;
            checkBox9.Checked = Cache.Instance.EveSettings.AlwaysClearNonEveSharpCCPData;
            textBoxWCFIp.Text = Cache.Instance.EveSettings.RemoteWCFIpAddress;
            textBoxWCFPort.Text = Cache.Instance.EveSettings.RemoteWCFPort;

            _recordingEnableCheckbox.Checked = Cache.Instance.EveSettings.RecordingEnabled;
            _recordingLocationTextbox.Text = Cache.Instance.EveSettings.RecordingDirectory;
            textBox1.Text = Cache.Instance.EveSettings.VideoRotationMaximumSizeGB.ToString();
        }

        private void textBoxEveLocation_TextChanged(object sender, EventArgs e)
        {
            Cache.Instance.EveSettings.EveDirectory = textBoxEveLocation.Text;
        }
        

        private void textBoxGmailPassword_TextChanged(object sender, EventArgs e)
        {
            Cache.Instance.EveSettings.GmailPassword = textBoxGmailPassword.Text;
        }

        private void textBoxGmailUser_TextChanged(object sender, EventArgs e)
        {
            Cache.Instance.EveSettings.GmailUser = textBoxGmailUser.Text;
        }

        private void textBoxReceiverEmailAddress_TextChanged(object sender, EventArgs e)
        {
            Cache.Instance.EveSettings.ReceiverEmailAddress = textBoxReceiverEmailAddress.Text;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBar1, trackBar1.Value.ToString());
            Cache.Instance.EveSettings.BackgroundFPS = trackBar1.Value;
            Debug.WriteLine($"Setting backgroundFPS to {trackBar1.Value}");
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBar2, trackBar2.Value.ToString());
            Cache.Instance.EveSettings.TimeBetweenEVELaunchesMin = trackBar2.Value;
            Debug.WriteLine($"Setting TimeBetweenEVELaunchesMin to {trackBar2.Value}");
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBar3, trackBar3.Value.ToString());
            Cache.Instance.EveSettings.TimeBetweenEVELaunchesMax = trackBar3.Value;
            Debug.WriteLine($"Setting TimeBetweenEVELaunchesMax to {trackBar3.Value}");
        }

        #endregion Methods

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Cache.Instance.EveSettings.AutoStartScheduler = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Cache.Instance.EveSettings.AutoUpdateEve = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Cache.Instance.EveSettings.DisableTLSVerifcation = checkBox3.Checked;
            CurlWorker.DisableSSLVerifcation = checkBox3.Checked;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;
            if (cb.Checked)
            {
                FirewallRuleHelper.AddBlockingRule(Cache.Instance.EveLocation, Cache.Instance.EveLocation);
                FirewallRuleHelper.AddBlockingRule(Cache.Instance.EveLocation.Replace("tq", "sisi"), Cache.Instance.EveLocation.Replace("tq", "sisi"));
            }
            else
            {
                FirewallRuleHelper.RemoveRule(Cache.Instance.EveLocation);
                FirewallRuleHelper.RemoveRule(Cache.Instance.EveLocation.Replace("tq", "sisi"));
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;
            if (cb.Checked)
            {
                HostsHelper.BlockDefault();
            }
            else
            {
                HostsHelper.UnblockDefault();
            }
            Cache.Instance.EveSettings.BlockEveTelemetry = cb.Checked;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;
            Cache.Instance.EveSettings.UseLegacyLogin = cb.Checked;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;
            Cache.Instance.EveSettings.RemoteWCFClient = cb.Checked;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;
            Cache.Instance.EveSettings.RemoteWCFServer = cb.Checked;

            if (cb.Checked)
            {
                if (WCFServerTCP.Instance.StartWCFServer())
                    Cache.Instance.Log($"Starting TCP WCFServer. IP:PORT {Cache.Instance.EveSettings.RemoteWCFIpAddress}:{Cache.Instance.EveSettings.RemoteWCFPort}");
            }
            else
            {
                WCFServerTCP.Instance.StopWCFServer();
                //Cache.Instance.Log($"Stopped TCP WCFServer. IP:PORT {Cache.Instance.EveSettings.RemoteWCFIpAddress}:{Cache.Instance.EveSettings.RemoteWCFPort}");
            }
        }

        private void textBoxWCFIp_TextChanged(object sender, EventArgs e)
        {
            Cache.Instance.EveSettings.RemoteWCFIpAddress = textBoxWCFIp.Text;
        }

        private void textBoxWCFPort_TextChanged(object sender, EventArgs e)
        {
            Cache.Instance.EveSettings.RemoteWCFPort = textBoxWCFPort.Text;
        }

        private void _recordingEnableCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Cache.Instance.EveSettings.RecordingEnabled = _recordingEnableCheckbox.Checked;
        }

        private void _recordingLocationTextbox_TextChanged(object sender, EventArgs e)
        {
            Cache.Instance.EveSettings.RecordingDirectory = _recordingLocationTextbox.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Cache.Instance.EveSettings.VideoRotationMaximumSizeGB = Convert.ToInt32(textBox1.Text);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;
            Cache.Instance.EveSettings.AlwaysClearNonEveSharpCCPData = cb.Checked;
        }
    }
}