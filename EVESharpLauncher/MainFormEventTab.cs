using SharedComponents.Controls;
using SharedComponents.EVE;
using SharedComponents.Events;
using SharedComponents.SharpLogLite.Model;
using SharedComponents.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ServiceStack;
using SharedComponents.Extensions;

namespace EVESharpLauncher
{
    internal class MainFormEventTab : TabPage
    {
        #region Constructors

        public MainFormEventTab(string title, bool islogTab = false, Image image = null) : base(title)
        {
            Leave += delegate (object sender, EventArgs args)
            {
                if (ImageIndex == 0)
                    ImageIndex = -1;
            };

            HandleDestroyed += delegate (object sender, EventArgs args) { };

            this.title = title;
            headerlistViewDirectEveEvents = (ColumnHeader)new ColumnHeader();
            headerlistViewDirectEveEvents.Text = "";
            headerlistViewDirectEveEvents.Width = 4000;

            headerlistViewSharpLogLiteMessages = (ColumnHeader)new ColumnHeader();
            headerlistViewSharpLogLiteMessages.Text = "";
            headerlistViewSharpLogLiteMessages.Width = 4000;

            headerlistViewConsole = (ColumnHeader)new ColumnHeader();
            headerlistViewConsole.Text = "";
            headerlistViewConsole.Width = 4000;

            listViewDirectEveEvents = new ListView();
            listViewDirectEveEvents.OwnerDraw = true;
            listViewDirectEveEvents.DrawColumnHeader += DrawColumnHeader;
            FormUtil.Color = listViewDirectEveEvents.BackColor;
            FormUtil.Font = listViewDirectEveEvents.Font;
            listViewDirectEveEvents.DrawItem += FormUtil.DrawItem;
            listViewDirectEveEvents.AutoArrange = false;
            listViewDirectEveEvents.Columns.AddRange(new ColumnHeader[] { headerlistViewDirectEveEvents });
            listViewDirectEveEvents.Dock = DockStyle.Fill;
            listViewDirectEveEvents.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            listViewDirectEveEvents.HeaderStyle = ColumnHeaderStyle.None;
            listViewDirectEveEvents.Location = new Point(3, 3);
            listViewDirectEveEvents.UseCompatibleStateImageBehavior = false;
            listViewDirectEveEvents.View = View.Details;
            listViewDirectEveEvents.Activation = ItemActivation.Standard;
            listViewDirectEveEvents.ItemActivate += delegate (object sender, EventArgs args)
            {
                var i = listViewDirectEveEvents.SelectedIndices[0];
                new ListViewItemForm(Regex.Replace(listViewDirectEveEvents.Items[i].Tag.ToString(), @"\r\n|\n\r|\n|\r", Environment.NewLine)).Show();
            };

            if (islogTab)
                Controls.Add(listViewDirectEveEvents);

            if (!islogTab)
            {
                Text += " (0)";
                listViewSharpLogLiteMessages = new ListView();
                listViewSharpLogLiteMessages.OwnerDraw = true;
                listViewSharpLogLiteMessages.DrawColumnHeader += DrawColumnHeader;
                FormUtil.Color = listViewSharpLogLiteMessages.BackColor;
                FormUtil.Font = listViewSharpLogLiteMessages.Font;
                listViewSharpLogLiteMessages.DrawItem += FormUtil.DrawItem;
                listViewSharpLogLiteMessages.AutoArrange = false;
                listViewSharpLogLiteMessages.Columns.AddRange(new ColumnHeader[] { headerlistViewSharpLogLiteMessages });
                listViewSharpLogLiteMessages.Dock = DockStyle.Fill;
                listViewSharpLogLiteMessages.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
                listViewSharpLogLiteMessages.HeaderStyle = ColumnHeaderStyle.None;
                listViewSharpLogLiteMessages.Location = new Point(3, 3);
                listViewSharpLogLiteMessages.UseCompatibleStateImageBehavior = false;
                listViewSharpLogLiteMessages.View = View.Details;
                listViewSharpLogLiteMessages.Activation = ItemActivation.Standard;
                listViewSharpLogLiteMessages.ItemActivate += delegate (object sender, EventArgs args)
                {
                    var i = listViewSharpLogLiteMessages.SelectedIndices[0];
                    new ListViewItemForm(Regex.Replace(listViewSharpLogLiteMessages.Items[i].Text, @"\r\n|\n\r|\n|\r", Environment.NewLine)).Show();
                };


                listViewConsole = new ListView();
                listViewConsole.OwnerDraw = true;
                listViewConsole.DrawColumnHeader += DrawColumnHeader;
                FormUtil.Color = listViewConsole.BackColor;
                FormUtil.Font = listViewConsole.Font;
                listViewConsole.DrawItem += FormUtil.DrawItem;
                listViewConsole.AutoArrange = false;
                listViewConsole.Columns.AddRange(new ColumnHeader[] { headerlistViewConsole });
                listViewConsole.Dock = DockStyle.Fill;
                listViewConsole.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
                listViewConsole.HeaderStyle = ColumnHeaderStyle.None;
                listViewConsole.Location = new Point(3, 3);
                listViewConsole.UseCompatibleStateImageBehavior = false;
                listViewConsole.View = View.Details;
                listViewConsole.Activation = ItemActivation.Standard;
                listViewConsole.ItemActivate += delegate (object sender, EventArgs args)
                {
                    var i = listViewConsole.SelectedIndices[0];
                    new ListViewItemForm(Regex.Replace(listViewConsole.Items[i].Text, @"\r\n|\n\r|\n|\r", Environment.NewLine)).Show();
                };

                var tabControl = new TabControl();
                tabControl.Font = new Font("Tahoma", 7F, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
                tabControl.Location = new Point(3, 3);
                tabControl.Multiline = true;
                tabControl.SelectedIndex = 0;
                tabControl.Dock = DockStyle.Fill;

                var tabPage1 = new TabPage("Events");
                var tabPage2 = new TabPage("SharpLogLite");
                var tabPage3 = new TabPage("Console");

                tabControl.TabPages.Add(tabPage1);
                tabControl.TabPages.Add(tabPage2);
                tabControl.TabPages.Add(tabPage3);

                tableLayoutPanel = new TableLayoutPanel();
                tableLayoutPanel.Dock = DockStyle.Fill;
                tableLayoutPanel.Location = new Point(3, 3);
                tableLayoutPanel.RowCount = 1;
                tableLayoutPanel.ColumnCount = 2;
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
                tableLayoutPanel.Controls.Add(listViewDirectEveEvents, 0, 0);

                var eventTableLayoutPanel = new TableLayoutPanel();
                eventTableLayoutPanel.Location = new Point(3, 3);
                var directEventsCount = Enum.GetNames(typeof(DirectEvents)).Length;
                eventTableLayoutPanel.RowCount = directEventsCount;
                eventTableLayoutPanel.ColumnCount = 1;
                eventTableLayoutPanel.Dock = DockStyle.Fill;
                eventTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                var labelDict = new Dictionary<DirectEvents, Label>();

                foreach (DirectEvents type in Enum.GetValues(typeof(DirectEvents)))
                {
                    eventTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / directEventsCount));
                    var l1 = new Label();
                    labelDict[type] = l1;
                    l1.Dock = DockStyle.Fill;
                    eventTableLayoutPanel.Controls.Add(l1);
                }

                EveAccount eA = null;
                thread = new Thread(() =>
                {
                    var lastUIRefresh = DateTime.MinValue;
                    while (true)
                        try
                        {
                            if (Cache.IsShuttingDown)
                                break;

                            if (lastUIRefresh.AddSeconds(5) > DateTime.UtcNow || !IsHandleCreated)
                            {
                                Thread.Sleep(500);
                                continue;
                            }

                            lastUIRefresh = DateTime.UtcNow;

                            if (ImageIndex != 0)
                            {
                                if (eA == null)
                                    eA =
                                        Cache.Instance.EveAccountSerializeableSortableBindingList.List.FirstOrDefault(
                                            e => e.CharacterName.ToLower().Equals(this.title.ToLower()));

                                if (eA == null)
                                    Invoke(new Action(() => ImageIndex = -1));

                                if (eA != null)
                                    if (eA.EveProcessExists())
                                    {
                                        if (ImageIndex != 1)
                                            Invoke(new Action(() => ImageIndex = 1));
                                    }
                                    else
                                    {
                                        if (ImageIndex != 2)
                                            Invoke(new Action(() => ImageIndex = 2));
                                    }
                            }

                            if (IsHandleCreated)
                                foreach (var kv in labelDict)
                                {
                                    var lastEvent = DirectEventHandler.GetLastEventReceived(this.title, kv.Key);
                                    var lastEventString = lastEvent.HasValue
                                        ? (DateTime.UtcNow - lastEvent.Value).Days.ToString("D2") + ":" +
                                          (DateTime.UtcNow - lastEvent.Value).Hours.ToString("D2") +
                                          ":" + (DateTime.UtcNow - lastEvent.Value).Minutes.ToString("D2") + ":" +
                                          (DateTime.UtcNow - lastEvent.Value).Seconds.ToString("D2") + " ago"
                                        : "-";
                                    kv.Value.Invoke(new Action(() => kv.Value.Text = kv.Key.ToString() + ": " + lastEventString));
                                }

                            Thread.Sleep(500);
                        }
                        catch (Exception ex)
                        {
                            Cache.Instance.Log(ex.ToString());
                            Debug.WriteLine(ex);
                            continue;
                        }
                });

                thread.Start();

                tableLayoutPanel.Controls.Add(eventTableLayoutPanel, 1, 0);
                tabPage1.Controls.Add(tableLayoutPanel);
                tabPage2.Controls.Add(listViewSharpLogLiteMessages);
                tabPage3.Controls.Add(listViewConsole);
                Controls.Add(tabControl);
            }
        }

        #endregion Constructors

        #region Destructors

        ~MainFormEventTab()
        {
        }

        #endregion Destructors

        #region Properties

        private EveAccount CorrespondingEveAccount { get; set; }
        private ColumnHeader headerlistViewDirectEveEvents { get; set; }
        private ColumnHeader headerlistViewSharpLogLiteMessages { get; set; }
        private ListView listViewDirectEveEvents { get; set; }
        private ListView listViewSharpLogLiteMessages { get; set; }
        private ColumnHeader headerlistViewConsole { get; set; }
        private ListView listViewConsole { get; set; }
        private TableLayoutPanel tableLayoutPanel { get; set; }
        private Thread thread { get; set; }
        private string title { get; set; }

        #endregion Properties

        #region Methods

        public void AddCustomMessage(string header, string message)
        {
            var col = Color.Black;
            var item = new ListViewItem();
            item.ForeColor = (Color)col;
            item.Text = "[" + DateTime.UtcNow.ToString() + "] [" + header + "]" + message;
            AddItemListViewDirectEveEvents(item);
        }

        public void AddMessage(string message)
        {
            var col = Color.Black;
            var item = new ListViewItem();
            item.ForeColor = (Color)col;
            item.Text = "[" + DateTime.UtcNow.ToString() + "] [MESSAGE]" + message;
            AddItemListViewDirectEveEvents(item);
        }

        public void AddNewEvent(DirectEvent directEvent)
        {
            var col = directEvent.color;
            var item = new ListViewItem();
            item.ForeColor = (Color)col;
            item.Text = "[" + String.Format("{0:dd-MMM-yy HH:mm:ss:fff}", DateTime.UtcNow) + "] [" + directEvent.type + "]" + directEvent.message;

            if (directEvent.warning)
                ImageIndex = 0;

            AddItemListViewDirectEveEvents(item);
        }

        public void AddRawMessage(string message)
        {
            var col = Color.Black;
            var item = new ListViewItem();
            item.ForeColor = (Color)col;
            int maxLen = 300;
            item.Text = message.Length > maxLen ? message.Substring(0, maxLen) + "..." : message;
            item.Tag = message;
            AddItemListViewDirectEveEvents(item);
        }

        public void AddRawConsoleMessage(string message, bool isErr)
        {
            var col = isErr ? Color.Red : Color.Black;
            var item = new ListViewItem();
            item.ForeColor = (Color)col;
            int maxLen = 300;
            item.Text = message.Length > maxLen ? message.Substring(0, maxLen) + "..." : message;
            item.Tag = message;
            AddItemListViewConsole(item);
        }

        public void AddSharpLogLiteMessage(SharpLogMessage msg, string charName)
        {
            try
            {
                if (CorrespondingEveAccount == null)
                    CorrespondingEveAccount =
                        Cache.Instance.EveAccountSerializeableSortableBindingList.List.FirstOrDefault(e => e.CharacterName.ToLower()
                            .Equals(charName.ToLower()));

                if (CorrespondingEveAccount != null)
                {
                    var stracktraceRegex = new Regex(@"STACKTRACE #[0-9]*", RegexOptions.Compiled);
                    var exRegex = new Regex(@"EXCEPTION #[0-9]*", RegexOptions.Compiled);
                    var valEx = 0;
                    var valStack = 0;
                    foreach (Match itemMatch in exRegex.Matches(msg.Message)) int.TryParse(Regex.Match(itemMatch.Value, @"\d+").Value, out valEx);

                    foreach (Match itemMatch in stracktraceRegex.Matches(msg.Message)) int.TryParse(Regex.Match(itemMatch.Value, @"\d+").Value, out valStack);
                    var prevValue = CorrespondingEveAccount.AmountExceptionsCurrentSession;

                    if (valEx != 0)
                        prevValue++;

                    if (valStack != 0)
                        prevValue++;

                    if (msg.Severity == LogSeverity.SEVERITY_ERR)
                    {
                        if (msg.Module.ContainsIgnoreCase("blue") && msg.Channel.ContainsIgnoreCase("resman"))
                        {
                            // TODO add some handler to NOT count specific errors
                        }
                        else if (msg.Module.ContainsIgnoreCase("destiny") && msg.Channel.ContainsIgnoreCase("Ball") && msg.Message.ContainsIgnoreCase("No valid ego"))
                        {

                        }

                        else
                        {
                            prevValue++;
                        }
                    }

                    if (CorrespondingEveAccount.AmountExceptionsCurrentSession != prevValue)
                        CorrespondingEveAccount.AmountExceptionsCurrentSession = prevValue;

                    Invoke(new Action(() =>
                    {
                        Text =
                            $"{charName} ({CorrespondingEveAccount.AmountExceptionsCurrentSession})";
                    }));

                }

                var col = Color.Black;

                switch (msg.Severity)
                {
                    case LogSeverity.SEVERITY_INFO:
                        col = Color.Green;
                        break;

                    case LogSeverity.SEVERITY_NOTICE:
                        col = Color.Green;
                        break;

                    case LogSeverity.SEVERITY_WARN:
                        col = Color.Orange;
                        break;

                    case LogSeverity.SEVERITY_ERR:
                        col = Color.Red;
                        break;

                    case LogSeverity.SEVERITY_COUNT:
                        break;
                }

                var item = new ListViewItem();
                item.ForeColor = (Color)col;
                item.Text = $"[{String.Format("{0:dd-MMM-yy HH:mm:ss:fff}", msg.DateTime)}] [{msg.Severity}] [{msg.Module}] [{msg.Channel}] {msg.Message}";

                // log to file

                var s = Path.DirectorySeparatorChar;
                var path = Util.AssemblyPath + s + "Logs" + s + charName + s + "SharpLogLite";

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                var logFile = Path.Combine(path,
                    string.Format("{0:MM-dd-yyyy}", DateTime.Today) + "-" + charName + "-" + "SharpLogLite" + ".log");

                File.AppendAllText(logFile, item.Text + Environment.NewLine);

                AddItemSharpLogLiteMessage(item);
            }
            catch (Exception ex)
            {
                Cache.Instance.Log("Exception: " + ex);
            }
        }

        private void AddItemListViewDirectEveEvents(ListViewItem item)
        {
            if (listViewDirectEveEvents.Items.Count >= 1000)
                listViewDirectEveEvents.Items.Clear();

            listViewDirectEveEvents.Items.Add(item);

            if (listViewDirectEveEvents.Items.Count > 0)
                listViewDirectEveEvents.Items[listViewDirectEveEvents.Items.Count - 1].EnsureVisible();
        }

        private void AddItemListViewConsole(ListViewItem item)
        {
            if (listViewConsole.Items.Count >= 1000)
                listViewConsole.Items.Clear();

            listViewConsole.Items.Add(item);

            if (listViewConsole.Items.Count > 0)
                listViewConsole.Items[listViewConsole.Items.Count - 1].EnsureVisible();
        }

        private void AddItemSharpLogLiteMessage(ListViewItem item)
        {
            if (listViewSharpLogLiteMessages.Items.Count >= 1000)
                listViewSharpLogLiteMessages.Items.Clear();

            listViewSharpLogLiteMessages.Items.Add(item);

            if (listViewSharpLogLiteMessages.Items.Count > 0)
                listViewSharpLogLiteMessages.Items[listViewSharpLogLiteMessages.Items.Count - 1].EnsureVisible();
        }

        private void DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        #endregion Methods
    }
}