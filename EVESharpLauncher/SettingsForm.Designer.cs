namespace EVESharpLauncher
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.textBoxEveLocation = new System.Windows.Forms.TextBox();
            this.exeFileLocationLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxGmailUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGmailPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxReceiverEmailAddress = new System.Windows.Forms.TextBox();
            this.buttonSendTestEmail = new System.Windows.Forms.Button();
            this.checkBoxUseTorProxy = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxWCFPort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxWCFIp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this._recordingLocationTextbox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this._recordingEnableCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxEveLocation
            // 
            this.textBoxEveLocation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEveLocation.Location = new System.Drawing.Point(14, 28);
            this.textBoxEveLocation.Name = "textBoxEveLocation";
            this.textBoxEveLocation.Size = new System.Drawing.Size(269, 21);
            this.textBoxEveLocation.TabIndex = 33;
            this.textBoxEveLocation.TextChanged += new System.EventHandler(this.textBoxEveLocation_TextChanged);
            // 
            // exeFileLocationLabel
            // 
            this.exeFileLocationLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exeFileLocationLabel.Location = new System.Drawing.Point(12, 9);
            this.exeFileLocationLabel.Name = "exeFileLocationLabel";
            this.exeFileLocationLabel.Size = new System.Drawing.Size(152, 16);
            this.exeFileLocationLabel.TabIndex = 32;
            this.exeFileLocationLabel.Text = "ExeFile.exe location:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "GMAIL Username:";
            // 
            // textBoxGmailUser
            // 
            this.textBoxGmailUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGmailUser.Location = new System.Drawing.Point(14, 92);
            this.textBoxGmailUser.Name = "textBoxGmailUser";
            this.textBoxGmailUser.Size = new System.Drawing.Size(269, 21);
            this.textBoxGmailUser.TabIndex = 36;
            this.textBoxGmailUser.TextChanged += new System.EventHandler(this.textBoxGmailUser_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 17);
            this.label3.TabIndex = 39;
            this.label3.Text = "GMAIL Password:";
            // 
            // textBoxGmailPassword
            // 
            this.textBoxGmailPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGmailPassword.Location = new System.Drawing.Point(14, 134);
            this.textBoxGmailPassword.Name = "textBoxGmailPassword";
            this.textBoxGmailPassword.Size = new System.Drawing.Size(269, 21);
            this.textBoxGmailPassword.TabIndex = 38;
            this.textBoxGmailPassword.TextChanged += new System.EventHandler(this.textBoxGmailPassword_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 17);
            this.label4.TabIndex = 41;
            this.label4.Text = "Receiver Email Address:";
            // 
            // textBoxReceiverEmailAddress
            // 
            this.textBoxReceiverEmailAddress.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxReceiverEmailAddress.Location = new System.Drawing.Point(14, 176);
            this.textBoxReceiverEmailAddress.Name = "textBoxReceiverEmailAddress";
            this.textBoxReceiverEmailAddress.Size = new System.Drawing.Size(269, 21);
            this.textBoxReceiverEmailAddress.TabIndex = 40;
            this.textBoxReceiverEmailAddress.TextChanged += new System.EventHandler(this.textBoxReceiverEmailAddress_TextChanged);
            // 
            // buttonSendTestEmail
            // 
            this.buttonSendTestEmail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSendTestEmail.Location = new System.Drawing.Point(14, 202);
            this.buttonSendTestEmail.Name = "buttonSendTestEmail";
            this.buttonSendTestEmail.Size = new System.Drawing.Size(270, 23);
            this.buttonSendTestEmail.TabIndex = 42;
            this.buttonSendTestEmail.Text = "Send test email";
            this.buttonSendTestEmail.UseVisualStyleBackColor = true;
            this.buttonSendTestEmail.Click += new System.EventHandler(this.buttonSendTestEmail_Click);
            // 
            // checkBoxUseTorProxy
            // 
            this.checkBoxUseTorProxy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxUseTorProxy.Location = new System.Drawing.Point(292, 26);
            this.checkBoxUseTorProxy.Name = "checkBoxUseTorProxy";
            this.checkBoxUseTorProxy.Size = new System.Drawing.Size(104, 16);
            this.checkBoxUseTorProxy.TabIndex = 43;
            this.checkBoxUseTorProxy.Text = "Enabled";
            this.checkBoxUseTorProxy.UseVisualStyleBackColor = true;
            this.checkBoxUseTorProxy.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(292, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(280, 16);
            this.label5.TabIndex = 44;
            this.label5.Text = "Tor Socks Proxy: ( 127.0.0.1:15001 - no auth )";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(292, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(280, 16);
            this.label8.TabIndex = 48;
            this.label8.Text = "SharpLogLite / Severity:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(292, 65);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(249, 21);
            this.comboBox1.TabIndex = 49;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(292, 106);
            this.trackBar1.Maximum = 30;
            this.trackBar1.Minimum = 10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(249, 45);
            this.trackBar1.TabIndex = 50;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(292, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(280, 16);
            this.label10.TabIndex = 52;
            this.label10.Text = "Background FPS:";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(292, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(280, 16);
            this.label9.TabIndex = 54;
            this.label9.Text = "Min Seconds Between EVE Launches:";
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 40;
            this.trackBar2.Location = new System.Drawing.Point(292, 157);
            this.trackBar2.Maximum = 240;
            this.trackBar2.Minimum = 20;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(249, 45);
            this.trackBar2.SmallChange = 15;
            this.trackBar2.TabIndex = 53;
            this.trackBar2.TickFrequency = 10;
            this.trackBar2.Value = 20;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(292, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(280, 16);
            this.label11.TabIndex = 56;
            this.label11.Text = "Max Seconds Between EVE Launches:";
            // 
            // trackBar3
            // 
            this.trackBar3.LargeChange = 20;
            this.trackBar3.Location = new System.Drawing.Point(292, 208);
            this.trackBar3.Maximum = 300;
            this.trackBar3.Minimum = 40;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(249, 45);
            this.trackBar3.SmallChange = 20;
            this.trackBar3.TabIndex = 55;
            this.trackBar3.TickFrequency = 10;
            this.trackBar3.Value = 40;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // checkBox1
            // 
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(15, 252);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(268, 16);
            this.checkBox1.TabIndex = 57;
            this.checkBox1.Text = "Autostart EveManager";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(15, 274);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(268, 16);
            this.checkBox2.TabIndex = 58;
            this.checkBox2.Text = "Auto Update EVE";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(15, 297);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(268, 16);
            this.checkBox3.TabIndex = 59;
            this.checkBox3.Text = "Disable SSL/TLS Verifcation";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(295, 275);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(172, 17);
            this.checkBox4.TabIndex = 61;
            this.checkBox4.Text = "Block Eve Telemetry Via Hosts";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(295, 252);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(143, 17);
            this.checkBox5.TabIndex = 60;
            this.checkBox5.Text = "Block Eve Traffic Via Fw";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(295, 296);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(112, 17);
            this.checkBox6.TabIndex = 62;
            this.checkBox6.Text = "Use Legacy Login";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxWCFPort);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxWCFIp);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkBox8);
            this.groupBox1.Controls.Add(this.checkBox7);
            this.groupBox1.Location = new System.Drawing.Point(11, 342);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 181);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remote WCF Settings";
            // 
            // textBoxWCFPort
            // 
            this.textBoxWCFPort.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWCFPort.Location = new System.Drawing.Point(9, 103);
            this.textBoxWCFPort.Name = "textBoxWCFPort";
            this.textBoxWCFPort.Size = new System.Drawing.Size(198, 21);
            this.textBoxWCFPort.TabIndex = 67;
            this.textBoxWCFPort.TextChanged += new System.EventHandler(this.textBoxWCFPort_TextChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 16);
            this.label7.TabIndex = 66;
            this.label7.Text = "Listen Port / Connect Port";
            // 
            // textBoxWCFIp
            // 
            this.textBoxWCFIp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWCFIp.Location = new System.Drawing.Point(9, 58);
            this.textBoxWCFIp.Name = "textBoxWCFIp";
            this.textBoxWCFIp.Size = new System.Drawing.Size(198, 21);
            this.textBoxWCFIp.TabIndex = 65;
            this.textBoxWCFIp.TextChanged += new System.EventHandler(this.textBoxWCFIp_TextChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 16);
            this.label6.TabIndex = 64;
            this.label6.Text = "Listen IP / Connect IP";
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(72, 19);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(52, 17);
            this.checkBox8.TabIndex = 65;
            this.checkBox8.Text = "Client";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(9, 19);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(57, 17);
            this.checkBox7.TabIndex = 64;
            this.checkBox7.Text = "Server";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // _recordingLocationTextbox
            // 
            this._recordingLocationTextbox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._recordingLocationTextbox.Location = new System.Drawing.Point(6, 55);
            this._recordingLocationTextbox.Name = "_recordingLocationTextbox";
            this._recordingLocationTextbox.Size = new System.Drawing.Size(269, 21);
            this._recordingLocationTextbox.TabIndex = 65;
            this._recordingLocationTextbox.TextChanged += new System.EventHandler(this._recordingLocationTextbox_TextChanged);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(152, 16);
            this.label12.TabIndex = 64;
            this.label12.Text = "Recording location:";
            // 
            // _recordingEnableCheckbox
            // 
            this._recordingEnableCheckbox.AutoSize = true;
            this._recordingEnableCheckbox.Location = new System.Drawing.Point(9, 19);
            this._recordingEnableCheckbox.Name = "_recordingEnableCheckbox";
            this._recordingEnableCheckbox.Size = new System.Drawing.Size(65, 17);
            this._recordingEnableCheckbox.TabIndex = 66;
            this._recordingEnableCheckbox.Text = "Enabled";
            this._recordingEnableCheckbox.UseVisualStyleBackColor = true;
            this._recordingEnableCheckbox.CheckedChanged += new System.EventHandler(this._recordingEnableCheckbox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this._recordingLocationTextbox);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this._recordingEnableCheckbox);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(289, 342);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 181);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Video Recording Settings";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(6, 144);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(269, 21);
            this.textBox1.TabIndex = 71;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 125);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(180, 16);
            this.label14.TabIndex = 70;
            this.label14.Text = "Video Rotation Maximum Size (GB):";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(6, 101);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(249, 21);
            this.comboBox2.TabIndex = 69;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(280, 16);
            this.label13.TabIndex = 68;
            this.label13.Text = "Encoder Setting:";
            // 
            // checkBox9
            // 
            this.checkBox9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox9.Location = new System.Drawing.Point(14, 319);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(268, 16);
            this.checkBox9.TabIndex = 68;
            this.checkBox9.Text = "Always Clear Non E# CCP Data";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.checkBox9_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 534);
            this.Controls.Add(this.checkBox9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxUseTorProxy);
            this.Controls.Add(this.buttonSendTestEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxReceiverEmailAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxGmailPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxGmailUser);
            this.Controls.Add(this.textBoxEveLocation);
            this.Controls.Add(this.exeFileLocationLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxEveLocation;
        private System.Windows.Forms.Label exeFileLocationLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxGmailUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGmailPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxReceiverEmailAddress;
        private System.Windows.Forms.Button buttonSendTestEmail;
        private System.Windows.Forms.CheckBox checkBoxUseTorProxy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxWCFPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxWCFIp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.TextBox _recordingLocationTextbox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox _recordingEnableCheckbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBox9;
    }
}