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
    public partial class rptStaffRatioAsOn : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "0";
        string finYear = "0";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public rptStaffRatioAsOn(int OsbId, int Year, int Month, string finYear, string MonthName)
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
            

            DateTime currentDate = new DateTime(Year, Month, 01);
            String[,] param = new string[,]
                {
                    { "@OsbId",OsbId.ToString()},
                 //  { "@Month",Month.ToString()},
                   
                };
             DataTable dt = Common.ExecuteProcedure("sp_rptStaffRatioAsOn", param);
            // DataTable dt = Common.ExecuteProcedure("sp_GetStaffRatioDetails", param);

            return dt;
        }

        private void rptStaffRatioAsOn_Load(object sender, EventArgs e)
        {
            var MonthList = GlobalMaster.GetPrevousMonthList(Month, Year, 5);
            DataTable dtReportData = GetData();
            ReportDataSource datasource = new ReportDataSource("rptStaffRatioAsOn", dtReportData);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);

            DateTime currentDate = new DateTime(Year, Month, 01);
            int lastDayofTheMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            string lastDateForDistributionFleet = lastDayofTheMonth + "-" + currentDate.Month + "-" + currentDate.Year;

            ReportParameter[] rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", lastDayofTheMonth + "-"+ MonthList[0].MonthName + "-" + MonthList[1].Year);
            this.reportViewer1.LocalReport.SetParameters(rptParam);
            this.reportViewer1.RefreshReport();
        }
    }
}
