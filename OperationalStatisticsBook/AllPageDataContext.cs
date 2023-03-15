using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationalStatisticsBook
{
    public class AllPageDataContext
    {
        //INDEX PAGE
        public DataTable GetIndexPageData_Page1(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("GetAllrptIndexPrintPage", param);
            return dt;
        }


        //PERFORMANCE OF DTC GLANCE
        public DataTable GetDataPerformanceDtcGlance_Page2_tbl1(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptfrmPerformanceofDTCGlance", param);
            return dt;
        }


        // PROGRESSIVE FINANCIAL RESULT
        public DataTable GetDataProgressiveFinanResult_Page2_tbl2(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptprogressiveFinancialResults", param);
            return dt;
        }

        // STAFF RATIO
        public DataTable GetDataStaffRatio_Page3_tbl1(int OsbId, int Year, int Month)
        {


            DateTime currentDate = new DateTime(Year, Month, 01);
            String[,] param = new string[,]
                {
                    { "@OsbId",OsbId.ToString()},
                 //  { "@Month",Month.ToString()},
                   
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptStaffRatioAsOn", param);
            // DataTable dt = Common.ExecuteProcedure("sp_GetStaffRatioDetails", param);

            return dt;
        }

        // ANALYSIS OF CAUSES ACCIDENTS FROM

        public DataTable GetDataAnalysisCausesAccidents_Page3_tbl2(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId","5"},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptanalysisCausesAccidents", param);
            return dt;
        }


        // A SALIENT FEATURE GROWTH OF BASIC STRUCTURE OF DTC

        public DataTable GetDataSalientGrowthBasicStructure_Page4_tbl1(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_SalientFeatureGrowthBasicStructure", param);
            return dt;
        }


        //ROUTES OPERATED BY DTC 
        public DataTable GetDataRoutesOperatedbyDTC_Page4_tbl2(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("[dbo].[sp_rptRoutesOperatedByDtc]", param);
            return dt;
        }

        //COMPARATIVE FINANCIAL RESULT
        public DataTable GetDataComparativeFinanacialResult_Page5n6(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptComparativeFinancialResultsFrom", param);
            return dt;
        }

        // COMPARATIVE OPERATIONAL DATA FOR THE FINANCIAL YEAR

        public DataTable GetDataComparativeOperationalData_Page7(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_ComparativeOperationalData", param);
            return dt;
        }


        // DISTRIBUTION OF FLEET BY TYPE/MAKE AND YEAR OF COMMISION

        public DataTable GetDataDistributionFleetTypeMakeYearCommision_Page8(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptDistrubutionOfFleetByTypeMakeAndYearOfCommission", param);
            return dt;
        }


        // PRICE AND COST INDICIES

        public DataTable GetDataPriceNCostIndicies_Page9_tbl1(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("GetAllrptPriceAndCostIndices", param);
            return dt;
        }

        //MATERIAL CONSUMPTION 

        public DataTable GetDataMaterialConsumption_Page9_tbl2(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptMaterialConsumptionFrom", param);
            return dt;
        }

        // PERFORMANCE OF METROPOLITIN TRANSPORT UNDERTAKING

        public DataTable GetDataPerformMetroTransUnder_Page10_tbl1(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_PerformanceMetopolitanTransportUndertaking", param);
            return dt;
        }

        //ACCIDENTS AND COMPENSATION GIVEN TO ACCIDENT VICTIMS

        public DataTable GetDataAccidentNCompensGvnAcciVic_Page10_tbl2(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_AccidentNCompensationGvnAccidentVictims", param);
            return dt;
        }

        // OPERATIONAL DATA DEPOT WISE FLEET STRENGTH & BUSES ON ROAD

        public DataTable GetDataOperaDepotWiseFleetStrenBusesOnRoad_Page11(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("SP_rptOperationalDepotWiseFleetStrengthNBusesOnRoad", param);
            return dt;
        }

        // CATEGORYWISE STAFF POSITION AS ON 

        public DataTable GetDataCategorywiseStaffPosition_Page12(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptCategorywiseStaffPositionAsOn", param);
            return dt;
        }

        // ROUTES OPERATED BY DTC AND ITS EARNING PER KILOMETER

        public DataTable GetDataRoutesOperatedByDTCEarningPerKm_Page13(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptRoutesOperatedByDTCEarningPerKillometerJune", param);
            return dt;
        }

        // Statement Showing Region Wise Operational

        public DataTable GetDataStatementShowRegionWiseOpera_Page14(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptStatementShowingRegionWiseOperationalDataForTheMonth", param);
            return dt;
        }


        // DETAILS OF OPERATIONAL DATA

        public DataTable GetDataDetailsofOperationaldata_Page15n16(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_DetailsofOperationaldataforthemonthofJuly", param);
            return dt;
        }

        // Depot Wise Oprational Data Respect Non Ac Low Floor City NCR Service Only For The Month Of January2021FleetItsUtillization
        public DataTable GetDataDepotWiseOperDataRespenonACAcLowFloorCityNCRServFleetItsUtillization_Page17n18(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptDepotWiseOprDataRFleetItsUtillization", param);
            return dt;
        }

        // DWODTripsScheduledOperated
        public DataTable GetDataDWODTripsScheduledOperated_Page19n20(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rpttbl_DWODTripsScheduledAndOperated", param);
            return dt;
        }

        //DWOD in respect of non ac low floor city & ncr ANALYSIS OF KILOMETER

        public DataTable GetDataDWODResNonAcAcAnalysisOfKilometers_Page21n22(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyAnalysisOfKilometers", param);
            return dt;
        }

        //DWOD in respect of non ac low floor city & ncr TRAFFIC INCOME

        public DataTable GetDataDWODResNonAcAcTrafficIncome_Page23n24(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyTrafficIncome", param);
            return dt;
        }


        // Accident Analysis non ac low floor city & ncr For The Month

        public DataTable GetDataAccidentAnalysisForTheMonth_Page25n26(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptAccidentAnalysisForTheMonth", param);
            return dt;
        }

        // Depot Wise Oprational Data In Respect Of NonAC

        public DataTable GetDataDepotWiseOprationalDataInRespectOfNonAC_Page27(int OsbId, int Year, int Month)
        {


            DateTime currentDate = new DateTime(Year, Month, 01);
            String[,] param = new string[,]
                {
                    { "@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptDepotWiseOprationalDataInRespectOfNonAC", param);
            return dt;
        }

        // No Of Trips Actual Operated On Time And No Of Trips Actual Operated

        public DataTable GetDataTripsActualOperatedOnTimeNOperated2min_Page28(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptNoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated", param);
            return dt;
        }

        //DepotWise Total Missed Kms And Breakdowns

        public DataTable GetDataDepotWiseTotalMissedKmsAndBreakdowns_Page29(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptDepotWiseTotalMissedKmsAndBreakdowns", param);
            return dt;
        }

        // Comparative Analysis Of Causes Of Accidents

        public DataTable GetDataComparativeAnalysisOfCausesOfAccidentsMonthly_Page30(int OsbId)
        {

            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptComparativeAnalysisOfCausesOfAccidents", param);

            return dt;
        }

        // Accident Analysis by other party involvement 

        public DataTable GetDataAccidentAnalysisOtherPartyInvolvment_Page30_tbl2(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptAccidentAnalysisOtherPartyInvolvment", param);
            return dt;
        }


        // Analysis of accidents by driver group 

        public DataTable GetDataAnalysisOfAccidentsByDriverGroup_Page30_tbl3(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptAnalysisOfAccidentsByDriverGroup", param);
            return dt;
        }

        // Statement of passes for the month of

        public DataTable GetDataStatementOfForTheMonthOfPasses_Page31n32(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptStatementOfForTheMonthOfPasses", param);
            return dt;
        }

        //  depot wise statment of school buses ,spl hire, tourist, pass and pink ticket earning

        public DataTable GetDataDWSPLHireTouristPassPinkTicketEarning_Page33n34(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptDeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarning", param);
            return dt;
        }


        // Statement showing operational data of ncr cng services of the corporation
        public DataTable GetDataDWSPLHireTouristPassPinkTicketEarning_Page35(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptStatementShowingOperationalDataOfNcrCngServicesOfTheCorporation", param);
            return dt;
        }


        // Depot wise operational data of FCMS (cluster buses) Fleet and its utilization

        public DataTable GetDataDWODFCMSFleetItsUtilization_Page36_tbl1(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_DWODFCMSFleetItsUtilization", param);
            return dt;
        }

        // Depot wise operational data of FCMS (cluster buses) Traffic Income

        public DataTable GetDataDWODFCMSTrafficIncome_Page36_tbl2(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptDepotwiseOperationalDataFCMSCluster_busesTrafficIncome", param);
            return dt;
        }
        //NCR AND CITY
        // Statement Showing The Income Expewditure In Respect Of City NCR Foreign Bus Service 

        public DataTable GetDataStatShowingIncomeNExpenditureRespectFBS_Page36(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptStatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs", param);
            return dt;
        }

        // NCR AND CITY
        // Statement Showing The Income Expewditure In Respect Of City NCR Foreign Bus Service 

        public DataTable GetDataStatemShowingIncomeNExpenditureCityNcr_Page39(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_rptStatemnetShowingTheInRespectOfCityNcrAndForeignBusService", param);
            return dt;
        }


        //<-----------BAR GRAPH PIE CHART----------->


        // Bar Fleet and its utilization






        // this Bar gets generated through live data(from database) thats why it has month and year parameter but not OSBID
        public DataTable GetDataBarFleetNUtilization_Page38_graph1(int Year, int Month)
        {
            var MonthList = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            DateTime currentDate = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate.AddYears(0);
            string currentYear = currentDate.Year.ToString();
            string previousYear = newDate.Year.ToString();
            String previousMonthName = newDate.ToString("MMMM");
            String[,] param = new string[,]
                   {
                   {"@Month",Month.ToString().Trim()},
                   {"@Year",previousYear.ToString().Trim()},
                };
            DataTable dt = Common.ExecuteProcedure("SP_BarFleetNUtilization", param);
            return dt;
        }

        // Bar operational ratio
        public DataTable GetDataBarOperationalRatio_Page38_graph2(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString().Trim()},

                };
            DataTable dt = Common.ExecuteProcedure("sp_BarOperationalRatio", param);
            return dt;
        }

        // BAR KILOMETER EFFICENCY

        public DataTable GetDataBarKilometersefficiency_Page38_graph3(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString().Trim()},

                };
            DataTable dt = Common.ExecuteProcedure("Sp_BarKilometersefficiency", param);
            return dt;
        }

        // Traffic earning in crore

        public DataTable GetDataBarTrafficEarninginCrore_Page39_graph1(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()}

                };
            DataTable dt = Common.ExecuteProcedure("rpt.BarTrafficearning ", param);
            return dt;
        }

        // Earning per bus per day

        public DataTable GetDataBarEarningPerBusPerDay_Page39_graph2(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString().Trim()},

                };
            DataTable dt = Common.ExecuteProcedure("Sp_BarEarningPerBusPerDay", param);
            return dt;
        }

        // passengers in carried

        public DataTable GetDataBarPassengerInCarried_Page39_graph3(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()}

                };
            DataTable dt = Common.ExecuteProcedure("rpt.BarPassengerCarried ", param);
            return dt;
        }

        //pie chart TRAFFIC EARNING FOR THE MONTH

        public DataTable GetDataBarPassengerInCarried_Page41_pie1(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };

            DataTable dt = Common.ExecuteProcedure("sp_BarPieChartTrafficEarning", param);
            return dt;
        }

        // PIE CHART EXPENDITURE FOR THE MONTH

        public DataTable GetDataBarPassengerInCarried_Page41_pie2(int OsbId)
        {
            String[,] param = new string[,]
                   {
                     {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("sp_PieChartExpenditureForTheMonth", param);
            return dt;
        }













    }

}
