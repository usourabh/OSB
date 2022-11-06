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
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7] FROM [rpt].[tbl_ComparativeFinancialResultsFrom] where OsbId=@OsbId", con);
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
                    dataGridView1.DataSource = BindComparativeFinancialResultsFrom();
                }
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


            table.Columns.Add(Year+"-"+previousYear, typeof(string));
            table.Columns.Add(Year+"- "+previousYear, typeof(string));
           // table.Columns.Add("2018-19 ", typeof(string));
           // table.Columns.Add("2018-19", typeof(string));
            table.Columns.Add(previousYear+"-"+previousYear1, typeof(string));
            table.Columns.Add(previousYear+"-  "+previousYear1, typeof(string));
            // table.Columns.Add("2019-20    ", typeof(string));
            //table.Columns.Add("2020-21", typeof(string));
            //table.Columns.Add("2020-21  ", typeof(string));
            table.Columns.Add(previousYear1 + "-" + previousYear2, typeof(string));
            table.Columns.Add(previousYear1 + "-  " + previousYear2, typeof(string));

            //Row here.......

           // table.Rows.Add("", "", "Amt (Rs In Lakhs)", "Per Km.(Paise)", "Amt (Rs In Lakhs)", "Per Km.(Paise)", "Amt (Rs In Lakhs)", "Per Km.(Paise)");
           // table.Rows.Add("I", "INCOME", "", "", "", "", "", "");
            table.Rows.Add("i", "Ticketed Earning", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ii", "Less Passenger Tax", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iii", "Net Ticketed Earning (i-ii)", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iv", "Contract Service ( School Buses etc.)", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("v", "Earning from passes & season tkts.", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("vi", "Rrimbursesment concessional passes", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("vii", "Subsidy against Free Travelling to Lady Commut.", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("viii ", "Passenger Conposite Fine", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ix ", "Total Traffic Earning (iii to viii) ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("x", "Sale of Scrap Mtl/Buses ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xi", "Interest Earned on equity/Plan loan", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xii", "Interest earned", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xiii", "Advertisement fee.", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xiv", "Rent Receipt", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xv", "Penalties LFB ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xvi", "I. D. Charges from Passes", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xvii", "Other Misc. Receipts", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xviii", "Grants- in-Aid (Revenue)", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xix", "Total Misc. Income(x to xvii)", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total Income(ix +xix)", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("II ", "Variable Cost", "", "", "", "", "", "");
            table.Rows.Add("i ", "H.S.D.OIL", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ii ", "C.N.G.", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iii ", "Lubricants", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iv ", "Petrol", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("v ", "Tyres ,Tubes & Flaps", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("vi", "Retd. Materials", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("vii", "Stores spare & Batteries", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("viii ", "Tickets ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ix ", "Hire charges to Volvo/ PO Buses  ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("x", "AMC Charges for Low Floor Buses  ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xi", "Damage/ Accidentical Charges LFB", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total Variable cost (II)", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("III", "Contribution ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("IV", "Semi Veriable Cost ", "", "", "", "", "", "");
            table.Rows.Add("A", "Pay & Allowances", "", "", "", "", "", "");
            table.Rows.Add("i", "Salary & Wages", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ii ", "Provision for 7th Pay Commission", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iii ", "Bonus", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iv ", "Children Education Allowance", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("v ", "Cont. to EPF & linked insurance", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("vi ", "Gratuity", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("vii  ", "Payment to pansion", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("viii  ", "ESI Contribution ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ix  ", "medical", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ix  ", "Incentive to Drivers/contractual Staff", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("x  ", "Welfare & LTC/TA", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xi  ", "Uniform", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "TOTAL (A)", "0", "0", "0", "0", "0", "0");///
            table.Rows.Add("B ", "Rent Rate & Taxes", "", "", "", "", "", "");
            table.Rows.Add("i ", "Road Tax/Adda Tax/ Permit fee/S.Tax on AC ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ii", "Property Tax/Ground Rent ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "TOTAL (B) ", "0", "0", "0", "0", "0", "0");//
            table.Rows.Add("C ", "Other Contingencies ", "", "", "", "", "", "");
            table.Rows.Add("i ", "Contribution to RIF/M.A.C.T.", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ii ", "Third Party Insurance ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iii ", "Elect. Water & Telephone ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "Interest on O.D , PF dues & Others  ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iv", "Maintenance to Buildings ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("v", "Out side Repair ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("vi", "Stationary & Forms ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("vii ", "Legal Expenses", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ix ", "Hire Charges of Staff Cars", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("x ", "Other Misc.", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("xi ", "Interest on Equity/plan re-appropriated", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total (C)", "0", "0", "0", "0", "0", "0");///
            table.Rows.Add("", "TOTAL (IV)(A+B+C)", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("V", "WORKING EXPENDITURE (II+IV) ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("VI", "Working Loss / Profit(I-V) ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("VII ", "Fixed Cost ", "", "", "", "", "", "");////
            table.Rows.Add(" ", " ", "", "", "", "", "", "");////
            table.Rows.Add("i ", "Depreciation on buses ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("ii", "Depreciation on other Assets", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iii", "Int.on G.N.C.T.D. loans", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iv", "Loss on Deleted buses", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("0", "Total (VII)", "0", "0", "0", "0", "0", "0");///
            table.Rows.Add("VIII ", "Total (VII)", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("IX ", "Total loss/Profit (I-VIII) ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("X ", "prior Period Adj./Interest Utilized", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("XI ", "Net Loss/ Profit", "0", "0", "0", "0", "0", "0");


            return table;
        }
        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_ComparativeFinancialResultsFrom", OsbId);
            dataGridView1.DataSource = BindComparativeFinancialResultsFrom();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_ComparativeFinancialResultsFrom", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null ||row.Cells[6].Value!=null || row.Cells[6].Value != null)
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
          dataGridView1.DataSource = BindComparativeFinancialResultsFrom();
            BindIndexPage(OsbId);
        }

        private void Print_ReportOnClick(object sender, EventArgs e)
        {
            
                rptComparativeFinancialResultsFrom objFrm = new rptComparativeFinancialResultsFrom(OsbId, Year, Month, finYear, MonthName);
                 objFrm.Show();
        }
    }
}
