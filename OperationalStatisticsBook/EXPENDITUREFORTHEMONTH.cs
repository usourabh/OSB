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
    public partial class EXPENDITUREFORTHEMONTH : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public EXPENDITUREFORTHEMONTH(int OsbId, int Year, int Month, string finYear, string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;
        }

        DataTable BindEXPENDITUREFORTHEMONTH()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Data ", typeof(string));


            // table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17");
            table.Rows.Add("Interest ", "0");
            table.Rows.Add("MISC. ", "0");
            table.Rows.Add("CNG ", "0");
            table.Rows.Add("Salary", "0");
            table.Rows.Add("Store & Spare", "0");

            return table;
        }

        void BindIndexPage(int OsbId)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT [Name],[Data] FROM [rpt].[PieChartExpenditureForTheMonth] where OsbId=@OsbId", con);
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
                    dataGridView1.DataSource = BindEXPENDITUREFORTHEMONTH();
                }
            }
            catch (Exception ex)
            {

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
            DeleteExisitingTableRecord("PieChartExpenditureForTheMonth", OsbId);
            dataGridView1.DataSource = BindEXPENDITUREFORTHEMONTH();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("PieChartExpenditureForTheMonth", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[PieChartExpenditureForTheMonth] ([OsbId],[Name],[Data]) VALUES (@OsbId,@Name,@Data)", con);
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

        private void GeneratePieChartOnClick(object sender, EventArgs e)
        {
            PieExpenditureForTheMonthOf obj = new PieExpenditureForTheMonthOf( OsbId,  Year,  Month,  finYear,  MonthName);
            obj.Show();
        }

        private void EXPENDITUREFORTHEMONTH_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
        }
    }
}
