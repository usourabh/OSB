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
    public partial class ComparativeAnalysisOfCausesOfAccidents : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public ComparativeAnalysisOfCausesOfAccidents(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] ,[Param5] FROM [rpt].[tbl_ComparativeAnalysisOfCausesOfAccidents] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                DataTable autoSpTable = new DataTable();
                SqlCommand cmd1 = new SqlCommand("sp_AnalysisOfCausesAccidentsMonthlyOSB5_1", con);
                cmd1.Parameters.AddWithValue("@month", Month);
                cmd1.Parameters.AddWithValue("@year", Year);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(autoSpTable);

                DataTable autoSpTable2 = new DataTable();
                SqlCommand cmd2 = new SqlCommand("sp_AnalysisOfCausesAccidentsMonthlyOSB5_1", con);
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
                    dataGridView1.DataSource = BindComparativeAnalysisOfCausesOfAccidents_sp(autoSpTable, autoSpTable2);
                }

                else
                {
                    dataGridView1.DataSource = BindComparativeAnalysisOfCausesOfAccidents();
                }

                Common.SetRowNonEditable(dataGridView1, 17);
                Common.SetColumnNonEditable(dataGridView1, 3);
                Common.SetColumnNonEditable(dataGridView1, 5);

                CalucalateFormula();


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

        DataTable BindComparativeAnalysisOfCausesOfAccidents()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("S_NO", typeof(string)),
                            new DataColumn("Param1", typeof(string)),
                            new DataColumn("Param2",typeof(string)),
                            new DataColumn("Param3",typeof(string)),
                            new DataColumn("Param4",typeof(string)),
                            new DataColumn("Param5",typeof(string))
            });

            DateTime currentDate = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate.AddYears(+1);
            string currentYear = currentDate.Year.ToString();
            string previousYear = newDate.Year.ToString();
            String previousMonthName = newDate.ToString("MMMM");

            // Rows

            // dt.Rows.Add("S_No", "Particulars", previousMonthName + ' ' + previousYear, previousMonthName + "  " + previousYear, previousMonthName + ' ' + currentYear, previousMonthName + "  " + currentYear);
            // dt.Rows.Add("", "", "Absolute", "%Age", "Absolute", "%Age");
            // dt.Rows.Add("1", "2", "3", "4", "5", "6");
            dt.Rows.Add("1", "Rash & Negligence Driving", "", "", "", "");
            dt.Rows.Add("a", "D.T.C", "0", "0", "0", "0");
            dt.Rows.Add("b", "Other", "0", "0", "0", "0");
            dt.Rows.Add("2", "Error of Judgement", "", "", "", "");
            dt.Rows.Add("a", "D.T.C", "0", "0", "0", "0");
            dt.Rows.Add("b", "Other", "0", "0", "0", "0");
            dt.Rows.Add("3", "Mechanical Defect", "", "", "", "");
            dt.Rows.Add("a", "D.T.C", "0", "0", "0", "0");
            dt.Rows.Add("b", "Other", "0", "0", "0", "0");
            dt.Rows.Add("4", "Lack of road sense", "0", "0", "0", "0");
            dt.Rows.Add("5", "Aligthing Passengers", "", "", "", "");
            dt.Rows.Add("a", "Front Gate", "0", "0", "0", "0");
            dt.Rows.Add("b", "Rear Gate", "0", "0", "0", "0");
            dt.Rows.Add("6", "Boarding Passengers", "", "", "", "");
            dt.Rows.Add("a", "Front Gate", "0", "0", "0", "0");
            dt.Rows.Add("b", "Rear Gate", "0", "0", "0", "0");
            dt.Rows.Add("7", "Contributory / Miscellaneous", "0", "0", "0", "0");
            dt.Rows.Add("", "Total", "0", "0", "0", "0");

            return dt;
        }

        DataTable BindComparativeAnalysisOfCausesOfAccidents_sp(DataTable sp, DataTable sp1)
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("S_NO", typeof(string)),
                            new DataColumn("Param1", typeof(string)),
                            new DataColumn("Param2",typeof(string)),
                            new DataColumn("Param3",typeof(string)),
                            new DataColumn("Param4",typeof(string)),
                            new DataColumn("Param5",typeof(string))
            });

            DateTime currentDate = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate.AddYears(+1);
            string currentYear = currentDate.Year.ToString();
            string previousYear = newDate.Year.ToString();
            String previousMonthName = newDate.ToString("MMMM");

            // Rows

            // dt.Rows.Add("S_No", "Particulars", previousMonthName + ' ' + previousYear, previousMonthName + "  " + previousYear, previousMonthName + ' ' + currentYear, previousMonthName + "  " + currentYear);
            // dt.Rows.Add("", "", "Absolute", "%Age", "Absolute", "%Age");
            // dt.Rows.Add("1", "2", "3", "4", "5", "6");
            dt.Rows.Add("1", "Rash & Negligence Driving", "", "", "", "");
            dt.Rows.Add("a", "D.T.C", sp.Rows[0]["RashNegligenceDTC"], "0", sp1.Rows[0]["RashNegligenceDTC"], "0");
            dt.Rows.Add("b", "Other", sp.Rows[0]["RashNegligenceOTHER"], "0", sp1.Rows[0]["RashNegligenceOTHER"], "0");
            dt.Rows.Add("2", "Error of Judgement", " ", "", "", "");
            dt.Rows.Add("a", "D.T.C", sp.Rows[0]["ErrorOfJudgementDTC"], "0", sp1.Rows[0]["ErrorOfJudgementDTC"], "0");
            dt.Rows.Add("b", "Other", sp.Rows[0]["ErrorOfJudgementOTHER"], "0", sp1.Rows[0]["ErrorOfJudgementOTHER"], "0");
            dt.Rows.Add("3", "Mechanical Defect", " ", "", "", "");
            dt.Rows.Add("a", "D.T.C", sp.Rows[0]["MechanicalDefectDTC"], "0", sp1.Rows[0]["MechanicalDefectDTC"], "0");
            dt.Rows.Add("b", "Other", sp.Rows[0]["MechanicalDefectOTHER"], "0", sp1.Rows[0]["MechanicalDefectOTHER"], "0");
            dt.Rows.Add("4", "Lack of road sense", sp.Rows[0]["LackOfRoadSense"], "0", sp1.Rows[0]["LackOfRoadSense"], "0");
            dt.Rows.Add("5", "Aligthing Passengers", " ", "", "", "");
            dt.Rows.Add("a", "Front Gate", sp.Rows[0]["AligthingPassengers"], "0", sp1.Rows[0]["AligthingPassengers"], "0");
            dt.Rows.Add("b", "Rear Gate", "0", "0", "0", "0");
            dt.Rows.Add("6", "Boarding Passengers", " ", "", "", "");
            dt.Rows.Add("a", "Front Gate", sp.Rows[0]["BoardingPassengers"], "0", sp1.Rows[0]["BoardingPassengers"], "0");
            dt.Rows.Add("b", "Rear Gate", "0", "0", "0", "0");
            dt.Rows.Add("7", "Contributory / Miscellaneous", sp.Rows[0]["Miscellaneous"], "0", sp1.Rows[0]["Miscellaneous"], "0");
            dt.Rows.Add("", "Total", "0", "0", "0", "0");

            return dt;
        }

        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingdtRecord("tbl_ComparativeAnalysisOfCausesOfAccidents", OsbId);
            dataGridView1.DataSource = BindComparativeAnalysisOfCausesOfAccidents();
            MessageBox.Show("Done");
            Common.SetRowNonEditable(dataGridView1, 17);
            Common.SetColumnNonEditable(dataGridView1, 3);
            Common.SetColumnNonEditable(dataGridView1, 5);
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingdtRecord("tbl_ComparativeAnalysisOfCausesOfAccidents", OsbId);
            CalucalateFormula();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_ComparativeAnalysisOfCausesOfAccidents] ([OsbId],[S_No],[Param1],[Param2],[Param3],[Param4],[Param5]) VALUES (@OsbId,@S_No,@Param1,@Param2,@Param3,@Param4,@Param5)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@S_No", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
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

        private void ComparativeAnalysisOfCausesOfAccidents_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);

        }

        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptComparativeAnalysisOfCausesOfAccidents objFrm = new rptComparativeAnalysisOfCausesOfAccidents(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        void CalucalateFormula()
        {

            var row = dataGridView1.Rows;


            // PERCENTAGE
            dataGridView1.Rows[1].Cells[3].Value = Common.ConvertToDecimal(row[17].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[1].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[2].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[2].Cells[3].Value = Common.ConvertToDecimal(row[17].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[2].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[2].Value.ToString())) * 100, 2) : 0;

            dataGridView1.Rows[4].Cells[3].Value = Common.ConvertToDecimal(row[17].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[2].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[5].Cells[3].Value = Common.ConvertToDecimal(row[17].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[5].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[2].Value.ToString())) * 100, 2) : 0;

            dataGridView1.Rows[7].Cells[3].Value = Common.ConvertToDecimal(row[17].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[7].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[2].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[8].Cells[3].Value = Common.ConvertToDecimal(row[17].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[8].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[2].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[9].Cells[3].Value = Common.ConvertToDecimal(row[17].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[2].Value.ToString())) * 100, 2) : 0;

            dataGridView1.Rows[11].Cells[3].Value = Common.ConvertToDecimal(row[17].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[11].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[2].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[12].Cells[3].Value = Common.ConvertToDecimal(row[17].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[12].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[2].Value.ToString())) * 100, 2) : 0;

            dataGridView1.Rows[14].Cells[3].Value = Common.ConvertToDecimal(row[17].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[14].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[2].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[15].Cells[3].Value = Common.ConvertToDecimal(row[17].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[15].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[2].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[16].Cells[3].Value = Common.ConvertToDecimal(row[17].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[2].Value.ToString())) * 100, 2) : 0;

            // Percentage-----------------------------------------------------------------------------------------------------------

            dataGridView1.Rows[1].Cells[5].Value = Common.ConvertToDecimal(row[17].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[1].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[4].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[2].Cells[5].Value = Common.ConvertToDecimal(row[17].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[2].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[4].Value.ToString())) * 100, 2) : 0;

            dataGridView1.Rows[4].Cells[5].Value = Common.ConvertToDecimal(row[17].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[4].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[5].Cells[5].Value = Common.ConvertToDecimal(row[17].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[5].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[4].Value.ToString())) * 100, 2) : 0;

            dataGridView1.Rows[7].Cells[5].Value = Common.ConvertToDecimal(row[17].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[7].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[4].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[8].Cells[5].Value = Common.ConvertToDecimal(row[17].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[8].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[4].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[9].Cells[5].Value = Common.ConvertToDecimal(row[17].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[4].Value.ToString())) * 100, 2) : 0;

            dataGridView1.Rows[11].Cells[5].Value = Common.ConvertToDecimal(row[17].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[11].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[4].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[12].Cells[5].Value = Common.ConvertToDecimal(row[17].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[12].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[4].Value.ToString())) * 100, 2) : 0;

            dataGridView1.Rows[14].Cells[5].Value = Common.ConvertToDecimal(row[17].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[14].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[4].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[15].Cells[5].Value = Common.ConvertToDecimal(row[17].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[15].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[4].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[16].Cells[5].Value = Common.ConvertToDecimal(row[17].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[16].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[17].Cells[4].Value.ToString())) * 100, 2) : 0;

            // Total
            dataGridView1.Rows[17].Cells[2].Value = Common.GetSum(row, 1, 16, 2);
            dataGridView1.Rows[17].Cells[3].Value = Common.GetSum(row, 1, 16, 3);
            dataGridView1.Rows[17].Cells[4].Value = Common.GetSum(row, 1, 16, 4);
            dataGridView1.Rows[17].Cells[5].Value = Common.GetSum(row, 1, 16, 5);


        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalucalateFormula();
        }
    }
}