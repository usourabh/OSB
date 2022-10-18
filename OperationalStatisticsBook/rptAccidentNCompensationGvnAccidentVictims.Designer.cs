
namespace OperationalStatisticsBook
{
    partial class rptAccidentNCompensationGvnAccidentVictims
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tbl_AccidentNCompensationGvnAccidentVictimsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtcoperationDataSet = new OperationalStatisticsBook.dtcoperationDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbl_AccidentNCompensationGvnAccidentVictimsTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_AccidentNCompensationGvnAccidentVictimsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_AccidentNCompensationGvnAccidentVictimsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_AccidentNCompensationGvnAccidentVictimsBindingSource
            // 
            this.tbl_AccidentNCompensationGvnAccidentVictimsBindingSource.DataMember = "tbl_AccidentNCompensationGvnAccidentVictims";
            this.tbl_AccidentNCompensationGvnAccidentVictimsBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "rptAccidentNCompensationGvnAccidentVictims";
            reportDataSource1.Value = this.tbl_AccidentNCompensationGvnAccidentVictimsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptAccidentNCompensationGvnAccidentVictims.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(533, 292);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbl_AccidentNCompensationGvnAccidentVictimsTableAdapter
            // 
            this.tbl_AccidentNCompensationGvnAccidentVictimsTableAdapter.ClearBeforeFill = true;
            // 
            // rptAccidentNCompensationGvnAccidentVictims
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "rptAccidentNCompensationGvnAccidentVictims";
            this.Text = "rptAccidentNCompensationGvnAccidentVictims";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptAccidentNCompensationGvnAccidentVictims_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_AccidentNCompensationGvnAccidentVictimsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_AccidentNCompensationGvnAccidentVictimsBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_AccidentNCompensationGvnAccidentVictimsTableAdapter tbl_AccidentNCompensationGvnAccidentVictimsTableAdapter;
    }
}