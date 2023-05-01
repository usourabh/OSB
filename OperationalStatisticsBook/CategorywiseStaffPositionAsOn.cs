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
    public partial class CategorywiseStaffPositionAsOn : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);

        public CategorywiseStaffPositionAsOn(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Depot],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11] FROM [rpt].[tbl_CategorywiseStaffPositionAsOn] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);


                DataTable autoSpTable = new DataTable();
                SqlCommand cmd1 = new SqlCommand("[dbo].[CategoryWiseStaffPositionOSB_2]", con);
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
                    dataGridView1.DataSource = BindCategorywiseStaffPositionAsOn_Auto_Sp(autoSpTable);
                }

                else
                {
                    dataGridView1.DataSource = BindCategorywiseStaffPositionAsOn();
                }
                NonEditableRowAndColumn();
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

        DataTable BindCategorywiseStaffPositionAsOn()
        {
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[13] {
                            new DataColumn("S.No", typeof(string)),
                            new DataColumn("DEPOT", typeof(string)),
                            new DataColumn("Param1", typeof(string)),
                            new DataColumn("Param2", typeof(string)),
                            new DataColumn("Param3", typeof(string)),
                            new DataColumn("Param4", typeof(string)),
                            new DataColumn("Param5", typeof(string)),
                            new DataColumn("Param6", typeof(string)),
                            new DataColumn("Param7", typeof(string)),
                            new DataColumn("Param8", typeof(string)),
                            new DataColumn("Param9", typeof(string)),
                            new DataColumn("Param10", typeof(string)),
                            new DataColumn("Param11",typeof(string))
 });


            //table.Columns.Add("S.No", typeof(string));
            //table.Columns.Add("DEPOT", typeof(string));
            //table.Columns.Add("DRIVER ", typeof(string));
            //table.Columns.Add("DRIVER  ", typeof(string));
            //table.Columns.Add("DRIVER   ", typeof(string));
            //table.Columns.Add("Conductors   ", typeof(string));
            //table.Columns.Add("Conductors  ", typeof(string));
            //table.Columns.Add("Conductors", typeof(string));
            //table.Columns.Add("Traffic", typeof(string));
            //table.Columns.Add(" Repair &", typeof(string));
            //table.Columns.Add(" Admin", typeof(string));
            //table.Columns.Add(" Consultant ", typeof(string));
            //table.Columns.Add(" Total ", typeof(string));

            //Rows////
            //  table.Rows.Add("S.No ", " DEPOT ", "DRIVER", "DRIVER", "DRIVER", "Conductors", "Conductors", "Conductors", "Traffic", "Repair &", "Admin ", "Consultant  ", " Total ");
            //  table.Rows.Add(" ", " ", "M.R.", "CONT.", "TOTAL", "M.R.", "CONT.", "TOTAL", "Supervisor", "Maintence", " ", " ", " ");
            //  table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13");
            table.Rows.Add("1", "Banda Bahadur Marg ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Rohini-I ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Rohini-II ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Rohini-III ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Rohini-IV ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "Wazir Pur ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "Subhash Place ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("8", "Grand Trank Karnal Road ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("9", "Bawana ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("10", "Nangloi  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("11", "Kanjhawla  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("12", "Narela ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("13", "Rohini sec. 37  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "North Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("14", "Kalka Ji", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("15", "Sri Niwas puri ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("16", "Ambedkar Nagar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("17", "Vasant Vihar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("18", "Tehkhand ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("19", "Sukhdev Vihar ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("20", "Sarojni Nagar ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "South Total ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("21 ", "Nand Nagri ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("22 ", "NOIDA ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("23 ", "East Vinod Nagar ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("24", "HasanPur ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("25", "Inderprastha ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("26", "Yamuna Vihar ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("27", "Gazi Pur ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("28", "Raj Ghat-I ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("29", "Raj Ghat-II ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "East Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("30", "Hari Nagar-I", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("31", "Hari Nagar-II ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("32", "Hari Nagar-III", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("33", "Kesho Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("34", "Naraina", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("35", "Shadi Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("36", "BAGDOLA", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("37", "Dwarka, Sector-2", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("38", "Maya Puri ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("39", "Dichaon Kalan ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("40", "Peera Garhi ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("41", "Ghuman Hera ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("42", "Mundhela kalan", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "West Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Sup. Checking North", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Sup. Checking East", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Sup. Checking West", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Sup. Checking South", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "R&I H.Qrs.", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("43", "Bawana Sec. 1 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("44", "Bawana Sec. 5 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("45", "Rani Khera 1  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("46", "Rani Khera 2  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("47", "Rani Khera 3 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("48", "Inderprastha ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("49", "Yamuna Vihar ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("50", "Khadkhadi  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("51", "Dwarka, Sector-22", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("52", "Rewla (Khanpur) ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("53", "Ghuman Hera -1 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("54", "Ghuman Hera -2 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "FCMS Total.", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Grand Total.", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");


            return table;
        }

        DataTable BindCategorywiseStaffPositionAsOn_Auto_Sp(DataTable sp)
        {
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[13] {
                            new DataColumn("S.No", typeof(string)),
                            new DataColumn("DEPOT", typeof(string)),
                            new DataColumn("Param1", typeof(string)),
                            new DataColumn("Param2", typeof(string)),
                            new DataColumn("Param3", typeof(string)),
                            new DataColumn("Param4", typeof(string)),
                            new DataColumn("Param5", typeof(string)),
                            new DataColumn("Param6", typeof(string)),
                            new DataColumn("Param7", typeof(string)),
                            new DataColumn("Param8", typeof(string)),
                            new DataColumn("Param9", typeof(string)),
                            new DataColumn("Param10", typeof(string)),
                            new DataColumn("Param11",typeof(string))
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
                    for (int i = 0; i <= 12; i++)
                    {
                        table.Rows.Add(i + 1, sp.Rows[i]["CircleName"].ToString(), sp.Rows[i]["PrDriver"].ToString(), sp.Rows[i]["CrDriver"].ToString(), "0", sp.Rows[i]["PrConductor"].ToString(), sp.Rows[i]["CrConductor"].ToString(), "0", sp.Rows[i]["TrafficSuper"].ToString(), "0", "0", "0", "0");

                    }

                    //table.Rows.Add("1 ", sp.Rows[0]["CircleName"].ToString(), sp.Rows[0]["ScheduleTrip"].ToString(), sp.Rows[0]["ActualTrip"].ToString(), sp.Rows[0]["ActualTripOnTime"].ToString(), sp.Rows[0]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("2 ", sp.Rows[1]["CircleName"].ToString(), sp.Rows[1]["ScheduleTrip"].ToString(), sp.Rows[1]["ActualTrip"].ToString(), sp.Rows[1]["ActualTripOnTime"].ToString(), sp.Rows[1]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("3 ", sp.Rows[2]["CircleName"].ToString(), sp.Rows[2]["ScheduleTrip"].ToString(), sp.Rows[2]["ActualTrip"].ToString(), sp.Rows[2]["ActualTripOnTime"].ToString(), sp.Rows[2]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("4 ", sp.Rows[3]["CircleName"].ToString(), sp.Rows[3]["ScheduleTrip"].ToString(), sp.Rows[3]["ActualTrip"].ToString(), sp.Rows[3]["ActualTripOnTime"].ToString(), sp.Rows[3]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("5 ", sp.Rows[4]["CircleName"].ToString(), sp.Rows[4]["ScheduleTrip"].ToString(), sp.Rows[4]["ActualTrip"].ToString(), sp.Rows[4]["ActualTripOnTime"].ToString(), sp.Rows[4]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("6 ", sp.Rows[5]["CircleName"].ToString(), sp.Rows[5]["ScheduleTrip"].ToString(), sp.Rows[5]["ActualTrip"].ToString(), sp.Rows[5]["ActualTripOnTime"].ToString(), sp.Rows[5]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("7 ", sp.Rows[6]["CircleName"].ToString(), sp.Rows[6]["ScheduleTrip"].ToString(), sp.Rows[6]["ActualTrip"].ToString(), sp.Rows[6]["ActualTripOnTime"].ToString(), sp.Rows[6]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("8 ", sp.Rows[7]["CircleName"].ToString(), sp.Rows[7]["ScheduleTrip"].ToString(), sp.Rows[7]["ActualTrip"].ToString(), sp.Rows[7]["ActualTripOnTime"].ToString(), sp.Rows[7]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("9 ", sp.Rows[8]["CircleName"].ToString(), sp.Rows[8]["ScheduleTrip"].ToString(), sp.Rows[8]["ActualTrip"].ToString(), sp.Rows[8]["ActualTripOnTime"].ToString(), sp.Rows[8]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("10", sp.Rows[9]["CircleName"].ToString(), sp.Rows[9]["ScheduleTrip"].ToString(), sp.Rows[9]["ActualTrip"].ToString(), sp.Rows[9]["ActualTripOnTime"].ToString(), sp.Rows[9]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("11", sp.Rows[10]["CircleName"].ToString(), sp.Rows[10]["ScheduleTrip"].ToString(), sp.Rows[10]["ActualTrip"].ToString(), sp.Rows[10]["ActualTripOnTime"].ToString(), sp.Rows[10]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("12", sp.Rows[11]["CircleName"].ToString(), sp.Rows[11]["ScheduleTrip"].ToString(), sp.Rows[11]["ActualTrip"].ToString(), sp.Rows[11]["ActualTripOnTime"].ToString(), sp.Rows[11]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("13", sp.Rows[11]["CircleName"].ToString(), sp.Rows[11]["ScheduleTrip"].ToString(), sp.Rows[11]["ActualTrip"].ToString(), sp.Rows[11]["ActualTripOnTime"].ToString(), sp.Rows[11]["ActualTripwithin2Min"].ToString(), "", "", "");

                    table.Rows.Add("Total North Region", "", "", "", "", "", "", "", "");
                    rgorder = 2;
                }
                if ((int)row[regionOrder] == 2 && rgorder2 == 1)
                {

                    for (int i = 13; i <= 20; i++)
                    {
                        table.Rows.Add(i + 1, sp.Rows[i]["CircleName"].ToString(), sp.Rows[i]["PrDriver"].ToString(), sp.Rows[i]["CrDriver"].ToString(), "0", sp.Rows[i]["PrConductor"].ToString(), sp.Rows[i]["CrConductor"].ToString(), "0", sp.Rows[i]["TrafficSuper"].ToString(), "0", "0", "0", "0");

                    }


                    //table.Rows.Add("13", sp.Rows[12]["CircleName"].ToString(), sp.Rows[12]["ScheduleTrip"].ToString(), sp.Rows[12]["ActualTrip"].ToString(), sp.Rows[12]["ActualTripOnTime"].ToString(), sp.Rows[12]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("14", sp.Rows[13]["CircleName"].ToString(), sp.Rows[13]["ScheduleTrip"].ToString(), sp.Rows[13]["ActualTrip"].ToString(), sp.Rows[13]["ActualTripOnTime"].ToString(), sp.Rows[13]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("15", sp.Rows[14]["CircleName"].ToString(), sp.Rows[14]["ScheduleTrip"].ToString(), sp.Rows[14]["ActualTrip"].ToString(), sp.Rows[14]["ActualTripOnTime"].ToString(), sp.Rows[14]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("16", sp.Rows[15]["CircleName"].ToString(), sp.Rows[15]["ScheduleTrip"].ToString(), sp.Rows[15]["ActualTrip"].ToString(), sp.Rows[15]["ActualTripOnTime"].ToString(), sp.Rows[15]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("17", sp.Rows[16]["CircleName"].ToString(), sp.Rows[16]["ScheduleTrip"].ToString(), sp.Rows[16]["ActualTrip"].ToString(), sp.Rows[16]["ActualTripOnTime"].ToString(), sp.Rows[16]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("18", sp.Rows[17]["CircleName"].ToString(), sp.Rows[17]["ScheduleTrip"].ToString(), sp.Rows[17]["ActualTrip"].ToString(), sp.Rows[17]["ActualTripOnTime"].ToString(), sp.Rows[17]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("19", sp.Rows[18]["CircleName"].ToString(), sp.Rows[18]["ScheduleTrip"].ToString(), sp.Rows[18]["ActualTrip"].ToString(), sp.Rows[18]["ActualTripOnTime"].ToString(), sp.Rows[18]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("Total South Region", "", "", "", "", "", "", "", "");
                    rgorder2 = 2;
                }
                if ((int)row[regionOrder] == 3 && rgorder3 == 1)
                {

                    for (int i = 21; i <= 28; i++)
                    {
                        table.Rows.Add(i + 1, sp.Rows[i]["CircleName"].ToString(), sp.Rows[i]["PrDriver"].ToString(), sp.Rows[i]["CrDriver"].ToString(), "0", sp.Rows[i]["PrConductor"].ToString(), sp.Rows[i]["CrConductor"].ToString(), "0", sp.Rows[i]["TrafficSuper"].ToString(), "0", "0", "0", "0");

                    }



                    //table.Rows.Add("20", sp.Rows[19]["CircleName"].ToString(), sp.Rows[19]["ScheduleTrip"].ToString(), sp.Rows[19]["ActualTrip"].ToString(), sp.Rows[19]["ActualTripOnTime"].ToString(), sp.Rows[19]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("21", sp.Rows[20]["CircleName"].ToString(), sp.Rows[20]["ScheduleTrip"].ToString(), sp.Rows[20]["ActualTrip"].ToString(), sp.Rows[20]["ActualTripOnTime"].ToString(), sp.Rows[20]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("22", sp.Rows[21]["CircleName"].ToString(), sp.Rows[21]["ScheduleTrip"].ToString(), sp.Rows[21]["ActualTrip"].ToString(), sp.Rows[21]["ActualTripOnTime"].ToString(), sp.Rows[21]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("23", sp.Rows[22]["CircleName"].ToString(), sp.Rows[22]["ScheduleTrip"].ToString(), sp.Rows[22]["ActualTrip"].ToString(), sp.Rows[22]["ActualTripOnTime"].ToString(), sp.Rows[22]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("24", sp.Rows[23]["CircleName"].ToString(), sp.Rows[23]["ScheduleTrip"].ToString(), sp.Rows[23]["ActualTrip"].ToString(), sp.Rows[23]["ActualTripOnTime"].ToString(), sp.Rows[23]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("25", sp.Rows[24]["CircleName"].ToString(), sp.Rows[24]["ScheduleTrip"].ToString(), sp.Rows[24]["ActualTrip"].ToString(), sp.Rows[24]["ActualTripOnTime"].ToString(), sp.Rows[24]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("26", sp.Rows[25]["CircleName"].ToString(), sp.Rows[25]["ScheduleTrip"].ToString(), sp.Rows[25]["ActualTrip"].ToString(), sp.Rows[25]["ActualTripOnTime"].ToString(), sp.Rows[25]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("Total East Region", "", "", "", "", "", "", "", "");
                    rgorder3 = 2;
                }
                if ((int)row[regionOrder] == 4 && rgorder4 == 1)
                {

                    for (int i = 29; i <= 39; i++)
                    {
                        table.Rows.Add(i + 1, sp.Rows[i]["CircleName"].ToString(), sp.Rows[i]["PrDriver"].ToString(), sp.Rows[i]["CrDriver"].ToString(), "0", sp.Rows[i]["PrConductor"].ToString(), sp.Rows[i]["CrConductor"].ToString(), "0", sp.Rows[i]["TrafficSuper"].ToString(), "0", "0", "0", "0");
                    }


                    //table.Rows.Add("27", sp.Rows[26]["CircleName"].ToString(), sp.Rows[26]["ScheduleTrip"].ToString(), sp.Rows[26]["ActualTrip"].ToString(), sp.Rows[26]["ActualTripOnTime"].ToString(), sp.Rows[26]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("28", sp.Rows[27]["CircleName"].ToString(), sp.Rows[27]["ScheduleTrip"].ToString(), sp.Rows[27]["ActualTrip"].ToString(), sp.Rows[27]["ActualTripOnTime"].ToString(), sp.Rows[27]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("29", sp.Rows[28]["CircleName"].ToString(), sp.Rows[28]["ScheduleTrip"].ToString(), sp.Rows[28]["ActualTrip"].ToString(), sp.Rows[28]["ActualTripOnTime"].ToString(), sp.Rows[28]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("30", sp.Rows[29]["CircleName"].ToString(), sp.Rows[29]["ScheduleTrip"].ToString(), sp.Rows[29]["ActualTrip"].ToString(), sp.Rows[29]["ActualTripOnTime"].ToString(), sp.Rows[29]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("31", sp.Rows[30]["CircleName"].ToString(), sp.Rows[30]["ScheduleTrip"].ToString(), sp.Rows[30]["ActualTrip"].ToString(), sp.Rows[30]["ActualTripOnTime"].ToString(), sp.Rows[30]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("32", sp.Rows[31]["CircleName"].ToString(), sp.Rows[31]["ScheduleTrip"].ToString(), sp.Rows[31]["ActualTrip"].ToString(), sp.Rows[31]["ActualTripOnTime"].ToString(), sp.Rows[31]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("33", sp.Rows[32]["CircleName"].ToString(), sp.Rows[32]["ScheduleTrip"].ToString(), sp.Rows[32]["ActualTrip"].ToString(), sp.Rows[32]["ActualTripOnTime"].ToString(), sp.Rows[32]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("34", sp.Rows[33]["CircleName"].ToString(), sp.Rows[33]["ScheduleTrip"].ToString(), sp.Rows[33]["ActualTrip"].ToString(), sp.Rows[33]["ActualTripOnTime"].ToString(), sp.Rows[33]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("35", sp.Rows[34]["CircleName"].ToString(), sp.Rows[34]["ScheduleTrip"].ToString(), sp.Rows[34]["ActualTrip"].ToString(), sp.Rows[34]["ActualTripOnTime"].ToString(), sp.Rows[34]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("36", sp.Rows[35]["CircleName"].ToString(), sp.Rows[35]["ScheduleTrip"].ToString(), sp.Rows[35]["ActualTrip"].ToString(), sp.Rows[35]["ActualTripOnTime"].ToString(), sp.Rows[35]["ActualTripwithin2Min"].ToString(), "", "", "");
                    //table.Rows.Add("37", sp.Rows[36]["CircleName"].ToString(), sp.Rows[36]["ScheduleTrip"].ToString(), sp.Rows[36]["ActualTrip"].ToString(), sp.Rows[36]["ActualTripOnTime"].ToString(), sp.Rows[36]["ActualTripwithin2Min"].ToString(), "", "", "");
                    table.Rows.Add("Total West Region", "", "", "", "", "", "", "", "");
                    rgorder4 = 2;
                }

            }


            //table.Rows.Add("1", "Banda Bahadur Marg ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("2", "Rohini-I ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("3", "Rohini-II ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("4", "Rohini-III ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("5", "Rohini-IV ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("6", "Wazir Pur ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("7", "Subhash Place ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("8", "Grand Trank Karnal Road ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("9", "Bawana ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("10", "Nangloi  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("11", "Kanjhawla  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("12", "Narela ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("13", "Rohini sec. 37  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("", "North Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("14", "Kalka Ji", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("15", "Sri Niwas puri ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("16", "Ambedkar Nagar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("17", "Vasant Vihar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("18", "Tehkhand ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("19", "Sukhdev Vihar ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("20", "Sarojni Nagar ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("", "South Total ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("21 ", "Nand Nagri ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("22 ", "NOIDA ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("23 ", "East Vinod Nagar ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("24", "HasanPur ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("25", "Inderprastha ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("26", "Yamuna Vihar ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("27", "Gazi Pur ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("28", "Raj Ghat-I ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("29", "Raj Ghat-II ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("", "East Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("30", "Hari Nagar-I", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("31", "Hari Nagar-II ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("32", "Hari Nagar-III", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("33", "Kesho Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("34", "Naraina", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("35", "Shadi Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("36", "BAGDOLA", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("37", "Dwarka, Sector-2", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("38", "Maya Puri ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("39", "Dichaon Kalan ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("40", "Peera Garhi ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("41", "Ghuman Hera ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("42", "Mundhela kalan", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //table.Rows.Add("", "West Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Sup. Checking North", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Sup. Checking East", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Sup. Checking West", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Sup. Checking South", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "R&I H.Qrs.", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("43", "Bawana Sec. 1 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("44", "Bawana Sec. 5 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("45", "Rani Khera 1  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("46", "Rani Khera 2  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("47", "Rani Khera 3 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("48", "Inderprastha ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("49", "Yamuna Vihar ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("50", "Khadkhadi  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("51", "Dwarka, Sector-22", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("52", "Rewla (Khanpur) ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("53", "Ghuman Hera -1 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("54", "Ghuman Hera -2 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "FCMS Total.", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Grand Total.", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");


            return table;
        }


        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_CategorywiseStaffPositionAsOn", OsbId);
            dataGridView1.DataSource = BindCategorywiseStaffPositionAsOn();
            NonEditableRowAndColumn();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_CategorywiseStaffPositionAsOn", OsbId);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null || row.Cells[11].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_CategorywiseStaffPositionAsOn] ([OsbId],[S_No],[Depot],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11]) VALUES (@OsbId,@S_No,@Depot,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@S_No", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Depot", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param6", row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param7", row.Cells[8].Value == null ? "" : row.Cells[8].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param8", row.Cells[9].Value == null ? "" : row.Cells[9].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param9", row.Cells[10].Value == null ? "" : row.Cells[10].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param10", row.Cells[11].Value == null ? "" : row.Cells[11].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param11", row.Cells[12].Value == null ? "" : row.Cells[12].Value.ToString());
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
            DeleteExisitingTableRecord("tbl_CategorywiseStaffPositionAsOn", OsbId);
            dataGridView1.DataSource = BindCategorywiseStaffPositionAsOn();
            // NonEditableRowAndColumn();
            MessageBox.Show("Done");
        }
        private void CategorywiseStaffPositionAsOn_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
            //dataGridView1.DataSource = BindCategorywiseStaffPositionAsOn();
        }

        void CalcalculateTotal()
        {
            var row = dataGridView1.Rows;

            #region Calculating_VerticalSum

            // North Total
            dataGridView1.Rows[13].Cells[2].Value = Common.GetSum(row, 0, 12, 2);
            dataGridView1.Rows[13].Cells[3].Value = Common.GetSum(row, 0, 12, 3);
            dataGridView1.Rows[13].Cells[4].Value = Common.GetSum(row, 0, 12, 4);
            dataGridView1.Rows[13].Cells[5].Value = Common.GetSum(row, 0, 12, 5);
            dataGridView1.Rows[13].Cells[6].Value = Common.GetSum(row, 0, 12, 6);
            dataGridView1.Rows[13].Cells[7].Value = Common.GetSum(row, 0, 12, 7);
            dataGridView1.Rows[13].Cells[8].Value = Common.GetSum(row, 0, 12, 8);
            dataGridView1.Rows[13].Cells[9].Value = Common.GetSum(row, 0, 12, 9);
            dataGridView1.Rows[13].Cells[10].Value = Common.GetSum(row, 0, 12, 10);
            dataGridView1.Rows[13].Cells[11].Value = Common.GetSum(row, 0, 12, 11);
            dataGridView1.Rows[13].Cells[12].Value = Common.GetSum(row, 0, 12, 12);

            // South Total

            dataGridView1.Rows[22].Cells[2].Value = Common.GetSum(row, 14, 21, 2);
            dataGridView1.Rows[22].Cells[3].Value = Common.GetSum(row, 14, 21, 3);
            dataGridView1.Rows[22].Cells[4].Value = Common.GetSum(row, 14, 21, 4);
            dataGridView1.Rows[22].Cells[5].Value = Common.GetSum(row, 14, 21, 5);
            dataGridView1.Rows[22].Cells[6].Value = Common.GetSum(row, 14, 21, 6);
            dataGridView1.Rows[22].Cells[7].Value = Common.GetSum(row, 14, 21, 7);
            dataGridView1.Rows[22].Cells[8].Value = Common.GetSum(row, 14, 21, 8);
            dataGridView1.Rows[22].Cells[9].Value = Common.GetSum(row, 14, 21, 9);
            dataGridView1.Rows[22].Cells[10].Value = Common.GetSum(row, 14, 21, 10);
            dataGridView1.Rows[22].Cells[11].Value = Common.GetSum(row, 14, 21, 11);
            dataGridView1.Rows[22].Cells[12].Value = Common.GetSum(row, 14, 21, 12);

            // East Total
            dataGridView1.Rows[31].Cells[2].Value = Common.GetSum(row, 23, 30, 2);
            dataGridView1.Rows[31].Cells[3].Value = Common.GetSum(row, 23, 30, 3);
            dataGridView1.Rows[31].Cells[4].Value = Common.GetSum(row, 23, 30, 4);
            dataGridView1.Rows[31].Cells[5].Value = Common.GetSum(row, 23, 30, 5);
            dataGridView1.Rows[31].Cells[6].Value = Common.GetSum(row, 23, 30, 6);
            dataGridView1.Rows[31].Cells[7].Value = Common.GetSum(row, 23, 30, 7);
            dataGridView1.Rows[31].Cells[8].Value = Common.GetSum(row, 23, 30, 8);
            dataGridView1.Rows[31].Cells[9].Value = Common.GetSum(row, 23, 30, 9);
            dataGridView1.Rows[31].Cells[10].Value = Common.GetSum(row, 23, 30, 10);
            dataGridView1.Rows[31].Cells[11].Value = Common.GetSum(row, 23, 30, 11);
            dataGridView1.Rows[31].Cells[12].Value = Common.GetSum(row, 23, 30, 12);

            //  West Total

            dataGridView1.Rows[43].Cells[2].Value = Common.GetSum(row, 32, 42, 2);
            dataGridView1.Rows[43].Cells[3].Value = Common.GetSum(row, 32, 42, 3);
            dataGridView1.Rows[43].Cells[4].Value = Common.GetSum(row, 32, 42, 4);
            dataGridView1.Rows[43].Cells[5].Value = Common.GetSum(row, 32, 42, 5);
            dataGridView1.Rows[43].Cells[6].Value = Common.GetSum(row, 32, 42, 6);
            dataGridView1.Rows[43].Cells[7].Value = Common.GetSum(row, 32, 42, 7);
            dataGridView1.Rows[43].Cells[8].Value = Common.GetSum(row, 32, 42, 8);
            dataGridView1.Rows[43].Cells[9].Value = Common.GetSum(row, 32, 42, 9);
            dataGridView1.Rows[43].Cells[10].Value = Common.GetSum(row, 32, 42, 10);
            dataGridView1.Rows[43].Cells[11].Value = Common.GetSum(row, 32, 42, 11);
            dataGridView1.Rows[43].Cells[12].Value = Common.GetSum(row, 32, 42, 12);


            // Grand Total

            //dataGridView1.Rows[64].Cells[2].Value = Common.GetSum(row, 50, 54, 2);
            //dataGridView1.Rows[64].Cells[3].Value = Common.GetSum(row, 50, 54, 3);
            //dataGridView1.Rows[64].Cells[4].Value = Common.GetSum(row, 50, 54, 4);
            //dataGridView1.Rows[64].Cells[5].Value = Common.GetSum(row, 50, 54, 5);
            //dataGridView1.Rows[64].Cells[6].Value = Common.GetSum(row, 50, 54, 6);
            //dataGridView1.Rows[64].Cells[7].Value = Common.GetSum(row, 50, 54, 7);
            //dataGridView1.Rows[64].Cells[8].Value = Common.GetSum(row, 50, 54, 8);
            //dataGridView1.Rows[64].Cells[9].Value = Common.GetSum(row, 50, 54, 9);
            //dataGridView1.Rows[64].Cells[10].Value = Common.GetSum(row,50, 54, 10);
            //dataGridView1.Rows[64].Cells[11].Value = Common.GetSum(row,50, 54, 11);
            //dataGridView1.Rows[64].Cells[12].Value = Common.GetSum(row,50, 54, 12);


            dataGridView1.Rows[61].Cells[2].Value = Common.GetSum(row, 49, 60, 2);
            dataGridView1.Rows[61].Cells[3].Value = Common.GetSum(row, 49, 60, 3);
            dataGridView1.Rows[61].Cells[4].Value = Common.GetSum(row, 49, 60, 4);
            dataGridView1.Rows[61].Cells[5].Value = Common.GetSum(row, 49, 60, 5);
            dataGridView1.Rows[61].Cells[6].Value = Common.GetSum(row, 49, 60, 6);
            dataGridView1.Rows[61].Cells[7].Value = Common.GetSum(row, 49, 60, 7);
            dataGridView1.Rows[61].Cells[8].Value = Common.GetSum(row, 49, 60, 8);
            dataGridView1.Rows[61].Cells[9].Value = Common.GetSum(row, 49, 60, 9);
            dataGridView1.Rows[61].Cells[10].Value = Common.GetSum(row, 49, 60, 10);
            dataGridView1.Rows[61].Cells[11].Value = Common.GetSum(row, 49, 60, 11);
            dataGridView1.Rows[61].Cells[12].Value = Common.GetSum(row, 49, 60, 12);


            // All Grand Total
            dataGridView1.Rows[62].Cells[2].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[22].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[61].Cells[2].Value.ToString()) + Common.GetSum(row, 44, 47, 2);
            dataGridView1.Rows[62].Cells[3].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[22].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[61].Cells[3].Value.ToString()) + Common.GetSum(row, 44, 47, 3);
            dataGridView1.Rows[62].Cells[4].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[22].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[61].Cells[4].Value.ToString()) + Common.GetSum(row, 44, 47, 4);
            dataGridView1.Rows[62].Cells[5].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[22].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[61].Cells[5].Value.ToString()) + Common.GetSum(row, 44, 47, 5);
            dataGridView1.Rows[62].Cells[6].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[6].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[22].Cells[6].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[6].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[6].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[61].Cells[6].Value.ToString()) + Common.GetSum(row, 44, 47, 6);
            dataGridView1.Rows[62].Cells[7].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[7].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[22].Cells[7].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[7].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[7].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[61].Cells[7].Value.ToString()) + Common.GetSum(row, 44, 47, 7);
            dataGridView1.Rows[62].Cells[8].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[8].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[22].Cells[8].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[8].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[8].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[61].Cells[8].Value.ToString()) + Common.GetSum(row, 44, 47, 8);
            dataGridView1.Rows[62].Cells[9].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[9].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[22].Cells[9].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[9].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[9].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[61].Cells[9].Value.ToString()) + Common.GetSum(row, 44, 47, 9);
            dataGridView1.Rows[62].Cells[10].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[10].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[22].Cells[10].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[10].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[10].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[61].Cells[10].Value.ToString()) + Common.GetSum(row, 44, 47, 10);
            dataGridView1.Rows[62].Cells[11].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[11].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[22].Cells[11].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[11].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[11].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[61].Cells[11].Value.ToString()) + Common.GetSum(row, 44, 47, 11);
            dataGridView1.Rows[62].Cells[12].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[12].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[22].Cells[12].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[12].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[12].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[61].Cells[12].Value.ToString()) + Common.GetSum(row, 44, 47, 12);


            #endregion

            #region Calculating_HorizontalSum
            for (int i = 0; i < (row.Count - 1); i++)
            {

                if (i >= 0)
                {
                    dataGridView1.Rows[i].Cells[4].Value = Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[3].Value.ToString());
                    dataGridView1.Rows[i].Cells[7].Value = Common.ConvertToDecimal(row[i].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[6].Value.ToString());
                    dataGridView1.Rows[i].Cells[12].Value = Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[8].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[9].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[11].Value.ToString());
                }
            }
            #endregion

        }

        private void Print_ReportOnClick(object sender, EventArgs e)
        {
            rptCategorywiseStaffPositionAsOn objFrm = new rptCategorywiseStaffPositionAsOn(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcalculateTotal();
        }
        public void NonEditableRowAndColumn()
        {
            //Common.SetRowNonEditable(dataGridView1, 13);
            //Common.SetRowNonEditable(dataGridView1, 21);
            //Common.SetRowNonEditable(dataGridView1, 31);
            //Common.SetRowNonEditable(dataGridView1, 45);
            //Common.SetRowNonEditable(dataGridView1, 63);
            //Common.SetRowNonEditable(dataGridView1, 64);

            //Common.SetColumnNonEditable(dataGridView1, 4);
            //Common.SetColumnNonEditable(dataGridView1, 7);
            //Common.SetColumnNonEditable(dataGridView1, 12);
        }
    }
}


