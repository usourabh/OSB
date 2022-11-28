
namespace OperationalStatisticsBook
{
    partial class analysisOfCausesAccidents
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
            this.SaveBtn = new System.Windows.Forms.Button();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.Print_Report = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 409);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(622, 415);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(85, 23);
            this.SaveBtn.TabIndex = 1;
            this.SaveBtn.Text = "Data Verified";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // ResetBtn
            // 
            this.ResetBtn.Location = new System.Drawing.Point(713, 415);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(75, 23);
            this.ResetBtn.TabIndex = 2;
            this.ResetBtn.Text = "Reset Default";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.Reset_OnClick);
            // 
            // Print_Report
            // 
            this.Print_Report.Location = new System.Drawing.Point(531, 415);
            this.Print_Report.Name = "Print_Report";
            this.Print_Report.Size = new System.Drawing.Size(85, 23);
            this.Print_Report.TabIndex = 3;
            this.Print_Report.Text = "Generate Pdf";
            this.Print_Report.UseVisualStyleBackColor = true;
            this.Print_Report.Click += new System.EventHandler(this.PrintReportOnClick);
            // 
            // analysisOfCausesAccidents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Print_Report);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "analysisOfCausesAccidents";
            this.Text = "analysisOfCausesAccidents";
            this.Load += new System.EventHandler(this.analysisOfCausesAccidents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Button Print_Report;
    }
}