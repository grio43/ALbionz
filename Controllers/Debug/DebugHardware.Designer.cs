namespace EVESharpCore.Controllers.Debug
{
    partial class DebugHardware
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadWithChargeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printAllItemAttributesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowPublicIP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(993, 413);
            this.dataGridView1.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadToolStripMenuItem,
            this.reloadWithChargeToolStripMenuItem,
            this.printAllItemAttributesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(195, 70);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.reloadToolStripMenuItem.Text = "Reload all";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // reloadWithChargeToolStripMenuItem
            // 
            this.reloadWithChargeToolStripMenuItem.Name = "reloadWithChargeToolStripMenuItem";
            this.reloadWithChargeToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.reloadWithChargeToolStripMenuItem.Text = "Reload with charge";
            // 
            // printAllItemAttributesToolStripMenuItem
            // 
            this.printAllItemAttributesToolStripMenuItem.Name = "printAllItemAttributesToolStripMenuItem";
            this.printAllItemAttributesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.printAllItemAttributesToolStripMenuItem.Text = "Print all item attributes";
            this.printAllItemAttributesToolStripMenuItem.Click += new System.EventHandler(this.printAllItemAttributesToolStripMenuItem_Click);
            // 
            // btnShowPublicIP
            // 
            this.btnShowPublicIP.BackColor = System.Drawing.Color.White;
            this.btnShowPublicIP.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnShowPublicIP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowPublicIP.Location = new System.Drawing.Point(12, 431);
            this.btnShowPublicIP.Name = "btnShowPublicIP";
            this.btnShowPublicIP.Size = new System.Drawing.Size(153, 21);
            this.btnShowPublicIP.TabIndex = 149;
            this.btnShowPublicIP.Text = "Show Public IP";
            this.btnShowPublicIP.UseVisualStyleBackColor = false;
            this.btnShowPublicIP.Click += new System.EventHandler(this.BtnShowPublicIP_Click);
            // 
            // DebugHardware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 458);
            this.Controls.Add(this.btnShowPublicIP);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DebugHardware";
            this.Text = "DebugHardware";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadWithChargeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printAllItemAttributesToolStripMenuItem;
        private System.Windows.Forms.Button btnShowPublicIP;
    }
}