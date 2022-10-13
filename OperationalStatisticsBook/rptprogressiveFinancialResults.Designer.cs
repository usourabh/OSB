
namespace OperationalStatisticsBook
{
    partial class rptprogressiveFinancialResults
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtcoperationDataSet = new OperationalStatisticsBook.dtcoperationDataSet();
            this.tbl_ProgressiveFinancialResultsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_ProgressiveFinancialResultsTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_ProgressiveFinancialResultsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_ProgressiveFinancialResultsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "rptProgressiveFinancialResults";
            reportDataSource1.Value = this.tbl_ProgressiveFinancialResultsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptprogressiveFinancialResults.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_ProgressiveFinancialResultsBindingSource
            // 
            this.tbl_ProgressiveFinancialResultsBindingSource.DataMember = "tbl_ProgressiveFinancialResults";
            this.tbl_ProgressiveFinancialResultsBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // tbl_ProgressiveFinancialResultsTableAdapter
            // 
            this.tbl_ProgressiveFinancialResultsTableAdapter.ClearBeforeFill = true;
            // 
            // rptprogressiveFinancialResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptprogressiveFinancialResults";
            this.Text = "rptprogressiveFinancialResults";
            this.Load += new System.EventHandler(this.rptprogressiveFinancialResults_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_ProgressiveFinancialResultsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_ProgressiveFinancialResultsBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_ProgressiveFinancialResultsTableAdapter tbl_ProgressiveFinancialResultsTableAdapter;
    }
}