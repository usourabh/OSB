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
    public partial class TRAFFICINCOMEFORTHEMONTH : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);

        public TRAFFICINCOMEFORTHEMONTH(int OsbId, int Year, int Month, string finYear, string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;
        }

        DataTable BindTRAFFICINCOMEFORTHEMONTH()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Data ", typeof(string));


            // table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17");
            table.Rows.Add("Ticket Earning ", "0");
            table.Rows.Add("Pass Earning ", "0");
            table.Rows.Add("Tourist", "0");
            table.Rows.Add("Special Hire ", "0");
            table.Rows.Add("School Bus ", "0");
            table.Rows.Add("Pink Ticket Earning ", "0");

            return table;
        }

        DataTable BindTRAFFICINCOMEFORTHEMONTHautoSp(DataTable sp)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Data ", typeof(string));


            // table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17");
            table.Rows.Add("Pink Ticket Earning ", sp.Rows[0]["PinkTicketEarning"].ToString());
            table.Rows.Add("School Bus ", sp.Rows[0]["schoolBus"].ToString());
            table.Rows.Add("Special Hire ", sp.Rows[0]["specialHire"].ToString());
            table.Rows.Add("Tourist", sp.Rows[0]["tourist"].ToString());
            table.Rows.Add("Pass Earning ", sp.Rows[0]["PassEarning"].ToString());
            table.Rows.Add("Ticket Earning ", sp.Rows[0]["TicketEarning"].ToString());


            return table;
        }

        void BindIndexPage(int OsbId)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT [Name],[Data] FROM [rpt].[BarPieChartTrafficEarning] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);



                DataTable autoSpTable = new DataTable();
                SqlCommand cmd1 = new SqlCommand("[dbo].[TrafficEarningPieChartOSB]", con);
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
                    dataGridView1.DataSource = BindTRAFFICINCOMEFORTHEMONTHautoSp(autoSpTable);
                }

                else
                {
                    dataGridView1.DataSource = BindTRAFFICINCOMEFORTHEMONTH();
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("BarPieChartTrafficEarning", OsbId);
            dataGridView1.DataSource = BindTRAFFICINCOMEFORTHEMONTH();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("BarPieChartTrafficEarning", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[BarPieChartTrafficEarning] ([OsbId],[Name],[Data]) VALUES (@OsbId,@Name,@Data)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@Name", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Data", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());

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

        private void TRAFFICINCOMEFORTHEMONTH_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
        }

        private void PieChartOnClick(object sender, EventArgs e)
        {
            PieTrafficEarningForTheMonthOf traffic = new PieTrafficEarningForTheMonthOf(OsbId, Year, Month, finYear, MonthName);
            traffic.Show();
        }
    }
}
