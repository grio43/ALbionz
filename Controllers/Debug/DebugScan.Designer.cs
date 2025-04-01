namespace EVESharpCore.Controllers.Debug
{
    partial class DebugScan
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDScan = new System.Windows.Forms.Button();
            this.btnPScan = new System.Windows.Forms.Button();
            this.btnShowProbes = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnLoadPScanresults = new System.Windows.Forms.Button();
            this.btnAutoProbe = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(923, 336);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnDScan
            // 
            this.btnDScan.BackColor = System.Drawing.Color.White;
            this.btnDScan.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDScan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDScan.Location = new System.Drawing.Point(12, 366);
            this.btnDScan.Name = "btnDScan";
            this.btnDScan.Size = new System.Drawing.Size(153, 21);
            this.btnDScan.TabIndex = 147;
            this.btnDScan.Text = "DScan";
            this.btnDScan.UseVisualStyleBackColor = false;
            this.btnDScan.Click += new System.EventHandler(this.btnDScan_Click);
            // 
            // btnPScan
            // 
            this.btnPScan.BackColor = System.Drawing.Color.White;
            this.btnPScan.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPScan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPScan.Location = new System.Drawing.Point(171, 366);
            this.btnPScan.Name = "btnPScan";
            this.btnPScan.Size = new System.Drawing.Size(153, 21);
            this.btnPScan.TabIndex = 148;
            this.btnPScan.Text = "PScan";
            this.btnPScan.UseVisualStyleBackColor = false;
            this.btnPScan.Click += new System.EventHandler(this.btnPScan_Click);
            // 
            // btnShowProbes
            // 
            this.btnShowProbes.BackColor = System.Drawing.Color.White;
            this.btnShowProbes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnShowProbes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowProbes.Location = new System.Drawing.Point(941, 366);
            this.btnShowProbes.Name = "btnShowProbes";
            this.btnShowProbes.Size = new System.Drawing.Size(153, 21);
            this.btnShowProbes.TabIndex = 149;
            this.btnShowProbes.Text = "Show probes";
            this.btnShowProbes.UseVisualStyleBackColor = false;
            this.btnShowProbes.Click += new System.EventHandler(this.btnShowProbes_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(941, 22);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(537, 336);
            this.dataGridView2.TabIndex = 150;
            // 
            // btnLoadPScanresults
            // 
            this.btnLoadPScanresults.BackColor = System.Drawing.Color.White;
            this.btnLoadPScanresults.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLoadPScanresults.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadPScanresults.Location = new System.Drawing.Point(327, 366);
            this.btnLoadPScanresults.Name = "btnLoadPScanresults";
            this.btnLoadPScanresults.Size = new System.Drawing.Size(153, 21);
            this.btnLoadPScanresults.TabIndex = 151;
            this.btnLoadPScanresults.Text = "Load PScan results";
            this.btnLoadPScanresults.UseVisualStyleBackColor = false;
            this.btnLoadPScanresults.Click += new System.EventHandler(this.btnLoadPScanResults_Click);
            // 
            // btnAutoProbe
            // 
            this.btnAutoProbe.BackColor = System.Drawing.Color.White;
            this.btnAutoProbe.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAutoProbe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoProbe.Location = new System.Drawing.Point(543, 366);
            this.btnAutoProbe.Name = "btnAutoProbe";
            this.btnAutoProbe.Size = new System.Drawing.Size(153, 21);
            this.btnAutoProbe.TabIndex = 152;
            this.btnAutoProbe.Text = "Auto probe";
            this.btnAutoProbe.UseVisualStyleBackColor = false;
            this.btnAutoProbe.Click += new System.EventHandler(this.btnAutoProbe_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(702, 366);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(153, 21);
            this.btnCancel.TabIndex = 153;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1343, 23);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status:";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DebugScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1488, 399);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAutoProbe);
            this.Controls.Add(this.btnLoadPScanresults);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnShowProbes);
            this.Controls.Add(this.btnPScan);
            this.Controls.Add(this.btnDScan);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DebugScan";
            this.Text = "DebugScan";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDScan;
        private System.Windows.Forms.Button btnPScan;
        private System.Windows.Forms.Button btnShowProbes;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnLoadPScanresults;
        private System.Windows.Forms.Button btnAutoProbe;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStatus;
    }
}