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
    public partial class DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16],[Param17],[Param18],[Param19],[Param20],[Param21] FROM [rpt].[tbl_DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                DataTable autoSpTable = new DataTable();

                if (dt.Rows.Count < 1)
                {
                    SqlCommand cmd1 = new SqlCommand("[dbo].[DepotWiseOperDataTrafficIncomeOSB4_4]", con);
                    cmd1.Parameters.AddWithValue("@month", Month);
                    cmd1.Parameters.AddWithValue("@year", Year);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandTimeout = 350;
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                    sda1.Fill(autoSpTable);

                }
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    Save.BackColor = Color.Green;
                }
                else if (autoSpTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = BindDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome_AutoSp_Table(autoSpTable);
                }
                else
                {
                    dataGridView1.DataSource = BindDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome();
                }


                setRowColNonEditable();
                CalcalculateTotal();

            }
            catch (Exception ex)
            {

            }

        }

        DataTable BindDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome()
        {
            DataTable table = new DataTable();

            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Name Of The Depot", typeof(string));
            table.Columns.Add("Monthly Traffic Income (Rs.)", typeof(string));
            table.Columns.Add("Monthly Traffic Income (Rs.) ", typeof(string));
            table.Columns.Add("Monthly Traffic Income (Rs.)  ", typeof(string));
            table.Columns.Add("Monthly Traffic Income (Rs.)   ", typeof(string));
            table.Columns.Add("Monthly Traffic Income (Rs.)    ", typeof(string));
            table.Columns.Add("Daily traffic income (Rs.)", typeof(string));
            table.Columns.Add("Daily traffic income (Rs.) ", typeof(string));
            table.Columns.Add("Daily traffic income (Rs.)  ", typeof(string));
            table.Columns.Add("Daily traffic income (Rs.)   ", typeof(string));
            table.Columns.Add("Daily traffic income (Rs.)    ", typeof(string));
            table.Columns.Add("Traffic Income per km (Paise)", typeof(string));
            table.Columns.Add("Traffic Income per km (Paise) ", typeof(string));
            table.Columns.Add("Traffic Income per km (Paise)  ", typeof(string));
            table.Columns.Add("Traffic Income per km (Paise)   ", typeof(string));
            table.Columns.Add("Traffic Income per km (Paise)    ", typeof(string));
            table.Columns.Add("Traffic Income per bus per day (Rs.)", typeof(string));
            table.Columns.Add("Traffic Income per bus per day (Rs.) ", typeof(string));
            table.Columns.Add("Traffic Income per bus per day (Rs.)  ", typeof(string));
            table.Columns.Add("Traffic Income per bus per day (Rs.)   ", typeof(string));
            table.Columns.Add("Traffic Income per bus per day (Rs.)    ", typeof(string));


            // Rows
            table.Rows.Add("", "", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total");
            table.Rows.Add("", "", "NAC", "AC", "NAC", "AC", "", "NAC", "AC", "NAC", "AC", "", "NAC", "AC", "NAC", "AC", "", "NAC", "AC", "NAC", "AC", "");
            table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22");
            table.Rows.Add("1", "BBM", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Rohini-I", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Rohini-II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Rohini-III", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Rohini-IV", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "Wazir Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "Subhash Place", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("8", "G.T.K.Rd.", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("9", "Nangloi", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("10", "Kanjhawla", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("11", "Narela", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("12", "Kalka Ji", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("13", "Sri Niwas puri ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("14", "AND", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("15", "Vasant Vihar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("16", "Tehkhand", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("17", "Sukhdev Vihar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("18", "Sarojni Nagar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("19", "Nand Nagri", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("20", "NOIDA", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("21", "EVND", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("22", "Hasan Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("23", "Gazi Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("24", "Rajghat I", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("25", "Hari Nagar I", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("26", "Hari Nagar II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("27", "Kesho Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("28", "Naraina", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("29", "Shadi Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("30", "BAGDOLA", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("31", "DW.SEC.-II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("32", "Maya Puri", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("33", "Dichaon Kalan", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("34", "Peera Garhi", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "Electric Buses", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

            table.Rows.Add("1", "Rohini sec.37", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Rajghat II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Mundhela kalan", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "Total Electric", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total DTC", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "International", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            table.Rows.Add("1", "Kathmandu", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "Grand Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");


            return table;
        }

        DataTable BindDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome_AutoSp_Table(DataTable sp)
        {
            DataTable table = new DataTable();

            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Name Of The Depot", typeof(string));
            table.Columns.Add("Monthly Traffic Income (Rs.)", typeof(string));
            table.Columns.Add("Monthly Traffic Income (Rs.) ", typeof(string));
            table.Columns.Add("Monthly Traffic Income (Rs.)  ", typeof(string));
            table.Columns.Add("Monthly Traffic Income (Rs.)   ", typeof(string));
            table.Columns.Add("Monthly Traffic Income (Rs.)    ", typeof(string));
            table.Columns.Add("Daily traffic income (Rs.)", typeof(string));
            table.Columns.Add("Daily traffic income (Rs.) ", typeof(string));
            table.Columns.Add("Daily traffic income (Rs.)  ", typeof(string));
            table.Columns.Add("Daily traffic income (Rs.)   ", typeof(string));
            table.Columns.Add("Daily traffic income (Rs.)    ", typeof(string));
            table.Columns.Add("Traffic Income per km (Paise)", typeof(string));
            table.Columns.Add("Traffic Income per km (Paise) ", typeof(string));
            table.Columns.Add("Traffic Income per km (Paise)  ", typeof(string));
            table.Columns.Add("Traffic Income per km (Paise)   ", typeof(string));
            table.Columns.Add("Traffic Income per km (Paise)    ", typeof(string));
            table.Columns.Add("Traffic Income per bus per day (Rs.)", typeof(string));
            table.Columns.Add("Traffic Income per bus per day (Rs.) ", typeof(string));
            table.Columns.Add("Traffic Income per bus per day (Rs.)  ", typeof(string));
            table.Columns.Add("Traffic Income per bus per day (Rs.)   ", typeof(string));
            table.Columns.Add("Traffic Income per bus per day (Rs.)    ", typeof(string));


            // Rows
            table.Rows.Add("", "", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total");
            table.Rows.Add("", "", "NAC", "AC", "NAC", "AC", "", "NAC", "AC", "NAC", "AC", "", "NAC", "AC", "NAC", "AC", "", "NAC", "AC", "NAC", "AC", "");
            table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22");

            for (int i = 0; i <= 33; i++)
            {
                int traffIncCityNac = Convert.ToInt32(sp.Rows[i]["TrafficIncCityNAC"]) + Convert.ToInt32(sp.Rows[i]["TrafficIncCityNAC"])

                table.Rows.Add(i + 1, sp.Rows[i]["CircleName"],
                     sp.Rows[i]["TrafficIncCityNAC"], sp.Rows[i]["TrafficIncCityAC"], sp.Rows[i]["TrafficIncNcrNac"], sp.Rows[i]["TrafficIncNcrAC"], sp.Rows[i][" "], sp.Rows[i][" "], sp.Rows[i][" "], sp.Rows[i][" "], sp.Rows[i][" "], sp.Rows[i][" "], sp.Rows[i][" "], sp.Rows[i][" "], sp.Rows[i][" "], sp.Rows[i][" "], sp.Rows[i][" "], sp.Rows[i][" "], sp.Rows[i][" "], sp.Rows[i][" "], sp.Rows[i][" "], sp.Rows[i][" "]);
            }

            table.Rows.Add("1", "BBM", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Rohini-I", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Rohini-II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Rohini-III", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Rohini-IV", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "Wazir Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "Subhash Place", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("8", "G.T.K.Rd.", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("9", "Nangloi", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("10", "Kanjhawla", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("11", "Narela", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("12", "Kalka Ji", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("13", "Sri Niwas puri ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("14", "AND", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("15", "Vasant Vihar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("16", "Tehkhand", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("17", "Sukhdev Vihar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("18", "Sarojni Nagar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("19", "Nand Nagri", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("20", "NOIDA", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("21", "EVND", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("22", "Hasan Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("23", "Gazi Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("24", "Rajghat I", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("25", "Hari Nagar I", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("26", "Hari Nagar II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("27", "Kesho Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("28", "Naraina", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("29", "Shadi Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("30", "BAGDOLA", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("31", "DW.SEC.-II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("32", "Maya Puri", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("33", "Dichaon Kalan", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("34", "Peera Garhi", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "Electric Buses", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

            table.Rows.Add("1", "Rohini sec.37", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Rajghat II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Mundhela kalan", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "Total Electric", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total DTC", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "International", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            table.Rows.Add("1", "Kathmandu", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "Grand Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");


            return table;
        }

        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome", OsbId);
            dataGridView1.DataSource = BindDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome();
            setRowColNonEditable();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null || row.Cells[11].Value != null || row.Cells[12].Value != null || row.Cells[13].Value != null || row.Cells[14].Value != null || row.Cells[15].Value != null || row.Cells[16].Value != null || row.Cells[17].Value != null || row.Cells[18].Value != null || row.Cells[19].Value != null || row.Cells[20].Value != null || row.Cells[21].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome] ([OsbId],[S_No],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16],[Param17],[Param18],[Param19],[Param20],[Param21]) VALUES (@OsbId,@S_No,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11,@Param12,@Param13,@Param14,@Param15,@Param16,@Param17,@Param18,@Param19,@Param20,@Param21)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@S_No", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param6", row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param7", row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param8", row.Cells[8].Value == null ? "" : row.Cells[8].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param9", row.Cells[9].Value == null ? "" : row.Cells[9].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param10", row.Cells[10].Value == null ? "" : row.Cells[10].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param11", row.Cells[11].Value == null ? "" : row.Cells[11].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param12", row.Cells[12].Value == null ? "" : row.Cells[12].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param13", row.Cells[13].Value == null ? "" : row.Cells[13].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param14", row.Cells[14].Value == null ? "" : row.Cells[14].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param15", row.Cells[15].Value == null ? "" : row.Cells[15].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param16", row.Cells[16].Value == null ? "" : row.Cells[16].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param17", row.Cells[17].Value == null ? "" : row.Cells[17].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param18", row.Cells[18].Value == null ? "" : row.Cells[18].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param19", row.Cells[19].Value == null ? "" : row.Cells[19].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param20", row.Cells[20].Value == null ? "" : row.Cells[20].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param21", row.Cells[21].Value == null ? "" : row.Cells[21].Value.ToString().Trim());
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

        private void DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
            // dataGridView1.DataSource = BindDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome();
        }

        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome objFrm = new rptDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome(OsbId, Year, Month, finYear, MonthName);
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


            dataGridView1.Rows[37].Cells[3].Value = Common.GetSum(row, 3, 36, 3);
            dataGridView1.Rows[37].Cells[4].Value = Common.GetSum(row, 3, 36, 4);
            dataGridView1.Rows[37].Cells[5].Value = Common.GetSum(row, 3, 36, 5);
            dataGridView1.Rows[37].Cells[6].Value = Common.GetSum(row, 3, 36, 6);
            dataGridView1.Rows[37].Cells[7].Value = Common.GetSum(row, 3, 36, 7);
            dataGridView1.Rows[37].Cells[8].Value = Common.GetSum(row, 3, 36, 8);
            dataGridView1.Rows[37].Cells[9].Value = Common.GetSum(row, 3, 36, 9);
            dataGridView1.Rows[37].Cells[10].Value = Common.GetSum(row, 3, 36, 10);
            dataGridView1.Rows[37].Cells[11].Value = Common.GetSum(row, 3, 36, 11);


            #endregion

            #region Calculating_HorizontalSum
            for (int i = 0; i < (row.Count - 1); i++)
            {

                if (i > 2)
                {
                    if (i != 38 && i != 43 && i != 45)
                    {
                        dataGridView1.Rows[i].Cells[6].Value = Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[5].Value.ToString());
                        dataGridView1.Rows[i].Cells[11].Value = Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[8].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[9].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[10].Value.ToString());

                    }
                }
            }
            #endregion

            for (int i = 2; i <= 11; i++)
            {
                // All depots Total
                dataGridView1.Rows[37].Cells[i].Value = Common.GetSum(row, 3, 36, i);
                //For Total Electric
                dataGridView1.Rows[42].Cells[i].Value = Common.GetSum(row, 39, 41, i);
                //For Total DTC
                dataGridView1.Rows[43].Cells[i].Value = Common.ConvertToDecimal(dataGridView1.Rows[37].Cells[i].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[42].Cells[i].Value.ToString());
                //For grand total
                dataGridView1.Rows[46].Cells[i].Value = Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[i].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[45].Cells[i].Value.ToString());

            }

        }

        private void setRowColNonEditable()
        {
            Common.SetRowNonEditable(dataGridView1, 37);
            Common.SetRowNonEditable(dataGridView1, 38);
            Common.SetRowNonEditable(dataGridView1, 42);
            Common.SetRowNonEditable(dataGridView1, 43);
            Common.SetRowNonEditable(dataGridView1, 44);
            Common.SetRowNonEditable(dataGridView1, 46);

            Common.SetColumnNonEditable(dataGridView1, 11, 45);
            Common.SetColumnNonEditable(dataGridView1, 6, 45);

        }
    }
}
