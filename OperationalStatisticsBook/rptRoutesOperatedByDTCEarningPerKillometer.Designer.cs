﻿
namespace OperationalStatisticsBook
{
    partial class rptRoutesOperatedByDTCEarningPerKillometer
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
            this.tbl_RoutesOperatedByDTCEarningPerKillometerJuneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_RoutesOperatedByDTCEarningPerKillometerJuneTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_RoutesOperatedByDTCEarningPerKillometerJuneTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_RoutesOperatedByDTCEarningPerKillometerJuneBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "RoutesOperatedByDTCEarningPerKillometer";
            reportDataSource1.Value = this.tbl_RoutesOperatedByDTCEarningPerKillometerJuneBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptRoutesOperatedByDTCEarningPerKillometer.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 314);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_RoutesOperatedByDTCEarningPerKillometerJuneBindingSource
            // 
            this.tbl_RoutesOperatedByDTCEarningPerKillometerJuneBindingSource.DataMember = "tbl_RoutesOperatedByDTCEarningPerKillometerJune";
            this.tbl_RoutesOperatedByDTCEarningPerKillometerJuneBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // tbl_RoutesOperatedByDTCEarningPerKillometerJuneTableAdapter
            // 
            this.tbl_RoutesOperatedByDTCEarningPerKillometerJuneTableAdapter.ClearBeforeFill = true;
            // 
            // rptRoutesOperatedByDTCEarningPerKillometer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptRoutesOperatedByDTCEarningPerKillometer";
            this.Text = "rptRoutesOperatedByDTCEarningPerKillometer";
            this.Load += new System.EventHandler(this.rptRoutesOperatedByDTCEarningPerKillometer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_RoutesOperatedByDTCEarningPerKillometerJuneBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_RoutesOperatedByDTCEarningPerKillometerJuneBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_RoutesOperatedByDTCEarningPerKillometerJuneTableAdapter tbl_RoutesOperatedByDTCEarningPerKillometerJuneTableAdapter;
    }
}