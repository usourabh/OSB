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

        DataTable BindDepotWiseOprationalDataInRespectOfNonAC_Sp(DataTable sp)
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


            DataColumn regionOrder = sp.Columns["regionOrder"];
            int rgorder = 1;
            int rgorder2 = 1;
            int rgorder3 = 1;
            int rgorder4 = 1;
            foreach (DataRow row in sp.Rows)
            {

                if ((int)row[regionOrder] == 1 && rgorder == 1)
                {

                    for (int i = 0; i < 12; i++)
                    {

                        decimal earningPerDayConductor = (Convert.ToDecimal(sp.Rows[i]["DailyTrafficIncome"]) / Convert.ToInt32(sp.Rows[i]["NoOfConductors"]));
                        table.Rows.Add(i + 1, sp.Rows[i]["CircleName"].ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["SchKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["ActKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["kilometerEffciency"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["DailyOperatedKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["KmPerBusPerDay"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["MonthlyTrafficIncome"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["DailyTrafficIncome"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["TrafficIncomePerKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["TrafficIncomePerBusPerDay"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["TotalAccident"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["AccidentPer1LakhKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["NoOfDrivers"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["KMPerDayPerDriver"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["NoOfConductors"]), 0).ToString(),
                            Math.Round(earningPerDayConductor, 0)
                                  );
                    }

                    table.Rows.Add("0", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "0");
                    table.Rows.Add(" ", "Total North Region", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
                    rgorder = 2;
                }


                if ((int)row[regionOrder] == 2 && rgorder2 == 1)
                {


                    for (int i = 12; i < 19; i++)
                    {
                        decimal earningPerDayConductor = (Convert.ToDecimal(sp.Rows[i]["DailyTrafficIncome"]) / Convert.ToInt32(sp.Rows[i]["NoOfConductors"]));
                        table.Rows.Add(i + 1, sp.Rows[i]["CircleName"].ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["SchKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["ActKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["kilometerEffciency"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["DailyOperatedKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["KmPerBusPerDay"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["MonthlyTrafficIncome"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["DailyTrafficIncome"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["TrafficIncomePerKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["TrafficIncomePerBusPerDay"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["TotalAccident"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["AccidentPer1LakhKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["NoOfDrivers"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["KMPerDayPerDriver"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["NoOfConductors"]), 0).ToString(),
                            Math.Round(earningPerDayConductor, 0)
                                  );
                    }

                    table.Rows.Add(" ", "Total South Region", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
                    rgorder2 = 2;
                }


                if ((int)row[regionOrder] == 3 && rgorder3 == 1)
                {


                    for (int i = 19; i < 26; i++)
                    {
                        decimal earningPerDayConductor = (Convert.ToDecimal(sp.Rows[i]["DailyTrafficIncome"]) / Convert.ToInt32(sp.Rows[i]["NoOfConductors"]));
                        table.Rows.Add(i + 1, sp.Rows[i]["CircleName"].ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["SchKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["ActKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["kilometerEffciency"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["DailyOperatedKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["KmPerBusPerDay"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["MonthlyTrafficIncome"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["DailyTrafficIncome"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["TrafficIncomePerKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["TrafficIncomePerBusPerDay"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["TotalAccident"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["AccidentPer1LakhKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["NoOfDrivers"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["KMPerDayPerDriver"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["NoOfConductors"]), 0).ToString(),
                            Math.Round(earningPerDayConductor, 0)
                                  );
                    }

                    table.Rows.Add(" ", "Total East Region", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
                    rgorder3 = 2;
                }


                if ((int)row[regionOrder] == 4 && rgorder4 == 1)
                {


                    for (int i = 26; i < 37; i++)
                    {
                        decimal earningPerDayConductor = (Convert.ToDecimal(sp.Rows[i]["DailyTrafficIncome"]) / Convert.ToInt32(sp.Rows[i]["NoOfConductors"]));
                        table.Rows.Add(i + 1, sp.Rows[i]["CircleName"].ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["SchKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["ActKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["kilometerEffciency"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["DailyOperatedKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["KmPerBusPerDay"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["MonthlyTrafficIncome"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["DailyTrafficIncome"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["TrafficIncomePerKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["TrafficIncomePerBusPerDay"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["TotalAccident"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["AccidentPer1LakhKm"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["NoOfDrivers"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["KMPerDayPerDriver"]), 0).ToString(),
                            Math.Round(Convert.ToDecimal(sp.Rows[i]["NoOfConductors"]), 0).ToString(),
                            Math.Round(earningPerDayConductor, 0)
                                  );
                    }

                    table.Rows.Add(" ", "Total West", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
                    table.Rows.Add(" ", "Grand Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
                    rgorder4 = 2;
                }

            }


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

                DataTable autoSpTable = new DataTable();
                SqlCommand cmd1 = new SqlCommand("[dbo].[DepotWiseOperationalDataOSB4_6]", con);
                cmd1.Parameters.AddWithValue("@month", Month);
                cmd1.Parameters.AddWithValue("@year", Year);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                cmd1.CommandTimeout = 350;
                sda1.Fill(autoSpTable);


                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    Save.BackColor = Color.Green;
                    CalcalculateTotal();
                }

                else if (autoSpTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = BindDepotWiseOprationalDataInRespectOfNonAC_Sp(autoSpTable);
                }


                else
                {
                    dataGridView1.DataSource = BindDepotWiseOprationalDataInRespectOfNonAC();
                }

                CalcalculateTotal();
                //setRowColNonEditable();

            }
            catch (Exception ex)
            {
                throw ex;
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
            setRowColNonEditable();
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

            DateTime currentDate = new DateTime(Year, Month, 01);
            int lastDayofTheMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);

            for (int i = 0; i <= 43; i++)
            {
                ////Kilometer efficiency formula
                //dataGridView1.Rows[i].Cells[4].Value = Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[3].Value.ToString())) * 100, 2) : 0;

                //// Traffic Income per km Paise
                //dataGridView1.Rows[i].Cells[9].Value = Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[3].Value.ToString())) * 100, 0) : 0;

                //// Accident per 100,000 Km
                //dataGridView1.Rows[i].Cells[12].Value = Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) > 0 ? Math.Round(((Common.ConvertToDecimal(row[i].Cells[11].Value.ToString()) * 100000) / Common.ConvertToDecimal(row[i].Cells[3].Value.ToString())), 2) : 0;

                ////Driver kilometer per day/ drivers
                //dataGridView1.Rows[i].Cells[14].Value = Common.ConvertToDecimal(row[i].Cells[13].Value.ToString()) > 0 ? (Common.ConvertToDecimal(row[i].Cells[13].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[5].Value.ToString())) * 100 : 0;

                // Earning per day / per conductor
                //dataGridView1.Rows[i].Cells[16].Value = Common.ConvertToDecimal(row[i].Cells[15].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[i].Cells[8].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[15].Value.ToString())), 0) : 0;



                //if condition will not run for total every region and for grand total also
                if (i != 13 && i != 21 && i != 30 && i != 42 && i != 43)
                {
                    // For Daily Operated km
                    dataGridView1.Rows[i].Cells[5].Value = lastDayofTheMonth > 0 ? (Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) / lastDayofTheMonth) : 0;
                    dataGridView1.Rows[i].Cells[8].Value = lastDayofTheMonth > 0 ? Math.Round((Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()) / lastDayofTheMonth), 0) : 0;
                }

            }




            #region Calculating_VerticalSum

            for (int i = 2; i <= 16; i++)
            {

                if (i != 4 && i != 6 && i != 9 && i != 10 && i != 12 && i != 14 && i != 16)
                {
                    //Total region wise
                    dataGridView1.Rows[13].Cells[i].Value = Common.GetSum(row, 0, 12, i);
                    dataGridView1.Rows[21].Cells[i].Value = Common.GetSum(row, 14, 20, i);
                    dataGridView1.Rows[29].Cells[i].Value = Common.GetSum(row, 22, 29, i);
                    dataGridView1.Rows[41].Cells[i].Value = Common.GetSum(row, 31, 41, i);
                }
            }

            for (int i = 2; i <= 16; i++)
            {
                // grand total
                // Grand Total will not run for kilometer efficiency
                if (i != 4 && i != 6 && i != 9 && i != 10 && i != 12 && i != 14 && i != 16)
                {
                    dataGridView1.Rows[42].Cells[i].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[i].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[21].Cells[i].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[30].Cells[i].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[42].Cells[i].Value.ToString());
                }

            }
            #endregion

        }

        private void setRowColNonEditable()
        {

            Common.SetRowNonEditable(dataGridView1, 13);
            Common.SetRowNonEditable(dataGridView1, 21);
            Common.SetRowNonEditable(dataGridView1, 30);
            Common.SetRowNonEditable(dataGridView1, 42);
            Common.SetRowNonEditable(dataGridView1, 43);
        }

    }
}
