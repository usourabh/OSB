﻿
namespace OperationalStatisticsBook
{
    partial class DWODFCMSFleetItsUtilization
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
            this.Reset = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.PrintReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 319);
            this.dataGridView1.TabIndex = 0;
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(687, 362);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(101, 23);
            this.Reset.TabIndex = 1;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.ResetOnClick);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(592, 362);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 2;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.SaveOnClick);
            // 
            // PrintReport
            // 
            this.PrintReport.Location = new System.Drawing.Point(501, 362);
            this.PrintReport.Name = "PrintReport";
            this.PrintReport.Size = new System.Drawing.Size(75, 23);
            this.PrintReport.TabIndex = 3;
            this.PrintReport.Text = "PrintReport";
            this.PrintReport.UseVisualStyleBackColor = true;
            this.PrintReport.Click += new System.EventHandler(this.PrintReportOnClick);
            // 
            // DWODFCMSFleetItsUtilization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 397);
            this.Controls.Add(this.PrintReport);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DWODFCMSFleetItsUtilization";
            this.Text = "DWODFCMSFleetItsUtilization";
            this.Load += new System.EventHandler(this.DWODFCMSFleetItsUtilization_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button PrintReport;
    }
}