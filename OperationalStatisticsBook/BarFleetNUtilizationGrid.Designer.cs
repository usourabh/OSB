
namespace OperationalStatisticsBook
{
    partial class BarFleetNUtilizationGrid
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
            this.Generate_Pdf = new System.Windows.Forms.Button();
            this.Data_Verified = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(713, 415);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 23);
            this.Reset.TabIndex = 1;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_OnClick);
            // 
            // Generate_Pdf
            // 
            this.Generate_Pdf.Location = new System.Drawing.Point(537, 415);
            this.Generate_Pdf.Name = "Generate_Pdf";
            this.Generate_Pdf.Size = new System.Drawing.Size(75, 23);
            this.Generate_Pdf.TabIndex = 3;
            this.Generate_Pdf.Text = "Generate PDF";
            this.Generate_Pdf.UseVisualStyleBackColor = true;
            this.Generate_Pdf.Click += new System.EventHandler(this.GeneratePdf_OnClick);
            // 
            // Data_Verified
            // 
            this.Data_Verified.Location = new System.Drawing.Point(618, 415);
            this.Data_Verified.Name = "Data_Verified";
            this.Data_Verified.Size = new System.Drawing.Size(89, 23);
            this.Data_Verified.TabIndex = 4;
            this.Data_Verified.Text = "Data Verified";
            this.Data_Verified.UseVisualStyleBackColor = true;
            this.Data_Verified.Click += new System.EventHandler(this.Data_Verified_Click);
            // 
            // BarFleetNUtilizationGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Data_Verified);
            this.Controls.Add(this.Generate_Pdf);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BarFleetNUtilizationGrid";
            this.Text = "BarFleetNUtilizationGrid";
            this.Load += new System.EventHandler(this.BarFleetNUtilizationGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Generate_Pdf;
        private System.Windows.Forms.Button Data_Verified;
    }
}