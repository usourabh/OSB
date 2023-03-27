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
    public partial class DepotwiseOperationalDataFCMSCluster_busesTrafficIncome : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public DepotwiseOperationalDataFCMSCluster_busesTrafficIncome(int OsbId, int Year, int Month, string finYear, string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;
        }

        void ShowData()
        {
            DateTime currentDate = new DateTime(Year, Month, 01);
            String[,] param = new string[,]
                    {
                    {"@OsbId",OsbId.ToString()},

            };
            DataTable dt = Common.ExecuteProcedure("sp_rptDepotwiseOperationalDataFCMSCluster_busesTrafficIncome", param);


            DataTable autoSpTable = new DataTable();
            SqlCommand cmd1 = new SqlCommand("sp_DepotWiseOperFCMSClusterTrafficIncomeOSB8_2", con);
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
                dataGridView1.DataSource = BindDepotwiseOperationalDataFCMSCluster_busesTrafficIncome_sp(autoSpTable);
            }
            else
            {
                dataGridView1.DataSource = BindDepotwiseOperationalDataFCMSCluster_busesTrafficIncome();
            }

            CalcalculateTotal();
            NonEditableRowAndColumn();
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

        DataTable BindDepotwiseOperationalDataFCMSCluster_busesTrafficIncome()
        {
            DataTable table = new DataTable();

            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Name of Depot", typeof(string));
            table.Columns.Add("Monthly Traffic Income (Rs.) ", typeof(string));
            table.Columns.Add("Daily Traffic Income (Rs.)", typeof(string));
            table.Columns.Add("Traffic Income per bus per day(Rs.)", typeof(string));

            ///Rows here........ 
          //  table.Rows.Add("1 ", " 2", "3", "4", "5");
            table.Rows.Add("Non AC City", " ", "", "", "");
            table.Rows.Add("1", "Bawana Sec. 1  ", "0", "0", "0");
            table.Rows.Add("2", "Rani Khera-1 ", "0", "0", "0");
            table.Rows.Add("3", "Rani Khera-2 ", "0", "0", "0");
            table.Rows.Add("4", "Rani Khera-3 ", "0", "0", "0");
            table.Rows.Add("5", "Khadkhadi", "0", "0", "0");
            table.Rows.Add("6", "Dwk. Sec-22", "0", "0", "0");
            table.Rows.Add("7", "Rewla (Khanpur)", "0", "0", "0");
            table.Rows.Add(" ", "TOTAL", "0", "0", "0");
            table.Rows.Add(" AC City", " ", "", "", "");
            table.Rows.Add(" 1", "Bawana Sec. 5 ", "0", "0", "0");
            table.Rows.Add(" 2", "Inderprastha ", "0", "0", "0");
            table.Rows.Add(" 3", "Yamuna Vihar", "0", "0", "0");
            table.Rows.Add(" 4", "Ghuman Hera -1 ", "0", "0", "0");
            table.Rows.Add(" 5", "Ghuman Hera -2", "0", "0", "0");
            table.Rows.Add(" ", "TOTAL", "0", "0", "0");
            table.Rows.Add(" ", "Grand Total", "0", "0", "0");

            return table;
        }

        DataTable BindDepotwiseOperationalDataFCMSCluster_busesTrafficIncome_sp(DataTable sp)
        {
            DataTable table = new DataTable();

            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Name of Depot", typeof(string));
            table.Columns.Add("Monthly Traffic Income (Rs.) ", typeof(string));
            table.Columns.Add("Daily Traffic Income (Rs.)", typeof(string));
            table.Columns.Add("Traffic Income per bus per day(Rs.)", typeof(string));

            ///Rows here........ 
          //  table.Rows.Add("1 ", " 2", "3", "4", "5");
            table.Rows.Add("Non AC City", " ", "", "", "");
            table.Rows.Add("1", sp.Rows[0]["NameOfTheDepot"], sp.Rows[0]["MonthlyTrafficIncome"], sp.Rows[0]["DailyTrafficIncome"], sp.Rows[0]["TrafficIncomePerBusPerDay"]);
            table.Rows.Add("2", sp.Rows[1]["NameOfTheDepot"], sp.Rows[1]["MonthlyTrafficIncome"], sp.Rows[1]["DailyTrafficIncome"], sp.Rows[1]["TrafficIncomePerBusPerDay"]);
            table.Rows.Add("3", sp.Rows[2]["NameOfTheDepot"], sp.Rows[2]["MonthlyTrafficIncome"], sp.Rows[2]["DailyTrafficIncome"], sp.Rows[2]["TrafficIncomePerBusPerDay"]);
            table.Rows.Add("4", sp.Rows[3]["NameOfTheDepot"], sp.Rows[3]["MonthlyTrafficIncome"], sp.Rows[3]["DailyTrafficIncome"], sp.Rows[3]["TrafficIncomePerBusPerDay"]);
            table.Rows.Add("5", sp.Rows[4]["NameOfTheDepot"], sp.Rows[4]["MonthlyTrafficIncome"], sp.Rows[4]["DailyTrafficIncome"], sp.Rows[4]["TrafficIncomePerBusPerDay"]);
            table.Rows.Add("6", sp.Rows[5]["NameOfTheDepot"], sp.Rows[5]["MonthlyTrafficIncome"], sp.Rows[5]["DailyTrafficIncome"], sp.Rows[5]["TrafficIncomePerBusPerDay"]);
            table.Rows.Add("7", sp.Rows[6]["NameOfTheDepot"], sp.Rows[6]["MonthlyTrafficIncome"], sp.Rows[6]["DailyTrafficIncome"], sp.Rows[6]["TrafficIncomePerBusPerDay"]);
            table.Rows.Add(" ", "TOTAL", "0", "0", "0");
            table.Rows.Add(" AC City", " ", "", "", "");
            table.Rows.Add("1", sp.Rows[7]["NameOfTheDepot"], sp.Rows[7]["MonthlyTrafficIncome"], sp.Rows[7]["DailyTrafficIncome"], sp.Rows[7]["TrafficIncomePerBusPerDay"]);
            table.Rows.Add("2", sp.Rows[8]["NameOfTheDepot"], sp.Rows[8]["MonthlyTrafficIncome"], sp.Rows[8]["DailyTrafficIncome"], sp.Rows[8]["TrafficIncomePerBusPerDay"]);
            table.Rows.Add("3", sp.Rows[9]["NameOfTheDepot"], sp.Rows[9]["MonthlyTrafficIncome"], sp.Rows[9]["DailyTrafficIncome"], sp.Rows[9]["TrafficIncomePerBusPerDay"]);
            table.Rows.Add("4", sp.Rows[10]["NameOfTheDepot"], sp.Rows[10]["MonthlyTrafficIncome"], sp.Rows[10]["DailyTrafficIncome"], sp.Rows[10]["TrafficIncomePerBusPerDay"]);
            table.Rows.Add("5", sp.Rows[11]["NameOfTheDepot"], sp.Rows[11]["MonthlyTrafficIncome"], sp.Rows[11]["DailyTrafficIncome"], sp.Rows[11]["TrafficIncomePerBusPerDay"]);
            table.Rows.Add(" ", "TOTAL", "0", "0", "0");
            table.Rows.Add(" ", "Grand Total", "0", "0", "0");

            return table;
        }


        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncome", OsbId);
            dataGridView1.DataSource = BindDepotwiseOperationalDataFCMSCluster_busesTrafficIncome();
            NonEditableRowAndColumn();
            MessageBox.Show("Done");

        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncome", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncome] ([OsbId],[S_No],[Param1],[Param2],[Param3],[Param4]) VALUES (@OsbId,@S_No,@Param1,@Param2,@Param3,@Param4)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@S_No", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());


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
            DeleteExisitingTableRecord("tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncome", OsbId);
            dataGridView1.DataSource = BindDepotwiseOperationalDataFCMSCluster_busesTrafficIncome();
            MessageBox.Show("Done");
        }


        private void Print_ReportOnClick(object sender, EventArgs e)
        {

            rptDepotwiseOperationalDataFCMSCluster_busesTrafficIncome objFrm = new rptDepotwiseOperationalDataFCMSCluster_busesTrafficIncome(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();

        }

        void CalcalculateTotal()
        {

            int MonthLastDay = 0;
            DateTime currentDate = new DateTime(Year, Month, 01);
            String previousMonthName = currentDate.ToString("MMMM");
            switch (previousMonthName)
            {
                case "January":
                    MonthLastDay = 31;
                    break;
                case "February":
                    MonthLastDay = 28;
                    break;
                case "March":
                    MonthLastDay = 31;
                    break;
                case "April":
                    MonthLastDay = 30;
                    break;
                case "May":
                    MonthLastDay = 31;
                    break;
                case "June":
                    MonthLastDay = 30;
                    break;
                case "July":
                    MonthLastDay = 31;
                    break;
                case "August":
                    MonthLastDay = 31;
                    break;
                case "September":
                    MonthLastDay = 30;
                    break;
                case "October":
                    MonthLastDay = 31;
                    break;
                case "November":
                    MonthLastDay = 30;
                    break;
                case "December":
                    MonthLastDay = 31;
                    break;
            };

            var row = dataGridView1.Rows;

            #region Calculating_VerticalSum

            for (int i = 2; i <= 3; i++)
            {
                dataGridView1.Rows[8].Cells[i].Value = Common.GetSum(row, 1, 7, i);
                dataGridView1.Rows[15].Cells[i].Value = Common.GetSum(row, 10, 14, i);
                dataGridView1.Rows[16].Cells[i].Value = Common.ConvertToDecimal(dataGridView1.Rows[8].Cells[i].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[15].Cells[i].Value.ToString());
            }


            #region Calculating_HorizontalSum
            for (int i = 0; i < (row.Count - 1); i++)
            {

                if (i > 0)
                {
                    if (i != 0 && i != 9)
                    {
                        dataGridView1.Rows[i].Cells[3].Value = Math.Round((Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) / MonthLastDay));
                    }
                }
            }
            #endregion



            #endregion

        }

        private void DepotwiseOperationalDataFCMSCluster_busesTrafficIncome_Load(object sender, EventArgs e)
        {

            ShowData();

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcalculateTotal();
        }
        void NonEditableRowAndColumn()

        {
            Common.SetRowNonEditable(dataGridView1, 0);
            Common.SetRowNonEditable(dataGridView1, 8);
            dataGridView1.Rows[8].Cells[4].ReadOnly = false;
            Common.SetRowNonEditable(dataGridView1, 9);
            Common.SetRowNonEditable(dataGridView1, 15);
            Common.SetRowNonEditable(dataGridView1, 16);
            dataGridView1.Rows[15].Cells[4].ReadOnly = false;
            dataGridView1.Rows[16].Cells[4].ReadOnly = false;


        }
    }
}
