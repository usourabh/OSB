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
    public partial class OperationalDepotWiseFleetStrengthNBusesOnRoad : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "0";
        string finYear = "0";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public OperationalDepotWiseFleetStrengthNBusesOnRoad(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10] FROM [rpt].[tbl_OperationalDepotWiseFleetStrengthNBusesOnRoad] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                    dataGridView1.DataSource = dt;
                else
                    dataGridView1.DataSource = BindOperationalDepotWiseFleetStrengthNBusesOnRoad();
            }
            catch (Exception ex)
            {

            }

        }


        DataTable BindOperationalDepotWiseFleetStrengthNBusesOnRoad()
        {
            DataTable table = new DataTable();

            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Name of depot with parking facilities", typeof(string));
            table.Columns.Add("Date of Commis-sioning", typeof(string));
            table.Columns.Add("DTC No. of Buses ", typeof(string));
            table.Columns.Add("DTC No. of Buses  ", typeof(string));
            table.Columns.Add("DTC No. of Buses   ", typeof(string));
            table.Columns.Add("DTC No. of Buses    ", typeof(string));
            table.Columns.Add("DTC No. of Buses     ", typeof(string));
            table.Columns.Add("DTC No. of Buses      ", typeof(string));
            table.Columns.Add("DTC No. of Buses       ", typeof(string));
            table.Columns.Add("DTC No. of Buses        ", typeof(string));

            // Rows
           // table.Rows.Add("", "", "", "Capacity (in terms of number of buses can be parked under ideal condition)", "Held at the Opening of Month", "Buses added during the month","Scrapped During the month","Trans-ferred during month","Held Closing of the month","Avg.fleet during the month","Buses on Road");
            //table.Rows.Add("1", "2", "3", "4", "5", "6","7","8","9","10","11");
            table.Rows.Add("1", "B.B.M", "Dec.1954", "0", "0", "0","0","0","0","0","0");
            table.Rows.Add("2", "Rohini-I", "Sept.1988", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Rohini-II ", "Oct.1989", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Rohini-III", "Feb.1991", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Rohini-IV", "July-2010 ", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "Wazir Pur", "Oct.1974 ", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "Subhash Place", "Oct.1984 ", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("8", "G.T.K.Rd.", "Sept.1974 ", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("9", "Nangloi", "June.1983 ", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("10", "Kanjhawla", "Apr.2010 ", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("11", "Narela", "Feb.2010 ", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("12", "Rohini sec.-37 ", "Feb.2010 ", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("13", "Kalka Ji", "Nov.1966", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("14", "SNPD", "May.1975", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("15", "Ambedkar Nagar", "June.1975", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("16", "Vasant Vihar", "April.1976", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("17", "Tehkhand", "June.2010", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("18", "Sukhdev Vihar", "Feb.1976", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("19", "Sarojni Nagar", "April.1954", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("20", "Nand Nagri", "Jan.1983", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("21", "NOIDA", "Feb.1984", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("22", "E.V.Nagar", "July.2003", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("23", "HasanPur", "Nov.1979", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("24", "Inderprastha", "Aug.1954", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("25", "Gazi Pur", "Oct.1989", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("26", "Raj Ghat-I", "Oct.2010", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("27", "Hari Nagar-I ", "July.1961", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("28", "Hari Nagar-II", "July.1975", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("29", "Kesho Pur", "March.1985", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("30", "Naraina", "Jan.1982", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("31", "Shadi Pur", "May.1957", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("32", "BAGDOLA", "Oct.2009", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("33", "DW.SEC-2", "Feb.2009", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("34", "Maya Puri", "Sept.1974", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("35", "Dichaon Kalan", "Oct.1974", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("36", "Peera Garhi", "Jun.1989", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("37", "Mundhela kalan", "May.2020", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Grand Total", "", "", "", "", "", "", "", "", "");

            return table;
        }

        private void ResetOnClick(object sender, EventArgs e)
        {
          
            dataGridView1.DataSource = BindOperationalDepotWiseFleetStrengthNBusesOnRoad();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_OperationalDepotWiseFleetStrengthNBusesOnRoad", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_OperationalDepotWiseFleetStrengthNBusesOnRoad] ([OsbId],[S_No],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10]) VALUES (@OsbId,@S_No,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10)", con);
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
            DeleteExisitingTableRecord("tbl_OperationalDepotWiseFleetStrengthNBusesOnRoad", OsbId);
            dataGridView1.DataSource = BindOperationalDepotWiseFleetStrengthNBusesOnRoad();
            MessageBox.Show("Done");
        }
        private void OperationalDepotWiseFleetStrengthNBusesOnRoad_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
         
        }

        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptOperationalDepotWiseFleetStrengthNBusesOnRoad objFrm = new rptOperationalDepotWiseFleetStrengthNBusesOnRoad(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }
    }
}
