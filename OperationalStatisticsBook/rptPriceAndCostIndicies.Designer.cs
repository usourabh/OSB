﻿
namespace OperationalStatisticsBook
{
    partial class rptPriceAndCostIndicies
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
            this.tbl_PriceAndCostIndiciesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_PriceAndCostIndiciesTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_PriceAndCostIndiciesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_PriceAndCostIndiciesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "rptPriceAndCostIndicies";
            reportDataSource1.Value = this.tbl_PriceAndCostIndiciesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptPriceAndCostIndicies.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(804, 594);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_PriceAndCostIndiciesBindingSource
            // 
            this.tbl_PriceAndCostIndiciesBindingSource.DataMember = "tbl_PriceAndCostIndicies";
            this.tbl_PriceAndCostIndiciesBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // tbl_PriceAndCostIndiciesTableAdapter
            // 
            this.tbl_PriceAndCostIndiciesTableAdapter.ClearBeforeFill = true;
            // 
            // rptPriceAndCostIndicies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 594);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptPriceAndCostIndicies";
            this.Text = "rptPriceAndCostIndicies";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptPriceAndCostIndicies_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_PriceAndCostIndiciesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_PriceAndCostIndiciesBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_PriceAndCostIndiciesTableAdapter tbl_PriceAndCostIndiciesTableAdapter;
    }
}