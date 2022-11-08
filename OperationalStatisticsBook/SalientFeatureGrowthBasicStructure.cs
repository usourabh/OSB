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
    public partial class SalientFeatureGrowthBasicStructure : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);

        public SalientFeatureGrowthBasicStructure(int OsbId, int Year, int Month, string finYear, string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;
        }




        void BindIndexPage(int OsbId)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT [Year],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12] FROM [rpt].[tbl_SalientFeatureGrowthBasicStructure] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    Save.BackColor = Color.Green;
                }
                else
                {
                    dataGridView1.DataSource = BindSalientFeatureGrowthBasicSturucture();
                }
            }
            catch (Exception ex)
            {

            }

        }
        int DeleteExisitingdtRecord(string dtName, int OsbId)
        {
            string strdt = "[rpt].[" + dtName + "]";
            int i = 0;
            SqlCommand cmd = new SqlCommand("delete from " + strdt + " where OsbId=@OsbId", con);
            cmd.Parameters.AddWithValue("@OsbId", OsbId);
            cmd.CommandType = CommandType.Text;
            con.Open();

            i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }

        DataTable BindSalientFeatureGrowthBasicSturucture()
        {


            DataTable table = new DataTable();

            //column name
            table.Columns.Add("Year", typeof(string));
            table.Columns.Add("No of Depots", typeof(string));
            table.Columns.Add(" ", typeof(string));
            table.Columns.Add("Man Power", typeof(string));
            table.Columns.Add("  ", typeof(string));
            table.Columns.Add("Staff Ratio", typeof(string));
            table.Columns.Add("   ", typeof(string));
            table.Columns.Add("Added (Vehicle)", typeof(string));
            table.Columns.Add("    ", typeof(string));
            table.Columns.Add("Deleted (Vehicle)", typeof(string));
            table.Columns.Add("     ", typeof(string));
            table.Columns.Add("Fleet at the end", typeof(string));
            table.Columns.Add("      ", typeof(string));




            //Rows Static Data
            DateTime currentDate = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate.AddYears(1);
            DateTime newDateM = currentDate.AddMonths(+1);
            DateTime newDate2 = currentDate.AddYears(+2);
            DateTime currentMonth = currentDate.AddMonths(-10);

            DateTime newDateCurrent = currentDate.AddYears(+1);
            string currentYear = currentDate.Year.ToString();
            string previousYear = newDateCurrent.Year.ToString();

            DateTime newDateCurrent2 = currentDate.AddYears(-1);
            string previousYear1 = newDateCurrent2.Year.ToString();
            // int j = 1;
            for (int i = 10; i > 0; i--)
            {
                table.Rows.Add(newDate.AddYears(-i).Year + "-" + newDate2.AddYears(-i).Year, 0, " ", 0, " ", 0, " ", 0, " ", 0, " ", 0, " ");
            }

            table.Rows.Add(" ", "No of Depots", "No of Depots", "Man Power", "Man Power", "Staff Ratio", "Staff Ratio", "Added (Vehicle)", "Added (Vehicle)", "Deleted (Vehicle)", "Deleted (Vehicle)", "Fleet at the end", "Fleet at the end");

            table.Rows.Add("Year", previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear);
            for (int i = 6; i > 0; i--)
            {
                table.Rows.Add(currentMonth.AddMonths(-i).ToString("MMMM"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

            }

            table.Rows.Add(" ", "No of Depots", "No of Depots", "Man Power", "Man Power", "Staff Ratio", "Staff Ratio", "Added (Vehicle)", "Added (Vehicle)", "Deleted (Vehicle)", "Deleted (Vehicle)", "Fleet at the end", "Fleet at the end");
            table.Rows.Add("Year", currentYear, previousYear, currentYear, previousYear, currentYear, previousYear, currentYear, previousYear, currentYear, previousYear, currentYear, previousYear);

            for (int i = 7; i > 0; i--)
            {
                table.Rows.Add(newDateM.AddMonths(-i).ToString("MMMM"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            }


            return table;

        }


        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingdtRecord("tbl_SalientFeatureGrowthBasicStructure", OsbId);
            dataGridView1.DataSource = BindSalientFeatureGrowthBasicSturucture();
            MessageBox.Show("Done");
        }



        private void SalientFeatureGrowthBasicStructure_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BindSalientFeatureGrowthBasicSturucture();
            BindIndexPage(OsbId);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            DeleteExisitingdtRecord("tbl_SalientFeatureGrowthBasicStructure", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null || row.Cells[11].Value != null || row.Cells[12].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_SalientFeatureGrowthBasicStructure] ([OsbId],[Year],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12]) VALUES (@OsbId,@Year,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11,@Param12)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@Year", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param6", row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param7", row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param8", row.Cells[8].Value == null ? "" : row.Cells[8].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param9", row.Cells[9].Value == null ? "" : row.Cells[9].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param10", row.Cells[10].Value == null ? "" : row.Cells[10].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param11", row.Cells[11].Value == null ? "" : row.Cells[11].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param12", row.Cells[12].Value == null ? "" : row.Cells[12].Value.ToString());
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

        private void Print_ReportOnCluck(object sender, EventArgs e)
        {
            rptSalientFeatureGrowthBasicStructure objFrm = new rptSalientFeatureGrowthBasicStructure(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }
    }
}
