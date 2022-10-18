
namespace OperationalStatisticsBook
{
    partial class rptDetailsofOperationaldata
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
            this.tbl_DetailsofOperationaldataforthemonthofJulyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtcoperationDataSet = new OperationalStatisticsBook.dtcoperationDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbl_DetailsofOperationaldataforthemonthofJulyTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_DetailsofOperationaldataforthemonthofJulyTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DetailsofOperationaldataforthemonthofJulyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_DetailsofOperationaldataforthemonthofJulyBindingSource
            // 
            this.tbl_DetailsofOperationaldataforthemonthofJulyBindingSource.DataMember = "tbl_DetailsofOperationaldataforthemonthofJuly";
            this.tbl_DetailsofOperationaldataforthemonthofJulyBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DetailsofOperationaldata";
            reportDataSource1.Value = this.tbl_DetailsofOperationaldataforthemonthofJulyBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptDetailsofOperationaldata.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbl_DetailsofOperationaldataforthemonthofJulyTableAdapter
            // 
            this.tbl_DetailsofOperationaldataforthemonthofJulyTableAdapter.ClearBeforeFill = true;
            // 
            // rptDetailsofOperationaldata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptDetailsofOperationaldata";
            this.Text = "rptDetailsofOperationaldata";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptDetailsofOperationaldata_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DetailsofOperationaldataforthemonthofJulyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_DetailsofOperationaldataforthemonthofJulyBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_DetailsofOperationaldataforthemonthofJulyTableAdapter tbl_DetailsofOperationaldataforthemonthofJulyTableAdapter;
    }
}