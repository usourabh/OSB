﻿using System;
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
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    Save.BackColor = Color.Green;
                }
                else
                {
                    dataGridView1.DataSource = BindDistrubutionOfFleetByTypeMakeAndYearOfCommission();
                }
                Common.SetRowNonEditable(dataGridView1, 19);
                Common.SetColumnNonEditable(dataGridView1, 7);
                CalculateFormula();
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

          
            table.Rows.Add("As on 31st July-2022 ", " ", " ", "", "", "", "(More Than 8 Years Old)", " ", " ");
            table.Rows.Add("Age Group in Years ", "Number of buses ", "", "", "", "", "", "Absolute(Number)", "Percentage ");
            table.Rows.Add("0-2", "153 ", "", "", "", "",                                  "31.3.07", "347", "0");
            table.Rows.Add("2-4", "0", "", "", "", "",                                     "31.3.08", "299", "0");
            table.Rows.Add("4-6", "0", "", "", "", "",                                     "31.3.09", "260", "0");
            table.Rows.Add("6-8", "0", "", "", "", "",                                     "31.3.10", "1839", "0");
            table.Rows.Add("8-10", "0", "", "", "", "",                                    "31.3.11", "1843", "0");
            table.Rows.Add("10+", "3760", "", "", "", "",                                  "31.3.12", "2079", "0");
            table.Rows.Add("Total", "3913", "", "", "", " ",                               "31.3.13", "1634", "0");
            table.Rows.Add("*Authorised Fleet Strength of DTC=5500 ", " ", "", "", "", "", "31.3.14", "1440", "0");
            table.Rows.Add(" ", " ", "", "", "", "",                                       "31.3.15", "930", "0");
            table.Rows.Add(" ", " ", "", "", "", "",                                       "31.3.16", "569", "0");
            table.Rows.Add(" ", " ", "", "", "", "",                                       "31.3.17", "245", "0");
            table.Rows.Add(" ", " ", "", "", "", "",                                       "31.3.18", "826", "0");
            table.Rows.Add(" ", " ", "", "", "", "",                                       "31.3.19", "1978", "0");
            table.Rows.Add(" ", " ", "", "", "", "",                                       "31.3.20", "1868", "0");
            table.Rows.Add(" ", " ", "", "", "", "",                                       "31.3.21", "3760", "0");
            table.Rows.Add(" ", " ", "", "", "", "",                                       "31.3.22", "3760", "0");
            table.Rows.Add(" ", " ", "", "", "", "",                                       "31.3.23", "3760", "0");


            return table;
        }

            private void ResetOnClick(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BindDistrubutionOfFleetByTypeMakeAndYearOfCommission();
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
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null )
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

            //Total vertically

            dataGridView1.Rows[19].Cells[1].Value = Common.GetSum(row, 0, 18, 1);
            dataGridView1.Rows[19].Cells[2].Value = Common.GetSum(row, 0, 18, 2);
            dataGridView1.Rows[19].Cells[3].Value = Common.GetSum(row, 0, 18, 3);
            dataGridView1.Rows[19].Cells[4].Value = Common.GetSum(row, 0, 18, 4);
            dataGridView1.Rows[19].Cells[5].Value = Common.GetSum(row, 0, 18, 5);
            dataGridView1.Rows[19].Cells[6].Value = Common.GetSum(row, 0, 18, 6);
            dataGridView1.Rows[19].Cells[7].Value = Common.GetSum(row, 0, 18, 7);


            // total horizontally

            for(int i=0; i<=19; i++)
            {
                dataGridView1.Rows[i].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[i].Cells[1].Value.ToString()) 
                                                                + Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) 
                                                                + Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) 
                                                                + Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) 
                                                                + Common.ConvertToDecimal(row[i].Cells[5].Value.ToString()) 
                                                                + Common.ConvertToDecimal(row[i].Cells[6].Value.ToString()), 0);
            }





            //dataGridView1.Rows[0].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[0].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[0].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[0].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[0].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[0].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[0].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[1].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[1].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[1].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[1].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[1].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[1].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[1].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[2].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[2].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[2].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[2].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[2].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[2].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[2].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[3].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[3].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[3].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[3].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[3].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[3].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[3].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[4].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[4].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[4].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[4].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[4].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[4].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[4].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[5].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[5].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[5].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[5].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[5].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[5].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[5].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[6].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[6].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[6].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[6].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[6].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[6].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[6].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[7].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[7].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[7].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[7].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[7].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[7].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[7].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[8].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[8].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[8].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[8].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[8].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[8].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[8].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[9].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[9].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[9].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[9].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[9].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[9].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[9].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[10].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[10].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[10].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[10].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[10].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[10].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[10].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[11].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[11].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[11].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[11].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[11].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[11].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[11].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[12].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[12].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[12].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[12].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[12].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[12].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[12].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[13].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[13].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[13].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[13].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[13].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[13].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[14].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[14].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[14].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[14].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[14].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[14].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[14].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[15].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[15].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[15].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[15].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[15].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[15].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[15].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[16].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[16].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[16].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[16].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[16].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[16].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[16].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[17].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[17].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[17].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[17].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[17].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[17].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[17].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[18].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[18].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[18].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[18].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[18].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[18].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[18].Cells[6].Value.ToString()), 0);
            //dataGridView1.Rows[19].Cells[7].Value = Math.Round(Common.ConvertToDecimal(row[19].Cells[1].Value.ToString()) + Common.ConvertToDecimal(row[19].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[19].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[19].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[19].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[19].Cells[6].Value.ToString()), 0);



        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateFormula();
        }
    }
}
