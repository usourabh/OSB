
namespace OperationalStatisticsBook
{
    partial class frmOSBMain
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
            this.grdIndexPage = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnupdateIndexPage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdIndexPage)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdIndexPage
            // 
            this.grdIndexPage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdIndexPage.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grdIndexPage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdIndexPage.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grdIndexPage.Location = new System.Drawing.Point(6, 19);
            this.grdIndexPage.Name = "grdIndexPage";
            this.grdIndexPage.Size = new System.Drawing.Size(729, 376);
            this.grdIndexPage.TabIndex = 5;
            this.grdIndexPage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdIndexPage_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnupdateIndexPage);
            this.groupBox2.Controls.Add(this.grdIndexPage);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(741, 430);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "INDEX PAGE";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(607, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Reset Default";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnupdateIndexPage
            // 
            this.btnupdateIndexPage.Location = new System.Drawing.Point(473, 401);
            this.btnupdateIndexPage.Name = "btnupdateIndexPage";
            this.btnupdateIndexPage.Size = new System.Drawing.Size(128, 23);
            this.btnupdateIndexPage.TabIndex = 6;
            this.btnupdateIndexPage.Text = "Save";
            this.btnupdateIndexPage.UseVisualStyleBackColor = true;
            this.btnupdateIndexPage.Click += new System.EventHandler(this.btnupdateIndexPage_Click);
            // 
            // frmOSBMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 460);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmOSBMain";
            this.Text = "Operational Statistics Book - INEDX PAGE";
            this.Load += new System.EventHandler(this.frmOSBMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdIndexPage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView grdIndexPage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnupdateIndexPage;
        private System.Windows.Forms.Button button1;
    }
}

