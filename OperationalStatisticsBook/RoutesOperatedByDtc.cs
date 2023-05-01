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
    public partial class RoutesOperatedByDtc : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);
        public RoutesOperatedByDtc(int OsbId, int Year, int Month, string finYear, string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;
        }

        DataTable BindRoutesOperatedByDtc()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Year", typeof(string));
            table.Columns.Add("No of routes at the end of the Period", typeof(string));
            table.Columns.Add("No of routes at the end of the Period ", typeof(string));
            table.Columns.Add("No of routes at the end of  the Period ", typeof(string));
            table.Columns.Add("No of routes at  the end of the Period ", typeof(string));
            table.Columns.Add("Route KMs  at the end of the period", typeof(string));
            table.Columns.Add("Route KMs at the end of  the period ", typeof(string));
            table.Columns.Add("Route KMs at the   end of the period ", typeof(string));
            table.Columns.Add("Route KMs at the  end of the period ", typeof(string));
            table.Columns.Add("Average Route length", typeof(string));
            table.Columns.Add("Average  Route length ", typeof(string));
            table.Columns.Add("Average   Route   length ", typeof(string));
            table.Columns.Add("Average Route  length ", typeof(string));


            DateTime currentDate = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate.AddYears(0);
            DateTime newDateM = currentDate.AddMonths(+1);
            DateTime newDate2 = currentDate.AddYears(1);
            DateTime currentMonth = currentDate.AddMonths(-6);
            DateTime newDateCurrent = currentDate.AddYears(0);

            DateTime currentYear1 = currentDate.AddYears(-2);


            string currentYear = currentYear1.Year.ToString();
            string previousYear = newDateCurrent.Year.ToString();
            DateTime newDateCurrent2 = currentDate.AddYears(-1);
            string previousYear1 = newDateCurrent2.Year.ToString();
            // table.Rows.Add("", "City", "City", "NCR", "NCR", "City", "City", "NCR", "NCR", "City", "City", "NCR", "NCR");
            //  table.Rows.Add("1", "2", "2", "3", "3", "4", "4", "5", "5", "6", "6", "7", "7");

            //for (int i = 10; i > 0; i--)
            //{
            //    table.Rows.Add(newDate.AddYears(-i).Year + "-" + newDate2.AddYears(-i).Year, " 0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //}

            table.Rows.Add("1", "2", "", "3", "", "4", "", "5", "", "6", "", "7", "");
            table.Rows.Add("2012-13", "589", "", "23", "", "15646.00", "", "1032", "", "26.6", "", "44.9", "");
            table.Rows.Add("2013-14", "579", "", "12", "", "15480.0", "", "529", "", "26.7", "", "44.1", "");
            table.Rows.Add("2014-15", "574", "", "12", "", "15285.5", "", "503", "", "26.7", "", "41.9", "");
            table.Rows.Add("2015-16", "546", "", "11", "", "14732.5", "", "414", "", "27.0", "", "37.6", "");
            table.Rows.Add("2016-17", "474", "", "9", "", "13017.9", "", "314", "", "27.5", "", "34.9", "");
            table.Rows.Add("2017-18", "453", "", "8", "", "12490.7", "", "247", "", "27.6", "", "34.9", "");
            table.Rows.Add("2018-19", "437", "", "8", "", "11968.1", "", "242", "", "27.4", "", "30.3", "");
            table.Rows.Add("2019-20", "448", "", "7", "", "12183.8", "", "219", "", "27.2", "", "31.2", "");
            table.Rows.Add("2020-21", "453", "", "7", "", "12289.7", "", "219", "", "27.1", "", "31.2", "");
            table.Rows.Add("2021-22", "461", "", "7", "", "12480.0", "", "219", "", "27.1", "", "31.2", "");


            table.Rows.Add("", " No.of routes at the end of the period", "No.of routes at the end of the period", "No.of routes at the end of the period", "No.of routes at the end of the period", "Route KMs at the end of the period", "Route KMs at the end of the period", "Route KMs at the end of the period", "Route KMs at the end of the period", "Average route length", "Average route length", "Average route length", "Average route length");
            table.Rows.Add("", " City ", "City ", "NCR", "NCR", "City", "City", "NCR", "NCR", "City", "City", "NCR", "NCR");
            table.Rows.Add("Year", currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1);

            //for (int i = 6; i > 0; i--)
            //{
            //    table.Rows.Add(currentMonth.AddMonths(-i).ToString("MMMM"), " 0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //}
            for (int i = currentDate.Month; i <= 12; i++)
            {
                table.Rows.Add(Common.monthNames[i - 1], 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            }


            table.Rows.Add("", " City ", "City ", "NCR", "NCR", "City", "City", "NCR", "NCR", "City", "City", "NCR", "NCR");
            table.Rows.Add("Year", previousYear1, previousYear, previousYear1, previousYear, previousYear1, previousYear, previousYear1, previousYear, previousYear1, previousYear, previousYear1, previousYear);

            for (int i = 1; i <= currentDate.Month; i++)
            {
                table.Rows.Add(Common.monthNames[i - 1], 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            }




            //for (int i = 7; i > 0; i--)
            //{
            //    table.Rows.Add(newDateM.AddMonths(-i).ToString("MMMM"), " 0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //}


            return table;

        }


        DataTable BindRoutesOperatedByDtcauto_Sp(DataTable sp)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Year", typeof(string));
            table.Columns.Add("No of routes at the end of the Period", typeof(string));
            table.Columns.Add("No of routes at the end of the Period ", typeof(string));
            table.Columns.Add("No of routes at the end of  the Period ", typeof(string));
            table.Columns.Add("No of routes at  the end of the Period ", typeof(string));
            table.Columns.Add("Route KMs  at the end of the period", typeof(string));
            table.Columns.Add("Route KMs at the end of  the period ", typeof(string));
            table.Columns.Add("Route KMs at the   end of the period ", typeof(string));
            table.Columns.Add("Route KMs at the  end of the period ", typeof(string));
            table.Columns.Add("Average Route length", typeof(string));
            table.Columns.Add("Average  Route length ", typeof(string));
            table.Columns.Add("Average   Route   length ", typeof(string));
            table.Columns.Add("Average Route  length ", typeof(string));


            DateTime currentDate = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate.AddYears(0);
            DateTime newDateM = currentDate.AddMonths(+1);
            DateTime newDate2 = currentDate.AddYears(1);
            DateTime currentMonth = currentDate.AddMonths(-6);
            DateTime newDateCurrent = currentDate.AddYears(0);

            DateTime currentYear1 = currentDate.AddYears(-2);


            string currentYear = currentYear1.Year.ToString();
            string previousYear = newDateCurrent.Year.ToString();
            DateTime newDateCurrent2 = currentDate.AddYears(-1);
            string previousYear1 = newDateCurrent2.Year.ToString();
            // table.Rows.Add("", "City", "City", "NCR", "NCR", "City", "City", "NCR", "NCR", "City", "City", "NCR", "NCR");
            //  table.Rows.Add("1", "2", "2", "3", "3", "4", "4", "5", "5", "6", "6", "7", "7");

            //for (int i = 10; i > 0; i--)
            //{
            //    table.Rows.Add(newDate.AddYears(-i).Year + "-" + newDate2.AddYears(-i).Year, " 0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            //}

            table.Rows.Add("1", "2", "", "3", "", "4", "", "5", "", "6", "", "7", "");
            table.Rows.Add("2012-13", "589", "", "23", "", "15646.00", "", "1032", "", "26.6", "", "44.9", "");
            table.Rows.Add("2013-14", "579", "", "12", "", "15480.0", "", "529", "", "26.7", "", "44.1", "");
            table.Rows.Add("2014-15", "574", "", "12", "", "15285.5", "", "503", "", "26.7", "", "41.9", "");
            table.Rows.Add("2015-16", "546", "", "11", "", "14732.5", "", "414", "", "27.0", "", "37.6", "");
            table.Rows.Add("2016-17", "474", "", "9", "", "13017.9", "", "314", "", "27.5", "", "34.9", "");
            table.Rows.Add("2017-18", "453", "", "8", "", "12490.7", "", "247", "", "27.6", "", "34.9", "");
            table.Rows.Add("2018-19", "437", "", "8", "", "11968.1", "", "242", "", "27.4", "", "30.3", "");
            table.Rows.Add("2019-20", "448", "", "7", "", "12183.8", "", "219", "", "27.2", "", "31.2", "");
            table.Rows.Add("2020-21", "453", "", "7", "", "12289.7", "", "219", "", "27.1", "", "31.2", "");
            table.Rows.Add("2021-22", "461", "", "7", "", "12480.0", "", "219", "", "27.1", "", "31.2", "");


            table.Rows.Add("", " No.of routes at the end of the period", "No.of routes at the end of the period", "No.of routes at the end of the period", "No.of routes at the end of the period", "Route KMs at the end of the period", "Route KMs at the end of the period", "Route KMs at the end of the period", "Route KMs at the end of the period", "Average route length", "Average route length", "Average route length", "Average route length");
            table.Rows.Add("", " City ", "City ", "NCR", "NCR", "City", "City", "NCR", "NCR", "City", "City", "NCR", "NCR");
            table.Rows.Add("Year", currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1, currentYear, previousYear1);



            //for (int i = currentDate.Month; i <= 12; i++)
            //{
            //    table.Rows.Add(Common.monthNames[i - 1], 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            //}



            if (currentDate.Month <= 12) table.Rows.Add(Common.monthNames[currentDate.Month - 1], 0, sp.Rows[11]["NoOfRouteCityYearMinus1"].ToString(), 0, sp.Rows[11]["NoOfRouteNCRYearMinus1"].ToString(), 0, sp.Rows[11]["RouteKmCityCurrentYearMinus1"].ToString(), 0, sp.Rows[11]["RouteKmNCRCurrentYearMinus1"].ToString(), 0, sp.Rows[11]["AvgRouteKmCityYearMinus1"].ToString(), 0, sp.Rows[11]["AvgRouteKmNCRYearMinus1"].ToString());
            if (currentDate.Month <= 11) table.Rows.Add(Common.monthNames[currentDate.Month], 0, sp.Rows[10]["NoOfRouteCityYearMinus1"].ToString(), 0, sp.Rows[10]["NoOfRouteNCRYearMinus1"].ToString(), 0, sp.Rows[10]["RouteKmCityCurrentYearMinus1"].ToString(), 0, sp.Rows[10]["RouteKmNCRCurrentYearMinus1"].ToString(), 0, sp.Rows[10]["AvgRouteKmCityYearMinus1"].ToString(), 0, sp.Rows[10]["AvgRouteKmNCRYearMinus1"].ToString());
            if (currentDate.Month <= 10) table.Rows.Add(Common.monthNames[currentDate.Month + 1], 0, sp.Rows[9]["NoOfRouteCityYearMinus1"].ToString(), 0, sp.Rows[9]["NoOfRouteNCRYearMinus1"].ToString(), 0, sp.Rows[9]["RouteKmCityCurrentYearMinus1"].ToString(), 0, sp.Rows[9]["RouteKmNCRCurrentYearMinus1"].ToString(), 0, sp.Rows[9]["AvgRouteKmCityYearMinus1"].ToString(), 0, sp.Rows[9]["AvgRouteKmNCRYearMinus1"].ToString());
            if (currentDate.Month <= 9) table.Rows.Add(Common.monthNames[currentDate.Month + 2], 0, sp.Rows[8]["NoOfRouteCityYearMinus1"].ToString(), 0, sp.Rows[8]["NoOfRouteNCRYearMinus1"].ToString(), 0, sp.Rows[8]["RouteKmCityCurrentYearMinus1"].ToString(), 0, sp.Rows[8]["RouteKmNCRCurrentYearMinus1"].ToString(), 0, sp.Rows[8]["AvgRouteKmCityYearMinus1"].ToString(), 0, sp.Rows[8]["AvgRouteKmNCRYearMinus1"].ToString());
            if (currentDate.Month <= 8) table.Rows.Add(Common.monthNames[currentDate.Month + 3], 0, sp.Rows[7]["NoOfRouteCityYearMinus1"].ToString(), 0, sp.Rows[7]["NoOfRouteNCRYearMinus1"].ToString(), 0, sp.Rows[7]["RouteKmCityCurrentYearMinus1"].ToString(), 0, sp.Rows[7]["RouteKmNCRCurrentYearMinus1"].ToString(), 0, sp.Rows[7]["AvgRouteKmCityYearMinus1"].ToString(), 0, sp.Rows[7]["AvgRouteKmNCRYearMinus1"].ToString());
            if (currentDate.Month <= 7) table.Rows.Add(Common.monthNames[currentDate.Month + 4], 0, sp.Rows[6]["NoOfRouteCityYearMinus1"].ToString(), 0, sp.Rows[6]["NoOfRouteNCRYearMinus1"].ToString(), 0, sp.Rows[6]["RouteKmCityCurrentYearMinus1"].ToString(), 0, sp.Rows[6]["RouteKmNCRCurrentYearMinus1"].ToString(), 0, sp.Rows[6]["AvgRouteKmCityYearMinus1"].ToString(), 0, sp.Rows[6]["AvgRouteKmNCRYearMinus1"].ToString());
            if (currentDate.Month <= 6) table.Rows.Add(Common.monthNames[currentDate.Month + 5], 0, sp.Rows[5]["NoOfRouteCityYearMinus1"].ToString(), 0, sp.Rows[5]["NoOfRouteNCRYearMinus1"].ToString(), 0, sp.Rows[5]["RouteKmCityCurrentYearMinus1"].ToString(), 0, sp.Rows[5]["RouteKmNCRCurrentYearMinus1"].ToString(), 0, sp.Rows[5]["AvgRouteKmCityYearMinus1"].ToString(), 0, sp.Rows[5]["AvgRouteKmNCRYearMinus1"].ToString());
            if (currentDate.Month <= 5) table.Rows.Add(Common.monthNames[currentDate.Month + 6], 0, sp.Rows[4]["NoOfRouteCityYearMinus1"].ToString(), 0, sp.Rows[4]["NoOfRouteNCRYearMinus1"].ToString(), 0, sp.Rows[4]["RouteKmCityCurrentYearMinus1"].ToString(), 0, sp.Rows[4]["RouteKmNCRCurrentYearMinus1"].ToString(), 0, sp.Rows[4]["AvgRouteKmCityYearMinus1"].ToString(), 0, sp.Rows[4]["AvgRouteKmNCRYearMinus1"].ToString());
            if (currentDate.Month <= 4) table.Rows.Add(Common.monthNames[currentDate.Month + 7], 0, sp.Rows[3]["NoOfRouteCityYearMinus1"].ToString(), 0, sp.Rows[3]["NoOfRouteNCRYearMinus1"].ToString(), 0, sp.Rows[3]["RouteKmCityCurrentYearMinus1"].ToString(), 0, sp.Rows[3]["RouteKmNCRCurrentYearMinus1"].ToString(), 0, sp.Rows[3]["AvgRouteKmCityYearMinus1"].ToString(), 0, sp.Rows[3]["AvgRouteKmNCRYearMinus1"].ToString());
            if (currentDate.Month <= 3) table.Rows.Add(Common.monthNames[currentDate.Month + 8], 0, sp.Rows[2]["NoOfRouteCityYearMinus1"].ToString(), 0, sp.Rows[2]["NoOfRouteNCRYearMinus1"].ToString(), 0, sp.Rows[2]["RouteKmCityCurrentYearMinus1"].ToString(), 0, sp.Rows[2]["RouteKmNCRCurrentYearMinus1"].ToString(), 0, sp.Rows[2]["AvgRouteKmCityYearMinus1"].ToString(), 0, sp.Rows[2]["AvgRouteKmNCRYearMinus1"].ToString());
            if (currentDate.Month <= 2) table.Rows.Add(Common.monthNames[currentDate.Month + 9], 0, sp.Rows[1]["NoOfRouteCityYearMinus1"].ToString(), 0, sp.Rows[1]["NoOfRouteNCRYearMinus1"].ToString(), 0, sp.Rows[1]["RouteKmCityCurrentYearMinus1"].ToString(), 0, sp.Rows[1]["RouteKmNCRCurrentYearMinus1"].ToString(), 0, sp.Rows[1]["AvgRouteKmCityYearMinus1"].ToString(), 0, sp.Rows[1]["AvgRouteKmNCRYearMinus1"].ToString());
            if (currentDate.Month <= 1) table.Rows.Add(Common.monthNames[currentDate.Month + 10], 0, sp.Rows[0]["NoOfRouteCityYearMinus1"].ToString(), 0, sp.Rows[0]["NoOfRouteNCRYearMinus1"].ToString(), 0, sp.Rows[0]["RouteKmCityCurrentYearMinus1"].ToString(), 0, sp.Rows[0]["RouteKmNCRCurrentYearMinus1"].ToString(), 0, sp.Rows[0]["AvgRouteKmCityYearMinus1"].ToString(), 0, sp.Rows[0]["AvgRouteKmNCRYearMinus1"].ToString());








            table.Rows.Add("", " City ", "City ", "NCR", "NCR", "City", "City", "NCR", "NCR", "City", "City", "NCR", "NCR");
            table.Rows.Add("Year", previousYear1, previousYear, previousYear1, previousYear, previousYear1, previousYear, previousYear1, previousYear, previousYear1, previousYear, previousYear1, previousYear);

            //for (int i = 1; i <= currentDate.Month; i++)
            //{
            //    table.Rows.Add(Common.monthNames[i - 1], 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            //}


            switch (currentDate.Month)
            {

                case 1:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[0]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[0]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmCityCurrentYear"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmNCRCurrentYear"].ToString());
                    break;
                case 2:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[0]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[0]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmCityCurrentYear"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[1]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[1]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmCityCurrentYear"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmNCRCurrentYear"].ToString());

                    break;
                case 3:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[0]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[0]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmCityCurrentYear"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[1]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[1]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmCityCurrentYear"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[2]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[2]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmCityCurrentYear"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmNCRCurrentYear"].ToString());

                    break;
                case 4:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[0]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[0]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmCityCurrentYear"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[1]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[1]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmCityCurrentYear"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[2]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[2]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmCityCurrentYear"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[3], sp.Rows[3]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[3]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[3]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[3]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[3]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[3]["RouteKmCityCurrentYear"].ToString(), sp.Rows[3]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[3]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[3]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[3]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[3]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[3]["AvgRouteKmNCRCurrentYear"].ToString());

                    break;
                case 5:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[0]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[0]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmCityCurrentYear"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[1]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[1]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmCityCurrentYear"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[2]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[2]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmCityCurrentYear"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[3], sp.Rows[3]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[3]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[3]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[3]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[3]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[3]["RouteKmCityCurrentYear"].ToString(), sp.Rows[3]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[3]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[3]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[3]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[3]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[3]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[4], sp.Rows[4]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[4]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[4]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[4]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[4]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[4]["RouteKmCityCurrentYear"].ToString(), sp.Rows[4]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[4]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[4]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[4]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[4]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[4]["AvgRouteKmNCRCurrentYear"].ToString());

                    break;
                case 6:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[0]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[0]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmCityCurrentYear"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[1]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[1]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmCityCurrentYear"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[2]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[2]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmCityCurrentYear"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[3], sp.Rows[3]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[3]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[3]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[3]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[3]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[3]["RouteKmCityCurrentYear"].ToString(), sp.Rows[3]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[3]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[3]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[3]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[3]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[3]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[4], sp.Rows[4]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[4]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[4]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[4]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[4]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[4]["RouteKmCityCurrentYear"].ToString(), sp.Rows[4]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[4]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[4]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[4]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[4]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[4]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[5], sp.Rows[5]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[5]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[5]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[5]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[5]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[5]["RouteKmCityCurrentYear"].ToString(), sp.Rows[5]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[5]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[5]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[5]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[5]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[5]["AvgRouteKmNCRCurrentYear"].ToString());

                    break;
                case 7:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[0]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[0]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmCityCurrentYear"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[1]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[1]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmCityCurrentYear"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[2]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[2]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmCityCurrentYear"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[3], sp.Rows[3]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[3]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[3]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[3]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[3]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[3]["RouteKmCityCurrentYear"].ToString(), sp.Rows[3]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[3]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[3]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[3]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[3]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[3]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[4], sp.Rows[4]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[4]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[4]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[4]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[4]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[4]["RouteKmCityCurrentYear"].ToString(), sp.Rows[4]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[4]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[4]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[4]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[4]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[4]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[5], sp.Rows[5]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[5]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[5]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[5]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[5]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[5]["RouteKmCityCurrentYear"].ToString(), sp.Rows[5]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[5]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[5]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[5]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[5]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[5]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[6], sp.Rows[6]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[6]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[6]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[6]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[6]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[6]["RouteKmCityCurrentYear"].ToString(), sp.Rows[6]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[6]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[6]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[6]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[6]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[6]["AvgRouteKmNCRCurrentYear"].ToString());

                    break;
                case 8:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[0]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[0]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmCityCurrentYear"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[1]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[1]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmCityCurrentYear"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[2]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[2]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmCityCurrentYear"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[3], sp.Rows[3]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[3]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[3]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[3]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[3]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[3]["RouteKmCityCurrentYear"].ToString(), sp.Rows[3]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[3]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[3]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[3]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[3]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[3]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[4], sp.Rows[4]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[4]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[4]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[4]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[4]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[4]["RouteKmCityCurrentYear"].ToString(), sp.Rows[4]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[4]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[4]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[4]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[4]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[4]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[5], sp.Rows[5]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[5]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[5]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[5]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[5]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[5]["RouteKmCityCurrentYear"].ToString(), sp.Rows[5]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[5]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[5]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[5]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[5]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[5]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[6], sp.Rows[6]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[6]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[6]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[6]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[6]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[6]["RouteKmCityCurrentYear"].ToString(), sp.Rows[6]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[6]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[6]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[6]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[6]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[6]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[7], sp.Rows[7]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[7]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[7]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[7]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[7]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[7]["RouteKmCityCurrentYear"].ToString(), sp.Rows[7]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[7]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[7]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[7]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[7]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[7]["AvgRouteKmNCRCurrentYear"].ToString());

                    break;
                case 9:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[0]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[0]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmCityCurrentYear"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[1]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[1]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmCityCurrentYear"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[2]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[2]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmCityCurrentYear"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[3], sp.Rows[3]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[3]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[3]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[3]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[3]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[3]["RouteKmCityCurrentYear"].ToString(), sp.Rows[3]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[3]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[3]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[3]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[3]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[3]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[4], sp.Rows[4]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[4]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[4]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[4]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[4]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[4]["RouteKmCityCurrentYear"].ToString(), sp.Rows[4]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[4]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[4]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[4]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[4]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[4]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[5], sp.Rows[5]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[5]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[5]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[5]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[5]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[5]["RouteKmCityCurrentYear"].ToString(), sp.Rows[5]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[5]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[5]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[5]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[5]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[5]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[6], sp.Rows[6]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[6]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[6]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[6]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[6]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[6]["RouteKmCityCurrentYear"].ToString(), sp.Rows[6]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[6]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[6]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[6]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[6]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[6]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[7], sp.Rows[7]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[7]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[7]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[7]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[7]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[7]["RouteKmCityCurrentYear"].ToString(), sp.Rows[7]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[7]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[7]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[7]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[7]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[7]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[8], sp.Rows[8]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[8]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[8]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[8]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[8]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[8]["RouteKmCityCurrentYear"].ToString(), sp.Rows[8]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[8]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[8]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[8]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[8]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[8]["AvgRouteKmNCRCurrentYear"].ToString());

                    break;
                case 10:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[0]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[0]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmCityCurrentYear"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[1]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[1]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmCityCurrentYear"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[2]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[2]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmCityCurrentYear"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[3], sp.Rows[3]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[3]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[3]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[3]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[3]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[3]["RouteKmCityCurrentYear"].ToString(), sp.Rows[3]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[3]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[3]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[3]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[3]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[3]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[4], sp.Rows[4]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[4]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[4]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[4]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[4]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[4]["RouteKmCityCurrentYear"].ToString(), sp.Rows[4]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[4]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[4]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[4]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[4]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[4]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[5], sp.Rows[5]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[5]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[5]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[5]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[5]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[5]["RouteKmCityCurrentYear"].ToString(), sp.Rows[5]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[5]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[5]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[5]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[5]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[5]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[6], sp.Rows[6]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[6]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[6]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[6]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[6]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[6]["RouteKmCityCurrentYear"].ToString(), sp.Rows[6]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[6]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[6]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[6]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[6]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[6]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[7], sp.Rows[7]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[7]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[7]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[7]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[7]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[7]["RouteKmCityCurrentYear"].ToString(), sp.Rows[7]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[7]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[7]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[7]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[7]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[7]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[8], sp.Rows[8]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[8]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[8]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[8]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[8]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[8]["RouteKmCityCurrentYear"].ToString(), sp.Rows[8]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[8]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[8]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[8]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[8]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[8]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[9], sp.Rows[9]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[9]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[9]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[9]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[9]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[9]["RouteKmCityCurrentYear"].ToString(), sp.Rows[9]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[9]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[9]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[9]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[9]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[9]["AvgRouteKmNCRCurrentYear"].ToString());

                    break;
                case 11:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[0]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[0]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmCityCurrentYear"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[1]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[1]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmCityCurrentYear"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[2]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[2]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmCityCurrentYear"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[3], sp.Rows[3]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[3]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[3]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[3]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[3]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[3]["RouteKmCityCurrentYear"].ToString(), sp.Rows[3]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[3]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[3]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[3]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[3]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[3]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[4], sp.Rows[4]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[4]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[4]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[4]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[4]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[4]["RouteKmCityCurrentYear"].ToString(), sp.Rows[4]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[4]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[4]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[4]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[4]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[4]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[5], sp.Rows[5]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[5]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[5]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[5]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[5]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[5]["RouteKmCityCurrentYear"].ToString(), sp.Rows[5]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[5]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[5]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[5]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[5]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[5]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[6], sp.Rows[6]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[6]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[6]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[6]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[6]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[6]["RouteKmCityCurrentYear"].ToString(), sp.Rows[6]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[6]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[6]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[6]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[6]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[6]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[7], sp.Rows[7]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[7]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[7]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[7]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[7]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[7]["RouteKmCityCurrentYear"].ToString(), sp.Rows[7]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[7]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[7]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[7]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[7]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[7]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[8], sp.Rows[8]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[8]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[8]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[8]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[8]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[8]["RouteKmCityCurrentYear"].ToString(), sp.Rows[8]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[8]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[8]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[8]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[8]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[8]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[9], sp.Rows[9]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[9]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[9]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[9]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[9]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[9]["RouteKmCityCurrentYear"].ToString(), sp.Rows[9]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[9]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[9]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[9]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[9]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[9]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[10], sp.Rows[10]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[10]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[10]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[10]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[10]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[10]["RouteKmCityCurrentYear"].ToString(), sp.Rows[10]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[10]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[10]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[10]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[10]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[10]["AvgRouteKmNCRCurrentYear"].ToString());

                    break;
                case 12:
                    table.Rows.Add(Common.monthNames[0], sp.Rows[0]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[0]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[0]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[0]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmCityCurrentYear"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[0]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[0]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[0]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[1], sp.Rows[1]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[1]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[1]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[1]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmCityCurrentYear"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[1]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[1]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[1]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[2], sp.Rows[2]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[2]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[2]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[2]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmCityCurrentYear"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[2]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[2]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[2]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[3], sp.Rows[3]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[3]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[3]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[3]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[3]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[3]["RouteKmCityCurrentYear"].ToString(), sp.Rows[3]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[3]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[3]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[3]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[3]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[3]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[4], sp.Rows[4]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[4]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[4]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[4]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[4]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[4]["RouteKmCityCurrentYear"].ToString(), sp.Rows[4]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[4]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[4]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[4]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[4]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[4]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[5], sp.Rows[5]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[5]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[5]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[5]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[5]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[5]["RouteKmCityCurrentYear"].ToString(), sp.Rows[5]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[5]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[5]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[5]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[5]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[5]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[6], sp.Rows[6]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[6]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[6]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[6]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[6]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[6]["RouteKmCityCurrentYear"].ToString(), sp.Rows[6]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[6]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[6]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[6]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[6]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[6]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[7], sp.Rows[7]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[7]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[7]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[7]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[7]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[7]["RouteKmCityCurrentYear"].ToString(), sp.Rows[7]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[7]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[7]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[7]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[7]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[7]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[8], sp.Rows[8]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[8]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[8]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[8]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[8]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[8]["RouteKmCityCurrentYear"].ToString(), sp.Rows[8]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[8]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[8]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[8]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[8]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[8]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[9], sp.Rows[9]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[9]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[9]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[9]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[9]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[9]["RouteKmCityCurrentYear"].ToString(), sp.Rows[9]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[9]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[9]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[9]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[9]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[9]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[10], sp.Rows[10]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[10]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[10]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[10]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[10]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[10]["RouteKmCityCurrentYear"].ToString(), sp.Rows[10]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[10]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[10]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[10]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[10]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[10]["AvgRouteKmNCRCurrentYear"].ToString());
                    table.Rows.Add(Common.monthNames[11], sp.Rows[11]["NoOfRouteCityYearMinus1"].ToString(), sp.Rows[11]["NoOfRouteCityCurrentYear"].ToString(), sp.Rows[11]["NoOfRouteNCRYearMinus1"].ToString(), sp.Rows[11]["NoOfRouteNCRCurrentYear"].ToString(), sp.Rows[11]["RouteKmCityCurrentYearMinus1"].ToString(), sp.Rows[11]["RouteKmCityCurrentYear"].ToString(), sp.Rows[11]["RouteKmNCRCurrentYearMinus1"].ToString(), sp.Rows[11]["RouteKmNCRCurrentYear"].ToString(), sp.Rows[11]["AvgRouteKmCityYearMinus1"].ToString(), sp.Rows[11]["AvgRouteKmCityCurrentYear"].ToString(), sp.Rows[11]["AvgRouteKmNCRYearMinus1"].ToString(), sp.Rows[11]["AvgRouteKmNCRCurrentYear"].ToString());
                    break;

            }





            return table;

        }


        private void ResetOnClick(object sender, EventArgs e)
        {

            dataGridView1.DataSource = BindRoutesOperatedByDtc();
            //DeleteExisitingTableRecord("tbl_RoutesOperatedByDtc", OsbId);
            MessageBox.Show("Done");
        }

        void BindIndexPage(int OsbId)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT [Year],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12] FROM [rpt].[tbl_RoutesOperatedByDtc] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);


                DataTable autoSpTable = new DataTable();
                SqlCommand cmd1 = new SqlCommand("[dbo].[RoutesOperatedbyDTCOSB1_3]", con);
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
                    dataGridView1.DataSource = BindRoutesOperatedByDtcauto_Sp(autoSpTable);
                }


                else
                {
                    dataGridView1.DataSource = BindRoutesOperatedByDtc();
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_RoutesOperatedByDtc", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null || row.Cells[11].Value != null || row.Cells[12].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_RoutesOperatedByDtc] ([OsbId],[Year],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12]) VALUES (@OsbId,@Year,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11,@Param12)", con);
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

        private void RoutesOperatedByDtc_Load(object sender, EventArgs e)
        {
            BindIndexPage(OsbId);
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
            rptRoutesOperatedByDtc objFrm = new rptRoutesOperatedByDtc(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }
    }
}
