
namespace OperationalStatisticsBook
{
    partial class rptDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization
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
            this.tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillizationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtcoperationDataSet = new OperationalStatisticsBook.dtcoperationDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillizationTableAdapter = new OperationalStatisticsBook.dtcoperationDataSetTableAdapters.tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillizationTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillizationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillizationBindingSource
            // 
            this.tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillizationBindingSource.DataMember = "tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanu" +
    "ary2021FleetItsUtillization";
            this.tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillizationBindingSource.DataSource = this.dtcoperationDataSet;
            // 
            // dtcoperationDataSet
            // 
            this.dtcoperationDataSet.DataSetName = "dtcoperationDataSet";
            this.dtcoperationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "rptDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanua" +
    "ry2021FleetItsUtillization";
            reportDataSource1.Value = this.tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillizationBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OperationalStatisticsBook.rptDepotWiseOprationalDataRespectNonALowFloorCityNCRSer" +
    "viceOnlyForTheMonthOfJanuary2021FleetItsUtillization.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(801, 449);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillizationTableAdapter
            // 
            this.tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillizationTableAdapter.ClearBeforeFill = true;
            // 
            // rptDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanua" +
    "ry2021FleetItsUtillization";
            this.Text = "rptDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanua" +
    "ry2021FleetItsUtillization";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillizationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcoperationDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillizationBindingSource;
        private dtcoperationDataSet dtcoperationDataSet;
        private dtcoperationDataSetTableAdapters.tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillizationTableAdapter tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillizationTableAdapter;
    }
}