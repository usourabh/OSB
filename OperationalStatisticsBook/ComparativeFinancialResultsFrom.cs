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


            table.Columns.Add(Year + "-" + previousYear, typeof(string));
            table.Columns.Add(Year + "- " + previousYear, typeof(string));
            // table.Columns.Add("2018-19 ", typeof(string));
            // table.Columns.Add("2018-19", typeof(string));
            table.Columns.Add(previousYear + "-" + previousYear1, typeof(string));
            table.Columns.Add(previousYear + "-  " + previousYear1, typeof(string));
            // table.Columns.Add("2019-20    ", typeof(string));
            //table.Columns.Add("2020-21", typeof(string));
            //table.Columns.Add("2020-21  ", typeof(string));
            table.Columns.Add(previousYear1 + "-" + previousYear2, typeof(string));
            table.Columns.Add(previousYear1 + "-  " + previousYear2, typeof(string));

            //Row here.......

            // table.Rows.Add("", "", "Amt (Rs In Lakhs)", "Per Km.(Paise)", "Amt (Rs In Lakhs)", "Per Km.(Paise)", "Amt (Rs In Lakhs)", "Per Km.(Paise)");
            // table.Rows.Add("I", "INCOME", "", "", "", "", "", "");
            //-----------------------------------------------------------------

            table.Rows.Add("i", "Ticketed Earning", "53298.57", "2272.62", "46854.78", "2048.32", "16712.91", "880.15");
            table.Rows.Add("ii", "Less Passenger Tax", "161.25", "6.89", "166.05", "7.27", "12.50", "0.66");
            table.Rows.Add("iii", "Net Ticketed Earning (i-ii)", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("iv", "Contract Service ( School Buses etc.)", "7066.48", "301.97", "6775.59", "296.74", "14159.28", "745.66");
            table.Rows.Add("v", "Earning from passes & season tkts.", "11135.08", "475.84", "9887.63", "433.03", "3342.59", "176.03");
            table.Rows.Add("vi", "Rrimbursesment concessional passes", "6153.50", "262.96", "5097.64", "223.25", "1840.01", "96.90");
            table.Rows.Add("vii", "Subsidy against Free Travelling to Lady Commut.", "0.00", "0.00", "10575.72", "462.33", "9284.12", "488.93");
            table.Rows.Add("viii ", "Passenger Conposite Fine", "265.05", "11.30", "219.00", "9.57", "115.37", "6.08");
            table.Rows.Add("ix ", "Total Traffic Earning (iii to viii) ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("x", "Sale of Scrap Mtl/Buses ", "1139.68", "48.70", "343.07", "15.02", "394.97", "20.80");
            table.Rows.Add("xi", "Interest Earned on equity/Plan loan", "2413.10", "103.12", "2351.36", "102.98", "201.80", "10.63");
            table.Rows.Add("xii", "Interest earned", "1604.49", "68.56", "899.97", "39.41", "580.07", "30.55");
            table.Rows.Add("xiii", "Advertisement fee.", "31.46", "1.34", "292.58", "12.81", "107.97", "5.69");
            table.Rows.Add("xiv", "Rent Receipt", "3100.17", "132.48", "3489.85", "152.84", "3381.49", "178.08");
            table.Rows.Add("xv", "Penalties LFB ", "133.22", "5.69", "365.74", "16.02", "22.97", "1.21");
            table.Rows.Add("xvi", "I. D. Charges from Passes", "230.89", "9.87", "203.77", "8.92", "71.21", "3.75");
            table.Rows.Add("xvii", "Other Misc. Receipts", "2017.90", "86.23", "2084.28", "91.28", "739.97", "38.97");
            table.Rows.Add("xviii", "Grants- in-Aid (Revenue)", "182500.00", "7781.69", "203000.00", "8874.43", "247500.00", "13034.00");
            table.Rows.Add("xix", "Total Misc. Income(x to xvii)", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total Income(ix +xix)", "0", "0", "0", "0", "0", "0");


            table.Rows.Add("II ", "VARIABLE COST", "", "", "", "", "", "");

            table.Rows.Add("i ", "H.S.D.OIL", "166.62", "7.28", "121.62", "5.32", "6.71", "0.35");
            table.Rows.Add("ii ", "C.N.G.", "41815.75", "1786.91", "44529.91", "1950.21", "34424.22", "1812.87");
            table.Rows.Add("iii ", "Lubricants", "22.31", "0.95", "0.38", "0.02", "0.06", "0.00");
            table.Rows.Add("iv ", "Petrol", "13.55", "0.58", "20.6", "0.90", "42.84", "2.26");
            table.Rows.Add("v ", "Tyres ,Tubes & Flaps", "1.61", "0.07", "2.04", "0.09", "1.50", "0.08");
            table.Rows.Add("vi", "Retd. Materials", "0.05", "0.00", "0.00", "0.00", "8.25", "0.43");
            table.Rows.Add("vii", "Stores spare & Batteries", "95.77", "4.09", "28.97", "1.27", "4.13", "0.22");
            table.Rows.Add("viii ", "Tickets ", "364.29", "15.57", "408.56", "17.89", "250.84", "13.21");
            table.Rows.Add("ix ", "Hire charges to Volvo/ PO Buses  ", "124.97", "2431.32", "619.11", "14990.56", "10.49", "0.00");
            table.Rows.Add("x", "AMC Charges for Low Floor Buses  ", "31241.32", "1343.79", "35258.18", "1551.75", "35618.97", "1875.79");
            table.Rows.Add("xi", "Damage/ Accidentical Charges LFB", "1495.32", "64.32", "738.14", "32.49", "695.12", "36.61");
            table.Rows.Add("", "Total Variable cost (II)", "75341.56", "3212.52", "81727.51", "3572.83", "71063.13", "3742.37");


            table.Rows.Add("III", "Contribution ", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("IV", "SEMI VARIABLE COST", "", "", "", "", "", "");

            table.Rows.Add("A", "PAY & ALLOWANCES", "", "", "", "", "", "");

            table.Rows.Add("i", "Salary & Wages", "101717.62", "4337.18", "95793.45", "4187.75", "90016.14", "4740.49");
            table.Rows.Add("ii ", "Provision for 7th Pay Commission", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00");
            table.Rows.Add("iii ", "Bonus", "1450.00", "61.83", "1460.00", "63.83", "1364.00", "71.83");
            table.Rows.Add("iv ", "Children Education Allowance", "890.05", "37.95", "1410.24", "61.65", "1245.92", "65.61");
            table.Rows.Add("v ", "Cont. to EPF & linked insurance", "10484.48", "447.05", "10204.06", "446.08", "9664.56", "508.96");
            table.Rows.Add("vi ", "Gratuity", "18968.93", "808.82", "18132.15", "792.67", "60372.01", "3179.35");
            table.Rows.Add("vii  ", "Payment to pansion", "29500.00", "2557.86", "45805.00", "2002.43", "48573.00", "2557.98");
            table.Rows.Add("viii  ", "ESI Contribution ", "1016.43", "43.34", "911.78", "39.86", "931.53", "49.06");
            table.Rows.Add("ix  ", "medical", "2766.45", "117.96", "2395.12", "104.71", "1615.41", "85.07");
            table.Rows.Add("ix  ", "Incentive to Drivers/contractual Staff", "1541.06", "65.71", "1926.61", "84.22", "1754.51", "92.40");
            table.Rows.Add("x  ", "Welfare & LTC/TA", "186.25", "7.94", "135.64", "5.93", "61.83", "3.26");
            table.Rows.Add("xi  ", "Uniform", "610.01", "26.01", "816.63", "35.70", "987.42", "52.00");
            table.Rows.Add("", "TOTAL (A)", "0", "0", "0", "0", "0", "0");


            table.Rows.Add("B ", "RENT RATE & TAXES", "", "", "", "", "", "");

            table.Rows.Add("i ", "Road Tax/Adda Tax/ Permit fee/S.Tax on AC ", "2069.12", "88.23", "2489.88", "108.85", "1439.74", "75.82");
            table.Rows.Add("ii", "Property Tax/Ground Rent ", "374.46", "15.97", "446.37", "19.51", "1207.33", "63.58");
            table.Rows.Add("", "TOTAL (B) ", "0", "0", "0", "0", "0", "0");


            table.Rows.Add("C ", "OTHER CONTINGENCIES", "", "", "", "", "", "");

            table.Rows.Add("i ", "Contribution to RIF/M.A.C.T.", "87.88", "3.75", "74.68", "3.26", "8.63", "0.45");
            table.Rows.Add("ii ", "Third Party Insurance ", "2168.77", "92.48", "2519.15", "110.13", "2209.90", "116.38");
            table.Rows.Add("iii ", "Elect. Water & Telephone ", "837.00", "35.69", "775.58", "33.91", "732.40", "38.57");
            table.Rows.Add(" ", "Interest on O.D , PF dues & Others  ", "13.06", "0.56", "38.76", "1.69", "5.17", "0.27");
            table.Rows.Add("iv", "Maintenance to Buildings ", "1314.99", "56.07", "1523.62", "66.61", "1126.31", "59.31");
            table.Rows.Add("v", "Out side Repair ", "6.70", "0.29", "11.71", "0.51", "08.36", "0.44");
            table.Rows.Add("vi", "Stationary & Forms ", "322.60", "13.76", "444.69", "19.44", "280.17", "14.75");
            table.Rows.Add("vii ", "Legal Expenses", "127.22", "5.42", "190.34", "8.32", "80.06", "4.22");
            table.Rows.Add("viii ", "Publicity & Time Table", "42.40", "1.81", "77.73", "3.40", "4.41", "0.23");
            table.Rows.Add("ix ", "Hire Charges of Staff Cars", "176.69", "7.53", "204.13", "8.92", "197.10", "10.38");
            table.Rows.Add("x ", "Other Misc.", "457.91", "19.52", "875.77", "38.29", "508.40", "26.77");
            table.Rows.Add("xi ", "Interest on Equity/plan re-appropriated", "2413.10", "102.89", "2351.36", "102.79", "201.80", "10.63");
            table.Rows.Add("", "Total (C)", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "TOTAL (IV)(A+B+C)", "0", "0", "0", "0", "0", "0");


            table.Rows.Add("V", "WORKING EXPENDITURE (II+IV) ", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("VI", "Working Loss / Profit(I-V) ", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("VII ", "Fixed Cost ", "", "", "", "", "", "");
            table.Rows.Add(" ", " ", "", "", "", "", "", "");

            table.Rows.Add("i ", "Depreciation on buses ", "16289.52", "694.57", "16195.57", "708.01", "14516.97", "764.50");
            table.Rows.Add("ii", "Depreciation on other Assets", "465.25", "19.84", "452.76", "19.79", "435.67", "22.94");
            table.Rows.Add("iii", "Int.on G.N.C.T.D. loans", "525203.38", "22394.35", "614454.93", "26861.77", "717623.46", "37791.93");
            table.Rows.Add("iv", "Loss on Deleted buses", "0.00", "0.00", "49.24", "2.15", "19.93", "1.05");

            table.Rows.Add(" ", "Total (VII)", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("VIII ", "Total (VII)", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("IX ", "Total loss/Profit (I-VIII) ", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("X ", "prior Period Adj./Interest Utilized", "2140.67", "91.28", "3086.08", "134.91", "4402.37", "231.84");
            table.Rows.Add("XI ", "Net Loss/ Profit", "0", "0", "0", "0", "0", "0");






            return table;
        }
        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_ComparativeFinancialResultsFrom", OsbId);
            dataGridView1.DataSource = BindComparativeFinancialResultsFrom();
            CalculateFormula();
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

            

            for(int i=2 ; i<= 7; i++)
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
            CalculateFormula();
        }
    }
}
