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
using WindowsFormsApp1;

namespace OperationalStatisticsBook
{
    public partial class BarFleetNUtilizationGrid : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "0";
        string finYear = "0";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public BarFleetNUtilizationGrid(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                //DataTable dt = new DataTable();
                //SqlCommand cmd = new SqlCommand("SELECT [Month],[Year],[Value] FROM [dbo].[tbl_BarFleetNUtilizationOsb] where OsbId=@OsbId", con);
                //cmd.Parameters.AddWithValue("@OsbId", OsbId);
                //cmd.CommandType = CommandType.Text;
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //sda.Fill(dt);


                DataTable dt1 = new DataTable();
                SqlCommand cmd1 = new SqlCommand("SP_BarFleetNUtilization", con);

                cmd1.Parameters.AddWithValue("@Month", Month);
                cmd1.Parameters.AddWithValue("@Year", Year);

                cmd1.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt1);


                if (dt1.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt1;
                    Data_Verified.BackColor = Color.Green;
                }
                else
                {



                    //dataGridView1.DataSource = BarFleetNUtilization();
                }
            }
            catch (Exception ex)
            {

            }


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

        DataTable BarFleetNUtilization()
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

        private void Reset_OnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_BarPassengerCarried ", OsbId);
            dataGridView1.DataSource = BarFleetNUtilization();
            MessageBox.Show("Done");
        }

        private void GeneratePdf_OnClick(object sender, EventArgs e)
        {
            BarFleetNUtilization obj = new BarFleetNUtilization(OsbId, Year, Month, finYear, MonthName);
            obj.Show();
        }

        private void Data_Verified_Click(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_BarFleetNUtilizationOsb", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO tbl_BarFleetNUtilizationOsb ([OsbId],[Value],[Month]) VALUES (@OsbId,@Value,@Month)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@Value", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Month", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurred while inserting data: " + ex.Message);

                }

            }
            MessageBox.Show("Done");

        }

        private void BarFleetNUtilizationGrid_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
        }
    }
}
