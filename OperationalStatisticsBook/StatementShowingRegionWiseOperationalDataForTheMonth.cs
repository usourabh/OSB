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
                {
                    dataGridView1.DataSource = dt;
                    Save.BackColor = Color.Green;
                }
                else
                {
                    dataGridView1.DataSource = BindStatementShowingRegionWiseOperationalDataForTheMonth();
                }

                NonEditableRowAndColumn();
                CalcalculateTotal();
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
            NonEditableRowAndColumn();
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

        void CalcalculateTotal()
        {
            int MonthLastDay = 0;
            DateTime currentDate = new DateTime(Year, Month, 01); 
            String previousMonthName = currentDate.ToString("MMMM");
           switch(previousMonthName)
            {
                case "January":
                     MonthLastDay = 31;
                    break;
                case "February":
                     MonthLastDay = 28;
                    break;
                case "March":
                    MonthLastDay = 31;
                    break;
                case "April":
                    MonthLastDay = 30;
                    break;
                case "May":
                    MonthLastDay = 31;
                    break;
                case "June":
                    MonthLastDay = 30;
                    break;
                case "July":
                    MonthLastDay = 31;
                    break;
                case "August":
                    MonthLastDay = 31;
                    break;
                case "September":
                    MonthLastDay = 30;
                    break;
                case "October":
                    MonthLastDay = 31;
                    break; 
                case "November":
                    MonthLastDay = 30;
                    break;
                case "December":
                    MonthLastDay = 31;
                    break;
            };


            var row = dataGridView1.Rows;

            #region Calculating_VerticalSum
            // buses Scheduled/fleet avg * 100

            // buses Scheduled/fleet avg * 100
            #region  // Total Ticket

            // division column number  start 
            dataGridView1.Rows[10].Cells[3].Value = Common.GetDiv(row, 8, 9, 3);
            dataGridView1.Rows[10].Cells[4].Value = Common.GetDiv(row, 8, 9, 4);
            dataGridView1.Rows[10].Cells[5].Value = Common.GetDiv(row, 8, 9, 5);
            dataGridView1.Rows[10].Cells[6].Value = Common.GetDiv(row, 8, 9, 6);
            dataGridView1.Rows[10].Cells[7].Value = Common.GetDiv(row, 8, 9, 7);

            dataGridView1.Rows[14].Cells[3].Value = Math.Round(Common.GetDiv(row, 12, 13, 3),2);
            dataGridView1.Rows[14].Cells[4].Value = Math.Round(Common.GetDiv(row, 12, 13, 4),2);
            dataGridView1.Rows[14].Cells[5].Value = Math.Round(Common.GetDiv(row, 12, 13, 5),2);
            dataGridView1.Rows[14].Cells[6].Value = Math.Round(Common.GetDiv(row, 12, 13, 6),2);
            dataGridView1.Rows[14].Cells[7].Value = Math.Round(Common.GetDiv(row, 12, 13, 7),2);
            // division column number  End 
            // Total Ticket

            dataGridView1.Rows[24].Cells[3].Value = Math.Round(Common.GetSum(row, 22, 23, 3), 2);
            dataGridView1.Rows[24].Cells[4].Value = Math.Round(Common.GetSum(row, 22, 23, 4), 2);
            dataGridView1.Rows[24].Cells[5].Value = Math.Round(Common.GetSum(row, 22, 23, 5), 2);
            dataGridView1.Rows[24].Cells[6].Value = Math.Round(Common.GetSum(row, 22, 23, 6), 2);
            dataGridView1.Rows[24].Cells[7].Value = Math.Round(Common.GetSum(row, 22, 23, 7), 2);
        
          
           // Grand total
            dataGridView1.Rows[26].Cells[3].Value = Math.Round(Common.GetSum(row, 24, 25, 3), 2);
            dataGridView1.Rows[26].Cells[4].Value = Math.Round(Common.GetSum(row, 24, 25, 4), 2);
            dataGridView1.Rows[26].Cells[5].Value = Math.Round(Common.GetSum(row, 24, 25, 5), 2);
            dataGridView1.Rows[26].Cells[6].Value = Math.Round(Common.GetSum(row, 24, 25, 6), 2);
            dataGridView1.Rows[26].Cells[7].Value = Math.Round(Common.GetSum(row, 24, 25, 7), 2);

            //total Ticket
            dataGridView1.Rows[37].Cells[3].Value = Math.Round(Common.GetSum(row, 35, 36, 3), 2);
            dataGridView1.Rows[37].Cells[4].Value = Math.Round(Common.GetSum(row, 35, 36, 4), 2);
            dataGridView1.Rows[37].Cells[5].Value = Math.Round(Common.GetSum(row, 35, 36, 5), 2);
            dataGridView1.Rows[37].Cells[6].Value = Math.Round(Common.GetSum(row, 35, 36, 6), 2);
            dataGridView1.Rows[37].Cells[7].Value = Math.Round(Common.GetSum(row, 35, 36, 7), 2);

            //Grand total
            dataGridView1.Rows[39].Cells[3].Value = Math.Round(Common.GetSum(row, 37, 38, 3), 2);
            dataGridView1.Rows[39].Cells[4].Value = Math.Round(Common.GetSum(row, 37, 38, 4), 2);
            dataGridView1.Rows[39].Cells[5].Value = Math.Round(Common.GetSum(row, 37, 38, 5), 2);
            dataGridView1.Rows[39].Cells[6].Value = Math.Round(Common.GetSum(row, 37, 38, 6), 2);
            dataGridView1.Rows[39].Cells[7].Value = Math.Round(Common.GetSum(row, 37, 38, 7), 2);
            #endregion

            #endregion

            #region Calculating_HorizontalSum
            // for (int i = 0; i < (row.Count - 1); i++)        
            for (int i = 0; i < 5; i++)
            {

                if (i>1)
                {
                    // Add column Number 7 All Column Start
                    dataGridView1.Rows[i].Cells[7].Value = Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[6].Value.ToString());                  
                    
                    dataGridView1.Rows[6].Cells[7].Value = Common.ConvertToDecimal(row[6].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[6].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[6].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[6].Cells[6].Value.ToString());

                    dataGridView1.Rows[8].Cells[7].Value = Common.ConvertToDecimal(row[8].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[8].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[8].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[8].Cells[6].Value.ToString());
                    dataGridView1.Rows[9].Cells[7].Value = Common.ConvertToDecimal(row[9].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[9].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[9].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[9].Cells[6].Value.ToString());
                    dataGridView1.Rows[10].Cells[7].Value = Common.ConvertToDecimal(row[10].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[10].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[10].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[10].Cells[6].Value.ToString());

                    dataGridView1.Rows[12].Cells[7].Value = Common.ConvertToDecimal(row[12].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[12].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[12].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[12].Cells[6].Value.ToString());
                    dataGridView1.Rows[13].Cells[7].Value = Common.ConvertToDecimal(row[13].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[13].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[13].Cells[6].Value.ToString());
                    dataGridView1.Rows[14].Cells[7].Value = Common.ConvertToDecimal(row[14].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[14].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[14].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[14].Cells[6].Value.ToString());
                   
                    dataGridView1.Rows[16].Cells[7].Value = Common.ConvertToDecimal(row[16].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[16].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[16].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[16].Cells[6].Value.ToString());
                    //(b) End New line
                    dataGridView1.Rows[20].Cells[7].Value = Common.ConvertToDecimal(row[20].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[20].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[20].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[20].Cells[6].Value.ToString());
                   
                    dataGridView1.Rows[22].Cells[7].Value = Common.ConvertToDecimal(row[22].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[22].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[22].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[22].Cells[6].Value.ToString());
                    dataGridView1.Rows[23].Cells[7].Value = Common.ConvertToDecimal(row[23].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[23].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[23].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[23].Cells[6].Value.ToString());
                    dataGridView1.Rows[24].Cells[7].Value = Common.ConvertToDecimal(row[24].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[24].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[24].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[24].Cells[6].Value.ToString());
                    dataGridView1.Rows[25].Cells[7].Value = Common.ConvertToDecimal(row[25].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[25].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[25].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[25].Cells[6].Value.ToString());
                   
                    dataGridView1.Rows[28].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[28].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[28].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[28].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[28].Cells[6].Value.ToString()) , 2);
                    dataGridView1.Rows[29].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[29].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[29].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[29].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[29].Cells[6].Value.ToString()) , 2);
                   
                    dataGridView1.Rows[35].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[35].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[35].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[35].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[35].Cells[6].Value.ToString()) , 2);
                    dataGridView1.Rows[36].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[36].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[36].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[36].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[36].Cells[6].Value.ToString()) , 2);
                    dataGridView1.Rows[37].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[37].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[37].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[37].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[37].Cells[6].Value.ToString()) , 2);
                    dataGridView1.Rows[38].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[38].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[38].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[38].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[38].Cells[6].Value.ToString()) , 2);
                    dataGridView1.Rows[40].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[40].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[40].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[40].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[40].Cells[6].Value.ToString()) , 2);
                    dataGridView1.Rows[43].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[43].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[43].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[43].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[43].Cells[6].Value.ToString()) , 2);

                    // Add All Column  7 Number End
                }

                #region // buses Scheduled/fleet avg * 100 All Formula
                if (i > 1)
                {
                    // Scheduled retio Start
                    dataGridView1.Rows[5].Cells[3].Value = Common.ConvertToDecimal(row[3].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[3].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[3].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[4].Value = Common.ConvertToDecimal(row[3].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[4].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[5].Value = Common.ConvertToDecimal(row[3].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[5].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[6].Value = Common.ConvertToDecimal(row[3].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[6].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[6].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[7].Value = Common.ConvertToDecimal(row[3].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[7].Value.ToString())) * 100, 2) : 0;
                    // Scheduled retio End

                    // fleet utilization Start
                    dataGridView1.Rows[7].Cells[3].Value = Common.ConvertToDecimal(row[3].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[3].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[3].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[4].Value = Common.ConvertToDecimal(row[3].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[4].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[5].Value = Common.ConvertToDecimal(row[3].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[5].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[6].Value = Common.ConvertToDecimal(row[3].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[6].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[6].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[7].Value = Common.ConvertToDecimal(row[3].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[7].Value.ToString())) * 100, 2) : 0;
                    // fleet utilization  End

                    // opration Ratio Start
                    dataGridView1.Rows[11].Cells[3].Value = Common.ConvertToDecimal(row[8].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[3].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[3].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[4].Value = Common.ConvertToDecimal(row[8].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[4].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[5].Value = Common.ConvertToDecimal(row[8].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[5].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[6].Value = Common.ConvertToDecimal(row[8].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[6].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[6].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[7].Value = Common.ConvertToDecimal(row[8].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[7].Value.ToString())) * 100, 2) : 0;
                    // opration Reatio End

                    // K M Efficiency  Start
                    dataGridView1.Rows[15].Cells[3].Value = Common.ConvertToDecimal(row[12].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[3].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[3].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[4].Value = Common.ConvertToDecimal(row[12].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[4].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[5].Value = Common.ConvertToDecimal(row[12].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[5].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[6].Value = Common.ConvertToDecimal(row[12].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[6].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[6].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[7].Value = Common.ConvertToDecimal(row[12].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[7].Value.ToString())) * 100, 2) : 0;
                    //  K M Efficiency End


                    // (a) Avg buses on Road kms/bus/day Start
                    dataGridView1.Rows[18].Cells[3].Value = Common.ConvertToDecimal(row[6].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[3].Value.ToString()) * 100000)/ Common.ConvertToDecimal(row[6].Cells[3].Value.ToString())) :0;
                    dataGridView1.Rows[18].Cells[4].Value = Common.ConvertToDecimal(row[6].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[4].Value.ToString()) * 100000)/ Common.ConvertToDecimal(row[6].Cells[4].Value.ToString())) :0;
                    dataGridView1.Rows[18].Cells[5].Value = Common.ConvertToDecimal(row[6].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[5].Value.ToString()) * 100000)/ Common.ConvertToDecimal(row[6].Cells[5].Value.ToString())) :0;
                    dataGridView1.Rows[18].Cells[6].Value = Common.ConvertToDecimal(row[6].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[6].Value.ToString()) * 100000)/ Common.ConvertToDecimal(row[6].Cells[6].Value.ToString())) :0;
                    dataGridView1.Rows[18].Cells[7].Value = Common.ConvertToDecimal(row[6].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[7].Value.ToString()) * 100000)/ Common.ConvertToDecimal(row[6].Cells[7].Value.ToString())) :0;
           

                    //  (a) Avg buses on Road kms/bus/day End

                    // (b) Avg buses on Road kms/bus/day Start
                    dataGridView1.Rows[19].Cells[3].Value = Common.ConvertToDecimal(row[3].Cells[3].Value.ToString()) > 0 ?Math.Round((Common.ConvertToDecimal(row[16].Cells[3].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[3].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[4].Value = Common.ConvertToDecimal(row[3].Cells[4].Value.ToString()) > 0 ?Math.Round((Common.ConvertToDecimal(row[16].Cells[4].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[4].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[5].Value = Common.ConvertToDecimal(row[3].Cells[5].Value.ToString()) > 0 ?Math.Round((Common.ConvertToDecimal(row[16].Cells[5].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[5].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[6].Value = Common.ConvertToDecimal(row[3].Cells[6].Value.ToString()) > 0 ?Math.Round((Common.ConvertToDecimal(row[16].Cells[6].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[6].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[7].Value = Common.ConvertToDecimal(row[3].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[7].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[7].Value.ToString())) : 0;

                    //  (b) Avg fleet heald kms/bus/day End

                    // 24 Passengers par bus daily Start
                    dataGridView1.Rows[41].Cells[3].Value = Common.ConvertToDecimal(row[6].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[3].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[3].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[4].Value = Common.ConvertToDecimal(row[6].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[4].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[4].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[5].Value = Common.ConvertToDecimal(row[6].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[5].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[5].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[6].Value = Common.ConvertToDecimal(row[6].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[6].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[6].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[7].Value = Common.ConvertToDecimal(row[6].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[7].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[7].Value.ToString())) : 0;

                    // 24 Passengers par bus daily End
                    //New

                    // column Number 15  Start

                    dataGridView1.Rows[16].Cells[3].Value = Math.Round((Common.ConvertToDecimal(row[13].Cells[3].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[16].Cells[4].Value = Math.Round((Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[16].Cells[5].Value = Math.Round((Common.ConvertToDecimal(row[13].Cells[5].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[16].Cells[6].Value = Math.Round((Common.ConvertToDecimal(row[13].Cells[6].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[16].Cells[7].Value = Math.Round((Common.ConvertToDecimal(row[13].Cells[7].Value.ToString()) / MonthLastDay) , 2);
                    // column Number 15 End

                    // column Number 19 (a) Start

                    dataGridView1.Rows[28].Cells[3].Value = Math.Round((Common.ConvertToDecimal(row[26].Cells[3].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[4].Value = Math.Round((Common.ConvertToDecimal(row[26].Cells[4].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[5].Value = Math.Round((Common.ConvertToDecimal(row[26].Cells[5].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[6].Value = Math.Round((Common.ConvertToDecimal(row[26].Cells[6].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[7].Value = Math.Round((Common.ConvertToDecimal(row[26].Cells[7].Value.ToString()) / MonthLastDay) , 2);
                    // column Number 19 (a) End


                    // column Number 23  Start

                    dataGridView1.Rows[40].Cells[3].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[3].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[4].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[4].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[5].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[5].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[6].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[6].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[7].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[7].Value.ToString()) / MonthLastDay) , 2);
                    // column Number 23 End

                    // column Number 20 (A)
                    dataGridView1.Rows[31].Cells[3].Value = Common.ConvertToDecimal(row[13].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[3].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[3].Value.ToString())) * 100) : 0;
                    dataGridView1.Rows[31].Cells[4].Value = Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[4].Value.ToString())) * 100) : 0;
                    dataGridView1.Rows[31].Cells[5].Value = Common.ConvertToDecimal(row[13].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[5].Value.ToString())) * 100) : 0;
                    dataGridView1.Rows[31].Cells[6].Value = Common.ConvertToDecimal(row[13].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[6].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[6].Value.ToString())) * 100) : 0;
                    dataGridView1.Rows[31].Cells[7].Value = Common.ConvertToDecimal(row[13].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[7].Value.ToString())) * 100) : 0;
                    // column Number 20 (A)             

                    //Column Number 21
                    dataGridView1.Rows[33].Cells[3].Value = Common.ConvertToDecimal(row[6].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[3].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[3].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[4].Value = Common.ConvertToDecimal(row[6].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[4].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[4].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[5].Value = Common.ConvertToDecimal(row[6].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[5].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[5].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[6].Value = Common.ConvertToDecimal(row[6].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[6].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[6].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[7].Value = Common.ConvertToDecimal(row[6].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[7].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[7].Value.ToString())) : 0;

                    // Column Number 21 
                
                    // 25 Passengers par bus daily Start

                    dataGridView1.Rows[42].Cells[3].Value = Common.ConvertToDecimal(row[13].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[3].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[3].Value.ToString())), 1) : 0;
                    dataGridView1.Rows[42].Cells[4].Value = Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[4].Value.ToString())), 1) : 0;
                    dataGridView1.Rows[42].Cells[5].Value = Common.ConvertToDecimal(row[13].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[5].Value.ToString())), 1) : 0;
                    dataGridView1.Rows[42].Cells[6].Value = Common.ConvertToDecimal(row[13].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[6].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[6].Value.ToString())), 1) : 0;
                    dataGridView1.Rows[42].Cells[7].Value = Common.ConvertToDecimal(row[13].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[7].Value.ToString())), 1) : 0;


                    // 25 Passengers par bus daily End

                    // 27 Passengers par bus daily Start

                    dataGridView1.Rows[44].Cells[3].Value = Common.ConvertToDecimal(row[13].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[43].Cells[3].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[3].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[44].Cells[4].Value = Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[43].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[4].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[44].Cells[5].Value = Common.ConvertToDecimal(row[13].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[43].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[5].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[44].Cells[6].Value = Common.ConvertToDecimal(row[13].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[43].Cells[6].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[6].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[44].Cells[7].Value = Common.ConvertToDecimal(row[13].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[43].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[7].Value.ToString())), 2) : 0;


                    // 27 Passengers par bus daily End

                }

                #endregion// buses Scheduled/fleet avg * 100

            }
            #endregion

            for (int i = 3; i < 8; i++)
            {
                dataGridView1.Rows[43].Cells[i].Value = Common.ConvertToDecimal(row[12].Cells[i].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[42].Cells[i].Value.ToString()) * 10000) / (Common.ConvertToDecimal(row[12].Cells[i].Value.ToString()) * 100000), 2) : 0;
            }

        }

        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptStatementShowingRegionalWiseOperational objFrm = new rptStatementShowingRegionalWiseOperational(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcalculateTotal();
        }
        public void NonEditableRowAndColumn()
        {
            Common.SetRowNonEditable(dataGridView1, 5);
            Common.SetRowNonEditable(dataGridView1, 7);
            Common.SetRowNonEditable(dataGridView1, 11);
            Common.SetRowNonEditable(dataGridView1, 15);
            Common.SetRowNonEditable(dataGridView1, 18);
            Common.SetRowNonEditable(dataGridView1, 19);
            Common.SetRowNonEditable(dataGridView1, 16);
            Common.SetRowNonEditable(dataGridView1, 41);
            Common.SetRowNonEditable(dataGridView1, 31);
            Common.SetRowNonEditable(dataGridView1, 33);
            Common.SetRowNonEditable(dataGridView1, 40);
            Common.SetRowNonEditable(dataGridView1, 28);
            Common.SetRowNonEditable(dataGridView1, 42);
            Common.SetRowNonEditable(dataGridView1, 44);
            Common.SetRowNonEditable(dataGridView1, 10);
            Common.SetRowNonEditable(dataGridView1, 14);
            Common.SetRowNonEditable(dataGridView1, 24);
            Common.SetRowNonEditable(dataGridView1, 26);
            Common.SetRowNonEditable(dataGridView1, 37);
            Common.SetRowNonEditable(dataGridView1, 39);

            Common.SetRowNonEditable(dataGridView1, 21);
            Common.SetRowNonEditable(dataGridView1, 27);
            Common.SetRowNonEditable(dataGridView1, 30);
            Common.SetRowNonEditable(dataGridView1, 34);
            Common.SetRowNonEditable(dataGridView1, 17);

            Common.SetColumnNonEditable(dataGridView1, 7);
        }
    }
}
