
namespace OperationalStatisticsBook
{
    partial class rptStatementShowingRespectCityNCRForeignBusService
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
            this.tbl_StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022InlakhsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtcoperationDataSet = new OperationalStatisticsBook.dtcoperationDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbl_StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022InlakhsTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022InlakhsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022InlakhsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022InlakhsBindingSource
            // 
            this.tbl_StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022InlakhsBindingSource.DataMember = "tbl_StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewndit" +
    "ureJune_2022Inlakhs";
            this.tbl_StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022InlakhsBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "StatementShowingRespectCityNCRForeignBusService";
            reportDataSource1.Value = this.tbl_StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022InlakhsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptStatementShowingRespectCityNCRForeignBusService.rdlc" +
    "";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbl_StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022InlakhsTableAdapter
            // 
            this.tbl_StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022InlakhsTableAdapter.ClearBeforeFill = true;
            // 
            // rptStatementShowingRespectCityNCRForeignBusService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptStatementShowingRespectCityNCRForeignBusService";
            this.Text = "rptStatementShowingRespectCityNCRForeignBusService";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptStatementShowingRespectCityNCRForeignBusService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022InlakhsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022InlakhsBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022InlakhsTableAdapter tbl_StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022InlakhsTableAdapter;
    }
}