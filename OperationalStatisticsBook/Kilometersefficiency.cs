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
    public partial class Kilometersefficiency : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "0";
        string finYear = "0";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public Kilometersefficiency(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [Month],[Value] FROM [tbl_Kilometersefficiency] where OsbId=@OsbId", con);
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
                    dataGridView1.DataSource = BindKilometersefficiency();
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
        DataTable BindKilometersefficiency()
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

        private void btnSaveOnClick(object sender, EventArgs e)
        {
            {
                DeleteExisitingTableRecord("tbl_Kilometersefficiency", OsbId);

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    try
                    {
                        if (row.Cells[0].Value != null || row.Cells[1].Value != null)
                        {
                            SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Kilometersefficiency ([OsbId],[Month],[Value]) VALUES (@OsbId,@Month,@Value)", con);
                            cmd.Parameters.AddWithValue("@OsbId", OsbId);
                            //cmd.Parameters.AddWithValue("@Id", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                            cmd.Parameters.AddWithValue("@Month", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                            cmd.Parameters.AddWithValue("@Value", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                            //cmd.Parameters.AddWithValue("@Year", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());

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

        private void btnResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_Kilometersefficiency", OsbId);
            dataGridView1.DataSource = BindKilometersefficiency();
            MessageBox.Show("Done");
        }

        private void Kilometersefficiency_Load(object sender, EventArgs e)
        {
           // dataGridView1.DataSource = BindKilometersefficiency();
            BindIndexPage(OsbId);
        }

        private void GeneratePdf_Click(object sender, EventArgs e)
        {
            BarKilometersefficiency obj = new BarKilometersefficiency(OsbId, Year, Month, finYear, MonthName);
            obj.Show();
        }
    }
}



