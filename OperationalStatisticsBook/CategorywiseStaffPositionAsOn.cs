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
    public partial class CategorywiseStaffPositionAsOn : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);

        public CategorywiseStaffPositionAsOn(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Depot],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11] FROM [rpt].[tbl_CategorywiseStaffPositionAsOn] where OsbId=@OsbId", con);
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
                    dataGridView1.DataSource = BindCategorywiseStaffPositionAsOn();
                }
                NonEditableRowAndColumn();
                CalcalculateTotal();

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

        DataTable BindCategorywiseStaffPositionAsOn()
        {
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[13] {
                            new DataColumn("S.No", typeof(string)),
                            new DataColumn("DEPOT", typeof(string)),
                            new DataColumn("Param1", typeof(string)),
                            new DataColumn("Param2", typeof(string)),
                            new DataColumn("Param3", typeof(string)),
                            new DataColumn("Param4", typeof(string)),
                            new DataColumn("Param5", typeof(string)),
                            new DataColumn("Param6", typeof(string)),
                            new DataColumn("Param7", typeof(string)),
                            new DataColumn("Param8", typeof(string)),
                            new DataColumn("Param9", typeof(string)),
                            new DataColumn("Param10", typeof(string)),
                            new DataColumn("Param11",typeof(string))
 });


            //table.Columns.Add("S.No", typeof(string));
            //table.Columns.Add("DEPOT", typeof(string));
            //table.Columns.Add("DRIVER ", typeof(string));
            //table.Columns.Add("DRIVER  ", typeof(string));
            //table.Columns.Add("DRIVER   ", typeof(string));
            //table.Columns.Add("Conductors   ", typeof(string));
            //table.Columns.Add("Conductors  ", typeof(string));
            //table.Columns.Add("Conductors", typeof(string));
            //table.Columns.Add("Traffic", typeof(string));
            //table.Columns.Add(" Repair &", typeof(string));
            //table.Columns.Add(" Admin", typeof(string));
            //table.Columns.Add(" Consultant ", typeof(string));
            //table.Columns.Add(" Total ", typeof(string));

            //Rows////
            //  table.Rows.Add("S.No ", " DEPOT ", "DRIVER", "DRIVER", "DRIVER", "Conductors", "Conductors", "Conductors", "Traffic", "Repair &", "Admin ", "Consultant  ", " Total ");
            //  table.Rows.Add(" ", " ", "M.R.", "CONT.", "TOTAL", "M.R.", "CONT.", "TOTAL", "Supervisor", "Maintence", " ", " ", " ");
            //  table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13");
            table.Rows.Add("1", "Banda Bahadur Marg ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Rohini-I ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Rohini-II ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Rohini-III ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Rohini-IV ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "Wazir Pur ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "Subhash Place ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("8", "Grand Trank Karnal Road ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("9", "Bawana ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("10", "Nangloi  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("11", "Kanjhawla  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("12", "Narela ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("13", "Rohini sec. 37  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "North Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("14", "Kalka Ji", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("15", "Sri Niwas puri ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("16", "Ambedkar Nagar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("17", "Vasant Vihar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("18", "Tehkhand ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("19", "Sukhdev Vihar ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("20", "Sarojni Nagar ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "South Total ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("21 ", "Nand Nagri ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("22 ", "NOIDA ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("23 ", "East Vinod Nagar ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("24", "HasanPur ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("25", "Inderprastha ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("26", "Yamuna Vihar ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("27", "Gazi Pur ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("28", "Raj Ghat-I ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("29", "Raj Ghat-II ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "East Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("30", "Hari Nagar-I", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("31", "Hari Nagar-II ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("32", "Hari Nagar-III", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("33", "Kesho Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("34", "Naraina", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("35", "Shadi Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("36", "BAGDOLA", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("37", "Dwarka, Sector-2", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("38", "Maya Puri ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("39", "Dichaon Kalan ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("40", "Peera Garhi ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("41", "Ghuman Hera ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("42", "Mundhela kalan", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "West Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Sup. Checking North", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Sup. Checking East", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Sup. Checking West", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Sup. Checking South", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "R&I H.Qrs.", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("43", "Bawana Sec. 1 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("44", "Bawana Sec. 5 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("45", "Rani Khera 1  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("46", "Rani Khera 2  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("47", "Rani Khera 3 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("48", "Inderprastha ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("49", "Yamuna Vihar ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("50", "Khadkhadi  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("51", "Dwarka, Sector-22", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("52", "Rewla (Khanpur) ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("53", "Ghuman Hera -1 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("54", "Ghuman Hera -2 ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "FCMS Total.", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Grand Total.", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");


            return table;
        }
        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_CategorywiseStaffPositionAsOn", OsbId);
            dataGridView1.DataSource = BindCategorywiseStaffPositionAsOn();
            NonEditableRowAndColumn();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_CategorywiseStaffPositionAsOn", OsbId);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null || row.Cells[11].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_CategorywiseStaffPositionAsOn] ([OsbId],[S_No],[Depot],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11]) VALUES (@OsbId,@S_No,@Depot,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@S_No", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Depot", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param6", row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param7", row.Cells[8].Value == null ? "" : row.Cells[8].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param8", row.Cells[9].Value == null ? "" : row.Cells[9].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param9", row.Cells[10].Value == null ? "" : row.Cells[10].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param10", row.Cells[11].Value == null ? "" : row.Cells[11].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param11", row.Cells[12].Value == null ? "" : row.Cells[12].Value.ToString());
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
        private void button1_Click(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_CategorywiseStaffPositionAsOn", OsbId);
            dataGridView1.DataSource = BindCategorywiseStaffPositionAsOn();
           // NonEditableRowAndColumn();
            MessageBox.Show("Done");
        }
        private void CategorywiseStaffPositionAsOn_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
            //dataGridView1.DataSource = BindCategorywiseStaffPositionAsOn();
        }

        void CalcalculateTotal()
        {
            var row = dataGridView1.Rows;

            #region Calculating_VerticalSum

            // North Total
            dataGridView1.Rows[13].Cells[2].Value = Common.GetSum(row, 0, 12, 2);
            dataGridView1.Rows[13].Cells[3].Value = Common.GetSum(row, 0, 12, 3);
            dataGridView1.Rows[13].Cells[4].Value = Common.GetSum(row, 0, 12, 4);
            dataGridView1.Rows[13].Cells[5].Value = Common.GetSum(row, 0, 12, 5);
            dataGridView1.Rows[13].Cells[6].Value = Common.GetSum(row, 0, 12, 6);
            dataGridView1.Rows[13].Cells[7].Value = Common.GetSum(row, 0, 12, 7);
            dataGridView1.Rows[13].Cells[8].Value = Common.GetSum(row, 0, 12, 8);
            dataGridView1.Rows[13].Cells[9].Value = Common.GetSum(row, 0, 12, 9);
            dataGridView1.Rows[13].Cells[10].Value = Common.GetSum(row, 0, 12, 10);
            dataGridView1.Rows[13].Cells[11].Value = Common.GetSum(row, 0, 12, 11);
            dataGridView1.Rows[13].Cells[12].Value = Common.GetSum(row, 0, 12, 12);

            // South Total

            dataGridView1.Rows[21].Cells[2].Value = Common.GetSum(row, 14, 20, 2);
            dataGridView1.Rows[21].Cells[3].Value = Common.GetSum(row, 14, 20, 3);
            dataGridView1.Rows[21].Cells[4].Value = Common.GetSum(row, 14, 20, 4);
            dataGridView1.Rows[21].Cells[5].Value = Common.GetSum(row, 14, 20, 5);
            dataGridView1.Rows[21].Cells[6].Value = Common.GetSum(row, 14, 20, 6);
            dataGridView1.Rows[21].Cells[7].Value = Common.GetSum(row, 14, 20, 7);
            dataGridView1.Rows[21].Cells[8].Value = Common.GetSum(row, 14, 20, 8);
            dataGridView1.Rows[21].Cells[9].Value = Common.GetSum(row, 14, 20, 9);
            dataGridView1.Rows[21].Cells[10].Value = Common.GetSum(row, 14, 20, 10);
            dataGridView1.Rows[21].Cells[11].Value = Common.GetSum(row, 14, 20, 11);
            dataGridView1.Rows[21].Cells[12].Value = Common.GetSum(row, 14, 20, 12);

            // East Total
            dataGridView1.Rows[31].Cells[2].Value = Common.GetSum(row, 22, 30, 2);
            dataGridView1.Rows[31].Cells[3].Value = Common.GetSum(row, 22, 30, 3);
            dataGridView1.Rows[31].Cells[4].Value = Common.GetSum(row, 22, 30, 4);
            dataGridView1.Rows[31].Cells[5].Value = Common.GetSum(row, 22, 30, 5);
            dataGridView1.Rows[31].Cells[6].Value = Common.GetSum(row, 22, 30, 6);
            dataGridView1.Rows[31].Cells[7].Value = Common.GetSum(row, 22, 30, 7);
            dataGridView1.Rows[31].Cells[8].Value = Common.GetSum(row, 22, 30, 8);
            dataGridView1.Rows[31].Cells[9].Value = Common.GetSum(row, 22, 30, 9);
            dataGridView1.Rows[31].Cells[10].Value = Common.GetSum(row, 22, 30, 10);
            dataGridView1.Rows[31].Cells[11].Value = Common.GetSum(row, 22, 30, 11);
            dataGridView1.Rows[31].Cells[12].Value = Common.GetSum(row, 22, 30, 12);

            //  West Total

            dataGridView1.Rows[45].Cells[2].Value = Common.GetSum(row, 32, 44, 2);
            dataGridView1.Rows[45].Cells[3].Value = Common.GetSum(row, 32, 44, 3);
            dataGridView1.Rows[45].Cells[4].Value = Common.GetSum(row, 32, 44, 4);
            dataGridView1.Rows[45].Cells[5].Value = Common.GetSum(row, 32, 44, 5);
            dataGridView1.Rows[45].Cells[6].Value = Common.GetSum(row, 32, 44, 6);
            dataGridView1.Rows[45].Cells[7].Value = Common.GetSum(row, 32, 44, 7);
            dataGridView1.Rows[45].Cells[8].Value = Common.GetSum(row, 32, 44, 8);
            dataGridView1.Rows[45].Cells[9].Value = Common.GetSum(row, 32, 44, 9);
            dataGridView1.Rows[45].Cells[10].Value = Common.GetSum(row, 32, 44, 10);
            dataGridView1.Rows[45].Cells[11].Value = Common.GetSum(row, 32, 44, 11);
            dataGridView1.Rows[45].Cells[12].Value = Common.GetSum(row, 32, 44, 12);


            // Grand Total

            //dataGridView1.Rows[64].Cells[2].Value = Common.GetSum(row, 50, 54, 2);
            //dataGridView1.Rows[64].Cells[3].Value = Common.GetSum(row, 50, 54, 3);
            //dataGridView1.Rows[64].Cells[4].Value = Common.GetSum(row, 50, 54, 4);
            //dataGridView1.Rows[64].Cells[5].Value = Common.GetSum(row, 50, 54, 5);
            //dataGridView1.Rows[64].Cells[6].Value = Common.GetSum(row, 50, 54, 6);
            //dataGridView1.Rows[64].Cells[7].Value = Common.GetSum(row, 50, 54, 7);
            //dataGridView1.Rows[64].Cells[8].Value = Common.GetSum(row, 50, 54, 8);
            //dataGridView1.Rows[64].Cells[9].Value = Common.GetSum(row, 50, 54, 9);
            //dataGridView1.Rows[64].Cells[10].Value = Common.GetSum(row,50, 54, 10);
            //dataGridView1.Rows[64].Cells[11].Value = Common.GetSum(row,50, 54, 11);
            //dataGridView1.Rows[64].Cells[12].Value = Common.GetSum(row,50, 54, 12);


            dataGridView1.Rows[63].Cells[2].Value = Common.GetSum(row, 51, 62, 2);
            dataGridView1.Rows[63].Cells[3].Value = Common.GetSum(row, 51, 62, 3);
            dataGridView1.Rows[63].Cells[4].Value = Common.GetSum(row, 51, 62, 4);
            dataGridView1.Rows[63].Cells[5].Value = Common.GetSum(row, 51, 62, 5);
            dataGridView1.Rows[63].Cells[6].Value = Common.GetSum(row, 51, 62, 6);
            dataGridView1.Rows[63].Cells[7].Value = Common.GetSum(row, 51, 62, 7);
            dataGridView1.Rows[63].Cells[8].Value = Common.GetSum(row, 51, 62, 8);
            dataGridView1.Rows[63].Cells[9].Value = Common.GetSum(row, 51, 62, 9);
            dataGridView1.Rows[63].Cells[10].Value = Common.GetSum(row, 51, 62, 10);
            dataGridView1.Rows[63].Cells[11].Value = Common.GetSum(row, 51, 62, 11);
            dataGridView1.Rows[63].Cells[12].Value = Common.GetSum(row, 51, 62, 12);


           // All Grand Total
            dataGridView1.Rows[64].Cells[2].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[21].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[45].Cells[2].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[63].Cells[2].Value.ToString()) + Common.GetSum(row, 46, 50, 2);
            dataGridView1.Rows[64].Cells[3].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[21].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[45].Cells[3].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[63].Cells[3].Value.ToString()) + Common.GetSum(row, 46, 50, 3);
            dataGridView1.Rows[64].Cells[4].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[21].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[45].Cells[4].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[63].Cells[4].Value.ToString()) + Common.GetSum(row, 46, 50, 4);
            dataGridView1.Rows[64].Cells[5].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[21].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[45].Cells[5].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[63].Cells[5].Value.ToString()) + Common.GetSum(row, 46, 50, 5);
            dataGridView1.Rows[64].Cells[6].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[6].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[21].Cells[6].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[6].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[45].Cells[6].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[63].Cells[6].Value.ToString()) + Common.GetSum(row, 46, 50, 6);
            dataGridView1.Rows[64].Cells[7].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[7].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[21].Cells[7].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[7].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[45].Cells[7].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[63].Cells[7].Value.ToString()) + Common.GetSum(row, 46, 50, 7);
            dataGridView1.Rows[64].Cells[8].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[8].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[21].Cells[8].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[8].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[45].Cells[8].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[63].Cells[8].Value.ToString()) + Common.GetSum(row, 46, 50, 8);
            dataGridView1.Rows[64].Cells[9].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[9].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[21].Cells[9].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[9].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[45].Cells[9].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[63].Cells[9].Value.ToString()) + Common.GetSum(row, 46, 50, 9);
            dataGridView1.Rows[64].Cells[10].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[10].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[21].Cells[10].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[10].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[45].Cells[10].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[63].Cells[10].Value.ToString()) + Common.GetSum(row, 46, 50, 10);
            dataGridView1.Rows[64].Cells[11].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[11].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[21].Cells[11].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[11].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[45].Cells[11].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[63].Cells[11].Value.ToString()) + Common.GetSum(row, 46, 50, 11);
            dataGridView1.Rows[64].Cells[12].Value = Common.ConvertToDecimal(dataGridView1.Rows[13].Cells[12].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[21].Cells[12].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[31].Cells[12].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[45].Cells[12].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[63].Cells[12].Value.ToString()) + Common.GetSum(row, 46, 50, 12);


            #endregion

            #region Calculating_HorizontalSum
            for (int i = 0; i < (row.Count - 1); i++)
            {

                if (i >= 0)
                {
                    dataGridView1.Rows[i].Cells[4].Value = Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[3].Value.ToString());
                    dataGridView1.Rows[i].Cells[7].Value = Common.ConvertToDecimal(row[i].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[6].Value.ToString());
                    dataGridView1.Rows[i].Cells[12].Value =  Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[8].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[9].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[11].Value.ToString());
                }
            }
            #endregion

        }

        private void Print_ReportOnClick(object sender, EventArgs e)
        {
            rptCategorywiseStaffPositionAsOn objFrm = new rptCategorywiseStaffPositionAsOn(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcalculateTotal();
        }
        public void NonEditableRowAndColumn()
        {
            Common.SetRowNonEditable(dataGridView1, 13);
            Common.SetRowNonEditable(dataGridView1, 21);
            Common.SetRowNonEditable(dataGridView1, 31);
            Common.SetRowNonEditable(dataGridView1, 45);
            Common.SetRowNonEditable(dataGridView1, 63);
            Common.SetRowNonEditable(dataGridView1, 64);

            Common.SetColumnNonEditable(dataGridView1,4);
            Common.SetColumnNonEditable(dataGridView1,7);
            Common.SetColumnNonEditable(dataGridView1,12);
        }
    }
}


