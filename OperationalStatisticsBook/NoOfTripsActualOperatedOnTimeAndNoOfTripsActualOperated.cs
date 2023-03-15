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
    public partial class NoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "0";
        string finYear = "0";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public NoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7],[Param8] FROM [rpt].[tbl_NoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);


                DataTable autoSpTable = new DataTable();
                SqlCommand cmd1 = new SqlCommand("NoofTripsactOperatedOnTimeNWithinTwoMinutesOSB4_7", con);
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
                    dataGridView1.DataSource = BindNoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperatedForSp(autoSpTable);
                }

                else
                {
                    dataGridView1.DataSource = BindNoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated();
                }

                SetRowColNonEditable();
                CalcalculateTotal();
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

        DataTable BindNoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated()
        {
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[9] {
                            new DataColumn("S.No", typeof(string)),
                            new DataColumn("Param1", typeof(string)),
                            new DataColumn("Param2", typeof(string)),
                            new DataColumn("Param3", typeof(string)),
                            new DataColumn("Param4", typeof(string)),
                            new DataColumn("Param5", typeof(string)),
                            new DataColumn("Param6", typeof(string)),
                            new DataColumn("Param7", typeof(string)),
                            new DataColumn("Param8", typeof(string))

                });
            //           table.Columns.Add("S.No", typeof(string));
            //           table.Columns.Add("Unit", typeof(string));
            //           table.Columns.Add("No. of Trips", typeof(string));
            //           table.Columns.Add("No. of Trips ", typeof(string));
            //           table.Columns.Add("No. of Trips  ", typeof(string));
            //           table.Columns.Add("No. of Trips   ", typeof(string));
            //           table.Columns.Add("% of Trips", typeof(string));
            //           table.Columns.Add("% of Trips ", typeof(string));
            //           table.Columns.Add("% of Trips  ", typeof(string));

            //Rows......
            // table.Rows.Add("S.No ", "Unit ", "No. of Trips ", "No. of Trips", "No. of Trips", "No. of Trips", "% of Trips ", "% of Trips", "% of Trips");
            // table.Rows.Add(" ", " ", "Total Scheduled Trip ", "Total Actual Trip", "Act. Trips on-time", "Actual Trips late within2 min.", "Total % ", "Act. Ontime %", "Actual late Within 2 min.% ");
            //  table.Rows.Add("", " ", "A", "B", "C","D","B/A","C/A","D/A");
            table.Rows.Add("1", "B.B.M. ", "", "", "", "", "", "", "");
            table.Rows.Add("2 ", "Rohini-I", "", "", "", "", "", "", "");
            table.Rows.Add("3 ", "Rohini-II", "", "", "", "", "", "", "");
            table.Rows.Add("4 ", "Rohini-III ", "", "", "", "", "", "", "");
            table.Rows.Add("5 ", "Rohini-IV", "", "", "", "", "", "", "");
            table.Rows.Add("6 ", "Wazir Pur", "", "", "", "", "", "", "");
            table.Rows.Add("7 ", "Subhash Place", "", "", "", "", "", "", "");
            table.Rows.Add("8 ", "G.T.K. Rd.", "", "", "", "", "", "", "");
            table.Rows.Add("9 ", "Rohini-III ", "", "", "", "", "", "", "");
            table.Rows.Add("10 ", "Nangloi", "", "", "", "", "", "", "");
            table.Rows.Add("11", "NARELA", "", "", "", "", "", "", "");
            table.Rows.Add("12", "Rohini sec. 37 ", "", "", "", "", "", "", "");
            table.Rows.Add(" ", "Total North Region", "", "", "", "", "", "", "");
            table.Rows.Add("13", "Kalka Ji", "", "", "", "", "", "", "");
            table.Rows.Add("14", "SNPD ", "", "", "", "", "", "", "");
            table.Rows.Add("15", "Ambedkar Nagar", "", "", "", "", "", "", "");
            table.Rows.Add("16", "Vasant Vihar", "", "", "", "", "", "", "");
            table.Rows.Add("17", "Tehkhand", "", "", "", "", "", "", "");
            table.Rows.Add("18", "Sukhdev Vihar", "", "", "", "", "", "", "");
            table.Rows.Add("19", "Sarojni Nagar", "", "", "", "", "", "", "");
            table.Rows.Add(" ", "Total South Region", "", "", "", "", "", "", "");
            table.Rows.Add("20", "Nand Nagri ", "", "", "", "", "", "", "");
            table.Rows.Add("21", "NOIDA", "", "", "", "", "", "", "");
            table.Rows.Add("22", "East venod Nagar", "", "", "", "", "", "", "");
            table.Rows.Add("23", "Hasan Pur", "", "", "", "", "", "", "");
            table.Rows.Add("24", "Gazi Pur", "", "", "", "", "", "", "");
            table.Rows.Add("25", "Raj Ghat-I", "", "", "", "", "", "", "");
            table.Rows.Add("26", "Raj Ghat-II", "", "", "", "", "", "", "");
            table.Rows.Add(" ", "Total East Region", "", "", "", "", "", "", "");
            table.Rows.Add("27", "Hari Nagar-I", "", "", "", "", "", "", "");
            table.Rows.Add("28", "Hari Nagar-II ", "", "", "", "", "", "", "");
            table.Rows.Add("29", "Kesho Pur", "", "", "", "", "", "", "");
            table.Rows.Add("30", "Naraina", "", "", "", "", "", "", "");
            table.Rows.Add("31", "Shadi Pur", "", "", "", "", "", "", "");
            table.Rows.Add("32", "BAGDOLA", "", "", "", "", "", "", "");
            table.Rows.Add("33", "DW.SEC- 2 ", "", "", "", "", "", "", "");
            table.Rows.Add("34", "Maya Puri", "", "", "", "", "", "", "");
            table.Rows.Add("35", "Dichaon Kalan", "", "", "", "", "", "", "");
            table.Rows.Add("36", "Peera Garhi   ", "", "", "", "", "", "", "");
            table.Rows.Add("37", "Mundhela kalan ", "", "", "", "", "", "", "");
            table.Rows.Add(" ", "Total West Region", "", "", "", "", "", "", "");
            table.Rows.Add(" ", "Grand Total", "", "", "", "", "", "", "");

            return table;
        }

        DataTable BindNoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperatedForSp(DataTable sp)
        {
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[9] {
                            new DataColumn("S.No", typeof(string)),
                            new DataColumn("Param1", typeof(string)),
                            new DataColumn("Param2", typeof(string)),
                            new DataColumn("Param3", typeof(string)),
                            new DataColumn("Param4", typeof(string)),
                            new DataColumn("Param5", typeof(string)),
                            new DataColumn("Param6", typeof(string)),
                            new DataColumn("Param7", typeof(string)),
                            new DataColumn("Param8", typeof(string))

                });


            DataColumn regionOrder = sp.Columns["regionOrder"];
            int rgorder = 1;
            int rgorder2 = 1;
            int rgorder3 = 1;
            int rgorder4 = 1;
            foreach (DataRow row in sp.Rows)
            {

                if ((int)row[regionOrder] == 1 && rgorder == 1)
                {
                    table.Rows.Add("1 ", sp.Rows[0]["CircleName"].ToString(), sp.Rows[0]["ScheduleTrip"].ToString(), sp.Rows[0]["ActualTrip"].ToString(), sp.Rows[0]["ActualTripOnTime"].ToString(), sp.Rows[0]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("2 ", sp.Rows[1]["CircleName"].ToString(), sp.Rows[1]["ScheduleTrip"].ToString(), sp.Rows[1]["ActualTrip"].ToString(), sp.Rows[1]["ActualTripOnTime"].ToString(), sp.Rows[1]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("3 ", sp.Rows[2]["CircleName"].ToString(), sp.Rows[2]["ScheduleTrip"].ToString(), sp.Rows[2]["ActualTrip"].ToString(), sp.Rows[2]["ActualTripOnTime"].ToString(), sp.Rows[2]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("4 ", sp.Rows[3]["CircleName"].ToString(), sp.Rows[3]["ScheduleTrip"].ToString(), sp.Rows[3]["ActualTrip"].ToString(), sp.Rows[3]["ActualTripOnTime"].ToString(), sp.Rows[3]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("5 ", sp.Rows[4]["CircleName"].ToString(), sp.Rows[4]["ScheduleTrip"].ToString(), sp.Rows[4]["ActualTrip"].ToString(), sp.Rows[4]["ActualTripOnTime"].ToString(), sp.Rows[4]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("6 ", sp.Rows[5]["CircleName"].ToString(), sp.Rows[5]["ScheduleTrip"].ToString(), sp.Rows[5]["ActualTrip"].ToString(), sp.Rows[5]["ActualTripOnTime"].ToString(), sp.Rows[5]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("7 ", sp.Rows[6]["CircleName"].ToString(), sp.Rows[6]["ScheduleTrip"].ToString(), sp.Rows[6]["ActualTrip"].ToString(), sp.Rows[6]["ActualTripOnTime"].ToString(), sp.Rows[6]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("8 ", sp.Rows[7]["CircleName"].ToString(), sp.Rows[7]["ScheduleTrip"].ToString(), sp.Rows[7]["ActualTrip"].ToString(), sp.Rows[7]["ActualTripOnTime"].ToString(), sp.Rows[7]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("9 ", sp.Rows[8]["CircleName"].ToString(), sp.Rows[8]["ScheduleTrip"].ToString(), sp.Rows[8]["ActualTrip"].ToString(), sp.Rows[8]["ActualTripOnTime"].ToString(), sp.Rows[8]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("10", sp.Rows[9]["CircleName"].ToString(), sp.Rows[9]["ScheduleTrip"].ToString(), sp.Rows[9]["ActualTrip"].ToString(), sp.Rows[9]["ActualTripOnTime"].ToString(), sp.Rows[9]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("11", sp.Rows[10]["CircleName"].ToString(), sp.Rows[10]["ScheduleTrip"].ToString(), sp.Rows[10]["ActualTrip"].ToString(), sp.Rows[10]["ActualTripOnTime"].ToString(), sp.Rows[10]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("12", sp.Rows[11]["CircleName"].ToString(), sp.Rows[11]["ScheduleTrip"].ToString(), sp.Rows[11]["ActualTrip"].ToString(), sp.Rows[11]["ActualTripOnTime"].ToString(), sp.Rows[11]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("Total North Region", "", "", "", "", "", "", "", "");
                    rgorder = 2;
                }
                if ((int)row[regionOrder] == 2 && rgorder2 == 1)
                {
                    table.Rows.Add("13", sp.Rows[12]["CircleName"].ToString(), sp.Rows[12]["ScheduleTrip"].ToString(), sp.Rows[12]["ActualTrip"].ToString(), sp.Rows[12]["ActualTripOnTime"].ToString(), sp.Rows[12]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("14", sp.Rows[13]["CircleName"].ToString(), sp.Rows[13]["ScheduleTrip"].ToString(), sp.Rows[13]["ActualTrip"].ToString(), sp.Rows[13]["ActualTripOnTime"].ToString(), sp.Rows[13]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("15", sp.Rows[14]["CircleName"].ToString(), sp.Rows[14]["ScheduleTrip"].ToString(), sp.Rows[14]["ActualTrip"].ToString(), sp.Rows[14]["ActualTripOnTime"].ToString(), sp.Rows[14]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("16", sp.Rows[15]["CircleName"].ToString(), sp.Rows[15]["ScheduleTrip"].ToString(), sp.Rows[15]["ActualTrip"].ToString(), sp.Rows[15]["ActualTripOnTime"].ToString(), sp.Rows[15]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("17", sp.Rows[16]["CircleName"].ToString(), sp.Rows[16]["ScheduleTrip"].ToString(), sp.Rows[16]["ActualTrip"].ToString(), sp.Rows[16]["ActualTripOnTime"].ToString(), sp.Rows[16]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("18", sp.Rows[17]["CircleName"].ToString(), sp.Rows[17]["ScheduleTrip"].ToString(), sp.Rows[17]["ActualTrip"].ToString(), sp.Rows[17]["ActualTripOnTime"].ToString(), sp.Rows[17]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("19", sp.Rows[18]["CircleName"].ToString(), sp.Rows[18]["ScheduleTrip"].ToString(), sp.Rows[18]["ActualTrip"].ToString(), sp.Rows[18]["ActualTripOnTime"].ToString(), sp.Rows[18]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("Total South Region", "", "", "", "", "", "", "", "");
                    rgorder2 = 2;
                }
                if ((int)row[regionOrder] == 3 && rgorder3 == 1)
                {
                    table.Rows.Add("20", sp.Rows[19]["CircleName"].ToString(), sp.Rows[19]["ScheduleTrip"].ToString(), sp.Rows[19]["ActualTrip"].ToString(), sp.Rows[19]["ActualTripOnTime"].ToString(), sp.Rows[19]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("21", sp.Rows[20]["CircleName"].ToString(), sp.Rows[20]["ScheduleTrip"].ToString(), sp.Rows[20]["ActualTrip"].ToString(), sp.Rows[20]["ActualTripOnTime"].ToString(), sp.Rows[20]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("22", sp.Rows[21]["CircleName"].ToString(), sp.Rows[21]["ScheduleTrip"].ToString(), sp.Rows[21]["ActualTrip"].ToString(), sp.Rows[21]["ActualTripOnTime"].ToString(), sp.Rows[21]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("23", sp.Rows[22]["CircleName"].ToString(), sp.Rows[22]["ScheduleTrip"].ToString(), sp.Rows[22]["ActualTrip"].ToString(), sp.Rows[22]["ActualTripOnTime"].ToString(), sp.Rows[22]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("24", sp.Rows[23]["CircleName"].ToString(), sp.Rows[23]["ScheduleTrip"].ToString(), sp.Rows[23]["ActualTrip"].ToString(), sp.Rows[23]["ActualTripOnTime"].ToString(), sp.Rows[23]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("25", sp.Rows[24]["CircleName"].ToString(), sp.Rows[24]["ScheduleTrip"].ToString(), sp.Rows[24]["ActualTrip"].ToString(), sp.Rows[24]["ActualTripOnTime"].ToString(), sp.Rows[24]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("26", sp.Rows[25]["CircleName"].ToString(), sp.Rows[25]["ScheduleTrip"].ToString(), sp.Rows[25]["ActualTrip"].ToString(), sp.Rows[25]["ActualTripOnTime"].ToString(), sp.Rows[25]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("Total East Region", "", "", "", "", "", "", "", "");
                    rgorder3 = 2;
                }
                if ((int)row[regionOrder] == 4 && rgorder4 == 1)
                {
                    table.Rows.Add("27", sp.Rows[26]["CircleName"].ToString(), sp.Rows[26]["ScheduleTrip"].ToString(), sp.Rows[26]["ActualTrip"].ToString(), sp.Rows[26]["ActualTripOnTime"].ToString(), sp.Rows[26]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("28", sp.Rows[27]["CircleName"].ToString(), sp.Rows[27]["ScheduleTrip"].ToString(), sp.Rows[27]["ActualTrip"].ToString(), sp.Rows[27]["ActualTripOnTime"].ToString(), sp.Rows[27]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("29", sp.Rows[28]["CircleName"].ToString(), sp.Rows[28]["ScheduleTrip"].ToString(), sp.Rows[28]["ActualTrip"].ToString(), sp.Rows[28]["ActualTripOnTime"].ToString(), sp.Rows[28]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("30", sp.Rows[29]["CircleName"].ToString(), sp.Rows[29]["ScheduleTrip"].ToString(), sp.Rows[29]["ActualTrip"].ToString(), sp.Rows[29]["ActualTripOnTime"].ToString(), sp.Rows[29]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("31", sp.Rows[30]["CircleName"].ToString(), sp.Rows[30]["ScheduleTrip"].ToString(), sp.Rows[30]["ActualTrip"].ToString(), sp.Rows[30]["ActualTripOnTime"].ToString(), sp.Rows[30]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("32", sp.Rows[31]["CircleName"].ToString(), sp.Rows[31]["ScheduleTrip"].ToString(), sp.Rows[31]["ActualTrip"].ToString(), sp.Rows[31]["ActualTripOnTime"].ToString(), sp.Rows[31]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("33", sp.Rows[32]["CircleName"].ToString(), sp.Rows[32]["ScheduleTrip"].ToString(), sp.Rows[32]["ActualTrip"].ToString(), sp.Rows[32]["ActualTripOnTime"].ToString(), sp.Rows[32]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("34", sp.Rows[33]["CircleName"].ToString(), sp.Rows[33]["ScheduleTrip"].ToString(), sp.Rows[33]["ActualTrip"].ToString(), sp.Rows[33]["ActualTripOnTime"].ToString(), sp.Rows[33]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("35", sp.Rows[34]["CircleName"].ToString(), sp.Rows[34]["ScheduleTrip"].ToString(), sp.Rows[34]["ActualTrip"].ToString(), sp.Rows[34]["ActualTripOnTime"].ToString(), sp.Rows[34]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("36", sp.Rows[35]["CircleName"].ToString(), sp.Rows[35]["ScheduleTrip"].ToString(), sp.Rows[35]["ActualTrip"].ToString(), sp.Rows[35]["ActualTripOnTime"].ToString(), sp.Rows[35]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("37", sp.Rows[36]["CircleName"].ToString(), sp.Rows[36]["ScheduleTrip"].ToString(), sp.Rows[36]["ActualTrip"].ToString(), sp.Rows[36]["ActualTripOnTime"].ToString(), sp.Rows[36]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("Total West Region", "", "", "", "", "", "", "", "");
                    rgorder4 = 2;
                }

            }
            table.Rows.Add("Grand Total", "", "", "", "", "", "", "", "");

            return table;
        }

        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_NoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated", OsbId);
            dataGridView1.DataSource = BindNoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_NoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated", OsbId);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_NoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated] ([OsbId],[S_No],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8]) VALUES (@OsbId,@S_No,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8)", con);
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

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    DeleteExisitingTableRecord("tbl_NoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated", OsbId);
        //    dataGridView1.DataSource = BindNoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated();
        //    SetRowColNonEditable();
        //    MessageBox.Show("Done");
        //}

        private void NoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
        }

        private void Print_ReportOnClick(object sender, EventArgs e)
        {
            rptNoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated objFrm = new rptNoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        void CalcalculateTotal()
        {
            var row = dataGridView1.Rows;

            #region Calculating_VerticalSum


            for (int i = 2; i <= 5; i++)
            {
                dataGridView1.Rows[12].Cells[i].Value = Common.GetSum(row, 0, 11, i);
                dataGridView1.Rows[20].Cells[i].Value = Common.GetSum(row, 13, 19, i);
                dataGridView1.Rows[28].Cells[i].Value = Common.GetSum(row, 21, 27, i);
                dataGridView1.Rows[40].Cells[i].Value = Common.GetSum(row, 29, 39, i);
                dataGridView1.Rows[41].Cells[i].Value = Common.ConvertToDecimal(dataGridView1.Rows[40].Cells[i].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[28].Cells[i].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[20].Cells[i].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[12].Cells[i].Value.ToString());
            }

            //dataGridView1.Rows[12].Cells[2].Value = Common.GetSum(row, 0, 11, 2);
            //dataGridView1.Rows[12].Cells[3].Value = Common.GetSum(row, 0, 11, 3);
            //dataGridView1.Rows[12].Cells[4].Value = Common.GetSum(row, 0, 11, 4);
            //dataGridView1.Rows[12].Cells[5].Value = Common.GetSum(row, 0, 11, 5);

            //dataGridView1.Rows[20].Cells[2].Value = Common.GetSum(row, 13, 19, 2);
            //dataGridView1.Rows[20].Cells[3].Value = Common.GetSum(row, 13, 19, 3);
            //dataGridView1.Rows[20].Cells[4].Value = Common.GetSum(row, 13, 19, 4);
            //dataGridView1.Rows[20].Cells[5].Value = Common.GetSum(row, 13, 19, 5);

            //dataGridView1.Rows[28].Cells[2].Value = Common.GetSum(row, 21, 27, 2);
            //dataGridView1.Rows[28].Cells[3].Value = Common.GetSum(row, 21, 27, 3);
            //dataGridView1.Rows[28].Cells[4].Value = Common.GetSum(row, 21, 27, 4);
            //dataGridView1.Rows[28].Cells[5].Value = Common.GetSum(row, 21, 27, 5);

            //dataGridView1.Rows[40].Cells[2].Value = Common.GetSum(row, 29, 39, 2);
            //dataGridView1.Rows[40].Cells[3].Value = Common.GetSum(row, 29, 39, 3);
            //dataGridView1.Rows[40].Cells[4].Value = Common.GetSum(row, 29, 39, 4);
            //dataGridView1.Rows[40].Cells[5].Value = Common.GetSum(row, 29, 39, 5);

            //dataGridView1.Rows[41].Cells[2].Value = Common.ConvertToDecimal(dataGridView1.Rows[40].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[28].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[20].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[12].Cells[2].Value.ToString());
            //dataGridView1.Rows[41].Cells[3].Value = Common.ConvertToDecimal(dataGridView1.Rows[40].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[28].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[20].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[12].Cells[3].Value.ToString());
            //dataGridView1.Rows[41].Cells[4].Value = Common.ConvertToDecimal(dataGridView1.Rows[40].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[28].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[20].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[12].Cells[4].Value.ToString());
            //dataGridView1.Rows[41].Cells[5].Value = Common.ConvertToDecimal(dataGridView1.Rows[40].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[28].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[20].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[12].Cells[5].Value.ToString());



            #endregion

            #region Calculating_HorizontalSum
            for (int i = 0; i < (row.Count - 1); i++)
            {
                dataGridView1.Rows[i].Cells[6].Value = Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[2].Value.ToString())) * 100, 2) : 0;
                dataGridView1.Rows[i].Cells[7].Value = Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[2].Value.ToString())) * 100, 2) : 0;
                dataGridView1.Rows[i].Cells[8].Value = Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[i].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[2].Value.ToString())) * 100, 2) : 0;
            }
            #endregion

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcalculateTotal();
        }

        private void SetRowColNonEditable()
        {
            Common.SetRowNonEditable(dataGridView1, 12);
            Common.SetRowNonEditable(dataGridView1, 20);
            Common.SetRowNonEditable(dataGridView1, 28);
            Common.SetRowNonEditable(dataGridView1, 40);
            Common.SetRowNonEditable(dataGridView1, 41);

            Common.SetColumnNonEditable(dataGridView1, 6);
            Common.SetColumnNonEditable(dataGridView1, 7);
            Common.SetColumnNonEditable(dataGridView1, 8);
        }
    }
}
