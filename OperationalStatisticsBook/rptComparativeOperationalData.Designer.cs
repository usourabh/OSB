
namespace OperationalStatisticsBook
{
    partial class rptComparativeOperationalData
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
            this.rptTbl_ComparativeOperationalDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptTbl_ComparativeOperationalDataTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.rptTbl_ComparativeOperationalDataTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptTbl_ComparativeOperationalDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "rptComparativeOperationalData";
            reportDataSource1.Value = this.rptTbl_ComparativeOperationalDataBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptComparativeOperationalData.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rptTbl_ComparativeOperationalDataBindingSource
            // 
            this.rptTbl_ComparativeOperationalDataBindingSource.DataMember = "rptTbl_ComparativeOperationalData";
            this.rptTbl_ComparativeOperationalDataBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // rptTbl_ComparativeOperationalDataTableAdapter
            // 
            this.rptTbl_ComparativeOperationalDataTableAdapter.ClearBeforeFill = true;
            // 
            // rptComparativeOperationalData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptComparativeOperationalData";
            this.Text = "rptComparativeOperationalData";
            this.Load += new System.EventHandler(this.rptComparativeOperationalData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptTbl_ComparativeOperationalDataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource rptTbl_ComparativeOperationalDataBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.rptTbl_ComparativeOperationalDataTableAdapter rptTbl_ComparativeOperationalDataTableAdapter;
    }
}