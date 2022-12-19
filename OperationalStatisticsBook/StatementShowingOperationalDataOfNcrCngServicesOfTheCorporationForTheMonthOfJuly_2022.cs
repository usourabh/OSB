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
    public partial class StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022 : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7],[Param8] FROM [rpt].[tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022] where OsbId=@OsbId", con);
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
                    dataGridView1.DataSource = BindStatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022();
                }

                Common.SetColumnNonEditable(dataGridView1, 6);
                Common.SetColumnNonEditable(dataGridView1, 7);
                Common.SetRowNonEditable(dataGridView1, 10);
                CalculateFormula();

            }
            catch (Exception ex)
            {

            }

        }

        DataTable BindStatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022()
        {
            DataTable table = new DataTable();

            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Particulars Of Services", typeof(string));
            table.Columns.Add("Avg.No. of buses on Road daily", typeof(string));
            table.Columns.Add("Total Kms. Opt", typeof(string));
            table.Columns.Add("Total Income(Rs.)", typeof(string));
            table.Columns.Add("Total Income(Rs.) ", typeof(string));
            table.Columns.Add("Earning per Km.", typeof(string));
            table.Columns.Add("Earning per Km. ", typeof(string));
            table.Columns.Add("Passengers Carried No", typeof(string));

            // Rows
           // table.Rows.Add("", "", "", "", "Including Passenger Tax", "Excluding Passenger Tax", "Including Passenger Tax", "Excluding Passenger Tax","");
           // table.Rows.Add("1", "2", "3", "4", "5", "6","7","8","9");
           // table.Rows.Add("Haryana", "", "", "", "", "","","","");
            table.Rows.Add("1", "Narela to Bahadur Garh (AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "Narela to Bahadur Garh (Non AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Karol Bagh to Gurgaon (AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Uttam Nagar to Gugaon VIA Dabri(Non AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Anand vihar to Gurgaon (Non AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "Anand vihar to Gurgaon (AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Badarpur to Gurgaon (Non AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "New Delhi railway station to Bahadur Garh(Non AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "New Delhi railway station to Bahadur Garh(AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "Karampura to Bahadur Garh(NonAC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "TOTAL", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "NCR PASS EARNING", " ", " ", "0", " ", " ", " ", "0");
            table.Rows.Add("INTERNATIONAL ROUTE", "", "", "", "", "", "", "", "");
            table.Rows.Add(" ", "DELHI to KATHMANDU", "0", "0", "0", "0", "0", "0", "0");


            return table;
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022", OsbId);
            CalculateFormula();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022] ([OsbId],[S_No],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8]) VALUES (@OsbId,@S_No,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@S_No", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
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

        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022", OsbId);
            dataGridView1.DataSource = BindStatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022();
            Common.SetColumnNonEditable(dataGridView1, 6);
            Common.SetColumnNonEditable(dataGridView1, 7);
            Common.SetRowNonEditable(dataGridView1, 10);
            MessageBox.Show("Done");
        }

        private void StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
            //dataGridView1.DataSource = BindStatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022();
        }

        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptStatementShowingOperationalDataOfNcrCngServicesOfTheCorporation objFrm = new rptStatementShowingOperationalDataOfNcrCngServicesOfTheCorporation(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        void CalculateFormula()
        {
            var row = dataGridView1.Rows;
            // Total

            dataGridView1.Rows[10].Cells[2].Value = Common.GetSum(row, 0, 8, 2);
            dataGridView1.Rows[10].Cells[3].Value = Common.GetSum(row, 0, 8, 3);
            dataGridView1.Rows[10].Cells[4].Value = Common.GetSum(row, 0, 8, 4);
            dataGridView1.Rows[10].Cells[5].Value = Common.GetSum(row, 0, 8, 5);
            dataGridView1.Rows[10].Cells[8].Value = Common.GetSum(row, 0, 8, 8);

            // column no 7
            
            dataGridView1.Rows[0].Cells[6].Value = Common.ConvertToDecimal(row[0].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[0].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[0].Cells[3].Value.ToString())) * 100, 0) : 0;
            dataGridView1.Rows[1].Cells[6].Value = Common.ConvertToDecimal(row[1].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[1].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[1].Cells[3].Value.ToString())) * 100, 0) : 0;
            dataGridView1.Rows[2].Cells[6].Value = Common.ConvertToDecimal(row[2].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[2].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[2].Cells[3].Value.ToString())) * 100, 0) : 0;
            dataGridView1.Rows[3].Cells[6].Value = Common.ConvertToDecimal(row[3].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[3].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[3].Value.ToString())) * 100, 0) : 0;
            dataGridView1.Rows[4].Cells[6].Value = Common.ConvertToDecimal(row[4].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[4].Cells[3].Value.ToString())) * 100, 0) : 0;
            dataGridView1.Rows[5].Cells[6].Value = Common.ConvertToDecimal(row[5].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[5].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[5].Cells[3].Value.ToString())) * 100, 0) : 0;
            dataGridView1.Rows[6].Cells[6].Value = Common.ConvertToDecimal(row[6].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[6].Cells[3].Value.ToString())) * 100, 0) : 0;
            dataGridView1.Rows[7].Cells[6].Value = Common.ConvertToDecimal(row[7].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[7].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[7].Cells[3].Value.ToString())) * 100, 0) : 0;
            dataGridView1.Rows[8].Cells[6].Value = Common.ConvertToDecimal(row[8].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[8].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[3].Value.ToString())) * 100, 0) : 0;
            dataGridView1.Rows[9].Cells[6].Value = Common.ConvertToDecimal(row[9].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[9].Cells[3].Value.ToString())) * 100, 0) : 0;

            // column no 8

            dataGridView1.Rows[0].Cells[7].Value = Common.ConvertToDecimal(row[0].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[0].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[0].Cells[3].Value.ToString())) * 100, 0) : 0;
            dataGridView1.Rows[1].Cells[7].Value = Common.ConvertToDecimal(row[1].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[1].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[1].Cells[3].Value.ToString())) * 100, 0) : 0;
            dataGridView1.Rows[2].Cells[7].Value = Common.ConvertToDecimal(row[2].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[2].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[2].Cells[3].Value.ToString())) * 100, 0) : 0;
            dataGridView1.Rows[3].Cells[7].Value = Common.ConvertToDecimal(row[3].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[3].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[3].Cells[3].Value.ToString())) * 100, 0) : 0;
            dataGridView1.Rows[4].Cells[7].Value = Common.ConvertToDecimal(row[4].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[4].Cells[3].Value.ToString())) * 100, 0) : 0;
            dataGridView1.Rows[5].Cells[7].Value = Common.ConvertToDecimal(row[5].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[5].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[5].Cells[3].Value.ToString())) * 100, 0) : 0;
            dataGridView1.Rows[6].Cells[7].Value = Common.ConvertToDecimal(row[6].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[6].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[6].Cells[3].Value.ToString())) * 100, 0) : 0;
            dataGridView1.Rows[7].Cells[7].Value = Common.ConvertToDecimal(row[7].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[7].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[7].Cells[3].Value.ToString())) * 100, 0) : 0;
            dataGridView1.Rows[8].Cells[7].Value = Common.ConvertToDecimal(row[8].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[8].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[8].Cells[3].Value.ToString())) * 100, 0) : 0;
            dataGridView1.Rows[9].Cells[7].Value = Common.ConvertToDecimal(row[9].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[9].Cells[3].Value.ToString())) * 100, 0) : 0;


        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateFormula();
        }
    }
}
