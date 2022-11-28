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
    public partial class analysisOfCausesAccidents : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);

        public analysisOfCausesAccidents(int OsbId, int Year, int Month, string finYear, string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;
        }


        DataTable BindAnalysisOfCausesAccidents()
        {
            DataTable table = new DataTable();
            table.Columns.Add("S.No.", typeof(string));
            table.Columns.Add("Particular", typeof(string));
            table.Columns.Add("Absolute", typeof(int));
            table.Columns.Add("%age", typeof(int));
            table.Columns.Add("Absolute ", typeof(int));
            table.Columns.Add("%age ", typeof(int));

            // Row Static data
           // table.Rows.Add("1", "2", "3", "3", "4", "4");
            table.Rows.Add("1", "Rash & Negligance", 0 , 0 , 0, 0);
            table.Rows.Add("a", "D.T.C", 0, 0, 0, 0);
            table.Rows.Add("b", "Other", 0, 0, 0, 0);
            table.Rows.Add("2", "Error of Judgement", 0, 0, 0, 0);
            table.Rows.Add("a", "D.T.C", 0, 0, 0, 0);
            table.Rows.Add("b", "Other", 0, 0, 0, 0);
            table.Rows.Add("3", "Mechanical", 0, 0, 0, 0);
            table.Rows.Add("a", "D.T.C", 0, 0, 0, 0);
            table.Rows.Add("b", "Other", 0, 0, 0, 0);
            table.Rows.Add("4", "Lack of Road Sense", 0, 0, 0, 0);
            table.Rows.Add("5", "Alighting Passengers", 0, 0, 0, 0);
            table.Rows.Add("6", "Boarding Passengers", 0, 0, 0, 0);
            table.Rows.Add("7", "MISC", 0, 0, 0, 0);
            table.Rows.Add("", "Total", 0, 0, 0, 0);
           // table.Rows.Add("", "Total", 0, 0, 0, 0);



            dataGridView1.DataSource = table;
            return table;
        }


        private void Reset_OnClick(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BindAnalysisOfCausesAccidents();
            //DeleteExisitingTableRecord("tbl_analysisCausesAccidents", OsbId);
            MessageBox.Show("Done");
        }

        private void analysisOfCausesAccidents_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
        }


        void BindIndexPage(int OsbId)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT [SNO],[Particular],[Absolute],[Percentage],[Absolutes],[Percentages] FROM [rpt].[tbl_analysisCausesAccidents] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    SaveBtn.BackColor = Color.Green;
                }
                else
                {
                    dataGridView1.DataSource = BindAnalysisOfCausesAccidents();
                }
                Common.SetRowNonEditable(dataGridView1, 13);
                Common.SetColumnNonEditable(dataGridView1, 3);
                Common.SetColumnNonEditable(dataGridView1, 5);
                Calculate();
            }
            catch (Exception ex)
            {

            }

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_analysisCausesAccidents", OsbId);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null )
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_analysisCausesAccidents] ([OsbId],[SNO],[Particular],[Absolute],[Percentage],[Absolutes],[Percentages]) VALUES (@OsbId,@SNO,@Particular,@Absolute,@Percentage,@Absolutes,@Percentages)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@SNO", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Particular", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Absolute", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Percentage", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Absolutes", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Percentages", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
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

        private void PrintReportOnClick(object sender, EventArgs e)
        {

            rptanalysisOfCausesAccidents objFrm = new rptanalysisOfCausesAccidents(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }


        void Calculate()
        {
            var row = dataGridView1.Rows;
            // Total
            dataGridView1.Rows[13].Cells[2].Value = Common.GetSum(row, 1, 12, 2);
            dataGridView1.Rows[13].Cells[3].Value = Common.GetSum(row, 1, 12, 3);
            dataGridView1.Rows[13].Cells[4].Value = Common.GetSum(row, 1, 12, 4);
            dataGridView1.Rows[13].Cells[5].Value = Common.GetSum(row, 1, 12, 5);

            // PERCENTAGE
            dataGridView1.Rows[1].Cells[3].Value = Common.ConvertToDecimal(row[13].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[1].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[2].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[2].Cells[3].Value = Common.ConvertToDecimal(row[13].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[2].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[2].Value.ToString())) * 100, 2) : 0;
                                                                                                                                                                                                                                                                  
            dataGridView1.Rows[4].Cells[3].Value = Common.ConvertToDecimal(row[13].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[2].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[5].Cells[3].Value = Common.ConvertToDecimal(row[13].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[5].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[2].Value.ToString())) * 100, 2) : 0;
                                                                                                                                                                                                                                                                  
            dataGridView1.Rows[7].Cells[3].Value = Common.ConvertToDecimal(row[13].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[7].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[2].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[8].Cells[3].Value = Common.ConvertToDecimal(row[13].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[8].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[2].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[9].Cells[3].Value = Common.ConvertToDecimal(row[13].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[2].Value.ToString())) * 100, 2) : 0;
           dataGridView1.Rows[10].Cells[3].Value = Common.ConvertToDecimal(row[13].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[10].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[2].Value.ToString())) * 100, 2) : 0;
           dataGridView1.Rows[11].Cells[3].Value = Common.ConvertToDecimal(row[13].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[11].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[2].Value.ToString())) * 100, 2) : 0;
           dataGridView1.Rows[12].Cells[3].Value = Common.ConvertToDecimal(row[13].Cells[2].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[12].Cells[2].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[2].Value.ToString())) * 100, 2) : 0;

            // Percentage-----------------------------------------------------------------------------------------------------------

            dataGridView1.Rows[1].Cells[5].Value =  Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[1].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[4].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[2].Cells[5].Value =  Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[2].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[4].Value.ToString())) * 100, 2) : 0;
                                                                                                                                                                                                                                                                
            dataGridView1.Rows[4].Cells[5].Value =  Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[4].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[4].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[5].Cells[5].Value =  Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[5].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[4].Value.ToString())) * 100, 2) : 0;
                                                                                                                                                                                                                                                              
            dataGridView1.Rows[7].Cells[5].Value =  Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[7].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[4].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[8].Cells[5].Value =  Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[8].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[4].Value.ToString())) * 100, 2) : 0;
            dataGridView1.Rows[9].Cells[5].Value =  Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[9].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[4].Value.ToString())) * 100, 2) : 0;
           dataGridView1.Rows[10].Cells[5].Value =  Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[10].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[4].Value.ToString())) * 100, 2) : 0;
           dataGridView1.Rows[11].Cells[5].Value =  Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[11].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[4].Value.ToString())) * 100, 2) : 0;
           dataGridView1.Rows[12].Cells[5].Value =  Common.ConvertToDecimal(row[13].Cells[4].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[12].Cells[4].Value.ToString()) / Common.ConvertToDecimal(row[13].Cells[4].Value.ToString())) * 100, 2) : 0;

           
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Calculate();
        }
    }
}
