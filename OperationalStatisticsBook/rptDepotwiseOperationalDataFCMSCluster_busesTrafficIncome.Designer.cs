
namespace OperationalStatisticsBook
{
    partial class rptDepotwiseOperationalDataFCMSCluster_busesTrafficIncome
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
            this.tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncomeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtcoperationDataSet = new OperationalStatisticsBook.dtcoperationDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncomeTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncomeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncomeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncomeBindingSource
            // 
            this.tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncomeBindingSource.DataMember = "tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncome";
            this.tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncomeBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "rptDepotwiseOperationalDataFCMSCluster_busesTrafficIncome";
            reportDataSource1.Value = this.tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncomeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptDepotwiseOperationalDataFCMSCluster_busesTrafficInco" +
    "me.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(804, 594);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncomeTableAdapter
            // 
            this.tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncomeTableAdapter.ClearBeforeFill = true;
            // 
            // rptDepotwiseOperationalDataFCMSCluster_busesTrafficIncome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 594);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptDepotwiseOperationalDataFCMSCluster_busesTrafficIncome";
            this.Text = "rptDepotwiseOperationalDataFCMSCluster_busesTrafficIncome";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptDepotwiseOperationalDataFCMSCluster_busesTrafficIncome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncomeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncomeBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncomeTableAdapter tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncomeTableAdapter;
    }
}