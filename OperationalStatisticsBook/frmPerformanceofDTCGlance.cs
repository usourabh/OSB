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

namespace OperationalStatisticsBook
{
    public partial class frmPerformanceofDTCGlance : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);

        public frmPerformanceofDTCGlance(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [PhysicalParameter],[Param1],[Param2],[Param3],[Param4] ,[Param5] FROM [rpt].[tbl_PerformanceDTCGlance] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);


                DataTable autoSpTable = new DataTable();
                SqlCommand cmd1 = new SqlCommand("[dbo].[PerformanceOfDTCGlanceOSB]", con);
                cmd1.Parameters.AddWithValue("@month", Month);
                cmd1.Parameters.AddWithValue("@year", Year);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 350;
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(autoSpTable);

                if (dt.Rows.Count > 0)
                {
                    grdIndexPage.DataSource = dt;
                    btnupdateIndexPage.BackColor = Color.Green;
                }

                else if (autoSpTable.Rows.Count > 0)
                {
                    grdIndexPage.DataSource = BindMasterData_AutoSpTable(autoSpTable);
                }

                else
                {
                    grdIndexPage.DataSource = BindMasterData();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void btnupdateIndexPage_Click(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_PerformanceDTCGlance", OsbId);

            foreach (DataGridViewRow row in grdIndexPage.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_PerformanceDTCGlance] ([OsbId],[PhysicalParameter],[Param1],[Param2],[Param3],[Param4],[Param5]) VALUES (@OsbId,@PhysicalParameter,@Param1,@Param2,@Param3,@Param4,@Param5)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@PhysicalParameter", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
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
            var MonthList = GlobalMaster.GetPrevousMonthList(Month, Year, 5);


            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("PhysicalParameter", typeof(string)),
                            new DataColumn("Param1", typeof(string)),
                            new DataColumn("Param2",typeof(string)),
                            new DataColumn("Param3",typeof(string)),
                            new DataColumn("Param4",typeof(string)),
                            new DataColumn("Param5",typeof(string))
            });

            //dt.Rows.Add("Physical Parameter", MonthList[4].MonthName + "-" + MonthList[4].Year, MonthList[3].MonthName + "-" + MonthList[3].Year, MonthList[2].MonthName + "-" + MonthList[2].Year, MonthList[1].MonthName + "-" + MonthList[1].Year, MonthList[0].MonthName + "-" + MonthList[0].Year );

            dt.Rows.Add("No. of Depots", "", "", "", "", "");
            dt.Rows.Add("Fleet Held (on last day)", "", "", "", "", "");
            dt.Rows.Add("- Non-AC Low Floor", "", "", "", "", "");
            dt.Rows.Add("- AC Low Floor", "", "", "", "", "");
            dt.Rows.Add("- AC Electric Low Floor", "", "", "", "", "");
            dt.Rows.Add("- Total", "", "", "", "", "");
            dt.Rows.Add("Trips Operated / day (in Lacs)", "", "", "", "", "");
            dt.Rows.Add("KMs Operated / day (in Lacs)", "", "", "", "", "");
            dt.Rows.Add("Passengers Carried / day (in Lacs)", "", "", "", "", "");
            dt.Rows.Add("Total number of routes (city)", "", "", "", "", "");
            dt.Rows.Add("Average route length (Kms)", "", "", "", "", "");
            dt.Rows.Add("Staff Strength (including contractual)", "", "", "", "", "");
            dt.Rows.Add("Daily Earning (Rs in Cr)", "", "", "", "", "");
            dt.Rows.Add("Earning Per Kms (Rs.)", "", "", "", "", "");
            dt.Rows.Add("Earning Per bus Per Day (Rs.)", "", "", "", "", "");
            return dt;


        }

        DataTable BindMasterData_AutoSpTable(DataTable sp)
        {
            var MonthList = GlobalMaster.GetPrevousMonthList(Month, Year, 5);


            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("PhysicalParameter", typeof(string)),
                            new DataColumn("Param1", typeof(string)),
                            new DataColumn("Param2",typeof(string)),
                            new DataColumn("Param3",typeof(string)),
                            new DataColumn("Param4",typeof(string)),
                            new DataColumn("Param5",typeof(string))
            });

            //dt.Rows.Add("Physical Parameter", MonthList[4].MonthName + "-" + MonthList[4].Year, MonthList[3].MonthName + "-" + MonthList[3].Year, MonthList[2].MonthName + "-" + MonthList[2].Year, MonthList[1].MonthName + "-" + MonthList[1].Year, MonthList[0].MonthName + "-" + MonthList[0].Year );
            int totalOfMonth5 = Convert.ToInt32(sp.Rows[1]["param1"]) + Convert.ToInt32(sp.Rows[2]["param1"]) + Convert.ToInt32(sp.Rows[3]["param1"]);
            int totalOfMonth4 = Convert.ToInt32(sp.Rows[1]["param2"]) + Convert.ToInt32(sp.Rows[2]["param2"]) + Convert.ToInt32(sp.Rows[3]["param2"]);
            int totalOfMonth3 = Convert.ToInt32(sp.Rows[1]["param3"]) + Convert.ToInt32(sp.Rows[2]["param3"]) + Convert.ToInt32(sp.Rows[3]["param3"]);
            int totalOfMonth2 = Convert.ToInt32(sp.Rows[1]["param4"]) + Convert.ToInt32(sp.Rows[2]["param4"]) + Convert.ToInt32(sp.Rows[3]["param4"]);
            int totalOfMonth1 = Convert.ToInt32(sp.Rows[1]["param5"]) + Convert.ToInt32(sp.Rows[2]["param5"]) + Convert.ToInt32(sp.Rows[3]["param5"]);


            dt.Rows.Add(sp.Rows[0]["PhysicalParameter"], sp.Rows[0]["param1"], sp.Rows[0]["param2"], sp.Rows[0]["param3"], sp.Rows[0]["param4"], sp.Rows[0]["param5"]);
            dt.Rows.Add("Fleet Held (on last day)", "", "", "", "", "");

            dt.Rows.Add(sp.Rows[1]["PhysicalParameter"], sp.Rows[1]["param1"], sp.Rows[1]["param2"], sp.Rows[1]["param3"], sp.Rows[1]["param4"], sp.Rows[1]["param5"]);
            dt.Rows.Add(sp.Rows[2]["PhysicalParameter"], sp.Rows[2]["param1"], sp.Rows[2]["param2"], sp.Rows[2]["param3"], sp.Rows[2]["param4"], sp.Rows[2]["param5"]);
            dt.Rows.Add(sp.Rows[3]["PhysicalParameter"], sp.Rows[3]["param1"], sp.Rows[3]["param2"], sp.Rows[3]["param3"], sp.Rows[3]["param4"], sp.Rows[3]["param5"]);

            dt.Rows.Add(sp.Rows[4]["PhysicalParameter"], Convert.ToString(totalOfMonth5), Convert.ToString(totalOfMonth4), Convert.ToString(totalOfMonth3), Convert.ToString(totalOfMonth2), Convert.ToString(totalOfMonth1));

            dt.Rows.Add(sp.Rows[5]["PhysicalParameter"], sp.Rows[5]["param1"], sp.Rows[5]["param2"], sp.Rows[5]["param3"], sp.Rows[5]["param4"], sp.Rows[5]["param5"]);
            dt.Rows.Add(sp.Rows[6]["PhysicalParameter"], sp.Rows[6]["param1"], sp.Rows[6]["param2"], sp.Rows[6]["param3"], sp.Rows[6]["param4"], sp.Rows[6]["param5"]);
            dt.Rows.Add(sp.Rows[7]["PhysicalParameter"], sp.Rows[7]["param1"], sp.Rows[7]["param2"], sp.Rows[7]["param3"], sp.Rows[7]["param4"], sp.Rows[7]["param5"]);
            dt.Rows.Add(sp.Rows[8]["PhysicalParameter"], sp.Rows[8]["param1"], sp.Rows[8]["param2"], sp.Rows[8]["param3"], sp.Rows[8]["param4"], sp.Rows[8]["param5"]);
            dt.Rows.Add(sp.Rows[9]["PhysicalParameter"], sp.Rows[9]["param1"], sp.Rows[9]["param2"], sp.Rows[9]["param3"], sp.Rows[9]["param4"], sp.Rows[9]["param5"]);
            dt.Rows.Add(sp.Rows[10]["PhysicalParameter"], sp.Rows[10]["param1"], sp.Rows[10]["param2"], sp.Rows[10]["param3"], sp.Rows[10]["param4"], sp.Rows[10]["param5"]);
            dt.Rows.Add(sp.Rows[11]["PhysicalParameter"], sp.Rows[11]["param1"], sp.Rows[11]["param2"], sp.Rows[11]["param3"], sp.Rows[11]["param4"], sp.Rows[11]["param5"]);
            dt.Rows.Add(sp.Rows[12]["PhysicalParameter"], sp.Rows[12]["param1"], sp.Rows[12]["param2"], sp.Rows[12]["param3"], sp.Rows[12]["param4"], sp.Rows[12]["param5"]);
            dt.Rows.Add(sp.Rows[13]["PhysicalParameter"], sp.Rows[13]["param1"], sp.Rows[13]["param2"], sp.Rows[13]["param3"], sp.Rows[13]["param4"], sp.Rows[13]["param5"]);
            return dt;


        }


        private void button1_Click(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_PerformanceDTCGlance", OsbId);
            grdIndexPage.DataSource = BindMasterData();
            MessageBox.Show("Done");
        }

        private void grdIndexPage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Print_ReportOnClick(object sender, EventArgs e)
        {
            rptfrmPerformanceofDTCGlance objFrm = new rptfrmPerformanceofDTCGlance(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }
    }
}
