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
    public partial class ComparativeAnalysisOfCausesOfAccidents : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public ComparativeAnalysisOfCausesOfAccidents(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] ,[Param5] FROM [rpt].[tbl_ComparativeAnalysisOfCausesOfAccidents] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                    dataGridView1.DataSource = dt;
                else
                    dataGridView1.DataSource = BindComparativeAnalysisOfCausesOfAccidents();
            }
            catch (Exception ex)
            {

            }

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


        DataTable BindComparativeAnalysisOfCausesOfAccidents()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("S_NO", typeof(string)),
                            new DataColumn("Param1", typeof(string)),
                            new DataColumn("Param2",typeof(string)),
                            new DataColumn("Param3",typeof(string)),
                            new DataColumn("Param4",typeof(string)),
                            new DataColumn("Param5",typeof(string))
            });

            DateTime currentDate = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate.AddYears(+1);
            string currentYear = currentDate.Year.ToString();
            string previousYear = newDate.Year.ToString();
            String previousMonthName = newDate.ToString("MMMM");
           
            // Rows
           
            dt.Rows.Add("S_No", "Particulars", previousMonthName + ' ' + previousYear, previousMonthName + "  " + previousYear, previousMonthName + ' ' + currentYear, previousMonthName + "  " + currentYear);
            dt.Rows.Add("", "", "Absolute", "%Age", "Absolute", "%Age");
            dt.Rows.Add("1", "2", "3", "4", "5", "6");
            dt.Rows.Add("1", "Rash & Negligence Driving", "", "", "", "");
            dt.Rows.Add("a", "D.T.C", "0", "0", "0", "0");
            dt.Rows.Add("b", "Other", "0", "0", "0", "0");
            dt.Rows.Add("2", "Error of Judgement", "", "", "", "");
            dt.Rows.Add("a", "D.T.C", "0", "0", "0", "0");
            dt.Rows.Add("b", "Other", "0", "0", "0", "0");
            dt.Rows.Add("3", "Mechanical Defect", "", "", "", "");
            dt.Rows.Add("a", "D.T.C", "0", "0", "0", "0");
            dt.Rows.Add("b", "Other", "0", "0", "0", "0");
            dt.Rows.Add("4", "Lack of road sense", "0", "0", "0", "0");
            dt.Rows.Add("5", "Aligthing Passengers", "", "", "", "");
            dt.Rows.Add("a", "Front Gate", "0", "0", "0", "0");
            dt.Rows.Add("b", "Rear Gate", "0", "0", "0", "0");
            dt.Rows.Add("6", "Boarding Passengers", "", "", "", "");
            dt.Rows.Add("a", "Front Gate", "0", "0", "0", "0");
            dt.Rows.Add("b", "Rear Gate", "0", "0", "0", "0");
            dt.Rows.Add("7", "Contributory / Miscellaneous", "0", "0", "0", "0");
            dt.Rows.Add("", "Total", "0", "0", "0", "0");

            return dt;
        }


        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingdtRecord("tbl_ComparativeAnalysisOfCausesOfAccidents", OsbId);
            dataGridView1.DataSource = BindComparativeAnalysisOfCausesOfAccidents();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingdtRecord("tbl_ComparativeAnalysisOfCausesOfAccidents", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_ComparativeAnalysisOfCausesOfAccidents] ([OsbId],[S_No],[Param1],[Param2],[Param3],[Param4],[Param5]) VALUES (@OsbId,@S_No,@Param1,@Param2,@Param3,@Param4,@Param5)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@S_No", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
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
       

        private void ComparativeAnalysisOfCausesOfAccidents_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
          
        }

        private void PrintReportOnClick(object sender, EventArgs e)
        {
            rptComparativeAnalysisOfCausesOfAccidents objFrm = new rptComparativeAnalysisOfCausesOfAccidents(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }
    }
}