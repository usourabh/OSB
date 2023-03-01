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
    public partial class DWODFCMSFleetItsUtilization : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public DWODFCMSFleetItsUtilization(int OsbId, int Year, int Month, string finYear, string MonthName)
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

        DataTable BindDWODFCMSFleetItsUtilization()
        {
            DataTable table = new DataTable();

            table.Columns.Add("S.No.", typeof(string));
            table.Columns.Add("Name of Depot", typeof(string));
            table.Columns.Add("Fleet as on last day of the month", typeof(string));
            table.Columns.Add("Avg. fleet during the month ", typeof(string));
            table.Columns.Add("Avg.no. of buses Scheduled  ", typeof(string));
            table.Columns.Add("Avg.no.of buses on Road ", typeof(string));
            table.Columns.Add("Percentage fleet utilisation  ", typeof(string));

            //  table.Rows.Add("1", "2", "3", "4", "5", "6", "7");
            table.Rows.Add("Non AC City", "", "", "", "", "", "");
            table.Rows.Add("1", "Bawana Sec.1", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Rani Khera-1 ", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Rani Khera-2", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Rani Khera-3", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Kharkhari Nahar", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "Dwk. Sec-22 ", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "Rewla (Khanpur)", "0", "0", "0", "0", "0");
            table.Rows.Add("", "TOTAL", "0", "0", "0", "0", "0");
            table.Rows.Add("AC City", "", "", "", "", "", "");
            table.Rows.Add("1", "Bawana Sec. 5", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Inderprastha", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Yamuna Vihar", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Ghuman Hera-1", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Ghuman Hera-2", "0", "0", "0", "0", "0");

            table.Rows.Add("", "TOTAL", "0", "0", "0", "0", "0");
            table.Rows.Add("", "GRAND TOTAL", "0", "0", "0", "0", "0");




            return table;
        }

        DataTable BindDWODFCMSFleetItsUtilization_sp()
        {
            DataTable table = new DataTable();

            table.Columns.Add("S.No.", typeof(string));
            table.Columns.Add("Name of Depot", typeof(string));
            table.Columns.Add("Fleet as on last day of the month", typeof(string));
            table.Columns.Add("Avg. fleet during the month ", typeof(string));
            table.Columns.Add("Avg.no. of buses Scheduled  ", typeof(string));
            table.Columns.Add("Avg.no.of buses on Road ", typeof(string));
            table.Columns.Add("Percentage fleet utilisation  ", typeof(string));

            //  table.Rows.Add("1", "2", "3", "4", "5", "6", "7");
            table.Rows.Add("Non AC City", "", "", "", "", "", "");
            table.Rows.Add("1", "Bawana Sec.1", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Rani Khera-1 ", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Rani Khera-2", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Rani Khera-3", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Kharkhari Nahar", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "Dwk. Sec-22 ", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "Rewla (Khanpur)", "0", "0", "0", "0", "0");
            table.Rows.Add("", "TOTAL", "0", "0", "0", "0", "0");
            table.Rows.Add("AC City", "", "", "", "", "", "");
            table.Rows.Add("1", "Bawana Sec. 5", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Inderprastha", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Yamuna Vihar", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Ghuman Hera-1", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Ghuman Hera-2", "0", "0", "0", "0", "0");

            table.Rows.Add("", "TOTAL", "0", "0", "0", "0", "0");
            table.Rows.Add("", "GRAND TOTAL", "0", "0", "0", "0", "0");




            return table;
        }

        void ShowData()
        {
            DateTime currentDate = new DateTime(Year, Month, 01);
            String[,] param = new string[,]
                    {
                    {"@OsbId",OsbId.ToString()},

            };
            DataTable dt = Common.ExecuteProcedure("sp_DWODFCMSFleetItsUtilization", param);


            DataTable autoSpTable = new DataTable();
            SqlCommand cmd1 = new SqlCommand("sp_DepotWiseOperFCMSClusterFleetNUtilizationOSB8_1", con);
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
                dataGridView1.DataSource = dt1;

            }
            else
            {
                dataGridView1.DataSource = BindDWODFCMSFleetItsUtilization();
            }

            CalcalculateTotal();
            NonEditableRowAndColumn();

        }

        private void ResetOnClick(object sender, EventArgs e)
        {

            DeleteExisitingTableRecord("tbl_DWODFCMSFleetItsUtilization", OsbId);
            dataGridView1.DataSource = BindDWODFCMSFleetItsUtilization();
            NonEditableRowAndColumn();
            MessageBox.Show("Done");

        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DWODFCMSFleetItsUtilization", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_DWODFCMSFleetItsUtilization] ([OsbId],[SNo],[Depot],[Param1],[Param2],[Param3],[Param4],[Param5]) VALUES (@OsbId,@SNo,@Depot,@Param1,@Param2,@Param3,@Param4,@Param5)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@SNo", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Depot", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString());
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

        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptDWODFCMSFleetItsUtilization objFrm = new rptDWODFCMSFleetItsUtilization(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        void CalcalculateTotal()
        {
            var row = dataGridView1.Rows;

            #region Calculating_VerticalSum


            dataGridView1.Rows[8].Cells[2].Value = Common.GetSum(row, 1, 7, 2);
            dataGridView1.Rows[8].Cells[3].Value = Common.GetSum(row, 1, 7, 3);
            dataGridView1.Rows[8].Cells[4].Value = Common.GetSum(row, 1, 7, 4);
            dataGridView1.Rows[8].Cells[5].Value = Common.GetSum(row, 1, 7, 5);


            dataGridView1.Rows[15].Cells[2].Value = Common.GetSum(row, 10, 14, 2);
            dataGridView1.Rows[15].Cells[3].Value = Common.GetSum(row, 10, 14, 3);
            dataGridView1.Rows[15].Cells[4].Value = Common.GetSum(row, 10, 14, 4);
            dataGridView1.Rows[15].Cells[5].Value = Common.GetSum(row, 10, 14, 5);



            // All Grand Total
            dataGridView1.Rows[16].Cells[2].Value = Common.ConvertToDecimal(dataGridView1.Rows[8].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[15].Cells[2].Value.ToString());
            dataGridView1.Rows[16].Cells[3].Value = Common.ConvertToDecimal(dataGridView1.Rows[8].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[15].Cells[3].Value.ToString());
            dataGridView1.Rows[16].Cells[4].Value = Common.ConvertToDecimal(dataGridView1.Rows[8].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[15].Cells[4].Value.ToString());
            dataGridView1.Rows[16].Cells[5].Value = Common.ConvertToDecimal(dataGridView1.Rows[8].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[15].Cells[5].Value.ToString());



            #endregion

            #region Calculating_HorizontalSum
            for (int i = 0; i < (row.Count - 1); i++)
            {

                if (i > 0)
                {
                    if (i != 0 && i != 9)
                    {

                        dataGridView1.Rows[i].Cells[6].Value = Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[i].Cells[5].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[3].Value.ToString())) * 100, 2) : 0;

                    }
                }
            }
            #endregion

        }

        private void DWODFCMSFleetItsUtilization_Load(object sender, EventArgs e)
        {

            ShowData();
            //dataGridView1.DataSource = BindDWODFCMSFleetItsUtilization();

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcalculateTotal();
        }
        void NonEditableRowAndColumn()
        {
            Common.SetRowNonEditable(dataGridView1, 0);
            Common.SetRowNonEditable(dataGridView1, 8);
            Common.SetRowNonEditable(dataGridView1, 9);
            Common.SetRowNonEditable(dataGridView1, 15);
            Common.SetRowNonEditable(dataGridView1, 16);
            Common.SetColumnNonEditable(dataGridView1, 6);
        }
    }
}
