/*
 * Created by SharpDevelop.
 * User: dserver
 * Date: 02.12.2013
 * Time: 09:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Windows.Forms;

namespace EVESharpLauncher
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startInjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editAdapteveHWProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editClientConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPatternManagerSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartFirefoxInjecttoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartECoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMailInboxToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectProcessToProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetLastAmmoBuyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLoginTokensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetLastPlexBuyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllSocketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugLaunchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearWinUserDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startDelayedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonGenNewBeginEnd = new System.Windows.Forms.Button();
            this.buttonbuttonKillAllEveInstancesNow = new System.Windows.Forms.Button();
            this.buttonKillAllEveInstances = new System.Windows.Forms.Button();
            this.buttonStopEveManger = new System.Windows.Forms.Button();
            this.buttonStartEveManger = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIconQL = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAccountLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllEveCachesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseHWDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importEveAccountFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proxiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateEVESharpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openQuestorStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDatabaseViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRealHardwareInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.button4 = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mainTabCtrl = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dataGridEveAccounts = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.textBoxPastebin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.mainTabCtrl.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEveAccounts)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startInjectToolStripMenuItem,
            this.editAdapteveHWProfileToolStripMenuItem,
            this.editClientConfigurationToolStripMenuItem,
            this.editPatternManagerSettingsToolStripMenuItem,
            this.StartFirefoxInjecttoolStripMenuItem,
            this.groupToolStripMenuItem,
            this.openMailInboxToolStripMenuItem1,
            this.exportToClipboardToolStripMenuItem,
            this.optionalToolStripMenuItem,
            this.columnsToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(231, 246);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1Opening);
            // 
            // startInjectToolStripMenuItem
            // 
            this.startInjectToolStripMenuItem.Name = "startInjectToolStripMenuItem";
            this.startInjectToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.startInjectToolStripMenuItem.Text = "Start EVE";
            this.startInjectToolStripMenuItem.Click += new System.EventHandler(this.StartInjectToolStripMenuItemClick);
            // 
            // editAdapteveHWProfileToolStripMenuItem
            // 
            this.editAdapteveHWProfileToolStripMenuItem.Name = "editAdapteveHWProfileToolStripMenuItem";
            this.editAdapteveHWProfileToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.editAdapteveHWProfileToolStripMenuItem.Text = "Edit Hardware Profile";
            this.editAdapteveHWProfileToolStripMenuItem.Click += new System.EventHandler(this.EditAdapteveHWProfileToolStripMenuItemClick);
            // 
            // editClientConfigurationToolStripMenuItem
            // 
            this.editClientConfigurationToolStripMenuItem.Name = "editClientConfigurationToolStripMenuItem";
            this.editClientConfigurationToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.editClientConfigurationToolStripMenuItem.Text = "Edit Client Settings";
            this.editClientConfigurationToolStripMenuItem.Click += new System.EventHandler(this.editClientConfigurationToolStripMenuItem_Click);
            // 
            // editPatternManagerSettingsToolStripMenuItem
            // 
            this.editPatternManagerSettingsToolStripMenuItem.Name = "editPatternManagerSettingsToolStripMenuItem";
            this.editPatternManagerSettingsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.editPatternManagerSettingsToolStripMenuItem.Text = "Edit Pattern Manager Settings";
            this.editPatternManagerSettingsToolStripMenuItem.Click += new System.EventHandler(this.editPatternManagerSettingsToolStripMenuItem_Click);
            // 
            // StartFirefoxInjecttoolStripMenuItem
            // 
            this.StartFirefoxInjecttoolStripMenuItem.Name = "StartFirefoxInjecttoolStripMenuItem";
            this.StartFirefoxInjecttoolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.StartFirefoxInjecttoolStripMenuItem.Text = "Start Chrome with Proxy";
            this.StartFirefoxInjecttoolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem1Click);
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchToolStripMenuItem,
            this.killToolStripMenuItem,
            this.restartECoreToolStripMenuItem});
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.groupToolStripMenuItem.Text = "Group";
            // 
            // launchToolStripMenuItem
            // 
            this.launchToolStripMenuItem.Name = "launchToolStripMenuItem";
            this.launchToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.launchToolStripMenuItem.Text = "Launch";
            this.launchToolStripMenuItem.Click += new System.EventHandler(this.launchToolStripMenuItem_Click);
            // 
            // killToolStripMenuItem
            // 
            this.killToolStripMenuItem.Name = "killToolStripMenuItem";
            this.killToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.killToolStripMenuItem.Text = "Kill";
            this.killToolStripMenuItem.Click += new System.EventHandler(this.killToolStripMenuItem_Click);
            // 
            // restartECoreToolStripMenuItem
            // 
            this.restartECoreToolStripMenuItem.Name = "restartECoreToolStripMenuItem";
            this.restartECoreToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.restartECoreToolStripMenuItem.Text = "Restart E# Core";
            this.restartECoreToolStripMenuItem.Click += new System.EventHandler(this.restartECoreToolStripMenuItem_Click);
            // 
            // openMailInboxToolStripMenuItem1
            // 
            this.openMailInboxToolStripMenuItem1.Name = "openMailInboxToolStripMenuItem1";
            this.openMailInboxToolStripMenuItem1.Size = new System.Drawing.Size(230, 22);
            this.openMailInboxToolStripMenuItem1.Text = "Open Mail Inbox";
            this.openMailInboxToolStripMenuItem1.Click += new System.EventHandler(this.openMailInboxToolStripMenuItem1_Click);
            // 
            // exportToClipboardToolStripMenuItem
            // 
            this.exportToClipboardToolStripMenuItem.Name = "exportToClipboardToolStripMenuItem";
            this.exportToClipboardToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.exportToClipboardToolStripMenuItem.Text = "Export to Clipboard";
            this.exportToClipboardToolStripMenuItem.Click += new System.EventHandler(this.exportToClipboardToolStripMenuItem_Click);
            // 
            // optionalToolStripMenuItem
            // 
            this.optionalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectProcessToProxyToolStripMenuItem,
            this.clearCacheToolStripMenuItem,
            this.resetLastAmmoBuyToolStripMenuItem,
            this.clearLoginTokensToolStripMenuItem,
            this.resetLastPlexBuyToolStripMenuItem,
            this.closeAllSocketsToolStripMenuItem,
            this.debugLaunchToolStripMenuItem,
            this.clearWinUserDirToolStripMenuItem,
            this.startDelayedToolStripMenuItem,
            this.cloneAccountToolStripMenuItem});
            this.optionalToolStripMenuItem.Name = "optionalToolStripMenuItem";
            this.optionalToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.optionalToolStripMenuItem.Text = "Optional";
            // 
            // selectProcessToProxyToolStripMenuItem
            // 
            this.selectProcessToProxyToolStripMenuItem.Name = "selectProcessToProxyToolStripMenuItem";
            this.selectProcessToProxyToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.selectProcessToProxyToolStripMenuItem.Text = "Start Selected Exe With Proxy";
            this.selectProcessToProxyToolStripMenuItem.Click += new System.EventHandler(this.SelectProcessToProxyToolStripMenuItemClick);
            // 
            // clearCacheToolStripMenuItem
            // 
            this.clearCacheToolStripMenuItem.Name = "clearCacheToolStripMenuItem";
            this.clearCacheToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.clearCacheToolStripMenuItem.Text = "Clear Cache";
            this.clearCacheToolStripMenuItem.Click += new System.EventHandler(this.clearCacheToolStripMenuItem_Click);
            // 
            // resetLastAmmoBuyToolStripMenuItem
            // 
            this.resetLastAmmoBuyToolStripMenuItem.Name = "resetLastAmmoBuyToolStripMenuItem";
            this.resetLastAmmoBuyToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.resetLastAmmoBuyToolStripMenuItem.Text = "Reset LastAmmoBuy";
            this.resetLastAmmoBuyToolStripMenuItem.Click += new System.EventHandler(this.resetLastAmmoBuyToolStripMenuItem_Click);
            // 
            // clearLoginTokensToolStripMenuItem
            // 
            this.clearLoginTokensToolStripMenuItem.Name = "clearLoginTokensToolStripMenuItem";
            this.clearLoginTokensToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.clearLoginTokensToolStripMenuItem.Text = "Clear LoginTokens";
            this.clearLoginTokensToolStripMenuItem.Click += new System.EventHandler(this.clearLoginTokensToolStripMenuItem_Click);
            // 
            // resetLastPlexBuyToolStripMenuItem
            // 
            this.resetLastPlexBuyToolStripMenuItem.Name = "resetLastPlexBuyToolStripMenuItem";
            this.resetLastPlexBuyToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.resetLastPlexBuyToolStripMenuItem.Text = "Reset LastPlexBuy";
            this.resetLastPlexBuyToolStripMenuItem.Click += new System.EventHandler(this.resetLastPlexBuyToolStripMenuItem_Click);
            // 
            // closeAllSocketsToolStripMenuItem
            // 
            this.closeAllSocketsToolStripMenuItem.Name = "closeAllSocketsToolStripMenuItem";
            this.closeAllSocketsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.closeAllSocketsToolStripMenuItem.Text = "Close All Sockets";
            this.closeAllSocketsToolStripMenuItem.Click += new System.EventHandler(this.closeAllSocketsToolStripMenuItem_Click);
            // 
            // debugLaunchToolStripMenuItem
            // 
            this.debugLaunchToolStripMenuItem.Name = "debugLaunchToolStripMenuItem";
            this.debugLaunchToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.debugLaunchToolStripMenuItem.Text = "Debug Launch";
            this.debugLaunchToolStripMenuItem.Click += new System.EventHandler(this.debugLaunchToolStripMenuItem_Click);
            // 
            // clearWinUserDirToolStripMenuItem
            // 
            this.clearWinUserDirToolStripMenuItem.Name = "clearWinUserDirToolStripMenuItem";
            this.clearWinUserDirToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.clearWinUserDirToolStripMenuItem.Text = "Clear WinUserDir";
            this.clearWinUserDirToolStripMenuItem.Click += new System.EventHandler(this.clearWinUserDirToolStripMenuItem_Click);
            // 
            // startDelayedToolStripMenuItem
            // 
            this.startDelayedToolStripMenuItem.Name = "startDelayedToolStripMenuItem";
            this.startDelayedToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.startDelayedToolStripMenuItem.Text = "Start Delayed";
            this.startDelayedToolStripMenuItem.Click += new System.EventHandler(this.startDelayedToolStripMenuItem_Click);
            // 
            // cloneAccountToolStripMenuItem
            // 
            this.cloneAccountToolStripMenuItem.Name = "cloneAccountToolStripMenuItem";
            this.cloneAccountToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.cloneAccountToolStripMenuItem.Text = "Clone Account";
            this.cloneAccountToolStripMenuItem.Click += new System.EventHandler(this.cloneAccountToolStripMenuItem_Click);
            // 
            // columnsToolStripMenuItem
            // 
            this.columnsToolStripMenuItem.Name = "columnsToolStripMenuItem";
            this.columnsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.columnsToolStripMenuItem.Text = "Columns";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem1});
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.deleteToolStripMenuItem1.Text = "Confirm";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.DeleteToolStripMenuItem1Click);
            // 
            // buttonGenNewBeginEnd
            // 
            this.buttonGenNewBeginEnd.Location = new System.Drawing.Point(18, 77);
            this.buttonGenNewBeginEnd.Name = "buttonGenNewBeginEnd";
            this.buttonGenNewBeginEnd.Size = new System.Drawing.Size(182, 20);
            this.buttonGenNewBeginEnd.TabIndex = 27;
            this.buttonGenNewBeginEnd.Text = "Generate New Time Spans";
            this.buttonGenNewBeginEnd.UseVisualStyleBackColor = true;
            this.buttonGenNewBeginEnd.Click += new System.EventHandler(this.ButtonGenNewBeginEndClick);
            // 
            // buttonbuttonKillAllEveInstancesNow
            // 
            this.buttonbuttonKillAllEveInstancesNow.Location = new System.Drawing.Point(110, 51);
            this.buttonbuttonKillAllEveInstancesNow.Name = "buttonbuttonKillAllEveInstancesNow";
            this.buttonbuttonKillAllEveInstancesNow.Size = new System.Drawing.Size(90, 20);
            this.buttonbuttonKillAllEveInstancesNow.TabIndex = 33;
            this.buttonbuttonKillAllEveInstancesNow.Text = "Kill Now";
            this.buttonbuttonKillAllEveInstancesNow.UseVisualStyleBackColor = true;
            this.buttonbuttonKillAllEveInstancesNow.Click += new System.EventHandler(this.ButtonbuttonKillAllEveInstancesNowClick);
            // 
            // buttonKillAllEveInstances
            // 
            this.buttonKillAllEveInstances.Location = new System.Drawing.Point(18, 51);
            this.buttonKillAllEveInstances.Name = "buttonKillAllEveInstances";
            this.buttonKillAllEveInstances.Size = new System.Drawing.Size(90, 20);
            this.buttonKillAllEveInstances.TabIndex = 26;
            this.buttonKillAllEveInstances.Text = "Kill Delayed";
            this.buttonKillAllEveInstances.UseVisualStyleBackColor = true;
            this.buttonKillAllEveInstances.Click += new System.EventHandler(this.ButtonKillAllEveInstancesClick);
            // 
            // buttonStopEveManger
            // 
            this.buttonStopEveManger.Location = new System.Drawing.Point(110, 25);
            this.buttonStopEveManger.Name = "buttonStopEveManger";
            this.buttonStopEveManger.Size = new System.Drawing.Size(90, 20);
            this.buttonStopEveManger.TabIndex = 23;
            this.buttonStopEveManger.Text = "Stop";
            this.buttonStopEveManger.UseVisualStyleBackColor = true;
            this.buttonStopEveManger.Click += new System.EventHandler(this.ButtonStopEveMangerClick);
            // 
            // buttonStartEveManger
            // 
            this.buttonStartEveManger.Location = new System.Drawing.Point(18, 25);
            this.buttonStartEveManger.Name = "buttonStartEveManger";
            this.buttonStartEveManger.Size = new System.Drawing.Size(90, 20);
            this.buttonStartEveManger.TabIndex = 22;
            this.buttonStartEveManger.Text = "Start";
            this.buttonStartEveManger.UseVisualStyleBackColor = true;
            this.buttonStartEveManger.Click += new System.EventHandler(this.ButtonStartEveMangerClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // notifyIconQL
            // 
            this.notifyIconQL.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconQL.Icon")));
            this.notifyIconQL.Click += new System.EventHandler(this.notifyIconQL_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandsToolStripMenuItem,
            this.proxiesToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.windowsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1368, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkAccountLinksToolStripMenuItem,
            this.clearAllEveCachesToolStripMenuItem,
            this.parseHWDetailsToolStripMenuItem,
            this.importEveAccountFromClipboardToolStripMenuItem});
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.commandsToolStripMenuItem.Text = "Commands";
            // 
            // checkAccountLinksToolStripMenuItem
            // 
            this.checkAccountLinksToolStripMenuItem.Name = "checkAccountLinksToolStripMenuItem";
            this.checkAccountLinksToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.checkAccountLinksToolStripMenuItem.Text = "Check Account Links";
            this.checkAccountLinksToolStripMenuItem.Click += new System.EventHandler(this.checkAccountLinksToolStripMenuItem_Click);
            // 
            // clearAllEveCachesToolStripMenuItem
            // 
            this.clearAllEveCachesToolStripMenuItem.Name = "clearAllEveCachesToolStripMenuItem";
            this.clearAllEveCachesToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.clearAllEveCachesToolStripMenuItem.Text = "Clear All Eve Caches";
            this.clearAllEveCachesToolStripMenuItem.Click += new System.EventHandler(this.clearAllEveCachesToolStripMenuItem_Click);
            // 
            // parseHWDetailsToolStripMenuItem
            // 
            this.parseHWDetailsToolStripMenuItem.Name = "parseHWDetailsToolStripMenuItem";
            this.parseHWDetailsToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.parseHWDetailsToolStripMenuItem.Text = "Parse HWDetails";
            this.parseHWDetailsToolStripMenuItem.Click += new System.EventHandler(this.parseHWDetailsToolStripMenuItem_Click);
            // 
            // importEveAccountFromClipboardToolStripMenuItem
            // 
            this.importEveAccountFromClipboardToolStripMenuItem.Name = "importEveAccountFromClipboardToolStripMenuItem";
            this.importEveAccountFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.importEveAccountFromClipboardToolStripMenuItem.Text = "Import EveAccount From Clipboard";
            this.importEveAccountFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.importEveAccountFromClipboardToolStripMenuItem_Click);
            // 
            // proxiesToolStripMenuItem
            // 
            this.proxiesToolStripMenuItem.Name = "proxiesToolStripMenuItem";
            this.proxiesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.proxiesToolStripMenuItem.Text = "Proxies";
            this.proxiesToolStripMenuItem.Click += new System.EventHandler(this.proxiesToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateEVESharpToolStripMenuItem});
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // updateEVESharpToolStripMenuItem
            // 
            this.updateEVESharpToolStripMenuItem.Name = "updateEVESharpToolStripMenuItem";
            this.updateEVESharpToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.updateEVESharpToolStripMenuItem.Text = "Update EVESharp";
            this.updateEVESharpToolStripMenuItem.Click += new System.EventHandler(this.UpdateEVESharpToolStripMenuItemClick);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openQuestorStatisticsToolStripMenuItem,
            this.openDatabaseViewerToolStripMenuItem,
            this.showRealHardwareInfoToolStripMenuItem,
            this.hideToolStripMenuItem,
            this.showToolStripMenuItem});
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // openQuestorStatisticsToolStripMenuItem
            // 
            this.openQuestorStatisticsToolStripMenuItem.Name = "openQuestorStatisticsToolStripMenuItem";
            this.openQuestorStatisticsToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.openQuestorStatisticsToolStripMenuItem.Text = "Open Questor Statistics";
            this.openQuestorStatisticsToolStripMenuItem.Click += new System.EventHandler(this.openQuestorStatisticsToolStripMenuItem_Click);
            // 
            // openDatabaseViewerToolStripMenuItem
            // 
            this.openDatabaseViewerToolStripMenuItem.Name = "openDatabaseViewerToolStripMenuItem";
            this.openDatabaseViewerToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.openDatabaseViewerToolStripMenuItem.Text = "Open Database Viewer";
            this.openDatabaseViewerToolStripMenuItem.Click += new System.EventHandler(this.openDatabaseViewerToolStripMenuItem_Click);
            // 
            // showRealHardwareInfoToolStripMenuItem
            // 
            this.showRealHardwareInfoToolStripMenuItem.Name = "showRealHardwareInfoToolStripMenuItem";
            this.showRealHardwareInfoToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.showRealHardwareInfoToolStripMenuItem.Text = "Show Real Hardware Info";
            this.showRealHardwareInfoToolStripMenuItem.Click += new System.EventHandler(this.showRealHardwareInfoToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.hideToolStripMenuItem.Text = "Hide Eve Windows";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.HideToolStripMenuItemClick);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.showToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.showToolStripMenuItem.Text = "Show Eve Windows";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItemClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "warning.png");
            this.imageList1.Images.SetKeyName(1, "green.png");
            this.imageList1.Images.SetKeyName(2, "red.png");
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(835, 241);
            this.tabControl1.TabIndex = 24;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(23, 48);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(182, 20);
            this.button4.TabIndex = 37;
            this.button4.Text = "Goto Jita";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(844, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(239, 241);
            this.tabControl2.TabIndex = 36;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.buttonGenNewBeginEnd);
            this.tabPage1.Controls.Add(this.buttonStopEveManger);
            this.tabPage1.Controls.Add(this.buttonbuttonKillAllEveInstancesNow);
            this.tabPage1.Controls.Add(this.buttonStartEveManger);
            this.tabPage1.Controls.Add(this.buttonKillAllEveInstances);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(231, 215);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "EveManager";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(231, 215);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Global Commands";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(23, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 20);
            this.button2.TabIndex = 38;
            this.button2.Text = "Restart E# Core";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.mainTabCtrl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.81224F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.18776F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1368, 719);
            this.tableLayoutPanel1.TabIndex = 38;
            // 
            // mainTabCtrl
            // 
            this.mainTabCtrl.Controls.Add(this.tabPage5);
            this.mainTabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabCtrl.Location = new System.Drawing.Point(3, 3);
            this.mainTabCtrl.Name = "mainTabCtrl";
            this.mainTabCtrl.SelectedIndex = 0;
            this.mainTabCtrl.Size = new System.Drawing.Size(1362, 460);
            this.mainTabCtrl.TabIndex = 39;
            this.mainTabCtrl.Selected += new System.Windows.Forms.TabControlEventHandler(this.mainTabCtrl_Selected);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dataGridEveAccounts);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1354, 434);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Main";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dataGridEveAccounts
            // 
            this.dataGridEveAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridEveAccounts.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridEveAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridEveAccounts.EnableHeadersVisualStyles = false;
            this.dataGridEveAccounts.Location = new System.Drawing.Point(3, 3);
            this.dataGridEveAccounts.MultiSelect = false;
            this.dataGridEveAccounts.Name = "dataGridEveAccounts";
            this.dataGridEveAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridEveAccounts.Size = new System.Drawing.Size(1348, 428);
            this.dataGridEveAccounts.TabIndex = 26;
            this.dataGridEveAccounts.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridEveAccounts_CellBeginEdit);
            this.dataGridEveAccounts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridEveAccounts_CellContentClick);
            this.dataGridEveAccounts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridEveAccounts_CellEndEdit);
            this.dataGridEveAccounts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridEveAccounts_CellFormatting);
            this.dataGridEveAccounts.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridEveAccounts_CellValueChanged);
            this.dataGridEveAccounts.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridEveAccounts_DataError);
            this.dataGridEveAccounts.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridEveAccounts_RowPostPaint);
            this.dataGridEveAccounts.SelectionChanged += new System.EventHandler(this.dataGridEveAccounts_SelectionChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 276F));
            this.tableLayoutPanel2.Controls.Add(this.tabControl2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tabControl3, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 469);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1362, 247);
            this.tableLayoutPanel2.TabIndex = 27;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage3);
            this.tabControl3.Controls.Add(this.tabPage4);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(1089, 3);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(270, 241);
            this.tabControl3.TabIndex = 37;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(262, 215);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Additional Info";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.textBoxPastebin);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(262, 215);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Pastebin";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // textBoxPastebin
            // 
            this.textBoxPastebin.AcceptsReturn = true;
            this.textBoxPastebin.AcceptsTab = true;
            this.textBoxPastebin.AllowDrop = true;
            this.textBoxPastebin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPastebin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPastebin.Location = new System.Drawing.Point(3, 3);
            this.textBoxPastebin.Multiline = true;
            this.textBoxPastebin.Name = "textBoxPastebin";
            this.textBoxPastebin.Size = new System.Drawing.Size(256, 209);
            this.textBoxPastebin.TabIndex = 2;
            this.textBoxPastebin.WordWrap = false;
            this.textBoxPastebin.TextChanged += new System.EventHandler(this.textBoxPastebin_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(1333, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 39;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 743);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "EVESharp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainFormResize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.mainTabCtrl.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEveAccounts)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private System.Windows.Forms.ToolStripMenuItem updateEVESharpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem selectProcessToProxyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem StartFirefoxInjecttoolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editAdapteveHWProfileToolStripMenuItem;
		private System.Windows.Forms.NotifyIcon notifyIconQL;
		private System.Windows.Forms.Button buttonStartEveManger;
		private System.Windows.Forms.Button buttonStopEveManger;
		private System.Windows.Forms.Button buttonGenNewBeginEnd;
		private System.Windows.Forms.Button buttonKillAllEveInstances;
		private System.Windows.Forms.ToolStripMenuItem startInjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
		private System.Windows.Forms.Button buttonbuttonKillAllEveInstancesNow;
		private System.Windows.Forms.ToolStripMenuItem 		 optionalToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabControl tabControl1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Button button1;
        private ToolStripMenuItem proxiesToolStripMenuItem;
        private Button button4;
        private TabControl tabControl2;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ToolStripMenuItem showRealHardwareInfoToolStripMenuItem;
        private ToolStripMenuItem columnsToolStripMenuItem;
        private ToolStripMenuItem editClientConfigurationToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private ToolStripMenuItem clearCacheToolStripMenuItem;
        private TabControl tabControl3;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TextBox textBoxPastebin;
        private TabControl mainTabCtrl;
        private TabPage tabPage5;
        private DataGridView dataGridEveAccounts;
        private ToolStripMenuItem resetLastAmmoBuyToolStripMenuItem;
        private ToolStripMenuItem openDatabaseViewerToolStripMenuItem;
        private ToolStripMenuItem clearLoginTokensToolStripMenuItem;
        private ToolStripMenuItem resetLastPlexBuyToolStripMenuItem;
        private Label label1;
        private Timer timer1;
        private ToolStripMenuItem editPatternManagerSettingsToolStripMenuItem;
        private ToolStripMenuItem openQuestorStatisticsToolStripMenuItem;
        private ToolStripMenuItem commandsToolStripMenuItem;
        private ToolStripMenuItem checkAccountLinksToolStripMenuItem;
        private ToolStripMenuItem clearAllEveCachesToolStripMenuItem;
        private ToolStripMenuItem openMailInboxToolStripMenuItem1;
        private ToolStripMenuItem parseHWDetailsToolStripMenuItem;
        private ToolStripMenuItem closeAllSocketsToolStripMenuItem;
        private ToolStripMenuItem debugLaunchToolStripMenuItem;
        private Button button2;
        private ToolStripMenuItem groupToolStripMenuItem;
        private ToolStripMenuItem launchToolStripMenuItem;
        private ToolStripMenuItem killToolStripMenuItem;
        private ToolStripMenuItem restartECoreToolStripMenuItem;
        private ToolStripMenuItem exportToClipboardToolStripMenuItem;
        private ToolStripMenuItem importEveAccountFromClipboardToolStripMenuItem;
        private ToolStripMenuItem clearWinUserDirToolStripMenuItem;
        private ToolStripMenuItem startDelayedToolStripMenuItem;
        private ToolStripMenuItem cloneAccountToolStripMenuItem;
    }
}
