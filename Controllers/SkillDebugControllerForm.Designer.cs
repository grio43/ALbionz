﻿namespace EVESharpCore.Controllers
{
    partial class SkillDebugControllerForm
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
            this.showRequirementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excludeMySkillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeMySkillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSkillToEndOfQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSkillToFrontOfQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(3, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(644, 193);
            this.dataGridView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showRequirementsToolStripMenuItem,
            this.addSkillToEndOfQueueToolStripMenuItem,
            this.addSkillToFrontOfQueueToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(213, 70);
            // 
            // showRequirementsToolStripMenuItem
            // 
            this.showRequirementsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excludeMySkillsToolStripMenuItem,
            this.includeMySkillsToolStripMenuItem});
            this.showRequirementsToolStripMenuItem.Name = "showRequirementsToolStripMenuItem";
            this.showRequirementsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.showRequirementsToolStripMenuItem.Text = "Show requirements";
            // 
            // excludeMySkillsToolStripMenuItem
            // 
            this.excludeMySkillsToolStripMenuItem.Name = "excludeMySkillsToolStripMenuItem";
            this.excludeMySkillsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.excludeMySkillsToolStripMenuItem.Text = "Exclude my skills";
            this.excludeMySkillsToolStripMenuItem.Click += new System.EventHandler(this.excludeMySkillsToolStripMenuItem_Click);
            // 
            // includeMySkillsToolStripMenuItem
            // 
            this.includeMySkillsToolStripMenuItem.Name = "includeMySkillsToolStripMenuItem";
            this.includeMySkillsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.includeMySkillsToolStripMenuItem.Text = "Include my skills";
            this.includeMySkillsToolStripMenuItem.Click += new System.EventHandler(this.includeMySkillsToolStripMenuItem_Click);
            // 
            // addSkillToEndOfQueueToolStripMenuItem
            // 
            this.addSkillToEndOfQueueToolStripMenuItem.Name = "addSkillToEndOfQueueToolStripMenuItem";
            this.addSkillToEndOfQueueToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.addSkillToEndOfQueueToolStripMenuItem.Text = "Add skill to end of queue";
            this.addSkillToEndOfQueueToolStripMenuItem.Click += new System.EventHandler(this.addSkillToEndOfQueueToolStripMenuItem_Click);
            // 
            // addSkillToFrontOfQueueToolStripMenuItem
            // 
            this.addSkillToFrontOfQueueToolStripMenuItem.Name = "addSkillToFrontOfQueueToolStripMenuItem";
            this.addSkillToFrontOfQueueToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.addSkillToFrontOfQueueToolStripMenuItem.Text = "Add skill to front of queue";
            this.addSkillToFrontOfQueueToolStripMenuItem.Click += new System.EventHandler(this.addSkillToFrontOfQueueToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Blue;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 253);
            this.panel1.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(372, 211);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 21);
            this.button3.TabIndex = 149;
            this.button3.Text = "Show skill queue";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(243, 211);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 21);
            this.button2.TabIndex = 148;
            this.button2.Text = "Show all skills";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(114, 211);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 21);
            this.button4.TabIndex = 147;
            this.button4.Text = "Skill queue length";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 21);
            this.button1.TabIndex = 146;
            this.button1.Text = "Show my skills";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SkillDebugControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 253);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SkillDebugControllerForm";
            this.Text = "SkillDebug";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showRequirementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excludeMySkillsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeMySkillsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSkillToEndOfQueueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSkillToFrontOfQueueToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
    }
}