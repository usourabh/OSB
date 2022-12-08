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
    public partial class AccidentAnalysisOtherPartyInvolvment : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public AccidentAnalysisOtherPartyInvolvment(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10] FROM [rpt].[tbl_AccidentAnalysisOtherPartyInvolvment] where OsbId=@OsbId", con);
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
                    dataGridView1.DataSource = BindAccidentAnalysisOtherPartyInvolvment();
                }
                NonEditableRowAndColumn();
                CalcalculateTotal();
            }
            catch (Exception ex)
            {

            }

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

        DataTable BindAccidentAnalysisOtherPartyInvolvment()
        {
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[10] {
                            new DataColumn("Param1", typeof(string)),
                            new DataColumn("Param2", typeof(string)),
                            new DataColumn("Param3",typeof(string)),
                            new DataColumn("Param4",typeof(string)),
                            new DataColumn("Param5",typeof(string)),
                            new DataColumn("Param6",typeof(string)),
                            new DataColumn("Param7",typeof(string)),
                            new DataColumn("Param8",typeof(string)),
                            new DataColumn("Param9",typeof(string)),
                            new DataColumn("Param10",typeof(string)),

            });





            DateTime currentDate = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate.AddYears(-1);
            int currentYear = currentDate.Year;
            int previousYear = newDate.Year;
            String previousMonthName = newDate.ToString("MMMM");



           
           // table.Rows.Add("S.No", "Particulars", previousMonthName + ' ' + currentYear, previousMonthName + "  " + currentYear, previousMonthName + "   " + currentYear, previousMonthName + "    " + currentYear, previousMonthName + " " + previousYear, previousMonthName + "  " + previousYear, previousMonthName + "   " + previousYear, previousMonthName + "    " + previousYear);
           // table.Rows.Add("", "", "Minor", "Major", "Fatal", "Total", "Minor", "Major", "Fatal", "Total");
           // table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9", "10");
            table.Rows.Add("1", "PO BUS", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "D.T.C", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Two Wheeler", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Trucks", "0", "0", "0", "0", "0", "0", "0", "0");
           // table.Rows.Add("4", "Two Wheeler", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Pedestrian", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "Hand Cart", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "Animal Cart", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("8", "Fixed", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("9", "Passengers", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("10", "E-Rickshaw", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("11", "Rickshaw", "0", "0", "0", "0", "0", "0", "0", "0");
           
            table.Rows.Add("12", "Three Wheeler", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("13", "Jeep/RTV", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("14", "Car", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("15", "Tempo", "0", "0", "0", "0", "0", "0", "0", "0");
          
            table.Rows.Add("16", "Cyclist", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("17", "Goods Carr.", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("18", "Other Vehicle", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total", "0", "0", "0", "0", "0", "0", "0", "0");



            return table;
        }



        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingdtRecord("tbl_AccidentAnalysisOtherPartyInvolvment", OsbId);
            dataGridView1.DataSource = BindAccidentAnalysisOtherPartyInvolvment();
            NonEditableRowAndColumn();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingdtRecord("tbl_AccidentAnalysisOtherPartyInvolvment", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_AccidentAnalysisOtherPartyInvolvment] ([OsbId],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10]) VALUES (@OsbId,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param6", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param7", row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param8", row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param9", row.Cells[8].Value == null ? "" : row.Cells[8].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param10", row.Cells[9].Value == null ? "" : row.Cells[9].Value.ToString());

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

        private void AccidentAnalysisOtherPartyInvolvment_Load(object sender, EventArgs e)
        {
            // dataGridView1.DataSource = BindAccidentAnalysisOtherPartyInvolvment();
            BindIndexPage(OsbId);
        }

        void CalcalculateTotal()
        {
            var row = dataGridView1.Rows;

            #region Calculating_VerticalSum

            // North Total
            dataGridView1.Rows[18].Cells[2].Value = Common.GetSum(row, 0, 17, 2);
            dataGridView1.Rows[18].Cells[3].Value = Common.GetSum(row, 0, 17, 3);
            dataGridView1.Rows[18].Cells[4].Value = Common.GetSum(row, 0, 17, 4);
            dataGridView1.Rows[18].Cells[5].Value = Common.GetSum(row, 0, 17, 5);
            dataGridView1.Rows[18].Cells[6].Value = Common.GetSum(row, 0, 17, 6);
            dataGridView1.Rows[18].Cells[7].Value = Common.GetSum(row, 0, 17, 7);
            dataGridView1.Rows[18].Cells[8].Value = Common.GetSum(row, 0, 17, 8);
            dataGridView1.Rows[18].Cells[9].Value = Common.GetSum(row, 0, 17, 9);
          

          

            #endregion

            #region Calculating_HorizontalSum
            for (int i = 0; i < (row.Count - 1); i++)
            {

                if (i >= 0)
                {
                    dataGridView1.Rows[i].Cells[5].Value = Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[4].Value.ToString());
                    dataGridView1.Rows[i].Cells[9].Value = Common.ConvertToDecimal(row[i].Cells[6].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[8].Value.ToString());
                 
                }
            }
            #endregion

        }
        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptAccidentAnalysisOtherPartyInvolvment objFrm = new rptAccidentAnalysisOtherPartyInvolvment(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
            CalcalculateTotal();
        }

        public void NonEditableRowAndColumn()
        {
            Common.SetRowNonEditable(dataGridView1, 18);

            Common.SetColumnNonEditable(dataGridView1, 5);
            Common.SetColumnNonEditable(dataGridView1, 9);
        }
    }
}
