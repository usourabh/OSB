﻿
namespace OperationalStatisticsBook
{
    partial class rptCategorywiseStaffPositionAsOn
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
            this.tbl_CategorywiseStaffPositionAsOnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_CategorywiseStaffPositionAsOnTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_CategorywiseStaffPositionAsOnTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_CategorywiseStaffPositionAsOnBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "rptCategorywiseStaffPositionAsOn";
            reportDataSource1.Value = this.tbl_CategorywiseStaffPositionAsOnBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptCategorywiseStaffPositionAsOn.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(798, 449);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_CategorywiseStaffPositionAsOnBindingSource
            // 
            this.tbl_CategorywiseStaffPositionAsOnBindingSource.DataMember = "tbl_CategorywiseStaffPositionAsOn";
            this.tbl_CategorywiseStaffPositionAsOnBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // tbl_CategorywiseStaffPositionAsOnTableAdapter
            // 
            this.tbl_CategorywiseStaffPositionAsOnTableAdapter.ClearBeforeFill = true;
            // 
            // rptCategorywiseStaffPositionAsOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptCategorywiseStaffPositionAsOn";
            this.Text = "rptCategorywiseStaffPositionAsOn";
            this.Load += new System.EventHandler(this.rptCategorywiseStaffPositionAsOn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_CategorywiseStaffPositionAsOnBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_CategorywiseStaffPositionAsOnBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_CategorywiseStaffPositionAsOnTableAdapter tbl_CategorywiseStaffPositionAsOnTableAdapter;
    }
}