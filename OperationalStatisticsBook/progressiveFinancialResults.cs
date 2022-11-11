using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace OperationalStatisticsBook
{
    public partial class progressiveFinancialResults : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);

        public progressiveFinancialResults(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9] FROM [rpt].[tbl_ProgressiveFinancialResults] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    BtnSave.BackColor = Color.Green;
                }
                else
                {
                    dataGridView1.DataSource = BindProgressiveFinancialTable();
                }
            }
            catch (Exception ex)
            {

            }

        }
        DataTable BindProgressiveFinancialTable()
        { 
            DataTable table = new DataTable();
            table.Columns.Add("MONTH", typeof(string));
            table.Columns.Add("TOTAL INCOME AMT. (Rs.)", typeof(int));
            table.Columns.Add("WORKING EXPENDITURE AMT(Rs.)", typeof(string));
            table.Columns.Add("% RECOVERY WORKING EXPENDITURE", typeof(string));
            table.Columns.Add("WORKING LOSS/PROFIT AMT(Rs.)", typeof(string));
            table.Columns.Add("FIXED COST AMT(RS.)", typeof(string));
            table.Columns.Add("TOTAL EXPENDITURE AMT (RS.)", typeof(string));
            table.Columns.Add("% RECOVERY OF TOTAL EXPENDITURE", typeof(string));
            table.Columns.Add("NET LOSS AMT(Rs.)", typeof(string));            
            //Rows data
          //  table.Rows.Add("1", "2", "3", "3", "4", "4");
            DateTime currentDate = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate.AddMonths(-1);
            int previousYear = newDate.Year;
            String previousMonthName = newDate.ToString("MMMM");
            //if (Year > previousYear)
            //{
            //    //table.Rows.Add(previousYear, "0", "0", "0", "0", "0", "0", "0", "0");
            //    //table.Rows.Add(previousMonthName, "0", "0", "0", "0", "0", "0", "0", "0");
            //    //table.Rows.Add(Year, "0", "0", "0", "0", "0", "0", "0", "0");
            //     table.Rows.Add(Year, "0", "0", "0", "0", "0", "0", "0", "0");
            //     table.Rows.Add(previousMonthName, "0", "0", "0", "0", "0", "0", "0", "0");
            //}
            //else
            //{
            //    // table.Rows.Add(Year, "0", "0", "0", "0", "0", "0", "0", "0");
            //    //  table.Rows.Add(previousMonthName, "0", "0", "0", "0", "0", "0", "0", "0");
            //    table.Rows.Add(previousYear, "0", "0", "0", "0", "0", "0", "0", "0");
            //    table.Rows.Add(previousMonthName, "0", "0", "0", "0", "0", "0", "0", "0");
            //    table.Rows.Add(Year, "0", "0", "0", "0", "0", "0", "0", "0");
            //}       
            DateTime newDateM = currentDate.AddMonths(0);
            DateTime newDateCurrent2 = currentDate.AddYears(-1);
            string previousYear1 = newDateCurrent2.Year.ToString();
            DateTime currentMonth = currentDate.AddMonths(-6);
            table.Rows.Add(previousYear1, "0", "0", "0", "0", "0", "0", "0", "0");
            for (int i = 7; i > 0; i--)
            {
                table.Rows.Add(currentMonth.AddMonths(-i).ToString("MMMM"), "0", "0", "0", "0", "0", "0", "0", "0");
            }
            table.Rows.Add(Year, "0", "0", "0", "0", "0", "0", "0", "0");
            for (int i = 6; i > 0; i--)
            {
                table.Rows.Add(newDateM.AddMonths(-i).ToString("MMMM"), "0", "0", "0", "0", "0", "0", "0", "0");
            }
            //for (int i = 0; i > 7; i++)
            //{
            //    table.Rows.Add(currentDate.AddMonths(i).ToString("MMMM"), "0", "0", "0", "0", "0", "0", "0", "0");
            //}
            dataGridView1.DataSource = table;
            return table;
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

        private void progressiveFinancialResults_Load_1(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
           // BindProgressiveFinancialTable();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_ProgressiveFinancialResults", OsbId);
            dataGridView1.DataSource = BindProgressiveFinancialTable();
            MessageBox.Show("Done");

        }

        private void Print_ReportOnClick(object sender, EventArgs e)
        {
            rptprogressiveFinancialResults objFrm = new rptprogressiveFinancialResults(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_ProgressiveFinancialResults", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null )
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_ProgressiveFinancialResults] ([OsbId],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9]) VALUES (@Osbid,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                         cmd.Parameters.AddWithValue("@Param1", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param6", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param7", row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param8", row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param9", row.Cells[8].Value == null ? "" : row.Cells[8].Value.ToString());
                      
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
    }
}
