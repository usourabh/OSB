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
                dataGridView1.DataSource = BindStaffRatioAsOn();


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
          

            dt.Rows.Add("", "", "", "", "", "Authorised Fl.Strength (Col.5-3)", "@Actual Fl.Strength (Col.5-4)");
            dt.Rows.Add("1", "2", "3", "4", "5", "6","7");
            dt.Rows.Add("DR.", "", "", "", "", "","");
            dt.Rows.Add("COND.", "", "", "", "", "","");
            dt.Rows.Add("Tr.Sup.", "", "", "", "", "","");
            dt.Rows.Add("R & M.", "", "", "", "", "","");
            dt.Rows.Add("Admin.", "", "", "", "", "","");
            dt.Rows.Add("Total*", "", "", "", "", "","");
            dt.Rows.Add("", " ", " ", " ", " ", " "," ");
            dt.Rows.Add("*Included Short term/Contract Basis Staff", "", "Short term  S/ Guards", " ", "", "Short term Manager", "");
            dt.Rows.Add("*Included Short term/Contract Basis Staff", "", "Short term  Drivers", " ", "", " Part Time MO", "");
            dt.Rows.Add("*Included Short term/Contract Basis Staff", "", "Short term Conductors", "", "", "Consultant ", "");
            dt.Rows.Add("*Included Short term/Contract Basis Staff", "", "Short term Press", "", "", "", "");
            
           
           
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
    }
}
