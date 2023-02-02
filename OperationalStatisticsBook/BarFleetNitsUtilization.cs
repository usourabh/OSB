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
    public partial class BarFleetNitsUtilization : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "0";
        string finYear = "0";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);



        public BarFleetNitsUtilization(int OsbId, int Year, int Month, string finYear, string MonthName)
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
            con.Open();
            string strTable = "[" + TableName + "]";
            int i = 0;
            SqlCommand cmd = new SqlCommand("delete from " + strTable + " where OsbId=@OsbId", con);
            cmd.Parameters.AddWithValue("@OsbId", OsbId);
            cmd.CommandType = CommandType.Text;


            i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }


        DataTable BindBarFleetNItsUtilization()
        {
            var MonthList = GlobalMaster.GetPrevousMonthList(Month, Year, 13);
            DataTable table = new DataTable();
            table.Columns.Add("MONTH", typeof(string));
            table.Columns.Add("Value", typeof(string));


            table.Rows.Add(MonthList[12].MonthName + "-" + MonthList[12].Year);
            table.Rows.Add(MonthList[11].MonthName + "-" + MonthList[11].Year);
            table.Rows.Add(MonthList[10].MonthName + "-" + MonthList[10].Year);
            table.Rows.Add(MonthList[9].MonthName + "-" + MonthList[9].Year);
            table.Rows.Add(MonthList[8].MonthName + "-" + MonthList[8].Year);
            table.Rows.Add(MonthList[7].MonthName + "-" + MonthList[7].Year);
            table.Rows.Add(MonthList[6].MonthName + "-" + MonthList[6].Year);
            table.Rows.Add(MonthList[5].MonthName + "-" + MonthList[5].Year);
            table.Rows.Add(MonthList[4].MonthName + "-" + MonthList[4].Year);
            table.Rows.Add(MonthList[3].MonthName + "-" + MonthList[3].Year);
            table.Rows.Add(MonthList[2].MonthName + "-" + MonthList[2].Year);
            table.Rows.Add(MonthList[1].MonthName + "-" + MonthList[1].Year);
            table.Rows.Add(MonthList[0].MonthName + "-" + MonthList[0].Year);

            return table;
        }


        private void BarFleetNitsUtilization_Load(object sender, EventArgs e)
        {
            BindBarFleetNItsUtilization();
        }


    }
}
