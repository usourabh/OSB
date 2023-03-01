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


                DataTable autoSpTable = new DataTable();
                SqlCommand cmd1 = new SqlCommand("sp_AccidentAnalybyOtherPartyInvolvOSB5_2", con);
                cmd1.Parameters.AddWithValue("@month", Month);
                cmd1.Parameters.AddWithValue("@year", Year);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(autoSpTable);

                DataTable autoSpTable2 = new DataTable();
                SqlCommand cmd2 = new SqlCommand("sp_AccidentAnalybyOtherPartyInvolvOSB5_2", con);
                cmd2.Parameters.AddWithValue("@month", Month);
                cmd2.Parameters.AddWithValue("@year", (Year - 1));
                cmd2.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                sda2.Fill(autoSpTable2);


                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    Save.BackColor = Color.Green;
                }

                else if (autoSpTable.Rows.Count > 0 || autoSpTable2.Rows.Count > 0)
                {
                    dataGridView1.DataSource = BindAccidentAnalysisOtherPartyInvolvment_sp(autoSpTable, autoSpTable2);
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

        DataTable BindAccidentAnalysisOtherPartyInvolvment_sp(DataTable sp1, DataTable sp2)
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
            table.Rows.Add("1", sp1.Rows[0]["Particular"], sp1.Rows[0]["Minor"], sp1.Rows[0]["Major"], sp1.Rows[0]["Fatal"], "0", sp2.Rows[0]["Minor"], sp2.Rows[0]["Major"], sp2.Rows[0]["Fatal"], "0");
            table.Rows.Add("2", sp1.Rows[1]["Particular"], sp1.Rows[1]["Minor"], sp1.Rows[1]["Major"], sp1.Rows[1]["Fatal"], "0", sp2.Rows[1]["Minor"], sp2.Rows[1]["Major"], sp2.Rows[1]["Fatal"], "0");
            table.Rows.Add("3", sp1.Rows[2]["Particular"], sp1.Rows[2]["Minor"], sp1.Rows[2]["Major"], sp1.Rows[2]["Fatal"], "0", sp2.Rows[2]["Minor"], sp2.Rows[2]["Major"], sp2.Rows[2]["Fatal"], "0");
            table.Rows.Add("4", sp1.Rows[3]["Particular"], sp1.Rows[3]["Minor"], sp1.Rows[3]["Major"], sp1.Rows[3]["Fatal"], "0", sp2.Rows[3]["Minor"], sp2.Rows[3]["Major"], sp2.Rows[3]["Fatal"], "0");
            table.Rows.Add("5", sp1.Rows[4]["Particular"], sp1.Rows[4]["Minor"], sp1.Rows[4]["Major"], sp1.Rows[4]["Fatal"], "0", sp2.Rows[4]["Minor"], sp2.Rows[4]["Major"], sp2.Rows[4]["Fatal"], "0");
            table.Rows.Add("6", sp1.Rows[5]["Particular"], sp1.Rows[5]["Minor"], sp1.Rows[5]["Major"], sp1.Rows[5]["Fatal"], "0", sp2.Rows[5]["Minor"], sp2.Rows[5]["Major"], sp2.Rows[5]["Fatal"], "0");
            table.Rows.Add("7", sp1.Rows[6]["Particular"], sp1.Rows[6]["Minor"], sp1.Rows[6]["Major"], sp1.Rows[6]["Fatal"], "0", sp2.Rows[6]["Minor"], sp2.Rows[6]["Major"], sp2.Rows[6]["Fatal"], "0");
            table.Rows.Add("8", sp1.Rows[7]["Particular"], sp1.Rows[7]["Minor"], sp1.Rows[7]["Major"], sp1.Rows[7]["Fatal"], "0", sp2.Rows[7]["Minor"], sp2.Rows[7]["Major"], sp2.Rows[7]["Fatal"], "0");
            table.Rows.Add("9", sp1.Rows[8]["Particular"], sp1.Rows[8]["Minor"], sp1.Rows[8]["Major"], sp1.Rows[8]["Fatal"], "0", sp2.Rows[8]["Minor"], sp2.Rows[8]["Major"], sp2.Rows[8]["Fatal"], "0");
            table.Rows.Add("10", sp1.Rows[9]["Particular"], sp1.Rows[9]["Minor"], sp1.Rows[9]["Major"], sp1.Rows[9]["Fatal"], "0", sp2.Rows[9]["Minor"], sp2.Rows[9]["Major"], sp2.Rows[9]["Fatal"], "0");
            table.Rows.Add("11", sp1.Rows[10]["Particular"], sp1.Rows[10]["Minor"], sp1.Rows[10]["Major"], sp1.Rows[10]["Fatal"], "0", sp2.Rows[10]["Minor"], sp2.Rows[10]["Major"], sp2.Rows[10]["Fatal"], "0");
            table.Rows.Add("12", sp1.Rows[11]["Particular"], sp1.Rows[11]["Minor"], sp1.Rows[11]["Major"], sp1.Rows[11]["Fatal"], "0", sp2.Rows[11]["Minor"], sp2.Rows[11]["Major"], sp2.Rows[11]["Fatal"], "0");
            table.Rows.Add("13", sp1.Rows[12]["Particular"], sp1.Rows[12]["Minor"], sp1.Rows[12]["Major"], sp1.Rows[12]["Fatal"], "0", sp2.Rows[12]["Minor"], sp2.Rows[12]["Major"], sp2.Rows[12]["Fatal"], "0");
            table.Rows.Add("14", sp1.Rows[13]["Particular"], sp1.Rows[13]["Minor"], sp1.Rows[13]["Major"], sp1.Rows[13]["Fatal"], "0", sp2.Rows[13]["Minor"], sp2.Rows[13]["Major"], sp2.Rows[13]["Fatal"], "0");
            table.Rows.Add("15", sp1.Rows[14]["Particular"], sp1.Rows[14]["Minor"], sp1.Rows[14]["Major"], sp1.Rows[14]["Fatal"], "0", sp2.Rows[14]["Minor"], sp2.Rows[14]["Major"], sp2.Rows[14]["Fatal"], "0");
            table.Rows.Add("16", sp1.Rows[15]["Particular"], sp1.Rows[15]["Minor"], sp1.Rows[15]["Major"], sp1.Rows[15]["Fatal"], "0", sp2.Rows[15]["Minor"], sp2.Rows[15]["Major"], sp2.Rows[15]["Fatal"], "0");
            table.Rows.Add("17", sp1.Rows[16]["Particular"], sp1.Rows[16]["Minor"], sp1.Rows[16]["Major"], sp1.Rows[16]["Fatal"], "0", sp2.Rows[16]["Minor"], sp2.Rows[16]["Major"], sp2.Rows[16]["Fatal"], "0");
            table.Rows.Add("18", sp1.Rows[17]["Particular"], sp1.Rows[17]["Minor"], sp1.Rows[17]["Major"], sp1.Rows[17]["Fatal"], "0", sp2.Rows[17]["Minor"], sp2.Rows[17]["Major"], sp2.Rows[17]["Fatal"], "0");
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
