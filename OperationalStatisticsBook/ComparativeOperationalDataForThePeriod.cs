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
    public partial class ComparativeOperationalData : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);

        public ComparativeOperationalData(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] ,[Param5] FROM [rpt].[tbl_ComparativeOperationalData] where OsbId=@OsbId", con);
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
                    dataGridView1.DataSource = BindComparativeOperationDataTbl();
                }
                Common.SetColumnNonEditable(dataGridView1, 3);
                Common.SetColumnNonEditable(dataGridView1, 4);
                Common.SetColumnNonEditable(dataGridView1, 5);
            }
            catch (Exception ex)
            {

            }

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
        DataTable BindComparativeOperationDataTbl()
        {

            DataTable table = new DataTable();

            // COLUMNS NAME OF Comperative operational data

            table.Columns.Add("S.NO", typeof(string));
            table.Columns.Add("ITEM", typeof(string));
            table.Columns.Add("UNIT", typeof(string));
            table.Columns.Add("Financial Year", typeof(string));
            table.Columns.Add("Financial Year ", typeof(string));
            table.Columns.Add("Financial Year  ", typeof(string));

           
            //Rows Static data

           // table.Rows.Add("1", "2", "3", "4", "5", "6");
            table.Rows.Add("1", "Total Fleet as on last date", "No", "3762", "3760", "3762");
            table.Rows.Add("2", "Average Fleet", "No", "3789", "3761", "3760");
            table.Rows.Add("3", "Avg. No. of buses on road", "No", "3222", "2894", "3206");
            table.Rows.Add("4", "Fleet Utilization", "%", "85.04", "76.95", "85.27");
            table.Rows.Add("5", "Trips Scheduled daily", "No", "32913", "26795", "33547");
            table.Rows.Add("6", "Trips operated daily", "No", "29832", "24582", "31834");
            table.Rows.Add("7", "Operational Ratio", "%", "90.64", "91.74", "94.89");
            table.Rows.Add("8", "Scheduled Kms", "lakh", "2566.64", "2095.38", "2533.52");
            table.Rows.Add("9", "Operated Kms", "lakh", "2272.17", "1898.88", "2354.74");
            table.Rows.Add("10", "Kms Efficiency", "%", "88.53", "90.62", "92.94");
            table.Rows.Add("11", "Kms Operated Daily", "lakh", "6.21", "5.20", "6.45");
            table.Rows.Add("12", "Vehicle Utilization Km/Bus/Day", "kms", "193", "180", "201");
            table.Rows.Add("13", "Total Traffic Income (Including Passenger Tax)", "Rs. in lakh", "73552.78", "43567.32", "52457.18");
            table.Rows.Add("14", "Pink Pass Earning", "Rs. in lakh", "0", "0", "0");
            table.Rows.Add("15", "Traffic Income Per day", "Paise", "200.96", "119.36", "143.72");
            table.Rows.Add("16", "Traffic Income Per km", "Rs", "3237", "2294", "2228");
            table.Rows.Add("17", "Traffic Income per bus daily", "No", "6237", "4124", "4483");
            table.Rows.Add("18", "Breakdowns per 10,000 kms", "No", "4.57", "2.90", "4.01");
            table.Rows.Add("19", "Accidents as per 1 lakh kms", "lakh", "0.05", "0.04", "0.04");
            table.Rows.Add("20", "Total passsengers carried", "lakh", "12182.40", "4468.05", "5702.20");
            table.Rows.Add("21", "Pink pass passenger", "No", "0", "0", "0"); 
            table.Rows.Add("22", "Passengers carried daily", "%", "33.29", "12.24", "15.62"); 
            table.Rows.Add("23", "Passengers per bus daily", "No", "1033", "423", "487");
            table.Rows.Add("24", "Load Factor", "%", "86.77", "22.97", "22.30");

          //  dataGridView1.DataSource = table;

            return table;
        }

        private void ComparativeOperationalData_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
          //  BindComparativeOperationDataTbl();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BindComparativeOperationDataTbl();
            MessageBox.Show("Done");
        }

        private void Print_ReportOnClick(object sender, EventArgs e)
        {
            rptComparativeOperationalData objFrm = new rptComparativeOperationalData(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_ComparativeOperationalData", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].tbl_ComparativeOperationalData ([OsbId],[S_No],[Param1],[Param2],[Param3],[Param4],[Param5]) VALUES (@OsbId,@S_No,@Param1,@Param2,@Param3,@Param4,@Param5)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@S_No", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
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
                    MessageBox.Show(ex.Message);
                }

            }
            MessageBox.Show("Done");
        }

    }
    
}
