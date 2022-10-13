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
    public partial class AnalysisOfAccidentsByDriverGroup : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public AnalysisOfAccidentsByDriverGroup(int OsbId, int Year, int Month, string finYear, string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;
        }

        DataTable BindAnalysisOfAccidentsByDriverGroup()
        {
            DataTable table = new DataTable();
            DateTime currentDate = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate.AddYears(-1);
            int currentYear = currentDate.Year;
            int previousYear = newDate.Year;
            String previousMonthName = newDate.ToString("MMMM");

            table.Columns.AddRange(new DataColumn[10] {
                            new DataColumn("S.No", typeof(string)),
                            new DataColumn("Param1", typeof(string)),
                            new DataColumn("Param2", typeof(string)),
                            new DataColumn("Param3", typeof(string)),
                            new DataColumn("Param4", typeof(string)),
                            new DataColumn("Param5", typeof(string)),
                            new DataColumn("Param6", typeof(string)),
                            new DataColumn("Param7", typeof(string)),
                            new DataColumn("Param8", typeof(string)),
                            new DataColumn("Param9", typeof(string))
                           


            });

            //table.Columns.Add("S.No", typeof(string));
            //table.Columns.Add("Age Group", typeof(string));
            //table.Columns.Add(previousMonthName+' '+currentYear, typeof(string));
            //table.Columns.Add(previousMonthName+"  "+currentYear, typeof(string));
            //table.Columns.Add(previousMonthName+"   "+currentYear, typeof(string));
            //table.Columns.Add(previousMonthName+"    "+currentYear, typeof(string));

            //table.Columns.Add(previousMonthName + " " + previousYear, typeof(string));
            //table.Columns.Add(previousMonthName +"  "+ previousYear, typeof(string));
            //table.Columns.Add(previousMonthName + "   " + previousYear, typeof(string));
            //table.Columns.Add(previousMonthName + "    " + previousYear, typeof(string));


            //Rows here.....
            table.Rows.Add("S.No", "Age Group", previousMonthName + ' ' + currentYear, previousMonthName + ' ' + currentYear, previousMonthName + ' ' + currentYear, previousMonthName + ' ' + currentYear, previousMonthName + ' ' + currentYear, previousMonthName + ' ' + currentYear, previousMonthName + ' ' + currentYear, previousMonthName + ' ' + currentYear);
            table.Rows.Add("", "", "Minor", "Major", "Fatal", "Total", "Minor", "Major", "Fatal", "Total");
            table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9", "10");
            table.Rows.Add("1", "20-25", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "26-30", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "31-35", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "36-40", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "41-45", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "46-50", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "51-55", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("8", "56-60", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total", "0", "0", "0", "0", "0", "0", "0", "0");

            return table;
        }
            private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_AnalysisOfAccidentsByDriverGroup", OsbId);
            dataGridView1.DataSource = BindAnalysisOfAccidentsByDriverGroup();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_AnalysisOfAccidentsByDriverGroup", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_AnalysisOfAccidentsByDriverGroup] ([OsbId],[S_No],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9]) VALUES (@OsbId,@S_No,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@S_No", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param6", row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param7", row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param8", row.Cells[8].Value == null ? "" : row.Cells[8].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param9", row.Cells[9].Value == null ? "" : row.Cells[9].Value.ToString());
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

        void BindIndexPage(int OsbId)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7],[Param8],[Param9] FROM [rpt].[tbl_AnalysisOfAccidentsByDriverGroup] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                    dataGridView1.DataSource = dt;
                else
                    dataGridView1.DataSource = BindAnalysisOfAccidentsByDriverGroup();
            }
            catch (Exception ex)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_AnalysisOfAccidentsByDriverGroup", OsbId);
            dataGridView1.DataSource = BindAnalysisOfAccidentsByDriverGroup();
            MessageBox.Show("Done");
        }

        private void AnalysisOfAccidentsByDriverGroup_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);  
            // dataGridView1.DataSource = BindAccidentAnalysisOtherPartyInvolvment();
        }

        private void Print_ReportOnClick(object sender, EventArgs e)
        {
            rptAnalysisOfAccidentsByDriverGroup objFrm = new rptAnalysisOfAccidentsByDriverGroup(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }
    }
}
