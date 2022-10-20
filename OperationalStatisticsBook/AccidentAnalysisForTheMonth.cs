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
    public partial class AccidentAnalysisForTheMonth : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);

        public AccidentAnalysisForTheMonth(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16],[Param17],[Param18],[Param19],[Param20],[Param21],[Param22],[Param23],[Param24],[Param25],[Param26],[Param27],[Param28],[Param29],[Param30],[Param31][Param32],[Param33],[Param34],[Param35],[Param36],[Param37],[Param38],[Param39],[Param40],[Param41] FROM [rpt].[tbl_AccidentAnalysisForTheMonth] where OsbId=@OsbId", con);
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
                    dataGridView1.DataSource = BindAccidentAnalysisForTheMonth();
                }
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
      
        DataTable BindAccidentAnalysisForTheMonth()
        {
            DataTable table = new DataTable();

            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Name of Depot", typeof(string));
            table.Columns.Add("MINOR*", typeof(string));
            table.Columns.Add("MINOR* ", typeof(string));
            table.Columns.Add("MINOR*  ", typeof(string));
            table.Columns.Add("MINOR*   ", typeof(string));
            table.Columns.Add("MINOR*     ", typeof(string));
            table.Columns.Add("MAJOR**", typeof(string));
            table.Columns.Add("MAJOR** ", typeof(string));
            table.Columns.Add("MAJOR**  ", typeof(string));
            table.Columns.Add("MAJOR**   ", typeof(string));
            table.Columns.Add("MAJOR**    ", typeof(string));
            table.Columns.Add("FATAL***", typeof(string));
            table.Columns.Add("FATAL*** ", typeof(string));
            table.Columns.Add("FATAL***  ", typeof(string));
            table.Columns.Add("FATAL***   ", typeof(string));
            table.Columns.Add("FATAL***    ", typeof(string));
            table.Columns.Add("TOTAL", typeof(string));
            table.Columns.Add("TOTAL ", typeof(string));
            table.Columns.Add("TOTAL  ", typeof(string));
            table.Columns.Add("TOTAL   ", typeof(string));
            table.Columns.Add("TOTAL     ", typeof(string));
            table.Columns.Add("RATIO PER ONE LAKH KMS.", typeof(string));
            table.Columns.Add("RATIO PER ONE LAKH KMS. ", typeof(string));
            table.Columns.Add("RATIO PER ONE LAKH KMS.  ", typeof(string));
            table.Columns.Add("RATIO PER ONE LAKH KMS.   ", typeof(string));
            table.Columns.Add("RATIO PER ONE LAKH KMS.    ", typeof(string));
            table.Columns.Add("PERSONS INJURED", typeof(string));
            table.Columns.Add("PERSONS INJURED ", typeof(string));
            table.Columns.Add("PERSONS INJURED  ", typeof(string));
            table.Columns.Add("PERSONS INJURED   ", typeof(string));
            table.Columns.Add("PERSONS INJURED    ", typeof(string));
            table.Columns.Add("PERSONS KILLED ", typeof(string));
            table.Columns.Add("PERSONS KILLED  ", typeof(string));
            table.Columns.Add("PERSONS KILLED   ", typeof(string));
            table.Columns.Add("PERSONS KILLED    ", typeof(string));
            table.Columns.Add("PERSONS KILLED      ", typeof(string));
            table.Columns.Add("FATALITIES PER 100000 KMS", typeof(string));
            table.Columns.Add("FATALITIES PER 100000 KMS ", typeof(string));
            table.Columns.Add("FATALITIES PER 100000 KMS  ", typeof(string));
            table.Columns.Add("FATALITIES PER 100000 KMS   ", typeof(string));
            table.Columns.Add("FATALITIES PER 100000 KMS    ", typeof(string));

            ///Rows here........ 
            table.Rows.Add(" ", " ", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total");
            table.Rows.Add(" ", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ");
            table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22","23","24","25","26","27","28","29","30","31","32","33","34","35","36","37","38","39","40","41","42");
            table.Rows.Add("2", "BBM ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Rohini-I ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Rohini-II ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Rohini-III ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "Rohini-IV ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "Wazir Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("8", "Subhash Place", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("9", "G.T.K. Rd. ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("10", "Nangloi ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("11", "Kanjhawla", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("12", "Narela", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("13", "Kalka Ji", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("14", "Sri Niwas puri", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("15", "AND", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("16", "Vasant Vihar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("17", "Tehkhand ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("18", "Sukhdev Vihar  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("19", "Sarojni Nagar   ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("20", "Nand Nagri ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("21", "NOIDA ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("22", "EVND ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("23", "Hasan Pur ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("24", "Gazi Pur ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("25", "Rajghat I ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("26", "Hari Nagar I ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("27", "Hari Nagar II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("28", "Kesho Pur ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("29", "Naraina", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("30", "Shadi Pur  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("31", "BAGDOLA", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("32", "DW. SEC.-II ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("33", "Maya Puri ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("34", "Dichaon Kalan", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("35", "Peera Garhi", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "Total ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" Electric Buses", " ", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            table.Rows.Add("1", " Rohini sec. 37", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Mundhela kalan ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "Total Electric ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "Total DTC ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" International", " ", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            table.Rows.Add("1", "Kathmandu", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Grand Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");


            return table;
        }
        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_AccidentAnalysisForTheMonth", OsbId);
            dataGridView1.DataSource = BindAccidentAnalysisForTheMonth();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_AccidentAnalysisForTheMonth", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null || row.Cells[11].Value != null || row.Cells[12].Value != null || row.Cells[13].Value != null || row.Cells[14].Value != null || row.Cells[15].Value != null || row.Cells[16].Value != null || row.Cells[17].Value != null || row.Cells[18].Value != null || row.Cells[19].Value != null || row.Cells[20].Value != null || row.Cells[21].Value != null || row.Cells[22].Value != null || row.Cells[23].Value != null || row.Cells[24].Value != null || row.Cells[25].Value != null || row.Cells[26].Value != null || row.Cells[27].Value != null || row.Cells[28].Value != null || row.Cells[27].Value != null || row.Cells[28].Value != null || row.Cells[30].Value != null || row.Cells[31].Value != null || row.Cells[32].Value != null || row.Cells[33].Value != null || row.Cells[34].Value != null || row.Cells[35].Value != null || row.Cells[36].Value != null || row.Cells[37].Value != null || row.Cells[38].Value != null || row.Cells[39].Value != null || row.Cells[40].Value != null || row.Cells[41].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_AccidentAnalysisForTheMonth] ([OsbId],[S_No],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16],[Param17],[Param18],[Param19],[Param20],[Param21],[Param22],[Param23],[Param24],[Param25],[Param26],[Param27],[Param28],[Param29],[Param30],[Param31],[Param32],[Param33],[Param34],[Param35],[Param36],[Param37],[Param38],[Param39],[Param40],[Param41]) VALUES (@OsbId,@S_No,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11,@Param12,@Param13,@Param14,@Param15,@Param16,@Param17,@Param18,@Param19,@Param20,@Param21,@Param22,@Param23,@Param24,@Param25,@Param26,@Param27,@Param28,@Param29,@Param30,@Param31,@Param32,@Param33,@Param34,@Param35,@Param36,@Param37,@Param38,@Param39,@Param40,@Param41)", con);
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
                        cmd.Parameters.AddWithValue("@Param17", row.Cells[17].Value == null ? "" : row.Cells[17].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param18", row.Cells[18].Value == null ? "" : row.Cells[18].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param19", row.Cells[19].Value == null ? "" : row.Cells[19].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param20", row.Cells[20].Value == null ? "" : row.Cells[20].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param21", row.Cells[21].Value == null ? "" : row.Cells[21].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param22", row.Cells[22].Value == null ? "" : row.Cells[22].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param23", row.Cells[23].Value == null ? "" : row.Cells[23].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param24", row.Cells[24].Value == null ? "" : row.Cells[24].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param25", row.Cells[25].Value == null ? "" : row.Cells[25].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param26", row.Cells[26].Value == null ? "" : row.Cells[26].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param27", row.Cells[27].Value == null ? "" : row.Cells[27].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param28", row.Cells[28].Value == null ? "" : row.Cells[28].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param29", row.Cells[29].Value == null ? "" : row.Cells[29].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param30", row.Cells[30].Value == null ? "" : row.Cells[30].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param31", row.Cells[31].Value == null ? "" : row.Cells[31].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param32", row.Cells[32].Value == null ? "" : row.Cells[32].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param33", row.Cells[33].Value == null ? "" : row.Cells[33].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param34", row.Cells[34].Value == null ? "" : row.Cells[34].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param35", row.Cells[35].Value == null ? "" : row.Cells[35].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param36", row.Cells[36].Value == null ? "" : row.Cells[36].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param37", row.Cells[37].Value == null ? "" : row.Cells[37].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param38", row.Cells[38].Value == null ? "" : row.Cells[38].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param39", row.Cells[39].Value == null ? "" : row.Cells[39].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param40", row.Cells[40].Value == null ? "" : row.Cells[40].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param41", row.Cells[41].Value == null ? "" : row.Cells[41].Value.ToString());
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
            DeleteExisitingTableRecord("tbl_AccidentAnalysisForTheMonth", OsbId);
            dataGridView1.DataSource = BindAccidentAnalysisForTheMonth();
            MessageBox.Show("Done");
        }
        private void AccidentAnalysisForTheMonth_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BindAccidentAnalysisForTheMonth();
            BindIndexPage(OsbId);
        }

        private void Print_ReportOnClick(object sender, EventArgs e)
        {
            rptAccidentAnalysisForTheMonth objFrm = new rptAccidentAnalysisForTheMonth(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }
    }
}
