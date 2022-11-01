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
    public partial class rptfrmPerformanceofDTCGlance : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public rptfrmPerformanceofDTCGlance(int OsbId, int Year, int Month, string finYear, string MonthName)
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
            DataTable dt = Common.ExecuteProcedure("sp_rptfrmPerformanceofDTCGlance", param);
            return dt;
        }

        private void rptfrmPerformanceofDTCGlance_Load(object sender, EventArgs e)
        {
            var MonthList = GlobalMaster.GetPrevousMonthList(Month, Year, 5);
            DataTable dtReportData = GetData();
            ReportDataSource datasource = new ReportDataSource("rptfrmPerformanceofDTCGlance", dtReportData);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            ReportParameter[] rptParam = new ReportParameter[5];
            rptParam[0] = new ReportParameter("txtDate1", MonthList[4].MonthName + "-" + MonthList[4].Year);
            rptParam[1] = new ReportParameter("txtDate2", MonthList[3].MonthName + "-" + MonthList[3].Year);
            rptParam[2] = new ReportParameter("txtDate3", MonthList[2].MonthName + "-" + MonthList[2].Year);
            rptParam[3] = new ReportParameter("txtDate4", MonthList[1].MonthName + "-" + MonthList[1].Year);
            rptParam[4] = new ReportParameter("txtDate5", MonthList[0].MonthName + "-" + MonthList[0].Year);
            this.reportViewer1.LocalReport.SetParameters(rptParam);
            this.reportViewer1.RefreshReport();
        }
    }
}
