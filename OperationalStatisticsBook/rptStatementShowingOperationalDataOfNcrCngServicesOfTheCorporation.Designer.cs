﻿
namespace OperationalStatisticsBook
{
    partial class rptStatementShowingOperationalDataOfNcrCngServicesOfTheCorporation
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
            this.tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtcoperationDataSet = new OperationalStatisticsBook.dtcoperationDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022TableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022BindingSource
            // 
            this.tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022BindingSource.DataMember = "tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJ" +
    "uly_2022";
            this.tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022BindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "rptStatementShowingOperationalDataOfNcrCngServicesOfTheCorporation";
            reportDataSource1.Value = this.tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptStatementShowingOperationalDataOfNcrCngServicesOfThe" +
    "Corporation.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(804, 594);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022TableAdapter
            // 
            this.tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022TableAdapter.ClearBeforeFill = true;
            // 
            // rptStatementShowingOperationalDataOfNcrCngServicesOfTheCorporation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 594);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptStatementShowingOperationalDataOfNcrCngServicesOfTheCorporation";
            this.Text = "rptStatementShowingOperationalDataOfNcrCngServicesOfTheCorporation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptStatementShowingOperationalDataOfNcrCngServicesOfTheCorporation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022BindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022TableAdapter tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022TableAdapter;
    }
}