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
    public partial class StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs : Form
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
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Particulars],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12] FROM [rpt].[tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs] where OsbId=@OsbId", con);
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
                    dataGridView1.DataSource = BindStatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs();
                }

                Common.SetRowNonEditable(dataGridView1, 2);
                Common.SetRowNonEditable(dataGridView1, 8);
                Common.SetRowNonEditable(dataGridView1, 17);
                Common.SetRowNonEditable(dataGridView1, 18);
                Common.SetRowNonEditable(dataGridView1, 30);
                Common.SetRowNonEditable(dataGridView1, 46);
                Common.SetRowNonEditable(dataGridView1, 50);
                Common.SetRowNonEditable(dataGridView1, 63);
                Common.SetRowNonEditable(dataGridView1, 64);
                Common.SetRowNonEditable(dataGridView1, 65);
                Common.SetRowNonEditable(dataGridView1, 66);

                Common.SetRowNonEditable(dataGridView1, 71);
                Common.SetRowNonEditable(dataGridView1, 72);
                Common.SetRowNonEditable(dataGridView1, 73);
                CalculateTotal();
            }
            catch (Exception ex)
            {

            }

        }
        public StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs(int OsbId, int Year, int Month, string finYear, string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;
        }
        DataTable BindStatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs()
        {

            DataTable table = new DataTable();

            // Static Columns

            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Particulars", typeof(string));
            table.Columns.Add("NCR (Low Floor AC buses)", typeof(string));
            table.Columns.Add("NCR (Low Floor AC buses) ", typeof(string));
            table.Columns.Add("NCR  (Low Floor Non AC buses)", typeof(string));
            table.Columns.Add("NCR (Low Floor Non AC buses)", typeof(string));
            table.Columns.Add("Foreign buses", typeof(string));
            table.Columns.Add("Foreign buses ", typeof(string));
            table.Columns.Add("Total Interest", typeof(string));
            table.Columns.Add("Total Interest  ", typeof(string));
            table.Columns.Add("Total (NCR) AC/Non AC Low  floor ", typeof(string));
            table.Columns.Add("Total (NCR) AC/Non AC Low floor ", typeof(string));
            table.Columns.Add("City (low Floor AC Electric buses )", typeof(string));
            table.Columns.Add("City (low Floor AC Electric buses)", typeof(string));

            //  table.Rows.Add(" ", " ", "Amt. (Rs. in lakhs) ", "Per Km (Paise) ", "Amt. (Rs. in lakhs)", "Per Km (Paise)", "Amt. (Rs. in lakhs)", "Per Km (Paise)", "Amt. (Rs. in lakhs)", "Per Km (Paise)", "Amt. (Rs. in lakhs)", "Per Km (Paise)", "Amt. (Rs. in lakhs)", "Per Km (Paise)" );

            // table.Rows.Add("i", "INCOME", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("i", "Ticketed Earning", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ii", "Less Passenger Tax", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iii", "Net Ticketed Earning (i-ii)", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iv", "Spl. Hire School Buses etc.", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("v", "Passenger composite fine", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("vi", "Sale of Passes ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("vii", "Free Trveling Lady commuters ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("viii", "Reimbursement against passes  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ix", "Total Traffic Earning (iii to viii)  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("x", "Sale of Scrap Mtl/Buses  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xi", "Interest earned  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xii", "Interest earned on equity/Plan loan  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xiii", "Advertisement fee (Excl. S. Tax & MCD Share)   ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xiv", "Rent Receipt  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xv", "Penalties LFB  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xvi", "I. D. Charges from Passes  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xvii", "Other Misc. Receipts  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xviii", "Total Misc. Income(x to xvii) ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total Income(ix +xviii) ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("ii", "Variable Cost ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("i", "H.S.D.OIL", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ii", "C.N.G. ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iii", "Lubricants", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iv", "Petrol", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("v", "Tyres ,Tubes & Flaps", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("vi", "Retreading Materials ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("vii", "Stores spare & Batteries ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("viii", "Tickets Material   ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ix", "Hire charges to Volvo Buses/PO  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("x", "AMC Charges for Low Floor", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total Variable cost (II) ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("iii", "Contribution ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iv", "Semi Veriable Cost ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("A", "Pay & Allowances ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("i", "Salaries & wages ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ii", "Children Education Allowance  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iii", "Transport Allowance (TA)", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iv", "Bonus", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("v", "Cont.to EPF & linked insurance", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("vi", "Payment to Pension", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("vii", "Gratuity", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("viii", "ESI Contribution", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ix", "Medical", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("x", "Welfare & L.T.C./TA", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xi", "Incentive to Drivers/conductors", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xii", "Uniform", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "TOTAL (A)", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("B", "Rent Rate & Taxes", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("i", "Road Tax.Adda Tax Permit Fee(GST) ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ii", "Property Tax/Ground Rent ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "TOTAL (B)", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("C", "Other Contingencies", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("i", "M.A.C.T/Third Party Insurance", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ii", "Electricity Water & Telephone", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iii", "Interest on O.D.& P.F dues ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iv", "Maintenance to buildings ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("v", "Out side Repair ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("vi", "Stationary & Forms", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("vii", "Legal Expenses ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("viii", "Publicity & Time Table ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ix", "Hire Charges of Staff Cars ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("x", "Other Misc. (CCTV)  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xi", "Interest on Equity/plan re-appropriated ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "TOTAL (C)", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "TOTAL (IV)(A+B+C) ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("v", "WORKING EXPENDITURE (II+IV) ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("vi", "Working Results(I-V) ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("vii", "Fixed Cost", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("i", "Depreciation on buses ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ii", "Depreciation on other assets  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iii", "Int.on G.N.C.T.D. loans ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "Total (VII)", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("viii", "Total Expenditure(V+VII) ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ix", "Total loss/Profit (I-VIII)  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");


            return table;
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
        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs", OsbId);
            dataGridView1.DataSource = BindStatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null || row.Cells[11].Value != null || row.Cells[12].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs]" +
                            "([OsbId],[S_No],[Particulars],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12]) VALUES (@OsbId,@S_No,@Particulars,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11,@Param12)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@S_No", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Particulars", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param6", row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param7", row.Cells[8].Value == null ? "" : row.Cells[8].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param8", row.Cells[9].Value == null ? "" : row.Cells[9].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param9", row.Cells[10].Value == null ? "" : row.Cells[10].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param10", row.Cells[11].Value == null ? "" : row.Cells[11].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param11", row.Cells[12].Value == null ? "" : row.Cells[12].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param12", row.Cells[13].Value == null ? "" : row.Cells[13].Value.ToString());

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

        private void StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
            // dataGridView1.DataSource = BindStatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs();
        }

        private void Print_ReportOnClick(object sender, EventArgs e)
        {
            rptStatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs objFrm = new rptStatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotal();
        }

        void CalculateTotal()
        {
            var row = dataGridView1.Rows;

            #region Calculating_VerticalSum
            for (int i = 0; i < (row.Count - 1); i++)
            {
                if (i == 2)
                {
                    for (int j = 2; j < 14; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Common.ConvertToDecimal(row[i - 2].Cells[j].Value.ToString()) - Common.ConvertToDecimal(row[i - 1].Cells[j].Value.ToString());
                    }
                }
                if (i == 8)
                {
                    for (int j = 2; j < 14; j++)
                    {
                        decimal cSum = 0;
                        for (int a = 2; a <= 7; a++)
                        {
                            cSum += Common.ConvertToDecimal(row[a].Cells[j].Value.ToString());
                        }

                        dataGridView1.Rows[i].Cells[j].Value = cSum;
                    }
                }

                if (i == 17)
                {
                    for (int j = 2; j < 14; j++)
                    {
                        decimal cSum = 0;
                        for (int a = 9; a <= 16; a++)
                        {
                            cSum += Common.ConvertToDecimal(row[a].Cells[j].Value.ToString());
                        }

                        dataGridView1.Rows[i].Cells[j].Value = cSum;
                    }
                }
                if (i == 18)
                {
                    for (int j = 2; j < 14; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Common.ConvertToDecimal(row[8].Cells[j].Value.ToString()) + Common.ConvertToDecimal(row[17].Cells[j].Value.ToString());
                    }
                }
                if (i == 30)
                {
                    for (int j = 2; j < 14; j++)
                    {
                        decimal cSum = 0;
                        for (int a = 20; a <= 29; a++)
                        {
                            cSum += Common.ConvertToDecimal(row[a].Cells[j].Value.ToString());
                        }

                        dataGridView1.Rows[i].Cells[j].Value = cSum;
                    }
                }

                if (i == 46)
                {
                    for (int j = 2; j < 14; j++)
                    {
                        decimal cSum = 0;
                        for (int a = 34; a <= 45; a++)
                        {
                            cSum += Common.ConvertToDecimal(row[a].Cells[j].Value.ToString());
                        }

                        dataGridView1.Rows[i].Cells[j].Value = cSum;
                    }
                }
                if (i == 50)
                {
                    for (int j = 2; j < 14; j++)
                    {
                        decimal cSum = 0;
                        for (int a = 48; a <= 50; a++)
                        {
                            cSum += Common.ConvertToDecimal(row[a].Cells[j].Value.ToString());
                        }

                        dataGridView1.Rows[i].Cells[j].Value = cSum;
                    }
                }

                if (i == 63)
                {
                    for (int j = 2; j < 14; j++)
                    {
                        decimal cSum = 0;
                        for (int a = 52; a <= 62; a++)
                        {
                            cSum += Common.ConvertToDecimal(row[a].Cells[j].Value.ToString());
                        }

                        dataGridView1.Rows[i].Cells[j].Value = cSum;
                    }
                }

                if (i == 64)
                {
                    for (int j = 2; j < 14; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Common.ConvertToDecimal(row[63].Cells[j].Value.ToString()) + Common.ConvertToDecimal(row[50].Cells[j].Value.ToString())+ Common.ConvertToDecimal(row[46].Cells[j].Value.ToString());
                    }
                }

                if (i == 65)
                {
                    for (int j = 2; j < 14; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Common.ConvertToDecimal(row[30].Cells[j].Value.ToString()) + Common.ConvertToDecimal(row[64].Cells[j].Value.ToString());
                    }
                }

                if (i == 66)
                {
                    for (int j = 2; j < 14; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Common.ConvertToDecimal(row[0].Cells[j].Value.ToString()) - Common.ConvertToDecimal(row[65].Cells[j].Value.ToString());
                    }
                }

                if (i == 71)
                {
                    for (int j = 2; j < 14; j++)
                    {
                        decimal cSum = 0;
                        for (int a = 68; a <= 70; a++)
                        {
                            cSum += Common.ConvertToDecimal(row[a].Cells[j].Value.ToString());
                        }

                        dataGridView1.Rows[i].Cells[j].Value = cSum;
                    }
                }

                if (i == 72)
                {
                    for (int j = 2; j < 14; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Common.ConvertToDecimal(row[65].Cells[j].Value.ToString()) - Common.ConvertToDecimal(row[71].Cells[j].Value.ToString());
                    }
                }
                if (i == 73)
                {
                    for (int j = 2; j < 14; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Common.ConvertToDecimal(row[0].Cells[j].Value.ToString()) - Common.ConvertToDecimal(row[72].Cells[j].Value.ToString());
                    }
                }
            }
            #endregion


        }
    }
}
