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
    public partial class RoutesOperatedByDtc : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);
        public RoutesOperatedByDtc(int OsbId, int Year, int Month, string finYear, string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;
        }
        DataTable BindRoutesOperatedByDtc()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Year", typeof(string));
            table.Columns.Add("No of routes at the end of the Period", typeof(string));
            table.Columns.Add("No of routes at the end of the Period ", typeof(string));
            table.Columns.Add("No of routes at the end of  the Period ", typeof(string));
            table.Columns.Add("No of routes at  the end of the Period ", typeof(string));
            table.Columns.Add("Route KMs  at the end of the period", typeof(string));
            table.Columns.Add("Route KMs at the end of  the period ", typeof(string));
            table.Columns.Add("Route KMs at the   end of the period ", typeof(string));
            table.Columns.Add("Route KMs at the  end of the period ", typeof(string));
            table.Columns.Add("Average Route length", typeof(string));
            table.Columns.Add("Average  Route length ", typeof(string));
            table.Columns.Add("Average   Route   length ", typeof(string));
            table.Columns.Add("Average Route  length ", typeof(string));
            DateTime currentDate = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate.AddYears(1);
            DateTime newDateM = currentDate.AddMonths(+1);
            DateTime newDate2 = currentDate.AddYears(+2);
            DateTime currentMonth = currentDate.AddMonths(-6);
            DateTime newDateCurrent = currentDate.AddYears(+1);
            string currentYear = currentDate.Year.ToString();
            string previousYear = newDateCurrent.Year.ToString();
            DateTime newDateCurrent2 = currentDate.AddYears(-1);
            string previousYear1 = newDateCurrent2.Year.ToString();
            table.Rows.Add("", "City", "City", "NCR", "NCR", "City", "City", "NCR", "NCR", "City", "City", "NCR", "NCR");
            table.Rows.Add("1", "2", "2", "3", "3", "4", "4", "5", "5", "6", "6", "7", "7");

            for (int i = 10; i > 0; i--)
            {
                table.Rows.Add(newDate.AddYears(-i).Year + "-" + newDate2.AddYears(-i).Year, " 0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            }

            table.Rows.Add("", " No.of routes at the end of the period", "No.of routes at the end of the period", "No.of routes at the end of the period", "No.of routes at the end of the period", "Route KMs at the end of the period", "Route KMs at the end of the period", "Route KMs at the end of the period", "Route KMs at the end of the period", "Average route length", "Average route length", "Average route length", "Average route length");

            table.Rows.Add("", " City ", "City ", "NCR", "NCR", "City", "City", "NCR", "NCR", "City", "City", "NCR", "NCR");


            table.Rows.Add("Year", previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear);
            for (int i = 6; i > 0; i--)
            {
                table.Rows.Add(currentMonth.AddMonths(-i).ToString("MMMM"), " 0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            }

            table.Rows.Add("", " City ", "City ", "NCR", "NCR", "City", "City", "NCR", "NCR", "City", "City", "NCR", "NCR");


            table.Rows.Add("Year", currentYear, previousYear, currentYear, previousYear, currentYear, previousYear, currentYear, previousYear, currentYear, previousYear, currentYear, previousYear);

            for (int i = 11; i > 0; i--)
            {
                table.Rows.Add(newDateM.AddMonths(-i).ToString("MMMM"), " 0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            }


            return table;

        }
        private void ResetOnClick(object sender, EventArgs e)
        {

            dataGridView1.DataSource = BindRoutesOperatedByDtc();
            //DeleteExisitingTableRecord("tbl_RoutesOperatedByDtc", OsbId);
            MessageBox.Show("Done");
        }

        void BindIndexPage(int OsbId)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT [Year],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12] FROM [rpt].[tbl_RoutesOperatedByDtc] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                    dataGridView1.DataSource = dt;
                else
                    dataGridView1.DataSource = BindRoutesOperatedByDtc();
            }
            catch (Exception ex)
            {

            }

        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_RoutesOperatedByDtc", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null || row.Cells[11].Value != null || row.Cells[12].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_RoutesOperatedByDtc] ([OsbId],[Year],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12]) VALUES (@OsbId,@Year,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11,@Param12)", con);
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

        private void RoutesOperatedByDtc_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
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

        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptRoutesOperatedByDtc objFrm = new rptRoutesOperatedByDtc(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }
    }
}
