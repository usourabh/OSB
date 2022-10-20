
namespace OperationalStatisticsBook
{
    partial class rptDistributionOfFleetByTypeMake
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
            this.tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommissionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtcoperationDataSet = new OperationalStatisticsBook.dtcoperationDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommissionTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommissionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommissionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommissionBindingSource
            // 
            this.tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommissionBindingSource.DataMember = "tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommission";
            this.tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommissionBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "OperationalStatisticsBook";
            reportDataSource1.Value = this.tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommissionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptDistributionOfFleetByTypeMake.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(804, 594);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommissionTableAdapter
            // 
            this.tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommissionTableAdapter.ClearBeforeFill = true;
            // 
            // rptDistributionOfFleetByTypeMake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 594);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptDistributionOfFleetByTypeMake";
            this.Text = "rptDistributionOfFleetByTypeMake";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptDistributionOfFleetByTypeMake_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommissionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommissionBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommissionTableAdapter tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommissionTableAdapter;
    }
}