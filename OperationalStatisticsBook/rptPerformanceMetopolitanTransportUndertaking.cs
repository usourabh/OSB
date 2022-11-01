﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperationalStatisticsBook
{
    public partial class rptPerformanceMetopolitanTransportUndertaking : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "0";
        string finYear = "0";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public rptPerformanceMetopolitanTransportUndertaking(int OsbId, int Year, int Month, string finYear, string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;

        }

        public DataTable GetData()
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_PerformanceMetopolitanTransportUndertaking", param);
            return dt;
        }

        private void rptPerformanceMetopolitanTransportUndertaking_Load(object sender, EventArgs e)
        {
            DataTable dtReportData = GetData();
            ReportDataSource datasource = new ReportDataSource("PerformanceMetopolitanTransportUndertaking", dtReportData);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            ReportParameter[] rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", " (" + GlobalMaster.FinMaster[5].FinVal + ")");
            this.reportViewer1.LocalReport.SetParameters(rptParam);
            this.reportViewer1.RefreshReport();
        }
    }
}
