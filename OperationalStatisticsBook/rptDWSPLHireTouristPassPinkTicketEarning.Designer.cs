
namespace OperationalStatisticsBook
{
    partial class rptDWSPLHireTouristPassPinkTicketEarning
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
            this.tbl_DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarningBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtcoperationDataSet = new OperationalStatisticsBook.dtcoperationDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbl_DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarningTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarningTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarningBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarningBindingSource
            // 
            this.tbl_DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarningBindingSource.DataMember = "tbl_DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarning";
            this.tbl_DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarningBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DWSPLHireTouristPassPinkTicketEarning";
            reportDataSource1.Value = this.tbl_DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarningBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptDWSPLHireTouristPassPinkTicketEarning.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(804, 594);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbl_DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarningTableAdapter
            // 
            this.tbl_DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarningTableAdapter.ClearBeforeFill = true;
            // 
            // rptDWSPLHireTouristPassPinkTicketEarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 594);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptDWSPLHireTouristPassPinkTicketEarning";
            this.Text = "rptDWSPLHireTouristPassPinkTicketEarning";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptDWSPLHireTouristPassPinkTicketEarning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarningBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarningBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarningTableAdapter tbl_DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarningTableAdapter;
    }
}