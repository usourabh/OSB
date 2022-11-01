using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace OperationalStatisticsBook
{
    public partial class frmOSBMain : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);
        public frmOSBMain(int OsbId, int Year, int Month, string finYear,string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;
        }

        private void frmOSBMain_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
        }



        int DeleteExisitingTableRecord(string TableName, int OsbId)
        {
            string strTable = "[rpt].[" + TableName + "]";
            int i = 0;
            SqlCommand cmd = new SqlCommand("delete from " + strTable + " where OsbId=@OsbId", con);
            cmd.Parameters.AddWithValue("@OsbId", OsbId);
            cmd.CommandType = CommandType.Text;
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }



        void BindIndexPage(int OsbId)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("[rpt].[sp_GetIndexPageData]", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                    grdIndexPage.DataSource = dt;
                else
                    grdIndexPage.DataSource = BindMasterData();
            }
            catch (Exception ex)
            {

            }

        }


        void GetFinMaster(string Finyear)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("[rpt].[sp_GetFinYearByFinYear]", con);
                cmd.Parameters.AddWithValue("@FinVal", Finyear);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    GlobalMaster.FinMaster.Add(new FinMasterInfo() { FinId = Convert.ToInt32(dr[0]), FinVal = Convert.ToString(dr[01]), StartDate = Convert.ToDateTime(dr[2]), EndDate = Convert.ToDateTime(dr[3]) });
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void btnupdateIndexPage_Click(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_IndexPage", OsbId);

            foreach (DataGridViewRow row in grdIndexPage.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_IndexPage] ([OsbId],[TableNo],[Description],[PageNo])VALUES(@OsbId,@TableNo,@Description,@PageNo)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@TableNo", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Description", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@PageNo", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception ex)
                {

                }

            }
            MessageBox.Show("Done");
        }


        DataTable BindMasterData()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("TableNo", typeof(string)),
                            new DataColumn("Description", typeof(string)),
                            new DataColumn("PageNo",typeof(string)) });

            dt.Rows.Add("", "Performance of DTC at a glance-", "1");
            dt.Rows.Add("", "Progressive financial results (Rs. in lakh)", "1");
            dt.Rows.Add("", "Fare structure", "1");
            dt.Rows.Add("", "Staff ratio", "2");
            dt.Rows.Add("1.1", "Analysis of causes of accidents (" + GlobalMaster.FinMaster[1].FinVal + " TO " + GlobalMaster.FinMaster[0].FinVal + ")", "2");
            dt.Rows.Add("1.2", "Basic structure growth of DTC", "3");
            dt.Rows.Add("1.3", "Routes operated by D.T.C.", "3");
            dt.Rows.Add("1.4", "Comparative financial results (" + GlobalMaster.FinMaster[2].FinVal + " to " + GlobalMaster.FinMaster[0].FinVal + ")", "4-5");
            dt.Rows.Add("1.5", "Comparative operational data of DTC (" + GlobalMaster.FinMaster[2].FinVal + " to " + GlobalMaster.FinMaster[0].FinVal + ")", "6");
            dt.Rows.Add("1.6", "Distribution of fleet by type/make and year of commission", "7");
            dt.Rows.Add("1.7", "Price and cost indices (" + GlobalMaster.FinMaster[5].FinVal + " to " + GlobalMaster.FinMaster[0].FinVal + ")", "8");
            dt.Rows.Add("1.8", "Material consumption (" + GlobalMaster.FinMaster[2].FinVal + " to " + GlobalMaster.FinMaster[0].FinVal + ")", "8");
            dt.Rows.Add("1.9", "Performance of Metropolitan Transport Undertakings (" + GlobalMaster.FinMaster[5].FinVal + ")", "9");
            dt.Rows.Add("1.1", "Accidents and compensation given to accidents victims (" + GlobalMaster.FinMaster[9].FinVal + " to " + GlobalMaster.FinMaster[0].FinVal + ")", "9");
            dt.Rows.Add("1.11", "Depot wise fleet strength", "10");
            dt.Rows.Add("2", "CATEGORYWISE STAFF POSITION", "11");
            dt.Rows.Add("", "OPERATIONAL RESULTS (CORPORATE LEVEL)", "");
            dt.Rows.Add("3.1", "Routes operated by D.T.C. and its EPK", "12");
            dt.Rows.Add("3.2", "Region wise operational data", "13");
            dt.Rows.Add("3.3", "Monthly operational data", "14-15");
            dt.Rows.Add("", "Operational data (Non AC & AC Low floor buses Total DTC)", "");
            dt.Rows.Add("4.1", "Fleet and its utilisation.", "16-17");
            dt.Rows.Add("4.2", "Trips scheduled,operated and Breakdowns", "18-19");
            dt.Rows.Add("4.3", "Analysis of Kilometers", "20-21");
            dt.Rows.Add("4.4", "Traffic income", "22-23");
            dt.Rows.Add("4.5", "Accident analysis", "24-25");
            dt.Rows.Add("4.6", "Depot wise operational data (Non AC & AC Low floor Total DTC)", "26");
            dt.Rows.Add("4.7", "Trips operated on time and  within two minutes.", "27");
            dt.Rows.Add("", "Operational data (Non AC & AC  buses Total PO)", "");
            dt.Rows.Add("4.1A", "Fleet and its utilisation.", "28-29");
            dt.Rows.Add("4.2A", "Trips scheduled,operated and Breakdowns", "30-31");
            dt.Rows.Add("4.3A", "Analysis of Kilometers", "32-33");
            dt.Rows.Add("4.4A", "Traffic income", "34-35");
            dt.Rows.Add("4.5A", "Accident analysis", "36-37");
            dt.Rows.Add("4.8", "Depot wise total missed KMS and breakdowns", "38");
            dt.Rows.Add("4.8A", "Depot wise total missed KMS and breakdowns", "39");
            dt.Rows.Add("", "MISCELLANEOUS STATISTICS", "");
            dt.Rows.Add("5.1", "Category wise sale of passes", "40-41");
            dt.Rows.Add("5.2", "Statement of depot wise school buses ,special Hire, tourist bus, Passes & Pink tickets earnings DTC", "42-43");
            dt.Rows.Add("5.2A", "Statement of  depot wise  Passes & Pink tickets earnings PO", "44");
            dt.Rows.Add("", "ACCIDENT ANALYSIS", "");
            dt.Rows.Add("6.1", "Analysis of causes of accidents.", "45");
            dt.Rows.Add("6.2", "Other party involvement in Accidents", "45");
            dt.Rows.Add("6.3", "Analysis of accidents by drivers (age-group)", "45");
            dt.Rows.Add("7.1-7.2", "Depot wise operational data of FCMS (Cluster buses)", "46");
            dt.Rows.Add("", "Traffic Earning PAI  & Expenditure PAI", "47");
            dt.Rows.Add("", "Comparison of fleet utilization, operational ratio & Kms. efficiency graphs", "48");
            dt.Rows.Add("", "Comparison of traffic earning, earning per bus per day & No. of passengers carried", "49");
            dt.Rows.Add("8", "Statement showing figures of Income & Expenditure", "50-53");

            return dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_IndexPage", OsbId);
            grdIndexPage.DataSource = BindMasterData();
            MessageBox.Show("Done");
        }

        private void grdIndexPage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OnClickPrintReport(object sender, EventArgs e)
        {
            rptIndexPrint objFrm = new rptIndexPrint(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }
    }
}
