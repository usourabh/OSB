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

            table.Rows.Add(" ", " ", "Amt. (Rs. in lakhs) ", "Per Km (Paise) ", "Amt. (Rs. in lakhs)", "Per Km (Paise)", "Amt. (Rs. in lakhs)", "Per Km (Paise)", "Amt. (Rs. in lakhs)", "Per Km (Paise)", "Amt. (Rs. in lakhs)", "Per Km (Paise)", "Amt. (Rs. in lakhs)", "Per Km (Paise)" );
            
            table.Rows.Add("i", "INCOME", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
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
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null || row.Cells[11].Value != null || row.Cells[12].Value != null  )
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
            dataGridView1.DataSource = BindStatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs();
        }

        private void Print_ReportOnClick(object sender, EventArgs e)
        {
            rptStatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs objFrm = new rptStatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }
    }
}
