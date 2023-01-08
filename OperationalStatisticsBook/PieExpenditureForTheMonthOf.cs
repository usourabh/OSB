using Microsoft.Reporting.WinForms;
using OperationalStatisticsBook;
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

namespace WindowsFormsApp1
{
    public partial class PieExpenditureForTheMonthOf : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "0";
        string finYear = "0";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public PieExpenditureForTheMonthOf(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                 {"@OsbId",OsbId.ToString().Trim()},

                };
            DataTable dt = Common.ExecuteProcedure("sp_PieChartExpenditureForTheMonth", param);
            return dt;
        }


        private void PieExpenditureForTheMonthOf_Load(object sender, EventArgs e)
        {

            var MonthList = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            DataTable dtReportData = GetData();
            ReportDataSource datasource = new ReportDataSource("ExpenditureOfTheMonth", dtReportData);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            ReportParameter[] rptParam = new ReportParameter[1];
            //  rptParam[0] = new ReportParameter("ReportTitle", MonthList[1].MonthName + "-" + MonthList[1].Year + " to " + MonthList[0].MonthName + "-" + MonthList[0].Year);
            rptParam[0] = new ReportParameter("ReportTitle", MonthList[1].MonthName + "-" + MonthList[0].Year);
            this.reportViewer1.LocalReport.SetParameters(rptParam);
            this.reportViewer1.RefreshReport();
        }
    }
}
