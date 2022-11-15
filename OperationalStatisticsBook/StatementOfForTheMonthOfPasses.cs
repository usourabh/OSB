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
    public partial class StatementOfForTheMonthOfPasses : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "0";
        string finYear = "0";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public StatementOfForTheMonthOfPasses(int OsbId, int Year, int Month
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            , string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] FROM [rpt].[tbl_StatementOfForTheMonthOfPasses] where OsbId=@OsbId", con);
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
                    dataGridView1.DataSource = BindStatementOfForTheMonthOfPasses();
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_StatementOfForTheMonthOfPasses", OsbId);
            dataGridView1.DataSource = BindStatementOfForTheMonthOfPasses();
            MessageBox.Show("Done");
        }

        DataTable BindStatementOfForTheMonthOfPasses()
        {
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[5] {
                            new DataColumn("S.No", typeof(string)),
                            new DataColumn("Param1", typeof(string)),
                            new DataColumn("Param2", typeof(string)),
                            new DataColumn("Param3", typeof(string)),
                            new DataColumn("Param4",typeof(string))
                  


            });
            //table.Columns.Add("S.No", typeof(string));
            //table.Columns.Add("Type of Concessional Passes", typeof(string));
            //table.Columns.Add("Denomination", typeof(string));
            //table.Columns.Add("No.of", typeof(string));
            //table.Columns.Add("Amount", typeof(string));
            ////Rows.......
          //  table.Rows.Add("S.No ","Type of Concessional Passes", "Denomination",  "No.of", "Amount");
          //  table.Rows.Add(" ", " ", "(Rs.) ", "Passes", "(Rs)");
          //  table.Rows.Add("1 ", "2 ", "3", "4", "5");
            table.Rows.Add("1 ", "STUDENT PASSES ", " ", " ", " ");
            table.Rows.Add("1.1", "Student Destination ( AC)  ", "0", "0", "0");
            table.Rows.Add("1.2", " All Route Pass ( AC) 100*1  ", "0", "0", "0");
            table.Rows.Add("1.3", "  All Route Pass ( AC) 100*2", "0", "0", "0");
            table.Rows.Add("1.4", "   All Route Pass ( AC) 100*3", "0", "0", "0");
            table.Rows.Add("1.5", "   All Route Pass ( AC) 100*4", "0", "0", "0");
            table.Rows.Add("1.6", "  All Route Pass ( AC) 100*5", "0", "0", "0");
            table.Rows.Add("1.7", "  All Route Pass ( AC) 100*6", "0", "0", "0");
            table.Rows.Add(" ", "  Student All route Special Passes (AC)", " ", " ", " ");
            table.Rows.Add("1.8", " All route special (AC) 150*1 ", "0", "0", "0");
            table.Rows.Add("1.9", " All route special (AC) 150*2  ", "0", "0", "0");
            table.Rows.Add("1.10", " All route special (AC) 150*3 ", "0", "0", "0");
            table.Rows.Add("1.11", " All route special (AC) 150*4", "0", "0", "0");
            table.Rows.Add("1.12", " All route special (AC) 150*5", "0", "0", "0");
            table.Rows.Add("1.13", " All route special (AC) 150*6", "0", "0", "0");
            table.Rows.Add("2.1", " AAY/PR-S Monthly Non AC 500*1 ", "0", "0", "0");
            table.Rows.Add("2.1", " AAY/PR-S Monthly Non AC 500*1 ", "0", "0", "0");
            table.Rows.Add("2.2", " AAY/PR-S Monthly Non AC 500*2", "0", "0", "0");
            table.Rows.Add("3 ", "Sr. Citizen Above 60 Years Old (NON AC)", " ", " ", " ");
            table.Rows.Add("3.1 ", "Sr. Citizen. Above 60 Years Old (All Route ) 50*1 ", "0", "0", "0");
            table.Rows.Add("3.2", "Sr. Citizen Above 60 Years Old (All Route ) 50*2", "0", "0", "0");
            table.Rows.Add("3.3", "Sr. Citizen Above 60 Years Old (All Route) 50*3", "0", "0", "0");
            table.Rows.Add("3.4", "Sr. Citizen Above 60 Years Old (All Route ) 50*4", "0", "0", "0");
            table.Rows.Add("3.5", "Sr. Citizen Above 60 Years Old (All Route ) 50*5", "0", "0", "0");
            table.Rows.Add("3.6", "Sr. Citizen Above 60 Years Old (All Route ) 50*5", "0", "0", "0");
            table.Rows.Add("3.7", "Sr. Citizen Above 60 Years Old (All Route ) 50*7", "0", "0", "0");
            table.Rows.Add("3.8", "Sr. Citizen Above 60 Years Old (All Route) 50*8", "0", "0", "0");
            table.Rows.Add("3.9", "Sr. Citizen Above 60 Years Old (All Route ) 50*9", "0", "0", "0");
            table.Rows.Add("3.10", "Sr. Citizen Above 60 Years Old (All Route ) 50*10", "0", "0", "0");
            table.Rows.Add("3.11", "Sr. Citizen Above 60 Years Old (All Route ) 50*11 ", "0", "0", "0");
            table.Rows.Add("3.12", "Sr. Citizen Above 60 Years Old (All Route ) 50*11 ", "0", "0", "0");
            table.Rows.Add("4 ", "Sr. Citizen Above 60 Years Old ( AC )", "0", "0", "0");
            table.Rows.Add("4.1", "Sr. Citizen Above 60 Years Old (All Route ) 150*1 ", "0", "0", "0");
            table.Rows.Add("4.2", "Sr. Citizen Above 60 Years Old (All Route ) 150*2", "0", "0", "0");
            table.Rows.Add("4.3", "Sr. Citizen Above 60 Years Old (All Route) 150*3", "0", "0", "0");
            table.Rows.Add("4.4", "Sr. Citizen Above 60 Years Old (All Route) 150*4", "0", "0", "0");
            table.Rows.Add("4.5", "Sr. Citizen Above 60 Years Old (All Route ) 150*5", "0", "0", "0");
            table.Rows.Add("4.6", "Sr.Citizen Above 60 Years Old (All Route ) 150*6", "0", "0", "0");
            table.Rows.Add("4.7", "Sr. Citizen Above 60 Years Old (All Route ) 150*7", "0", "0", "0");
            table.Rows.Add("4.8", "Sr. Citizen Above 60 Years Old (All Route ) 150*8", "0", "0", "0");
            table.Rows.Add("4.9", "Sr. Citizen Above 60 Years Old (All Route ) 150*9", "0", "0", "0");
            table.Rows.Add("4.10", "Sr. Citizen Above 60 Years Old (All Route ) 150*10", "0", "0", "0");
            table.Rows.Add("4.11", "Sr. Citizen Above 60 Years Old (All Route ) 150*11", "0", "0", "0");
            table.Rows.Add("4.12", "Sr. Citizen Above 60 Years old (All Route ) 150*12", "0", "0", "0");
            table.Rows.Add("5 ", "GENERAL ALL ROUTE PASSES (Non AC)", " ", " ", " ");
            table.Rows.Add("5.1 ", "General all route passes One Month", "0", "0", "0");
            table.Rows.Add("5.2 ", "General all route passes Two Months", "0", "0", "0");
            table.Rows.Add("5.3 ", "General all route passes Quarterly ", "0", "0", "0");
            table.Rows.Add("5.4 ", "DBOCWWB all route passes Quarterly ", "0", "0", "0");
            table.Rows.Add("5.5 ", "General all route passes Half Yr. ", "0", "0", "0");
            table.Rows.Add("5.6 ", "General all route passes Year ", "0", "0", "0");
            table.Rows.Add("6 ", "GENERAL ALL ROUTE PASSES (AC )", " ", " ", " ");
            table.Rows.Add("6.1 ", "General all route passes One Month ", "0", "0", "0");
            table.Rows.Add("6.2 ", "General all route passes Two Months", "0", "0", "0");
            table.Rows.Add("6.3", "General all route passes Quarterly", "0", "0", "0");
            table.Rows.Add("6.4", "General all route passes Half Yr.", "0", "0", "0");
            table.Rows.Add("6.5", "General all route passes Year", "0", "0", "0");
            table.Rows.Add("6.6", "General all route Airport Express AC 1400*1", "0", "0", "0");
            table.Rows.Add("6.7", "General all route Airport Express AC 1400*2", "0", "0", "0");
            table.Rows.Add("6.8", "Delhi+NCR Airport AC Pass", "0", "0", "0");
            table.Rows.Add("7 ", "PRESS PASS ( NON AC)", " ", " ", " ");
            table.Rows.Add("7.1", "Press all route passes 100*1 ", "0", "0", "0");
            table.Rows.Add("7.2", "Press all route passes 100*2 ", "0", "0", "0");
            table.Rows.Add("7.3", "Press all route passes 100*3 ", "0", "0", "0");
            table.Rows.Add("7.4", "Press all route passes 100*4 ", "0", "0", "0");
            table.Rows.Add("7.5", "Press all route passes 100*5 ", "0", "0", "0");
            table.Rows.Add("7.6", "Press all route passes 100*6 ", "0", "0", "0");
            table.Rows.Add("7.7", "Press all route passes 100*7 ", "0", "0", "0");
            table.Rows.Add("7.8", "Press all route passes 100*8 ", "0", "0", "0");
            table.Rows.Add("7.9", "Press all route passes 100*9 ", "0", "0", "0");
            table.Rows.Add("7.10", "Press all route passes 100*10 ", "0", "0", "0");
            table.Rows.Add("7.11", "Press all route passes 100*11 ", "0", "0", "0");
            table.Rows.Add("7.12", "Press all route passes 100*12 ", "0", "0", "0");
            table.Rows.Add("8", "PRESS PASS (AC)", " ", " ", " ");
            table.Rows.Add("8.1", "Press all route passes 100*1 ", "0", "0", "0");
            table.Rows.Add("8.2", "Press all route passes 100*2 ", "0", "0", "0");
            table.Rows.Add("8.3", "Press all route passes 100*3 ", "0", "0", "0");
            table.Rows.Add("8.4", "Press all route passes 100*4 ", "0", "0", "0");
            table.Rows.Add("8.5", "Press all route passes 100*5 ", "0", "0", "0");
            table.Rows.Add("8.6", "Press all route passes 100*6 ", "0", "0", "0");
            table.Rows.Add("8.7", "Press all route passes 100*7 ", "0", "0", "0");
            table.Rows.Add("8.8", "Press all route passes 100*8 ", "0", "0", "0");
            table.Rows.Add("8.9", "Press all route passes 100*9 ", "0", "0", "0");
            table.Rows.Add("8.10", "Press all route passes 100*10 ", "0", "0", "0");
            table.Rows.Add("8.11", "Press all route passes 100*11 ", "0", "0", "0");
            table.Rows.Add("8.12", "Press all route passes 100*12 ", "0", "0", "0");
            table.Rows.Add("9", "PRESS PASS All Route (AC) DIP", " ", " ", " ");
            table.Rows.Add("9.1", "Press all route passes (DIP) 200*1 ", "0", "0", "0");
            table.Rows.Add("9.2", "Press all route passes (DIP) 200*2 ", "0", "0", "0");
            table.Rows.Add("9.3", "Press all route passes (DIP) 200*3 ", "0", "0", "0");
            table.Rows.Add("9.4", "Press all route passes (DIP) 200*4 ", "0", "0", "0");
            table.Rows.Add("9.5", "Press all route passes (DIP) 200*5 ", "0", "0", "0");
            table.Rows.Add("9.6", "Press all route passes (DIP) 200*6 ", "0", "0", "0");
            table.Rows.Add("9.7", "Press all route passes (DIP) 200*7 ", "0", "0", "0");
            table.Rows.Add("9.8", "Press all route passes (DIP) 200*8 ", "0", "0", "0");
            table.Rows.Add("9.9", "Press all route passes (DIP) 200*9 ", "0", "0", "0");
            table.Rows.Add("9.10", "Press all route passes (DIP) 200*10 ", "0", "0", "0");
            table.Rows.Add("9.11", "Press all route passes (DIP) 200*11 ", "0", "0", "0");
            table.Rows.Add("9.12", "Press all route passes (DIP) 200*12 ", "0", "0", "0");
            table.Rows.Add("10", "FREE PASSES", " ", " ", " ");
            table.Rows.Add("10.1", "Divyangjan Pass (Deaf & Dumb) One Yr. AC", "0", "0", "0");
            table.Rows.Add("10.2", "Divyangjan Pass (BLIND) with One Attendant Charge Half of the adult Fare One Yr.AC", "0", "0", "0");
            table.Rows.Add("10.3", "Divyangjan Pass (ORTHO) One Yr. AC", "0", "0", "0");
            table.Rows.Add("10.4", "Divyangjan Pass (MENTALILLNESS) with One Attendent Free One Yr.AC", "0", "0", "0");
            table.Rows.Add("10.5", "Freedom fighters with One attendant One Yr. Non AC", "0", "0", "0");
            table.Rows.Add("10.6", "WIDOW OF FREEDOM FIGHTER NON AC One YEAR", "0", "0", "0");
            table.Rows.Add("10.7", "INTERNATIONAL SPORTMEN ONE YR. NON AC ", "0", "0", "0");
            table.Rows.Add("10.8", "National award winners Six Month Non AC ", "0", "0", "0");
            table.Rows.Add("10.9", "WAR WIDOW & THEIR DEPENDENT SIX MONTH Non AC  ", "0", "0", "0");
            table.Rows.Add("10.10", "MLA/MP Attendant AC Pass One Yr. ", "0", "0", "0");
            table.Rows.Add("", "City Amount of NCR Passes ", "0", "0", "0");
            table.Rows.Add("", "TOTAL CITY Passes ", "0", "0", "0");
            table.Rows.Add("", "NCR Passes", "0", "0", "0");
            table.Rows.Add("", "Grand Total", "0", "0", "0");


            return table;
        }
        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_StatementOfForTheMonthOfPasses", OsbId);
            dataGridView1.DataSource = BindStatementOfForTheMonthOfPasses();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_StatementOfForTheMonthOfPasses", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null)
                    {
                        
                           SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_StatementOfForTheMonthOfPasses] ([OsbId],[S_No],[Param1],[Param2],[Param3],[Param4]) VALUES (@OsbId,@S_No,@Param1,@Param2,@Param3,@Param4)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@S_No", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        //cmd.Parameters.AddWithValue("@Param5", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
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

        private void StatementOfForTheMonthOfPasses_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
        }

        private void Print_ReportOnClick(object sender, EventArgs e)
        {
            rptStatementOfForTheMonthOfPasses objFrm = new rptStatementOfForTheMonthOfPasses(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }
    }
}
