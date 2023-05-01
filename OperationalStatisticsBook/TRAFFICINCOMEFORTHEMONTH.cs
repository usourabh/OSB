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
            //Convert.ToDecimal(sp.Rows[i]["SchTripCityNonAc"]) != 0 ? (Convert.ToDecimal(sp.Rows[i]["OperatedTripCityNonAc"]) * 100) / Convert.ToDecimal(sp.Rows[i]["SchTripCityNonAc"]) : 1;

            decimal totalEarning = Convert.ToDecimal(sp.Rows[0]["PinkTicketEarning"]) + Convert.ToDecimal(sp.Rows[0]["schoolBus"]) + Convert.ToDecimal(sp.Rows[0]["specialHire"]) + Convert.ToDecimal(sp.Rows[0]["tourist"]) + Convert.ToDecimal(sp.Rows[0]["PassEarning"]) + Convert.ToDecimal(sp.Rows[0]["TicketEarning"]);

            decimal pinkTicket = Math.Round((Convert.ToDecimal(sp.Rows[0]["PinkTicketEarning"]) * 100) / totalEarning, 2);
            decimal schoolBus = Math.Round((Convert.ToDecimal(sp.Rows[0]["schoolBus"]) * 100) / totalEarning, 2);
            decimal specialHire = Math.Round((Convert.ToDecimal(sp.Rows[0]["specialHire"]) * 100) / totalEarning, 2);
            decimal tourist = Math.Round((Convert.ToDecimal(sp.Rows[0]["tourist"]) * 100) / totalEarning, 2);
            decimal passEarning = Math.Round((Convert.ToDecimal(sp.Rows[0]["PassEarning"]) * 100) / totalEarning, 2);
            decimal ticketEarning = Math.Round((Convert.ToDecimal(sp.Rows[0]["TicketEarning"]) * 100) / totalEarning, 2);

            table.Rows.Add("Pink Ticket Earning ", pinkTicket.ToString());
            table.Rows.Add("School Bus ", schoolBus.ToString());
            table.Rows.Add("Pass Earning ", passEarning.ToString());
            table.Rows.Add("Tourist", tourist.ToString());
            table.Rows.Add("Ticket Earning ", ticketEarning.ToString());
            table.Rows.Add("Special Hire ", specialHire.ToString());



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
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from " + strTable + " where OsbId= " + OsbId, con);
            cmd.Parameters.AddWithValue("@OsbId", OsbId);
            cmd.CommandType = CommandType.Text;


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
                        con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[BarPieChartTrafficEarning] ([OsbId],[Name],[Data]) VALUES (@OsbId,@Name,@Data)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@Name", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Data", row.Cells[1].Value == null ? 0 : Convert.ToDecimal(row.Cells[1].Value));

                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
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
