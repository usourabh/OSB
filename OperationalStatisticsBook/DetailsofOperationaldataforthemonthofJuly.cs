using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperationalStatisticsBook
{
    public partial class DetailsofOperationaldataforthemonthofJuly : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);

        public DetailsofOperationaldataforthemonthofJuly(int OsbId, int Year, int Month, string finYear, string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;
        }

        DataTable BindDetailsofOperationaldataforthemonthofJuly()
        {
            DataTable table = new DataTable();
            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Unit ", typeof(string));
            table.Columns.Add("City  ", typeof(string));
            table.Columns.Add("City       ", typeof(string));
            table.Columns.Add("City ", typeof(string));
            table.Columns.Add("City    ", typeof(string));
            table.Columns.Add(" NCR       ", typeof(string));
            table.Columns.Add("NCR", typeof(string));
            table.Columns.Add(" NCR     ", typeof(string));
            table.Columns.Add("Total City+ NCR ", typeof(string));
            table.Columns.Add("Total City+ NCR  ", typeof(string));
            table.Columns.Add("Total City+ NCR   ", typeof(string));
            table.Columns.Add("Total City+ NCR", typeof(string));
            table.Columns.Add("Kathmandu ", typeof(string));
            table.Columns.Add("Grand Total ", typeof(string));
            table.Columns.Add("FCMS", typeof(string));
            table.Columns.Add("FCMS ", typeof(string));
            table.Columns.Add("FCMS  ", typeof(string));


            //Rows Static Data
            table.Rows.Add("","","","Low Floor Non AC", "Low Floor AC", "Electric Bus AC","Total", "Low Floor Non AC", "Low Floor AC", "Total", "Low Floor Non AC","Low Floor AC", "Electric Bus AC", "Total DTC","","", "Non AC","AC","Total");

            table.Rows.Add("1", "2", "3", "4", "5","6", "7", "8", "9", "10", "11","12", "13", "14", "15", "16", "17", "18", "19");
            table.Rows.Add("1", "Total Fleet as on last day", "Number", "0", "0","0", "0", "0", "0", "0", "0","0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Avg. Fleet", "Number", "0", "0","0", "0", "0", "0", "0", "0","0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Avg. No. of buses scheduled", "Number", "0", "0","0", "0", "0", "0", "0", "0","0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Schedule ratio", "%", "0", "0","0", "0", "0", "0", "0", "0","0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Avg. No.of buses on road", "Number", "0", "0","0", "0", "0", "0", "0", "0","0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "Fleet utilization", "%", "0", "0","0", "0", "0", "0", "0", "0","0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "Trips scheduled daily", "Number", "0", "0","0", "0", "0", "0", "0", "0","0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("8", "Trips operated daily", "Number", "0", "0","0", "0", "0", "0", "0", "0","0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("9", "Trips Missed daily", "Number", "0", "0","0", "0", "0", "0", "0", "0","0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("10", "Operational ratio", "%", "0", "0","0", "0", "0", "0", "0", "0","0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("11", "Scheduled Kms.", "Lakh", "0", "0","0", "0", "0", "0", "0", "0","0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("12", "Operated Kms.", "Lakh", "0", "0","0", "0", "0", "0", "0", "0","0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("13", "Missed Kms.", "Lakh", "0", "0","0", "0", "0", "0", "0", "0","0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("14", "K.M. efficiency", "%", "0", "0","0", "0", "0", "0", "0", "0","0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("15", "Kms operated daily", "Lakh", "0", "0","0", "0", "0", "0", "0", "0","0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("16", "Vehicle utilization", "", "", "","", "", "", "", "", "","", "", "", "", "", "", "", "");
            table.Rows.Add("(a)", "Avg.buses on Road Kms/Bus/day", "No.", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("(b)", "Avg. Fleet held Kms./bus/day", "No.", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("17", "Gross Kms.(including dead Kms)", "lakhs", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("18", "Monthly Earning", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            table.Rows.Add("(a)", "Tickets Earning", "Rs-in-lakh", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("(b)", "Pink Tickets Earning", "Rs-in-lakh", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total Tickets Earning", "Rs-in-lakh", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("(c)", "Others Earning(School, Spl.hire, Tourist & passes)", "Rs-in-lakh", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0");
            table.Rows.Add("", "Grand Total", "Rs-in-lakh", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("19", "Daily Earning", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            table.Rows.Add("(a)", "Including passenger Tax", "Rs-in-lakh", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("(b)", "Excluding passenger Tax", "Rs-in-lakh", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("20", "Earning per Km.", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            table.Rows.Add("(a)", "Including Passenger Tax", "Paise", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("(b)", "Excluding Passenger Tax", "Paise", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("21", "Earning per bus daily", "Rs.", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("22", "Total passengers carried", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            table.Rows.Add("(a)", "Ticketed", "Lakhs", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("(b)", "PinkTicketed", "Lakhs", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total Ticketed", "Lakhs", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("(c)", "Pass Holders", "Lakhs", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Grand Total", "Lakhs", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("23", "Passengers carried daily", "Lakhs", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("24", "Passengers per bus daily", "Number", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("25", "Passengers per bus km.", "Number", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("26", "Load Factor", "%", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("27", "Total Breakdowns", "Number", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("28", "Breakdowns per 10,000 Kms.", "%", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("29", "Accidents per 1,00,000 Kms.", "Number", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("30", "Passanger complaints per 1,00,000 Passengers", "Number", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--");

            return table;//

        }
        private void DetailsofOperationaldataforthemonthofJuly_Load(object sender, EventArgs e)
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

        void BindIndexPage(int OsbId)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT [SNO],[Item],[Unit],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16] FROM [rpt].[tbl_DetailsofOperationaldataforthemonthofJuly] where OsbId=@OsbId", con);
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
                    dataGridView1.DataSource = BindDetailsofOperationaldataforthemonthofJuly();
                }
                CalcalculateTotal();
            }
            catch (Exception ex)
            {

            }

        }

        private void Save_Click(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DetailsofOperationaldataforthemonthofJuly", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null || row.Cells[11].Value != null|| row.Cells[12].Value != null || row.Cells[13].Value != null || row.Cells[14].Value != null || row.Cells[15].Value != null || row.Cells[16].Value != null || row.Cells[17].Value != null || row.Cells[18].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_DetailsofOperationaldataforthemonthofJuly] ([OsbId],[SNO],[Item],[Unit],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16]) VALUES (@OsbId,@SNO,@Item,@Unit,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11,@Param12,@Param13,@Param14,@Param15,@Param16)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@SNO", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Item", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Unit", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param6", row.Cells[8].Value == null ? "" : row.Cells[8].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param7", row.Cells[9].Value == null ? "" : row.Cells[9].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param8", row.Cells[10].Value == null ? "" : row.Cells[10].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param9", row.Cells[11].Value == null ? "" : row.Cells[11].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param10", row.Cells[12].Value == null ? "" : row.Cells[12].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param11", row.Cells[13].Value == null ? "" : row.Cells[13].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param12", row.Cells[14].Value == null ? "" : row.Cells[14].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param13", row.Cells[15].Value == null ? "" : row.Cells[15].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param14", row.Cells[16].Value == null ? "" : row.Cells[16].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param15", row.Cells[17].Value == null ? "" : row.Cells[17].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param16", row.Cells[18].Value == null ? "" : row.Cells[18].Value.ToString());
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

        private void Reset_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BindDetailsofOperationaldataforthemonthofJuly();
            DeleteExisitingTableRecord("tbl_RoutesOperatedByDtc", OsbId);
            MessageBox.Show("Done");
        }
        void CalcalculateTotal()
        {
            //swich case using date Last Month Date get  Start
            var SelectedDateTimeMonthYear = new DateTime(Year, Month, 01);
            var MonthLastDay = SelectedDateTimeMonthYear.AddDays(-1).Day;
            //swich case using date Last Month Date get  End

            var row = dataGridView1.Rows;

            #region Calculating_VerticalSum

            #region Monthly Earning 

            // division column number  start 
            dataGridView1.Rows[10].Cells[3].Value = Common.GetDiv(row, 8, 9, 3);
            dataGridView1.Rows[10].Cells[4].Value = Common.GetDiv(row, 8, 9, 4);
            dataGridView1.Rows[10].Cells[5].Value = Common.GetDiv(row, 8, 9, 5);
            dataGridView1.Rows[10].Cells[6].Value = Common.GetDiv(row, 8, 9, 6);
            dataGridView1.Rows[10].Cells[7].Value = Common.GetDiv(row, 8, 9, 7);
            dataGridView1.Rows[10].Cells[8].Value = Common.GetDiv(row, 8, 9, 8);
            dataGridView1.Rows[10].Cells[9].Value = Common.GetDiv(row, 8, 9, 9);
            dataGridView1.Rows[10].Cells[10].Value = Common.GetDiv(row, 8, 9, 10);
            dataGridView1.Rows[10].Cells[11].Value = Common.GetDiv(row, 8, 9, 11);
            dataGridView1.Rows[10].Cells[12].Value = Common.GetDiv(row, 8, 9, 12);
            dataGridView1.Rows[10].Cells[13].Value = Common.GetDiv(row, 8, 9, 13);
            dataGridView1.Rows[10].Cells[14].Value = Common.GetDiv(row, 8, 9, 14);
            dataGridView1.Rows[10].Cells[15].Value = Common.GetDiv(row, 8, 9, 15);
            dataGridView1.Rows[10].Cells[16].Value = Common.GetDiv(row, 8, 9, 16);
            dataGridView1.Rows[10].Cells[17].Value = Common.GetDiv(row, 8, 9, 17);
            dataGridView1.Rows[10].Cells[18].Value = Common.GetDiv(row, 8, 9, 18);

            dataGridView1.Rows[14].Cells[3].Value = Math.Round(Common.GetDiv(row, 12, 13, 3), 3);
            dataGridView1.Rows[14].Cells[4].Value = Math.Round(Common.GetDiv(row, 12, 13, 4), 4);
            dataGridView1.Rows[14].Cells[5].Value = Math.Round(Common.GetDiv(row, 12, 13, 5), 5);
            dataGridView1.Rows[14].Cells[6].Value = Math.Round(Common.GetDiv(row, 12, 13, 6), 6);
            dataGridView1.Rows[14].Cells[7].Value = Math.Round(Common.GetDiv(row, 12, 13, 7), 7);
            dataGridView1.Rows[14].Cells[8].Value = Math.Round(Common.GetDiv(row, 12, 13, 7), 8);
            dataGridView1.Rows[14].Cells[9].Value = Math.Round(Common.GetDiv(row, 12, 13, 7), 9);
            dataGridView1.Rows[14].Cells[10].Value = Math.Round(Common.GetDiv(row, 12, 13, 7), 10);
            dataGridView1.Rows[14].Cells[11].Value = Math.Round(Common.GetDiv(row, 12, 13, 7), 11);
            dataGridView1.Rows[14].Cells[12].Value = Math.Round(Common.GetDiv(row, 12, 13, 7), 12);
            dataGridView1.Rows[14].Cells[13].Value = Math.Round(Common.GetDiv(row, 12, 13, 7), 13);
            dataGridView1.Rows[14].Cells[14].Value = Math.Round(Common.GetDiv(row, 12, 13, 7), 14);
            dataGridView1.Rows[14].Cells[15].Value = Math.Round(Common.GetDiv(row, 12, 13, 7), 15);
            dataGridView1.Rows[14].Cells[16].Value = Math.Round(Common.GetDiv(row, 12, 13, 7), 16);
            dataGridView1.Rows[14].Cells[17].Value = Math.Round(Common.GetDiv(row, 12, 13, 7), 17);
            dataGridView1.Rows[14].Cells[18].Value = Math.Round(Common.GetDiv(row, 12, 13, 7), 18);
          
            // division column number  End 

            // Total Ticket Earning  Start

            dataGridView1.Rows[24].Cells[3].Value = Math.Round(Common.GetSum(row, 22, 23, 3), 2);
            dataGridView1.Rows[24].Cells[4].Value = Math.Round(Common.GetSum(row, 22, 23, 4), 2);
            dataGridView1.Rows[24].Cells[5].Value = Math.Round(Common.GetSum(row, 22, 23, 5), 2);
            dataGridView1.Rows[24].Cells[6].Value = Math.Round(Common.GetSum(row, 22, 23, 6), 2);
            dataGridView1.Rows[24].Cells[7].Value = Math.Round(Common.GetSum(row, 22, 23, 7), 2);
            dataGridView1.Rows[24].Cells[8].Value = Math.Round(Common.GetSum(row, 22, 23, 8), 2);
            dataGridView1.Rows[24].Cells[9].Value = Math.Round(Common.GetSum(row, 22, 23, 9), 2);
            dataGridView1.Rows[24].Cells[10].Value = Math.Round(Common.GetSum(row, 22, 23, 10), 2);
            dataGridView1.Rows[24].Cells[11].Value = Math.Round(Common.GetSum(row, 22, 23, 11), 2);
            dataGridView1.Rows[24].Cells[12].Value = Math.Round(Common.GetSum(row, 22, 23, 12), 2);
            dataGridView1.Rows[24].Cells[13].Value = Math.Round(Common.GetSum(row, 22, 23, 13), 2);
            dataGridView1.Rows[24].Cells[14].Value = Math.Round(Common.GetSum(row, 22, 23, 14), 2);
            dataGridView1.Rows[24].Cells[15].Value = Math.Round(Common.GetSum(row, 22, 23, 15), 2);
            dataGridView1.Rows[24].Cells[16].Value = Math.Round(Common.GetSum(row, 22, 23, 16), 2);
            dataGridView1.Rows[24].Cells[17].Value = Math.Round(Common.GetSum(row, 22, 23, 17), 2);
            dataGridView1.Rows[24].Cells[18].Value = Math.Round(Common.GetSum(row, 22, 23, 18), 2);


            // Total Ticket Earning  End

            // Total Grand Total  Start

            dataGridView1.Rows[26].Cells[3].Value = Math.Round(Common.GetSum(row, 24, 25, 3), 2);
            dataGridView1.Rows[26].Cells[4].Value = Math.Round(Common.GetSum(row, 24, 25, 4), 2);
            dataGridView1.Rows[26].Cells[5].Value = Math.Round(Common.GetSum(row, 24, 25, 5), 2);
            dataGridView1.Rows[26].Cells[6].Value = Math.Round(Common.GetSum(row, 24, 25, 6), 2);
            dataGridView1.Rows[26].Cells[7].Value = Math.Round(Common.GetSum(row, 24, 25, 7), 2);
            dataGridView1.Rows[26].Cells[8].Value = Math.Round(Common.GetSum(row, 24, 25, 8), 2);
            dataGridView1.Rows[26].Cells[9].Value = Math.Round(Common.GetSum(row, 24, 25, 9), 2);
            dataGridView1.Rows[26].Cells[10].Value = Math.Round(Common.GetSum(row, 24, 25, 10), 2);
            dataGridView1.Rows[26].Cells[11].Value = Math.Round(Common.GetSum(row, 24, 25, 11), 2);
            dataGridView1.Rows[26].Cells[12].Value = Math.Round(Common.GetSum(row, 24, 25, 12), 2);
            dataGridView1.Rows[26].Cells[13].Value = Math.Round(Common.GetSum(row, 24, 25, 13), 2);
            dataGridView1.Rows[26].Cells[14].Value = Math.Round(Common.GetSum(row, 24, 25, 14), 2);
            dataGridView1.Rows[26].Cells[15].Value = Math.Round(Common.GetSum(row, 24, 25, 15), 2);
            dataGridView1.Rows[26].Cells[16].Value = Math.Round(Common.GetSum(row, 24, 25, 16), 2);
            dataGridView1.Rows[26].Cells[17].Value = Math.Round(Common.GetSum(row, 24, 25, 17), 2);
            dataGridView1.Rows[26].Cells[18].Value = Math.Round(Common.GetSum(row, 24, 25, 18), 2);


            // Total Grand Total End

            // Total Ticket  Start

            dataGridView1.Rows[37].Cells[3].Value = Math.Round(Common.GetSum(row, 35, 36, 3), 2);
            dataGridView1.Rows[37].Cells[4].Value = Math.Round(Common.GetSum(row, 35, 36, 4), 2);
            dataGridView1.Rows[37].Cells[5].Value = Math.Round(Common.GetSum(row, 35, 36, 5), 2);
            dataGridView1.Rows[37].Cells[6].Value = Math.Round(Common.GetSum(row, 35, 36, 6), 2);
            dataGridView1.Rows[37].Cells[7].Value = Math.Round(Common.GetSum(row, 35, 36, 7), 2);
            dataGridView1.Rows[37].Cells[8].Value = Math.Round(Common.GetSum(row, 35, 36, 8), 2);
            dataGridView1.Rows[37].Cells[9].Value = Math.Round(Common.GetSum(row, 35, 36, 9), 2);
            dataGridView1.Rows[37].Cells[10].Value = Math.Round(Common.GetSum(row, 35, 36, 10), 2);
            dataGridView1.Rows[37].Cells[11].Value = Math.Round(Common.GetSum(row, 35, 36, 11), 2);
            dataGridView1.Rows[37].Cells[12].Value = Math.Round(Common.GetSum(row, 35, 36, 12), 2);
            dataGridView1.Rows[37].Cells[13].Value = Math.Round(Common.GetSum(row, 35, 36, 13), 2);
            dataGridView1.Rows[37].Cells[14].Value = Math.Round(Common.GetSum(row, 35, 36, 14), 2);
            dataGridView1.Rows[37].Cells[15].Value = Math.Round(Common.GetSum(row, 35, 36, 15), 2);
            dataGridView1.Rows[37].Cells[16].Value = Math.Round(Common.GetSum(row, 35, 36, 16), 2);
            dataGridView1.Rows[37].Cells[17].Value = Math.Round(Common.GetSum(row, 35, 36, 17), 2);
            dataGridView1.Rows[37].Cells[18].Value = Math.Round(Common.GetSum(row, 35, 36, 18), 2);


            // Total Ticket   End

            // Grand Total  Start

            dataGridView1.Rows[39].Cells[3].Value = Math.Round(Common.GetSum(row, 37, 38, 3), 2);
            dataGridView1.Rows[39].Cells[4].Value = Math.Round(Common.GetSum(row, 37, 38, 4), 2);
            dataGridView1.Rows[39].Cells[5].Value = Math.Round(Common.GetSum(row, 37, 38, 5), 2);
            dataGridView1.Rows[39].Cells[6].Value = Math.Round(Common.GetSum(row, 37, 38, 6), 2);
            dataGridView1.Rows[39].Cells[7].Value = Math.Round(Common.GetSum(row, 37, 38, 7), 2);
            dataGridView1.Rows[39].Cells[8].Value = Math.Round(Common.GetSum(row, 37, 38, 8), 2);
            dataGridView1.Rows[39].Cells[9].Value = Math.Round(Common.GetSum(row, 37, 38, 9), 2);
            dataGridView1.Rows[39].Cells[10].Value = Math.Round(Common.GetSum(row, 37, 38, 10), 2);
            dataGridView1.Rows[39].Cells[11].Value = Math.Round(Common.GetSum(row, 37, 38, 11), 2);
            dataGridView1.Rows[39].Cells[12].Value = Math.Round(Common.GetSum(row, 37, 38, 12), 2);
            dataGridView1.Rows[39].Cells[13].Value = Math.Round(Common.GetSum(row, 37, 38, 13), 2);
            dataGridView1.Rows[39].Cells[14].Value = Math.Round(Common.GetSum(row, 37, 38, 14), 2);
            dataGridView1.Rows[39].Cells[15].Value = Math.Round(Common.GetSum(row, 37, 38, 15), 2);
            dataGridView1.Rows[39].Cells[16].Value = Math.Round(Common.GetSum(row, 37, 38, 16), 2);
            dataGridView1.Rows[39].Cells[17].Value = Math.Round(Common.GetSum(row, 37, 38, 17), 2);
            dataGridView1.Rows[39].Cells[18].Value = Math.Round(Common.GetSum(row, 37, 38, 18), 2);


            // Grand Total   End



            #endregion Monthly Earning  


            #endregion Calculating_VerticalSum
            #region Calculating_HorizontalSum
            // for (int i = 0; i < (row.Count - 1); i++)
            for (int i = 0; i < 5; i++)
            {

                if (i > 1)
                {
                    // Add column Sr No Number 1 To 4 Start
                    dataGridView1.Rows[i].Cells[6].Value =Math.Round(Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[5].Value.ToString()),2);
                    dataGridView1.Rows[i].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[8].Value.ToString()));
                    dataGridView1.Rows[i].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()),0);
                    dataGridView1.Rows[i].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[8].Value.ToString()),0);
                    dataGridView1.Rows[i].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[i].Cells[5].Value.ToString()) , 2);
                    dataGridView1.Rows[i].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[i].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[12].Value.ToString()),0);
                    dataGridView1.Rows[i].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[i].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[14].Value.ToString()),0);
                    dataGridView1.Rows[i].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[i].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[17].Value.ToString()),0);

                    // Add column Number 1 To 4 End

                    // Add column Number 5 Start
                    dataGridView1.Rows[6].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[6].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[6].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[6].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[6].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[6].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[6].Cells[8].Value.ToString()));
                    dataGridView1.Rows[6].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[6].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[6].Cells[7].Value.ToString()), 0);
                    dataGridView1.Rows[6].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[6].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[6].Cells[8].Value.ToString()), 0);
                    dataGridView1.Rows[6].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[6].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[6].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[6].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[6].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[6].Cells[12].Value.ToString()), 0);
                    dataGridView1.Rows[6].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[6].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[6].Cells[14].Value.ToString()), 0);
                    dataGridView1.Rows[6].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[6].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[6].Cells[17].Value.ToString()), 0);

                    //Add column Number 5 End

                    // Add column Number 7 Start
                    dataGridView1.Rows[8].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[8].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[8].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[8].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[8].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[8].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[8].Cells[8].Value.ToString()));
                    dataGridView1.Rows[8].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[8].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[8].Cells[7].Value.ToString()), 0);
                    dataGridView1.Rows[8].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[8].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[8].Cells[8].Value.ToString()), 0);
                    dataGridView1.Rows[8].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[8].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[8].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[8].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[8].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[8].Cells[12].Value.ToString()), 0);
                    dataGridView1.Rows[8].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[8].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[8].Cells[14].Value.ToString()), 0);
                    dataGridView1.Rows[8].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[8].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[8].Cells[17].Value.ToString()), 0);

                    //Add column Number 7 End

                

                    // Add column Number 8 Start
                    dataGridView1.Rows[9].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[9].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[9].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[9].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[9].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[9].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[9].Cells[8].Value.ToString()));
                    dataGridView1.Rows[9].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[9].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[9].Cells[7].Value.ToString()), 0);
                    dataGridView1.Rows[9].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[9].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[9].Cells[8].Value.ToString()), 0);
                    dataGridView1.Rows[9].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[9].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[9].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[9].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[9].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[9].Cells[12].Value.ToString()), 0);
                    dataGridView1.Rows[9].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[9].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[9].Cells[14].Value.ToString()), 0);
                    dataGridView1.Rows[9].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[9].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[9].Cells[17].Value.ToString()), 0);

                    //Add column Number 8 End

                    // Add column Number 9 Start
                    dataGridView1.Rows[10].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[10].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[10].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[10].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[10].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[10].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[10].Cells[8].Value.ToString()));
                    dataGridView1.Rows[10].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[10].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[10].Cells[7].Value.ToString()), 0);
                    dataGridView1.Rows[10].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[10].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[10].Cells[8].Value.ToString()), 0);
                    dataGridView1.Rows[10].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[10].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[10].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[10].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[10].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[10].Cells[12].Value.ToString()), 0);
                    dataGridView1.Rows[10].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[10].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[10].Cells[14].Value.ToString()), 0);
                    dataGridView1.Rows[10].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[10].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[10].Cells[17].Value.ToString()), 0);

                    //Add column Number 9 End

                    // Add column Number 11 Start
                    dataGridView1.Rows[12].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[12].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[12].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[12].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[12].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[12].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[12].Cells[8].Value.ToString()));
                    dataGridView1.Rows[12].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[12].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[12].Cells[7].Value.ToString()), 0);
                    dataGridView1.Rows[12].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[12].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[12].Cells[8].Value.ToString()), 0);
                    dataGridView1.Rows[12].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[12].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[12].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[12].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[12].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[12].Cells[12].Value.ToString()), 0);
                    dataGridView1.Rows[12].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[12].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[12].Cells[14].Value.ToString()), 0);
                    dataGridView1.Rows[12].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[12].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[12].Cells[17].Value.ToString()), 0);

                    //Add column Number 11 End

                    // Add column Number 12 Start
                    dataGridView1.Rows[13].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[13].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[13].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[13].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[13].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[13].Cells[8].Value.ToString()));
                    dataGridView1.Rows[13].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[13].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[13].Cells[7].Value.ToString()), 0);
                    dataGridView1.Rows[13].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[13].Cells[8].Value.ToString()), 0);
                    dataGridView1.Rows[13].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[13].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[13].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[13].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[13].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[13].Cells[12].Value.ToString()), 0);
                    dataGridView1.Rows[13].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[13].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[13].Cells[14].Value.ToString()), 0);
                    dataGridView1.Rows[13].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[13].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[13].Cells[17].Value.ToString()), 0);

                    //Add column Number 12 End

                    // Add column Number 13 Start
                    dataGridView1.Rows[14].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[14].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[14].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[14].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[14].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[14].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[14].Cells[8].Value.ToString()));
                    dataGridView1.Rows[14].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[14].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[14].Cells[7].Value.ToString()), 0);
                    dataGridView1.Rows[14].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[14].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[14].Cells[8].Value.ToString()), 0);
                    dataGridView1.Rows[14].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[14].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[14].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[14].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[14].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[14].Cells[12].Value.ToString()), 0);
                    dataGridView1.Rows[14].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[14].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[14].Cells[14].Value.ToString()), 0);
                    dataGridView1.Rows[14].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[14].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[14].Cells[17].Value.ToString()), 0);

                    //Add column Number 13 End

                    // Add column Number 15 Start
                    dataGridView1.Rows[16].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[16].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[16].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[16].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[16].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[16].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[16].Cells[8].Value.ToString()));
                    dataGridView1.Rows[16].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[16].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[16].Cells[7].Value.ToString()), 0);
                    dataGridView1.Rows[16].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[16].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[16].Cells[8].Value.ToString()), 0);
                    dataGridView1.Rows[16].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[16].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[16].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[16].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[16].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[16].Cells[12].Value.ToString()), 0);
                    dataGridView1.Rows[16].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[16].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[16].Cells[14].Value.ToString()), 0);
                    dataGridView1.Rows[16].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[16].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[16].Cells[17].Value.ToString()), 0);

                    //Add column Number 15 End

                    // Add column Number 17 Start
                    dataGridView1.Rows[20].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[20].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[20].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[20].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[20].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[20].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[20].Cells[8].Value.ToString()));
                    dataGridView1.Rows[20].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[20].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[20].Cells[7].Value.ToString()), 0);
                    dataGridView1.Rows[20].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[20].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[20].Cells[8].Value.ToString()), 0);
                    dataGridView1.Rows[20].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[20].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[20].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[20].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[20].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[20].Cells[12].Value.ToString()), 0);
                    dataGridView1.Rows[20].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[20].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[20].Cells[14].Value.ToString()), 0);
                    dataGridView1.Rows[20].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[20].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[20].Cells[17].Value.ToString()), 0);

                    //Add column Number 17 End

                    // Add column Number 18(a) Start
                    dataGridView1.Rows[22].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[22].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[22].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[22].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[22].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[22].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[22].Cells[8].Value.ToString()),2);
                    dataGridView1.Rows[22].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[22].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[22].Cells[7].Value.ToString()), 2);
                    dataGridView1.Rows[22].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[22].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[22].Cells[8].Value.ToString()), 2);
                    dataGridView1.Rows[22].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[22].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[22].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[22].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[22].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[22].Cells[12].Value.ToString()), 2);
                    dataGridView1.Rows[22].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[22].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[22].Cells[14].Value.ToString()), 2);
                    dataGridView1.Rows[22].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[22].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[22].Cells[17].Value.ToString()), 2);

                    //Add column Number 18(a) End

                    // Add column Number 18(b) Start
                    dataGridView1.Rows[23].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[23].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[23].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[23].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[23].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[23].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[23].Cells[8].Value.ToString()),2);
                    dataGridView1.Rows[23].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[23].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[23].Cells[7].Value.ToString()), 2);
                    dataGridView1.Rows[23].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[23].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[23].Cells[8].Value.ToString()), 2);
                    dataGridView1.Rows[23].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[23].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[23].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[23].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[23].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[23].Cells[12].Value.ToString()), 2);
                    dataGridView1.Rows[23].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[23].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[23].Cells[14].Value.ToString()), 2);
                    dataGridView1.Rows[23].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[23].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[23].Cells[17].Value.ToString()), 2);

                    //Add column Number 18(b) End

                    // Add column Number 18 Total Ticket Start
                    dataGridView1.Rows[24].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[24].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[24].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[24].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[24].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[24].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[24].Cells[8].Value.ToString()),2);
                    dataGridView1.Rows[24].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[24].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[24].Cells[7].Value.ToString()), 2);
                    dataGridView1.Rows[24].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[24].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[24].Cells[8].Value.ToString()), 2);
                    dataGridView1.Rows[24].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[24].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[24].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[24].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[24].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[24].Cells[12].Value.ToString()), 2);
                    dataGridView1.Rows[24].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[24].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[24].Cells[14].Value.ToString()), 2);
                    dataGridView1.Rows[24].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[24].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[24].Cells[17].Value.ToString()), 2);

                    //Add column Number 18 Total Ticket End

                    // Add column Number 18 (c) Start
                    dataGridView1.Rows[25].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[25].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[25].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[25].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[25].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[25].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[25].Cells[8].Value.ToString()));
                    dataGridView1.Rows[25].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[25].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[25].Cells[7].Value.ToString()), 2);
                    dataGridView1.Rows[25].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[25].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[25].Cells[8].Value.ToString()), 2);
                    dataGridView1.Rows[25].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[25].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[25].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[25].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[25].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[25].Cells[12].Value.ToString()), 2);
                    dataGridView1.Rows[25].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[25].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[25].Cells[14].Value.ToString()), 2);
                    dataGridView1.Rows[25].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[25].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[25].Cells[17].Value.ToString()), 2);

                    //Add column Number 18 (c) End

                    // Add column Number 19 Daily Earning (a) Start
                    dataGridView1.Rows[28].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[28].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[28].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[28].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[28].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[28].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[28].Cells[8].Value.ToString()));
                    dataGridView1.Rows[28].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[28].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[28].Cells[7].Value.ToString()), 2);
                    dataGridView1.Rows[28].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[28].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[28].Cells[8].Value.ToString()), 2);
                    dataGridView1.Rows[28].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[28].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[28].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[28].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[28].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[28].Cells[12].Value.ToString()), 2);
                    dataGridView1.Rows[28].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[28].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[28].Cells[14].Value.ToString()), 2);
                    dataGridView1.Rows[28].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[28].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[28].Cells[17].Value.ToString()), 2);

                    //Add column Number 19 Daily Earning (a) End

                    // Add column Number 19 Daily Earning (b) Start
                    dataGridView1.Rows[29].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[29].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[29].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[29].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[29].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[29].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[29].Cells[8].Value.ToString()));
                    dataGridView1.Rows[29].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[29].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[29].Cells[7].Value.ToString()), 2);
                    dataGridView1.Rows[29].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[29].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[29].Cells[8].Value.ToString()), 2);
                    dataGridView1.Rows[29].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[29].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[29].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[29].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[29].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[29].Cells[12].Value.ToString()), 2);
                    dataGridView1.Rows[29].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[29].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[29].Cells[14].Value.ToString()), 2);
                    dataGridView1.Rows[29].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[29].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[29].Cells[17].Value.ToString()), 2);

                    //Add column Number 19 Daily Earning (b) End

                    // Add column Number 22 Total passengers carried (a)Ticket Start
                    dataGridView1.Rows[35].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[35].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[35].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[35].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[35].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[35].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[35].Cells[8].Value.ToString()));
                    dataGridView1.Rows[35].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[35].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[35].Cells[7].Value.ToString()), 2);
                    dataGridView1.Rows[35].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[35].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[35].Cells[8].Value.ToString()), 2);
                    dataGridView1.Rows[35].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[35].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[35].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[35].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[35].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[35].Cells[12].Value.ToString()), 2);
                    dataGridView1.Rows[35].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[35].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[35].Cells[14].Value.ToString()), 2);
                    dataGridView1.Rows[35].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[35].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[35].Cells[17].Value.ToString()), 2);

                    //Add column Number 22 Total passengers carried (a)Ticketed End

                    // Add column Number 22 Total passengers carried (b)PinkTicketed Start
                    dataGridView1.Rows[36].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[36].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[36].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[36].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[36].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[36].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[36].Cells[8].Value.ToString()));
                    dataGridView1.Rows[36].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[36].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[36].Cells[7].Value.ToString()), 2);
                    dataGridView1.Rows[36].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[36].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[36].Cells[8].Value.ToString()), 2);
                    dataGridView1.Rows[36].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[36].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[36].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[36].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[36].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[36].Cells[12].Value.ToString()), 2);
                    dataGridView1.Rows[36].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[36].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[36].Cells[14].Value.ToString()), 2);
                    dataGridView1.Rows[36].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[36].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[36].Cells[17].Value.ToString()), 2);

                    //Add column Number 22 Total passengers carried (b)PinkTicketed End

                    // Add column Number 22 Total passengers carried Total Ticket Start
                    dataGridView1.Rows[37].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[37].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[37].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[37].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[37].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[37].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[37].Cells[8].Value.ToString()));
                    dataGridView1.Rows[37].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[37].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[37].Cells[7].Value.ToString()), 2);
                    dataGridView1.Rows[37].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[37].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[37].Cells[8].Value.ToString()), 2);
                    dataGridView1.Rows[37].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[37].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[37].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[37].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[37].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[37].Cells[12].Value.ToString()), 2);
                    dataGridView1.Rows[37].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[37].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[37].Cells[14].Value.ToString()), 2);
                    dataGridView1.Rows[37].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[37].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[37].Cells[17].Value.ToString()), 2);

                    //Add column Number 22 Total passengers carried Total Ticket  End

                    // Add column Number 22 pass holders (c) Start
                    dataGridView1.Rows[38].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[38].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[38].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[38].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[38].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[38].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[38].Cells[8].Value.ToString()));
                    dataGridView1.Rows[38].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[38].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[38].Cells[7].Value.ToString()), 2);
                    dataGridView1.Rows[38].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[38].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[38].Cells[8].Value.ToString()), 2);
                    dataGridView1.Rows[38].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[38].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[38].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[38].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[38].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[38].Cells[12].Value.ToString()), 2);
                    dataGridView1.Rows[38].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[38].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[38].Cells[14].Value.ToString()), 2);
                    dataGridView1.Rows[38].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[38].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[38].Cells[17].Value.ToString()), 2);

                    //Add column Number 22 pass holders (c)   End

                    // Add column Number 23 Passengers carried daily Start
                    dataGridView1.Rows[40].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[40].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[40].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[40].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[40].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[40].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[40].Cells[8].Value.ToString()));
                    dataGridView1.Rows[40].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[40].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[40].Cells[7].Value.ToString()), 2);
                    dataGridView1.Rows[40].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[40].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[40].Cells[8].Value.ToString()), 2);
                    dataGridView1.Rows[40].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[40].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[40].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[40].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[40].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[40].Cells[12].Value.ToString()), 2);
                    dataGridView1.Rows[40].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[40].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[40].Cells[14].Value.ToString()), 2);
                    dataGridView1.Rows[40].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[40].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[40].Cells[17].Value.ToString()), 2);

                    //Add column Number 23 Passengers carried daily  End

                    // Add column Number 26  Start
                    dataGridView1.Rows[44].Cells[6].Value = Math.Round(Common.ConvertToDecimal(row[44].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[44].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[44].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[44].Cells[9].Value = Math.Round(Common.ConvertToDecimal(row[44].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[44].Cells[8].Value.ToString()));
                    dataGridView1.Rows[44].Cells[10].Value = Math.Round(Common.ConvertToDecimal(row[44].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[44].Cells[7].Value.ToString()), 2);
                    dataGridView1.Rows[44].Cells[11].Value = Math.Round(Common.ConvertToDecimal(row[44].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[44].Cells[8].Value.ToString()), 2);
                    dataGridView1.Rows[44].Cells[12].Value = Math.Round(Common.ConvertToDecimal(row[44].Cells[5].Value.ToString()), 2);
                    dataGridView1.Rows[44].Cells[13].Value = Math.Round(Common.ConvertToDecimal(row[44].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[44].Cells[11].Value.ToString()) + Common.ConvertToDecimal(row[44].Cells[12].Value.ToString()), 2);
                    dataGridView1.Rows[44].Cells[15].Value = Math.Round(Common.ConvertToDecimal(row[44].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[44].Cells[14].Value.ToString()), 2);
                    dataGridView1.Rows[44].Cells[18].Value = Math.Round(Common.ConvertToDecimal(row[44].Cells[16].Value.ToString()) + Common.ConvertToDecimal(row[44].Cells[17].Value.ToString()), 2);

                    //Add column Number 26  End

                 


                }
                #region // buses Scheduled/fleet avg * 100 All Formula
                if (i > 1)
                {
                    // Scheduled retio Column No 4 Start Formula
                    dataGridView1.Rows[5].Cells[3].Value = Common.ConvertToDecimal(row[3].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[3].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[3].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[4].Value = Common.ConvertToDecimal(row[3].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[4].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[5].Value = Common.ConvertToDecimal(row[3].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[5].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[6].Value = Common.ConvertToDecimal(row[3].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[6].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[6].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[7].Value = Common.ConvertToDecimal(row[3].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[7].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[8].Value = Common.ConvertToDecimal(row[3].Cells[8].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[8].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[8].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[9].Value = Common.ConvertToDecimal(row[3].Cells[9].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[9].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[9].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[10].Value = Common.ConvertToDecimal(row[3].Cells[10].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[10].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[10].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[11].Value = Common.ConvertToDecimal(row[3].Cells[11].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[11].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[11].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[12].Value = Common.ConvertToDecimal(row[3].Cells[12].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[12].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[12].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[13].Value = Common.ConvertToDecimal(row[3].Cells[13].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[13].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[13].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[14].Value = Common.ConvertToDecimal(row[3].Cells[14].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[14].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[14].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[15].Value = Common.ConvertToDecimal(row[3].Cells[15].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[15].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[15].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[16].Value = Common.ConvertToDecimal(row[3].Cells[16].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[16].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[16].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[17].Value = Common.ConvertToDecimal(row[3].Cells[17].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[17].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[17].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[5].Cells[18].Value = Common.ConvertToDecimal(row[3].Cells[18].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[18].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[18].Value.ToString())) * 100, 2) : 0;
                    // Scheduled retio Column No 4  End Formula

                    // Fleet Utilization Column Number 6 Start Formula
                    dataGridView1.Rows[7].Cells[3].Value = Common.ConvertToDecimal(row[3].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[3].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[3].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[4].Value = Common.ConvertToDecimal(row[3].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[4].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[5].Value = Common.ConvertToDecimal(row[3].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[5].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[6].Value = Common.ConvertToDecimal(row[3].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[6].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[6].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[7].Value = Common.ConvertToDecimal(row[3].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[7].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[8].Value = Common.ConvertToDecimal(row[3].Cells[8].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[8].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[8].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[9].Value = Common.ConvertToDecimal(row[3].Cells[9].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[9].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[9].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[10].Value = Common.ConvertToDecimal(row[3].Cells[10].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[10].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[10].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[11].Value = Common.ConvertToDecimal(row[3].Cells[11].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[11].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[11].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[12].Value = Common.ConvertToDecimal(row[3].Cells[12].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[12].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[12].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[13].Value = Common.ConvertToDecimal(row[3].Cells[13].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[13].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[13].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[14].Value = Common.ConvertToDecimal(row[3].Cells[14].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[14].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[14].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[15].Value = Common.ConvertToDecimal(row[3].Cells[15].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[15].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[15].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[16].Value = Common.ConvertToDecimal(row[3].Cells[16].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[16].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[16].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[17].Value = Common.ConvertToDecimal(row[3].Cells[17].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[17].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[17].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[7].Cells[18].Value = Common.ConvertToDecimal(row[3].Cells[18].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[18].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[18].Value.ToString())) * 100, 2) : 0;
                    //  Fleet Utilization Column Number 6 End Formula

                    // Oprational Ratio Column Number 10 Start Formula
                    dataGridView1.Rows[11].Cells[3].Value = Common.ConvertToDecimal(row[8].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[3].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[3].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[4].Value = Common.ConvertToDecimal(row[8].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[4].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[5].Value = Common.ConvertToDecimal(row[8].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[5].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[6].Value = Common.ConvertToDecimal(row[8].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[6].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[6].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[7].Value = Common.ConvertToDecimal(row[8].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[7].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[8].Value = Common.ConvertToDecimal(row[8].Cells[8].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[8].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[8].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[9].Value = Common.ConvertToDecimal(row[8].Cells[9].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[9].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[9].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[10].Value = Common.ConvertToDecimal(row[8].Cells[10].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[10].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[10].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[11].Value = Common.ConvertToDecimal(row[8].Cells[11].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[11].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[11].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[12].Value = Common.ConvertToDecimal(row[8].Cells[12].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[12].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[12].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[13].Value = Common.ConvertToDecimal(row[8].Cells[13].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[13].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[13].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[14].Value = Common.ConvertToDecimal(row[8].Cells[14].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[14].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[14].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[15].Value = Common.ConvertToDecimal(row[8].Cells[15].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[15].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[15].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[16].Value = Common.ConvertToDecimal(row[8].Cells[16].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[16].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[16].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[17].Value = Common.ConvertToDecimal(row[8].Cells[17].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[17].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[17].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[11].Cells[18].Value = Common.ConvertToDecimal(row[8].Cells[18].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[18].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[18].Value.ToString())) * 100, 2) : 0;
                    // Oprational Ratio  Column Number 10 End Formula

                     // K M Efficiency  Start Column Number 14 Start Formula
                    dataGridView1.Rows[15].Cells[3].Value = Common.ConvertToDecimal(row[12].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[3].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[3].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[4].Value = Common.ConvertToDecimal(row[12].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[4].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[5].Value = Common.ConvertToDecimal(row[12].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[5].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[6].Value = Common.ConvertToDecimal(row[12].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[6].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[6].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[7].Value = Common.ConvertToDecimal(row[12].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[7].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[8].Value = Common.ConvertToDecimal(row[12].Cells[8].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[8].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[8].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[9].Value = Common.ConvertToDecimal(row[12].Cells[9].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[9].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[9].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[10].Value = Common.ConvertToDecimal(row[12].Cells[10].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[10].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[10].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[11].Value = Common.ConvertToDecimal(row[12].Cells[11].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[11].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[11].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[12].Value = Common.ConvertToDecimal(row[12].Cells[12].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[12].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[12].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[13].Value = Common.ConvertToDecimal(row[12].Cells[13].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[13].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[13].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[14].Value = Common.ConvertToDecimal(row[12].Cells[14].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[14].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[14].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[15].Value = Common.ConvertToDecimal(row[12].Cells[15].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[15].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[15].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[16].Value = Common.ConvertToDecimal(row[12].Cells[16].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[16].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[16].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[17].Value = Common.ConvertToDecimal(row[12].Cells[17].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[17].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[17].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[15].Cells[18].Value = Common.ConvertToDecimal(row[12].Cells[18].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[13].Cells[18].Value.ToString()) / Common.ConvertToDecimal(row[12].Cells[18].Value.ToString())) * 100, 2) : 0;
                    //  K M Efficiency End 14 End Formula

                    // (a) Avg buses on Road kms/bus/day Start
                    dataGridView1.Rows[18].Cells[3].Value = Common.ConvertToDecimal(row[6].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[3].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[3].Value.ToString())) : 0;
                    dataGridView1.Rows[18].Cells[4].Value = Common.ConvertToDecimal(row[6].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[4].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[4].Value.ToString())) : 0;
                    dataGridView1.Rows[18].Cells[5].Value = Common.ConvertToDecimal(row[6].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[5].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[5].Value.ToString())) : 0;
                    dataGridView1.Rows[18].Cells[6].Value = Common.ConvertToDecimal(row[6].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[6].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[6].Value.ToString())) : 0;
                    dataGridView1.Rows[18].Cells[7].Value = Common.ConvertToDecimal(row[6].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[7].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[7].Value.ToString())) : 0;
                    dataGridView1.Rows[18].Cells[8].Value = Common.ConvertToDecimal(row[6].Cells[8].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[8].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[8].Value.ToString())) : 0;
                    dataGridView1.Rows[18].Cells[9].Value = Common.ConvertToDecimal(row[6].Cells[9].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[9].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[9].Value.ToString())) : 0;
                    dataGridView1.Rows[18].Cells[10].Value = Common.ConvertToDecimal(row[6].Cells[10].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[10].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[10].Value.ToString())) : 0;
                    dataGridView1.Rows[18].Cells[11].Value = Common.ConvertToDecimal(row[6].Cells[11].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[11].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[11].Value.ToString())) : 0;
                    dataGridView1.Rows[18].Cells[12].Value = Common.ConvertToDecimal(row[6].Cells[12].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[12].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[12].Value.ToString())) : 0;
                    dataGridView1.Rows[18].Cells[13].Value = Common.ConvertToDecimal(row[6].Cells[13].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[13].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[13].Value.ToString())) : 0;
                    dataGridView1.Rows[18].Cells[14].Value = Common.ConvertToDecimal(row[6].Cells[14].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[14].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[14].Value.ToString())) : 0;
                    dataGridView1.Rows[18].Cells[15].Value = Common.ConvertToDecimal(row[6].Cells[15].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[15].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[15].Value.ToString())) : 0;
                    dataGridView1.Rows[18].Cells[16].Value = Common.ConvertToDecimal(row[6].Cells[16].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[16].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[16].Value.ToString())) : 0;
                    dataGridView1.Rows[18].Cells[17].Value = Common.ConvertToDecimal(row[6].Cells[17].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[17].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[17].Value.ToString())) : 0;
                    dataGridView1.Rows[18].Cells[18].Value = Common.ConvertToDecimal(row[6].Cells[18].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[18].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[18].Value.ToString())) : 0;


                    //  (a) Avg buses on Road kms/bus/day End

                    // // (b) Avg buses on Road kms/bus/day Start

                    dataGridView1.Rows[19].Cells[3].Value = Common.ConvertToDecimal(row[3].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[3].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[3].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[4].Value = Common.ConvertToDecimal(row[3].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[4].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[4].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[5].Value = Common.ConvertToDecimal(row[3].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[5].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[5].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[6].Value = Common.ConvertToDecimal(row[3].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[6].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[6].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[7].Value = Common.ConvertToDecimal(row[3].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[7].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[7].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[8].Value = Common.ConvertToDecimal(row[3].Cells[8].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[8].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[8].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[9].Value = Common.ConvertToDecimal(row[3].Cells[9].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[9].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[9].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[10].Value = Common.ConvertToDecimal(row[3].Cells[10].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[10].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[10].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[11].Value = Common.ConvertToDecimal(row[3].Cells[11].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[11].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[11].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[12].Value = Common.ConvertToDecimal(row[3].Cells[12].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[12].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[12].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[13].Value = Common.ConvertToDecimal(row[3].Cells[13].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[13].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[13].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[14].Value = Common.ConvertToDecimal(row[3].Cells[14].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[14].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[14].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[15].Value = Common.ConvertToDecimal(row[3].Cells[15].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[15].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[15].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[16].Value = Common.ConvertToDecimal(row[3].Cells[16].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[16].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[16].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[17].Value = Common.ConvertToDecimal(row[3].Cells[17].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[17].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[17].Value.ToString())) : 0;
                    dataGridView1.Rows[19].Cells[18].Value = Common.ConvertToDecimal(row[3].Cells[18].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[18].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[3].Cells[18].Value.ToString())) : 0;

                    // (b) Avg buses on Road kms/bus/day Start



                    // column number 24 Passengers par bus daily  column number 23*100000/ column number 5 Start

                    dataGridView1.Rows[41].Cells[3].Value = Common.ConvertToDecimal(row[6].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[3].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[3].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[4].Value = Common.ConvertToDecimal(row[6].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[4].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[4].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[5].Value = Common.ConvertToDecimal(row[6].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[5].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[5].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[6].Value = Common.ConvertToDecimal(row[6].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[6].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[6].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[7].Value = Common.ConvertToDecimal(row[6].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[7].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[7].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[8].Value = Common.ConvertToDecimal(row[6].Cells[8].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[8].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[8].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[9].Value = Common.ConvertToDecimal(row[6].Cells[9].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[9].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[9].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[10].Value = Common.ConvertToDecimal(row[6].Cells[10].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[10].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[10].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[11].Value = Common.ConvertToDecimal(row[6].Cells[11].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[11].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[11].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[12].Value = Common.ConvertToDecimal(row[6].Cells[12].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[12].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[12].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[13].Value = Common.ConvertToDecimal(row[6].Cells[13].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[13].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[13].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[14].Value = Common.ConvertToDecimal(row[6].Cells[14].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[14].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[14].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[15].Value = Common.ConvertToDecimal(row[6].Cells[15].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[15].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[15].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[16].Value = Common.ConvertToDecimal(row[6].Cells[16].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[16].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[16].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[17].Value = Common.ConvertToDecimal(row[6].Cells[17].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[17].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[17].Value.ToString())) : 0;
                    dataGridView1.Rows[41].Cells[18].Value = Common.ConvertToDecimal(row[6].Cells[18].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[40].Cells[18].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[18].Value.ToString())) : 0;

                    // column number 24 Passengers par bus daily 

                    //New 

                    // column Number 20 (A)
                    dataGridView1.Rows[31].Cells[3].Value = Common.ConvertToDecimal(row[13].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[3].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[3].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[31].Cells[4].Value = Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[4].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[31].Cells[5].Value = Common.ConvertToDecimal(row[13].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[5].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[31].Cells[6].Value = Common.ConvertToDecimal(row[13].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[6].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[6].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[31].Cells[7].Value = Common.ConvertToDecimal(row[13].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[7].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[31].Cells[8].Value = Common.ConvertToDecimal(row[13].Cells[8].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[8].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[8].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[31].Cells[9].Value = Common.ConvertToDecimal(row[13].Cells[9].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[9].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[9].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[31].Cells[10].Value = Common.ConvertToDecimal(row[13].Cells[10].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[10].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[10].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[31].Cells[11].Value = Common.ConvertToDecimal(row[13].Cells[11].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[11].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[11].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[31].Cells[12].Value = Common.ConvertToDecimal(row[13].Cells[12].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[12].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[12].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[31].Cells[13].Value = Common.ConvertToDecimal(row[13].Cells[13].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[13].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[13].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[31].Cells[14].Value = Common.ConvertToDecimal(row[13].Cells[14].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[14].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[14].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[31].Cells[15].Value = Common.ConvertToDecimal(row[13].Cells[15].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[15].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[15].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[31].Cells[16].Value = Common.ConvertToDecimal(row[13].Cells[16].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[16].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[16].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[31].Cells[17].Value = Common.ConvertToDecimal(row[13].Cells[17].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[17].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[17].Value.ToString())) * 100, 2) : 0;
                    dataGridView1.Rows[31].Cells[18].Value = Common.ConvertToDecimal(row[13].Cells[18].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[26].Cells[18].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[18].Value.ToString())) * 100, 2) : 0;
                    // column Number 20 (A)

                    //Column Number 21
                    dataGridView1.Rows[33].Cells[3].Value = Common.ConvertToDecimal(row[6].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[3].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[3].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[4].Value = Common.ConvertToDecimal(row[6].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[4].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[4].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[5].Value = Common.ConvertToDecimal(row[6].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[5].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[5].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[6].Value = Common.ConvertToDecimal(row[6].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[6].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[6].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[7].Value = Common.ConvertToDecimal(row[6].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[7].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[7].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[8].Value = Common.ConvertToDecimal(row[6].Cells[8].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[8].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[8].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[9].Value = Common.ConvertToDecimal(row[6].Cells[9].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[9].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[9].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[10].Value = Common.ConvertToDecimal(row[6].Cells[10].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[10].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[10].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[11].Value = Common.ConvertToDecimal(row[6].Cells[11].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[11].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[11].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[12].Value = Common.ConvertToDecimal(row[6].Cells[12].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[12].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[12].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[13].Value = Common.ConvertToDecimal(row[6].Cells[13].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[13].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[13].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[14].Value = Common.ConvertToDecimal(row[6].Cells[14].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[14].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[14].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[15].Value = Common.ConvertToDecimal(row[6].Cells[15].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[15].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[15].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[16].Value = Common.ConvertToDecimal(row[6].Cells[16].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[16].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[16].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[17].Value = Common.ConvertToDecimal(row[6].Cells[17].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[17].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[17].Value.ToString())) : 0;
                    dataGridView1.Rows[33].Cells[18].Value = Common.ConvertToDecimal(row[6].Cells[18].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[28].Cells[18].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[6].Cells[18].Value.ToString())) : 0;
                  
                    // Column Number 21 

                    // 25 Passengers par bus daily Start

                    dataGridView1.Rows[42].Cells[3].Value = Common.ConvertToDecimal(row[13].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[3].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[3].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[42].Cells[4].Value = Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[4].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[42].Cells[5].Value = Common.ConvertToDecimal(row[13].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[5].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[42].Cells[6].Value = Common.ConvertToDecimal(row[13].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[6].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[6].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[42].Cells[7].Value = Common.ConvertToDecimal(row[13].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[7].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[42].Cells[8].Value = Common.ConvertToDecimal(row[13].Cells[8].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[8].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[8].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[42].Cells[9].Value = Common.ConvertToDecimal(row[13].Cells[9].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[9].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[9].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[42].Cells[10].Value = Common.ConvertToDecimal(row[13].Cells[10].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[10].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[10].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[42].Cells[11].Value = Common.ConvertToDecimal(row[13].Cells[11].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[11].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[11].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[42].Cells[12].Value = Common.ConvertToDecimal(row[13].Cells[12].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[12].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[12].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[42].Cells[13].Value = Common.ConvertToDecimal(row[13].Cells[13].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[13].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[13].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[42].Cells[14].Value = Common.ConvertToDecimal(row[13].Cells[14].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[14].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[14].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[42].Cells[15].Value = Common.ConvertToDecimal(row[13].Cells[15].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[15].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[15].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[42].Cells[16].Value = Common.ConvertToDecimal(row[13].Cells[16].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[16].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[16].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[42].Cells[17].Value = Common.ConvertToDecimal(row[13].Cells[17].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[17].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[17].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[42].Cells[18].Value = Common.ConvertToDecimal(row[13].Cells[18].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[39].Cells[18].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[18].Value.ToString())), 2) : 0;
                   

                    // 25 Passengers par bus daily End

                    // 27 Passengers par bus daily Start

                    dataGridView1.Rows[45].Cells[3].Value = Common.ConvertToDecimal(row[13].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[44].Cells[3].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[3].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[45].Cells[4].Value = Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[44].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[4].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[45].Cells[5].Value = Common.ConvertToDecimal(row[13].Cells[5].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[44].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[5].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[45].Cells[6].Value = Common.ConvertToDecimal(row[13].Cells[6].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[44].Cells[6].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[6].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[45].Cells[7].Value = Common.ConvertToDecimal(row[13].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[44].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[7].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[45].Cells[8].Value = Common.ConvertToDecimal(row[13].Cells[8].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[44].Cells[8].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[8].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[45].Cells[9].Value = Common.ConvertToDecimal(row[13].Cells[9].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[44].Cells[9].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[9].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[45].Cells[10].Value = Common.ConvertToDecimal(row[13].Cells[10].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[44].Cells[10].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[10].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[45].Cells[11].Value = Common.ConvertToDecimal(row[13].Cells[11].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[44].Cells[11].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[11].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[45].Cells[12].Value = Common.ConvertToDecimal(row[13].Cells[12].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[44].Cells[12].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[12].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[45].Cells[13].Value = Common.ConvertToDecimal(row[13].Cells[13].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[44].Cells[13].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[13].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[45].Cells[14].Value = Common.ConvertToDecimal(row[13].Cells[14].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[44].Cells[14].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[14].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[45].Cells[15].Value = Common.ConvertToDecimal(row[13].Cells[15].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[44].Cells[15].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[15].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[45].Cells[16].Value = Common.ConvertToDecimal(row[13].Cells[16].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[44].Cells[16].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[16].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[45].Cells[17].Value = Common.ConvertToDecimal(row[13].Cells[17].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[44].Cells[17].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[17].Value.ToString())), 2) : 0;
                    dataGridView1.Rows[45].Cells[18].Value = Common.ConvertToDecimal(row[13].Cells[18].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[44].Cells[18].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[18].Value.ToString())), 2) : 0;


                    // 27 Passengers par bus daily End

                    //New

                    // column Number 15  Start

                    dataGridView1.Rows[16].Cells[3].Value =  Math.Round((Common.ConvertToDecimal(row[13].Cells[3].Value.ToString()) / MonthLastDay)  , 2);
                    dataGridView1.Rows[16].Cells[4].Value =  Math.Round((Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) / MonthLastDay)  , 2);
                    dataGridView1.Rows[16].Cells[5].Value =  Math.Round((Common.ConvertToDecimal(row[13].Cells[5].Value.ToString()) / MonthLastDay)  , 2);
                    dataGridView1.Rows[16].Cells[6].Value =  Math.Round((Common.ConvertToDecimal(row[13].Cells[6].Value.ToString()) / MonthLastDay)  , 2);
                    dataGridView1.Rows[16].Cells[7].Value =  Math.Round((Common.ConvertToDecimal(row[13].Cells[7].Value.ToString()) / MonthLastDay)  , 2);
                    dataGridView1.Rows[16].Cells[8].Value =  Math.Round((Common.ConvertToDecimal(row[13].Cells[8].Value.ToString()) / MonthLastDay)  , 2);
                    dataGridView1.Rows[16].Cells[9].Value =  Math.Round((Common.ConvertToDecimal(row[13].Cells[9].Value.ToString()) / MonthLastDay)  , 2);
                    dataGridView1.Rows[16].Cells[10].Value = Math.Round((Common.ConvertToDecimal(row[13].Cells[10].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[16].Cells[11].Value = Math.Round((Common.ConvertToDecimal(row[13].Cells[11].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[16].Cells[12].Value = Math.Round((Common.ConvertToDecimal(row[13].Cells[12].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[16].Cells[13].Value = Math.Round((Common.ConvertToDecimal(row[13].Cells[13].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[16].Cells[14].Value = Math.Round((Common.ConvertToDecimal(row[13].Cells[14].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[16].Cells[15].Value = Math.Round((Common.ConvertToDecimal(row[13].Cells[15].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[16].Cells[16].Value = Math.Round((Common.ConvertToDecimal(row[13].Cells[16].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[16].Cells[17].Value = Math.Round((Common.ConvertToDecimal(row[13].Cells[17].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[16].Cells[18].Value = Math.Round((Common.ConvertToDecimal(row[13].Cells[18].Value.ToString()) / MonthLastDay) , 2);
              
                    // column Number 15 End

                    // column Number 19 (a) Start

                    dataGridView1.Rows[28].Cells[3].Value =  Math.Round((Common.ConvertToDecimal(row[26].Cells[3].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[4].Value =  Math.Round((Common.ConvertToDecimal(row[26].Cells[4].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[5].Value =  Math.Round((Common.ConvertToDecimal(row[26].Cells[5].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[6].Value =  Math.Round((Common.ConvertToDecimal(row[26].Cells[6].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[7].Value =  Math.Round((Common.ConvertToDecimal(row[26].Cells[7].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[8].Value =  Math.Round((Common.ConvertToDecimal(row[26].Cells[8].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[9].Value =  Math.Round((Common.ConvertToDecimal(row[26].Cells[9].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[10].Value = Math.Round((Common.ConvertToDecimal(row[26].Cells[10].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[11].Value = Math.Round((Common.ConvertToDecimal(row[26].Cells[11].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[12].Value = Math.Round((Common.ConvertToDecimal(row[26].Cells[12].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[13].Value = Math.Round((Common.ConvertToDecimal(row[26].Cells[13].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[14].Value = Math.Round((Common.ConvertToDecimal(row[26].Cells[14].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[15].Value = Math.Round((Common.ConvertToDecimal(row[26].Cells[15].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[16].Value = Math.Round((Common.ConvertToDecimal(row[26].Cells[16].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[17].Value = Math.Round((Common.ConvertToDecimal(row[26].Cells[17].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[28].Cells[18].Value = Math.Round((Common.ConvertToDecimal(row[26].Cells[18].Value.ToString()) / MonthLastDay) , 2);
            
                    // column Number 19 (a) End


                    // column Number 23  Start

                    dataGridView1.Rows[40].Cells[3].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[3].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[4].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[4].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[5].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[5].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[6].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[6].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[7].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[7].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[8].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[8].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[9].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[9].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[10].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[10].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[11].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[11].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[12].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[12].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[13].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[13].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[14].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[14].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[15].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[15].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[16].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[16].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[17].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[17].Value.ToString()) / MonthLastDay) , 2);
                    dataGridView1.Rows[40].Cells[18].Value = Math.Round((Common.ConvertToDecimal(row[39].Cells[18].Value.ToString()) / MonthLastDay) , 2);
                   
                    // column Number 23 End



                }

                #endregion// buses Scheduled/fleet avg * 100

            }
            #endregion

        }
        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptDetailsofOperationaldata objFrm = new rptDetailsofOperationaldata(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcalculateTotal();
        }
    }
}
