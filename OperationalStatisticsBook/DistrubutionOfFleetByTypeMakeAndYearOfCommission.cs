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
    public partial class DistrubutionOfFleetByTypeMakeAndYearOfCommission : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public DistrubutionOfFleetByTypeMakeAndYearOfCommission(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [YearOfComm],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6] ,[Param7],[Param8] FROM [rpt].[tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommission] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                DataTable autoSpTable = new DataTable();
                SqlCommand cmd1 = new SqlCommand("NoofTripsactOperatedOnTimeNWithinTwoMinutesOSB4_7", con);
                cmd1.Parameters.AddWithValue("@Month", Month);
                cmd1.Parameters.AddWithValue("@Year", Year);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(autoSpTable);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    Save.BackColor = Color.Green;
                }
                else if (autoSpTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = BindDistrubutionOfFleetByTypeMakeAndYearOfCommission();
                }
                else
                {
                    dataGridView1.DataSource = BindDistrubutionOfFleetByTypeMakeAndYearOfCommission();
                }
                CalculateFormula();
                SetNonEditable();
            }
            catch (Exception ex)
            {

            }

        }

        DataTable BindDistrubutionOfFleetByTypeMakeAndYearOfCommission()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Year of Comm.", typeof(string));
            table.Columns.Add("Leyland", typeof(string));
            table.Columns.Add("Leyland ", typeof(string));
            table.Columns.Add("TATA", typeof(string));
            table.Columns.Add("TATA  ", typeof(string));
            table.Columns.Add("TATA ", typeof(string));
            table.Columns.Add("JBM ", typeof(string));
            table.Columns.Add("Total  ", typeof(string));
            table.Columns.Add("Percentage ", typeof(string));

            // table.Rows.Add("Year of Comm.", "CNG ", "CNG", "CNG", "CNG", "Electric", "Electric", "Total", "duistribution");
            // table.Rows.Add(" ", "LOW FLOOR ", "LOW FLOOR", "LOW FLOOR", "LOW FLOOR", "LOW FLOOR", "LOW FLOOR", "Total", "by year of" );
            // table.Rows.Add(" ", "NON AC ", "AC", "NON AC", "AC", "AC", "AC", "Total", "commission");
            // table.Rows.Add("1", "2 ", "3", "4", "5", "6", "7", "8", "9");


            DateTime currentDate = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate.AddYears(0);
            DateTime newDate2 = currentDate.AddYears(+1);
            string currentYear = currentDate.AddYears(+2).ToString();


            String previousMonthName = newDate.ToString("MMMM");

            //for (int i = 19; i > 0; i--)
            //{
            //    table.Rows.Add(newDate.AddYears(-i).Year + "-" + newDate2.AddYears(-i).Year, "0", "0", "0", "0", "0", "0", "0", "0");
            //}

            table.Rows.Add("2004-05", " ", "", "", "", "", "", "", "0.00");
            table.Rows.Add("2005-06", " ", "", "5", "", "", "", "", "0.13");
            table.Rows.Add("2006-07", " ", "", "1", "", "", "", "", "0.03");
            table.Rows.Add("2007-08", " ", "", "159", "", "", "", "", "4.06");
            table.Rows.Add("2008-09", " ", "", "466", "25", "", "", "", "12.55");
            table.Rows.Add("2009-10", "326", "", "661", "249", "", "", "", "31.59");
            table.Rows.Add("2010-11", "321", "410", "558", "547", "", "", "", "46.92");
            table.Rows.Add("2011-12", "7", "25", "", "", "", "", "", "0.82");
            table.Rows.Add("2012-13", " ", "", "", "", "", "", "", "0.00");
            table.Rows.Add("2013-14", " ", "", "", "", "", "", "", "0.00");
            table.Rows.Add("2014-15", " ", "", "", "", "", "", "", "0.00");
            table.Rows.Add("2015-16", " ", "", "", "", "", "", "", "0.00");
            table.Rows.Add("2016-17", " ", "", "", "", "", "", "", "0.00");
            table.Rows.Add("2017-18", " ", "", "", "", "", "", "", "0.00");
            table.Rows.Add("2018-19", " ", "", "", "", "", "", "", "0.00");
            table.Rows.Add("2019-20", " ", "", "", "", "", "", "", "0.00");
            table.Rows.Add("2020-21", " ", "", "", "", "", "", "", "0.00");
            table.Rows.Add("2021-22", " ", "", "", "", "", "", "", "0.00");
            table.Rows.Add("2022-23", " ", "", "", "", "53", "100", "", "96.09");

            table.Rows.Add("TOTAL ", " ", "", "", "", "", "", "", "");

            table.Rows.Add("Percentage Distribution  ", "16.71", "11.12", "47.28", "20.98", "1.35", "2.56", "", "");

            table.Rows.Add("BY TYPE /MAKEAVERAGE AGE(INYEAR) ", "10.0", "10.0", "10.0", "10.0", "0.00", "0.00", "10.0", "");

            table.Rows.Add(" ", " ", "", "", "", "", "", "", "");

            table.Rows.Add(" DISTRIBUTION OF FLEET", " ", " ", "", "", "", "Extent of Overaged Buses", " ", " ");

            int lastDayofTheMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);

            string lastDateForDistributionFleet = lastDayofTheMonth + "-" + currentDate.Month + "-" + currentDate.Year;

            table.Rows.Add(lastDateForDistributionFleet, " ", " ", "", "", "", "(More Than 8 Years Old)", " ", " ");
            table.Rows.Add("Age Group in Years ", "Number of buses ", "", "", "", "", "", "Absolute(Number)", "Percentage ");
            table.Rows.Add("0-2", "153 ", "", "", "", "", "31.3.07", "347", "9.81");
            table.Rows.Add("2-4", "0", "", "", "", "", "31.3.08", "299", "8.45");
            table.Rows.Add("4-6", "0", "", "", "", "", "31.3.09", "260", "6.83");
            table.Rows.Add("6-8", "0", "", "", "", "", "31.3.10", "1839", "39.24");
            table.Rows.Add("8-10", "0", "", "", "", "", "31.3.11", "1843", "29.71");
            table.Rows.Add("10+", "3760", "", "", "", "", "31.3.12", "2079", "35.29");
            table.Rows.Add("Total", "3913", "", "", "", " ", "31.3.13", "1634", "30.01");
            table.Rows.Add("*Authorised Fleet Strength of DTC=5500 ", " ", "", "", "", "", "31.3.14", "1440", "27.57");
            table.Rows.Add(" ", " ", "", "", "", "", "31.3.15", "930", "19.74");
            table.Rows.Add(" ", " ", "", "", "", "", "31.3.16", "569", "13.07");
            table.Rows.Add(" ", " ", "", "", "", "", "31.3.17", "245", "6.08");
            table.Rows.Add(" ", " ", "", "", "", "", "31.3.18", "826", "20.91");
            table.Rows.Add(" ", " ", "", "", "", "", "31.3.19", "1978", "51.39");
            table.Rows.Add(" ", " ", "", "", "", "", "31.3.20", "1868", "99.15");
            table.Rows.Add(" ", " ", "", "", "", "", "31.3.21", "3760", "100.00");
            table.Rows.Add(" ", " ", "", "", "", "", "31.3.22", "3760", "100.00");


            string lastDateOfSelectedMonthForlastGridViewCell = lastDayofTheMonth + "." + currentDate.Month + "." + currentDate.Year;


            table.Rows.Add(" ", " ", "", "", "", "", lastDateOfSelectedMonthForlastGridViewCell, "3760", " ");


            return table;
        }

        private void ResetOnClick(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BindDistrubutionOfFleetByTypeMakeAndYearOfCommission();
            CalculateFormula();
            SetNonEditable();
            MessageBox.Show("Done");
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

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommission", OsbId);
            CalculateFormula();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommission] ([OsbId],[YearOfComm],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8]) VALUES (@OsbId,@YearOfComm,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@YearOfComm", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
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

        private void DistrubutionOfFleetByTypeMakeAndYearOfCommission_Load(object sender, EventArgs e)
        {
            // dataGridView1.DataSource = BindDistrubutionOfFleetByTypeMakeAndYearOfCommission();
            BindIndexPage(OsbId);
        }

        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptDistributionOfFleetByTypeMake objFrm = new rptDistributionOfFleetByTypeMake(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        void CalculateFormula()
        {
            var row = dataGridView1.Rows;

            // total horizontally adding

            for (int i = 0; i <= 19; i++)
            {
                dataGridView1.Rows[i].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[i].Cells[1].Value.ToString())
                                                                + Common.ConvertToDecimal(row[i].Cells[2].Value.ToString())
                                                                + Common.ConvertToDecimal(row[i].Cells[3].Value.ToString())
                                                                + Common.ConvertToDecimal(row[i].Cells[4].Value.ToString())
                                                                + Common.ConvertToDecimal(row[i].Cells[5].Value.ToString())
                                                                + Common.ConvertToDecimal(row[i].Cells[6].Value.ToString()), 0);
            }

            //Total vertically adding

            for (int i = 1; i <= 7; i++)
            {
                dataGridView1.Rows[19].Cells[i].Value = Common.GetSum(row, 0, 18, i);
            }


            // PERCENTAGE DISTRIBUTION BY YEAR OF COMMISSION
            for (int i = 0; i <= 18; i++)
            {
                dataGridView1.Rows[i].Cells[8].Value = Common.ConvertToDecimal(row[19].Cells[7].Value.ToString()) > 0 ?
                    Math.Round(Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[19].Cells[7].Value.ToString()) * 100, 2) : 0;

                dataGridView1.Rows[19].Cells[8].Value = Common.GetSum(row, 0, 18, 8);

            }
            //PERCENTAGE DISTRIBUTION
            for (int i = 1; i <= 7; i++)
            {
                dataGridView1.Rows[20].Cells[i].Value = Common.ConvertToDecimal(row[19].Cells[7].Value.ToString()) > 0 ?
                    Math.Round(Common.ConvertToDecimal(row[19].Cells[i].Value.ToString()) / Common.ConvertToDecimal(row[19].Cells[7].Value.ToString()) * 100, 2) : 0;
            }

            // DISTRIBUTION OF FLEET AS ON DATE
            // for age group 0-2
            dataGridView1.Rows[26].Cells[1].Value = Common.ConvertToDecimal(row[17].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[18].Cells[7].Value.ToString());

            // for age group 2-4
            dataGridView1.Rows[27].Cells[1].Value = Common.ConvertToDecimal(row[15].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[16].Cells[7].Value.ToString());

            // 4-6
            dataGridView1.Rows[28].Cells[1].Value = Common.ConvertToDecimal(row[13].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[14].Cells[7].Value.ToString());

            //6-8
            dataGridView1.Rows[29].Cells[1].Value = Common.ConvertToDecimal(row[11].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[12].Cells[7].Value.ToString());

            // 8-10
            dataGridView1.Rows[30].Cells[1].Value = Common.ConvertToDecimal(row[9].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[10].Cells[7].Value.ToString());

            // 10+
            dataGridView1.Rows[31].Cells[1].Value = Common.ConvertToDecimal(row[0].Cells[7].Value.ToString())
                                                  + Common.ConvertToDecimal(row[1].Cells[7].Value.ToString())
                                                  + Common.ConvertToDecimal(row[2].Cells[7].Value.ToString())
                                                  + Common.ConvertToDecimal(row[3].Cells[7].Value.ToString())
                                                  + Common.ConvertToDecimal(row[4].Cells[7].Value.ToString())
                                                  + Common.ConvertToDecimal(row[5].Cells[7].Value.ToString())
                                                  + Common.ConvertToDecimal(row[6].Cells[7].Value.ToString())
                                                  + Common.ConvertToDecimal(row[7].Cells[7].Value.ToString())
                                                  + Common.ConvertToDecimal(row[8].Cells[7].Value.ToString());
            // Total
            dataGridView1.Rows[32].Cells[1].Value = Common.ConvertToDecimal(row[26].Cells[1].Value.ToString())
                                                  + Common.ConvertToDecimal(row[27].Cells[1].Value.ToString())
                                                  + Common.ConvertToDecimal(row[28].Cells[1].Value.ToString())
                                                  + Common.ConvertToDecimal(row[29].Cells[1].Value.ToString())
                                                  + Common.ConvertToDecimal(row[30].Cells[1].Value.ToString())
                                                  + Common.ConvertToDecimal(row[31].Cells[1].Value.ToString());

            // Extent overaged buses
            //absoulute number
            dataGridView1.Rows[42].Cells[7].Value = Common.ConvertToDecimal(row[30].Cells[1].Value.ToString())
                                                  + Common.ConvertToDecimal(row[31].Cells[1].Value.ToString());

            //percentage last 
            dataGridView1.Rows[42].Cells[8].Value = Math.Round(Common.ConvertToDecimal(row[42].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[32].Cells[1].Value.ToString()) * 100, 2);

        }

        void SetNonEditable()
        {
            for (byte i = 0; i <= 15; i++)
            {
                Common.SetRowNonEditable(dataGridView1, i);
            }
            Common.SetRowNonEditable(dataGridView1, 19);
            Common.SetRowNonEditable(dataGridView1, 20);
            for (byte i = 22; i <= 42; i++)
            {
                Common.SetRowNonEditable(dataGridView1, i);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateFormula();
        }
    }
}
