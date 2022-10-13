
namespace OperationalStatisticsBook
{
    partial class rptMaterialConsumptionFinancial
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
            this.tbl_MaterialConsumptionFromBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_MaterialConsumptionFromTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_MaterialConsumptionFromTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_MaterialConsumptionFromBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "MaterialConsumptionFinancial";
            reportDataSource1.Value = this.tbl_MaterialConsumptionFromBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptMaterialConsumptionFinancial.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 5);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 294);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_MaterialConsumptionFromBindingSource
            // 
            this.tbl_MaterialConsumptionFromBindingSource.DataMember = "tbl_MaterialConsumptionFrom";
            this.tbl_MaterialConsumptionFromBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // tbl_MaterialConsumptionFromTableAdapter
            // 
            this.tbl_MaterialConsumptionFromTableAdapter.ClearBeforeFill = true;
            // 
            // rptMaterialConsumptionFinancial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptMaterialConsumptionFinancial";
            this.Text = "rptMaterialConsumptionFinancial";
            this.Load += new System.EventHandler(this.rptMaterialConsumptionFinancial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_MaterialConsumptionFromBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_MaterialConsumptionFromBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_MaterialConsumptionFromTableAdapter tbl_MaterialConsumptionFromTableAdapter;
    }
}