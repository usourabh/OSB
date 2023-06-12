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
    public partial class rptMaterialConsumptionFinancial : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "0";
        string finYear = "0";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public rptMaterialConsumptionFinancial(int OsbId, int Year, int Month, string finYear, string MonthName)
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
            if (finYear == "2023-24")
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select S_No, ITEM, UNIT, Param1, Param2, Param3 From [rpt].tbl_MaterialConsumptionFrom where OsbId = @OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", 132);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
            else if (finYear == "2022-23")
            {

                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select S_No, ITEM, UNIT, Param1, Param2, Param3 From [rpt].tbl_MaterialConsumptionFrom where OsbId = @OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", 5);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
            else
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select S_No, ITEM, UNIT, Param1, Param2, Param3 From [rpt].tbl_MaterialConsumptionFrom where OsbId = @OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId.ToString());
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
            //String[,] param = new string[,]
            //{
            //{"@OsbId",OsbId.ToString()},
            //};
            //DataTable dt = Common.ExecuteProcedure("sp_rptMaterialConsumptionFrom", param);
            //return dt;
        }

        private void rptMaterialConsumptionFinancial_Load(object sender, EventArgs e)
        {


            DataTable dtReportData = GetData();
            ReportDataSource datasource = new ReportDataSource("MaterialConsumptionFinancial", dtReportData);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            ReportParameter[] rptParam = new ReportParameter[4];
            rptParam[0] = new ReportParameter("ReportTitle", GlobalMaster.FinMaster[3].FinVal + " to " + GlobalMaster.FinMaster[1].FinVal);
            rptParam[1] = new ReportParameter("txtDate1", GlobalMaster.FinMaster[3].FinVal);
            rptParam[2] = new ReportParameter("txtDate2", GlobalMaster.FinMaster[2].FinVal);
            rptParam[3] = new ReportParameter("txtDate3", GlobalMaster.FinMaster[1].FinVal);
            this.reportViewer1.LocalReport.SetParameters(rptParam);

            this.reportViewer1.RefreshReport();
        }
    }
}
