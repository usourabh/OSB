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
    public partial class SalientFeatureGrowthBasicStructure : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);

        public SalientFeatureGrowthBasicStructure(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [Year],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12] FROM [rpt].[tbl_SalientFeatureGrowthBasicStructure] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);


                DataTable autoSpTable = new DataTable();
                SqlCommand cmd1 = new SqlCommand("[dbo].[SalientFeatGrowthBasicStrucOSB1_2]", con);
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
                    dataGridView1.DataSource = BindSalientFeatureGrowthBasicStuructureAuto_Sp(autoSpTable);
                }


                else
                {
                    dataGridView1.DataSource = BindSalientFeatureGrowthBasicSturucture();
                }
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

        DataTable BindSalientFeatureGrowthBasicSturucture()
        {


            DataTable table = new DataTable();

            //column name
            table.Columns.Add("Year", typeof(string));
            table.Columns.Add("No of Depots", typeof(string));
            table.Columns.Add(" ", typeof(string));
            table.Columns.Add("Man Power", typeof(string));
            table.Columns.Add("  ", typeof(string));
            table.Columns.Add("Staff Ratio", typeof(string));
            table.Columns.Add("   ", typeof(string));
            table.Columns.Add("Added (Vehicle)", typeof(string));
            table.Columns.Add("    ", typeof(string));
            table.Columns.Add("Deleted (Vehicle)", typeof(string));
            table.Columns.Add("     ", typeof(string));
            table.Columns.Add("Fleet at the end", typeof(string));
            table.Columns.Add("      ", typeof(string));




            //Rows Static Data
            DateTime currentDate = new DateTime(Year, Month, 01);

            //DateTime newDate = currentDate.AddYears(0);
            //DateTime newDateM = currentDate.AddMonths(+1);
            //DateTime newDate2 = currentDate.AddYears(1);
            //DateTime currentMonth = currentDate.AddMonths(-6);

            DateTime newDateCurrent = currentDate.AddYears(0);
            DateTime newDateCurrent1 = currentDate.AddYears(-1);
            string currentYear = newDateCurrent1.Year.ToString();
            string previousYear = newDateCurrent.Year.ToString();

            DateTime newDateCurrent2 = currentDate.AddYears(-2);
            string previousYear1 = newDateCurrent2.Year.ToString();
            // int j = 1;
            //for (int i = 10; i > 0; i--)
            //{
            //    table.Rows.Add(newDate.AddYears(-i).Year + "-" + newDate2.AddYears(-i).Year, 0, " ", 0, " ", 0, " ", 0, " ", 0, " ", 0, " ");
            //}

            table.Rows.Add("2012-13", "46", "", "38103", "", "7.00", "", "0", "", "446", "", "5445", "");
            table.Rows.Add("2013-14", "45", "", "35503", "", "6.80", "", "0", "", "222", "", "5223", "");
            table.Rows.Add("2014-15", "43", "", "32864", "", "6.97", "", "0", "", "511", "", "4712", "");
            table.Rows.Add("2015-16", "43", "", "30527", "", "7.01", "", "1", "", "361", "", "4352", "");
            table.Rows.Add("2016-17", "39", "", "27879", "", "6.92", "", "0", "", "325", "", "4027", "");
            table.Rows.Add("2017-18", "39", "", "25489", "", "6.45", "", "0", "", "76", "", "3951", "");
            table.Rows.Add("2018-19", "39", "", "24721", "", "6.42", "", "0", "", "102", "", "3849", "");
            table.Rows.Add("2019-20", "35", "", "28163", "", "7.49", "", "0", "", "80", "", "3762", "");
            table.Rows.Add("2020-21", "35", "", "29369", "", "7.81", "", "0", "", "2", "", "3760", "");
            table.Rows.Add("2021-22", "36", "", "30675", "", "8.15", "", "2", "", "0", "", "3762", "");

            table.Rows.Add(" ", "No of Depots", "No of Depots", "Man Power", "Man Power", "Staff Ratio", "Staff Ratio", "Added (Vehicle)", "Added (Vehicle)", "Deleted (Vehicle)", "Deleted (Vehicle)", "Fleet at the end", "Fleet at the end");

            table.Rows.Add("Year", previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear);

            for (int i = currentDate.Month; i <= 12; i++)
            {
                table.Rows.Add(Common.monthNames[i - 1], 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            }

            //for (int i = 6; i > 0; i--)
            //{
            //    table.Rows.Add(currentMonth.AddMonths(-i).ToString("MMMM"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            //}

            table.Rows.Add(" ", "No of Depots", "No of Depots", "Man Power", "Man Power", "Staff Ratio", "Staff Ratio", "Added (Vehicle)", "Added (Vehicle)", "Deleted (Vehicle)", "Deleted (Vehicle)", "Fleet at the end", "Fleet at the end");
            table.Rows.Add("Year", currentYear, previousYear, currentYear, previousYear, currentYear, previousYear, currentYear, previousYear, currentYear, previousYear, currentYear, previousYear);

            for (int i = 1; i <= currentDate.Month; i++)
            {
                table.Rows.Add(Common.monthNames[i - 1], 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            }

            return table;
        }

        DataTable BindSalientFeatureGrowthBasicStuructureAuto_Sp(DataTable sp)
        {


            DataTable table = new DataTable();

            //column name
            table.Columns.Add("Year", typeof(string));
            table.Columns.Add("No of Depots", typeof(string));
            table.Columns.Add(" ", typeof(string));
            table.Columns.Add("Man Power", typeof(string));
            table.Columns.Add("  ", typeof(string));
            table.Columns.Add("Staff Ratio", typeof(string));
            table.Columns.Add("   ", typeof(string));
            table.Columns.Add("Added (Vehicle)", typeof(string));
            table.Columns.Add("    ", typeof(string));
            table.Columns.Add("Deleted (Vehicle)", typeof(string));
            table.Columns.Add("     ", typeof(string));
            table.Columns.Add("Fleet at the end", typeof(string));
            table.Columns.Add("      ", typeof(string));




            //Rows Static Data
            DateTime currentDate = new DateTime(Year, Month, 01);

            //DateTime newDate = currentDate.AddYears(0);
            //DateTime newDateM = currentDate.AddMonths(+1);
            //DateTime newDate2 = currentDate.AddYears(1);
            //DateTime currentMonth = currentDate.AddMonths(-6);

            DateTime newDateCurrent = currentDate.AddYears(0);
            DateTime newDateCurrent1 = currentDate.AddYears(-1);
            string currentYear = newDateCurrent1.Year.ToString();
            string previousYear = newDateCurrent.Year.ToString();

            DateTime newDateCurrent2 = currentDate.AddYears(-2);
            string previousYear1 = newDateCurrent2.Year.ToString();


            table.Rows.Add("2012-13", "46", "", "38103", "", "7.00", "", "0", "", "446", "", "5445", "");
            table.Rows.Add("2013-14", "45", "", "35503", "", "6.80", "", "0", "", "222", "", "5223", "");
            table.Rows.Add("2014-15", "43", "", "32864", "", "6.97", "", "0", "", "511", "", "4712", "");
            table.Rows.Add("2015-16", "43", "", "30527", "", "7.01", "", "1", "", "361", "", "4352", "");
            table.Rows.Add("2016-17", "39", "", "27879", "", "6.92", "", "0", "", "325", "", "4027", "");
            table.Rows.Add("2017-18", "39", "", "25489", "", "6.45", "", "0", "", "76", "", "3951", "");
            table.Rows.Add("2018-19", "39", "", "24721", "", "6.42", "", "0", "", "102", "", "3849", "");
            table.Rows.Add("2019-20", "35", "", "28163", "", "7.49", "", "0", "", "80", "", "3762", "");
            table.Rows.Add("2020-21", "35", "", "29369", "", "7.81", "", "0", "", "2", "", "3760", "");
            table.Rows.Add("2021-22", "36", "", "30675", "", "8.15", "", "2", "", "0", "", "3762", "");

            table.Rows.Add(" ", "No of Depots", "No of Depots", "Man Power", "Man Power", "Staff Ratio", "Staff Ratio", "Added (Vehicle)", "Added (Vehicle)", "Deleted (Vehicle)", "Deleted (Vehicle)", "Fleet at the end", "Fleet at the end");

            table.Rows.Add("Year", previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear);


            if (currentDate.Month <= 12) table.Rows.Add(Common.monthNames[currentDate.Month - 1], 0, sp.Rows[11]["NoOfDepotsYearMinus1"].ToString(), 0, sp.Rows[11]["ManPowerYearMinus1"].ToString(), 0, sp.Rows[11]["StaffRatioCurrentYearMinus1"].ToString(), 0, sp.Rows[11]["AddedVehicleYearMinus1"].ToString(), 0, 0, 0, sp.Rows[11]["TotalFleetYearMinus1"].ToString());
            if (currentDate.Month <= 11) table.Rows.Add(Common.monthNames[currentDate.Month], 0, sp.Rows[10]["NoOfDepotsYearMinus1"].ToString(), 0, sp.Rows[10]["ManPowerYearMinus1"].ToString(), 0, sp.Rows[10]["StaffRatioCurrentYearMinus1"].ToString(), 0, sp.Rows[10]["AddedVehicleYearMinus1"].ToString(), 0, 0, 0, sp.Rows[10]["TotalFleetYearMinus1"].ToString());
            if (currentDate.Month <= 10) table.Rows.Add(Common.monthNames[currentDate.Month + 1], 0, sp.Rows[9]["NoOfDepotsYearMinus1"].ToString(), 0, sp.Rows[9]["ManPowerYearMinus1"].ToString(), 0, sp.Rows[9]["StaffRatioCurrentYearMinus1"].ToString(), 0, sp.Rows[9]["AddedVehicleYearMinus1"].ToString(), 0, 0, 0, sp.Rows[9]["TotalFleetYearMinus1"].ToString());
            if (currentDate.Month <= 9) table.Rows.Add(Common.monthNames[currentDate.Month + 2], 0, sp.Rows[8]["NoOfDepotsYearMinus1"].ToString(), 0, sp.Rows[8]["ManPowerYearMinus1"].ToString(), 0, sp.Rows[8]["StaffRatioCurrentYearMinus1"].ToString(), 0, sp.Rows[8]["AddedVehicleYearMinus1"].ToString(), 0, 0, 0, sp.Rows[8]["TotalFleetYearMinus1"].ToString());
            if (currentDate.Month <= 8) table.Rows.Add(Common.monthNames[currentDate.Month + 3], 0, sp.Rows[7]["NoOfDepotsYearMinus1"].ToString(), 0, sp.Rows[7]["ManPowerYearMinus1"].ToString(), 0, sp.Rows[7]["StaffRatioCurrentYearMinus1"].ToString(), 0, sp.Rows[7]["AddedVehicleYearMinus1"].ToString(), 0, 0, 0, sp.Rows[7]["TotalFleetYearMinus1"].ToString());
            if (currentDate.Month <= 7) table.Rows.Add(Common.monthNames[currentDate.Month + 4], 0, sp.Rows[6]["NoOfDepotsYearMinus1"].ToString(), 0, sp.Rows[6]["ManPowerYearMinus1"].ToString(), 0, sp.Rows[6]["StaffRatioCurrentYearMinus1"].ToString(), 0, sp.Rows[6]["AddedVehicleYearMinus1"].ToString(), 0, 0, 0, sp.Rows[6]["TotalFleetYearMinus1"].ToString());
            if (currentDate.Month <= 6) table.Rows.Add(Common.monthNames[currentDate.Month + 5], 0, sp.Rows[5]["NoOfDepotsYearMinus1"].ToString(), 0, sp.Rows[5]["ManPowerYearMinus1"].ToString(), 0, sp.Rows[5]["StaffRatioCurrentYearMinus1"].ToString(), 0, sp.Rows[5]["AddedVehicleYearMinus1"].ToString(), 0, 0, 0, sp.Rows[5]["TotalFleetYearMinus1"].ToString());
            if (currentDate.Month <= 5) table.Rows.Add(Common.monthNames[currentDate.Month + 6], 0, sp.Rows[4]["NoOfDepotsYearMinus1"].ToString(), 0, sp.Rows[4]["ManPowerYearMinus1"].ToString(), 0, sp.Rows[4]["StaffRatioCurrentYearMinus1"].ToString(), 0, sp.Rows[4]["AddedVehicleYearMinus1"].ToString(), 0, 0, 0, sp.Rows[4]["TotalFleetYearMinus1"].ToString());
            if (currentDate.Month <= 4) table.Rows.Add(Common.monthNames[currentDate.Month + 7], 0, sp.Rows[3]["NoOfDepotsYearMinus1"].ToString(), 0, sp.Rows[3]["ManPowerYearMinus1"].ToString(), 0, sp.Rows[3]["StaffRatioCurrentYearMinus1"].ToString(), 0, sp.Rows[3]["AddedVehicleYearMinus1"].ToString(), 0, 0, 0, sp.Rows[3]["TotalFleetYearMinus1"].ToString());
            if (currentDate.Month <= 3) table.Rows.Add(Common.monthNames[currentDate.Month + 8], 0, sp.Rows[2]["NoOfDepotsYearMinus1"].ToString(), 0, sp.Rows[2]["ManPowerYearMinus1"].ToString(), 0, sp.Rows[2]["StaffRatioCurrentYearMinus1"].ToString(), 0, sp.Rows[2]["AddedVehicleYearMinus1"].ToString(), 0, 0, 0, sp.Rows[2]["TotalFleetYearMinus1"].ToString());
            if (currentDate.Month <= 2) table.Rows.Add(Common.monthNames[currentDate.Month + 9], 0, sp.Rows[1]["NoOfDepotsYearMinus1"].ToString(), 0, sp.Rows[1]["ManPowerYearMinus1"].ToString(), 0, sp.Rows[1]["StaffRatioCurrentYearMinus1"].ToString(), 0, sp.Rows[1]["AddedVehicleYearMinus1"].ToString(), 0, 0, 0, sp.Rows[1]["TotalFleetYearMinus1"].ToString());
            if (currentDate.Month <= 1) table.Rows.Add(Common.monthNames[currentDate.Month + 10], 0, sp.Rows[0]["NoOfDepotsYearMinus1"].ToString(), 0, sp.Rows[0]["ManPowerYearMinus1"].ToString(), 0, sp.Rows[0]["StaffRatioCurrentYearMinus1"].ToString(), 0, sp.Rows[0]["AddedVehicleYearMinus1"].ToString(), 0, 0, 0, sp.Rows[0]["TotalFleetYearMinus1"].ToString());


            //for (int i = currentDate.Month; i <= 12; i++)
            //{
            //    table.Rows.Add(Common.monthNames[i - 1], "35", "35", Convert.ToString(27700+118), 0, 0, 0, 0, 0, 0, 0, 0, 0);
            //}

            table.Rows.Add(" ", "No of Depots", "No of Depots", "Man Power", "Man Power", "Staff Ratio", "Staff Ratio", "Added (Vehicle)", "Added (Vehicle)", "Deleted (Vehicle)", "Deleted (Vehicle)", "Fleet at the end", "Fleet at the end");
            table.Rows.Add("Year", currentYear, previousYear, currentYear, previousYear, currentYear, previousYear, currentYear, previousYear, currentYear, previousYear, currentYear, previousYear);

            //for (int i = 1; i <= currentDate.Month; i++)
            //{
            //    table.Rows.Add(Common.monthNames[i - 1], 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            //}


            switch (currentDate.Month)
            {

                case 1:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[0]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[0]["ManPowerYearMinus1"].ToString(), sp.Rows[0]["ManPowerCurrentYear"].ToString(), sp.Rows[0]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[0]["StaffRatioCurrentYear"].ToString(), sp.Rows[0]["AddedVehicleYearMinus1"].ToString(), sp.Rows[0]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[0]["TotalFleetYearMinus1"].ToString(), sp.Rows[0]["TotalFleetCurrentYear"].ToString());
                    break;
                case 2:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[0]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[0]["ManPowerYearMinus1"].ToString(), sp.Rows[0]["ManPowerCurrentYear"].ToString(), sp.Rows[0]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[0]["StaffRatioCurrentYear"].ToString(), sp.Rows[0]["AddedVehicleYearMinus1"].ToString(), sp.Rows[0]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[0]["TotalFleetYearMinus1"].ToString(), sp.Rows[0]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[1]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[1]["ManPowerYearMinus1"].ToString(), sp.Rows[1]["ManPowerCurrentYear"].ToString(), sp.Rows[1]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[1]["StaffRatioCurrentYear"].ToString(), sp.Rows[1]["AddedVehicleYearMinus1"].ToString(), sp.Rows[1]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[1]["TotalFleetYearMinus1"].ToString(), sp.Rows[1]["TotalFleetCurrentYear"].ToString());

                    break;
                case 3:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[0]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[0]["ManPowerYearMinus1"].ToString(), sp.Rows[0]["ManPowerCurrentYear"].ToString(), sp.Rows[0]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[0]["StaffRatioCurrentYear"].ToString(), sp.Rows[0]["AddedVehicleYearMinus1"].ToString(), sp.Rows[0]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[0]["TotalFleetYearMinus1"].ToString(), sp.Rows[0]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[1]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[1]["ManPowerYearMinus1"].ToString(), sp.Rows[1]["ManPowerCurrentYear"].ToString(), sp.Rows[1]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[1]["StaffRatioCurrentYear"].ToString(), sp.Rows[1]["AddedVehicleYearMinus1"].ToString(), sp.Rows[1]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[1]["TotalFleetYearMinus1"].ToString(), sp.Rows[1]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[2]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[2]["ManPowerYearMinus1"].ToString(), sp.Rows[2]["ManPowerCurrentYear"].ToString(), sp.Rows[2]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[2]["StaffRatioCurrentYear"].ToString(), sp.Rows[2]["AddedVehicleYearMinus1"].ToString(), sp.Rows[2]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[2]["TotalFleetYearMinus1"].ToString(), sp.Rows[2]["TotalFleetCurrentYear"].ToString());

                    break;
                case 4:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[0]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[0]["ManPowerYearMinus1"].ToString(), sp.Rows[0]["ManPowerCurrentYear"].ToString(), sp.Rows[0]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[0]["StaffRatioCurrentYear"].ToString(), sp.Rows[0]["AddedVehicleYearMinus1"].ToString(), sp.Rows[0]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[0]["TotalFleetYearMinus1"].ToString(), sp.Rows[0]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[1]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[1]["ManPowerYearMinus1"].ToString(), sp.Rows[1]["ManPowerCurrentYear"].ToString(), sp.Rows[1]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[1]["StaffRatioCurrentYear"].ToString(), sp.Rows[1]["AddedVehicleYearMinus1"].ToString(), sp.Rows[1]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[1]["TotalFleetYearMinus1"].ToString(), sp.Rows[1]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[2]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[2]["ManPowerYearMinus1"].ToString(), sp.Rows[2]["ManPowerCurrentYear"].ToString(), sp.Rows[2]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[2]["StaffRatioCurrentYear"].ToString(), sp.Rows[2]["AddedVehicleYearMinus1"].ToString(), sp.Rows[2]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[2]["TotalFleetYearMinus1"].ToString(), sp.Rows[2]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[3], sp.Rows[3]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[3]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[3]["ManPowerYearMinus1"].ToString(), sp.Rows[3]["ManPowerCurrentYear"].ToString(), sp.Rows[3]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[3]["StaffRatioCurrentYear"].ToString(), sp.Rows[3]["AddedVehicleYearMinus1"].ToString(), sp.Rows[3]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[3]["TotalFleetYearMinus1"].ToString(), sp.Rows[3]["TotalFleetCurrentYear"].ToString());

                    break;
                case 5:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[0]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[0]["ManPowerYearMinus1"].ToString(), sp.Rows[0]["ManPowerCurrentYear"].ToString(), sp.Rows[0]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[0]["StaffRatioCurrentYear"].ToString(), sp.Rows[0]["AddedVehicleYearMinus1"].ToString(), sp.Rows[0]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[0]["TotalFleetYearMinus1"].ToString(), sp.Rows[0]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[1]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[1]["ManPowerYearMinus1"].ToString(), sp.Rows[1]["ManPowerCurrentYear"].ToString(), sp.Rows[1]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[1]["StaffRatioCurrentYear"].ToString(), sp.Rows[1]["AddedVehicleYearMinus1"].ToString(), sp.Rows[1]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[1]["TotalFleetYearMinus1"].ToString(), sp.Rows[1]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[2]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[2]["ManPowerYearMinus1"].ToString(), sp.Rows[2]["ManPowerCurrentYear"].ToString(), sp.Rows[2]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[2]["StaffRatioCurrentYear"].ToString(), sp.Rows[2]["AddedVehicleYearMinus1"].ToString(), sp.Rows[2]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[2]["TotalFleetYearMinus1"].ToString(), sp.Rows[2]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[3], sp.Rows[3]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[3]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[3]["ManPowerYearMinus1"].ToString(), sp.Rows[3]["ManPowerCurrentYear"].ToString(), sp.Rows[3]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[3]["StaffRatioCurrentYear"].ToString(), sp.Rows[3]["AddedVehicleYearMinus1"].ToString(), sp.Rows[3]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[3]["TotalFleetYearMinus1"].ToString(), sp.Rows[3]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[4], sp.Rows[4]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[4]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[4]["ManPowerYearMinus1"].ToString(), sp.Rows[4]["ManPowerCurrentYear"].ToString(), sp.Rows[4]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[4]["StaffRatioCurrentYear"].ToString(), sp.Rows[4]["AddedVehicleYearMinus1"].ToString(), sp.Rows[4]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[4]["TotalFleetYearMinus1"].ToString(), sp.Rows[4]["TotalFleetCurrentYear"].ToString());

                    break;
                case 6:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[0]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[0]["ManPowerYearMinus1"].ToString(), sp.Rows[0]["ManPowerCurrentYear"].ToString(), sp.Rows[0]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[0]["StaffRatioCurrentYear"].ToString(), sp.Rows[0]["AddedVehicleYearMinus1"].ToString(), sp.Rows[0]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[0]["TotalFleetYearMinus1"].ToString(), sp.Rows[0]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[1]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[1]["ManPowerYearMinus1"].ToString(), sp.Rows[1]["ManPowerCurrentYear"].ToString(), sp.Rows[1]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[1]["StaffRatioCurrentYear"].ToString(), sp.Rows[1]["AddedVehicleYearMinus1"].ToString(), sp.Rows[1]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[1]["TotalFleetYearMinus1"].ToString(), sp.Rows[1]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[2]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[2]["ManPowerYearMinus1"].ToString(), sp.Rows[2]["ManPowerCurrentYear"].ToString(), sp.Rows[2]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[2]["StaffRatioCurrentYear"].ToString(), sp.Rows[2]["AddedVehicleYearMinus1"].ToString(), sp.Rows[2]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[2]["TotalFleetYearMinus1"].ToString(), sp.Rows[2]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[3], sp.Rows[3]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[3]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[3]["ManPowerYearMinus1"].ToString(), sp.Rows[3]["ManPowerCurrentYear"].ToString(), sp.Rows[3]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[3]["StaffRatioCurrentYear"].ToString(), sp.Rows[3]["AddedVehicleYearMinus1"].ToString(), sp.Rows[3]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[3]["TotalFleetYearMinus1"].ToString(), sp.Rows[3]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[4], sp.Rows[4]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[4]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[4]["ManPowerYearMinus1"].ToString(), sp.Rows[4]["ManPowerCurrentYear"].ToString(), sp.Rows[4]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[4]["StaffRatioCurrentYear"].ToString(), sp.Rows[4]["AddedVehicleYearMinus1"].ToString(), sp.Rows[4]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[4]["TotalFleetYearMinus1"].ToString(), sp.Rows[4]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[5], sp.Rows[5]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[5]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[5]["ManPowerYearMinus1"].ToString(), sp.Rows[5]["ManPowerCurrentYear"].ToString(), sp.Rows[5]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[5]["StaffRatioCurrentYear"].ToString(), sp.Rows[5]["AddedVehicleYearMinus1"].ToString(), sp.Rows[5]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[5]["TotalFleetYearMinus1"].ToString(), sp.Rows[5]["TotalFleetCurrentYear"].ToString());

                    break;
                case 7:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[0]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[0]["ManPowerYearMinus1"].ToString(), sp.Rows[0]["ManPowerCurrentYear"].ToString(), sp.Rows[0]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[0]["StaffRatioCurrentYear"].ToString(), sp.Rows[0]["AddedVehicleYearMinus1"].ToString(), sp.Rows[0]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[0]["TotalFleetYearMinus1"].ToString(), sp.Rows[0]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[1]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[1]["ManPowerYearMinus1"].ToString(), sp.Rows[1]["ManPowerCurrentYear"].ToString(), sp.Rows[1]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[1]["StaffRatioCurrentYear"].ToString(), sp.Rows[1]["AddedVehicleYearMinus1"].ToString(), sp.Rows[1]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[1]["TotalFleetYearMinus1"].ToString(), sp.Rows[1]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[2]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[2]["ManPowerYearMinus1"].ToString(), sp.Rows[2]["ManPowerCurrentYear"].ToString(), sp.Rows[2]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[2]["StaffRatioCurrentYear"].ToString(), sp.Rows[2]["AddedVehicleYearMinus1"].ToString(), sp.Rows[2]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[2]["TotalFleetYearMinus1"].ToString(), sp.Rows[2]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[3], sp.Rows[3]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[3]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[3]["ManPowerYearMinus1"].ToString(), sp.Rows[3]["ManPowerCurrentYear"].ToString(), sp.Rows[3]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[3]["StaffRatioCurrentYear"].ToString(), sp.Rows[3]["AddedVehicleYearMinus1"].ToString(), sp.Rows[3]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[3]["TotalFleetYearMinus1"].ToString(), sp.Rows[3]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[4], sp.Rows[4]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[4]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[4]["ManPowerYearMinus1"].ToString(), sp.Rows[4]["ManPowerCurrentYear"].ToString(), sp.Rows[4]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[4]["StaffRatioCurrentYear"].ToString(), sp.Rows[4]["AddedVehicleYearMinus1"].ToString(), sp.Rows[4]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[4]["TotalFleetYearMinus1"].ToString(), sp.Rows[4]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[5], sp.Rows[5]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[5]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[5]["ManPowerYearMinus1"].ToString(), sp.Rows[5]["ManPowerCurrentYear"].ToString(), sp.Rows[5]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[5]["StaffRatioCurrentYear"].ToString(), sp.Rows[5]["AddedVehicleYearMinus1"].ToString(), sp.Rows[5]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[5]["TotalFleetYearMinus1"].ToString(), sp.Rows[5]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[6], sp.Rows[6]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[6]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[6]["ManPowerYearMinus1"].ToString(), sp.Rows[6]["ManPowerCurrentYear"].ToString(), sp.Rows[6]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[6]["StaffRatioCurrentYear"].ToString(), sp.Rows[6]["AddedVehicleYearMinus1"].ToString(), sp.Rows[6]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[6]["TotalFleetYearMinus1"].ToString(), sp.Rows[6]["TotalFleetCurrentYear"].ToString());

                    break;
                case 8:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[0]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[0]["ManPowerYearMinus1"].ToString(), sp.Rows[0]["ManPowerCurrentYear"].ToString(), sp.Rows[0]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[0]["StaffRatioCurrentYear"].ToString(), sp.Rows[0]["AddedVehicleYearMinus1"].ToString(), sp.Rows[0]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[0]["TotalFleetYearMinus1"].ToString(), sp.Rows[0]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[1]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[1]["ManPowerYearMinus1"].ToString(), sp.Rows[1]["ManPowerCurrentYear"].ToString(), sp.Rows[1]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[1]["StaffRatioCurrentYear"].ToString(), sp.Rows[1]["AddedVehicleYearMinus1"].ToString(), sp.Rows[1]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[1]["TotalFleetYearMinus1"].ToString(), sp.Rows[1]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[2]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[2]["ManPowerYearMinus1"].ToString(), sp.Rows[2]["ManPowerCurrentYear"].ToString(), sp.Rows[2]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[2]["StaffRatioCurrentYear"].ToString(), sp.Rows[2]["AddedVehicleYearMinus1"].ToString(), sp.Rows[2]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[2]["TotalFleetYearMinus1"].ToString(), sp.Rows[2]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[3], sp.Rows[3]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[3]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[3]["ManPowerYearMinus1"].ToString(), sp.Rows[3]["ManPowerCurrentYear"].ToString(), sp.Rows[3]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[3]["StaffRatioCurrentYear"].ToString(), sp.Rows[3]["AddedVehicleYearMinus1"].ToString(), sp.Rows[3]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[3]["TotalFleetYearMinus1"].ToString(), sp.Rows[3]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[4], sp.Rows[4]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[4]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[4]["ManPowerYearMinus1"].ToString(), sp.Rows[4]["ManPowerCurrentYear"].ToString(), sp.Rows[4]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[4]["StaffRatioCurrentYear"].ToString(), sp.Rows[4]["AddedVehicleYearMinus1"].ToString(), sp.Rows[4]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[4]["TotalFleetYearMinus1"].ToString(), sp.Rows[4]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[5], sp.Rows[5]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[5]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[5]["ManPowerYearMinus1"].ToString(), sp.Rows[5]["ManPowerCurrentYear"].ToString(), sp.Rows[5]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[5]["StaffRatioCurrentYear"].ToString(), sp.Rows[5]["AddedVehicleYearMinus1"].ToString(), sp.Rows[5]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[5]["TotalFleetYearMinus1"].ToString(), sp.Rows[5]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[6], sp.Rows[6]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[6]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[6]["ManPowerYearMinus1"].ToString(), sp.Rows[6]["ManPowerCurrentYear"].ToString(), sp.Rows[6]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[6]["StaffRatioCurrentYear"].ToString(), sp.Rows[6]["AddedVehicleYearMinus1"].ToString(), sp.Rows[6]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[6]["TotalFleetYearMinus1"].ToString(), sp.Rows[6]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[7], sp.Rows[7]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[7]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[7]["ManPowerYearMinus1"].ToString(), sp.Rows[7]["ManPowerCurrentYear"].ToString(), sp.Rows[7]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[7]["StaffRatioCurrentYear"].ToString(), sp.Rows[7]["AddedVehicleYearMinus1"].ToString(), sp.Rows[7]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[7]["TotalFleetYearMinus1"].ToString(), sp.Rows[7]["TotalFleetCurrentYear"].ToString());

                    break;
                case 9:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[0]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[0]["ManPowerYearMinus1"].ToString(), sp.Rows[0]["ManPowerCurrentYear"].ToString(), sp.Rows[0]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[0]["StaffRatioCurrentYear"].ToString(), sp.Rows[0]["AddedVehicleYearMinus1"].ToString(), sp.Rows[0]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[0]["TotalFleetYearMinus1"].ToString(), sp.Rows[0]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[1]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[1]["ManPowerYearMinus1"].ToString(), sp.Rows[1]["ManPowerCurrentYear"].ToString(), sp.Rows[1]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[1]["StaffRatioCurrentYear"].ToString(), sp.Rows[1]["AddedVehicleYearMinus1"].ToString(), sp.Rows[1]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[1]["TotalFleetYearMinus1"].ToString(), sp.Rows[1]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[2]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[2]["ManPowerYearMinus1"].ToString(), sp.Rows[2]["ManPowerCurrentYear"].ToString(), sp.Rows[2]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[2]["StaffRatioCurrentYear"].ToString(), sp.Rows[2]["AddedVehicleYearMinus1"].ToString(), sp.Rows[2]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[2]["TotalFleetYearMinus1"].ToString(), sp.Rows[2]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[3], sp.Rows[3]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[3]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[3]["ManPowerYearMinus1"].ToString(), sp.Rows[3]["ManPowerCurrentYear"].ToString(), sp.Rows[3]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[3]["StaffRatioCurrentYear"].ToString(), sp.Rows[3]["AddedVehicleYearMinus1"].ToString(), sp.Rows[3]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[3]["TotalFleetYearMinus1"].ToString(), sp.Rows[3]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[4], sp.Rows[4]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[4]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[4]["ManPowerYearMinus1"].ToString(), sp.Rows[4]["ManPowerCurrentYear"].ToString(), sp.Rows[4]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[4]["StaffRatioCurrentYear"].ToString(), sp.Rows[4]["AddedVehicleYearMinus1"].ToString(), sp.Rows[4]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[4]["TotalFleetYearMinus1"].ToString(), sp.Rows[4]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[5], sp.Rows[5]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[5]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[5]["ManPowerYearMinus1"].ToString(), sp.Rows[5]["ManPowerCurrentYear"].ToString(), sp.Rows[5]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[5]["StaffRatioCurrentYear"].ToString(), sp.Rows[5]["AddedVehicleYearMinus1"].ToString(), sp.Rows[5]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[5]["TotalFleetYearMinus1"].ToString(), sp.Rows[5]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[6], sp.Rows[6]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[6]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[6]["ManPowerYearMinus1"].ToString(), sp.Rows[6]["ManPowerCurrentYear"].ToString(), sp.Rows[6]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[6]["StaffRatioCurrentYear"].ToString(), sp.Rows[6]["AddedVehicleYearMinus1"].ToString(), sp.Rows[6]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[6]["TotalFleetYearMinus1"].ToString(), sp.Rows[6]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[7], sp.Rows[7]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[7]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[7]["ManPowerYearMinus1"].ToString(), sp.Rows[7]["ManPowerCurrentYear"].ToString(), sp.Rows[7]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[7]["StaffRatioCurrentYear"].ToString(), sp.Rows[7]["AddedVehicleYearMinus1"].ToString(), sp.Rows[7]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[7]["TotalFleetYearMinus1"].ToString(), sp.Rows[7]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[8], sp.Rows[8]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[8]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[8]["ManPowerYearMinus1"].ToString(), sp.Rows[8]["ManPowerCurrentYear"].ToString(), sp.Rows[8]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[8]["StaffRatioCurrentYear"].ToString(), sp.Rows[8]["AddedVehicleYearMinus1"].ToString(), sp.Rows[8]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[8]["TotalFleetYearMinus1"].ToString(), sp.Rows[8]["TotalFleetCurrentYear"].ToString());

                    break;
                case 10:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[0]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[0]["ManPowerYearMinus1"].ToString(), sp.Rows[0]["ManPowerCurrentYear"].ToString(), sp.Rows[0]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[0]["StaffRatioCurrentYear"].ToString(), sp.Rows[0]["AddedVehicleYearMinus1"].ToString(), sp.Rows[0]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[0]["TotalFleetYearMinus1"].ToString(), sp.Rows[0]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[1]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[1]["ManPowerYearMinus1"].ToString(), sp.Rows[1]["ManPowerCurrentYear"].ToString(), sp.Rows[1]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[1]["StaffRatioCurrentYear"].ToString(), sp.Rows[1]["AddedVehicleYearMinus1"].ToString(), sp.Rows[1]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[1]["TotalFleetYearMinus1"].ToString(), sp.Rows[1]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[2]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[2]["ManPowerYearMinus1"].ToString(), sp.Rows[2]["ManPowerCurrentYear"].ToString(), sp.Rows[2]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[2]["StaffRatioCurrentYear"].ToString(), sp.Rows[2]["AddedVehicleYearMinus1"].ToString(), sp.Rows[2]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[2]["TotalFleetYearMinus1"].ToString(), sp.Rows[2]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[3], sp.Rows[3]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[3]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[3]["ManPowerYearMinus1"].ToString(), sp.Rows[3]["ManPowerCurrentYear"].ToString(), sp.Rows[3]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[3]["StaffRatioCurrentYear"].ToString(), sp.Rows[3]["AddedVehicleYearMinus1"].ToString(), sp.Rows[3]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[3]["TotalFleetYearMinus1"].ToString(), sp.Rows[3]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[4], sp.Rows[4]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[4]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[4]["ManPowerYearMinus1"].ToString(), sp.Rows[4]["ManPowerCurrentYear"].ToString(), sp.Rows[4]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[4]["StaffRatioCurrentYear"].ToString(), sp.Rows[4]["AddedVehicleYearMinus1"].ToString(), sp.Rows[4]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[4]["TotalFleetYearMinus1"].ToString(), sp.Rows[4]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[5], sp.Rows[5]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[5]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[5]["ManPowerYearMinus1"].ToString(), sp.Rows[5]["ManPowerCurrentYear"].ToString(), sp.Rows[5]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[5]["StaffRatioCurrentYear"].ToString(), sp.Rows[5]["AddedVehicleYearMinus1"].ToString(), sp.Rows[5]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[5]["TotalFleetYearMinus1"].ToString(), sp.Rows[5]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[6], sp.Rows[6]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[6]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[6]["ManPowerYearMinus1"].ToString(), sp.Rows[6]["ManPowerCurrentYear"].ToString(), sp.Rows[6]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[6]["StaffRatioCurrentYear"].ToString(), sp.Rows[6]["AddedVehicleYearMinus1"].ToString(), sp.Rows[6]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[6]["TotalFleetYearMinus1"].ToString(), sp.Rows[6]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[7], sp.Rows[7]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[7]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[7]["ManPowerYearMinus1"].ToString(), sp.Rows[7]["ManPowerCurrentYear"].ToString(), sp.Rows[7]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[7]["StaffRatioCurrentYear"].ToString(), sp.Rows[7]["AddedVehicleYearMinus1"].ToString(), sp.Rows[7]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[7]["TotalFleetYearMinus1"].ToString(), sp.Rows[7]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[8], sp.Rows[8]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[8]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[8]["ManPowerYearMinus1"].ToString(), sp.Rows[8]["ManPowerCurrentYear"].ToString(), sp.Rows[8]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[8]["StaffRatioCurrentYear"].ToString(), sp.Rows[8]["AddedVehicleYearMinus1"].ToString(), sp.Rows[8]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[8]["TotalFleetYearMinus1"].ToString(), sp.Rows[8]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[9], sp.Rows[9]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[9]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[9]["ManPowerYearMinus1"].ToString(), sp.Rows[9]["ManPowerCurrentYear"].ToString(), sp.Rows[9]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[9]["StaffRatioCurrentYear"].ToString(), sp.Rows[9]["AddedVehicleYearMinus1"].ToString(), sp.Rows[9]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[9]["TotalFleetYearMinus1"].ToString(), sp.Rows[9]["TotalFleetCurrentYear"].ToString());

                    break;
                case 11:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[0]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[0]["ManPowerYearMinus1"].ToString(), sp.Rows[0]["ManPowerCurrentYear"].ToString(), sp.Rows[0]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[0]["StaffRatioCurrentYear"].ToString(), sp.Rows[0]["AddedVehicleYearMinus1"].ToString(), sp.Rows[0]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[0]["TotalFleetYearMinus1"].ToString(), sp.Rows[0]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[1]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[1]["ManPowerYearMinus1"].ToString(), sp.Rows[1]["ManPowerCurrentYear"].ToString(), sp.Rows[1]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[1]["StaffRatioCurrentYear"].ToString(), sp.Rows[1]["AddedVehicleYearMinus1"].ToString(), sp.Rows[1]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[1]["TotalFleetYearMinus1"].ToString(), sp.Rows[1]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[2]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[2]["ManPowerYearMinus1"].ToString(), sp.Rows[2]["ManPowerCurrentYear"].ToString(), sp.Rows[2]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[2]["StaffRatioCurrentYear"].ToString(), sp.Rows[2]["AddedVehicleYearMinus1"].ToString(), sp.Rows[2]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[2]["TotalFleetYearMinus1"].ToString(), sp.Rows[2]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[3], sp.Rows[3]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[3]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[3]["ManPowerYearMinus1"].ToString(), sp.Rows[3]["ManPowerCurrentYear"].ToString(), sp.Rows[3]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[3]["StaffRatioCurrentYear"].ToString(), sp.Rows[3]["AddedVehicleYearMinus1"].ToString(), sp.Rows[3]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[3]["TotalFleetYearMinus1"].ToString(), sp.Rows[3]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[4], sp.Rows[4]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[4]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[4]["ManPowerYearMinus1"].ToString(), sp.Rows[4]["ManPowerCurrentYear"].ToString(), sp.Rows[4]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[4]["StaffRatioCurrentYear"].ToString(), sp.Rows[4]["AddedVehicleYearMinus1"].ToString(), sp.Rows[4]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[4]["TotalFleetYearMinus1"].ToString(), sp.Rows[4]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[5], sp.Rows[5]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[5]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[5]["ManPowerYearMinus1"].ToString(), sp.Rows[5]["ManPowerCurrentYear"].ToString(), sp.Rows[5]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[5]["StaffRatioCurrentYear"].ToString(), sp.Rows[5]["AddedVehicleYearMinus1"].ToString(), sp.Rows[5]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[5]["TotalFleetYearMinus1"].ToString(), sp.Rows[5]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[6], sp.Rows[6]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[6]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[6]["ManPowerYearMinus1"].ToString(), sp.Rows[6]["ManPowerCurrentYear"].ToString(), sp.Rows[6]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[6]["StaffRatioCurrentYear"].ToString(), sp.Rows[6]["AddedVehicleYearMinus1"].ToString(), sp.Rows[6]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[6]["TotalFleetYearMinus1"].ToString(), sp.Rows[6]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[7], sp.Rows[7]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[7]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[7]["ManPowerYearMinus1"].ToString(), sp.Rows[7]["ManPowerCurrentYear"].ToString(), sp.Rows[7]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[7]["StaffRatioCurrentYear"].ToString(), sp.Rows[7]["AddedVehicleYearMinus1"].ToString(), sp.Rows[7]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[7]["TotalFleetYearMinus1"].ToString(), sp.Rows[7]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[8], sp.Rows[8]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[8]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[8]["ManPowerYearMinus1"].ToString(), sp.Rows[8]["ManPowerCurrentYear"].ToString(), sp.Rows[8]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[8]["StaffRatioCurrentYear"].ToString(), sp.Rows[8]["AddedVehicleYearMinus1"].ToString(), sp.Rows[8]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[8]["TotalFleetYearMinus1"].ToString(), sp.Rows[8]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[9], sp.Rows[9]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[9]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[9]["ManPowerYearMinus1"].ToString(), sp.Rows[9]["ManPowerCurrentYear"].ToString(), sp.Rows[9]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[9]["StaffRatioCurrentYear"].ToString(), sp.Rows[9]["AddedVehicleYearMinus1"].ToString(), sp.Rows[9]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[9]["TotalFleetYearMinus1"].ToString(), sp.Rows[9]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[10], sp.Rows[10]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[10]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[10]["ManPowerYearMinus1"].ToString(), sp.Rows[10]["ManPowerCurrentYear"].ToString(), sp.Rows[10]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[10]["StaffRatioCurrentYear"].ToString(), sp.Rows[10]["AddedVehicleYearMinus1"].ToString(), sp.Rows[10]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[10]["TotalFleetYearMinus1"].ToString(), sp.Rows[10]["TotalFleetCurrentYear"].ToString());

                    break;
                case 12:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[0]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[0]["ManPowerYearMinus1"].ToString(), sp.Rows[0]["ManPowerCurrentYear"].ToString(), sp.Rows[0]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[0]["StaffRatioCurrentYear"].ToString(), sp.Rows[0]["AddedVehicleYearMinus1"].ToString(), sp.Rows[0]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[0]["TotalFleetYearMinus1"].ToString(), sp.Rows[0]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[1]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[1]["ManPowerYearMinus1"].ToString(), sp.Rows[1]["ManPowerCurrentYear"].ToString(), sp.Rows[1]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[1]["StaffRatioCurrentYear"].ToString(), sp.Rows[1]["AddedVehicleYearMinus1"].ToString(), sp.Rows[1]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[1]["TotalFleetYearMinus1"].ToString(), sp.Rows[1]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[2]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[2]["ManPowerYearMinus1"].ToString(), sp.Rows[2]["ManPowerCurrentYear"].ToString(), sp.Rows[2]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[2]["StaffRatioCurrentYear"].ToString(), sp.Rows[2]["AddedVehicleYearMinus1"].ToString(), sp.Rows[2]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[2]["TotalFleetYearMinus1"].ToString(), sp.Rows[2]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[3], sp.Rows[3]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[3]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[3]["ManPowerYearMinus1"].ToString(), sp.Rows[3]["ManPowerCurrentYear"].ToString(), sp.Rows[3]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[3]["StaffRatioCurrentYear"].ToString(), sp.Rows[3]["AddedVehicleYearMinus1"].ToString(), sp.Rows[3]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[3]["TotalFleetYearMinus1"].ToString(), sp.Rows[3]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[4], sp.Rows[4]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[4]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[4]["ManPowerYearMinus1"].ToString(), sp.Rows[4]["ManPowerCurrentYear"].ToString(), sp.Rows[4]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[4]["StaffRatioCurrentYear"].ToString(), sp.Rows[4]["AddedVehicleYearMinus1"].ToString(), sp.Rows[4]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[4]["TotalFleetYearMinus1"].ToString(), sp.Rows[4]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[5], sp.Rows[5]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[5]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[5]["ManPowerYearMinus1"].ToString(), sp.Rows[5]["ManPowerCurrentYear"].ToString(), sp.Rows[5]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[5]["StaffRatioCurrentYear"].ToString(), sp.Rows[5]["AddedVehicleYearMinus1"].ToString(), sp.Rows[5]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[5]["TotalFleetYearMinus1"].ToString(), sp.Rows[5]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[6], sp.Rows[6]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[6]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[6]["ManPowerYearMinus1"].ToString(), sp.Rows[6]["ManPowerCurrentYear"].ToString(), sp.Rows[6]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[6]["StaffRatioCurrentYear"].ToString(), sp.Rows[6]["AddedVehicleYearMinus1"].ToString(), sp.Rows[6]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[6]["TotalFleetYearMinus1"].ToString(), sp.Rows[6]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[7], sp.Rows[7]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[7]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[7]["ManPowerYearMinus1"].ToString(), sp.Rows[7]["ManPowerCurrentYear"].ToString(), sp.Rows[7]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[7]["StaffRatioCurrentYear"].ToString(), sp.Rows[7]["AddedVehicleYearMinus1"].ToString(), sp.Rows[7]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[7]["TotalFleetYearMinus1"].ToString(), sp.Rows[7]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[8], sp.Rows[8]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[8]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[8]["ManPowerYearMinus1"].ToString(), sp.Rows[8]["ManPowerCurrentYear"].ToString(), sp.Rows[8]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[8]["StaffRatioCurrentYear"].ToString(), sp.Rows[8]["AddedVehicleYearMinus1"].ToString(), sp.Rows[8]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[8]["TotalFleetYearMinus1"].ToString(), sp.Rows[8]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[9], sp.Rows[9]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[9]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[9]["ManPowerYearMinus1"].ToString(), sp.Rows[9]["ManPowerCurrentYear"].ToString(), sp.Rows[9]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[9]["StaffRatioCurrentYear"].ToString(), sp.Rows[9]["AddedVehicleYearMinus1"].ToString(), sp.Rows[9]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[9]["TotalFleetYearMinus1"].ToString(), sp.Rows[9]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[10], sp.Rows[10]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[10]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[10]["ManPowerYearMinus1"].ToString(), sp.Rows[10]["ManPowerCurrentYear"].ToString(), sp.Rows[10]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[10]["StaffRatioCurrentYear"].ToString(), sp.Rows[10]["AddedVehicleYearMinus1"].ToString(), sp.Rows[10]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[10]["TotalFleetYearMinus1"].ToString(), sp.Rows[10]["TotalFleetCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[11], sp.Rows[11]["NoOfDepotsYearMinus1"].ToString(), sp.Rows[11]["NoOfDepotsYearCurrentYear"].ToString(), sp.Rows[11]["ManPowerYearMinus1"].ToString(), sp.Rows[11]["ManPowerCurrentYear"].ToString(), sp.Rows[11]["StaffRatioCurrentYearMinus1"].ToString(), sp.Rows[11]["StaffRatioCurrentYear"].ToString(), sp.Rows[11]["AddedVehicleYearMinus1"].ToString(), sp.Rows[11]["AddedVehicleCurrentYear"].ToString(), 0, 0, sp.Rows[11]["TotalFleetYearMinus1"].ToString(), sp.Rows[11]["TotalFleetCurrentYear"].ToString());
                    break;

            }

            return table;
        }

        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingdtRecord("tbl_SalientFeatureGrowthBasicStructure", OsbId);
            dataGridView1.DataSource = BindSalientFeatureGrowthBasicSturucture();
            MessageBox.Show("Done");
        }

        private void SalientFeatureGrowthBasicStructure_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BindSalientFeatureGrowthBasicSturucture();
            BindIndexPage(OsbId);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            DeleteExisitingdtRecord("tbl_SalientFeatureGrowthBasicStructure", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null || row.Cells[11].Value != null || row.Cells[12].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_SalientFeatureGrowthBasicStructure] ([OsbId],[Year],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12]) VALUES (@OsbId,@Year,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11,@Param12)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@Year", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param1", row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param2", row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param3", row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param4", row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param5", row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param6", row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param7", row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param8", row.Cells[8].Value == null ? "" : row.Cells[8].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param9", row.Cells[9].Value == null ? "" : row.Cells[9].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param10", row.Cells[10].Value == null ? "" : row.Cells[10].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param11", row.Cells[11].Value == null ? "" : row.Cells[11].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param12", row.Cells[12].Value == null ? "" : row.Cells[12].Value.ToString());
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

        private void Print_ReportOnCluck(object sender, EventArgs e)
        {
            rptSalientFeatureGrowthBasicStructure objFrm = new rptSalientFeatureGrowthBasicStructure(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }
    }
}

