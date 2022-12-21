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
    
    public partial class DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021AnalysisOfKilometers : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021AnalysisOfKilometers(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16],[Param17],[Param18],[Param19],[Param20],[Param21],[Param22],[Param23],[Param24],[Param25],[Param26] FROM [rpt].[tbl_DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021AnalysisOfKilometers] where OsbId=@OsbId", con);
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
                    dataGridView1.DataSource = BindDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021AnalysisOfKilometers();

                Common.SetRowNonEditable(dataGridView1,34);
                Common.SetRowNonEditable(dataGridView1,35);
                Common.SetRowNonEditable(dataGridView1, 38);
                Common.SetRowNonEditable(dataGridView1, 39);
                Common.SetRowNonEditable(dataGridView1, 40);
                Common.SetRowNonEditable(dataGridView1, 43);

                Common.SetColumnNonEditable(dataGridView1, 6);
                Common.SetColumnNonEditable(dataGridView1, 11);
                Common.SetColumnNonEditable(dataGridView1, 13);
                Common.SetColumnNonEditable(dataGridView1, 14);
                Common.SetColumnNonEditable(dataGridView1, 15);
                Common.SetColumnNonEditable(dataGridView1, 16);
                Common.SetColumnNonEditable(dataGridView1, 17);
                Common.SetColumnNonEditable(dataGridView1, 22);
                CalcalculateTotal();
            }
            catch (Exception ex)
            {

            }

        }

        DataTable BindDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021AnalysisOfKilometers()
        {
            DataTable table = new DataTable();

            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Name of the Depot", typeof(string));
            table.Columns.Add("Total Kilometers (Number)", typeof(string));
            table.Columns.Add("Total Kilometers (Number) ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)  ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)   ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)    ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)     ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)      ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)       ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)        ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)         ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)          ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)           ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)            ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)             ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)              ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)               ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)                ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)                 ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)                  ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)                   ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)                    ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)                     ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)                      ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)                       ", typeof(string));
            table.Columns.Add("Total Kilometers (Number)                        ", typeof(string));
          


            // Rows
          //  table.Rows.Add("", "", "Scheduled", "Scheduled", "Scheduled", "Scheduled", "Scheduled", "Operated", "Operated", "Operated", "Operated", "Operated", "Kilometer Efficiency (%)", "Kilometer Efficiency (%) ", "Kilometer Efficiency (%)", "Kilometer Efficiency (%)", "Kilometer Efficiency (%)", "Daily Opt. Kilometers", "Daily Opt. Kilometers", "Daily Opt. Kilometers", "Daily Opt. Kilometers", "Daily Opt. Kilometers", "Kilometers per bus per day (No.)", "Kilometers per bus per day (No.)", "Kilometers per bus per day (No.)", "Kilometers per bus per day (No.)", "Kilometers per bus per day (No.)");
          //  table.Rows.Add("", "", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total");
        //    table.Rows.Add("", "", "NAC", "AC", "NAC", "AC", "", "NAC", "AC", "NAC", "AC", "", "NAC", "AC", "NAC", "AC", "", "NAC", "AC", "NAC", "AC", "", "NAC", "AC", "NAC", "AC", "");
         //   table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22","23","24","25","26","27");
            table.Rows.Add("1", "BBM", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("2", "Rohini-I", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("3", "Rohini-II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("4", "Rohini-III", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("5", "Rohini-IV", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("6", "Wazir Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("7", "Subhash Place ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("8", "G.T.K.Rd", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("9", "Nangloi", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("10", "Kanjhawla", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("11", "Narela", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("12", "Kalka Ji", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("13", "Sri Niwas puri", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("14", "AND", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("15", "Vasant Vihar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("16", "Tehkhand", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("17", "Sukhdev Vihar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("18", "Sarojni Nagar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("19", "Nand Nagri", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("20", "NOIDA", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("21", "EVND", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("22", "Hasan Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("23", "Gazi Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("24", "Rajghat I", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("25", "Rajghat II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("26", "Hari Nagar I", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("27", "Hari Nagar II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("28", "Kesho Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("29", "Naraina", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("30", "Shadi Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("31", "BAGDOLA", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("32", "DW. SEC.-II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("33", "Maya Puri", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("34", "Dichaon Kalan", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("35", "Peera Garhi", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("", "Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("", "Electric Buses", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "","","","","","");
            table.Rows.Add("1", "Rohini sec.37", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Mundhela kalan", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total Electric", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total DTC", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "International", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            table.Rows.Add("1", "Kathmandu", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Grand Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            return table;
        }


        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021AnalysisOfKilometers", OsbId);
            dataGridView1.DataSource = BindDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021AnalysisOfKilometers();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021AnalysisOfKilometers", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null || row.Cells[11].Value != null || row.Cells[12].Value != null || row.Cells[13].Value != null || row.Cells[14].Value != null || row.Cells[15].Value != null || row.Cells[16].Value != null || row.Cells[17].Value != null || row.Cells[18].Value != null || row.Cells[19].Value != null || row.Cells[20].Value != null || row.Cells[21].Value != null || row.Cells[22].Value != null || row.Cells[23].Value != null || row.Cells[24].Value != null || row.Cells[25].Value != null || row.Cells[26].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021AnalysisOfKilometers] ([OsbId],[S_No],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16],[Param17],[Param18],[Param19],[Param20],[Param21],[Param22],[Param23],[Param24],[Param25],[Param26]) VALUES (@OsbId,@S_No,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11,@Param12,@Param13,@Param14,@Param15,@Param16,@Param17,@Param18,@Param19,@Param20,@Param21,@Param22,@Param23,@Param24,@Param25,@Param26)", con);
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
                        cmd.Parameters.AddWithValue("@Param22", row.Cells[22].Value == null ? "" : row.Cells[22].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param23", row.Cells[23].Value == null ? "" : row.Cells[23].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param24", row.Cells[24].Value == null ? "" : row.Cells[24].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param25", row.Cells[25].Value == null ? "" : row.Cells[25].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param26", row.Cells[26].Value == null ? "" : row.Cells[26].Value.ToString().Trim());
                       
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

        private void DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021AnalysisOfKilometers_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
          //  dataGridView1.DataSource = BindDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021AnalysisOfKilometers();
        }

        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyAnalysisOfKilometers objFrm = new rptDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyAnalysisOfKilometers(OsbId, Year, Month, finYear, MonthName);
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


            dataGridView1.Rows[34].Cells[2].Value = Common.GetSum(row, 0,33,2);
            dataGridView1.Rows[34].Cells[3].Value = Common.GetSum(row, 0,33,3);
            dataGridView1.Rows[34].Cells[4].Value = Common.GetSum(row, 0,33,4);
            dataGridView1.Rows[34].Cells[5].Value = Common.GetSum(row, 0,33,5);
            dataGridView1.Rows[34].Cells[6].Value = Common.GetSum(row, 0,33,6);
            dataGridView1.Rows[34].Cells[7].Value = Common.GetSum(row, 0,33,7);
            dataGridView1.Rows[34].Cells[8].Value = Common.GetSum(row, 0,33,8);
            dataGridView1.Rows[34].Cells[9].Value = Common.GetSum(row, 0,33,9);
            dataGridView1.Rows[34].Cells[10].Value = Common.GetSum(row,0,33, 10);
            dataGridView1.Rows[34].Cells[11].Value = Common.GetSum(row,0,33, 11);


            dataGridView1.Rows[38].Cells[2].Value = Common.GetSum(row, 36,37,2);
            dataGridView1.Rows[38].Cells[3].Value = Common.GetSum(row, 36,37,3);
            dataGridView1.Rows[38].Cells[4].Value = Common.GetSum(row, 36,37,4);
            dataGridView1.Rows[38].Cells[5].Value = Common.GetSum(row, 36,37,5);
            dataGridView1.Rows[38].Cells[6].Value = Common.GetSum(row, 36,37,6);
            dataGridView1.Rows[38].Cells[7].Value = Common.GetSum(row, 36,37,7);
            dataGridView1.Rows[38].Cells[8].Value = Common.GetSum(row, 36,37,8);
            dataGridView1.Rows[38].Cells[9].Value = Common.GetSum(row, 36,37,9);
            dataGridView1.Rows[38].Cells[10].Value = Common.GetSum(row,36,37, 10);
            dataGridView1.Rows[38].Cells[11].Value = Common.GetSum(row,36,37, 11);



            dataGridView1.Rows[39].Cells[2].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[2].Value.ToString());
            dataGridView1.Rows[39].Cells[3].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[3].Value.ToString());
            dataGridView1.Rows[39].Cells[4].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[4].Value.ToString());
            dataGridView1.Rows[39].Cells[5].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[5].Value.ToString());
            dataGridView1.Rows[39].Cells[6].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[6].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[6].Value.ToString());
            dataGridView1.Rows[39].Cells[7].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[7].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[7].Value.ToString());
            dataGridView1.Rows[39].Cells[8].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[8].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[8].Value.ToString());
            dataGridView1.Rows[39].Cells[9].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[9].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[9].Value.ToString());
            dataGridView1.Rows[39].Cells[10].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[10].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[10].Value.ToString());
            dataGridView1.Rows[39].Cells[11].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[11].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[11].Value.ToString());


            dataGridView1.Rows[42].Cells[2].Value = Common.ConvertToDecimal(dataGridView1.Rows[41].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[2].Value.ToString());
            dataGridView1.Rows[42].Cells[3].Value = Common.ConvertToDecimal(dataGridView1.Rows[41].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[3].Value.ToString());
            dataGridView1.Rows[42].Cells[4].Value = Common.ConvertToDecimal(dataGridView1.Rows[41].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[4].Value.ToString());
            dataGridView1.Rows[42].Cells[5].Value = Common.ConvertToDecimal(dataGridView1.Rows[41].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[5].Value.ToString());
            dataGridView1.Rows[42].Cells[6].Value = Common.ConvertToDecimal(dataGridView1.Rows[41].Cells[6].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[6].Value.ToString());
            dataGridView1.Rows[42].Cells[7].Value = Common.ConvertToDecimal(dataGridView1.Rows[41].Cells[7].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[7].Value.ToString());
            dataGridView1.Rows[42].Cells[8].Value = Common.ConvertToDecimal(dataGridView1.Rows[41].Cells[8].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[8].Value.ToString());
            dataGridView1.Rows[42].Cells[9].Value = Common.ConvertToDecimal(dataGridView1.Rows[41].Cells[9].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[9].Value.ToString());
            dataGridView1.Rows[42].Cells[10].Value = Common.ConvertToDecimal(dataGridView1.Rows[41].Cells[10].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[10].Value.ToString());
            dataGridView1.Rows[42].Cells[11].Value = Common.ConvertToDecimal(dataGridView1.Rows[41].Cells[11].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[11].Value.ToString());

            #endregion

            #region Calculating_HorizontalSum
            for (int i = 0; i < (row.Count - 1); i++)
            {

                if (i > 0)
                {
                    if (i !=35 && i !=40)
                    {

                        dataGridView1.Rows[i].Cells[6].Value = Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[5].Value.ToString());
                        dataGridView1.Rows[i].Cells[11].Value = Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[8].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[9].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[10].Value.ToString());
                        dataGridView1.Rows[i].Cells[13].Value = Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) > 0 ? Math.Round(Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) * 100, 2) : 0;
                        dataGridView1.Rows[i].Cells[14].Value = Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) > 0 ? Math.Round(Common.ConvertToDecimal(row[i].Cells[8].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) * 100, 2) : 0;
                        dataGridView1.Rows[i].Cells[15].Value = Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) > 0 ? Math.Round(Common.ConvertToDecimal(row[i].Cells[9].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) * 100, 2) : 0;
                        dataGridView1.Rows[i].Cells[16].Value = Common.ConvertToDecimal(row[i].Cells[5].Value.ToString()) > 0 ? Math.Round(Common.ConvertToDecimal(row[i].Cells[10].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[5].Value.ToString()) * 100, 2) : 0;
                        dataGridView1.Rows[i].Cells[17].Value = Common.ConvertToDecimal(row[i].Cells[6].Value.ToString()) > 0 ? Math.Round(Common.ConvertToDecimal(row[i].Cells[11].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[6].Value.ToString()) * 100, 2) : 0;
                        dataGridView1.Rows[i].Cells[22].Value = Common.ConvertToDecimal(row[i].Cells[18].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[19].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[20].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[21].Value.ToString());
                    }
                }
            }
            #endregion

        }
    }
}
