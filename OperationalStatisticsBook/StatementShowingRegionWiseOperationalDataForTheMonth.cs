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
    public partial class StatementShowingRegionWiseOperationalDataForTheMonth : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "0";
        string finYear = "0";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public StatementShowingRegionWiseOperationalDataForTheMonth(int OsbId, int Year, int Month, string finYear, string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;
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
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7] FROM [rpt].[tbl_StatementShowingRegionWiseOperationalDataForTheMonth] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                    dataGridView1.DataSource = dt;
                else
                    dataGridView1.DataSource = BindStatementShowingRegionWiseOperationalDataForTheMonth();
            }
            catch (Exception ex)
            {

            }

        }

        DataTable BindStatementShowingRegionWiseOperationalDataForTheMonth()
        {
            DataTable table = new DataTable();

            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("DTC", typeof(string));
            table.Columns.Add("DTC ", typeof(string));
            table.Columns.Add("DTC  ", typeof(string));
            table.Columns.Add("DTC   ", typeof(string));
            table.Columns.Add("DTC    ", typeof(string));
            table.Columns.Add("DTC     ", typeof(string));
       

            // Rows
          
            table.Rows.Add("", "", "Unit", "North", "South", "East", "West", "Total DTC");
            table.Rows.Add("1", "2", "3", "4", "5", "6", "7","8");
            table.Rows.Add("1", "Total Fleet as on last day", "Number", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Avg. Fleet", "Number", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Avg.No of Buses Scheduled", "Number", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Schedule Ratio", "%", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Avg. No of buses on road", "Number", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "Fleet Utilization", "%", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "Trips Scheduled Daily", "Number", "0", "0", "0", "0", "0");
            table.Rows.Add("8", "Trips Operated Daily", "Number", "0", "0", "0", "0", "0");
            table.Rows.Add("9", "Trips Missed Daily", "Number", "0", "0", "0", "0", "0");
            table.Rows.Add("10", "Operational Ratio", "%", "0", "0", "0", "0", "0");
            table.Rows.Add("11", "Scheduled Kms.", "Lakh", "0", "0", "0", "0", "0");
            table.Rows.Add("12", "Operated Kms.", "Lakh", "0", "0", "0", "0", "0");
            table.Rows.Add("13", "Missed Kms.", "Lakh", "0", "0", "0", "0", "0");
            table.Rows.Add("14", "K.M Efficiency", "%", "0", "0", "0", "0", "0");
            table.Rows.Add("15", "Kms Operated Daily", "Lakh", "0", "0", "0", "0", "0");
            table.Rows.Add("16", "Vehicle Utilisation", "", "", "", "", "", "");
            table.Rows.Add("(a)", "Avg Buses on Road Kms/Bus/Day", "No", "0", "0", "0", "0", "0");
            table.Rows.Add("(b)", "Avg Fleet held Kms/Bus/Day", "No", "0", "0", "0", "0", "0");
            table.Rows.Add("17", "Gross Kms.(Including Dead Kms.)", "Lakhs", "0", "0", "0", "0", "0");
            table.Rows.Add("18", "Monthly Earning", "", "", "", "", "", "");
            table.Rows.Add("(a)", "Tickets", "Rs-In-Lakh", "0", "0", "0", "0", "0");
            table.Rows.Add("(b)", "Pink Tickets", "Rs-In-Lakh", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total Tickets", "Rs-In-Lakh", "0", "0", "0", "0", "0");
            table.Rows.Add("(c)", "Others Spl.hire,tourist & passes etc.", "Rs-In-Lakh", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Grand Total", "Rs-In-Lakh", "0", "0", "0", "0", "0");
            table.Rows.Add("19", "Daily Earning", "", "", "", "", "", "");
            table.Rows.Add("(a)", "Including Passenger Tax", "Rs-In-Lakh", "0", "0", "0", "0", "0");
            table.Rows.Add("(b)", "Excluding Passenger Tax", "Rs-In-Lakh", "0", "0", "0", "0", "0");
            table.Rows.Add("20", "Earning Per Km.", "", "", "", "", "", "");
            table.Rows.Add("(a)", "Including Passenger Tax", "Paise", "0", "0", "0", "0", "0");
            table.Rows.Add("(b)", "Excluding Passenger Tax", "Paise", "0", "0", "0", "0", "0");
            table.Rows.Add("21", "Earning Per Bus daily", "Rs.", "0", "0", "0", "0", "0");
            table.Rows.Add("22", "Total Passengers Carried", "", "", "", "", "", "");
            table.Rows.Add("(a)", "Ticketed", "Lakhs", "0", "0", "0", "0", "0");
            table.Rows.Add("(b)", "Pink Ticketed", "Lakhs", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total Tickets", "Lakhs", "0", "0", "0", "0", "0");
            table.Rows.Add("(c)", "Pass Holders", "Lakhs", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Grand Total", "Lakhs", "0", "0", "0", "0", "0");
            table.Rows.Add("23", "Passengers Carried Daily", "Lakhs", "0", "0", "0", "0", "0");
            table.Rows.Add("24", "Passengers Per Bus Daily", "Number", "0", "0", "0", "0", "0");
            table.Rows.Add("25", "Passengers Per Bus K.M", "Number", "0", "0", "0", "0", "0");
            table.Rows.Add("26", "Total Break Downs", "Number", "0", "0", "0", "0", "0");
            table.Rows.Add("27", "BreakDowns Per 10,000 Kms.", "%", "0", "0", "0", "0", "0");
            table.Rows.Add("28", "Accidents Per 1,00,000 Kms.", "Number", "0", "0", "0", "0", "0");
            table.Rows.Add("29", "Passanger Complaints Per 100000 Passangers", "Number", "0", "0", "0", "0", "0");


            return table;
        }


        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_StatementShowingRegionWiseOperationalDataForTheMonth", OsbId);
            dataGridView1.DataSource = BindStatementShowingRegionWiseOperationalDataForTheMonth();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_StatementShowingRegionWiseOperationalDataForTheMonth", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_StatementShowingRegionWiseOperationalDataForTheMonth] ([OsbId],[S_No],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7]) VALUES (@OsbId,@S_No,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@S_No", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param6", row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param7", row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString());
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

        private void StatementShowingRegionWiseOperationalDataForTheMonth_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
        }

        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptStatementShowingRegionalWiseOperational objFrm = new rptStatementShowingRegionalWiseOperational(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }
    }
}
