
namespace OperationalStatisticsBook
{
    partial class rptStatementShowingRegionalWiseOperational
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
            this.tbl_StatementShowingRegionWiseOperationalDataForTheMonthBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtcoperationDataSet = new OperationalStatisticsBook.dtcoperationDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbl_StatementShowingRegionWiseOperationalDataForTheMonthTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_StatementShowingRegionWiseOperationalDataForTheMonthTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_StatementShowingRegionWiseOperationalDataForTheMonthBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_StatementShowingRegionWiseOperationalDataForTheMonthBindingSource
            // 
            this.tbl_StatementShowingRegionWiseOperationalDataForTheMonthBindingSource.DataMember = "tbl_StatementShowingRegionWiseOperationalDataForTheMonth";
            this.tbl_StatementShowingRegionWiseOperationalDataForTheMonthBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "StatementShowingRegionalWiseOperational";
            reportDataSource1.Value = this.tbl_StatementShowingRegionWiseOperationalDataForTheMonthBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptStatementShowingRegionalWiseOperational.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(804, 594);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbl_StatementShowingRegionWiseOperationalDataForTheMonthTableAdapter
            // 
            this.tbl_StatementShowingRegionWiseOperationalDataForTheMonthTableAdapter.ClearBeforeFill = true;
            // 
            // rptStatementShowingRegionalWiseOperational
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 594);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptStatementShowingRegionalWiseOperational";
            this.Text = "rptStatementShowingRegionalWiseOperational";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptStatementShowingRegionalWiseOperational_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_StatementShowingRegionWiseOperationalDataForTheMonthBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_StatementShowingRegionWiseOperationalDataForTheMonthBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_StatementShowingRegionWiseOperationalDataForTheMonthTableAdapter tbl_StatementShowingRegionWiseOperationalDataForTheMonthTableAdapter;
    }
}