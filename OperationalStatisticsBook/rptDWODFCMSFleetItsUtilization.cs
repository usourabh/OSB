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
    public partial class rptDWODFCMSFleetItsUtilization : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "0";
        string finYear = "0";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public rptDWODFCMSFleetItsUtilization(int OsbId, int Year, int Month, string finYear, string MonthName)
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
            DataTable dt = Common.ExecuteProcedure("sp_DWODFCMSFleetItsUtilization", param);
            return dt;
        }
        private void rptDWODFCMSFleetItsUtilization_Load(object sender, EventArgs e)
        {
            DataTable dtReportData = GetData();
            ReportDataSource datasource = new ReportDataSource("DWODFCMSFleetItsUtilization", dtReportData);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            this.reportViewer1.RefreshReport();
        }
    }
}
