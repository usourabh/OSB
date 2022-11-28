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
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16],[Param17],[Param18],[Param19],[Param20],[Param21],[Param22],[Param23],[Param24],[Param25],[Param26],[Param27],[Param28],[Param29],[Param30],[Param31],[Param32],[Param33],[Param34],[Param35],[Param36],[Param37],[Param38],[Param39],[Param40],[Param41] FROM [rpt].[tbl_AccidentAnalysisForTheMonth] where OsbId=@OsbId", con);
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

                Common.SetColumnNonEditable(dataGridView1, 6);
                Common.SetColumnNonEditable(dataGridView1, 11);
                Common.SetColumnNonEditable(dataGridView1, 16);
                Common.SetColumnNonEditable(dataGridView1, 17);
                Common.SetColumnNonEditable(dataGridView1, 18);
                Common.SetColumnNonEditable(dataGridView1, 19);
                Common.SetColumnNonEditable(dataGridView1, 20);
                Common.SetColumnNonEditable(dataGridView1, 21);
                Common.SetColumnNonEditable(dataGridView1, 31);
                Common.SetColumnNonEditable(dataGridView1, 36);
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
           // table.Rows.Add(" ", " ", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total");
           // table.Rows.Add(" ", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ");
           // table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22","23","24","25","26","27","28","29","30","31","32","33","34","35","36","37","38","39","40","41","42");
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
            DeleteExisitingTableRecord("[rpt].[tbl_AccidentAnalysisForTheMonth]", OsbId);

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


        void CalcalculateTotal()
        {
            var row = dataGridView1.Rows;

            #region Calculating_VerticalSum


            dataGridView1.Rows[34].Cells[2].Value = Common.GetSum(row, 0, 33, 2);
            dataGridView1.Rows[34].Cells[3].Value = Common.GetSum(row, 0, 33, 3);
            dataGridView1.Rows[34].Cells[4].Value = Common.GetSum(row, 0, 33, 4);
            dataGridView1.Rows[34].Cells[5].Value = Common.GetSum(row, 0, 33, 5);
            dataGridView1.Rows[34].Cells[6].Value = Common.GetSum(row, 0, 33, 6);
            dataGridView1.Rows[34].Cells[7].Value = Common.GetSum(row, 0, 33, 7);
            dataGridView1.Rows[34].Cells[8].Value = Common.GetSum(row, 0, 33, 8);
            dataGridView1.Rows[34].Cells[9].Value = Common.GetSum(row, 0, 33, 9);
            dataGridView1.Rows[34].Cells[10].Value = Common.GetSum(row, 0, 33, 10);
            dataGridView1.Rows[34].Cells[11].Value = Common.GetSum(row, 0, 33, 11);
            dataGridView1.Rows[34].Cells[12].Value = Common.GetSum(row, 0, 33, 12);
            dataGridView1.Rows[34].Cells[13].Value = Common.GetSum(row, 0, 33, 13);
            dataGridView1.Rows[34].Cells[14].Value = Common.GetSum(row, 0, 33, 14);
            dataGridView1.Rows[34].Cells[15].Value = Common.GetSum(row, 0, 33, 15);
            dataGridView1.Rows[34].Cells[16].Value = Common.GetSum(row, 0, 33, 16);

            dataGridView1.Rows[34].Cells[17].Value = Common.GetSum(row, 0, 33, 17);
            dataGridView1.Rows[34].Cells[18].Value = Common.GetSum(row, 0, 33, 18);
            dataGridView1.Rows[34].Cells[19].Value = Common.GetSum(row, 0, 33, 19);
            dataGridView1.Rows[34].Cells[20].Value = Common.GetSum(row, 0, 33, 20);
            dataGridView1.Rows[34].Cells[21].Value = Common.GetSum(row, 0, 33, 21);

            dataGridView1.Rows[34].Cells[27].Value = Common.GetSum(row, 0, 33, 27);
            dataGridView1.Rows[34].Cells[28].Value = Common.GetSum(row, 0, 33, 38);
            dataGridView1.Rows[34].Cells[29].Value = Common.GetSum(row, 0, 33, 29);
            dataGridView1.Rows[34].Cells[30].Value = Common.GetSum(row, 0, 33, 30);
            dataGridView1.Rows[34].Cells[31].Value = Common.GetSum(row, 0, 33, 31);
            dataGridView1.Rows[34].Cells[32].Value = Common.GetSum(row, 0, 33, 32);
            dataGridView1.Rows[34].Cells[33].Value = Common.GetSum(row, 0, 33, 33);
            dataGridView1.Rows[34].Cells[34].Value = Common.GetSum(row, 0, 33, 34);
            dataGridView1.Rows[34].Cells[35].Value = Common.GetSum(row, 0, 33, 35);
            dataGridView1.Rows[34].Cells[36].Value = Common.GetSum(row, 0, 33, 36);
            /////////////////////////////
            dataGridView1.Rows[38].Cells[2].Value = Common.GetSum(row, 36, 37, 2);
            dataGridView1.Rows[38].Cells[3].Value = Common.GetSum(row, 36, 37, 3);
            dataGridView1.Rows[38].Cells[4].Value = Common.GetSum(row, 36, 37, 4);
            dataGridView1.Rows[38].Cells[5].Value = Common.GetSum(row, 36, 37, 5);
            dataGridView1.Rows[38].Cells[6].Value = Common.GetSum(row, 36, 37, 6);
            dataGridView1.Rows[38].Cells[7].Value = Common.GetSum(row, 36, 37, 7);
            dataGridView1.Rows[38].Cells[8].Value = Common.GetSum(row, 36, 37, 8);
            dataGridView1.Rows[38].Cells[9].Value = Common.GetSum(row, 36, 37, 9);
            dataGridView1.Rows[38].Cells[10].Value = Common.GetSum(row, 36, 37, 10);
            dataGridView1.Rows[38].Cells[11].Value = Common.GetSum(row, 36, 37, 11);
            dataGridView1.Rows[38].Cells[12].Value = Common.GetSum(row, 36, 37, 12);
            dataGridView1.Rows[38].Cells[13].Value = Common.GetSum(row, 36, 37, 13);
            dataGridView1.Rows[38].Cells[14].Value = Common.GetSum(row, 36, 37, 14);
            dataGridView1.Rows[38].Cells[15].Value = Common.GetSum(row, 36, 37, 15);
            dataGridView1.Rows[38].Cells[16].Value = Common.GetSum(row, 36, 37, 16);
            dataGridView1.Rows[38].Cells[17].Value = Common.GetSum(row, 36, 37, 17);
            dataGridView1.Rows[38].Cells[18].Value = Common.GetSum(row, 36, 37, 18);
            dataGridView1.Rows[38].Cells[19].Value = Common.GetSum(row, 36, 37, 19);
            dataGridView1.Rows[38].Cells[20].Value = Common.GetSum(row, 36, 37, 20);
            dataGridView1.Rows[38].Cells[21].Value = Common.GetSum(row, 36, 37, 21);
            dataGridView1.Rows[38].Cells[27].Value = Common.GetSum(row, 36, 37, 27);
            dataGridView1.Rows[38].Cells[28].Value = Common.GetSum(row, 36, 37, 38);
            dataGridView1.Rows[38].Cells[29].Value = Common.GetSum(row, 36, 37, 29);
            dataGridView1.Rows[38].Cells[30].Value = Common.GetSum(row, 36, 37, 30);
            dataGridView1.Rows[38].Cells[31].Value = Common.GetSum(row, 36, 37, 31);
            dataGridView1.Rows[38].Cells[32].Value = Common.GetSum(row, 36, 37, 32);
            dataGridView1.Rows[38].Cells[33].Value = Common.GetSum(row, 36, 37, 33);
            dataGridView1.Rows[38].Cells[34].Value = Common.GetSum(row, 36, 37, 34);
            dataGridView1.Rows[38].Cells[35].Value = Common.GetSum(row, 36, 37, 35);
            dataGridView1.Rows[38].Cells[36].Value = Common.GetSum(row, 36, 37, 36);
            /////////////////////



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
            dataGridView1.Rows[39].Cells[12].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[12].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[12].Value.ToString());
            dataGridView1.Rows[39].Cells[13].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[13].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[13].Value.ToString());
            dataGridView1.Rows[39].Cells[14].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[14].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[14].Value.ToString());
            dataGridView1.Rows[39].Cells[15].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[15].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[15].Value.ToString());
            dataGridView1.Rows[39].Cells[16].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[16].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[16].Value.ToString());
            dataGridView1.Rows[39].Cells[17].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[17].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[17].Value.ToString());
            dataGridView1.Rows[39].Cells[18].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[18].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[18].Value.ToString());
            dataGridView1.Rows[39].Cells[19].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[19].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[19].Value.ToString());
            dataGridView1.Rows[39].Cells[20].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[20].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[20].Value.ToString());
            dataGridView1.Rows[39].Cells[21].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[21].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[21].Value.ToString());
            dataGridView1.Rows[39].Cells[27].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[27].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[27].Value.ToString());
            dataGridView1.Rows[39].Cells[28].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[28].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[28].Value.ToString());
            dataGridView1.Rows[39].Cells[29].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[29].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[29].Value.ToString());
            dataGridView1.Rows[39].Cells[30].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[30].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[30].Value.ToString());
            dataGridView1.Rows[39].Cells[31].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[31].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[31].Value.ToString());
            dataGridView1.Rows[39].Cells[32].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[32].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[32].Value.ToString());
            dataGridView1.Rows[39].Cells[33].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[33].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[33].Value.ToString());
            dataGridView1.Rows[39].Cells[34].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[34].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[34].Value.ToString());
            dataGridView1.Rows[39].Cells[35].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[35].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[35].Value.ToString());
            dataGridView1.Rows[39].Cells[36].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[36].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[36].Value.ToString());



            ///////////////////////
            dataGridView1.Rows[42].Cells[2].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[2].Value.ToString()) + Common.GetSum(row, 40, 41, 2);
            dataGridView1.Rows[42].Cells[3].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[3].Value.ToString()) + Common.GetSum(row, 40, 41, 3);
            dataGridView1.Rows[42].Cells[4].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[4].Value.ToString()) + Common.GetSum(row, 40, 41, 4);
            dataGridView1.Rows[42].Cells[5].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[5].Value.ToString()) + Common.GetSum(row, 40, 41, 5);
            dataGridView1.Rows[42].Cells[6].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[6].Value.ToString()) + Common.GetSum(row, 40, 41, 6);
            dataGridView1.Rows[42].Cells[7].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[7].Value.ToString()) + Common.GetSum(row, 40, 41, 7);
            dataGridView1.Rows[42].Cells[8].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[8].Value.ToString()) + Common.GetSum(row, 40, 41, 8);
            dataGridView1.Rows[42].Cells[9].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[9].Value.ToString()) + Common.GetSum(row, 40, 41, 9);
            dataGridView1.Rows[42].Cells[10].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[10].Value.ToString()) + Common.GetSum(row, 40, 41, 10);
            dataGridView1.Rows[42].Cells[11].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[11].Value.ToString()) + Common.GetSum(row, 40, 41, 11);
            dataGridView1.Rows[42].Cells[12].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[12].Value.ToString()) + Common.GetSum(row, 40, 41, 12);
            dataGridView1.Rows[42].Cells[13].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[13].Value.ToString()) + Common.GetSum(row, 40, 41, 13);
            dataGridView1.Rows[42].Cells[14].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[14].Value.ToString()) + Common.GetSum(row, 40, 41, 14);
            dataGridView1.Rows[42].Cells[15].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[15].Value.ToString()) + Common.GetSum(row, 40, 41, 15);
            dataGridView1.Rows[42].Cells[16].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[16].Value.ToString()) + Common.GetSum(row, 40, 41, 16);
            dataGridView1.Rows[42].Cells[17].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[17].Value.ToString()) + Common.GetSum(row, 40, 41, 17);
            dataGridView1.Rows[42].Cells[18].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[18].Value.ToString()) + Common.GetSum(row, 40, 41, 18);
            dataGridView1.Rows[42].Cells[19].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[19].Value.ToString()) + Common.GetSum(row, 40, 41, 19);
            dataGridView1.Rows[42].Cells[20].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[20].Value.ToString()) + Common.GetSum(row, 40, 41, 20);
            dataGridView1.Rows[42].Cells[21].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[21].Value.ToString()) + Common.GetSum(row, 40, 41, 21);
            dataGridView1.Rows[42].Cells[27].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[27].Value.ToString()) + Common.GetSum(row, 40, 41, 27);
            dataGridView1.Rows[42].Cells[28].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[28].Value.ToString()) + Common.GetSum(row, 40, 41, 38);
            dataGridView1.Rows[42].Cells[29].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[29].Value.ToString()) + Common.GetSum(row, 40, 41, 29);
            dataGridView1.Rows[42].Cells[30].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[30].Value.ToString()) + Common.GetSum(row, 40, 41, 30);
            dataGridView1.Rows[42].Cells[31].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[31].Value.ToString()) + Common.GetSum(row, 40, 41, 31);
            dataGridView1.Rows[42].Cells[32].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[32].Value.ToString()) + Common.GetSum(row, 40, 41, 32);
            dataGridView1.Rows[42].Cells[33].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[33].Value.ToString()) + Common.GetSum(row, 40, 41, 33);
            dataGridView1.Rows[42].Cells[34].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[34].Value.ToString()) + Common.GetSum(row, 40, 41, 34);
            dataGridView1.Rows[42].Cells[35].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[35].Value.ToString()) + Common.GetSum(row, 40, 41, 35);
            dataGridView1.Rows[42].Cells[36].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[36].Value.ToString()) + Common.GetSum(row, 40, 41, 36);
            #endregion

            #region Calculating_HorizontalSum
            for (int i = 0; i < (row.Count - 1); i++)
            {

                if (i >= 0)
                {
                    dataGridView1.Rows[i].Cells[6].Value = Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[5].Value.ToString());
                    dataGridView1.Rows[i].Cells[11].Value = Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[8].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[9].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[10].Value.ToString());

                    dataGridView1.Rows[i].Cells[16].Value = Common.ConvertToDecimal(row[i].Cells[12].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[14].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[15].Value.ToString());

                    dataGridView1.Rows[i].Cells[17].Value = Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[12].Value.ToString());
                    dataGridView1.Rows[i].Cells[18].Value = Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[8].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[13].Value.ToString());
                    dataGridView1.Rows[i].Cells[19].Value = Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[9].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[14].Value.ToString());
                    dataGridView1.Rows[i].Cells[20].Value = Common.ConvertToDecimal(row[i].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[15].Value.ToString());


                    dataGridView1.Rows[i].Cells[21].Value = Common.ConvertToDecimal(row[i].Cells[17].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[18].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[19].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[20].Value.ToString());
                    dataGridView1.Rows[i].Cells[31].Value = Common.ConvertToDecimal(row[i].Cells[27].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[28].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[29].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[30].Value.ToString());
                    dataGridView1.Rows[i].Cells[36].Value = Common.ConvertToDecimal(row[i].Cells[32].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[33].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[34].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[35].Value.ToString());
                }
            }
            #endregion

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcalculateTotal();
        }
    }
}
