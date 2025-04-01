using EVESharpLauncher.SocksServer;
using SharedComponents.EVE;
using SharedComponents.Events;
using SharedComponents.Extensions;
using SharedComponents.IPC;
using SharedComponents.Notifcations;
using SharedComponents.SharpLogLite.Model;
using SharedComponents.Utility;
using SharedComponents.WinApiUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceStack;
using ServiceStack.OrmLite;
using SharedComponents.CurlUtil;
using SharedComponents.SeleniumDriverHandler;
using SharedComponents.SharedMemory;
using SharedComponents.IPC.TCP;

namespace EVESharpLauncher
{
    public partial class MainForm : Form
    {
        #region Fields

        private static Color backColor = Color.FromArgb(0, 113, 188);
        private ClientSettingForm clientSettingForm;

        private ThumbPreviewTab thumbPreviewTab;

        #endregion Fields

        #region Constructors

        public MainForm()
        {
            InitializeComponent();
            evenTabs = new Dictionary<string, MainFormEventTab>();
            logTab = new MainFormEventTab("Log", true);
            tabControl1.TabPages.Add(logTab);
            Cache.AsyncLogQueue.OnMessage += Log;
            Cache.AsyncLogQueue.StartWorker();
            DirectEventHandler.OnDirectEvent += OnNewDirectEvent;
            ConsoleEventHandler.OnConsoleEvent += OnNewConsoleEvent;
            SharpLogLiteHandler.Instance.OnSharpLogLiteMessage += InstanceOnSharpLogLiteMessage;
            thumbPreviewTab = new ThumbPreviewTab(this, mainTabCtrl);
        }

        #endregion Constructors

        #region Properties

        private IntPtr CurrentHandle { get; set; }
        private Dictionary<string, MainFormEventTab> evenTabs { get; set; }
        private MainFormEventTab logTab { get; set; }

        private bool stopDebugLaunch { get; set; }

        #endregion Properties

        #region Methods

        public void DisableDrawDatagrid()
        {
            Pinvokes.SendMessage(dataGridEveAccounts.Handle, Pinvokes.WM_SETREDRAW, false, 0);
        }

        public void EnableDrawDatagrid()
        {
            Pinvokes.SendMessage(dataGridEveAccounts.Handle, Pinvokes.WM_SETREDRAW, true, 0);
            dataGridEveAccounts.Refresh();
        }

        public void Log(string msg, Color? col = null)
        {
            if (!IsHandleCreated)
                return;
            try
            {
                logTab.Invoke(new Action(() => { logTab.AddRawMessage(msg); }));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public void OnNewDirectEvent(string charName, DirectEvent directEvent)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    Email.onNewDirectEvent(charName, directEvent);
                    GetEventTab(charName).AddNewEvent(directEvent);
                }));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public void OnNewConsoleEvent(string charName, string message, bool isErr)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    GetEventTab(charName).AddRawConsoleMessage(message,  isErr);
                }));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs ex)
        {


            //foreach (var domain in CLRUtil.EnumAppDomains())
            //{
            //    Debug.WriteLine("Found appdomain {0}", domain.FriendlyName);
            //}

            //var url = "https://api.evemarketer.com/ec/marketstat/json?typeid=47903&usesystem=30000142";
            //using (var rcc = WriteConn.Open())
            //{
            //    if (rcc.DB.Exists<CachedWebsiteEntry>(x => x.Url == url))
            //    {
            //        var allEntries = rcc.DB.Select<CachedWebsiteEntry>(x => x.Url == url);
            //        Debug.WriteLine($"AllEntries Count {allEntries.Count}");
            //        rcc.DB.Delete<CachedWebsiteEntry>(x => x.Url == url);
            //    }
            //}
            //Util.PlayNoticeSound();

            //var t = new Thread(() =>
            //{

            //    Debug.WriteLine("--STARTED--");
            //    while (true)
            //    {
            //        try
            //        {
            //            if (Cache.IsShuttingDown)
            //                break;

            //            Thread.Sleep(20);
            //            using (new DisposableStopwatch(tx =>
            //            {
            //                //Cache.Instance.Log($"{1000000 * t.Ticks / Stopwatch.Frequency}  µs elapsed.");
            //                Cache.Instance.Log($"{(1000000 * tx.Ticks / Stopwatch.Frequency) / 1000} ms elapsed.");

            //            }))
            //            {
            //                var task = Task.Run(() =>
            //                {
            //                    var isRunningOnARemoteInstance = WCFClientTCP.Instance.GetPipeProxy.IsEveInstanceRunning("test");
            //                    return isRunningOnARemoteInstance;
            //                });

            //                var timeoutTask = Task.Delay(TimeSpan.FromSeconds(2));
            //                var completedTask = Task.WhenAny(task, timeoutTask).GetAwaiter().GetResult();

            //                if (completedTask == task)
            //                {
            //                    bool result = task.GetAwaiter().GetResult();
            //                }
            //                else
            //                {
            //                    // Handle the timeout case here
            //                    Debug.WriteLine("Timeout occurred.");
            //                }
            //            }

            //        }
            //        catch (Exception e)
            //        {
            //            Debug.WriteLine(e);
            //        }
            //    }

            //})
            //{

            //};
            //t.Start();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                try
                {
                    Cache.Instance.EveAccountSerializeableSortableBindingList.List.Where(k => k.GetClientCallback() != null)
                        .ToList()
                        .ForEach(k =>
                        {
                            try
                            {
                                k.GetClientCallback().GotoJita();
                            }
                            catch
                            {
                            }
                        });
                    EveManager.Instance.Dispose();
                }
                catch (Exception ex)
                {
                    Log("Exception: " + ex);
                }
            }).Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cache.Instance.EveAccountSerializeableSortableBindingList.List.ToList().ForEach(k => k.ClearCache());
        }

        private void ButtonbuttonKillAllEveInstancesNowClick(object sender, EventArgs e)
        {
            stopDebugLaunch = true;
            EveManager.Instance.KillEveInstances();
        }

        private void buttonCheckHWProfiles_Click(object sender, EventArgs e)
        {

        }

        private void ButtonGenNewBeginEndClick(object sender, EventArgs e)
        {
            foreach (var eA in Cache.Instance.EveAccountSerializeableSortableBindingList.List)
                eA.GenerateNewTimeSpan();
        }

        private void ButtonKillAllEveInstancesClick(object sender, EventArgs e)
        {
            EveManager.Instance.KillEveInstancesDelayed();
        }

        private void ButtonStartEveMangerClick(object sender, EventArgs e)
        {
            EveManager.Instance.StartEveManager();
        }

        private void ButtonStopEveMangerClick(object sender, EventArgs e)
        {
            EveManager.Instance.Dispose();
        }

        private void clearCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(ActiveControl is DataGridView dgv)) return;
            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];
            eA.ClearCache();
        }

        private void ContextMenuStrip1Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (!(ActiveControl is DataGridView dgv)) return;
                var index = dgv.SelectedCells[0].OwningRow.Index;
                var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.ToString());
            }
        }

        private void dataGridEveAccounts_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Task.Run(() =>
            {
                dataGridEveAccounts.Invoke(new Action(() =>
                {
                    dataGridEveAccounts.ColumnHeadersDefaultCellStyle.BackColor = backColor; // #0071BC
                    dataGridEveAccounts.BackColor = backColor;
                }));
                Cache.Instance.EveAccountSerializeableSortableBindingList.List.RaiseListChangedEvents = false;
            });
            dataGridEveAccounts.SuspendLayout();
        }

        private void dataGridEveAccounts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Task.Run(() =>
            {
                dataGridEveAccounts.Invoke(new Action(() => { dataGridEveAccounts.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control; }));
                Cache.Instance.EveAccountSerializeableSortableBindingList.List.RaiseListChangedEvents = true;
            });
            dataGridEveAccounts.ResumeLayout();
        }

        private void dataGridEveAccounts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                var name = dataGridEveAccounts.Columns[e.ColumnIndex].Name;

                if (name.Equals("Pattern"))
                {
                    if (dataGridEveAccounts.CurrentCell != null && dataGridEveAccounts.CurrentCell.IsInEditMode)
                    {
                        var cIndex = dataGridEveAccounts.CurrentCell.ColumnIndex;
                        var rIndex = dataGridEveAccounts.CurrentCell.RowIndex;

                        if (e.RowIndex == rIndex && e.ColumnIndex == cIndex)
                            return;
                    }

                    if (e.Value != null)
                    {
                        var eA = (EveAccount)dataGridEveAccounts.Rows[e.RowIndex].DataBoundItem;
                        dataGridEveAccounts.Rows[e.RowIndex].Tag = e.Value;
                        e.Value = eA.FilledPattern;
                    }
                }

                if (name.Contains("Password"))
                {
                    if (dataGridEveAccounts.CurrentCell != null && dataGridEveAccounts.CurrentCell.IsInEditMode)
                    {
                        var cIndex = dataGridEveAccounts.CurrentCell.ColumnIndex;
                        var rIndex = dataGridEveAccounts.CurrentCell.RowIndex;

                        if (e.RowIndex == rIndex && e.ColumnIndex == cIndex)
                            return;
                    }

                    if (e.Value != null)
                    {
                        dataGridEveAccounts.Rows[e.RowIndex].Tag = e.Value;
                        e.Value = new String('\u25CF', e.Value.ToString().Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void dataGridEveAccounts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var dgv = (DataGridView)sender;
                var c = dataGridEveAccounts.SelectedCells[0];
                var index = c.OwningRow.Index;
                if (c.OwningColumn.Name == "Controller")
                {
                    var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];
                    eA.SelectedController = (string)c.Value;
                }

                if (c.OwningColumn.Name == "Group")
                {
                    var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];
                    eA.SelectedGroup = (string)c.Value;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void dataGridEveAccounts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // just do nothing in that case
        }

        private void dataGridEveAccounts_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (var b = new SolidBrush(dataGridEveAccounts.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 14, e.RowBounds.Location.Y + 4);
            }
        }

        private void dataGridEveAccounts_SelectionChanged(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    var eventTableLayoutPanel = new TableLayoutPanel();
                    eventTableLayoutPanel.Location = new Point(3, 3);
                    var count = 12;
                    eventTableLayoutPanel.RowCount = count;
                    eventTableLayoutPanel.ColumnCount = 1;
                    eventTableLayoutPanel.Dock = DockStyle.Fill;
                    eventTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                    var labelDict = new Dictionary<int, Label>();

                    for (var i = 0; i < count; i++)
                    {
                        eventTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / count));
                        var l1 = new Label();
                        labelDict[i] = l1;
                        l1.Dock = DockStyle.Fill;
                        eventTableLayoutPanel.Controls.Add(l1);
                    }

                    if (!(ActiveControl is DataGridView dgv)) return;
                    if (dgv.SelectedCells.Count > 0)
                    {
                        var index = dgv.SelectedCells[0].OwningRow.Index;
                        if (Cache.Instance.EveAccountSerializeableSortableBindingList.List.ElementAtOrDefault(index) != null)
                        {
                            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];
                            if (eA != null && eA.CharsOnAccount != null)
                                labelDict[0].Text = $"Other chars: {string.Join(", ", eA.CharsOnAccount.Where(h => !h.Equals(eA.CharacterName)))}";
                            labelDict[1].Text = $"Last ammo buy: {eA.LastAmmoBuy}";
                            labelDict[2].Text = $"Last plex buy: {eA.LastPlexBuy}";
                            labelDict[3].Text = $"Last start time: {eA.LastStartTime}";
                            labelDict[4].Text = $"Next cache deletion: {eA.NextCacheDeletion}";
                            labelDict[5].Text = $"Process Id: {eA.Pid}";
                            labelDict[6].Text = $"Ram usage: {Math.Round(eA.RamUsage, 1)} mb";
                            labelDict[7].Text = $"Run time today: {Math.Round(eA.StartingTokenTimespan.TotalHours, 2)} h";
                            var skillQueueEnd = eA.SkillQueueEnd > DateTime.UtcNow ? eA.SkillQueueEnd : DateTime.UtcNow;
                            labelDict[8].Text = $"Skill queue end: {Math.Round((skillQueueEnd - DateTime.UtcNow).TotalDays, 2)} days";
                            labelDict[9].Text = $"Dump loot iterations: {eA.DumpLootIterations}";
                        }
                    }

                    tabControl3.Invoke(new Action(() =>
                    {
                        tabPage3.Controls.Clear();
                        tabPage3.SuspendLayout();
                        tabPage3.Controls.Add(eventTableLayoutPanel);
                        tabPage3.ResumeLayout();
                    }));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            });
        }

        private void DeleteToolStripMenuItem1Click(object sender, EventArgs e)
        {
            if (!(ActiveControl is DataGridView dgv)) return;
            var selected = dgv.SelectedCells[0].OwningRow.Index;

            if (selected >= 0)
                Cache.Instance.EveAccountSerializeableSortableBindingList.List.RemoveAt(selected);
        }

        private void EditAdapteveHWProfileToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (!(ActiveControl is DataGridView dgv)) return;
            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];

            var hwPf = new HWProfileForm(eA);
            hwPf.Show();
        }

        private void editClientConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(ActiveControl is DataGridView dgv)) return;
            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];
            if (clientSettingForm != null)
                clientSettingForm.Close();
            clientSettingForm = new ClientSettingForm(eA);
            clientSettingForm.Show();
        }

        private MainFormEventTab GetEventTab(string charName)
        {
            MainFormEventTab tab;
            evenTabs.TryGetValue(charName, out tab);
            if (tab == null)
            {
                tab = new MainFormEventTab(charName);
                evenTabs[charName] = tab;
                tabControl1.TabPages.Add(tab);
            }

            return tab;
        }

        private void HideToolStripMenuItemClick(object sender, EventArgs e)
        {
            foreach (var eA in Cache.Instance.EveAccountSerializeableSortableBindingList.List.Where(a => a.EveProcessExists()))
                eA.HideWindows();
        }

        private void InstanceOnSharpLogLiteMessage(SharpLogMessage msg)
        {
            if (EveAccount.CharnameByPid.TryGetValue((int)msg.Pid, out var charName))
                Invoke(new Action(() =>
                {
                    var tab = GetEventTab(charName);
                    tab.AddSharpLogLiteMessage(msg, charName);
                }));
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            CurrentHandle = Handle;
            MainFormResize(this, new EventArgs());
            Cache.Instance.MainFormHWnd = (Int64)CurrentHandle;



            if (Cache.Instance.EveSettings.AutoStartScheduler)
                EveManager.Instance.StartEveManager();
        }

        private void MainFormFormClosed(object sender, FormClosedEventArgs e)
        {
            SharpLogLiteHandler.Instance.Dispose();

            //Cache.Instance.EveAccountSerializeableSortableBindingList.List.XmlSerialize(Cache.Instance.EveAccountSerializeableSortableBindingList.FilePathName);
            //Cache.Instance.EveSettingsSerializeableSortableBindingList.List.XmlSerialize(Cache.Instance.EveSettingsSerializeableSortableBindingList.FilePathName);

            SharpLogLiteHandler.Instance.OnSharpLogLiteMessage -= InstanceOnSharpLogLiteMessage;
            DirectEventHandler.OnDirectEvent -= OnNewDirectEvent;
            ConsoleEventHandler.OnConsoleEvent -= OnNewConsoleEvent;
            EveManager.Instance.Dispose();
            Cache.IsShuttingDown = true;
            Cache.BroadcastShutdown();
            TorImpl.Instance.StopTorSocksProxy();
            DriverHandler.DisposeAllDrivers();
            Util.KillAllChildProcesses(Process.GetCurrentProcess().Id, new List<String>() { "exefile", "updater" });
            try
            {
                Application.Exit();
            }
            catch (Exception)
            {
            }
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            dataGridEveAccounts.DataSource = Cache.Instance.EveAccountSerializeableSortableBindingList.List;
            {
                var cmb = new DataGridViewComboBoxColumn();
                cmb.HeaderText = "Controller";
                cmb.Name = "Controller";
                cmb.MaxDropDownItems = EveAccount.AvailableControllers.Count + 1;
                cmb.DataSource = EveAccount.AvailableControllers;
                dataGridEveAccounts.Columns.Insert(dataGridEveAccounts.Columns["IsActive"].Index, cmb);

                foreach (DataGridViewRow r in dataGridEveAccounts.Rows)
                    foreach (DataGridViewCell c in r.Cells)
                        if (c.OwningColumn.Name == "Controller")
                        {
                            var index = c.OwningRow.Index;
                            try
                            {
                                var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];
                                c.Value = eA.SelectedController;
                            }
                            catch
                            {
                            }
                        }

            }

            {
                var max = 30;
                var cmb = new DataGridViewComboBoxColumn();
                cmb.HeaderText = "Group";
                cmb.Name = "Group";
                cmb.MaxDropDownItems = max;
                cmb.DataSource = Enumerable.Range(0, max).Select(i => i.ToString()).ToList();
                dataGridEveAccounts.Columns.Insert(dataGridEveAccounts.Columns["Controller"].Index, cmb);

                foreach (DataGridViewRow r in dataGridEveAccounts.Rows)
                    foreach (DataGridViewCell c in r.Cells)
                        if (c.OwningColumn.Name == "Group")
                        {
                            var index = c.OwningRow.Index;
                            try
                            {
                                var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];
                                c.Value = eA.SelectedGroup;

                            }
                            catch
                            {
                            }
                        }

            }
            //dataGridEveAccounts.Columns["Info"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //dataGridEveAccounts.Columns["Info"].Width = 220;

            if (Cache.Instance.EveSettings.UseTorSocksProxy)
                TorImpl.Instance.StartTorSocksProxy();

            foreach (var eA in Cache.Instance.EveAccountSerializeableSortableBindingList.List.Where(eA => !eA.EveProcessExists()))
                eA.Pid = -1;

            try
            {
                if (textBoxPastebin != null)
                    textBoxPastebin.Text = Regex.Replace(Cache.Instance.EveSettings.Pastebin, @"\r\n|\n\r|\n|\r", Environment.NewLine);
            }
            catch (Exception)
            {
            }

            try
            {

                if (Cache.Instance.EveSettings.RemoteWCFServer || Cache.Instance.EveSettings.RemoteWCFClient)
                {
                    Task.Run(() =>
                    {
                        try
                        {
                            _ = WCFClientTCP.Instance.GetPipeProxy;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                        }
                    });
                }

                if (Cache.Instance.EveSettings.RemoteWCFServer)
                {
                    if (WCFServerTCP.Instance.StartWCFServer())
                        Cache.Instance.Log($"Starting TCP WCFServer. IP:PORT {Cache.Instance.EveSettings.RemoteWCFIpAddress}:{Cache.Instance.EveSettings.RemoteWCFPort}");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            WCFServer.Instance.StartWCFServer();
            WCFClient.Instance.pipeName = Cache.Instance.EveSettings.WCFPipeName;

            foreach (DataGridViewColumn col in dataGridEveAccounts.Columns)
            {
                var index = col.Index;
                var name = col.Name;
                var menuItem = new ToolStripMenuItem();
                menuItem.Checked = true;

                if (Cache.Instance.EveSettings.DatagridViewHiddenColumns.Contains(index))
                {
                    menuItem.Checked = false;
                    dataGridEveAccounts.Columns[index].Visible = false;
                }

                menuItem.Click += (o, args) =>
                {
                    var ts = (ToolStripMenuItem)o;
                    ts.Checked = !ts.Checked;
                    dataGridEveAccounts.Columns[index].Visible = ts.Checked;

                    if (ts.Checked)
                    {
                        if (Cache.Instance.EveSettings.DatagridViewHiddenColumns.Any(k => k == index))
                            Cache.Instance.EveSettings.DatagridViewHiddenColumns.Remove(index);
                    }
                    else
                    {
                        if (!Cache.Instance.EveSettings.DatagridViewHiddenColumns.Any(k => k == index))
                            Cache.Instance.EveSettings.DatagridViewHiddenColumns.Add(index);
                    }
                };
                menuItem.Text = name;
                columnsToolStripMenuItem.DropDownItems.Add(menuItem);
            }

            dataGridEveAccounts.FastAutoSizeColumns();

            FormUtil.SetDoubleBuffered(dataGridEveAccounts);
            //SetDoubleBuffered(flowLayoutPanel1);

            var tokenSource = new CancellationTokenSource();
            Task.Run(() =>
            {
                while (!tokenSource.Token.IsCancellationRequested)
                {
                    tokenSource.Token.WaitHandle.WaitOne(5000);
                    try
                    {
                        dataGridEveAccounts.Invoke(new Action(() => { dataGridEveAccounts.FastAutoSizeColumns(); }));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
            }, tokenSource.Token);

            mainTabCtrl.TabPages.Add(thumbPreviewTab);


            CurlWorker.DisableSSLVerifcation = Cache.Instance.EveSettings.DisableTLSVerifcation;
        }

        private void MainFormResize(object sender, EventArgs e)
        {
            try
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    Visible = false;
                    notifyIconQL.Visible = true;
                    Cache.Instance.IsMainFormMinimized = true;

                    foreach (var eA in Cache.Instance.EveAccountSerializeableSortableBindingList.List)
                        eA.HideWindows();
                }
            }
            catch (Exception ex)
            {
                Cache.Instance.Log(ex.ToString());
            }
        }

        private void mainTabCtrl_Selected(object sender, TabControlEventArgs e)
        {
            // pass to...
            thumbPreviewTab.Selected(sender, e);
        }

        private void notifyIconQL_Click(object sender, EventArgs e)
        {
            ((NotifyIcon)sender).Visible = !((NotifyIcon)sender).Visible;
            Visible = !Visible;
            Cache.Instance.IsMainFormMinimized = false;
            //WindowState = FormWindowState.Maximized;
            foreach (var eA in Cache.Instance.EveAccountSerializeableSortableBindingList.List.Where(eA => !eA.Hidden))
                eA.ShowWindows();
            WindowState = FormWindowState.Normal;
        }

        private void openEveAccountCreatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EveAccountCreatorForm().Show();
        }

        private void proxiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ProxiesForm().Show();
        }

        private void SelectProcessToProxyToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (!(ActiveControl is DataGridView dgv)) return;
            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];
            eA.StartExecuteable(String.Empty);
            return;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SettingsForm();
            form.ShowDialog();
        }

        private void showRealHardwareInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RealHardwareInfoForm().Show();
        }

        private void ShowToolStripMenuItemClick(object sender, EventArgs e)
        {
            foreach (var eA in Cache.Instance.EveAccountSerializeableSortableBindingList.List.Where(a => a.EveProcessExists()))
                eA.ShowWindows();
        }

        private void StartInjectToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (!(ActiveControl is DataGridView dgv)) return;
            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];
            new Thread(eA.StartEveInject).Start();
            return;
        }

        private void StatisticsToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        private void textBoxPastebin_TextChanged(object sender, EventArgs e)
        {
            Cache.Instance.EveSettings.Pastebin = textBoxPastebin.Text;
        }

        private void ToolStripMenuItem1Click(object sender, EventArgs e)
        {
            //if (!(ActiveControl is DataGridView dgv)) return;

            //var index = dgv.SelectedCells[0].OwningRow.Index;
            //var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];

            //if (eA.HWSettings != null && eA.HWSettings.Proxy != null)
            //    eA.HWSettings.Proxy.StartFireFoxInject();
            //return;


            if (!(ActiveControl is DataGridView dgv)) return;

            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];

            if (eA.HWSettings != null && eA.HWSettings.Proxy != null)
            {
                eA.DisposeDriverHandler();
                var handler = eA.GetDriverHandler();
            }
        }

        private void UpdateEVESharpToolStripMenuItemClick(object sender, EventArgs e)
        {
            Util.RunInDirectory("Updater.exe", false);
            Close();
            try
            {
                Application.Exit();
            }
            catch (Exception)
            {
            }
        }

        #endregion Methods

        private void resetLastAmmoBuyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(ActiveControl is DataGridView dgv)) return;

            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];

            if (eA.HWSettings != null)
                eA.LastAmmoBuy = DateTime.MinValue;
            return;
        }

        private void openDatabaseViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Thread(() =>
                {
                    try
                    {
                        new DBViewer().ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                }
            ).Start();
        }

        private void clearLoginTokensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(ActiveControl is DataGridView dgv)) return;
            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];
            eA.ClearTokens();
        }


        private void resetLastPlexBuyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(ActiveControl is DataGridView dgv)) return;

            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];

            if (eA.HWSettings != null)
                eA.LastPlexBuy = DateTime.MinValue;
            return;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private bool _changed;
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.UtcNow.ToString();
            if (!_changed)
            {
                var p = new System.Drawing.Point();
                p.X = label1.Location.X - Math.Abs(label1.Size.Width - 32);
                p.Y = label1.Location.Y;
                label1.Location = p;
                label1.BackColor = Color.White;
                _changed = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
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

        private void editPatternManagerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(ActiveControl is DataGridView dgv)) return;
            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];

            var frm = new PatternManagerForm(eA);
            frm.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void openQuestorStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                try
                {
                    new StatisticsForm().ShowDialog();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
       ).Start();
        }

        private void checkAccountLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cache.Instance.AnyAccountsLinked(true);
        }


        private void clearAllEveCachesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cache.Instance.EveAccountSerializeableSortableBindingList.List.ToList().ForEach(k => k.ClearCache());
        }

        private void cloneAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(ActiveControl is DataGridView dgv)) return;
            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];
            var cloned = eA.Clone();
            cloned.ClearCache();
            cloned.ClearTokens();
            Cache.Instance.EveAccountSerializeableSortableBindingList.List.Add(cloned);
        }


        private void openMailInboxToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!(ActiveControl is DataGridView dgv)) return;

            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];

            Task.Run(() =>
            {

                try
                {
                    eA.GetDriverHandler(false, true).MailInboxHandler.OpenMailInbox();
                }
                catch (Exception ex)
                {

                    Cache.Instance.Log(ex.ToString());
                }

            });

        }

        private void parseHWDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HWSettings.ParseHardwareDetailsFromDxDiagFolder();
        }

        private void closeAllSocketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(ActiveControl is DataGridView dgv)) return;
                var index = dgv.SelectedCells[0].OwningRow.Index;
                var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];
                var a = new SharedArray<bool>(eA.CharacterName + nameof(UsedSharedMemoryNames.DisableAllWinsocketSocketsAndPreventNew));
                a[0] = true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void debugLaunchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopDebugLaunch = false;
            if (!(ActiveControl is DataGridView dgv)) return;

            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];

            new Thread(() =>
            {
                try
                {
                    int startCnt = 0;
                    int successLogin = 0;
                    DateTime lastStart = DateTime.UtcNow;
                    while (!stopDebugLaunch && startCnt < 50)
                    {
                        if (eA.EveProcessExists())
                        {
                            if (eA.LoggedIn)
                            {
                                successLogin++;
                                Cache.Instance.Log($"Successfully logged in. SuccessfulStarts [{successLogin}] TotalStarts [{startCnt}]");
                                eA.KillEveProcess();
                                Thread.Sleep(1000);
                            }

                            if ((lastStart - DateTime.UtcNow).TotalSeconds > 120)
                            {
                                Cache.Instance.Log($"Failed to login. SuccessfulStarts [{successLogin}] TotalStarts [{startCnt}]");
                                stopDebugLaunch = true;
                            }
                        }
                        else
                        {
                            if (startCnt != successLogin)
                            {
                                Cache.Instance.Log($"Failed to login. SuccessfulStarts [{successLogin}] TotalStarts [{startCnt}]");
                                stopDebugLaunch = true;
                                break;
                            }

                            lastStart = DateTime.UtcNow;
                            eA.StartEveInject();
                            startCnt++;
                            Thread.Sleep(1000);
                        }

                        Thread.Sleep(500);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

            }).Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                try
                {
                    Cache.Instance.EveAccountSerializeableSortableBindingList.List.Where(k => k.GetClientCallback() != null)
                        .ToList()
                        .ForEach(k =>
                        {
                            try
                            {
                                k.GetClientCallback().RestartEveSharpCore();
                            }
                            catch
                            {
                            }
                        });
                }
                catch (Exception ex)
                {
                    Log("Exception: " + ex);
                }
            }).Start();
        }

        private void dataGridEveAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void launchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(ActiveControl is DataGridView dgv)) return;
            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];
            var groupId = eA.SelectedGroup;

            if (groupId == "0")
                return;

            foreach (var acc in Cache.Instance.EveAccountSerializeableSortableBindingList.List)
            {
                if (groupId == acc.SelectedGroup)
                {

                    new Task(() =>
                    {
                        try
                        {
                            acc.StartEveInject();
                        }
                        catch (Exception exception)
                        {
                            Debug.WriteLine(exception);
                        }
                    }).Start();

                }
            }
        }

        private void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(ActiveControl is DataGridView dgv)) return;
            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];
            var groupId = eA.SelectedGroup;

            if (groupId == "0")
                return;

            foreach (var acc in Cache.Instance.EveAccountSerializeableSortableBindingList.List)
            {
                if (groupId == acc.SelectedGroup)
                {
                    acc.KillEveProcess(true);
                }
            }
        }

        private void restartECoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(ActiveControl is DataGridView dgv)) return;
            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];
            var groupId = eA.SelectedGroup;

            if (groupId == "0")
                return;

            Cache.Instance.EveAccountSerializeableSortableBindingList.List.Where(k => k.GetClientCallback() != null && k.SelectedGroup == groupId)
                .ToList()
                .ForEach(k =>
                {
                    try
                    {
                        k.GetClientCallback().RestartEveSharpCore();
                    }
                    catch
                    {
                    }
                });
        }

        private void exportToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(ActiveControl is DataGridView dgv)) return;
            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];

            if (eA.HWSettings == null || eA.HWSettings.Proxy == null)
            {
                Cache.Instance.Log("eA.HWSettings == null || eA.HWSettings.Proxy == null");
                return;
            }

            var proxy = eA.HWSettings.Proxy;

            var result = $"{CompressUtil.Compress(Util.XmlSerialize(eA))}|{CompressUtil.Compress(Util.XmlSerialize(proxy))}";
            Clipboard.SetText(result);
        }

        private void importEveAccountFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string clipboard = Clipboard.GetText();

            if (!clipboard.Contains("|"))
            {
                return;
            }

            var base64EveAcc = clipboard.Split('|')[0];
            var base64Proxy = clipboard.Split('|')[1];


            try
            {

                // proxy handling
                var proxy = Util.XmlDeserialize(CompressUtil.DecompressText(base64Proxy), typeof(Proxy));
                // check if there is already a proxy available locally, else create one

                var isProxy = proxy is Proxy;

                if (!isProxy)
                {
                    Cache.Instance.Log("Imported proxy type could not be found.");
                    return;
                }

                var ppProxy = (Proxy)proxy;

                var localProxy = Cache.Instance.EveSettings.Proxies.FirstOrDefault(p => p.GetHashcode() == ppProxy.GetHashcode());

                if (localProxy == null)
                {
                    Cache.Instance.EveSettings.Proxies.Add(ppProxy);
                    localProxy =
                        Cache.Instance.EveSettings.Proxies.FirstOrDefault(p =>
                            p.GetHashcode() == ppProxy.GetHashcode());
                    if (localProxy == null)
                    {
                        Cache.Instance.Log("Could not add the imported proxy.");
                        return;
                    }
                }

                var eveAcc = Util.XmlDeserialize(CompressUtil.DecompressText(base64EveAcc), typeof(EveAccount));
                if (eveAcc is EveAccount setting)
                {
                    var eA = (EveAccount)eveAcc;

                    eA.HWSettings.ProxyId = localProxy.Id;

                    //if (Cache.Instance.EveAccountSerializeableSortableBindingList.List.Any(e => e.CharacterName == eA.CharacterName))
                    //{
                    //    Cache.Instance.Log($"There is already one eve account with that character name.");
                    //    return;
                    //}

                    Cache.Instance.EveAccountSerializeableSortableBindingList.List.Add(eA);
                    Cache.Instance.Log($"Eve account imported.");
                }
            }
            catch (Exception ex)
            {
                Cache.Instance.Log($"Unable to import eve account from clipboard.");
            }
        }

        private void clearWinUserDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(ActiveControl is DataGridView dgv)) return;
            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];
            var winUserName = eA?.HWSettings?.WindowsUserLogin ?? String.Empty;

            if (!string.IsNullOrEmpty(winUserName))
            {
                var path = "C:\\Users\\" + winUserName;
                if (Directory.Exists((path)))
                {
                    Directory.Delete(path, true);
                }
            }
        }

        private void startDelayedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(ActiveControl is DataGridView dgv)) return;
            var index = dgv.SelectedCells[0].OwningRow.Index;
            var eA = Cache.Instance.EveAccountSerializeableSortableBindingList.List[index];
            new Thread(() =>
            {
                try
                {
                    Thread.Sleep(5000);
                    eA.StartEveInject();
                }
                catch (Exception exception)
                {

                }

            }).Start();
        }
    }
}