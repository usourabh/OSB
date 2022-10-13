using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperationalStatisticsBook
{
    public partial class MainDashboard : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string FinYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);
        public MainDashboard()
        {
            InitializeComponent();
            BindFinYear(DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString());
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (cbFinYear.Text != "" && cbMonth.Text != "")
            {
                this.FinYear = cbFinYear.Text;
                this.Month = GlobalMaster.GetMonthNumber(cbMonth.Text);
                this.MonthName = cbMonth.Text;
                if (Month <= 3)
                    this.Year = (Convert.ToInt32(cbFinYear.Text.Split('-')[1]) + 2000);
                else
                    this.Year = (Convert.ToInt32(cbFinYear.Text.Split('-')[0]));

                OsbId = GetOsbId(cbFinYear.Text, cbMonth.Text, Year);
                GetFinMaster(cbFinYear.Text);
                dataGridView1.DataSource = BindMasterData();
            }
            else
                MessageBox.Show("Pls Select Fin Year and Month");

        }
        void BindFinYear(string year, string month)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("[rpt].[sp_GetFinMaster]", con);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                cbFinYear.DataSource = dt;
                cbFinYear.DisplayMember = "FinVal";
                cbFinYear.ValueMember = "FinVal";
            }
            catch (Exception ex)
            {

            }

        }
        int GetOsbId(string FinYear, string _month,int _year)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("[rpt].[sp_GetReportId]", con);
            cmd.Parameters.AddWithValue("@FinYear", FinYear);
            cmd.Parameters.AddWithValue("@ForMonth", GlobalMaster.GetMonthNumber(_month));
            cmd.Parameters.AddWithValue("@ForYear", _year);
            cmd.Parameters.AddWithValue("@CreatedBy", "");
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            try
            {
                i = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

            }
            con.Close();

            return i;
        }
        void GetFinMaster(string Finyear)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("[rpt].[sp_GetFinYearByFinYear]", con);
                cmd.Parameters.AddWithValue("@FinVal", Finyear);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    GlobalMaster.FinMaster.Add(new FinMasterInfo() { FinId = Convert.ToInt32(dr[0]), FinVal = Convert.ToString(dr[01]), StartDate = Convert.ToDateTime(dr[2]), EndDate = Convert.ToDateTime(dr[3]) });
                }
            }
            catch (Exception ex)
            {

            }

        }
        DataTable BindMasterData()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("SNO", typeof(string)),
                            new DataColumn("ReportName", typeof(string)),new DataColumn("FrmName", typeof(string))});

            dt.Rows.Add("1", "Index Page", "frmOSBMain");
            dt.Rows.Add("2", "Performance of DTC at a Glance", "frmPerformanceofDTCGlance");
            dt.Rows.Add("3", "PROGRESSIVE FINANCIAL RESULTS (Rs. In Lakh)", "progressiveFinancialResults");
            //dt.Rows.Add("4", "STAFF RATIO AS ON 28th FEBRUARY-2022", "");
            dt.Rows.Add("4", "ANALYSIS OF CAUSES OF ACCIDENTS FROM 2019-20 TO 2020-21", "analysisOfCausesAccidents");
            dt.Rows.Add("5", " GROWTH OF BASIC STRUCTURE OF D.T.C.", "SalientFeatureGrowthBasicStructure");
            dt.Rows.Add("6", " ROUTES OPERATED BY D.T.C.", "RoutesOperatedByDtc");
            dt.Rows.Add("7", "COMPARATIVE FINANCIAL RESULTS FROM", "ComparativeFinancialResultsFrom");
            dt.Rows.Add("8", "Comparative operational data for the period (April to March) 2018-19 to 2020-21", "ComparativeOperationalData");
           // dt.Rows.Add("10", "DISTRUBUTION OF FLEET BY TYPE/MAKE AND YEAR OF COMMISSION", "");
            dt.Rows.Add("9", "PRICE AND COST INDICES (2015-16 to 2019-20)", "PriceAndCostIndicies");
            dt.Rows.Add("10", "Material Consumption from 2018-19 to 2020-21", "MaterialConsumptionFrom");
           // dt.Rows.Add("13", "PERFORMANCE OF METROPOLITIN TRANSPORT UNDERTAKING", "");
            dt.Rows.Add("11", "Accidents and Compensation given to Accident Victims April to March (2011-12 to 2020-21)", "AccidentNCompensationGvnAccidentVictims");
            //dt.Rows.Add("15", "DEPOT- WISE FLEET STRENGTH & BUSES ON ROAD AS ON 28th FEBRUARY-2022", "");        
           // dt.Rows.Add("16", "Routes operated by DTC and its Earning Per Killometer January-2022", "");
           // dt.Rows.Add("17", "Statement showing Region Wise Operational Data for the month of February - 2022", "");
            dt.Rows.Add("12", "DETAILS OF OPERATIONAL DATA", "DetailsofOperationaldataforthemonthofJuly");
           // dt.Rows.Add("19", "FOR THE MONTH OF FEBRUARY-2022 (SUMMARY)", "");
          //  dt.Rows.Add("20", "Depot- wise Oprational Data Fleet & For the month of", "");
            //dt.Rows.Add("21", "in respect of Non AC & AC Low Floor City service only", "");
           // dt.Rows.Add("13", "Depot- wise Oprational Data For the month of Trips Scheduled", "");
          //  dt.Rows.Add("23", "in respect of Non AC & AC Low Floor City service only", "");
          //  dt.Rows.Add("24", "Depot- wise Oprational Data for the month of Analysis", "");
          //  dt.Rows.Add("25", "in respect of Non AC & AC Low Floor City service only February-2022 of Kilometers", "");
           // dt.Rows.Add("26", "Depot- wise Oprational Data TRAFFIC for the month of", "");
           // dt.Rows.Add("27", "in respect of Non AC & AC Low Floor City service only February-2022 of Income", "");
            dt.Rows.Add("13", "Accident Analysis By Other Party Involvement", "AccidentAnalysisOtherPartyInvolvment");
            //dt.Rows.Add("29", "(Non AC & AC Low Floor City service only)", "");
          //  dt.Rows.Add("30", "Depot- wise Oprational Data (in respect of Non AC & AC Low Floor City service only)", "");
           // dt.Rows.Add("31", "No. of trips actual operated on time and No. of trips actual operated within two minutes. for the month of Febuary - 2022", "");
           
            dt.Rows.Add("14", "Comparative Analysis of causes of Accidents for the month of July - 2022 & July - 2021", "ComparativeAnalysisOfCausesOfAccidents");
            dt.Rows.Add("15", "Operational data Depot wise fleet strength & buses on road as on 31st July-2022", "OperationalDepotWiseFleetStrengthNBusesOnRoad");
            dt.Rows.Add("16", "Statement showing Region Wise Operational Data for the month of January 2021", "StatementShowingRegionWiseOperationalDataForTheMonth");
            dt.Rows.Add("17", "Depot- wise Oprational Data (in respect of Non AC & AC Low Floor City + NCR service only) For the month of january 2021 Traffic Income", "DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome");
            dt.Rows.Add("18", "Depot- wise Oprational Data (in respect of Non AC & AC Low Floor City + NCR service only)for the month of January 2021 Analysis of Kilometers", "DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021AnalysisOfKilometers");
            dt.Rows.Add("19", "Statement Showing Operational Data of NCR CNG Services of the Corporation for the month of January 2021", "StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022");
            dt.Rows.Add("20", "Statemnet showing the in respect of City, NCR & Foreign bus service(Income & Expewnditure June - 2022 in lakhs)", "StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022Inlakhs");

            dt.Rows.Add("21", "Depot- wise Oprational Data (in respect of Non AC & AC Low Floor City service only)", "DepotWiseOprationalDataInRespectOfNonAC");
            dt.Rows.Add("22", "No. of trips actual operated on time and No. of trips actual operated within two minutes. for the month of Febuary - 2022", "NoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated");
            dt.Rows.Add("23", "Analysis of Accidents by driver group", "AnalysisOfAccidentsByDriverGroup");
            dt.Rows.Add("24", "Accident Analysis Of for the month of (Non AC & AC Low Floor City & NCR service only)", "AccidentAnalysisForTheMonth");
            dt.Rows.Add("25", "Statement Of for the month of Passes", "StatementOfForTheMonthOfPasses");
            dt.Rows.Add("26", "Category wise Staff Position as on 31st January-2021", "CategorywiseStaffPositionAsOn");
            dt.Rows.Add("27", "Depot wise total missed kms and breakdowns for the month of July-2022", "DepotWiseTotalMissedKmsAndBreakdowns");

            dt.Rows.Add("28", "DEPOT WISE STATEMENT OF SCHOOL , SPL. HIRE ,TOURIST, PASS & PINK TICKET EARNING For the month of january 2021", "DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarning");
            dt.Rows.Add("29", "Routes operated by DTC and its Earning per Killometer June-2022", "RoutesOperatedByDTCEarningPerKillometerJune");
            dt.Rows.Add("30", "Distrubution fof fleet by type/make and year of commission", "DistrubutionOfFleetByTypeMakeAndYearOfCommission");
            dt.Rows.Add("31", "Depot Wise Oprational Data(inRespectOfNonAC & AC LowFloor City NCR Service Only For The Month Of January 2021 Fleet & ItsUtillization)", "DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization");
            dt.Rows.Add("32", "Depot-wise Operational Data Trips Scheduled and Operated)", "DepotWiseOperationalDataInRespectOfNonAcAndAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TripsScheduledAndOperated");
            dt.Rows.Add("33", "Statemnet showing the(Rs. in respect of City, NCR & Foreign bus service(Income & Expewnditure June - 2022 in lakhs)", "StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs");


            dt.Rows.Add("34", "Depot wise operational data of FCMS Fleet & its utiuzation", "DWODFCMSFleetItsUtilization");
            dt.Rows.Add("35", "Performance of Metopolitan Transport Undertaking", "PerformanceMetopolitanTransportUndertaking");
            dt.Rows.Add("36", "Staff Ratio as on 31st July-2022", "StaffRatioAsOn");
            dt.Rows.Add("37", "Depot wise Operational Data FCMS Cluster buses Traffic Income", "DepotwiseOperationalDataFCMSCluster_busesTrafficIncome");

            //dt.Rows.Add("32", "ROUTES OPERATED BY D.T.C.", "RoutesOperatedByDtc");
            //dt.Rows.Add("3", "");
            //dt.Rows.Add("3", "");
            //dt.Rows.Add("3", "");
            //dt.Rows.Add("3", "");
            //dt.Rows.Add("3", "");
            //dt.Rows.Add("3", "");
            //dt.Rows.Add("3", "");
            //dt.Rows.Add("3", "");
            //dt.Rows.Add("3", "");
            //dt.Rows.Add("3", "");

            return dt;

        }
        private void MainDashboard_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "Veiw_Report";
                button.HeaderText = "View Report";
                button.Text = "View Report";
                button.UseColumnTextForButtonValue = true; //dont forget this line
                this.dataGridView1.Columns.Add(button);
                this.dataGridView1.Columns[2].FillWeight = 10;
                this.dataGridView1.Columns[3].FillWeight = 10;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string frmName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                if (frmName == "frmOSBMain")
                {
                    frmOSBMain objFrm = new frmOSBMain(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "frmPerformanceofDTCGlance")
                {
                    frmPerformanceofDTCGlance objFrm = new frmPerformanceofDTCGlance(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "progressiveFinancialResults")
                {
                    progressiveFinancialResults objFrm = new progressiveFinancialResults(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "analysisOfCausesAccidents")
                {
                    analysisOfCausesAccidents objFrm = new analysisOfCausesAccidents(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "ComparativeOperationalData")
                {
                    ComparativeOperationalData objFrm = new ComparativeOperationalData(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "PriceAndCostIndicies")
                {
                    PriceAndCostIndicies objFrm = new PriceAndCostIndicies(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "MaterialConsumptionFrom")
                {
                    MaterialConsumptionFrom objFrm = new MaterialConsumptionFrom(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "AccidentNCompensationGvnAccidentVictims")
                {
                    AccidentNCompensationGvnAccidentVictims objFrm = new AccidentNCompensationGvnAccidentVictims(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "SalientFeatureGrowthBasicStructure")
                {
                    SalientFeatureGrowthBasicStructure objFrm = new SalientFeatureGrowthBasicStructure(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "AccidentAnalysisOtherPartyInvolvment")
                {
                    AccidentAnalysisOtherPartyInvolvment objFrm = new AccidentAnalysisOtherPartyInvolvment(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "RoutesOperatedByDtc")
                {
                    RoutesOperatedByDtc objFrm = new RoutesOperatedByDtc(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "DetailsofOperationaldataforthemonthofJuly")
                {
                    DetailsofOperationaldataforthemonthofJuly objFrm = new DetailsofOperationaldataforthemonthofJuly(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "ComparativeFinancialResultsFrom")
                {
                    ComparativeFinancialResultsFrom objFrm = new ComparativeFinancialResultsFrom(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "analysisOfCausesAccidents")
                {
                    analysisOfCausesAccidents objFrm = new analysisOfCausesAccidents(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "ComparativeAnalysisOfCausesOfAccidents")
                {
                    ComparativeAnalysisOfCausesOfAccidents objFrm = new ComparativeAnalysisOfCausesOfAccidents(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "OperationalDepotWiseFleetStrengthNBusesOnRoad")
                {
                    OperationalDepotWiseFleetStrengthNBusesOnRoad objFrm = new OperationalDepotWiseFleetStrengthNBusesOnRoad(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }

                else if (frmName == "StatementShowingRegionWiseOperationalDataForTheMonth")
                {
                    StatementShowingRegionWiseOperationalDataForTheMonth objFrm = new StatementShowingRegionWiseOperationalDataForTheMonth(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome")
                {
                    DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome objFrm = new DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021AnalysisOfKilometers")
                {
                    DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021AnalysisOfKilometers objFrm = new DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021AnalysisOfKilometers(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }

                else if (frmName == "StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022")
                {
                    StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022 objFrm = new StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022Inlakhs")
                {
                    StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022Inlakhs objFrm = new StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022Inlakhs(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "DepotWiseTotalMissedKmsAndBreakdowns")
                {
                    DepotWiseTotalMissedKmsAndBreakdowns objFrm = new DepotWiseTotalMissedKmsAndBreakdowns(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarning")
                {
                    DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarning objFrm = new DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarning(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "RoutesOperatedByDTCEarningPerKillometerJune")
                {
                    RoutesOperatedByDTCEarningPerKillometerJune objFrm = new RoutesOperatedByDTCEarningPerKillometerJune(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }

                else if (frmName == "DistrubutionOfFleetByTypeMakeAndYearOfCommission")
                {
                    DistrubutionOfFleetByTypeMakeAndYearOfCommission objFrm = new DistrubutionOfFleetByTypeMakeAndYearOfCommission(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization")
                {
                    DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization objFrm = new DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "DepotWiseOperationalDataInRespectOfNonAcAndAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TripsScheduledAndOperated")
                {
                    DepotWiseOperationalDataInRespectOfNonAcAndAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TripsScheduledAndOperated objFrm = new DepotWiseOperationalDataInRespectOfNonAcAndAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TripsScheduledAndOperated(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs")
                {
                    StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs objFrm = new StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "DepotWiseOprationalDataInRespectOfNonAC")
                {
                    DepotWiseOprationalDataInRespectOfNonAC objFrm = new DepotWiseOprationalDataInRespectOfNonAC(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }

                else if (frmName == "NoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated")
                {
                    NoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated objFrm = new NoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }

                else if (frmName == "AnalysisOfAccidentsByDriverGroup")
                {
                    AnalysisOfAccidentsByDriverGroup objFrm = new AnalysisOfAccidentsByDriverGroup(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "AccidentAnalysisForTheMonth")
                {
                    AccidentAnalysisForTheMonth objFrm = new AccidentAnalysisForTheMonth(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }

                else if (frmName == "StatementOfForTheMonthOfPasses")
                {
                    StatementOfForTheMonthOfPasses objFrm = new StatementOfForTheMonthOfPasses(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "CategorywiseStaffPositionAsOn")
                {
                    CategorywiseStaffPositionAsOn objFrm = new CategorywiseStaffPositionAsOn(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "DWODFCMSFleetItsUtilization")
                {
                    DWODFCMSFleetItsUtilization objFrm = new DWODFCMSFleetItsUtilization(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "PerformanceMetopolitanTransportUndertaking")
                {
                    PerformanceMetopolitanTransportUndertaking objFrm = new PerformanceMetopolitanTransportUndertaking(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "StaffRatioAsOn")
                {
                    StaffRatioAsOn objFrm = new StaffRatioAsOn(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "DepotwiseOperationalDataFCMSCluster_busesTrafficIncome")
                {
                    DepotwiseOperationalDataFCMSCluster_busesTrafficIncome objFrm = new DepotwiseOperationalDataFCMSCluster_busesTrafficIncome(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
            }
        }
    }
}
