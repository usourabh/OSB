
namespace OperationalStatisticsBook
{
    partial class rptStatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs
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
            this.tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhsTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "rptStatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2" +
    "022InLakhs";
            reportDataSource1.Value = this.tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptStatementShowingTheRsInRespectOfCityNCRForeignBusSer" +
    "viceIncomeExpewditureJune2022InLakhs.rdlc";
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
            // tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhsBindingSource
            // 
            this.tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhsBindingSource.DataMember = "tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune" +
    "2022InLakhs";
            this.tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhsBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhsTableAdapter
            // 
            this.tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhsTableAdapter.ClearBeforeFill = true;
            // 
            // rptStatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptStatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2" +
    "022InLakhs";
            this.Text = "rptStatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2" +
    "022InLakhs";
            this.Load += new System.EventHandler(this.rptStatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhsBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhsTableAdapter tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhsTableAdapter;
    }
}