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
    public partial class rptComparativeFinancialResultsFrom : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "0";
        string finYear = "0";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public rptComparativeFinancialResultsFrom(int OsbId, int Year, int Month, string finYear, string MonthName)
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
            DataTable dt = Common.ExecuteProcedure("sp_rptComparativeFinancialResultsFrom", param);
            return dt;
        }

        private void rptComparativeFinancialResultsFrom_Load(object sender, EventArgs e)
        {
            DataTable dtReportData = GetData();
            ReportDataSource datasource = new ReportDataSource("rptComparativeFinancialResultsFrom", dtReportData);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            ReportParameter[] rptParam = new ReportParameter[4];
            rptParam[0] = new ReportParameter("ReportTitle", "Comparative Financial Results form (Rs " + GlobalMaster.FinMaster[2].FinVal + " to " + GlobalMaster.FinMaster[0].FinVal + " in lakh)");
            rptParam[1] = new ReportParameter("txtDate1",  GlobalMaster.FinMaster[2].FinVal );
            rptParam[2] = new ReportParameter("txtDate2",  GlobalMaster.FinMaster[1].FinVal );
            rptParam[3] = new ReportParameter("txtDate3",  GlobalMaster.FinMaster[0].FinVal );
            this.reportViewer1.LocalReport.SetParameters(rptParam);
            this.reportViewer1.RefreshReport();
        }
    }
}
