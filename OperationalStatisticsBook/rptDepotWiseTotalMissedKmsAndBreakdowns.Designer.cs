﻿
namespace OperationalStatisticsBook
{
    partial class rptDepotWiseTotalMissedKmsAndBreakdowns
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
            this.tbl_DepotWiseTotalMissedKmsAndBreakdownsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtcoperationDataSet = new OperationalStatisticsBook.dtcoperationDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbl_DepotWiseTotalMissedKmsAndBreakdownsTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_DepotWiseTotalMissedKmsAndBreakdownsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DepotWiseTotalMissedKmsAndBreakdownsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_DepotWiseTotalMissedKmsAndBreakdownsBindingSource
            // 
            this.tbl_DepotWiseTotalMissedKmsAndBreakdownsBindingSource.DataMember = "tbl_DepotWiseTotalMissedKmsAndBreakdowns";
            this.tbl_DepotWiseTotalMissedKmsAndBreakdownsBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "rptDepotWiseTotalMissedKmsAndBreakdowns";
            reportDataSource1.Value = this.tbl_DepotWiseTotalMissedKmsAndBreakdownsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptDepotWiseTotalMissedKmsAndBreakdowns.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(804, 594);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbl_DepotWiseTotalMissedKmsAndBreakdownsTableAdapter
            // 
            this.tbl_DepotWiseTotalMissedKmsAndBreakdownsTableAdapter.ClearBeforeFill = true;
            // 
            // rptDepotWiseTotalMissedKmsAndBreakdowns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 594);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "rptDepotWiseTotalMissedKmsAndBreakdowns";
            this.Text = "rptDepotWiseTotalMissedKmsAndBreakdowns";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptDepotWiseTotalMissedKmsAndBreakdowns_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DepotWiseTotalMissedKmsAndBreakdownsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_DepotWiseTotalMissedKmsAndBreakdownsBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_DepotWiseTotalMissedKmsAndBreakdownsTableAdapter tbl_DepotWiseTotalMissedKmsAndBreakdownsTableAdapter;
    }
}