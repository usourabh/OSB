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



                DataTable autoSpTable = new DataTable();
                SqlCommand cmd1 = new SqlCommand("sp_DepotWiseTotalMissedKmsAndBreakdownforthemonthOSB4_8", con);
                cmd1.Parameters.AddWithValue("@month", Month);
                cmd1.Parameters.AddWithValue("@year", Year);
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
                    //dataGridView1.DataSource = autoSpTable;

                    dataGridView1.DataSource = BindDepotWiseTotalMissedKmsAndBreakdownsForSp(autoSpTable);
                }
                else
                {
                    dataGridView1.DataSource = BindDepotWiseTotalMissedKmsAndBreakdowns();

                }

                setRowColNonEditable();
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
            table.Rows.Add("26", "Raj Ghat-II", "0", "0", "0", "0", "0");
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

        DataTable BindDepotWiseTotalMissedKmsAndBreakdownsForSp(DataTable sp)
        {
            DataTable table = new DataTable();

            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Depot", typeof(string));
            table.Columns.Add("Missed Kms", typeof(string));
            table.Columns.Add("Breakdowns", typeof(string));
            table.Columns.Add("Breakdowns ", typeof(string));
            table.Columns.Add("Breakdowns  ", typeof(string));
            table.Columns.Add(" Breakdowns", typeof(string));


            DataColumn regionOrder = sp.Columns["regionOrder"];
            int rgorder = 1;
            int rgorder2 = 1;
            int rgorder3 = 1;
            int rgorder4 = 1;
            foreach (DataRow row in sp.Rows)
            {

                if ((int)row[regionOrder] == 1 && rgorder == 1)
                {
                    table.Rows.Add("1", sp.Rows[0]["CircleName"].ToString(), sp.Rows[0]["MissKm"].ToString(), sp.Rows[0]["BreakDownM"].ToString(), sp.Rows[0]["BreakDownE"].ToString(), sp.Rows[0]["BreakDownT"].ToString());
                    table.Rows.Add("2", sp.Rows[1]["CircleName"].ToString(), sp.Rows[1]["MissKm"].ToString(), sp.Rows[1]["BreakDownM"].ToString(), sp.Rows[1]["BreakDownE"].ToString(), sp.Rows[1]["BreakDownT"].ToString());
                    table.Rows.Add("3", sp.Rows[2]["CircleName"].ToString(), sp.Rows[2]["MissKm"].ToString(), sp.Rows[2]["BreakDownM"].ToString(), sp.Rows[2]["BreakDownE"].ToString(), sp.Rows[2]["BreakDownT"].ToString());
                    table.Rows.Add("4", sp.Rows[3]["CircleName"].ToString(), sp.Rows[3]["MissKm"].ToString(), sp.Rows[3]["BreakDownM"].ToString(), sp.Rows[3]["BreakDownE"].ToString(), sp.Rows[3]["BreakDownT"].ToString());
                    table.Rows.Add("5", sp.Rows[4]["CircleName"].ToString(), sp.Rows[4]["MissKm"].ToString(), sp.Rows[4]["BreakDownM"].ToString(), sp.Rows[4]["BreakDownE"].ToString(), sp.Rows[4]["BreakDownT"].ToString());
                    table.Rows.Add("6", sp.Rows[5]["CircleName"].ToString(), sp.Rows[5]["MissKm"].ToString(), sp.Rows[5]["BreakDownM"].ToString(), sp.Rows[5]["BreakDownE"].ToString(), sp.Rows[5]["BreakDownT"].ToString());
                    table.Rows.Add("7", sp.Rows[6]["CircleName"].ToString(), sp.Rows[6]["MissKm"].ToString(), sp.Rows[6]["BreakDownM"].ToString(), sp.Rows[6]["BreakDownE"].ToString(), sp.Rows[6]["BreakDownT"].ToString());
                    table.Rows.Add("8", sp.Rows[7]["CircleName"].ToString(), sp.Rows[7]["MissKm"].ToString(), sp.Rows[7]["BreakDownM"].ToString(), sp.Rows[7]["BreakDownE"].ToString(), sp.Rows[7]["BreakDownT"].ToString());
                    table.Rows.Add("9", sp.Rows[8]["CircleName"].ToString(), sp.Rows[8]["MissKm"].ToString(), sp.Rows[8]["BreakDownM"].ToString(), sp.Rows[8]["BreakDownE"].ToString(), sp.Rows[8]["BreakDownT"].ToString());
                    table.Rows.Add("10", sp.Rows[9]["CircleName"].ToString(), sp.Rows[9]["MissKm"].ToString(), sp.Rows[9]["BreakDownM"].ToString(), sp.Rows[9]["BreakDownE"].ToString(), sp.Rows[9]["BreakDownT"].ToString());
                    table.Rows.Add("11", sp.Rows[10]["CircleName"].ToString(), sp.Rows[10]["MissKm"].ToString(), sp.Rows[10]["BreakDownM"].ToString(), sp.Rows[10]["BreakDownE"].ToString(), sp.Rows[10]["BreakDownT"].ToString());
                    table.Rows.Add("12", sp.Rows[11]["CircleName"].ToString(), sp.Rows[11]["MissKm"].ToString(), sp.Rows[11]["BreakDownM"].ToString(), sp.Rows[11]["BreakDownE"].ToString(), sp.Rows[11]["BreakDownT"].ToString());
                    table.Rows.Add("North Region", "0", "0", "0", "0", "0", "0");
                    rgorder = 2;
                }
                if ((int)row[regionOrder] == 2 && rgorder2 == 1)
                {

                    table.Rows.Add("13", sp.Rows[12]["CircleName"].ToString(), sp.Rows[12]["MissKm"].ToString(), sp.Rows[12]["BreakDownM"].ToString(), sp.Rows[12]["BreakDownE"].ToString(), sp.Rows[12]["BreakDownT"].ToString());
                    table.Rows.Add("14", sp.Rows[13]["CircleName"].ToString(), sp.Rows[13]["MissKm"].ToString(), sp.Rows[13]["BreakDownM"].ToString(), sp.Rows[13]["BreakDownE"].ToString(), sp.Rows[13]["BreakDownT"].ToString());
                    table.Rows.Add("15", sp.Rows[14]["CircleName"].ToString(), sp.Rows[14]["MissKm"].ToString(), sp.Rows[14]["BreakDownM"].ToString(), sp.Rows[14]["BreakDownE"].ToString(), sp.Rows[14]["BreakDownT"].ToString());
                    table.Rows.Add("16", sp.Rows[15]["CircleName"].ToString(), sp.Rows[15]["MissKm"].ToString(), sp.Rows[15]["BreakDownM"].ToString(), sp.Rows[15]["BreakDownE"].ToString(), sp.Rows[15]["BreakDownT"].ToString());
                    table.Rows.Add("17", sp.Rows[16]["CircleName"].ToString(), sp.Rows[16]["MissKm"].ToString(), sp.Rows[16]["BreakDownM"].ToString(), sp.Rows[16]["BreakDownE"].ToString(), sp.Rows[16]["BreakDownT"].ToString());
                    table.Rows.Add("18", sp.Rows[17]["CircleName"].ToString(), sp.Rows[17]["MissKm"].ToString(), sp.Rows[17]["BreakDownM"].ToString(), sp.Rows[17]["BreakDownE"].ToString(), sp.Rows[17]["BreakDownT"].ToString());
                    table.Rows.Add("19", sp.Rows[18]["CircleName"].ToString(), sp.Rows[18]["MissKm"].ToString(), sp.Rows[18]["BreakDownM"].ToString(), sp.Rows[18]["BreakDownE"].ToString(), sp.Rows[18]["BreakDownT"].ToString());

                    table.Rows.Add("South Region", "South Region", "0", "0", "0", "0", "0");
                    rgorder2 = 2;
                }

                if ((int)row[regionOrder] == 3 && rgorder3 == 1)
                {

                    table.Rows.Add("20", sp.Rows[19]["CircleName"].ToString(), sp.Rows[19]["MissKm"].ToString(), sp.Rows[19]["BreakDownM"].ToString(), sp.Rows[19]["BreakDownE"].ToString(), sp.Rows[19]["BreakDownT"].ToString());
                    table.Rows.Add("21", sp.Rows[20]["CircleName"].ToString(), sp.Rows[20]["MissKm"].ToString(), sp.Rows[20]["BreakDownM"].ToString(), sp.Rows[20]["BreakDownE"].ToString(), sp.Rows[20]["BreakDownT"].ToString());
                    table.Rows.Add("22", sp.Rows[21]["CircleName"].ToString(), sp.Rows[21]["MissKm"].ToString(), sp.Rows[21]["BreakDownM"].ToString(), sp.Rows[21]["BreakDownE"].ToString(), sp.Rows[21]["BreakDownT"].ToString());
                    table.Rows.Add("23", sp.Rows[22]["CircleName"].ToString(), sp.Rows[22]["MissKm"].ToString(), sp.Rows[22]["BreakDownM"].ToString(), sp.Rows[22]["BreakDownE"].ToString(), sp.Rows[22]["BreakDownT"].ToString());
                    table.Rows.Add("24", sp.Rows[23]["CircleName"].ToString(), sp.Rows[23]["MissKm"].ToString(), sp.Rows[23]["BreakDownM"].ToString(), sp.Rows[23]["BreakDownE"].ToString(), sp.Rows[23]["BreakDownT"].ToString());
                    table.Rows.Add("25", sp.Rows[24]["CircleName"].ToString(), sp.Rows[24]["MissKm"].ToString(), sp.Rows[24]["BreakDownM"].ToString(), sp.Rows[24]["BreakDownE"].ToString(), sp.Rows[24]["BreakDownT"].ToString());
                    table.Rows.Add("26", sp.Rows[25]["CircleName"].ToString(), sp.Rows[25]["MissKm"].ToString(), sp.Rows[25]["BreakDownM"].ToString(), sp.Rows[25]["BreakDownE"].ToString(), sp.Rows[25]["BreakDownT"].ToString());

                    table.Rows.Add("East Region", "East Region", "0", "0", "0", "0", "0");
                    rgorder3 = 2;
                }

                if ((int)row[regionOrder] == 4 && rgorder4 == 1)
                {
                    table.Rows.Add("27", sp.Rows[26]["CircleName"].ToString(), sp.Rows[26]["MissKm"].ToString(), sp.Rows[26]["BreakDownM"].ToString(), sp.Rows[26]["BreakDownE"].ToString(), sp.Rows[26]["BreakDownT"].ToString());
                    table.Rows.Add("28", sp.Rows[27]["CircleName"].ToString(), sp.Rows[27]["MissKm"].ToString(), sp.Rows[27]["BreakDownM"].ToString(), sp.Rows[27]["BreakDownE"].ToString(), sp.Rows[27]["BreakDownT"].ToString());
                    table.Rows.Add("29", sp.Rows[28]["CircleName"].ToString(), sp.Rows[28]["MissKm"].ToString(), sp.Rows[28]["BreakDownM"].ToString(), sp.Rows[28]["BreakDownE"].ToString(), sp.Rows[28]["BreakDownT"].ToString());
                    table.Rows.Add("30", sp.Rows[29]["CircleName"].ToString(), sp.Rows[29]["MissKm"].ToString(), sp.Rows[29]["BreakDownM"].ToString(), sp.Rows[29]["BreakDownE"].ToString(), sp.Rows[29]["BreakDownT"].ToString());
                    table.Rows.Add("31", sp.Rows[30]["CircleName"].ToString(), sp.Rows[30]["MissKm"].ToString(), sp.Rows[30]["BreakDownM"].ToString(), sp.Rows[30]["BreakDownE"].ToString(), sp.Rows[30]["BreakDownT"].ToString());
                    table.Rows.Add("32", sp.Rows[31]["CircleName"].ToString(), sp.Rows[31]["MissKm"].ToString(), sp.Rows[31]["BreakDownM"].ToString(), sp.Rows[31]["BreakDownE"].ToString(), sp.Rows[31]["BreakDownT"].ToString());
                    table.Rows.Add("33", sp.Rows[32]["CircleName"].ToString(), sp.Rows[32]["MissKm"].ToString(), sp.Rows[32]["BreakDownM"].ToString(), sp.Rows[32]["BreakDownE"].ToString(), sp.Rows[32]["BreakDownT"].ToString());
                    table.Rows.Add("34", sp.Rows[33]["CircleName"].ToString(), sp.Rows[33]["MissKm"].ToString(), sp.Rows[33]["BreakDownM"].ToString(), sp.Rows[33]["BreakDownE"].ToString(), sp.Rows[33]["BreakDownT"].ToString());
                    table.Rows.Add("35", sp.Rows[34]["CircleName"].ToString(), sp.Rows[34]["MissKm"].ToString(), sp.Rows[34]["BreakDownM"].ToString(), sp.Rows[34]["BreakDownE"].ToString(), sp.Rows[34]["BreakDownT"].ToString());
                    table.Rows.Add("36", sp.Rows[35]["CircleName"].ToString(), sp.Rows[35]["MissKm"].ToString(), sp.Rows[35]["BreakDownM"].ToString(), sp.Rows[35]["BreakDownE"].ToString(), sp.Rows[35]["BreakDownT"].ToString());
                    table.Rows.Add("37", sp.Rows[36]["CircleName"].ToString(), sp.Rows[36]["MissKm"].ToString(), sp.Rows[36]["BreakDownM"].ToString(), sp.Rows[36]["BreakDownE"].ToString(), sp.Rows[36]["BreakDownT"].ToString());

                    table.Rows.Add("Total West", "Total West", "0", "0", "0", "0", "0");
                    rgorder4 = 2;
                }
            }

            table.Rows.Add("Grand Total", "Grand Total", "0", "0", "0", "0", "0");

            return table;
        }


        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DepotWiseTotalMissedKmsAndBreakdowns", OsbId);
            BindIndexPage(OsbId);
            setRowColNonEditable();
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

            dataGridView1.Rows[20].Cells[2].Value = Common.GetSum(row, 13, 19, 2);
            dataGridView1.Rows[20].Cells[3].Value = Common.GetSum(row, 13, 19, 3);
            dataGridView1.Rows[20].Cells[4].Value = Common.GetSum(row, 13, 19, 4);
            dataGridView1.Rows[20].Cells[5].Value = Common.GetSum(row, 13, 19, 5);

            dataGridView1.Rows[28].Cells[2].Value = Common.GetSum(row, 21, 27, 2);
            dataGridView1.Rows[28].Cells[3].Value = Common.GetSum(row, 21, 27, 3);
            dataGridView1.Rows[28].Cells[4].Value = Common.GetSum(row, 21, 27, 4);
            dataGridView1.Rows[28].Cells[5].Value = Common.GetSum(row, 21, 27, 5);

            dataGridView1.Rows[40].Cells[2].Value = Common.GetSum(row, 29, 39, 2);
            dataGridView1.Rows[40].Cells[3].Value = Common.GetSum(row, 29, 39, 3);
            dataGridView1.Rows[40].Cells[4].Value = Common.GetSum(row, 29, 39, 4);
            dataGridView1.Rows[40].Cells[5].Value = Common.GetSum(row, 29, 39, 5);

            dataGridView1.Rows[41].Cells[2].Value = Common.ConvertToDecimal(dataGridView1.Rows[40].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[28].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[20].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[12].Cells[2].Value.ToString());
            dataGridView1.Rows[41].Cells[3].Value = Common.ConvertToDecimal(dataGridView1.Rows[40].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[28].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[20].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[12].Cells[3].Value.ToString());
            dataGridView1.Rows[41].Cells[4].Value = Common.ConvertToDecimal(dataGridView1.Rows[40].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[28].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[20].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[12].Cells[4].Value.ToString());
            dataGridView1.Rows[41].Cells[5].Value = Common.ConvertToDecimal(dataGridView1.Rows[40].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[28].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[20].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[12].Cells[5].Value.ToString());



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

        private void setRowColNonEditable()
        {
            Common.SetRowNonEditable(dataGridView1, 12);
            Common.SetRowNonEditable(dataGridView1, 20);
            Common.SetRowNonEditable(dataGridView1, 28);
            Common.SetRowNonEditable(dataGridView1, 40);
            Common.SetRowNonEditable(dataGridView1, 41);

            Common.SetColumnNonEditable(dataGridView1, 6);
        }
    }
}
