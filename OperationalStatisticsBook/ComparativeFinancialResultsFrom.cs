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
    public partial class ComparativeFinancialResultsFrom
 : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "0";
        string finYear = "0";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public ComparativeFinancialResultsFrom(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                    SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7] FROM [rpt].[tbl_ComparativeFinancialResultsFrom] where OsbId=@OsbId", con);
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
                        dataGridView1.DataSource = BindComparativeFinancialResultsFrom();
                    }
                }

                else if (finYear == "2023-24")
                {
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7] FROM [rpt].[tbl_ComparativeFinancialResultsFrom] where OsbId=@OsbId", con);
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
                        dataGridView1.DataSource = BindComparativeFinancialResultsFrom();
                    }
                }

                SetRowColNonEditable();
                CalculateFormula();

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

        DataTable BindComparativeFinancialResultsFrom()
        {
            DataTable table = new DataTable();
            DateTime currentDate = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate.AddYears(+1);
            DateTime newDate1 = currentDate.AddYears(+2);
            DateTime newDate2 = currentDate.AddYears(+3);
            int currentYear = currentDate.Year;
            int previousYear = newDate.Year;
            int previousYear1 = newDate1.Year;
            int previousYear2 = newDate2.Year;
            String previousMonthName = newDate.ToString("MMMM");


            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Particulars", typeof(string));


            table.Columns.Add(GlobalMaster.FinMaster[4].FinVal, typeof(string));
            table.Columns.Add(GlobalMaster.FinMaster[4].FinVal + " ", typeof(string));

            table.Columns.Add(GlobalMaster.FinMaster[3].FinVal, typeof(string));
            table.Columns.Add(GlobalMaster.FinMaster[3].FinVal + " ", typeof(string));

            table.Columns.Add(GlobalMaster.FinMaster[2].FinVal, typeof(string));
            table.Columns.Add(GlobalMaster.FinMaster[2].FinVal + " ", typeof(string));

            //Row here.......

            // table.Rows.Add("", "", "Amt (Rs In Lakhs)", "Per Km.(Paise)", "Amt (Rs In Lakhs)", "Per Km.(Paise)", "Amt (Rs In Lakhs)", "Per Km.(Paise)");
            // table.Rows.Add("I", "INCOME", "", "", "", "", "", "");
            //-----------------------------------------------------------------

            table.Rows.Add("i", "Ticketed Earning", "", "", "", "", "", "");
            table.Rows.Add("ii", "Less Passenger Tax", "", "", "", "", "", "");
            table.Rows.Add("iii", "Net Ticketed Earning (i-ii)", "", "", "", "", "", "");
            table.Rows.Add("iv", "Contract Service ( School Buses etc.)", "", "", "", "", "", "");
            table.Rows.Add("v", "Earning from passes & season tkts.", "", "", "", "", "", "");
            table.Rows.Add("vi", "Rrimbursesment concessional passes", "", "", "", "", "", "");
            table.Rows.Add("vii", "Subsidy against Free Travelling to Lady Commut.", "", "", "", "", "", "");
            table.Rows.Add("viii ", "Passenger Conposite Fine", "", "", "", "", "", "");
            table.Rows.Add("ix ", "Total Traffic Earning (iii to viii) ", "", "", "", "", "", "");
            table.Rows.Add("x", "Sale of Scrap Mtl/Buses ", "", "", "", "", "", "");
            table.Rows.Add("xi", "Interest Earned on equity/Plan loan", "", "", "", "", "", "");
            table.Rows.Add("xii", "Interest earned", "", "", "", "", "", "");
            table.Rows.Add("xiii", "Advertisement fee.", "", "", "", "", "", "");
            table.Rows.Add("xiv", "Rent Receipt", "", "", "", "", "", "");
            table.Rows.Add("xv", "Penalties LFB ", "", "", "", "", "", "");
            table.Rows.Add("xvi", "I. D. Charges from Passes", "", "", "", "", "", "");
            table.Rows.Add("xvii", "Other Misc. Receipts", "", "", "", "", "", "");
            table.Rows.Add("xviii", "Grants- in-Aid (Revenue)", "", "", "", "", "", "");
            table.Rows.Add("xix", "Total Misc. Income(x to xvii)", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total Income(ix +xix)", "0", "0", "0", "0", "0", "0");


            table.Rows.Add("II ", "VARIABLE COST", "", "", "", "", "", "");

            table.Rows.Add("i ", "H.S.D.OIL", "", "", "", "", "", "");
            table.Rows.Add("ii ", "C.N.G.", "", "", "", "", "", "");
            table.Rows.Add("iii ", "Lubricants", "", "", "", "", "", "");
            table.Rows.Add("iv ", "Petrol", "13.55", "", "", "", "", "");
            table.Rows.Add("v ", "Tyres ,Tubes & Flaps", "", "", "", "", "", "");
            table.Rows.Add("vi", "Retd. Materials", "", "", "", "", "", "");
            table.Rows.Add("vii", "Stores spare & Batteries", "", "", "", "", "", "");
            table.Rows.Add("viii ", "Tickets ", "", "", "", "", "", "");
            table.Rows.Add("ix ", "Hire charges to Volvo/ PO Buses  ", "", "", "", "", "", "");
            table.Rows.Add("x", "AMC Charges for Low Floor Buses  ", "", "", "", "", "", "");
            table.Rows.Add("xi", "Damage/ Accidentical Charges LFB", "", "", "", "", "", "");
            table.Rows.Add("", "Total Variable cost (II)", "", "", "", "", "", "");


            table.Rows.Add("III", "Contribution ", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("IV", "SEMI VARIABLE COST", "", "", "", "", "", "");

            table.Rows.Add("A", "PAY & ALLOWANCES", "", "", "", "", "", "");

            table.Rows.Add("i", "Salary & Wages", "", "", "", "", "", "");
            table.Rows.Add("ii ", "Provision for 7th Pay Commission", "", "", "", "", "", "");
            table.Rows.Add("iii ", "Bonus", "", "", "", "", "", "");
            table.Rows.Add("iv ", "Children Education Allowance", "", "", "", "", "", "");
            table.Rows.Add("v ", "Cont. to EPF & linked insurance", "", "", "", "", "", "");
            table.Rows.Add("vi ", "Gratuity", "", "", "", "", "", "");
            table.Rows.Add("vii  ", "Payment to pansion", "", "", "", "", "", "");
            table.Rows.Add("viii  ", "ESI Contribution ", "", "", "", "", "", "");
            table.Rows.Add("ix  ", "medical", "", "", "", "", "", "");
            table.Rows.Add("ix  ", "Incentive to Drivers/contractual Staff", "", "", "", "", "", "");
            table.Rows.Add("x  ", "Welfare & LTC/TA", "", "", "", "", "", "");
            table.Rows.Add("xi  ", "Uniform", "", "", "", "", "", "");
            table.Rows.Add("", "TOTAL (A)", "0", "0", "0", "0", "0", "0");


            table.Rows.Add("B ", "RENT RATE & TAXES", "", "", "", "", "", "");

            table.Rows.Add("i ", "Road Tax/Adda Tax/ Permit fee/S.Tax on AC ", "", "", "", "", "", "");
            table.Rows.Add("ii", "Property Tax/Ground Rent ", "", "", "", "", "", "");
            table.Rows.Add("", "TOTAL (B) ", "0", "0", "0", "0", "0", "0");


            table.Rows.Add("C ", "OTHER CONTINGENCIES", "", "", "", "", "", "");

            table.Rows.Add("i ", "Contribution to RIF/M.A.C.T.", "", "", "", "", "", "");
            table.Rows.Add("ii ", "Third Party Insurance ", "", "", "", "", "", "");
            table.Rows.Add("iii ", "Elect. Water & Telephone ", "", "", "", "", "", "");
            table.Rows.Add(" ", "Interest on O.D , PF dues & Others  ", "", "", "", "", "", "");
            table.Rows.Add("iv", "Maintenance to Buildings ", "", "", "", "", "", "");
            table.Rows.Add("v", "Out side Repair ", "", "", "", "", "", "");
            table.Rows.Add("vi", "Stationary & Forms ", "", "", "", "", "", "");
            table.Rows.Add("vii ", "Legal Expenses", "", "", "", "", "", "");
            table.Rows.Add("viii ", "Publicity & Time Table", "", "", "", "", "", "");
            table.Rows.Add("ix ", "Hire Charges of Staff Cars", "", "", "", "", "", "");
            table.Rows.Add("x ", "Other Misc.", "", "", "", "", "", "");
            table.Rows.Add("xi ", "Interest on Equity/plan re-appropriated", "", "", "", "", "", "");
            table.Rows.Add("", "Total (C)", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "TOTAL (IV)(A+B+C)", "0", "0", "0", "0", "0", "0");


            table.Rows.Add("V", "WORKING EXPENDITURE (II+IV) ", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("VI", "Working Loss / Profit(I-V) ", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("VII ", "Fixed Cost ", "", "", "", "", "", "");
            table.Rows.Add(" ", " ", "", "", "", "", "", "");

            table.Rows.Add("i ", "Depreciation on buses ", "", "", "", "", "", "");
            table.Rows.Add("ii", "Depreciation on other Assets", "", "", "", "", "", "");
            table.Rows.Add("iii", "Int.on G.N.C.T.D. loans", "", "", "", "", "", "");
            table.Rows.Add("iv", "Loss on Deleted buses", "", "", "", "", "", "");

            table.Rows.Add(" ", "Total (VII)", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("VIII ", "Total Expenditure (V + VII)", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("IX ", "Total loss/Profit (I-VIII) ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("X ", "prior Period Adj./Interest Utilized", "", "", "", "", "", "");
            table.Rows.Add("XI ", "Net Loss/ Profit", "0", "0", "0", "0", "0", "0");






            return table;
        }

        private void ResetOnClick(object sender, EventArgs e)
        {
            //DeleteExisitingTableRecord("tbl_ComparativeFinancialResultsFrom", OsbId);
            //dataGridView1.DataSource = BindComparativeFinancialResultsFrom();
            CalculateFormula();
            SetRowColNonEditable();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_ComparativeFinancialResultsFrom", OsbId);

            CalculateFormula();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[6].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_ComparativeFinancialResultsFrom] ([OsbId],[S_No],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7]) VALUES (@OsbId,@S_No,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7)", con);
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

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_ComparativeFinancialResultsFrom", OsbId);
            dataGridView1.DataSource = BindComparativeFinancialResultsFrom();
            MessageBox.Show("Done");
        }

        private void ComparativeFinancialResultsFrom_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = BindComparativeFinancialResultsFrom();
            BindIndexPage(OsbId);
        }

        private void Print_ReportOnClick(object sender, EventArgs e)
        {
            rptComparativeFinancialResultsFrom objFrm = new rptComparativeFinancialResultsFrom(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        void CalculateFormula()
        {
            var row = dataGridView1.Rows;
            //Common.SetRowNonEditable(dataGridView1, 2);



            for (int i = 2; i <= 7; i++)
            {

                // NET TICKET EARNING TOTAL
                dataGridView1.Rows[2].Cells[i].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[0].Cells[i].Value.ToString()) - Common.ConvertToDecimal(dataGridView1.Rows[1].Cells[i].Value.ToString()), 2);
                // TOTAL TRAFFIC EARNING iii to Viii
                dataGridView1.Rows[8].Cells[i].Value = Math.Round(Common.GetSum(row, 2, 7, i), 2);
                //Total misc income (x to xvii)
                dataGridView1.Rows[18].Cells[i].Value = Math.Round(Common.GetSum(row, 9, 17, i), 2);
                // Total income (ix + xix)
                dataGridView1.Rows[19].Cells[i].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[8].Cells[i].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[18].Cells[i].Value.ToString()), 2);
                //Total variable cost (II)
                dataGridView1.Rows[32].Cells[i].Value = Math.Round(Common.GetSum(row, 21, 31, i), 2);
                // contribution              
                dataGridView1.Rows[33].Cells[i].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[19].Cells[i].Value.ToString()) - Common.ConvertToDecimal(dataGridView1.Rows[32].Cells[i].Value.ToString()), 2);
                // Total A                   
                dataGridView1.Rows[48].Cells[i].Value = Math.Round(Common.GetSum(row, 36, 47, i), 2);
                // Total B                   
                dataGridView1.Rows[52].Cells[i].Value = Math.Round(Common.GetSum(row, 50, 51, i), 2);
                // Total C
                dataGridView1.Rows[66].Cells[i].Value = Math.Round(Common.GetSum(row, 54, 65, i), 2);
                // Total (IV)=(A+B+C)
                dataGridView1.Rows[67].Cells[i].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[48].Cells[i].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[52].Cells[i].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[66].Cells[i].Value.ToString()), 2);
                //WORKING EXPENDITURE (II + IV)
                dataGridView1.Rows[68].Cells[i].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[32].Cells[i].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[67].Cells[i].Value.ToString()), 2);
                // WORKING LOSS / PROFIT (I-V)
                dataGridView1.Rows[69].Cells[i].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[19].Cells[i].Value.ToString()) - Common.ConvertToDecimal(dataGridView1.Rows[68].Cells[i].Value.ToString()), 2);
                // TOTAL (VII)
                dataGridView1.Rows[76].Cells[i].Value = Math.Round(Common.GetSum(row, 72, 75, i), 2);
                //TOTAL EXPENDITURE (V+VII)
                dataGridView1.Rows[77].Cells[i].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[68].Cells[i].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[76].Cells[i].Value.ToString()), 2);
                // Total loss/profit (I-VIII)
                dataGridView1.Rows[78].Cells[i].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[19].Cells[i].Value.ToString()) - Common.ConvertToDecimal(dataGridView1.Rows[77].Cells[i].Value.ToString()), 2);

            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // CalculateFormula();
        }

        private void SetRowColNonEditable()
        {
            Common.SetRowNonEditable(dataGridView1, 2);
            Common.SetRowNonEditable(dataGridView1, 8);
            Common.SetRowNonEditable(dataGridView1, 18);
            Common.SetRowNonEditable(dataGridView1, 19);
            Common.SetRowNonEditable(dataGridView1, 32);
            Common.SetRowNonEditable(dataGridView1, 33);
            Common.SetRowNonEditable(dataGridView1, 48);
            Common.SetRowNonEditable(dataGridView1, 52);
            Common.SetRowNonEditable(dataGridView1, 66);
            Common.SetRowNonEditable(dataGridView1, 67);
            Common.SetRowNonEditable(dataGridView1, 68);
            Common.SetRowNonEditable(dataGridView1, 69);
            Common.SetRowNonEditable(dataGridView1, 76);
            Common.SetRowNonEditable(dataGridView1, 77);
            Common.SetRowNonEditable(dataGridView1, 78);
        }
    }
}
