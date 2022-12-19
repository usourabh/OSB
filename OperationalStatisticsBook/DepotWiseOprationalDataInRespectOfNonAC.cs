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
    public partial class DepotWiseOprationalDataInRespectOfNonAC : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public DepotWiseOprationalDataInRespectOfNonAC(int OsbId, int Year, int Month, string finYear, string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;
        }

        DataTable BindDepotWiseOprationalDataInRespectOfNonAC()
        {
            DataTable table = new DataTable();

            table.Columns.Add("For The Month of July-2022", typeof(string));
            table.Columns.Add("For The Month of July-2022 ", typeof(string));
            table.Columns.Add("For The Month of July-2022  ", typeof(string));
            table.Columns.Add("For The Month of July-2022   ", typeof(string));
            table.Columns.Add("For The Month of July-2022    ", typeof(string));
            table.Columns.Add("For The Month of July-2022     ", typeof(string));
            table.Columns.Add("For The Month of July-2022      ", typeof(string));
            table.Columns.Add("For The Month of July-2022       ", typeof(string));
            table.Columns.Add("For The Month of July-2022        ", typeof(string));
            table.Columns.Add("For The Month of July-2022         ", typeof(string));
            table.Columns.Add("For The Month of July-2022                          ", typeof(string));
            table.Columns.Add("For The Month of July-2022          ", typeof(string));
            table.Columns.Add("  For The Month of July-2022             ", typeof(string));
            table.Columns.Add(" For The Month of July-2022                  ", typeof(string));
            table.Columns.Add("  For The Month of July-2022     ", typeof(string));
            table.Columns.Add("  For The Month of July-2022       ", typeof(string));
            table.Columns.Add("  For The Month of July-2022  ", typeof(string));

            //table.Rows.Add("Sr.No.", "Name Of the Depot", "Analysis of km.", "Analysis of km.", "Analysis of km.", "Analysis of km.", "Analysis of km.", "Traffic Income", "Traffic Income", "Traffic Income", "Traffic Income", "Accident", "Accident", "Drivers", "Drivers","Conductors", "Conductors");
            //table.Rows.Add(" ", " ", "Total km.(Number)", "Total km.(Number)", "Killometer Efficiency(%)", "Daily Operated Killometers", "Killometers per bus per day(No.)", "Monthly Traffic Income(Rs.)", "Daily Traffic Income(Rs.) ", "Traffic Income per km(paise)", "Traffic Income per bus oer day(Rs.)", "Total Accident (No).", "Accident Per 100000 kms", "No of Drivers", "Killometers per day /Drivers","Nos of Conductors", "Earning per day /Conductors");
            //table.Rows.Add(" ", " ", "Scheduled", "Operated", "", "", "", "", "", "", "", "", "", "", "", "", "");
            //table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17");
            table.Rows.Add("1", "BBM ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "RH-1  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "RH-2 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "RH-3 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "RH-4 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "WP ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "Sub. Pl. ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("8", "GTK ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("9", "Bawana ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("10", "NLD ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("11", "Kanj. ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("12", "Narala ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("13", "RH. Sec.37  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "Total North Region", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("14", "KJ ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("15", "SNP  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("16", "AN  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("17", "VV  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("18", "TK ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("19", "SV ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("20", "SN  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "Total South Region", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("21", "NN ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("22", "NOIDA ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("23", "EVN  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("24", "HP  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("25", "IP ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("26", "GP ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("27", "RG-1 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("28", "RG-2 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "Total East Region", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("29", "HN-1  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("30", "HN-2 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("31", "KP  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("32", "ND ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("33", "SP", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("34", "Bagdola", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("35", "Dw. Sec.2 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("36", "MP", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("37", "DK", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("38", "PG", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("39", "MK", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "Total West", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "Grand Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");






            return table;
        }

        void BindIndexPage(int OsbId)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16] FROM [rpt].[tbl_DepotWiseOprationalDataInRespectOfNonACNAC] where OsbId=@OsbId", con);
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
                    dataGridView1.DataSource = BindDepotWiseOprationalDataInRespectOfNonAC();
                }

                CalcalculateTotal();

                Common.SetRowNonEditable(dataGridView1, 14);
                Common.SetRowNonEditable(dataGridView1, 22);
                Common.SetRowNonEditable(dataGridView1, 31);
                Common.SetRowNonEditable(dataGridView1, 43);
                Common.SetRowNonEditable(dataGridView1, 44);

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



        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DepotWiseOprationalDataInRespectOfNonACNAC", OsbId);
            dataGridView1.DataSource = BindDepotWiseOprationalDataInRespectOfNonAC();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DepotWiseOprationalDataInRespectOfNonACNAC", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null || row.Cells[11].Value != null || row.Cells[12].Value != null || row.Cells[13].Value != null || row.Cells[14].Value != null || row.Cells[15].Value != null || row.Cells[16].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_DepotWiseOprationalDataInRespectOfNonACNAC] ([OsbId],[S_No],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16]) VALUES (@OsbId,@S_No,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11,@Param12,@Param13,@Param14,@Param15,@Param16)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@S_No", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param6", row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param7", row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param8", row.Cells[8].Value == null ? "" : row.Cells[8].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param9", row.Cells[9].Value == null ? "" : row.Cells[9].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param10", row.Cells[10].Value == null ? "" : row.Cells[10].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param11", row.Cells[11].Value == null ? "" : row.Cells[11].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param12", row.Cells[12].Value == null ? "" : row.Cells[12].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param13", row.Cells[13].Value == null ? "" : row.Cells[13].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param14", row.Cells[14].Value == null ? "" : row.Cells[14].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param15", row.Cells[15].Value == null ? "" : row.Cells[15].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param16", row.Cells[16].Value == null ? "" : row.Cells[16].Value.ToString());
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
            DeleteExisitingTableRecord("tbl_DepotWiseOprationalDataInRespectOfNonACNAC", OsbId);
            dataGridView1.DataSource = BindDepotWiseOprationalDataInRespectOfNonAC();
            Common.SetRowNonEditable(dataGridView1, 14);
            Common.SetRowNonEditable(dataGridView1, 22);
            Common.SetRowNonEditable(dataGridView1, 31);
            Common.SetRowNonEditable(dataGridView1, 43);
            Common.SetRowNonEditable(dataGridView1, 44);
            MessageBox.Show("Done");
        }
        private void DepotWiseOprationalDataInRespectOfNonAC_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = BindDepotWiseOprationalDataInRespectOfNonAC();
            BindIndexPage(OsbId);
        }

        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptDepotWiseOprationalDataInRespectOfNonAC objFrm = new rptDepotWiseOprationalDataInRespectOfNonAC(OsbId, Year, Month, finYear, MonthName);
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

            for (int i = 2; i <= 16; i++)
            {
                dataGridView1.Rows[14].Cells[i].Value = Common.GetSum(row, 1, 13, i);
                dataGridView1.Rows[22].Cells[i].Value = Common.GetSum(row, 15, 21, i);
                dataGridView1.Rows[31].Cells[i].Value = Common.GetSum(row, 23, 30, i);
                dataGridView1.Rows[43].Cells[i].Value = Common.GetSum(row, 32, 42, i);

            }


            //dataGridView1.Rows[13].Cells[2].Value = Common.GetSum(row, 0, 12, 2);
            //dataGridView1.Rows[13].Cells[3].Value = Common.GetSum(row, 0, 12, 3);
            //dataGridView1.Rows[13].Cells[4].Value = Common.GetSum(row, 0, 12, 4);
            //dataGridView1.Rows[13].Cells[5].Value = Common.GetSum(row, 0, 12, 5);
            //dataGridView1.Rows[13].Cells[6].Value = Common.GetSum(row, 0, 12, 6);
            //dataGridView1.Rows[13].Cells[7].Value = Common.GetSum(row, 0, 12, 7);
            //dataGridView1.Rows[13].Cells[8].Value = Common.GetSum(row, 0, 12, 8);
            //dataGridView1.Rows[13].Cells[9].Value = Common.GetSum(row, 0, 12, 9);
            //dataGridView1.Rows[13].Cells[10].Value = Common.GetSum(row, 0, 12, 10);
            //dataGridView1.Rows[13].Cells[11].Value = Common.GetSum(row, 0, 12, 11);
            //dataGridView1.Rows[13].Cells[12].Value = Common.GetSum(row, 0, 12, 12);
            //dataGridView1.Rows[13].Cells[13].Value = Common.GetSum(row, 0, 12, 13);
            //dataGridView1.Rows[13].Cells[14].Value = Common.GetSum(row, 0, 12, 14);
            //dataGridView1.Rows[13].Cells[15].Value = Common.GetSum(row, 0, 12, 15);
            //dataGridView1.Rows[13].Cells[16].Value = Common.GetSum(row, 0, 12, 16);

            //dataGridView1.Rows[21].Cells[2].Value = Common.GetSum(row, 14, 20, 2);
            //dataGridView1.Rows[21].Cells[3].Value = Common.GetSum(row, 14, 20, 3);
            //dataGridView1.Rows[21].Cells[4].Value = Common.GetSum(row, 14, 20, 4);
            //dataGridView1.Rows[21].Cells[5].Value = Common.GetSum(row, 14, 20, 5);
            //dataGridView1.Rows[21].Cells[6].Value = Common.GetSum(row, 14, 20, 6);
            //dataGridView1.Rows[21].Cells[7].Value = Common.GetSum(row, 14, 20, 7);
            //dataGridView1.Rows[21].Cells[8].Value = Common.GetSum(row, 14, 20, 8);
            //dataGridView1.Rows[21].Cells[9].Value = Common.GetSum(row, 14, 20, 9);
            //dataGridView1.Rows[21].Cells[10].Value = Common.GetSum(row, 14, 20, 10);
            //dataGridView1.Rows[21].Cells[11].Value = Common.GetSum(row, 14, 20, 11);
            //dataGridView1.Rows[21].Cells[12].Value = Common.GetSum(row, 14, 20, 12);
            //dataGridView1.Rows[21].Cells[13].Value = Common.GetSum(row, 14, 20, 13);
            //dataGridView1.Rows[21].Cells[14].Value = Common.GetSum(row, 14, 20, 14);
            //dataGridView1.Rows[21].Cells[15].Value = Common.GetSum(row, 14, 20, 15);
            //dataGridView1.Rows[21].Cells[16].Value = Common.GetSum(row, 14, 20, 16);


            //dataGridView1.Rows[29].Cells[2].Value = Common.GetSum(row, 22, 28, 2);
            //dataGridView1.Rows[29].Cells[3].Value = Common.GetSum(row, 22, 28, 3);
            //dataGridView1.Rows[29].Cells[4].Value = Common.GetSum(row, 22, 28, 4);
            //dataGridView1.Rows[29].Cells[5].Value = Common.GetSum(row, 22, 28, 5);
            //dataGridView1.Rows[29].Cells[6].Value = Common.GetSum(row, 22, 28, 6);
            //dataGridView1.Rows[29].Cells[7].Value = Common.GetSum(row, 22, 28, 7);
            //dataGridView1.Rows[29].Cells[8].Value = Common.GetSum(row, 22, 28, 8);
            //dataGridView1.Rows[29].Cells[9].Value = Common.GetSum(row, 22, 28, 9);
            //dataGridView1.Rows[29].Cells[10].Value = Common.GetSum(row, 22, 28, 10);
            //dataGridView1.Rows[29].Cells[11].Value = Common.GetSum(row, 22, 28, 11);
            //dataGridView1.Rows[29].Cells[12].Value = Common.GetSum(row, 22, 28, 12);
            //dataGridView1.Rows[29].Cells[13].Value = Common.GetSum(row, 22, 28, 13);
            //dataGridView1.Rows[29].Cells[14].Value = Common.GetSum(row, 22, 28, 14);
            //dataGridView1.Rows[29].Cells[15].Value = Common.GetSum(row, 22, 28, 15);
            //dataGridView1.Rows[29].Cells[16].Value = Common.GetSum(row, 22, 28, 16);

            //dataGridView1.Rows[41].Cells[2].Value = Common.GetSum(row, 30, 40, 2);
            //dataGridView1.Rows[41].Cells[3].Value = Common.GetSum(row, 30, 40, 3);
            //dataGridView1.Rows[41].Cells[4].Value = Common.GetSum(row, 30, 40, 4);
            //dataGridView1.Rows[41].Cells[5].Value = Common.GetSum(row, 30, 40, 5);
            //dataGridView1.Rows[41].Cells[6].Value = Common.GetSum(row, 30, 40, 6);
            //dataGridView1.Rows[41].Cells[7].Value = Common.GetSum(row, 30, 40, 7);
            //dataGridView1.Rows[41].Cells[8].Value = Common.GetSum(row, 30, 40, 8);
            //dataGridView1.Rows[41].Cells[9].Value = Common.GetSum(row, 30, 40, 9);
            //dataGridView1.Rows[41].Cells[10].Value = Common.GetSum(row, 30, 40, 10);
            //dataGridView1.Rows[41].Cells[11].Value = Common.GetSum(row, 30, 40, 11);
            //dataGridView1.Rows[41].Cells[12].Value = Common.GetSum(row, 30, 40, 12);
            //dataGridView1.Rows[41].Cells[13].Value = Common.GetSum(row, 30, 40, 13);
            //dataGridView1.Rows[41].Cells[14].Value = Common.GetSum(row, 30, 40, 14);
            //dataGridView1.Rows[41].Cells[15].Value = Common.GetSum(row, 30, 40, 15);
            //dataGridView1.Rows[41].Cells[16].Value = Common.GetSum(row, 30, 40, 16);

            for (int i = 2; i <= 16; i++)
            {
                dataGridView1.Rows[44].Cells[i].Value = Common.ConvertToDecimal(dataGridView1.Rows[14].Cells[i].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[22].Cells[i].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[i].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[i].Value.ToString());

            }
            #endregion



        }

    }
}
