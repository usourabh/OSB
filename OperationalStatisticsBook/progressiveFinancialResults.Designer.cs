
using System;

namespace OperationalStatisticsBook
{
    partial class progressiveFinancialResults
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView grdIndexPage;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button resetBtn;

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
            this.BtnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.Print_Report = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(656, 445);
            this.dataGridView1.TabIndex = 0;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(473, 463);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(92, 37);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "Data Verified";
            this.BtnSave.UseMnemonic = false;
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.SaveOnClick);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(571, 463);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(83, 37);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Print_Report
            // 
            this.Print_Report.Location = new System.Drawing.Point(361, 463);
            this.Print_Report.Name = "Print_Report";
            this.Print_Report.Size = new System.Drawing.Size(106, 37);
            this.Print_Report.TabIndex = 3;
            this.Print_Report.Text = "Generate Pdf";
            this.Print_Report.UseVisualStyleBackColor = true;
            this.Print_Report.Click += new System.EventHandler(this.Print_ReportOnClick);
            // 
            // progressiveFinancialResults
            // 
            this.ClientSize = new System.Drawing.Size(690, 506);
            this.Controls.Add(this.Print_Report);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.dataGridView1);
            this.Name = "progressiveFinancialResults";
            this.Load += new System.EventHandler(this.progressiveFinancialResults_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }




        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button Print_Report;
    }
}