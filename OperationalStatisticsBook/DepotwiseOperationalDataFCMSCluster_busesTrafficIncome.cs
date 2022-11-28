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
            String[,] param1 = new string[,]
                    {
                {"@Year",Year.ToString().Trim()},
                {"@Month",Month.ToString().Trim()},
            };
            DataTable dt1 = Common.ExecuteProcedure("sp_GetAllTrafficIncomeData", param1);

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                Save.BackColor = Color.Green;
            }
            else if (dt1.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt1;

            }
            else
            {
                dataGridView1.DataSource = BindDepotwiseOperationalDataFCMSCluster_busesTrafficIncome();
            }
            Common.SetRowNonEditable(dataGridView1, 0);
            Common.SetRowNonEditable(dataGridView1, 9);
            Common.SetRowNonEditable(dataGridView1, 10);
            Common.SetRowNonEditable(dataGridView1, 15);
            Common.SetRowNonEditable(dataGridView1, 16);
            CalcalculateTotal();
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

        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncome", OsbId);
            dataGridView1.DataSource = BindDepotwiseOperationalDataFCMSCluster_busesTrafficIncome();
            MessageBox.Show("Done");

        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DepotwiseOperationalDataFCMSCluster_busesTrafficIncome", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null )
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
            var row = dataGridView1.Rows;

            #region Calculating_VerticalSum

       
            dataGridView1.Rows[8].Cells[2].Value = Common.GetSum(row, 1, 7, 2);
            dataGridView1.Rows[8].Cells[3].Value = Common.GetSum(row, 1, 7, 3);


            dataGridView1.Rows[15].Cells[2].Value = Common.GetSum(row, 10, 14, 2);
            dataGridView1.Rows[15].Cells[3].Value = Common.GetSum(row, 10, 14, 3);



            // All Grand Total
            dataGridView1.Rows[16].Cells[2].Value = Common.ConvertToDecimal(dataGridView1.Rows[8].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[15].Cells[2].Value.ToString());
            dataGridView1.Rows[16].Cells[3].Value = Common.ConvertToDecimal(dataGridView1.Rows[8].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[15].Cells[3].Value.ToString());


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
    }
}
