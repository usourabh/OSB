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
    public partial class MaterialConsumptionFrom : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);

        public MaterialConsumptionFrom(int OsbId, int Year, int Month, string finYear, string MonthName)
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

            if (finYear == "2023-24")
            {

                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select S_No, ITEM, UNIT, Param1, Param2, Param3 From [rpt].tbl_MaterialConsumptionFrom where OsbId = @OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", 132);
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
                    dataGridView1.DataSource = BindMaterialConsumptionFrom();
                }
            }

            else if (finYear == "2022-23")
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select S_No, ITEM, UNIT, Param1, Param2, Param3 From [rpt].tbl_MaterialConsumptionFrom where OsbId = @OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", 5);
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
                    // dataGridView1.DataSource = dt1;
                }
            }

            else
            {
                dataGridView1.DataSource = BindMaterialConsumptionFrom();
            }



            Common.SetColumnNonEditable(dataGridView1, 3);
            Common.SetColumnNonEditable(dataGridView1, 4);
            Common.SetColumnNonEditable(dataGridView1, 5);

        }

        DataTable BindMaterialConsumptionFrom()
        {
            DataTable table = new DataTable();

            // COLUMNS NAME

            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Unit", typeof(string));
            table.Columns.Add("2019-2020", typeof(string));
            table.Columns.Add("2020-2021", typeof(string));
            table.Columns.Add("2021-2022", typeof(string));

            //Rows data

            table.Rows.Add("1", "2", "3", "4", "5", "6");
            table.Rows.Add("A", "CNG BUSES CONSUMPTION", "", "", "", "");
            table.Rows.Add("1", "CNG(Qty.)", "Lakh kgs", " ", " ", " ");
            table.Rows.Add("2", "CNG(Value)", "Rs in Lakh", " ", " ", " ");
            table.Rows.Add("3", "CNG(output)", "KMP kg", " ", " ", " ");
            table.Rows.Add("B", "OIL Consumption", "", "", "", "");
            table.Rows.Add("1", "Lube oil(Qty.)", "Lakh Lts", " ", " ", " ");
            table.Rows.Add("2", "Lube oil(Value)", "Rs in Lakh", " ", " ", " ");
            table.Rows.Add("3", "Lube oil(Output)", "KMP Lts", " ", " ", " ");
            table.Rows.Add("C", "Tyres", "", "", "", "");
            table.Rows.Add("1", "New tyres (Qty.)", "No", "0", "0", "0");
            table.Rows.Add("2", "New tyre Value (with tube & flap)", " Rs per tyre", "0", "0", "0");
            table.Rows.Add("3", "Tyre out-put(I) New", "kms", " ", " ", " ");
            table.Rows.Add(" ", "(EA) Cumulative", "kms", " ", " ", " ");
            table.Rows.Add("D", "AVERAGE INVENTORY", "", "", "", "");
            table.Rows.Add("1", "Opening Balance", "Rs in Lakh", " ", " ", " ");
            table.Rows.Add("2", "Closing Balance", "Rs in Lakh", " ", " ", " ");

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

        private void ResetOnClick(object sender, EventArgs e)
        {
            BindMaterialConsumptionFrom();
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_MaterialConsumptionFrom", OsbId);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_MaterialConsumptionFrom] ([OsbId],[S_No],[ITEM],[UNIT],[Param1],[Param2],[Param3]) VALUES (@OsbId,@S_No,@ITEM,@UNIT,@Param1,@Param2,@Param3)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@S_No", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@ITEM", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@UNIT", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString().Trim());

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

        private void MaterialConsumptionFrom_Load(object sender, EventArgs e)
        {
            ShowData();
            //dataGridView1.DataSource = BindMaterialConsumptionFrom();
        }

        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptMaterialConsumptionFinancial objFrm = new rptMaterialConsumptionFinancial(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }
    }
}
