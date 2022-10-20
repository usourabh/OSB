
namespace OperationalStatisticsBook
{
    partial class StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022
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
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(797, 406);
            this.dataGridView1.TabIndex = 0;
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(713, 415);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 33);
            this.Reset.TabIndex = 1;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.ResetOnClick);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(617, 415);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(90, 33);
            this.Save.TabIndex = 2;
            this.Save.Text = "Data Verified";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.SaveOnClick);
            // 
            // Print_Report
            // 
            this.Print_Report.Location = new System.Drawing.Point(519, 416);
            this.Print_Report.Name = "Print_Report";
            this.Print_Report.Size = new System.Drawing.Size(92, 32);
            this.Print_Report.TabIndex = 3;
            this.Print_Report.Text = "Generate Pdf";
            this.Print_Report.UseVisualStyleBackColor = true;
            this.Print_Report.Click += new System.EventHandler(this.PrintReportOnClick);
            // 
            // StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Print_Report);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_" +
    "2022";
            this.Text = "StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_" +
    "2022";
            this.Load += new System.EventHandler(this.StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022_Load);
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