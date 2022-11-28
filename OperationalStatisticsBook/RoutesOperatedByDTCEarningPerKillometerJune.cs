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
    public partial class RoutesOperatedByDTCEarningPerKillometerJune : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);

        void BindIndexPage(int OsbId)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT [EPK],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14] FROM [rpt].[tbl_RoutesOperatedByDTCEarningPerKillometerJune] where OsbId=@OsbId", con);
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
                    dataGridView1.DataSource = BindRoutesOperatedByDTCEarningPerKillometerJune();
                }
                CalcalculateTotal();
            }
            catch (Exception ex)
            {

            }

        }
        public RoutesOperatedByDTCEarningPerKillometerJune(int OsbId, int Year, int Month, string finYear, string MonthName)
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
        DataTable BindRoutesOperatedByDTCEarningPerKillometerJune()
        {
            DataTable table = new DataTable();

            table.Columns.Add("EPK", typeof(string));
            table.Columns.Add("No Of Route", typeof(string));
            table.Columns.Add("Route %", typeof(string));
            table.Columns.Add("No. of Buses ", typeof(string));
            table.Columns.Add("Buses %  ", typeof(string));
            table.Columns.Add("Route No ", typeof(string));
            table.Columns.Add("Route No  ", typeof(string));
            table.Columns.Add("Route No", typeof(string));
            table.Columns.Add(" Route No   ", typeof(string));
            table.Columns.Add("Route No    ", typeof(string));
            table.Columns.Add("  Route No   ", typeof(string));
            table.Columns.Add("  Route No", typeof(string));
            table.Columns.Add("Route  No   ", typeof(string));
            table.Columns.Add(" Route  No   ", typeof(string));
            table.Columns.Add("   Route No", typeof(string));


            table.Rows.Add("<15","93", "23", "269", "8", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("15-19.99","122", "30", "717", "23", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("20-24.99","124", "30", "1219", "39", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");


            table.Rows.Add("25-29.99","58", "14", "772", "25", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add(" "," ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(">30","14", "3", "158", "5", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("Total ","0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            return table;
        }
            
        private void ResetOnClick(object sender, EventArgs e)
        {

            dataGridView1.DataSource = BindRoutesOperatedByDTCEarningPerKillometerJune();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_RoutesOperatedByDTCEarningPerKillometerJune", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null || row.Cells[11].Value != null || row.Cells[12].Value != null || row.Cells[13].Value != null || row.Cells[14].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_RoutesOperatedByDTCEarningPerKillometerJune] ([OsbId],[EPK],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14]) VALUES (@OsbId,@EPK,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11,@Param12,@Param13,@Param14)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@EPK", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
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
                        cmd.Parameters.AddWithValue("@Param13", row.Cells[13].Value == null ? "" : row.Cells[13].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param14", row.Cells[14].Value == null ? "" : row.Cells[14].Value.ToString());
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

        private void RoutesOperatedByDTCEarningPerKillometerJune_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
           // dataGridView1.DataSource = BindRoutesOperatedByDTCEarningPerKillometerJune();
        }

        void CalcalculateTotal()
        {
            var row = dataGridView1.Rows;

            #region Calculating_VerticalSum

            // North Total
            dataGridView1.Rows[44].Cells[1].Value = Common.GetSum(row, 0, 43, 1);
            dataGridView1.Rows[44].Cells[2].Value = Common.GetSum(row, 0, 43, 2);
            dataGridView1.Rows[44].Cells[3].Value = Common.GetSum(row, 0, 43, 3);
            dataGridView1.Rows[44].Cells[4].Value = Common.GetSum(row, 0, 43, 4);
            //dataGridView1.Rows[44].Cells[5].Value = Common.GetSum(row, 0, 43, 5);
            //dataGridView1.Rows[44].Cells[6].Value = Common.GetSum(row, 0, 43, 6);
            //dataGridView1.Rows[44].Cells[7].Value = Common.GetSum(row, 0, 43, 7);
            //dataGridView1.Rows[44].Cells[8].Value = Common.GetSum(row, 0, 43, 8);
            //dataGridView1.Rows[44].Cells[9].Value = Common.GetSum(row, 0, 43, 9);
            //dataGridView1.Rows[44].Cells[10].Value = Common.GetSum(row, 0, 43, 10);
            //dataGridView1.Rows[44].Cells[11].Value = Common.GetSum(row, 0, 43, 11);
            //dataGridView1.Rows[44].Cells[12].Value = Common.GetSum(row, 0, 43, 12);
            //dataGridView1.Rows[44].Cells[13].Value = Common.GetSum(row, 0, 43, 13);
            //dataGridView1.Rows[44].Cells[14].Value = Common.GetSum(row, 0, 43, 14);
            //dataGridView1.Rows[44].Cells[15].Value = Common.GetSum(row, 0, 43, 15);
           

            #endregion


        }
        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptRoutesOperatedByDTCEarningPerKillometer objFrm = new rptRoutesOperatedByDTCEarningPerKillometer(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcalculateTotal();
        }
    }
}
