
namespace OperationalStatisticsBook
{
    partial class rptStatementOfForTheMonthOfPasses
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
            this.tbl_StatementOfForTheMonthOfPassesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtcoperationDataSet = new OperationalStatisticsBook.dtcoperationDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbl_StatementOfForTheMonthOfPassesTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_StatementOfForTheMonthOfPassesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_StatementOfForTheMonthOfPassesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_StatementOfForTheMonthOfPassesBindingSource
            // 
            this.tbl_StatementOfForTheMonthOfPassesBindingSource.DataMember = "tbl_StatementOfForTheMonthOfPasses";
            this.tbl_StatementOfForTheMonthOfPassesBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "rptStatementOfForTheMonthOfPasses";
            reportDataSource1.Value = this.tbl_StatementOfForTheMonthOfPassesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptStatementOfForTheMonthOfPasses.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, -1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(799, 451);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbl_StatementOfForTheMonthOfPassesTableAdapter
            // 
            this.tbl_StatementOfForTheMonthOfPassesTableAdapter.ClearBeforeFill = true;
            // 
            // rptStatementOfForTheMonthOfPasses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptStatementOfForTheMonthOfPasses";
            this.Text = "rptStatementOfForTheMonthOfPasses";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptStatementOfForTheMonthOfPasses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_StatementOfForTheMonthOfPassesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_StatementOfForTheMonthOfPassesBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_StatementOfForTheMonthOfPassesTableAdapter tbl_StatementOfForTheMonthOfPassesTableAdapter;
    }
}