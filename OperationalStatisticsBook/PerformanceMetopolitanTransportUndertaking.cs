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
    public partial class PerformanceMetopolitanTransportUndertaking : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public PerformanceMetopolitanTransportUndertaking(int OsbId, int Year, int Month, string finYear, string MonthName)
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
        DataTable BindPerformanceMetopolitanTransportUndertaking()
        {
            DataTable table = new DataTable();

            table.Columns.Add("S.NO.", typeof(string));
            table.Columns.Add("Particular", typeof(string));
            table.Columns.Add("Unit", typeof(string));
            table.Columns.Add("DTC", typeof(string));
            table.Columns.Add("CSTC ", typeof(string));
            table.Columns.Add("BEST", typeof(string));
            table.Columns.Add("M.T.C. ", typeof(string));
            table.Columns.Add("B.M.T.C.", typeof(string));

            table.Rows.Add("", "", "", "DELHI", "CALCUTTA", "BOMBAY", "CHENNAI", "BANGLORE");
            table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8");
            table.Rows.Add("A", "Physical Parformance", "", "", "", "", "", "");
            table.Rows.Add("1", "Avg. fleet held", "Number", "", "", "", "", "");
            table.Rows.Add("2", "Avg. age of the fleet", "Years", "", "", "", "", "");
            table.Rows.Add("3", "%age of overaged Buses", "%age", "", "", "", "", "");
            table.Rows.Add("4", "Fleet Utlization", "%age", "", "", "", "", "");
            table.Rows.Add("5", "Vehicle Utilization", " Km/Bus/Day", "", "", "", "", "");
            table.Rows.Add("6", "Load Factor", " %age", "", "", "", "", "");
            table.Rows.Add("7", "Staff per bus", " Number", "", "", "", "", "");
            table.Rows.Add("8", "(a)Diesel consumption", " KMPL", "", "", "", "", "");
            table.Rows.Add("", "(b)CNG", " KMP KG", "", "", "", "", "");

            table.Rows.Add("B", "Financial Performance", "", "", "", "", "", "");
            table.Rows.Add("1", "Revenue per Km.", "Paise", "", "", "", "", "");
            table.Rows.Add("2", "Cost per Km", "Paise", "", "", "", "", "");

            table.Rows.Add("C", "Cost Structrue", "", "", "", "", "", "");
            table.Rows.Add("1", "Staff cost", "", "", "", "", "", "");
            table.Rows.Add("2", "Fuel and Lubricant", "", "", "", "", "", "");
            table.Rows.Add("3", "Tyres and tubes", "", "", "", "", "", "");
            table.Rows.Add("4", "Spares and Material", "", "", "", "", "", "");
            table.Rows.Add("5", "Interest", "", "", "", "", "", "");
            table.Rows.Add("6", "Depreciation", "", "", "", "", "", "");
            table.Rows.Add("7", "Taxes", "", "", "", "", "", "");
            table.Rows.Add("8", "Others", "", "", "", "", "", "");
                        return table;
        }
      

        private void ResetOnClick(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BindPerformanceMetopolitanTransportUndertaking();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_PerformanceMetopolitanTransportUndertaking", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null  )
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_PerformanceMetopolitanTransportUndertaking] ([OsbId],[SNo],[Particular],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6]) VALUES (@OsbId,@SNo,@Particular,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@SNo", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Particular", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param6", row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString());
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

        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptPerformanceMetopolitanTransportUndertaking objFrm = new rptPerformanceMetopolitanTransportUndertaking(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        private void PerformanceMetopolitanTransportUndertaking_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BindPerformanceMetopolitanTransportUndertaking();
        }
    }
}
