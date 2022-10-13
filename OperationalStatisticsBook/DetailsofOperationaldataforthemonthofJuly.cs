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
                    dataGridView1.DataSource = dt;
                else
                    dataGridView1.DataSource = BindDetailsofOperationaldataforthemonthofJuly();
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

        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptDetailsofOperationaldata objFrm = new rptDetailsofOperationaldata(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }
    }
}
