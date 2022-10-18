
namespace OperationalStatisticsBook
{
    partial class rptDepotWiseOprationalDataInRespectOfNonAC
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
            this.tbl_DepotWiseOprationalDataInRespectOfNonACNACBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtcoperationDataSet = new OperationalStatisticsBook.dtcoperationDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbl_DepotWiseOprationalDataInRespectOfNonACNACTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_DepotWiseOprationalDataInRespectOfNonACNACTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DepotWiseOprationalDataInRespectOfNonACNACBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_DepotWiseOprationalDataInRespectOfNonACNACBindingSource
            // 
            this.tbl_DepotWiseOprationalDataInRespectOfNonACNACBindingSource.DataMember = "tbl_DepotWiseOprationalDataInRespectOfNonACNAC";
            this.tbl_DepotWiseOprationalDataInRespectOfNonACNACBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "rptDepotWiseOprationalDataInRespectOfNonAC";
            reportDataSource1.Value = this.tbl_DepotWiseOprationalDataInRespectOfNonACNACBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptDepotWiseOprationalDataInRespectOfNonAC.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbl_DepotWiseOprationalDataInRespectOfNonACNACTableAdapter
            // 
            this.tbl_DepotWiseOprationalDataInRespectOfNonACNACTableAdapter.ClearBeforeFill = true;
            // 
            // rptDepotWiseOprationalDataInRespectOfNonAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptDepotWiseOprationalDataInRespectOfNonAC";
            this.Text = "rptDepotWiseOprationalDataInRespectOfNonAC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptDepotWiseOprationalDataInRespectOfNonAC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DepotWiseOprationalDataInRespectOfNonACNACBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_DepotWiseOprationalDataInRespectOfNonACNACBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_DepotWiseOprationalDataInRespectOfNonACNACTableAdapter tbl_DepotWiseOprationalDataInRespectOfNonACNACTableAdapter;
    }
}