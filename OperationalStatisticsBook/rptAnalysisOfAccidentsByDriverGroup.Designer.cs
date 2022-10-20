
namespace OperationalStatisticsBook
{
    partial class rptAnalysisOfAccidentsByDriverGroup
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
            this.tbl_AnalysisOfAccidentsByDriverGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtcoperationDataSet = new OperationalStatisticsBook.dtcoperationDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbl_AnalysisOfAccidentsByDriverGroupTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_AnalysisOfAccidentsByDriverGroupTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_AnalysisOfAccidentsByDriverGroupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_AnalysisOfAccidentsByDriverGroupBindingSource
            // 
            this.tbl_AnalysisOfAccidentsByDriverGroupBindingSource.DataMember = "tbl_AnalysisOfAccidentsByDriverGroup";
            this.tbl_AnalysisOfAccidentsByDriverGroupBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "rptrptAnalysisOfAccidentsByDriverGroup";
            reportDataSource1.Value = this.tbl_AnalysisOfAccidentsByDriverGroupBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptAnalysisOfAccidentsByDriverGroup.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 447);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbl_AnalysisOfAccidentsByDriverGroupTableAdapter
            // 
            this.tbl_AnalysisOfAccidentsByDriverGroupTableAdapter.ClearBeforeFill = true;
            // 
            // rptAnalysisOfAccidentsByDriverGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 594);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptAnalysisOfAccidentsByDriverGroup";
            this.Text = "rptAnalysisOfAccidentsByDriverGroup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptAnalysisOfAccidentsByDriverGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_AnalysisOfAccidentsByDriverGroupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_AnalysisOfAccidentsByDriverGroupBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_AnalysisOfAccidentsByDriverGroupTableAdapter tbl_AnalysisOfAccidentsByDriverGroupTableAdapter;
    }
}