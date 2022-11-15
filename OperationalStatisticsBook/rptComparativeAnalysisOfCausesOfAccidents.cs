using Microsoft.Reporting.WinForms;
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
    public partial class rptComparativeAnalysisOfCausesOfAccidents : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "0";
        string finYear = "0";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public rptComparativeAnalysisOfCausesOfAccidents(int OsbId, int Year, int Month, string finYear, string MonthName)
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
            DataTable dt = Common.ExecuteProcedure("sp_rptComparativeAnalysisOfCausesOfAccidents", param);
          
            return dt;
        }

        private void rptComparativeAnalysisOfCausesOfAccidents_Load(object sender, EventArgs e)
        {
            var MonthList = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            DateTime currentDate = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate.AddYears(-1);
            string currentYear = currentDate.Year.ToString();
            string previousYear = newDate.Year.ToString();
            String previousMonthName = newDate.ToString("MMMM");
            DataTable dtReportData = GetData();
            ReportDataSource datasource = new ReportDataSource("rptComparativeAnalysisOfCausesOfAccidents", dtReportData);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            ReportParameter[] rptParam = new ReportParameter[3];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList[0].MonthName + "-" + currentYear + " & " + MonthList[0].MonthName + "-" + previousYear);
            rptParam[1] = new ReportParameter("fromDate", MonthList[0].MonthName + "-" + currentYear);
            rptParam[2] = new ReportParameter("ToDate", MonthList[0].MonthName + "-" + previousYear);
            this.reportViewer1.LocalReport.SetParameters(rptParam);
            this.reportViewer1.RefreshReport();

            //this.reportViewer1.RefreshReport();
        }
    }
}
