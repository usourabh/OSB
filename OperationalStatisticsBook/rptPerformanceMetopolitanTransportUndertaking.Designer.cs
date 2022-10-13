
namespace OperationalStatisticsBook
{
    partial class rptPerformanceMetopolitanTransportUndertaking
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
            this.tbl_PerformanceMetopolitanTransportUndertakingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_PerformanceMetopolitanTransportUndertakingTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_PerformanceMetopolitanTransportUndertakingTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_PerformanceMetopolitanTransportUndertakingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "PerformanceMetopolitanTransportUndertaking";
            reportDataSource1.Value = this.tbl_PerformanceMetopolitanTransportUndertakingBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptPerformanceMetopolitanTransportUndertaking.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 363);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_PerformanceMetopolitanTransportUndertakingBindingSource
            // 
            this.tbl_PerformanceMetopolitanTransportUndertakingBindingSource.DataMember = "tbl_PerformanceMetopolitanTransportUndertaking";
            this.tbl_PerformanceMetopolitanTransportUndertakingBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // tbl_PerformanceMetopolitanTransportUndertakingTableAdapter
            // 
            this.tbl_PerformanceMetopolitanTransportUndertakingTableAdapter.ClearBeforeFill = true;
            // 
            // rptPerformanceMetopolitanTransportUndertaking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 342);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptPerformanceMetopolitanTransportUndertaking";
            this.Text = "rptPerformanceMetopolitanTransportUndertaking";
            this.Load += new System.EventHandler(this.rptPerformanceMetopolitanTransportUndertaking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_PerformanceMetopolitanTransportUndertakingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_PerformanceMetopolitanTransportUndertakingBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_PerformanceMetopolitanTransportUndertakingTableAdapter tbl_PerformanceMetopolitanTransportUndertakingTableAdapter;
    }
}