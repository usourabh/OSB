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
                if (finYear == "2022-23")
                {
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] ,[Param5] FROM [rpt].[tbl_ComparativeOperationalData] where OsbId=@OsbId", con);
                    cmd.Parameters.AddWithValue("@OsbId", 5);
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
                }
                else if (finYear == "2023-24")
                {
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] ,[Param5] FROM [rpt].[tbl_ComparativeOperationalData] where OsbId=@OsbId", con);
                    cmd.Parameters.AddWithValue("@OsbId", 132);
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
            table.Rows.Add("1", "Total Fleet as on last date", "No", " ", " ", " ");
            table.Rows.Add("2", "Average Fleet", "No", " ", " ", " ");
            table.Rows.Add("3", "Avg. No. of buses on road", "No", " ", " ", " ");
            table.Rows.Add("4", "Fleet Utilization", "%", " ", " ", " ");
            table.Rows.Add("5", "Trips Scheduled daily", "No", " ", " ", " ");
            table.Rows.Add("6", "Trips operated daily", "No", " ", " ", " ");
            table.Rows.Add("7", "Operational Ratio", "%", " ", " ", " ");
            table.Rows.Add("8", "Scheduled Kms", "lakh", " ", " ", " ");
            table.Rows.Add("9", "Operated Kms", "lakh", " ", " ", " ");
            table.Rows.Add("10", "Kms Efficiency", "%", " ", " ", " ");
            table.Rows.Add("11", "Kms Operated Daily", "lakh", " ", " ", " ");
            table.Rows.Add("12", "Vehicle Utilization Km/Bus/Day", "kms", " ", " ", " ");
            table.Rows.Add("13", "Total Traffic Income (Including Passenger Tax)", "Rs. in lakh", " ", " ", " ");
            //table.Rows.Add("14", "Pink Pass Earning", "Rs. in lakh", " ", " ", " ");
            table.Rows.Add("14", "Traffic Income Per day", "Paise", " ", " ", " ");
            table.Rows.Add("15", "Traffic Income Per km", "Rs", " ", " ", " ");
            table.Rows.Add("16", "Traffic Income per bus daily", "No", " ", " ", " ");
            table.Rows.Add("17", "Breakdowns per 10,000 kms", "No", " ", " ", " ");
            table.Rows.Add("18", "Accidents as per 1 lakh kms", "lakh", " ", " ", " ");
            table.Rows.Add("19", "Total passsengers carried", "lakh", " ", " ", " ");
            //table.Rows.Add("21", "Pink pass passenger", "No", " ", " ", " ");
            table.Rows.Add("20", "Passengers carried daily", "%", " ", " ", " ");
            table.Rows.Add("21", "Passengers per bus daily", "No", " ", " ", " ");
            table.Rows.Add("22", "Load Factor", "%", " ", " ", " ");

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
