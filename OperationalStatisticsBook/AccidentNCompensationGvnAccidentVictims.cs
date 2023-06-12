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
    public partial class AccidentNCompensationGvnAccidentVictims : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public AccidentNCompensationGvnAccidentVictims(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                if (finYear == "2023-24")
                {
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("SELECT [S_No], [Year],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7] FROM [rpt].[tbl_AccidentNCompensationGvnAccidentVictims] where OsbId=@OsbId", con);
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
                        dataGridView1.DataSource = BindAccidentNCompensationGvnAccidentVictims();
                    }
                }
                else if (finYear == "2022-23")
                {
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("SELECT [S_No], [Year],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7] FROM [rpt].[tbl_AccidentNCompensationGvnAccidentVictims] where OsbId=@OsbId", con);
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
                        dataGridView1.DataSource = BindAccidentNCompensationGvnAccidentVictims();
                    }
                }
                else
                {
                    dataGridView1.DataSource = BindAccidentNCompensationGvnAccidentVictims();
                }


            }
            catch (Exception ex)
            {

            }

        }

        DataTable BindAccidentNCompensationGvnAccidentVictims()
        {

            DataTable table = new DataTable();

            // Static Columns

            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Year", typeof(string));
            table.Columns.Add("No of Accidents", typeof(string));
            table.Columns.Add("Accidents per 100,000 kms", typeof(string));
            table.Columns.Add("No of Person Injured", typeof(string));
            table.Columns.Add("No of Person Killed", typeof(string));
            table.Columns.Add("No of Cases received", typeof(string));
            table.Columns.Add("Compensation given (Rs. in lakh)", typeof(string));
            table.Columns.Add("Compensation given (Rs. in lakh) ", typeof(string));
            //   table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9");
            //Static Rows



            DateTime currentDate = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate.AddYears(0);
            DateTime newDate2 = currentDate.AddYears(+1);
            //string currentYear = currentDate.AddYears(+2).ToString();
            String previousMonthName = newDate.ToString("MMMM");

            table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9");
            table.Rows.Add("2", "2012-13", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "2013-14", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "2014-15", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "2015-16", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "2016-17", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "2017-18", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("8", "2018-19", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("9", "2019-20", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("10", "2020-21", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("11", "2021-22", "0", "0", "0", "0", "0", "0", "0");

            return table;

        }

        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingdtRecord("tbl_AccidentNCompensationGvnAccidentVictims", OsbId);
            dataGridView1.DataSource = BindAccidentNCompensationGvnAccidentVictims();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingdtRecord("tbl_AccidentNCompensationGvnAccidentVictims", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_AccidentNCompensationGvnAccidentVictims] ([OsbId], [S_No], [Year],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7]) VALUES (@OsbId,@S_No,@Year,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@S_No", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Year", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param6", row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param7", row.Cells[8].Value == null ? "" : row.Cells[8].Value.ToString());

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

        int DeleteExisitingdtRecord(string dtName, int OsbId)
        {
            string strdt = "[rpt].[" + dtName + "]";
            int i = 0;
            SqlCommand cmd = new SqlCommand("delete from " + strdt + " where OsbId=@OsbId", con);
            cmd.Parameters.AddWithValue("@OsbId", OsbId);
            cmd.CommandType = CommandType.Text;
            con.Open();

            i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }

        private void AccidentNCompensationGvnAccidentVictims_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
        }

        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptAccidentNCompensationGvnAccidentVictims objFrm = new rptAccidentNCompensationGvnAccidentVictims(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }
    }
}
