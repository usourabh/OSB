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
    public partial class StaffRatioAsOn : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public StaffRatioAsOn(int OsbId, int Year, int Month, string finYear, string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;
        }


        //void BindIndexPage(int OsbId)
        //{

        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        SqlCommand cmd = new SqlCommand("SELECT [Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7] FROM [rpt].[tbl_StaffRatioAsOn] where OsbId=@OsbId", con);
        //        cmd.Parameters.AddWithValue("@OsbId", OsbId);
        //        cmd.CommandType = CommandType.Text;
        //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //        sda.Fill(dt);
        //        if (dt.Rows.Count > 0)
        //            dataGridView1.DataSource = dt;
        //        else
        //            dataGridView1.DataSource = BindStaffRatioAsOn();
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}
        void ShowData()
        {
            DateTime currentDate = new DateTime(Year, Month, 01);
            String[,] param = new string[,]
            {
                {"@OsbId",OsbId.ToString()},
            };
            DataTable dt = Common.ExecuteProcedure("sp_rptStaffRatioAsOn", param);
            //String[,] param1 = new string[,]
            //{
            //    {"@Year",Year.ToString().Trim()},
            //    {"@Month",Month.ToString().Trim()},
            //};
            //DataTable dt1 = Common.ExecuteProcedure("rptGetAllMaterialConsumption", param1);

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                Save.BackColor = Color.Green;
            }
            //else if (dt1.Rows.Count > 0)
            //{
            //    dataGridView1.DataSource = dt1;

            //}
            else
            {
                dataGridView1.DataSource = BindStaffRatioAsOn();
              
            }

            Common.SetColumnNonEditable(dataGridView1, 2);
            Common.SetColumnNonEditable(dataGridView1, 5);
            Common.SetRowNonEditable(dataGridView1, 5);
            for (short i = 0; i < 5; i++) 
            {
                dataGridView1.Rows[i].Cells[3].ReadOnly = true;
                dataGridView1.Rows[i].Cells[3].Style.BackColor = Color.LightGray;
                dataGridView1.Rows[i].Cells[6].ReadOnly = true;
                dataGridView1.Rows[i].Cells[6].Style.BackColor = Color.LightGray;
            }


            //dataGridView1.Rows[].Cells[].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;

            CalculateTotal();
        }

        int DeleteExisitingdtRecord(string dtName, int OsbId)
        {
            string strdt = "[rpt].[" + dtName + "]";
            int i = 0;
            SqlCommand cmd = new SqlCommand("delete from " + strdt + " where OsbId=@OsbId", con);
            cmd.Parameters.AddWithValue("@OsbId", OsbId);
            cmd.CommandType = CommandType.Text;
            con.Open();

            i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }

        DataTable BindStaffRatioAsOn()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Prescribed Ratio Bus held", typeof(string));
            dt.Columns.Add("Prescribed staff on authorised 5500 DTC Buses ", typeof(string));
            dt.Columns.Add("Staff required on existing fleet strength 3913 ", typeof(string));
            dt.Columns.Add("staff on roll", typeof(string));
            dt.Columns.Add("Staff excess/short", typeof(string));
            dt.Columns.Add("Staff excess/short ", typeof(string));
          

         //   dt.Rows.Add("", "", "", "", "", "Authorised Fl.Strength (Col.5-3)", "@Actual Fl.Strength (Col.5-4)");
         //   dt.Rows.Add("1", "2", "3", "4", "5", "6","7");
            dt.Rows.Add("Driver", "2.65", "", "", "", "","");
            dt.Rows.Add("Conductor", "2.65", "", "", "", "","");
            dt.Rows.Add("Traffic Supervisor", "0.50", "", "", "", "","");
            dt.Rows.Add("Repair & Maintainance", "0.25", "", "", "", "","");
            dt.Rows.Add("Admin.", "1.00", "", "", "", "","");
            dt.Rows.Add("Total*", "7.05", "", "", "", "","");
            dt.Rows.Add("", " ", " ", " ", " ", " "," ");
            dt.Rows.Add("*Included Short term/Contract Basis Staff", "", "Short term  S/ Guards", " ", "", "Short term Manager", "");
            dt.Rows.Add("", "", "Short term  Drivers", " ", "", " Part Time MO", "");
            dt.Rows.Add("", "", "Short term Conductors", "", "", "Consultant ", "");
            dt.Rows.Add("", "", "Short term Press", "", "", "", "");
            
           
           
            return dt;
        }

        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingdtRecord("tbl_StaffRatioAsOn", OsbId);
            dataGridView1.DataSource = BindStaffRatioAsOn();
            MessageBox.Show("Done");
        }    

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingdtRecord("tbl_StaffRatioAsOn", OsbId);
            CalculateTotal();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_StaffRatioAsOn] ([OsbId],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7]) VALUES (@OsbId,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param6", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param7", row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString());
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
            rptStaffRatioAsOn objFrm = new rptStaffRatioAsOn(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        private void StaffRatioAsOn_Load(object sender, EventArgs e)
        {
            ShowData();
            //BindIndexPage(OsbId);
           // dataGridView1.DataSource = BindStaffRatioAsOn();
        }

        void CalculateTotal()
        {
            var row = dataGridView1.Rows;

            // Column no = 3 

             dataGridView1.Rows[0].Cells[2].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[0].Cells[1].Value.ToString()) * 5500, 0);
             dataGridView1.Rows[1].Cells[2].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[1].Cells[1].Value.ToString()) * 5500, 0); 
             dataGridView1.Rows[2].Cells[2].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[2].Cells[1].Value.ToString()) * 5500, 0);
             dataGridView1.Rows[3].Cells[2].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[3].Cells[1].Value.ToString()) * 5500, 0);
             dataGridView1.Rows[4].Cells[2].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[4].Cells[1].Value.ToString()) * 5500, 0);
             dataGridView1.Rows[5].Cells[2].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[5].Cells[1].Value.ToString()) * 5500, 0);

            // column no 4 

            dataGridView1.Rows[0].Cells[3].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[0].Cells[1].Value.ToString()) * 4060, 0);
            dataGridView1.Rows[1].Cells[3].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[1].Cells[1].Value.ToString()) * 4060, 0);
            dataGridView1.Rows[2].Cells[3].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[2].Cells[1].Value.ToString()) * 4060, 0);
            dataGridView1.Rows[3].Cells[3].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[3].Cells[1].Value.ToString()) * 4060, 0);
            dataGridView1.Rows[4].Cells[3].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[4].Cells[1].Value.ToString()) * 4060, 0);
            dataGridView1.Rows[5].Cells[3].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[5].Cells[1].Value.ToString()) * 4060, 0);

            // Formulas column no = 6, 7
            //Col = 6
            dataGridView1.Rows[0].Cells[5].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[0].Cells[4].Value.ToString()) - Common.ConvertToDecimal(dataGridView1.Rows[0].Cells[2].Value.ToString()), 0);
            dataGridView1.Rows[1].Cells[5].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[1].Cells[4].Value.ToString()) - Common.ConvertToDecimal(dataGridView1.Rows[1].Cells[2].Value.ToString()), 0);
            dataGridView1.Rows[2].Cells[5].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[2].Cells[4].Value.ToString()) - Common.ConvertToDecimal(dataGridView1.Rows[2].Cells[2].Value.ToString()), 0);
            dataGridView1.Rows[3].Cells[5].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[3].Cells[4].Value.ToString()) - Common.ConvertToDecimal(dataGridView1.Rows[3].Cells[2].Value.ToString()), 0);
            dataGridView1.Rows[4].Cells[5].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[4].Cells[4].Value.ToString()) - Common.ConvertToDecimal(dataGridView1.Rows[4].Cells[2].Value.ToString()), 0);
            dataGridView1.Rows[5].Cells[5].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[5].Cells[4].Value.ToString()) - Common.ConvertToDecimal(dataGridView1.Rows[5].Cells[2].Value.ToString()), 0);
            //Col = 7                                                                                                                                                     
            dataGridView1.Rows[0].Cells[6].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[0].Cells[4].Value.ToString()) - Common.ConvertToDecimal(dataGridView1.Rows[0].Cells[3].Value.ToString()), 0);
            dataGridView1.Rows[1].Cells[6].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[1].Cells[4].Value.ToString()) - Common.ConvertToDecimal(dataGridView1.Rows[1].Cells[3].Value.ToString()), 0);
            dataGridView1.Rows[2].Cells[6].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[2].Cells[4].Value.ToString()) - Common.ConvertToDecimal(dataGridView1.Rows[2].Cells[3].Value.ToString()), 0);
            dataGridView1.Rows[3].Cells[6].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[3].Cells[4].Value.ToString()) - Common.ConvertToDecimal(dataGridView1.Rows[3].Cells[3].Value.ToString()), 0);
            dataGridView1.Rows[4].Cells[6].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[4].Cells[4].Value.ToString()) - Common.ConvertToDecimal(dataGridView1.Rows[4].Cells[3].Value.ToString()), 0);
            dataGridView1.Rows[5].Cells[6].Value = Math.Round(Common.ConvertToDecimal(dataGridView1.Rows[5].Cells[4].Value.ToString()) - Common.ConvertToDecimal(dataGridView1.Rows[5].Cells[3].Value.ToString()), 0);

            //for total
            dataGridView1.Rows[5].Cells[2].Value = Common.GetSum(row, 0, 4, 2);
            dataGridView1.Rows[5].Cells[3].Value = Common.GetSum(row, 0, 4, 3);
            dataGridView1.Rows[5].Cells[4].Value = Common.GetSum(row, 0, 4, 4);
            dataGridView1.Rows[5].Cells[5].Value = Common.GetSum(row, 0, 4, 5);
            dataGridView1.Rows[5].Cells[6].Value = Common.GetSum(row, 0, 4, 6);

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotal();
        }
    }
}
