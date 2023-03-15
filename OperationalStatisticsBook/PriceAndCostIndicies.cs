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
    public partial class PriceAndCostIndicies : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);

        public PriceAndCostIndicies(int OsbId, int Year, int Month, string finYear, string MonthName)
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

        void ShowData()
        {
            DateTime currentDate = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate.AddYears(+1);
            string currentYear = newDate.Year.ToString();
            String previousMonthName = newDate.ToString("MMMM");
            String[,] param = new string[,]
                    {
                    //{"@OsbId",OsbId.ToString()},
                    //remove below line if you want to remove hardcore osbid
                    {"@OsbId", "5"},
            };
            DataTable dt = Common.ExecuteProcedure("SP_rptPriceAndCostIndices", param);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                Save.BackColor = Color.Green;
            }
            else
            {
                dataGridView1.DataSource = BindPriceAndCostIndicies();
            }
            Common.SetRowNonEditable(dataGridView1, 0);
            Common.SetRowNonEditable(dataGridView1, 1);
            Common.SetRowNonEditable(dataGridView1, 2);
            Common.SetRowNonEditable(dataGridView1, 3);
            Common.SetRowNonEditable(dataGridView1, 4);
        }
        DataTable BindPriceAndCostIndicies()
        {
            DataTable table = new DataTable();



            table.Columns.Add("Year", typeof(string));
            table.Columns.Add("Price Per 100 KG (Rs.)", typeof(string));
            table.Columns.Add("Indicies", typeof(string));
            table.Columns.Add("CPKM (P)", typeof(string));
            table.Columns.Add("Indicies ", typeof(string));
            table.Columns.Add("Price Tyre (Rs.)", typeof(string));
            table.Columns.Add("Indicies  ", typeof(string));
            table.Columns.Add("CPKM (P) ", typeof(string));
            table.Columns.Add("Indicies    ", typeof(string));
            //Rows data
            //  table.Rows.Add("", "Fuel-Lubricant", "Fuel-Lubricant", "Fuel-Lubricant", "Fuel-Lubricant", "Tyres,Tubes & Retd. Material", "Tyres,Tubes & Retd. Material", "Tyres,Tubes & Retd. Material", "Tyres,Tubes & Retd. Material");
            // table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9");
            DateTime currentDate = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate.AddYears(-1);
            DateTime newDate2 = currentDate.AddYears(0);
            string currentYear = currentDate.AddYears(+2).ToString();
            String previousMonthName = newDate.ToString("MMMM");

            //for (int i = 5; i > 0; i--)
            //{
            //    table.Rows.Add(newDate.AddYears(-i).Year + "-" + newDate2.AddYears(-i).Year, "0", "0", "0", "0", "0", "0", "0", "0");
            //}

            table.Rows.Add("2016-2017", " ", " ", " ", " ", " ", " ", " ", " ");
            table.Rows.Add("2017-2018", " ", " ", " ", " ", " ", " ", " ", " ");
            table.Rows.Add("2018-2019", " ", " ", " ", " ", " ", " ", " ", " ");
            table.Rows.Add("2019-2020", " ", " ", " ", " ", " ", " ", " ", " ");
            table.Rows.Add("2020-2021", " ", " ", " ", " ", " ", " ", " ", " ");


            return table;
        }
        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_PriceAndCostIndicies", OsbId);
            dataGridView1.DataSource = BindPriceAndCostIndicies();
            MessageBox.Show("Done");
        }
        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_PriceAndCostIndicies", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_PriceAndCostIndicies] ([OsbId],[Year],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8]) VALUES (@OsbId,@Year,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8)", con);
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
        private void button1_Click(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_PriceAndCostIndicies", OsbId);
            dataGridView1.DataSource = BindPriceAndCostIndicies();
            MessageBox.Show("Done");
        }

        private void PriceAndCostIndicies_Load(object sender, EventArgs e)
        {
            ShowData();
            //dataGridView1.DataSource = BindPriceAndCostIndicies();
            // BindIndexPage(OsbId);
        }

        private void PrintReportOnClick(object sender, EventArgs e)
        {

            rptPriceAndCostIndicies objFrm = new rptPriceAndCostIndicies(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();

        }
    }
}