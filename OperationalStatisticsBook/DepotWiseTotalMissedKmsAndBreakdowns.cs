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
    public partial class DepotWiseTotalMissedKmsAndBreakdowns : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public DepotWiseTotalMissedKmsAndBreakdowns(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6] FROM [rpt].[tbl_DepotWiseTotalMissedKmsAndBreakdowns] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
               // cmd.Parameters.AddWithValue("@Month", MonthName);
               // cmd.Parameters.AddWithValue("@Year", finYear);
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
                    dataGridView1.DataSource = BindDepotWiseTotalMissedKmsAndBreakdowns();

                }

                Common.SetRowNonEditable(dataGridView1, 12);
                Common.SetRowNonEditable(dataGridView1, 20);
                Common.SetRowNonEditable(dataGridView1, 27);
                Common.SetRowNonEditable(dataGridView1, 39);
                Common.SetRowNonEditable(dataGridView1, 40);

                Common.SetColumnNonEditable(dataGridView1, 6);
                CalcalculateTotal();

            }
            catch (Exception ex)
            {

            }

        }
        DataTable BindDepotWiseTotalMissedKmsAndBreakdowns()
        {
            DataTable table = new DataTable();

            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Depot", typeof(string));
            table.Columns.Add("Missed Kms", typeof(string));
            table.Columns.Add("Breakdowns", typeof(string));
            table.Columns.Add("Breakdowns ", typeof(string));
            table.Columns.Add("Breakdowns  ", typeof(string));
            table.Columns.Add(" Breakdowns", typeof(string));
          
            
          
        //    table.Rows.Add("", "Depot", "Missed Kms", "Breakdowns", "Breakdowns", "Breakdowns", "Breakdowns");           
         //   table.Rows.Add("", "", "", "M", "E", "T", "Total");
         //   table.Rows.Add("1", "2", "3", "4", "5", "6", "7");
            table.Rows.Add("1", "BBM", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Rohini-I", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Rohini-II", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Rohini-III", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Rohini-IV", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "Wazir Pur", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "Subhash Place", "0", "0", "0", "0", "0");
            table.Rows.Add("8", "G.T.K. Rd.", "0", "0", "0", "0", "0");
            table.Rows.Add("9", "Nangloi", "0", "0", "0", "0", "0");
            table.Rows.Add("10", "Kanjhawla", "0", "0", "0", "0", "0");
            table.Rows.Add("11", "NARELA", "0", "0", "0", "0", "0");
            table.Rows.Add("12", "Rohini sec. 37", "0", "0", "0", "0", "0");
            table.Rows.Add("North Region", "North Region", "0", "0", "0", "0", "0");
            table.Rows.Add("13", "KJD", "0", "0", "0", "0", "0");
            table.Rows.Add("14", "SNPD", "0", "0", "0", "0", "0");
            table.Rows.Add("15", "AND", "0", "0", "0", "0", "0");
            table.Rows.Add("16", "VasantVihar", "0", "0", "0", "0", "0");
            table.Rows.Add("17", "Tehkhand", "0", "0", "0", "0", "0");
            table.Rows.Add("18", "Sukhdev Vihar", "0", "0", "0", "0", "0");
            table.Rows.Add("19", "Sarojni Nagar", "0", "0", "0", "0", "0");
            table.Rows.Add("South Region", "South Region", "0", "0", "0", "0", "0");
            table.Rows.Add("20", "Nand Nagri", "0", "0", "0", "0", "0");
            table.Rows.Add("21", "NOIDA", "0", "0", "0", "0", "0");
            table.Rows.Add("22", "E.V.Nagar", "0", "0", "0", "0", "0");
            table.Rows.Add("23", "HasanPur", "0", "0", "0", "0", "0");
            table.Rows.Add("24", "Gazi Pur", "0", "0", "0", "0", "0");
            table.Rows.Add("25", "Raj Ghat-I", "0", "0", "0", "0", "0");  
            table.Rows.Add("26", "Raj Ghat-I", "0", "0", "0", "0", "0");  
            table.Rows.Add("East Region", "East Region", "0", "0", "0", "0", "0");
            table.Rows.Add("27", "HND-I", "0", "0", "0", "0", "0");
            table.Rows.Add("28", "HND-II", "0", "0", "0", "0", "0");
            table.Rows.Add("29", "KPD", "0", "0", "0", "0", "0");
            table.Rows.Add("30", "ND", "0", "0", "0", "0", "0");
            table.Rows.Add("31", "SPD", "0", "0", "0", "0", "0");
            table.Rows.Add("32", "B.DOLA", "0", "0", "0", "0", "0");
            table.Rows.Add("33", "D.SEC.-II", "0", "0", "0", "0", "0");
            table.Rows.Add("34", "MPD", "0", "0", "0", "0", "0");
            table.Rows.Add("35", "DKD", "0", "0", "0", "0", "0");
            table.Rows.Add("36", "PGD", "0", "0", "0", "0", "0");
            table.Rows.Add("37", "Mundhela kalan", "0", "0", "0", "0", "0");
            table.Rows.Add("Total West", "Total West", "0", "0", "0", "0", "0");
            table.Rows.Add("Grand Total", "Grand Total", "0", "0", "0", "0", "0");           
            return table;
        }

        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DepotWiseTotalMissedKmsAndBreakdowns", OsbId);
            dataGridView1.DataSource = BindDepotWiseTotalMissedKmsAndBreakdowns();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DepotWiseTotalMissedKmsAndBreakdowns", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_DepotWiseTotalMissedKmsAndBreakdowns] ([OsbId],[S_No],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6]) VALUES (@OsbId,@S_No,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@S_No", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param6", row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString());
                        
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
        private void DepotWiseTotalMissedKmsAndBreakdowns_Load(object sender, EventArgs e)
        {           
           // dataGridView1.DataSource = BindDepotWiseTotalMissedKmsAndBreakdowns();
            BindIndexPage(OsbId);
        }

        private void Print_ReportOnClick(object sender, EventArgs e)
        {
            rptDepotWiseTotalMissedKmsAndBreakdowns objFrm = new rptDepotWiseTotalMissedKmsAndBreakdowns(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcalculateTotal();
        }

        void CalcalculateTotal()
        {
            var row = dataGridView1.Rows;

            #region Calculating_VerticalSum


            dataGridView1.Rows[12].Cells[2].Value = Common.GetSum(row, 0, 11, 2);
            dataGridView1.Rows[12].Cells[3].Value = Common.GetSum(row, 0, 11, 3);
            dataGridView1.Rows[12].Cells[4].Value = Common.GetSum(row, 0, 11, 4);
            dataGridView1.Rows[12].Cells[5].Value = Common.GetSum(row, 0, 11, 5);

            dataGridView1.Rows[20].Cells[2].Value = Common.GetSum(row, 13,19, 2);
            dataGridView1.Rows[20].Cells[3].Value = Common.GetSum(row, 13,19, 3);
            dataGridView1.Rows[20].Cells[4].Value = Common.GetSum(row, 13,19, 4);
            dataGridView1.Rows[20].Cells[5].Value = Common.GetSum(row, 13,19, 5);

            dataGridView1.Rows[27].Cells[2].Value = Common.GetSum(row, 21,26, 2);
            dataGridView1.Rows[27].Cells[3].Value = Common.GetSum(row, 21,26, 3);
            dataGridView1.Rows[27].Cells[4].Value = Common.GetSum(row, 21,26, 4);
            dataGridView1.Rows[27].Cells[5].Value = Common.GetSum(row, 21,26, 5);

            dataGridView1.Rows[39].Cells[2].Value = Common.GetSum(row, 28,38, 2);
            dataGridView1.Rows[39].Cells[3].Value = Common.GetSum(row, 28,38, 3);
            dataGridView1.Rows[39].Cells[4].Value = Common.GetSum(row, 28,38, 4);
            dataGridView1.Rows[39].Cells[5].Value = Common.GetSum(row, 28,38, 5);

            dataGridView1.Rows[40].Cells[2].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[2].Value.ToString())+ Common.ConvertToDecimal(dataGridView1.Rows[27].Cells[2].Value.ToString())+ Common.ConvertToDecimal(dataGridView1.Rows[20].Cells[2].Value.ToString())+ Common.ConvertToDecimal(dataGridView1.Rows[12].Cells[2].Value.ToString());
            dataGridView1.Rows[40].Cells[3].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[27].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[20].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[12].Cells[3].Value.ToString());
            dataGridView1.Rows[40].Cells[4].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[27].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[20].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[12].Cells[4].Value.ToString());
            dataGridView1.Rows[40].Cells[5].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[27].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[20].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[12].Cells[5].Value.ToString());



            #endregion

            #region Calculating_HorizontalSum
            for (int i = 0; i < (row.Count - 1); i++)
            {

                if (i >= 0)
                {
                    dataGridView1.Rows[i].Cells[6].Value = Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[5].Value.ToString());
                }
            }
            #endregion

        }
    }
}
