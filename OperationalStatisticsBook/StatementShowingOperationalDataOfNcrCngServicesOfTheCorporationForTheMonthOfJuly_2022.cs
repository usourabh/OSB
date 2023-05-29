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


                DataTable autoSpTable = new DataTable();
                if (dt.Rows.Count < 1)
                {
                    SqlCommand cmd1 = new SqlCommand("[dbo].[StatementShowingOperDataNCRCNGServicesCorporationOSB7_1]", con);
                    cmd1.Parameters.AddWithValue("@month", Month);
                    cmd1.Parameters.AddWithValue("@year", Year);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandTimeout = 350;
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                    sda1.Fill(autoSpTable);
                }

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    Save.BackColor = Color.Green;
                }

                else if (autoSpTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = BindStatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022_AutoSpTable(autoSpTable);
                }
                else
                {
                    dataGridView1.DataSource = BindStatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022();
                }

                setRowColNonEditable();
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
            table.Rows.Add("1", "Narela to Bahadur Garh (Non AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "Narela to Bahadur Garh (AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Karol Bagh to Gurgaon (Non AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "Karol Bagh to Gurgaon (AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Uttam Nagar to Gugaon VIA Dabri(Non AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Anand vihar to Gurgaon (Non AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Anand vihar to Gurgaon (AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "Badarpur to Gurgaon (Non AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "New Delhi railway station to Bahadur Garh(Non AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "New Delhi railway station to Bahadur Garh(AC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "Karampura to Bahadur Garh(NonAC)", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "TOTAL", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "NCR PASS EARNING", " ", " ", "0", " ", " ", " ", "0");
            table.Rows.Add("INTERNATIONAL ROUTE", "", "", "", "", "", "", "", "");
            table.Rows.Add(" ", "DELHI to KATHMANDU", "0", "0", "0", "0", "0", "0", "0");


            return table;
        }

        DataTable BindStatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022_AutoSpTable(DataTable sp)
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


            table.Rows.Add("1", sp.Rows[0]["ParticularOfServices"], sp.Rows[0]["AvgNoOfBusesOnRoadDaily"], sp.Rows[0]["TotalKmOpt"], sp.Rows[0]["TotalIncomeIncludingPassengerTax"], sp.Rows[0]["TotalIncomeExcludingPassengerTax"], sp.Rows[0]["EarningPerKmIncludingPassengerTax"], sp.Rows[0]["EarningPerKmExcludingPassengerTax"], sp.Rows[0]["PassengersCarriedNo"]);
            table.Rows.Add(" ", sp.Rows[1]["ParticularOfServices"], sp.Rows[1]["AvgNoOfBusesOnRoadDaily"], sp.Rows[1]["TotalKmOpt"], sp.Rows[1]["TotalIncomeIncludingPassengerTax"], sp.Rows[1]["TotalIncomeExcludingPassengerTax"], sp.Rows[1]["EarningPerKmIncludingPassengerTax"], sp.Rows[1]["EarningPerKmExcludingPassengerTax"], sp.Rows[1]["PassengersCarriedNo"]);
            table.Rows.Add("2", sp.Rows[2]["ParticularOfServices"], sp.Rows[2]["AvgNoOfBusesOnRoadDaily"], sp.Rows[2]["TotalKmOpt"], sp.Rows[2]["TotalIncomeIncludingPassengerTax"], sp.Rows[2]["TotalIncomeExcludingPassengerTax"], sp.Rows[2]["EarningPerKmIncludingPassengerTax"], sp.Rows[2]["EarningPerKmExcludingPassengerTax"], sp.Rows[2]["PassengersCarriedNo"]);
            table.Rows.Add(" ", sp.Rows[3]["ParticularOfServices"], sp.Rows[3]["AvgNoOfBusesOnRoadDaily"], sp.Rows[3]["TotalKmOpt"], sp.Rows[3]["TotalIncomeIncludingPassengerTax"], sp.Rows[3]["TotalIncomeExcludingPassengerTax"], sp.Rows[3]["EarningPerKmIncludingPassengerTax"], sp.Rows[3]["EarningPerKmExcludingPassengerTax"], sp.Rows[3]["PassengersCarriedNo"]);
            table.Rows.Add("3", sp.Rows[4]["ParticularOfServices"], sp.Rows[4]["AvgNoOfBusesOnRoadDaily"], sp.Rows[4]["TotalKmOpt"], sp.Rows[4]["TotalIncomeIncludingPassengerTax"], sp.Rows[4]["TotalIncomeExcludingPassengerTax"], sp.Rows[4]["EarningPerKmIncludingPassengerTax"], sp.Rows[4]["EarningPerKmExcludingPassengerTax"], sp.Rows[4]["PassengersCarriedNo"]);
            table.Rows.Add("4", sp.Rows[5]["ParticularOfServices"], sp.Rows[5]["AvgNoOfBusesOnRoadDaily"], sp.Rows[5]["TotalKmOpt"], sp.Rows[5]["TotalIncomeIncludingPassengerTax"], sp.Rows[5]["TotalIncomeExcludingPassengerTax"], sp.Rows[5]["EarningPerKmIncludingPassengerTax"], sp.Rows[5]["EarningPerKmExcludingPassengerTax"], sp.Rows[5]["PassengersCarriedNo"]);
            table.Rows.Add("5", sp.Rows[6]["ParticularOfServices"], sp.Rows[6]["AvgNoOfBusesOnRoadDaily"], sp.Rows[6]["TotalKmOpt"], sp.Rows[6]["TotalIncomeIncludingPassengerTax"], sp.Rows[6]["TotalIncomeExcludingPassengerTax"], sp.Rows[6]["EarningPerKmIncludingPassengerTax"], sp.Rows[6]["EarningPerKmExcludingPassengerTax"], sp.Rows[6]["PassengersCarriedNo"]);
            table.Rows.Add("6", sp.Rows[7]["ParticularOfServices"], sp.Rows[7]["AvgNoOfBusesOnRoadDaily"], sp.Rows[7]["TotalKmOpt"], sp.Rows[7]["TotalIncomeIncludingPassengerTax"], sp.Rows[7]["TotalIncomeExcludingPassengerTax"], sp.Rows[7]["EarningPerKmIncludingPassengerTax"], sp.Rows[7]["EarningPerKmExcludingPassengerTax"], sp.Rows[7]["PassengersCarriedNo"]);
            table.Rows.Add("7", sp.Rows[8]["ParticularOfServices"], sp.Rows[8]["AvgNoOfBusesOnRoadDaily"], sp.Rows[8]["TotalKmOpt"], sp.Rows[8]["TotalIncomeIncludingPassengerTax"], sp.Rows[8]["TotalIncomeExcludingPassengerTax"], sp.Rows[8]["EarningPerKmIncludingPassengerTax"], sp.Rows[8]["EarningPerKmExcludingPassengerTax"], sp.Rows[8]["PassengersCarriedNo"]);
            table.Rows.Add(" ", sp.Rows[9]["ParticularOfServices"], sp.Rows[9]["AvgNoOfBusesOnRoadDaily"], sp.Rows[9]["TotalKmOpt"], sp.Rows[9]["TotalIncomeIncludingPassengerTax"], sp.Rows[9]["TotalIncomeExcludingPassengerTax"], sp.Rows[9]["EarningPerKmIncludingPassengerTax"], sp.Rows[9]["EarningPerKmExcludingPassengerTax"], sp.Rows[9]["PassengersCarriedNo"]);
            table.Rows.Add(" ", sp.Rows[10]["ParticularOfServices"], sp.Rows[10]["AvgNoOfBusesOnRoadDaily"], sp.Rows[10]["TotalKmOpt"], sp.Rows[10]["TotalIncomeIncludingPassengerTax"], sp.Rows[10]["TotalIncomeExcludingPassengerTax"], sp.Rows[10]["EarningPerKmIncludingPassengerTax"], sp.Rows[10]["EarningPerKmExcludingPassengerTax"], sp.Rows[10]["PassengersCarriedNo"]);
            //
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
            setRowColNonEditable();
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

            dataGridView1.Rows[11].Cells[2].Value = Common.GetSum(row, 0, 10, 2);
            dataGridView1.Rows[11].Cells[3].Value = Common.GetSum(row, 0, 10, 3);
            dataGridView1.Rows[11].Cells[4].Value = Common.GetSum(row, 0, 10, 4);
            dataGridView1.Rows[11].Cells[5].Value = Common.GetSum(row, 0, 10, 5);
            dataGridView1.Rows[11].Cells[8].Value = Common.GetSum(row, 0, 10, 8);


            for (int i = 0; i <= 10; i++)
            {
                // column no 7

                dataGridView1.Rows[i].Cells[6].Value = Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[3].Value.ToString())) * 100, 0) : 0;

                // column no 8
                dataGridView1.Rows[i].Cells[7].Value = Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[i].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[3].Value.ToString())) * 100, 0) : 0;
            }

        }

        private void setRowColNonEditable()
        {
            Common.SetColumnNonEditable(dataGridView1, 6);
            Common.SetColumnNonEditable(dataGridView1, 7);

            Common.SetRowNonEditable(dataGridView1, 11);
            Common.SetRowNonEditable(dataGridView1, 13);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateFormula();
        }
    }
}
