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
    public partial class DepotWiseOperationalDataInRespectOfNonAcAndAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TripsScheduledAndOperated : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public DepotWiseOperationalDataInRespectOfNonAcAndAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TripsScheduledAndOperated(int OsbId, int Year, int Month, string finYear, string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;
        }
        DataTable BindDepotWiseOperationalDataInRespectOfNonAcAndAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TripsScheduledAndOperated()
        {
          

            DataTable table = new DataTable();

            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Name of Depot", typeof(string));
            table.Columns.Add("Trips Scheduled daily", typeof(string));
            table.Columns.Add("Trips Scheduled daily ", typeof(string));
            table.Columns.Add("Trips Scheduled daily  ", typeof(string));
            table.Columns.Add("Trips Scheduled  daily", typeof(string));
            table.Columns.Add("Trips  Scheduled daily", typeof(string));

            table.Columns.Add("Trips Operated daily", typeof(string));
            table.Columns.Add("Trips Operated daily ", typeof(string));
            table.Columns.Add("Trips Operated daily  ", typeof(string));
            table.Columns.Add("Trips  Operated daily ", typeof(string));
            table.Columns.Add("Trips Operated  daily ", typeof(string));

            table.Columns.Add("Operational ratio (%)", typeof(string));
            table.Columns.Add("Operational ratio (%) ", typeof(string));
            table.Columns.Add("Operational ratio (%)  ", typeof(string));
            table.Columns.Add("Operational  ratio (%) ", typeof(string));
            table.Columns.Add("Operational   ratio (%)", typeof(string));

            table.Columns.Add("Total no.of Break downs", typeof(string));
            table.Columns.Add("Total no.of Break downs ", typeof(string));
            table.Columns.Add("Total no.of Break downs  ", typeof(string));
            table.Columns.Add("Total no.of Break  downs ", typeof(string));
            table.Columns.Add("Total no.of  Break downs ", typeof(string));

            table.Columns.Add("Breakdowns Rate per 10,000 Kmsh ", typeof(string));
            table.Columns.Add("Breakdowns Rate per 10,000 Kmsh", typeof(string));
            table.Columns.Add("Breakdowns Rate per 10,000 Kmsh  ", typeof(string));
            table.Columns.Add("Breakdowns Rate per 10,000  Kmsh  ", typeof(string));
            table.Columns.Add("Breakdowns Rate per  10,000 Kmsh  ", typeof(string));


            table.Rows.Add("S.No ", "Name of the Depot", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total");
            table.Rows.Add(" ", " ", "NAC", "AC", "NAC", "AC", "Total", "NAC", "AC", "NAC", "AC", "Total", "NAC", "AC", "NAC", "AC", "Total", "NAC", "AC", "NAC", "AC", "Total", "NAC", "AC", "NAC", "AC", "Total");
            table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27");

            table.Rows.Add("1", "BBM", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Rohini-I", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Rohini-II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Rohini-III", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Rohini-IV", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "Wazir Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "Subhash Place", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("8", "G.T.K. Rd.", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("9", "Nangloi", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("10", "Kanjhawla", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("11", "NARELA", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("12", "Kalka Ji", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("13", "Sri Niwas puri", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("14", "AND", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("15", "Vasant Vihar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("16", "Tehkhand", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("17", "Sukhdev Vihar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("18", "Sarojni Nagar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("19", "Nand Nagri", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("20", "NOIDA", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("21", "EVND  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("22", "HasanPur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("23", "Gazi Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("24", "Raj Ghat-I", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("25", "Raj Ghat-II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("26", "Hari Nagar-I ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("27", "Hari Nagar-II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("28", "Kesho Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("29", "Naraina", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("30", "Shadi Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("31", "BAGDOLA", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("32", "DW.SEC- 2", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("33", "Maya Puri", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("34", "Dichaon Kalan", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("35", "Peera Garhi", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("Total", "Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            table.Rows.Add("Electric Buses", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

            table.Rows.Add("1", "Rohini sec. 37", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Mundhela kalan", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total Electric", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total DTC", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            table.Rows.Add("International", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            table.Rows.Add("1", "Kathmandu", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("Grand Total", "Grand Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");


            return table;
        }

        void BindIndexPage(int OsbId)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Depot],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16],[Param17],[Param18],[Param19],[Param20],[Param21],[Param22],[Param23],[Param24],[Param25] FROM [rpt].[tbl_DepotWiseOperationalDataInRespectOfNonAcAndAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TripsScheduledAndOperated] where OsbId=@OsbId", con);
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
                    dataGridView1.DataSource = BindDepotWiseOperationalDataInRespectOfNonAcAndAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TripsScheduledAndOperated();
                }

                Common.SetRowNonEditable(dataGridView1, 37);
                Common.SetRowNonEditable(dataGridView1, 38);
                Common.SetRowNonEditable(dataGridView1, 39);
                Common.SetRowNonEditable(dataGridView1, 42);
                Common.SetRowNonEditable(dataGridView1, 43);
                Common.SetRowNonEditable(dataGridView1, 44);
                Common.SetRowNonEditable(dataGridView1, 45);
            
                Common.SetRowNonEditable(dataGridView1, 48);


                Common.SetColumnNonEditable(dataGridView1, 6);
                Common.SetColumnNonEditable(dataGridView1, 11);
                Common.SetColumnNonEditable(dataGridView1, 12);
                Common.SetColumnNonEditable(dataGridView1, 13);
                Common.SetColumnNonEditable(dataGridView1, 14);
                Common.SetColumnNonEditable(dataGridView1, 15);
                Common.SetColumnNonEditable(dataGridView1, 16);
                Common.SetColumnNonEditable(dataGridView1, 21);

              
                CalcalculateTotal();
                //dataGridView1.Rows[10].Cells[6].ReadOnly = true;
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
            DeleteExisitingTableRecord("tbl_DepotWiseOperationalDataInRespectOfNonAcAndAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TripsScheduledAndOperated", OsbId);
            dataGridView1.DataSource = BindDepotWiseOperationalDataInRespectOfNonAcAndAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TripsScheduledAndOperated();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DepotWiseOperationalDataInRespectOfNonAcAndAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TripsScheduledAndOperated", OsbId);
            CalcalculateTotal();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null || row.Cells[11].Value != null || row.Cells[12].Value != null || row.Cells[13].Value != null || row.Cells[14].Value != null ||
                        row.Cells[15].Value != null || row.Cells[16].Value != null || row.Cells[17].Value != null || row.Cells[18].Value != null || row.Cells[19].Value != null || row.Cells[20].Value != null || row.Cells[21].Value != null || row.Cells[22].Value != null || row.Cells[23].Value != null || row.Cells[24].Value != null || row.Cells[25].Value != null || row.Cells[26].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_DepotWiseOperationalDataInRespectOfNonAcAndAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TripsScheduledAndOperated]" +
                            "([OsbId],[S_No],[Depot],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16],[Param17],[Param18],[Param19],[Param20],[Param21],[Param22],[Param23],[Param24],[Param25]) VALUES (@OsbId,@S_No,@Depot,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11,@Param12,@Param13,@Param14,@Param15,@Param16,@Param17,@Param18,@Param19,@Param20,@Param21,@Param22,@Param23,@Param24,@Param25)", con);
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
                        cmd.Parameters.AddWithValue("@Param12", row.Cells[13].Value == null ? "" : row.Cells[13].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param13", row.Cells[14].Value == null ? "" : row.Cells[14].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param14", row.Cells[15].Value == null ? "" : row.Cells[15].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param15", row.Cells[16].Value == null ? "" : row.Cells[16].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param16", row.Cells[17].Value == null ? "" : row.Cells[17].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param17", row.Cells[18].Value == null ? "" : row.Cells[18].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param18", row.Cells[19].Value == null ? "" : row.Cells[19].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param19", row.Cells[20].Value == null ? "" : row.Cells[20].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param20", row.Cells[21].Value == null ? "" : row.Cells[21].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param21", row.Cells[22].Value == null ? "" : row.Cells[22].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param22", row.Cells[23].Value == null ? "" : row.Cells[23].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param23", row.Cells[24].Value == null ? "" : row.Cells[24].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param24", row.Cells[25].Value == null ? "" : row.Cells[25].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param25", row.Cells[26].Value == null ? "" : row.Cells[26].Value.ToString());
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

        private void DepotWiseOperationalDataInRespectOfNonAcAndAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TripsScheduledAndOperated_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
            //  dataGridView1.DataSource = BindDepotWiseOperationalDataInRespectOfNonAcAndAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TripsScheduledAndOperated();
        }

        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptDWODTripsScheduledOperated objFrm = new rptDWODTripsScheduledOperated(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }


        void CalcalculateTotal()
        {
            var row = dataGridView1.Rows;

            #region Calculating_VerticalSum


            dataGridView1.Rows[37].Cells[2].Value = Common.GetSum(row, 3, 36, 2);
            dataGridView1.Rows[37].Cells[3].Value = Common.GetSum(row, 3, 36, 3);
            dataGridView1.Rows[37].Cells[4].Value = Common.GetSum(row, 3, 36, 4);
            dataGridView1.Rows[37].Cells[5].Value = Common.GetSum(row, 3, 36, 5);
            dataGridView1.Rows[37].Cells[6].Value = Common.GetSum(row, 3, 36, 6);
            dataGridView1.Rows[37].Cells[7].Value = Common.GetSum(row, 3, 36, 7);
            dataGridView1.Rows[37].Cells[8].Value = Common.GetSum(row, 3, 36, 8);
            dataGridView1.Rows[37].Cells[9].Value = Common.GetSum(row, 3, 36, 9);
            dataGridView1.Rows[37].Cells[10].Value = Common.GetSum(row, 3, 36, 10);
            dataGridView1.Rows[37].Cells[11].Value = Common.GetSum(row, 3, 36, 11);
            //Add
            dataGridView1.Rows[37].Cells[17].Value = Common.GetSum(row, 3, 36, 17);
            dataGridView1.Rows[37].Cells[18].Value = Common.GetSum(row, 3, 36, 18);
            dataGridView1.Rows[37].Cells[19].Value = Common.GetSum(row, 3, 36, 19);
            dataGridView1.Rows[37].Cells[20].Value = Common.GetSum(row, 3, 36, 20);
            dataGridView1.Rows[37].Cells[21].Value = Common.GetSum(row, 3, 36, 21);
         


            dataGridView1.Rows[42].Cells[2].Value = Common.GetSum(row, 40, 41, 2);
            dataGridView1.Rows[42].Cells[3].Value = Common.GetSum(row, 40, 41, 3);
            dataGridView1.Rows[42].Cells[4].Value = Common.GetSum(row, 40, 41, 4);
            dataGridView1.Rows[42].Cells[5].Value = Common.GetSum(row, 40, 41, 5);
            dataGridView1.Rows[42].Cells[6].Value = Common.GetSum(row, 40, 41, 6);
            dataGridView1.Rows[42].Cells[7].Value = Common.GetSum(row, 40, 41, 7);
            dataGridView1.Rows[42].Cells[8].Value = Common.GetSum(row, 40, 41, 8);
            dataGridView1.Rows[42].Cells[9].Value = Common.GetSum(row, 40, 41, 9);
            dataGridView1.Rows[42].Cells[10].Value = Common.GetSum(row, 40, 41, 10);
            dataGridView1.Rows[42].Cells[11].Value = Common.GetSum(row, 40, 41, 11);
            //Add
            dataGridView1.Rows[42].Cells[17].Value = Common.GetSum(row, 40, 41, 17);
            dataGridView1.Rows[42].Cells[18].Value = Common.GetSum(row, 40, 41, 18);
            dataGridView1.Rows[42].Cells[19].Value = Common.GetSum(row, 40, 41, 19);
            dataGridView1.Rows[42].Cells[20].Value = Common.GetSum(row, 40, 41, 20);
            dataGridView1.Rows[42].Cells[21].Value = Common.GetSum(row, 40, 41, 21);




            dataGridView1.Rows[43].Cells[2].Value = Common.ConvertToDecimal(dataGridView1.Rows[37].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[42].Cells[2].Value.ToString());
            dataGridView1.Rows[43].Cells[3].Value = Common.ConvertToDecimal(dataGridView1.Rows[37].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[42].Cells[3].Value.ToString());
            dataGridView1.Rows[43].Cells[4].Value = Common.ConvertToDecimal(dataGridView1.Rows[37].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[42].Cells[4].Value.ToString());
            dataGridView1.Rows[43].Cells[5].Value = Common.ConvertToDecimal(dataGridView1.Rows[37].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[42].Cells[5].Value.ToString());
            dataGridView1.Rows[43].Cells[6].Value = Common.ConvertToDecimal(dataGridView1.Rows[37].Cells[6].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[42].Cells[6].Value.ToString());
            dataGridView1.Rows[43].Cells[7].Value = Common.ConvertToDecimal(dataGridView1.Rows[37].Cells[7].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[42].Cells[7].Value.ToString());
            dataGridView1.Rows[43].Cells[8].Value = Common.ConvertToDecimal(dataGridView1.Rows[37].Cells[8].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[42].Cells[8].Value.ToString());
            dataGridView1.Rows[43].Cells[9].Value = Common.ConvertToDecimal(dataGridView1.Rows[37].Cells[9].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[42].Cells[9].Value.ToString());
            dataGridView1.Rows[43].Cells[10].Value = Common.ConvertToDecimal(dataGridView1.Rows[37].Cells[10].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[42].Cells[10].Value.ToString());
            dataGridView1.Rows[43].Cells[11].Value = Common.ConvertToDecimal(dataGridView1.Rows[37].Cells[11].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[42].Cells[11].Value.ToString());
            dataGridView1.Rows[43].Cells[17].Value = Common.ConvertToDecimal(dataGridView1.Rows[37].Cells[17].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[42].Cells[17].Value.ToString());
            dataGridView1.Rows[43].Cells[18].Value = Common.ConvertToDecimal(dataGridView1.Rows[37].Cells[18].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[42].Cells[18].Value.ToString());
            dataGridView1.Rows[43].Cells[19].Value = Common.ConvertToDecimal(dataGridView1.Rows[37].Cells[19].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[42].Cells[19].Value.ToString());
            dataGridView1.Rows[43].Cells[20].Value = Common.ConvertToDecimal(dataGridView1.Rows[37].Cells[20].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[42].Cells[20].Value.ToString());
            dataGridView1.Rows[43].Cells[21].Value = Common.ConvertToDecimal(dataGridView1.Rows[37].Cells[21].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[42].Cells[21].Value.ToString());
          
            dataGridView1.Rows[47].Cells[2].Value = Common.ConvertToDecimal(dataGridView1.Rows[46].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[2].Value.ToString());
            dataGridView1.Rows[47].Cells[3].Value = Common.ConvertToDecimal(dataGridView1.Rows[46].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[3].Value.ToString());
            dataGridView1.Rows[47].Cells[4].Value = Common.ConvertToDecimal(dataGridView1.Rows[46].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[4].Value.ToString());
            dataGridView1.Rows[47].Cells[5].Value = Common.ConvertToDecimal(dataGridView1.Rows[46].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[5].Value.ToString());
            dataGridView1.Rows[47].Cells[6].Value = Common.ConvertToDecimal(dataGridView1.Rows[46].Cells[6].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[6].Value.ToString());
            dataGridView1.Rows[47].Cells[7].Value = Common.ConvertToDecimal(dataGridView1.Rows[46].Cells[7].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[7].Value.ToString());
            dataGridView1.Rows[47].Cells[8].Value = Common.ConvertToDecimal(dataGridView1.Rows[46].Cells[8].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[8].Value.ToString());
            dataGridView1.Rows[47].Cells[9].Value = Common.ConvertToDecimal(dataGridView1.Rows[46].Cells[9].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[9].Value.ToString());
            dataGridView1.Rows[47].Cells[10].Value = Common.ConvertToDecimal(dataGridView1.Rows[46].Cells[10].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[10].Value.ToString());
            dataGridView1.Rows[47].Cells[11].Value = Common.ConvertToDecimal(dataGridView1.Rows[46].Cells[11].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[11].Value.ToString());
            dataGridView1.Rows[47].Cells[17].Value = Common.ConvertToDecimal(dataGridView1.Rows[46].Cells[17].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[17].Value.ToString());
            dataGridView1.Rows[47].Cells[18].Value = Common.ConvertToDecimal(dataGridView1.Rows[46].Cells[18].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[18].Value.ToString());
            dataGridView1.Rows[47].Cells[19].Value = Common.ConvertToDecimal(dataGridView1.Rows[46].Cells[19].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[19].Value.ToString());
            dataGridView1.Rows[47].Cells[20].Value = Common.ConvertToDecimal(dataGridView1.Rows[46].Cells[20].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[20].Value.ToString());
            dataGridView1.Rows[47].Cells[21].Value = Common.ConvertToDecimal(dataGridView1.Rows[46].Cells[21].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[43].Cells[21].Value.ToString());
         
            #endregion

            #region Calculating_HorizontalSum
            for (int i = 0; i < (row.Count - 1); i++)
            {

                if (i > 2)
                {
                    if (i != 38 && i != 39 && i != 44 && i != 45) {
                        dataGridView1.Rows[i].Cells[6].Value = Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[5].Value.ToString());
                        dataGridView1.Rows[i].Cells[11].Value = Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[8].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[9].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[10].Value.ToString());

                        dataGridView1.Rows[i].Cells[12].Value = Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) > 0 ? Math.Round(Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) * 100, 2) : 0;
                        dataGridView1.Rows[i].Cells[13].Value = Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) > 0 ? Math.Round(Common.ConvertToDecimal(row[i].Cells[8].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) * 100, 2) : 0;
                        dataGridView1.Rows[i].Cells[14].Value = Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) > 0 ? Math.Round(Common.ConvertToDecimal(row[i].Cells[9].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) * 100, 2) : 0;
                        dataGridView1.Rows[i].Cells[15].Value = Common.ConvertToDecimal(row[i].Cells[5].Value.ToString()) > 0 ? Math.Round(Common.ConvertToDecimal(row[i].Cells[10].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[5].Value.ToString()) * 100, 2) : 0;
                        dataGridView1.Rows[i].Cells[16].Value = Common.ConvertToDecimal(row[i].Cells[6].Value.ToString()) > 0 ? Math.Round(Common.ConvertToDecimal(row[i].Cells[11].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[6].Value.ToString()) * 100, 2) : 0;
                        dataGridView1.Rows[i].Cells[21].Value = Common.ConvertToDecimal(row[i].Cells[17].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[18].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[19].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[20].Value.ToString());
                    }
                }
            }
            #endregion

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show(e.RowIndex.ToString()+","+ e.ColumnIndex.ToString());
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcalculateTotal();
        }
    }
}
