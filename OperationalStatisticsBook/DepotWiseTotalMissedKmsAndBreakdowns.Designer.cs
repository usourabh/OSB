
namespace OperationalStatisticsBook
{
    partial class DepotWiseTotalMissedKmsAndBreakdowns
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
            this.Print_Report = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 2);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(731, 367);
            this.dataGridView1.TabIndex = 0;
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(652, 373);
            this.Reset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(80, 27);
            this.Reset.TabIndex = 1;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.ResetOnClick);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(545, 373);
            this.Save.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(87, 27);
            this.Save.TabIndex = 2;
            this.Save.Text = "Data Verified";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.SaveOnClick);
            // 
            // Print_Report
            // 
            this.Print_Report.Location = new System.Drawing.Point(459, 373);
            this.Print_Report.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Print_Report.Name = "Print_Report";
            this.Print_Report.Size = new System.Drawing.Size(82, 27);
            this.Print_Report.TabIndex = 3;
            this.Print_Report.Text = "Generate Pdf";
            this.Print_Report.UseVisualStyleBackColor = true;
            this.Print_Report.Click += new System.EventHandler(this.Print_ReportOnClick);
            // 
            // DepotWiseTotalMissedKmsAndBreakdowns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 411);
            this.Controls.Add(this.Print_Report);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DepotWiseTotalMissedKmsAndBreakdowns";
            this.Text = "DepotWiseTotalMissedKmsAndBreakdowns";
            this.Load += new System.EventHandler(this.DepotWiseTotalMissedKmsAndBreakdowns_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Print_Report;
    }
}