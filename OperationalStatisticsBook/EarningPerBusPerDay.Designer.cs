
namespace OperationalStatisticsBook
{
    partial class EarningPerBusPerDay
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
            this.Generatebarchart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 18);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1164, 600);
            this.dataGridView1.TabIndex = 0;
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(1070, 638);
            this.Reset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(112, 35);
            this.Reset.TabIndex = 1;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.btnResetOnClick);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(898, 638);
            this.Save.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(136, 35);
            this.Save.TabIndex = 2;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.btnSaveOnClick);
            // 
            // Generatebarchart
            // 
            this.Generatebarchart.Location = new System.Drawing.Point(644, 638);
            this.Generatebarchart.Name = "Generatebarchart";
            this.Generatebarchart.Size = new System.Drawing.Size(187, 35);
            this.Generatebarchart.TabIndex = 3;
            this.Generatebarchart.Text = "Generatebarchart";
            this.Generatebarchart.UseVisualStyleBackColor = true;
            this.Generatebarchart.Click += new System.EventHandler(this.Generatebarchart_OnClick);
            // 
            // EarningPerBusPerDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.Generatebarchart);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EarningPerBusPerDay";
            this.Text = "EarningPerBusPerDay";
            this.Load += new System.EventHandler(this.EarningPerBusPerDay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Generatebarchart;
    }
}