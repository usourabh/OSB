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
    public partial class DistrubutionOfFleetByTypeMakeAndYearOfCommission : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public DistrubutionOfFleetByTypeMakeAndYearOfCommission(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [OsbId],[YearOfComm],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6] ,[Param7],[Param8] FROM [rpt].[tbl_ComparativeOperationalDataForThePeriod] where OsbId=@OsbId", con);
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
                    dataGridView1.DataSource = BindDistrubutionOfFleetByTypeMakeAndYearOfCommission();
                }
            }
            catch (Exception ex)
            {

            }

        }

        DataTable BindDistrubutionOfFleetByTypeMakeAndYearOfCommission()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Year of Comm.", typeof(string));
            table.Columns.Add("Leyland", typeof(string));
            table.Columns.Add("Leyland ", typeof(string));
            table.Columns.Add("TATA", typeof(string));
            table.Columns.Add("TATA  ", typeof(string));
            table.Columns.Add("TATA ", typeof(string));
            table.Columns.Add("JBM ", typeof(string));
            table.Columns.Add("Total  ", typeof(string));
            table.Columns.Add("Percentage ", typeof(string));

            table.Rows.Add("Year of Comm.", "CNG ", "CNG", "CNG", "CNG", "Electric", "Electric", "Total", "duistribution");
            table.Rows.Add(" ", "LOW FLOOR ", "LOW FLOOR", "LOW FLOOR", "LOW FLOOR", "LOW FLOOR", "LOW FLOOR", "Total", "by year of" );
            table.Rows.Add(" ", "NON AC ", "AC", "NON AC", "AC", "AC", "AC", "Total", "commission");
            table.Rows.Add("1", "2 ", "3", "4", "5", "6", "7", "8", "9");


            DateTime currentDate = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate.AddYears(1);
            DateTime newDate2 = currentDate.AddYears(+2);
            string currentYear = currentDate.AddYears(+2).ToString();


            String previousMonthName = newDate.ToString("MMMM");

            for (int i = 10; i > 0; i--)
            {


                table.Rows.Add(newDate.AddYears(-i).Year + "-" + newDate2.AddYears(-i).Year, "0", "0", "0", "0", "0", "0", "0", "0");
            }




            table.Rows.Add("TOTAL ", " ", "", "", "", "", "", "", "");


            table.Rows.Add("PercentageDistribution  ", " ", "", "", "", "", "", "", "");

            table.Rows.Add("BY TYPE /MAKEAVERAGE AGE(INYEAR) ", " ", "", "", "", "", "", "", "");

            table.Rows.Add(" ", " ", "", "", "", "", "", "", "");

            table.Rows.Add(" DISTRIBUTION OF FLEET", "DISTRIBUTION OF FLEET ", "DISTRIBUTION OF FLEET", "", "", "", "Extent of Overaged Buses", "Extent of Overaged Buses", "Extent of Overaged Buses");

          
            table.Rows.Add("As on 31st July-2022 ", " As on 31st July-2022", "As on 31st July-2022", "", "", "", "(More Than 8 Years Old)", "(More Than 8 Years Old)", "(More Than 8 Years Old)");
            table.Rows.Add("Age Group in Years ", "Number of buses ", "", "", "", "", "", "Absolute(Number)", "Percentage   ");
            table.Rows.Add("0 ", "0 ", "", "", "", "", "0", "0", "0");
            table.Rows.Add("0 ", "0 ", "", "", "", "", "0", "0", "0");
            table.Rows.Add("0 ", "0 ", "", "", "", "", "0", "0", "0");
            table.Rows.Add("0 ", "0 ", "", "", "", "", "0", "0", "0");
            table.Rows.Add("0 ", "0 ", "", "", "", "", "0", "0", "0");
            table.Rows.Add("0 ", "0 ", "", "", "", "", "0", "0", "0");
            table.Rows.Add("Total ", " ", "", "", "", "0", "0", "0", "0");
            table.Rows.Add(" ", " ", "", "", "", "", "0", "0", "0");
            table.Rows.Add(" ", " ", "", "", "", "", "0", "0", "0");
            table.Rows.Add(" ", " ", "", "", "", "", "0", "0", "0");
            table.Rows.Add(" ", " ", "", "", "", "", "0", "0", "0");
            table.Rows.Add(" ", " ", "", "", "", "", "0", "0", "0");
            table.Rows.Add(" ", " ", "", "", "", "", "0", "0", "0");
            table.Rows.Add(" ", " ", "", "", "", "", "0", "0", "0");
            table.Rows.Add(" ", " ", "", "", "", "", "0", "0", "0");
            table.Rows.Add(" ", " ", "", "", "", "", "0", "0", "0");
            table.Rows.Add("*Authorised Fleet Strength of DTC=5500 ", "*Authorised Fleet Strength of DTC=5500 ", "*Authorised Fleet Strength of DTC=5500", "", "", "", "0", "0", "0");


            return table;
        }

            private void ResetOnClick(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BindDistrubutionOfFleetByTypeMakeAndYearOfCommission();
            MessageBox.Show("Done");
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
        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommission", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null )
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_DistrubutionOfFleetByTypeMakeAndYearOfCommission] ([OsbId],[YearOfComm],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8]) VALUES (@OsbId,@YearOfComm,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@YearOfComm", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param6", row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param7", row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param8", row.Cells[8].Value == null ? "" : row.Cells[8].Value.ToString());
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

        private void DistrubutionOfFleetByTypeMakeAndYearOfCommission_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BindDistrubutionOfFleetByTypeMakeAndYearOfCommission();
        }

        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptDistributionOfFleetByTypeMake objFrm = new rptDistributionOfFleetByTypeMake(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }
    }
}
