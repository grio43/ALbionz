namespace EVESharpCore.Controllers.Debug
{
    partial class DebugWindows
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
            this.DebugWindowsDataGridView2 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyIdToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowWindows = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DebugWindowsDataGridView2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DebugWindowsDataGridView2
            // 
            this.DebugWindowsDataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DebugWindowsDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DebugWindowsDataGridView2.ContextMenuStrip = this.contextMenuStrip1;
            this.DebugWindowsDataGridView2.Dock = System.Windows.Forms.DockStyle.Top;
            this.DebugWindowsDataGridView2.Location = new System.Drawing.Point(0, 0);
            this.DebugWindowsDataGridView2.MultiSelect = false;
            this.DebugWindowsDataGridView2.Name = "DebugWindowsDataGridView2";
            this.DebugWindowsDataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DebugWindowsDataGridView2.Size = new System.Drawing.Size(1131, 501);
            this.DebugWindowsDataGridView2.TabIndex = 152;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyIdToClipboardToolStripMenuItem,
            this.monitorEntityToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 48);
            // 
            // copyIdToClipboardToolStripMenuItem
            // 
            this.copyIdToClipboardToolStripMenuItem.Name = "copyIdToClipboardToolStripMenuItem";
            this.copyIdToClipboardToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.copyIdToClipboardToolStripMenuItem.Text = "Copy id to clipboard";
            this.copyIdToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyIdToClipboardToolStripMenuItem_Click);
            // 
            // monitorEntityToolStripMenuItem
            // 
            this.monitorEntityToolStripMenuItem.Name = "monitorEntityToolStripMenuItem";
            this.monitorEntityToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.monitorEntityToolStripMenuItem.Text = "Monitor entity";
            this.monitorEntityToolStripMenuItem.Click += new System.EventHandler(this.monitorEntityToolStripMenuItem_Click);
            // 
            // btnShowWindows
            // 
            this.btnShowWindows.BackColor = System.Drawing.Color.White;
            this.btnShowWindows.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnShowWindows.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowWindows.Location = new System.Drawing.Point(-1, 508);
            this.btnShowWindows.Name = "btnShowWindows";
            this.btnShowWindows.Size = new System.Drawing.Size(153, 26);
            this.btnShowWindows.TabIndex = 151;
            this.btnShowWindows.Text = "Show windows";
            this.btnShowWindows.UseVisualStyleBackColor = false;
            this.btnShowWindows.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(158, 508);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 26);
            this.button1.TabIndex = 153;
            this.button1.Text = "Clear action queue";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DebugWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 538);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DebugWindowsDataGridView2);
            this.Controls.Add(this.btnShowWindows);
            this.Name = "DebugWindows";
            this.Text = "DebugWindows";
            ((System.ComponentModel.ISupportInitialize)(this.DebugWindowsDataGridView2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DebugWindowsDataGridView2;
        private System.Windows.Forms.Button btnShowWindows;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyIdToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitorEntityToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}