﻿using System;
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
    public partial class DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization(int OsbId, int Year, int Month, string finYear, string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;
        }
        DataTable BindDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization()
        {


            DataTable table = new DataTable();

            table.Columns.Add("S_No", typeof(string));
            table.Columns.Add("Depot", typeof(string));
            table.Columns.Add("Fleet as on the last day of the month", typeof(string));
            table.Columns.Add("Fleet as on the last day of the  month ", typeof(string));
            table.Columns.Add("Fleet as  on the last day of the month", typeof(string));
            table.Columns.Add("Fleet as on the last day of the month ", typeof(string));
            table.Columns.Add("Fleet as on the last day of the month  ", typeof(string));

            table.Columns.Add("Avg. fleet during the month", typeof(string));
            table.Columns.Add("Avg. fleet during the month ", typeof(string));
            table.Columns.Add("Avg. fleet during the month  ", typeof(string));
            table.Columns.Add("Avg. fleet during the  month", typeof(string));
            table.Columns.Add("Avg. fleet during  the month", typeof(string));

            table.Columns.Add("Avg.no of buses scheduled", typeof(string));
            table.Columns.Add("Avg.no of buses scheduled ", typeof(string));
            table.Columns.Add("Avg.no of buses scheduled  ", typeof(string));
            table.Columns.Add("Avg.no of buses  scheduled", typeof(string));
            table.Columns.Add("Avg.no of buses   scheduled", typeof(string));

            table.Columns.Add("Avg.no.of buses on Road", typeof(string));
            table.Columns.Add("Avg.no.of buses on Road ", typeof(string));
            table.Columns.Add("Avg.no.of buses on  Road", typeof(string));
            table.Columns.Add("Avg.no.of buses  on Road  ", typeof(string));
            table.Columns.Add("Avg.no.of  buses on Road  ", typeof(string));

            table.Columns.Add("Percentage fleet utilisation ", typeof(string));
            table.Columns.Add("Percentage fleet utilisation", typeof(string));
            table.Columns.Add("Percentage fleet utilisation   ", typeof(string));
            table.Columns.Add("Percentage fleet  utilisation  ", typeof(string));
            table.Columns.Add("Percentage  fleet utilisation", typeof(string));


            //  table.Rows.Add("S.No ", "Name of the Depot", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total");
            //  table.Rows.Add(" ", "Name of the Depot", "NAC", "AC", "NAC", "AC", "Total", "NAC", "AC", "NAC", "AC", "Total", "NAC", "AC", "NAC", "AC", "Total", "NAC", "AC", "NAC", "AC", "Total", "NAC", "AC", "NAC", "AC", "Total");
            //   table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21","22", "23", "24", "25", "26", "27");

            table.Rows.Add("1", "BBM", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Rohini-I", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Rohini-II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Rohini-III", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Rohini-IV", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "Wazir Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "Subhash Place", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("8", "G.T.K. Rd.", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("9", "Nangloi", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("10", "Kanjhawla", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("11", "NARELA", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("12", "Kalka Ji", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("13", "Sri Niwas puri", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("14", "AND", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("15", "Vasant Vihar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("16", "Tehkhand", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("17", "Sukhdev Vihar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("18", "Sarojni Nagar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("19", "Nand Nagri", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("20", "NOIDA", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("21", "EVND  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("22", "HasanPur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("23", "Gazi Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("24", "Raj Ghat-I", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("25", "Hari Nagar-I ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("26", "Hari Nagar-II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("27", "Kesho Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("28", "Naraina", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("29", "Shadi Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("30", "BAGDOLA", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("31", "DW.SEC- 2", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("32", "Maya Puri", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("33", "Dichaon Kalan", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("34", "Peera Garhi", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Electric Buses", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

            table.Rows.Add("1", "Rohini sec. 37", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Raj Ghat-II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Mundhela kalan", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total Electric", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total DTC", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "International", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            table.Rows.Add("1", "Kathmandu", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Grand Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            return table;

        }

        DataTable BindDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillizationAuto_Sp_Table(DataTable sp)
        {

            DataTable table = new DataTable();

            table.Columns.Add("S_No", typeof(string));
            table.Columns.Add("Depot", typeof(string));
            table.Columns.Add("Fleet as on the last day of the month  CITY NAC", typeof(string));
            table.Columns.Add("Fleet as on the last day of the  month CITY AC ", typeof(string));
            table.Columns.Add("Fleet as  on the last day of the month NCR NAC ", typeof(string));
            table.Columns.Add("Fleet as on the last day of the month  NCR AC  ", typeof(string));
            table.Columns.Add("Fleet as on the last day of the month  TOTAL   ", typeof(string));

            table.Columns.Add("Avg. fleet during the month CITY NAC", typeof(string));
            table.Columns.Add("Avg. fleet during the month CITY AC", typeof(string));
            table.Columns.Add("Avg. fleet during the month NCR NAC", typeof(string));
            table.Columns.Add("Avg. fleet during the  month NCR AC", typeof(string));
            table.Columns.Add("Avg. fleet during  the month TOTAL", typeof(string));

            table.Columns.Add("Avg.no of buses scheduled CITY NAC", typeof(string));
            table.Columns.Add("Avg.no of buses scheduled CITY AC ", typeof(string));
            table.Columns.Add("Avg.no of buses scheduled NCR NAC ", typeof(string));
            table.Columns.Add("Avg.no of buses scheduled NCR AC  ", typeof(string));
            table.Columns.Add("Avg.no of buses scheduled TOTAL   ", typeof(string));

            table.Columns.Add("Avg.no.of buses on Road CITY NAC", typeof(string));
            table.Columns.Add("Avg.no.of buses on Road CITY AC ", typeof(string));
            table.Columns.Add("Avg.no.of buses on  Road NCR NAC  ", typeof(string));
            table.Columns.Add("Avg.no.of buses  on Road NCR AC    ", typeof(string));
            table.Columns.Add("Avg.no.of  buses on Road TOTAL     ", typeof(string));

            table.Columns.Add("Percentage fleet utilisation CITY NAC", typeof(string));
            table.Columns.Add("Percentage fleet utilisation CITY AC ", typeof(string));
            table.Columns.Add("Percentage fleet utilisation NCR NAC   ", typeof(string));
            table.Columns.Add("Percentage fleet  utilisation NCR AC    ", typeof(string));
            table.Columns.Add("Percentage  fleet utilisation TOTAL     ", typeof(string));


            for (int i = 0; i < sp.Rows.Count; i++)
            {
                if (!(Convert.ToInt32(sp.Rows[i]["CirleCode"]) == 36 || Convert.ToInt32(sp.Rows[i]["CirleCode"]) == 35 || Convert.ToInt32(sp.Rows[i]["CirleCode"]) == 37 || Convert.ToInt32(sp.Rows[i]["CirleCode"]) == 38 || Convert.ToInt32(sp.Rows[i]["CirleCode"]) == 40 || Convert.ToInt32(sp.Rows[i]["CirleCode"]) == 41 || Convert.ToInt32(sp.Rows[i]["CirleCode"]) == 23))
                {
                    decimal percentageFleetUtilizCityNac = Math.Round((Convert.ToDecimal(sp.Rows[i]["AvgFleetCityNac"]) != 0) ? (Convert.ToDecimal(sp.Rows[i]["AvgNoBusesOnRoadCityNac"]) / Convert.ToDecimal(sp.Rows[i]["AvgFleetCityNac"])) * 100 : 0, 2);
                    decimal percentageFleetUtilizCityAc = Math.Round((Convert.ToDecimal(sp.Rows[i]["AvgFleetCityAc"]) != 0) ? (Convert.ToDecimal(sp.Rows[i]["AvgNoBusesOnRoadCityAc"]) / Convert.ToDecimal(sp.Rows[i]["AvgFleetCityAc"])) * 100 : 0, 2);
                    decimal percentageFleetUtilizNcrNac = Math.Round((Convert.ToDecimal(sp.Rows[i]["AvgFleetNCRNac"]) != 0) ? (Convert.ToDecimal(sp.Rows[i]["AvgNoBusesOnRoadNCRNac"]) / Convert.ToDecimal(sp.Rows[i]["AvgFleetNCRNac"])) * 100 : 0, 2);
                    decimal percentageFleetUtilizNcrAc = Math.Round((Convert.ToDecimal(sp.Rows[i]["AvgFleetNacAc"]) != 0) ? (Convert.ToDecimal(sp.Rows[i]["AvgNoBusesOnRoadNCRAc"]) / Convert.ToDecimal(sp.Rows[i]["AvgFleetNacAc"])) * 100 : 0, 2);

                    table.Rows.Add(i + 1, sp.Rows[i]["CircleName"], sp.Rows[i]["FleetLastDayCityNac"], sp.Rows[i]["FleetLastDayCityAc"], sp.Rows[i]["FleetLastDayNCRNac"], sp.Rows[i]["FleetLastDayNCRAc"], "0", sp.Rows[i]["AvgFleetCityNac"], sp.Rows[i]["AvgFleetCityAc"], sp.Rows[i]["AvgFleetNCRNac"], sp.Rows[i]["AvgFleetNacAc"], "0", sp.Rows[i]["AvgNoBusesScheduleCityNac"], sp.Rows[i]["AvgNoBusesScheduleCityAc"], sp.Rows[i]["AvgNoBusesScheduleNCRNac"], sp.Rows[i]["AvgNoBusesScheduleNCRAc"], "0", sp.Rows[i]["AvgNoBusesOnRoadCityNac"], sp.Rows[i]["AvgNoBusesOnRoadCityAc"], sp.Rows[i]["AvgNoBusesOnRoadNCRNac"], sp.Rows[i]["AvgNoBusesOnRoadNCRAc"], "0", Convert.ToString(percentageFleetUtilizCityNac), Convert.ToString(percentageFleetUtilizCityAc), Convert.ToString(percentageFleetUtilizNcrNac), Convert.ToString(percentageFleetUtilizNcrAc), "0");
                }

            }

            table.Rows.Add("", "Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Electric Buses", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

            for (int i = 38; i < 40; i++)
            {
                decimal percentageFleetUtilizCityNac = Math.Round((Convert.ToDecimal(sp.Rows[i]["AvgFleetCityNac"]) != 0) ? (Convert.ToDecimal(sp.Rows[i]["AvgNoBusesOnRoadCityNac"]) / Convert.ToDecimal(sp.Rows[i]["AvgFleetCityNac"])) * 100 : 0, 2);
                decimal percentageFleetUtilizCityAc = Math.Round((Convert.ToDecimal(sp.Rows[i]["AvgFleetCityAc"]) != 0) ? (Convert.ToDecimal(sp.Rows[i]["AvgNoBusesOnRoadCityAc"]) / Convert.ToDecimal(sp.Rows[i]["AvgFleetCityAc"])) * 100 : 0, 2);
                decimal percentageFleetUtilizNcrNac = Math.Round((Convert.ToDecimal(sp.Rows[i]["AvgFleetNCRNac"]) != 0) ? (Convert.ToDecimal(sp.Rows[i]["AvgNoBusesOnRoadNCRNac"]) / Convert.ToDecimal(sp.Rows[i]["AvgFleetNCRNac"])) * 100 : 0, 2);
                decimal percentageFleetUtilizNcrAc = Math.Round((Convert.ToDecimal(sp.Rows[i]["AvgFleetNacAc"]) != 0) ? (Convert.ToDecimal(sp.Rows[i]["AvgNoBusesOnRoadNCRAc"]) / Convert.ToDecimal(sp.Rows[i]["AvgFleetNacAc"])) * 100 : 0, 2);

                table.Rows.Add(" ", sp.Rows[i]["CircleName"],
                    sp.Rows[i]["FleetLastDayCityNac"],
                    sp.Rows[i]["FleetLastDayCityAc"],
                    sp.Rows[i]["FleetLastDayNCRNac"],
                    sp.Rows[i]["FleetLastDayNCRAc"],
                    "0",
                    sp.Rows[i]["AvgFleetCityNac"],
                    sp.Rows[i]["AvgFleetCityAc"],
                    sp.Rows[i]["AvgFleetNCRNac"],
                    sp.Rows[i]["AvgFleetNacAc"],
                    "0",
                    sp.Rows[i]["AvgNoBusesScheduleCityNac"],
                    sp.Rows[i]["AvgNoBusesScheduleCityAc"],
                    sp.Rows[i]["AvgNoBusesScheduleNCRNac"],
                    sp.Rows[i]["AvgNoBusesScheduleNCRAc"],
                    "0",
                    sp.Rows[i]["AvgNoBusesOnRoadCityNac"],
                    sp.Rows[i]["AvgNoBusesOnRoadCityAc"],
                    sp.Rows[i]["AvgNoBusesOnRoadNCRNac"],
                    sp.Rows[i]["AvgNoBusesOnRoadNCRAc"],
                    "0",
                    Convert.ToString(percentageFleetUtilizCityNac),
                    Convert.ToString(percentageFleetUtilizCityAc),
                    Convert.ToString(percentageFleetUtilizNcrNac),
                    Convert.ToString(percentageFleetUtilizNcrAc),
                    "0");
            }

            table.Rows.Add(" ",
                sp.Rows[22]["CircleName"],
                sp.Rows[22]["FleetLastDayCityNac"],
                sp.Rows[22]["FleetLastDayCityAc"],
                sp.Rows[22]["FleetLastDayNCRNac"],
                sp.Rows[22]["FleetLastDayNCRAc"],
                "0",
                sp.Rows[22]["AvgFleetCityNac"],
                sp.Rows[22]["AvgFleetCityAc"],
                sp.Rows[22]["AvgFleetNCRNac"],
                sp.Rows[22]["AvgFleetNacAc"],
                "0",
                sp.Rows[22]["AvgNoBusesScheduleCityNac"],
                sp.Rows[22]["AvgNoBusesScheduleCityAc"],
                sp.Rows[22]["AvgNoBusesScheduleNCRNac"],
                sp.Rows[22]["AvgNoBusesScheduleNCRAc"],
                "0",
                sp.Rows[22]["AvgNoBusesOnRoadCityNac"],
                sp.Rows[22]["AvgNoBusesOnRoadCityAc"],
                sp.Rows[22]["AvgNoBusesOnRoadNCRNac"],
                sp.Rows[22]["AvgNoBusesOnRoadNCRAc"],
                "0",
                Math.Round((Convert.ToDecimal(sp.Rows[22]["AvgFleetCityNac"]) != 0) ? (Convert.ToDecimal(sp.Rows[22]["AvgNoBusesOnRoadCityNac"]) / Convert.ToDecimal(sp.Rows[22]["AvgFleetCityNac"])) * 100 : 0, 2),
                Math.Round((Convert.ToDecimal(sp.Rows[22]["AvgFleetCityAc"]) != 0) ? (Convert.ToDecimal(sp.Rows[22]["AvgNoBusesOnRoadCityAc"]) / Convert.ToDecimal(sp.Rows[22]["AvgFleetCityAc"])) * 100 : 0, 2),
                Math.Round((Convert.ToDecimal(sp.Rows[22]["AvgFleetNCRNac"]) != 0) ? (Convert.ToDecimal(sp.Rows[22]["AvgNoBusesOnRoadNCRNac"]) / Convert.ToDecimal(sp.Rows[22]["AvgFleetNCRNac"])) * 100 : 0, 2),
                Math.Round((Convert.ToDecimal(sp.Rows[22]["AvgFleetNacAc"]) != 0) ? (Convert.ToDecimal(sp.Rows[22]["AvgNoBusesOnRoadNCRAc"]) / Convert.ToDecimal(sp.Rows[22]["AvgFleetNacAc"])) * 100 : 0, 2),
                "0");

            table.Rows.Add("", "Total Electric", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Total DTC", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "International", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            table.Rows.Add("1", "Kathmandu", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("", "Grand Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");


            return table;

        }

        void BindIndexPage(int OsbId)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Depot],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16],[Param17],[Param18],[Param19],[Param20],[Param21],[Param22] ,[Param23],[Param24],[Param25] FROM [rpt].[tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                DataTable autoSpTable = new DataTable();

                if (dt.Rows.Count < 1)
                {
                    SqlCommand cmd1 = new SqlCommand("[dbo].[sp_DepotWIseoprationaldataOsb4_1]", con);
                    cmd1.Parameters.AddWithValue("@month", Month);
                    cmd1.Parameters.AddWithValue("@year", Year);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                    sda1.Fill(autoSpTable);
                    cmd1.CommandTimeout = 350;

                }

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    Save.BackColor = Color.Green;
                }

                else if (autoSpTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = BindDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillizationAuto_Sp_Table(autoSpTable);
                }
                else
                {
                    dataGridView1.DataSource = BindDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization();
                }

                setRowColNonEditable();
                CalcalculateTotal();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        int DeleteExisitingTableRecord(string TableName, int OsbId)
        {
            string strTable = "[dtcoperation].[rpt].[" + TableName + "]";
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
            DeleteExisitingTableRecord("tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization", OsbId);
            dataGridView1.DataSource = BindDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization();
            setRowColNonEditable();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null || row.Cells[11].Value != null || row.Cells[12].Value != null || row.Cells[13].Value != null || row.Cells[14].Value != null ||
                        row.Cells[15].Value != null || row.Cells[16].Value != null || row.Cells[17].Value != null || row.Cells[18].Value != null || row.Cells[19].Value != null || row.Cells[20].Value != null || row.Cells[21].Value != null || row.Cells[22].Value != null || row.Cells[23].Value != null || row.Cells[24].Value != null || row.Cells[25].Value != null || row.Cells[26].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization]" +
                            "([OsbId],[S_No],[Depot],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16],[Param17],[Param18],[Param19],[Param20],[Param21],[Param22],[Param23],[Param24],[Param25]) VALUES (@OsbId,@S_No,@Depot,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11,@Param12,@Param13,@Param14,@Param15,@Param16,@Param17,@Param18,@Param19,@Param20,@Param21,@Param22,@Param23,@Param24,@Param25)", con);
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
                        cmd.Parameters.AddWithValue("@Param12", row.Cells[13].Value == null ? "" : row.Cells[13].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param13", row.Cells[14].Value == null ? "" : row.Cells[14].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param14", row.Cells[15].Value == null ? "" : row.Cells[15].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param15", row.Cells[16].Value == null ? "" : row.Cells[16].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param16", row.Cells[17].Value == null ? "" : row.Cells[17].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param17", row.Cells[18].Value == null ? "" : row.Cells[18].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param18", row.Cells[19].Value == null ? "" : row.Cells[19].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param19", row.Cells[20].Value == null ? "" : row.Cells[20].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param20", row.Cells[21].Value == null ? "" : row.Cells[21].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param21", row.Cells[22].Value == null ? "" : row.Cells[22].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param22", row.Cells[23].Value == null ? "" : row.Cells[23].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param23", row.Cells[24].Value == null ? "" : row.Cells[24].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param24", row.Cells[25].Value == null ? "" : row.Cells[25].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param25", row.Cells[26].Value == null ? "" : row.Cells[26].Value.ToString());
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            MessageBox.Show("Done");
        }

        private void DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
            //dataGridView1.DataSource = BindDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization();
        }

        private void Print_ReportOnClick(object sender, EventArgs e)
        {
            rptDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization objFrm = new rptDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcalculateTotal();
        }

        void CalcalculateTotal()
        {
            try
            {
                var row = dataGridView1.Rows;

                #region Calculating_HorizontalSum

                for (int i = 0; i < 43; i++)
                {
                    if (i >= 0)
                    {
                        if (i != 35 && i != 40 && i != 42)
                        {
                            dataGridView1.Rows[i].Cells[6].Value = Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[5].Value.ToString());
                            dataGridView1.Rows[i].Cells[11].Value = Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[8].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[9].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[10].Value.ToString());
                            dataGridView1.Rows[i].Cells[16].Value = Common.ConvertToDecimal(row[i].Cells[12].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[14].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[15].Value.ToString());
                            dataGridView1.Rows[i].Cells[21].Value = Common.ConvertToDecimal(row[i].Cells[17].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[18].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[19].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[20].Value.ToString());
                        }

                        for (int j = 2; j < 22; j++)
                        {
                            dataGridView1.Rows[33].Cells[j].Value = Common.GetSum(row, 0, 32, j);

                            dataGridView1.Rows[38].Cells[j].Value = Common.GetSum(row, 35, 37, j);

                            dataGridView1.Rows[39].Cells[j].Value = Common.ConvertToDecimal(dataGridView1.Rows[33].Cells[j].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[38].Cells[j].Value.ToString());

                            dataGridView1.Rows[42].Cells[j].Value = Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[j].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[41].Cells[j].Value.ToString());
                        }

                        //if()
                        dataGridView1.Rows[i].Cells[22].Value = Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[i].Cells[17].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[7].Value.ToString())) * 100, 2) : 0;
                        dataGridView1.Rows[i].Cells[23].Value = Common.ConvertToDecimal(row[i].Cells[8].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[i].Cells[18].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[8].Value.ToString())) * 100, 2) : 0;
                        dataGridView1.Rows[i].Cells[24].Value = Common.ConvertToDecimal(row[i].Cells[9].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[i].Cells[19].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[9].Value.ToString())) * 100, 2) : 0;
                        dataGridView1.Rows[i].Cells[25].Value = Common.ConvertToDecimal(row[i].Cells[10].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[i].Cells[20].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[10].Value.ToString())) * 100, 2) : 0;
                        dataGridView1.Rows[i].Cells[26].Value = Common.ConvertToDecimal(row[i].Cells[11].Value.ToString()) > 0 ? Math.Round((Common.ConvertToDecimal(row[i].Cells[21].Value.ToString()) / Common.ConvertToDecimal(row[i].Cells[11].Value.ToString())) * 100, 2) : 0;
                    }
                }
                #endregion

                #region Calculating_VerticalSum

            }
            catch (Exception ex)
            {
                throw ex;
            }



            #endregion
        }

        private void setRowColNonEditable()
        {
            //Common.SetRowNonEditable(dataGridView1, 34);
            //Common.SetRowNonEditable(dataGridView1, 35);
            //Common.SetRowNonEditable(dataGridView1, 39);
            //Common.SetRowNonEditable(dataGridView1, 40);
            //Common.SetRowNonEditable(dataGridView1, 41);
            //Common.SetRowNonEditable(dataGridView1, 43);

            //Common.SetColumnNonEditable(dataGridView1, 6, 42);
            //Common.SetColumnNonEditable(dataGridView1, 11, 42);
            //Common.SetColumnNonEditable(dataGridView1, 16, 42);
            //Common.SetColumnNonEditable(dataGridView1, 21, 42);
            //Common.SetColumnNonEditable(dataGridView1, 22, 42);
            //Common.SetColumnNonEditable(dataGridView1, 23, 42);
            //Common.SetColumnNonEditable(dataGridView1, 24, 42);
            //Common.SetColumnNonEditable(dataGridView1, 25, 42);
            //Common.SetColumnNonEditable(dataGridView1, 26, 42);


        }

    }
}
