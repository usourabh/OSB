using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using Warning = Microsoft.Reporting.WinForms.Warning;

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

        int GetOsbId(string FinYear, string _month, int _year)
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

            dt.Rows.Add(" ", "Index Page", "frmOSBMain");
            dt.Rows.Add(" ", "Performance of DTC at a Glance", "frmPerformanceofDTCGlance");
            dt.Rows.Add(" ", "PROGRESSIVE FINANCIAL RESULTS (Rs. In Lakh)", "progressiveFinancialResults");

            dt.Rows.Add(" ", "Staff Ratio as on ", "StaffRatioAsOn");
            dt.Rows.Add("1.1", "Analysis of causes of Accidents ", "analysisOfCausesAccidents");
            dt.Rows.Add("1.2", "Growith of basic structure of DTC", "SalientFeatureGrowthBasicStructure");
            dt.Rows.Add("1.3", "ROUTES OPERATED BY DTC.", "RoutesOperatedByDtc");
            dt.Rows.Add("1.4", "Comparative Financial Results Year ", "ComparativeFinancialResultsFrom");
            dt.Rows.Add("1.5", "Comparative operational data for the period (April to March) ", "ComparativeOperationalData");
            dt.Rows.Add("1.6", "Distrubution of fleet by type/make and year of commission", "DistrubutionOfFleetByTypeMakeAndYearOfCommission");
            dt.Rows.Add("1.7", "PRICE AND COST INDICES ", "PriceAndCostIndicies");
            dt.Rows.Add("1.8", "Material Consumption from ", "MaterialConsumptionFrom");
            dt.Rows.Add("1.9", "Performance of Metopolitan Transport Undertaking ", "PerformanceMetopolitanTransportUndertaking");
            dt.Rows.Add("1.10", "Accidents and Compensation given to Accident Victims April to March ", "AccidentNCompensationGvnAccidentVictims");
            dt.Rows.Add("1.11", "Operational data Depot wise fleet strength & buses on road as on", "OperationalDepotWiseFleetStrengthNBusesOnRoad");
            dt.Rows.Add("2", "Category wise Staff Position as on ", "CategorywiseStaffPositionAsOn");
            dt.Rows.Add("3.1", "Routes operated by DTC and its Earning per Killometer ", "RoutesOperatedByDTCEarningPerKillometerJune");
            dt.Rows.Add("3.2", "Statement showing Region Wise Operational Data for the month of ", "StatementShowingRegionWiseOperationalDataForTheMonth");
            dt.Rows.Add("3.3", "DETAILS OF OPERATIONAL DATA", "DetailsofOperationaldataforthemonthofJuly");
            dt.Rows.Add("4.1", "Depot Wise Oprational Data(inRespectOfNonAC & AC LowFloor City NCR Service Only For The Month Of Fleet & ItsUtillization)", "DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization");
            dt.Rows.Add("4.2", "Depot-wise Operational Data Trips Scheduled and Operated)", "DepotWiseOperationalDataInRespectOfNonAcAndAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TripsScheduledAndOperated");
            dt.Rows.Add("4.3", "Depot- wise Oprational Data (in respect of Non AC & AC Low Floor City + NCR service only)for the month of Analysis of Kilometers", "DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021AnalysisOfKilometers");
            dt.Rows.Add("4.4", "Depot- wise Oprational Data (in respect of Non AC & AC Low Floor City + NCR service only) For the month of Traffic Income", "DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome");
            dt.Rows.Add("4.5", "Accident Analysis Of for the month of (Non AC & AC Low Floor City & NCR service only)", "AccidentAnalysisForTheMonth");
            dt.Rows.Add("4.6", "Depot- wise Oprational Data (in respect of Non AC & AC Low Floor City service only)", "DepotWiseOprationalDataInRespectOfNonAC");
            dt.Rows.Add("4.7", "No. of trips actual operated on time and No. of trips actual operated within two minutes. for the month of ", "NoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated");
            dt.Rows.Add("4.8", "Depot wise total missed kms and breakdowns for the month of", "DepotWiseTotalMissedKmsAndBreakdowns");
            dt.Rows.Add("5.1", "Comparative Analysis of causes of Accidents for the month of", "ComparativeAnalysisOfCausesOfAccidents");
            dt.Rows.Add("5.2", "Accident Analysis By Other Party Involvement", "AccidentAnalysisOtherPartyInvolvment");
            dt.Rows.Add("5.3", "Analysis of Accidents by driver group", "AnalysisOfAccidentsByDriverGroup");
            dt.Rows.Add("6.1", "Statement Of for the month of Passes", "StatementOfForTheMonthOfPasses");
            dt.Rows.Add("6.2", "DEPOT WISE STATEMENT OF SCHOOL , SPL. HIRE ,TOURIST, PASS & PINK TICKET EARNING For the month of", "DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarning");
            dt.Rows.Add("7.1", "Statement Showing Operational Data of NCR CNG Services of the Corporation for the month of", "StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022");
            dt.Rows.Add("8.1", "Depot wise operational data of FCMS Fleet & its utilization", "DWODFCMSFleetItsUtilization");
            dt.Rows.Add("8.2", "Depot wise Operational Data FCMS Cluster buses Traffic Income", "DepotwiseOperationalDataFCMSCluster_busesTrafficIncome");
            dt.Rows.Add("9", "Statemnet showing the(Rs. in respect of City, NCR & Foreign bus service(Income & Expewnditure in lakhs)", "StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs");
            dt.Rows.Add(" ", "Statemnet showing the in respect of City, NCR & Foreign bus service(Income & Expewnditure in lakhs)", "StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022Inlakhs");
            // dt.Rows.Add("", "Depot wise operational data of FCMS Fleet & its utiuzation", "DWODFCMSFleetItsUtilization");

            dt.Rows.Add("", "", "");

            //<-------------BARGRAPH AND PIE CHART------------>

            dt.Rows.Add(" ", "BAR GRPAPH Fleet Utilization ", "BarFleetNUtilizationGrid");
            dt.Rows.Add(" ", "BAR GRPAPH Operational ratio", "OperationalRatio");
            dt.Rows.Add(" ", "BAR GRPAPH Kilometers efficency", "Kilometersefficiency");
            dt.Rows.Add(" ", "BAR GRPAPH Traffic Earning", "BarTrafficEarning");
            dt.Rows.Add(" ", "BAR GRPAPH Earning per bus per day in Rs.", "EarningPerBusPerDay");
            dt.Rows.Add(" ", "BAR GRPAPH Passenger Carried", "BarPassengerCarried");
            dt.Rows.Add(" ", "PIE CHART Traffic Earning for the month ", "TRAFFICINCOMEFORTHEMONTH");
            dt.Rows.Add(" ", "PIE CHART Expenditure of  the month ", "EXPENDITUREFORTHEMONTH");
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
                else if (frmName == "rptFleetUtilization")
                {
                    rptFleetUtilization objFrm = new rptFleetUtilization(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }

                else if (frmName == "BarFleetNUtilizationGrid")
                {
                    BarFleetNUtilizationGrid objFrm = new BarFleetNUtilizationGrid(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "BarKilometersefficiency")
                {
                    BarKilometersefficiency objFrm = new BarKilometersefficiency(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "Kilometersefficiency")
                {
                    Kilometersefficiency objFrm = new Kilometersefficiency(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "TRAFFICINCOMEFORTHEMONTH")
                {
                    TRAFFICINCOMEFORTHEMONTH objFrm = new TRAFFICINCOMEFORTHEMONTH(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "EXPENDITUREFORTHEMONTH")
                {
                    EXPENDITUREFORTHEMONTH objFrm = new EXPENDITUREFORTHEMONTH(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }

                else if (frmName == "BarTrafficEarninginCrore")
                {
                    BarTrafficEarninginCrore objFrm = new BarTrafficEarninginCrore(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "BarPassengerInCarried")
                {
                    BarPassengerInCarried objFrm = new BarPassengerInCarried(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "BarTrafficEarning")
                {
                    BarTrafficEarning objFrm = new BarTrafficEarning(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "BarPassengerCarried")
                {
                    BarPassengerCarried objFrm = new BarPassengerCarried(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }

                else if (frmName == "BarOperationalRatio")
                {
                    BarOperationalRatio objFrm = new BarOperationalRatio(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "OperationalRatio")
                {
                    OperationalRatio objFrm = new OperationalRatio(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }

                else if (frmName == "BarEarningPerBusPerDay")
                {
                    BarEarningPerBusPerDay objFrm = new BarEarningPerBusPerDay(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }
                else if (frmName == "EarningPerBusPerDay")
                {
                    EarningPerBusPerDay objFrm = new EarningPerBusPerDay(OsbId, Year, Month, FinYear, MonthName);
                    objFrm.Show();
                }

            }
        }

        private void PrintAllReportOnClick(object sender, EventArgs e)
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
                GetSinglePagePDF();

            }
            else
                MessageBox.Show("Pls Select Fin Year and Month");
        }

        private void GetSinglePagePDF()
        {
            AllPageDataContext objPageData = new AllPageDataContext();

            List<byte[]> lstByte = new List<byte[]>();


            #region GetPagePdfs

            //INDEX PAGE

            string Page1ReportName = "rptIndexPrintPage.rdlc";
            string Page1DataSourceName = "rptIndexPrintPage";
            DataTable Page1Data = objPageData.GetIndexPageData_Page1(this.OsbId);
            byte[] byarry1 = GenerateReport(Page1ReportName, null, Page1DataSourceName, Page1Data);
            lstByte.Add(byarry1);


            //PERFORMANCE OF DTC GLANCE

            string Page2ReportName = "rptfrmPerformanceofDTCGlance.rdlc";
            string Page2DataSourceName = "rptfrmPerformanceofDTCGlance";
            DataTable Page2Data = objPageData.GetDataPerformanceDtcGlance_Page2_tbl1(this.OsbId);
            var MonthList = GlobalMaster.GetPrevousMonthList(Month, Year, 5);
            ReportParameter[] rptParam = new ReportParameter[5];
            rptParam[0] = new ReportParameter("txtDate1", MonthList[4].MonthName + "-" + MonthList[4].Year);
            rptParam[1] = new ReportParameter("txtDate2", MonthList[3].MonthName + "-" + MonthList[3].Year);
            rptParam[2] = new ReportParameter("txtDate3", MonthList[2].MonthName + "-" + MonthList[2].Year);
            rptParam[3] = new ReportParameter("txtDate4", MonthList[1].MonthName + "-" + MonthList[1].Year);
            rptParam[4] = new ReportParameter("txtDate5", MonthList[0].MonthName + "-" + MonthList[0].Year);
            byte[] byarry2 = GenerateReport(Page2ReportName, rptParam, Page2DataSourceName, Page2Data);
            lstByte.Add(byarry2);


            // PROGRESSIVE FINANCIAL RESULT

            string Page2ReportName2 = "rptprogressiveFinancialResults.rdlc";
            string Page2DataSourceName2 = "rptProgressiveFinancialResults";
            DataTable Page2Data2 = objPageData.GetDataProgressiveFinanResult_Page2_tbl2(this.OsbId);
            byte[] byarry3 = GenerateReport(Page2ReportName2, null, Page2DataSourceName2, Page2Data2);
            lstByte.Add(byarry3);


            //// STAFF RATIO

            string Page3ReportName1 = "rptStaffRatioAsOn.rdlc";
            string Page3DataSourceName1 = "rptStaffRatioAsOn";
            DataTable Page3Data1 = objPageData.GetDataStaffRatio_Page3_tbl1(this.OsbId, this.Year, this.Month);

            rptParam = new ReportParameter[1];

            DateTime currentDate = new DateTime(Year, Month, 01);
            int lastDayofTheMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            string lastDateForDistributionFleet = lastDayofTheMonth + "-" + currentDate.Month + "-" + currentDate.Year;

            rptParam[0] = new ReportParameter("ReportTitle", lastDayofTheMonth + "-" + MonthList[0].MonthName + "-" + MonthList[1].Year);

            byte[] byarry4 = GenerateReport(Page3ReportName1, rptParam, Page3DataSourceName1, Page3Data1);

            lstByte.Add(byarry4);


            // ANALYSIS OF CAUSES ACCIDENTS FROM

            string Page3ReportName2 = "rptanalysisOfCausesAccidents.rdlc";
            string Page3DataSourceName2 = "rptanalysisOfCausesAccidents";
            DataTable Page3Data2 = objPageData.GetDataAnalysisCausesAccidents_Page3_tbl2(this.OsbId);
            rptParam = new ReportParameter[3];
            rptParam[0] = new ReportParameter("ReportTitle", GlobalMaster.FinMaster[2].FinVal + " to " + GlobalMaster.FinMaster[1].FinVal);
            rptParam[1] = new ReportParameter("txtFrom", GlobalMaster.FinMaster[2].FinVal);
            rptParam[2] = new ReportParameter("txtTo", GlobalMaster.FinMaster[1].FinVal);
            byte[] byarry5 = GenerateReport(Page3ReportName2, rptParam, Page3DataSourceName2, Page3Data2);
            lstByte.Add(byarry5);


            // A SALIENT FEATURE GROWTH OF BASIC STRUCTURE OF DTC

            string Page4ReportName1 = "rptSalientFeatureGrowthBasicStructure.rdlc";
            string Page4DataSourceName1 = "rptSalientFeatureGrowthBasicStructure";
            DataTable Page4Data1 = objPageData.GetDataSalientGrowthBasicStructure_Page4_tbl1(this.OsbId);
            byte[] byarry6 = GenerateReport(Page4ReportName1, null, Page4DataSourceName1, Page4Data1);
            lstByte.Add(byarry6);


            //ROUTES OPERATED BY DTC 

            string Page4ReportName2 = "rptRoutesOperatedByDtc.rdlc";
            string Page4DataSourceName2 = "rptRoutesOperatedByDtc";
            DataTable Page4Data2 = objPageData.GetDataRoutesOperatedbyDTC_Page4_tbl2(this.OsbId);
            byte[] byarry7 = GenerateReport(Page4ReportName2, null, Page4DataSourceName2, Page4Data2);
            lstByte.Add(byarry7);


            //COMPARATIVE FINANCIAL RESULT

            string Page5n6ReportName = "rptComparativeFinancialResultsFrom.rdlc";
            string Page5n6DataSourceName = "rptComparativeFinancialResultsFrom";
            DataTable Page5n6Data = objPageData.GetDataComparativeFinanacialResult_Page5n6(this.OsbId);
            rptParam = new ReportParameter[4];
            rptParam[0] = new ReportParameter("ReportTitle", "Comparative Financial Results form (Rs " + GlobalMaster.FinMaster[4].FinVal + " to " + GlobalMaster.FinMaster[2].FinVal + " in lakh)");
            rptParam[1] = new ReportParameter("txtDate1", GlobalMaster.FinMaster[4].FinVal);
            rptParam[2] = new ReportParameter("txtDate2", GlobalMaster.FinMaster[3].FinVal);
            rptParam[3] = new ReportParameter("txtDate3", GlobalMaster.FinMaster[2].FinVal);
            byte[] byarry8 = GenerateReport(Page5n6ReportName, rptParam, Page5n6DataSourceName, Page5n6Data);
            lstByte.Add(byarry8);


            // COMPARATIVE OPERATIONAL DATA FOR THE FINANCIAL YEAR

            string Page7ReportName = "rptComparativeOperationalData.rdlc";
            string Page7DataSourceName = "rptComparativeOperationalData";
            DataTable Page7Data = objPageData.GetDataComparativeOperationalData_Page7(this.OsbId);
            rptParam = new ReportParameter[4];
            rptParam[0] = new ReportParameter("ReportTitle", GlobalMaster.FinMaster[3].FinVal + " to " + GlobalMaster.FinMaster[1].FinVal);
            rptParam[1] = new ReportParameter("txtDate1", GlobalMaster.FinMaster[3].FinVal);
            rptParam[2] = new ReportParameter("txtDate2", GlobalMaster.FinMaster[2].FinVal);
            rptParam[3] = new ReportParameter("txtDate3", GlobalMaster.FinMaster[1].FinVal);
            byte[] byarry9 = GenerateReport(Page7ReportName, rptParam, Page7DataSourceName, Page7Data);
            lstByte.Add(byarry9);


            // DISTRIBUTION OF FLEET BY TYPE/MAKE AND YEAR OF COMMISION

            string Page8ReportName = "rptDistributionOfFleetByTypeMake.rdlc";
            string Page8DataSourceName = "rptDistributionOfFleetByTypeMake";
            DataTable Page8Data = objPageData.GetDataDistributionFleetTypeMakeYearCommision_Page8(this.OsbId);
            var MonthList1 = GlobalMaster.GetPrevousMonthList(Month, Year, 5);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("txtDate", MonthList1[0].MonthName + "-" + MonthList1[1].Year);
            byte[] byarry10 = GenerateReport(Page8ReportName, rptParam, Page8DataSourceName, Page8Data);
            lstByte.Add(byarry10);

            // PRICE AND COST INDICIES

            string Page9ReportName1 = "rptPriceAndCostIndicies.rdlc";
            string Page9DataSourceName1 = "rptPriceAndCostIndicies";
            DataTable Page9Data1 = objPageData.GetDataPriceNCostIndicies_Page9_tbl1(this.OsbId);

            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", GlobalMaster.FinMaster[6].FinVal + " to " + GlobalMaster.FinMaster[2].FinVal);
            byte[] byarry11 = GenerateReport(Page9ReportName1, rptParam, Page9DataSourceName1, Page9Data1);
            lstByte.Add(byarry11);

            //MATERIAL CONSUMPTION 

            string Page9ReportName2 = "rptMaterialConsumptionFinancial.rdlc";
            string Page9DataSourceName2 = "MaterialConsumptionFinancial";
            DataTable Page9Data2 = objPageData.GetDataMaterialConsumption_Page9_tbl2(this.OsbId);
            rptParam = new ReportParameter[4];
            rptParam[0] = new ReportParameter("ReportTitle", GlobalMaster.FinMaster[3].FinVal + " to " + GlobalMaster.FinMaster[1].FinVal);
            rptParam[1] = new ReportParameter("txtDate1", GlobalMaster.FinMaster[3].FinVal);
            rptParam[2] = new ReportParameter("txtDate2", GlobalMaster.FinMaster[2].FinVal);
            rptParam[3] = new ReportParameter("txtDate3", GlobalMaster.FinMaster[1].FinVal);
            byte[] byarry12 = GenerateReport(Page9ReportName2, rptParam, Page9DataSourceName2, Page9Data2);
            lstByte.Add(byarry12);

            //PERFORMANCE OF METROPOLITIN TRANSPORT UNDERTAKING

            string Page10ReportName1 = "rptPerformanceMetopolitanTransportUndertaking.rdlc";
            string Page10DataSourceName1 = "PerformanceMetopolitanTransportUndertaking";
            DataTable Page10Data1 = objPageData.GetDataPerformMetroTransUnder_Page10_tbl1(this.OsbId);

            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", " (" + GlobalMaster.FinMaster[6].FinVal + ")");
            byte[] byarry13 = GenerateReport(Page10ReportName1, rptParam, Page10DataSourceName1, Page10Data1);
            lstByte.Add(byarry13);

            // ACCIDENTS AND COMPENSATION GIVEN TO ACCIDENT VICTIMS

            string Page10ReportName2 = "rptAccidentNCompensationGvnAccidentVictims.rdlc";
            string Page10DataSourceName2 = "rptAccidentNCompensationGvnAccidentVictims";
            DataTable Page10Data2 = objPageData.GetDataAccidentNCompensGvnAcciVic_Page10_tbl2(this.OsbId);

            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", "(" + GlobalMaster.FinMaster[10].FinVal + " to " + GlobalMaster.FinMaster[1].FinVal + ")");

            byte[] byarry14 = GenerateReport(Page10ReportName2, rptParam, Page10DataSourceName2, Page10Data2);
            lstByte.Add(byarry14);

            // OPERATIONAL DATA DEPOT WISE FLEET STRENGTH & BUSES ON ROAD

            string Page11ReportName = "rptOperationalDepotWiseFleetStrengthNBusesOnRoad.rdlc";
            string Page11DataSourceName = "rptOperationalDepotWiseFleetStrengthNBusesOnRoad";
            DataTable Page11Data = objPageData.GetDataOperaDepotWiseFleetStrenBusesOnRoad_Page11(this.OsbId);
            var MonthList2 = GlobalMaster.GetPrevousMonthList(Month, Year, 5);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList2[0].MonthName + "-" + MonthList2[1].Year);

            byte[] byarry15 = GenerateReport(Page11ReportName, rptParam, Page11DataSourceName, Page11Data);
            lstByte.Add(byarry15);

            // CATEGORYWISE STAFF POSITION AS ON 

            string Page12ReportName = "rptCategorywiseStaffPositionAsOn.rdlc";
            string Page12DataSourceName = "rptCategorywiseStaffPositionAsOn";
            DataTable Page12Data = objPageData.GetDataCategorywiseStaffPosition_Page12(this.OsbId);

            var MonthList3 = GlobalMaster.GetPrevousMonthList(Month, Year, 2);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("txtDate", MonthList3[0].MonthName + "-" + MonthList3[1].Year);

            byte[] byarry16 = GenerateReport(Page12ReportName, rptParam, Page12DataSourceName, Page12Data);
            lstByte.Add(byarry16);

            // ROUTES OPERATED BY DTC AND ITS EARNING PER KILOMETER

            string Page13ReportName = "rptRoutesOperatedByDTCEarningPerKillometer.rdlc";
            string Page13DataSourceName = "RoutesOperatedByDTCEarningPerKillometer";
            DataTable Page13Data = objPageData.GetDataRoutesOperatedByDTCEarningPerKm_Page13(this.OsbId);

            var MonthList4 = GlobalMaster.GetPrevousMonthList(Month, Year, 2);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList4[1].MonthName + "-" + MonthList4[1].Year);

            byte[] byarry17 = GenerateReport(Page13ReportName, rptParam, Page13DataSourceName, Page13Data);
            lstByte.Add(byarry17);

            // Statement Showing Region Wise Operational

            string Page14ReportName = "rptStatementShowingRegionalWiseOperational.rdlc";
            string Page14DataSourceName = "StatementShowingRegionalWiseOperational";
            DataTable Page14Data = objPageData.GetDataStatementShowRegionWiseOpera_Page14(this.OsbId);

            var MonthList5 = GlobalMaster.GetPrevousMonthList(Month, Year, 2);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList5[0].MonthName + "-" + MonthList5[1].Year);

            byte[] byarry18 = GenerateReport(Page14ReportName, rptParam, Page14DataSourceName, Page14Data);
            lstByte.Add(byarry18);

            // DETAILS OF OPERATIONAL DATA --------PAGE 1

            string Page15n16ReportNamePage1 = "rptDetailsofOperationaldata1.rdlc";
            string Page15n16DataSourceNamePage1 = "DetailsofOperationaldata";
            DataTable Page15n16DataPage1 = objPageData.GetDataDetailsofOperationaldata_Page15n16(this.OsbId);

            var MonthList6Page1 = GlobalMaster.GetPrevousMonthList(Month, Year, 2);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList6Page1[0].MonthName + "-" + MonthList6Page1[1].Year);

            byte[] byarry47 = GenerateReport(Page15n16ReportNamePage1, rptParam, Page15n16DataSourceNamePage1, Page15n16DataPage1);
            lstByte.Add(byarry47);

            // DETAILS OF OPERATIONAL DATA -------PAGE 2

            string Page15n16ReportNamePage2 = "rptDetailsofOperationaldata2.rdlc";
            string Page15n16DataSourceNamePage2 = "DetailsofOperationaldata";
            DataTable Page15n16DataPage2 = objPageData.GetDataDetailsofOperationaldata_Page15n16(this.OsbId);

            var MonthList6Page2 = GlobalMaster.GetPrevousMonthList(Month, Year, 2);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList6Page2[0].MonthName + "-" + MonthList6Page2[1].Year);

            byte[] byarry48 = GenerateReport(Page15n16ReportNamePage2, rptParam, Page15n16DataSourceNamePage2, Page15n16DataPage2);
            lstByte.Add(byarry48);

            // Depot Wise Oprational Data Respect Non Ac Low Floor City NCR Service Only For The Month Of January2021FleetItsUtillization Page1

            string Page17n18ReportNamePage1 = "rptDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization1.rdlc";
            string Page17n18DataSourceNamePage1 = "rptDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization";
            DataTable Page17n18DataPage1 = objPageData.GetDataDepotWiseOperDataRespenonACAcLowFloorCityNCRServFleetItsUtillization_Page17n18(this.OsbId);

            var MonthList7Page1 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList7Page1[0].MonthName + "-" + MonthList7Page1[1].Year);

            byte[] byarry56 = GenerateReport(Page17n18ReportNamePage1, rptParam, Page17n18DataSourceNamePage1, Page17n18DataPage1);
            lstByte.Add(byarry56);
            // Depot Wise Oprational Data Respect Non Ac Low Floor City NCR Service Only For The Month Of January2021FleetItsUtillization Page2

            string Page17n18ReportNamePage2 = "rptDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization2.rdlc";
            string Page17n18DataSourceNamePage2 = "rptDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization";
            DataTable Page17n18DataPage2 = objPageData.GetDataDepotWiseOperDataRespenonACAcLowFloorCityNCRServFleetItsUtillization_Page17n18(this.OsbId);

            var MonthList7Page2 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList7Page2[0].MonthName + "-" + MonthList7Page2[1].Year);

            byte[] byarry57 = GenerateReport(Page17n18ReportNamePage2, rptParam, Page17n18DataSourceNamePage2, Page17n18DataPage2);
            lstByte.Add(byarry57);

            //DWODTripsScheduledOperated ---------PAGE 1 CALLING

            string Page19n20ReportNamePage1 = "rptDWODTripsScheduledOperated.rdlc";
            string Page19n20DataSourceNamePage1 = "DWODTripsScheduledOperated";
            DataTable Page19n20DataPage1 = objPageData.GetDataDWODTripsScheduledOperated_Page19n20(this.OsbId);

            var MonthList8 = GlobalMaster.GetPrevousMonthList(Month, Year, 2);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList8[0].MonthName + "-" + MonthList8[1].Year);

            byte[] byarry21 = GenerateReport(Page19n20ReportNamePage1, rptParam, Page19n20DataSourceNamePage1, Page19n20DataPage1);
            lstByte.Add(byarry21);


            //DWODTripsScheduledOperated ---------PAGE 2 CALLING

            string Page19n20ReportNamePage2 = "rptDWODTripsScheduledOperated2.rdlc";
            string Page19n20DataSourceNamePage2 = "DWODTripsScheduledOperated";
            DataTable Page19n20DataPage2 = objPageData.GetDataDWODTripsScheduledOperated_Page19n20(this.OsbId);

            var MonthList8Page2 = GlobalMaster.GetPrevousMonthList(Month, Year, 2);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList8Page2[0].MonthName + "-" + MonthList8Page2[1].Year);

            byte[] byarry46 = GenerateReport(Page19n20ReportNamePage2, rptParam, Page19n20DataSourceNamePage2, Page19n20DataPage2);
            lstByte.Add(byarry46);


            //DWOD in respect of non ac low floor city & ncr ANALYSIS OF KILOMETER Page1

            string Page21n22ReportNamePage1 = "rptDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyAnalysisOfKilometers1.rdlc";
            string Page21n22DataSourceNamePage1 = "rptDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyAnalysisOfKilometers";
            DataTable Page21n22DataPage1 = objPageData.GetDataDWODResNonAcAcAnalysisOfKilometers_Page21n22(this.OsbId);

            var MonthList9Page1 = GlobalMaster.GetPrevousMonthList(Month, Year, 2);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList9Page1[0].MonthName + "-" + MonthList9Page1[1].Year);

            byte[] byarry49 = GenerateReport(Page21n22ReportNamePage1, rptParam, Page21n22DataSourceNamePage1, Page21n22DataPage1);
            lstByte.Add(byarry49);

            //DWOD in respect of non ac low floor city & ncr ANALYSIS OF KILOMETER Page2

            string Page21n22ReportNamePage2 = "rptDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyAnalysisOfKilometers2.rdlc";
            string Page21n22DataSourceNamePage2 = "rptDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyAnalysisOfKilometers";
            DataTable Page21n22DataPage2 = objPageData.GetDataDWODResNonAcAcAnalysisOfKilometers_Page21n22(this.OsbId);

            var MonthList9Page2 = GlobalMaster.GetPrevousMonthList(Month, Year, 2);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList9Page2[0].MonthName + "-" + MonthList9Page2[1].Year);

            byte[] byarry50 = GenerateReport(Page21n22ReportNamePage2, rptParam, Page21n22DataSourceNamePage2, Page21n22DataPage2);
            lstByte.Add(byarry50);

            //DWOD in respect of non ac low floor city & ncr TRAFFIC INCOME Page1

            string Page23n24ReportNamePage1 = "rptDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome1.rdlc";
            string Page23n24DataSourceNamePage1 = "rptDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome";
            DataTable Page23n24DataPage1 = objPageData.GetDataDWODResNonAcAcTrafficIncome_Page23n24(this.OsbId);

            var MonthList10Page1 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList10Page1[0].MonthName + "-" + MonthList10Page1[1].Year);

            byte[] byarry51 = GenerateReport(Page23n24ReportNamePage1, rptParam, Page23n24DataSourceNamePage1, Page23n24DataPage1);
            lstByte.Add(byarry51);
            //DWOD in respect of non ac low floor city & ncr TRAFFIC INCOME Page2

            string Page23n24ReportNamePage2 = "rptDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome2.rdlc";
            string Page23n24DataSourceNamePage2 = "rptDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome";
            DataTable Page23n24DataPage2 = objPageData.GetDataDWODResNonAcAcTrafficIncome_Page23n24(this.OsbId);

            var MonthList10Page2 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList10Page2[0].MonthName + "-" + MonthList10Page2[1].Year);

            byte[] byarry23 = GenerateReport(Page23n24ReportNamePage2, rptParam, Page23n24DataSourceNamePage2, Page23n24DataPage2);
            lstByte.Add(byarry23);

            // Accident Analysis non ac low floor city & ncr For The Month Page1

            string Page25n26ReportNamePage1 = "rptAccidentAnalysisForTheMonth1.rdlc";
            string Page25n26DataSourceNamePage1 = "rptAccidentAnalysisForTheMonth";
            DataTable Page25n26DataPage1 = objPageData.GetDataAccidentAnalysisForTheMonth_Page25n26(this.OsbId);

            var MonthList11Page1 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList11Page1[0].MonthName + "-" + MonthList11Page1[1].Year);

            byte[] byarry52 = GenerateReport(Page25n26ReportNamePage1, rptParam, Page25n26DataSourceNamePage1, Page25n26DataPage1);
            lstByte.Add(byarry52);
            // Accident Analysis non ac low floor city & ncr For The Month Page2

            string Page25n26ReportNamePage2 = "rptAccidentAnalysisForTheMonth2.rdlc";
            string Page25n26DataSourceNamePage2 = "rptAccidentAnalysisForTheMonth";
            DataTable Page25n26DataPage2 = objPageData.GetDataAccidentAnalysisForTheMonth_Page25n26(this.OsbId);

            var MonthList11Page2 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList11Page2[0].MonthName + "-" + MonthList11Page2[1].Year);

            byte[] byarry53 = GenerateReport(Page25n26ReportNamePage2, rptParam, Page25n26DataSourceNamePage2, Page25n26DataPage2);
            lstByte.Add(byarry53);

            // Depot Wise Oprational Data In Respect Of NonAC

            string Page27ReportName = "rptDepotWiseOprationalDataInRespectOfNonAC.rdlc";
            string Page27DataSourceName = "rptDepotWiseOprationalDataInRespectOfNonAC";
            DataTable Page27Data = objPageData.GetDataDepotWiseOprationalDataInRespectOfNonAC_Page27(this.OsbId, this.Year, this.Month);

            var MonthList12 = GlobalMaster.GetPrevousMonthList(Month, Year, 2);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList12[0].MonthName + "-" + MonthList12[1].Year);

            byte[] byarry25 = GenerateReport(Page27ReportName, rptParam, Page27DataSourceName, Page27Data);
            lstByte.Add(byarry25);

            // No Of Trips Actual Operated On Time And No Of Trips Actual Operated within two minutes

            var MonthList13 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            DateTime currentDate12 = new DateTime(Year, Month, 01);
            DateTime newDate = currentDate12.AddYears(+1);
            string currentYear = currentDate12.Year.ToString();
            string previousYear = newDate.Year.ToString();
            String previousMonthName = newDate.ToString("MMMM");

            string Page28ReportName = "rptNoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated.rdlc";
            string Page28DataSourceName = "rptNoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated";
            DataTable Page28Data = objPageData.GetDataTripsActualOperatedOnTimeNOperated2min_Page28(this.OsbId);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList13[0].MonthName + "-" + currentYear);
            byte[] byarry26 = GenerateReport(Page28ReportName, rptParam, Page28DataSourceName, Page28Data);
            lstByte.Add(byarry26);

            //DepotWise Total Missed Kms And Breakdowns

            string Page29ReportName = "rptDepotWiseTotalMissedKmsAndBreakdowns.rdlc";
            string Page29DataSourceName = "rptDepotWiseTotalMissedKmsAndBreakdowns";
            DataTable Page29Data = objPageData.GetDataDepotWiseTotalMissedKmsAndBreakdowns_Page29(this.OsbId);

            var MonthList21 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);

            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList21[0].MonthName + "-" + MonthList21[0].Year);

            byte[] byarry27 = GenerateReport(Page29ReportName, rptParam, Page29DataSourceName, Page29Data);
            lstByte.Add(byarry27);


            // Comparative Analysis Of Causes Of Accidents

            string Page30ReportName1 = "rptComparativeAnalysisOfCausesOfAccidents.rdlc";
            string Page30DataSourceName1 = "rptComparativeAnalysisOfCausesOfAccidents";
            DataTable Page30Data1 = objPageData.GetDataComparativeAnalysisOfCausesOfAccidentsMonthly_Page30(this.OsbId);

            var MonthList22 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            DateTime currentDate1 = new DateTime(Year, Month, 01);
            DateTime newDate1 = currentDate.AddYears(-1);
            string currentYear1 = currentDate1.Year.ToString();
            string previousYear1 = newDate1.Year.ToString();
            String previousMonthName1 = newDate.ToString("MMMM");
            rptParam = new ReportParameter[3];

            rptParam[0] = new ReportParameter("ReportTitle", MonthList22[0].MonthName + "-" + currentYear1 + " & " + MonthList22[0].MonthName + "-" + previousYear1);
            rptParam[1] = new ReportParameter("fromDate", MonthList22[0].MonthName + "-" + currentYear1);
            rptParam[2] = new ReportParameter("ToDate", MonthList22[0].MonthName + "-" + previousYear1);

            byte[] byarry28 = GenerateReport(Page30ReportName1, rptParam, Page30DataSourceName1, Page30Data1);
            lstByte.Add(byarry28);

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            // Accident Analysis by other party involvement 

            string Page30ReportName2 = "rptAccidentAnalysisOtherPartyInvolvment.rdlc";
            string Page30DataSourceName2 = "rptAccidentAnalysisOtherPartyInvolvment";
            DataTable Page30Data2 = objPageData.GetDataAccidentAnalysisOtherPartyInvolvment_Page30_tbl2(this.OsbId);

            var MonthList23 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            DateTime currentDate2 = new DateTime(Year, Month, 01);
            DateTime newDate2 = currentDate.AddYears(-1);
            string currentYear2 = currentDate2.Year.ToString();
            string previousYear2 = newDate2.Year.ToString();
            String previousMonthName2 = newDate.ToString("MMMM");
            rptParam = new ReportParameter[3];

            rptParam[0] = new ReportParameter("ReportTitle", MonthList23[0].MonthName + "-" + currentYear2 + " & " + MonthList23[0].MonthName + "-" + previousYear2);
            rptParam[1] = new ReportParameter("FromDate", MonthList23[0].MonthName + "-" + currentYear2);
            rptParam[2] = new ReportParameter("ToDate", MonthList23[0].MonthName + "-" + previousYear2);

            byte[] byarry29 = GenerateReport(Page30ReportName2, rptParam, Page30DataSourceName2, Page30Data2);
            lstByte.Add(byarry29);

            // Analysis of accidents by driver group 

            string Page30ReportName3 = "rptAnalysisOfAccidentsByDriverGroup.rdlc";
            string Page30DataSourceName3 = "rptAnalysisOfAccidentsByDriverGroup";
            DataTable Page30Data3 = objPageData.GetDataAnalysisOfAccidentsByDriverGroup_Page30_tbl3(this.OsbId);

            var MonthList24 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            DateTime currentDate3 = new DateTime(Year, Month, 01);
            DateTime newDate3 = currentDate.AddYears(-1);
            string currentYear3 = currentDate3.Year.ToString();
            string previousYear3 = newDate3.Year.ToString();
            String previousMonthName3 = newDate.ToString("MMMM");
            rptParam = new ReportParameter[3];

            rptParam[0] = new ReportParameter("ReportTitle", MonthList24[0].MonthName + "-" + currentYear3 + " & " + MonthList24[0].MonthName + "-" + previousYear3);
            rptParam[1] = new ReportParameter("FromDate", MonthList24[0].MonthName + "-" + currentYear3);
            rptParam[2] = new ReportParameter("ToDate", MonthList24[0].MonthName + "-" + previousYear3);

            byte[] byarry30 = GenerateReport(Page30ReportName3, rptParam, Page30DataSourceName3, Page30Data3);
            lstByte.Add(byarry30);

            // Statement of passes for the month of

            string Page31n32ReportName = "rptStatementOfForTheMonthOfPasses.rdlc";
            string Page31n32DataSourceName = "rptStatementOfForTheMonthOfPasses";
            DataTable Page31n32Data = objPageData.GetDataStatementOfForTheMonthOfPasses_Page31n32(this.OsbId);

            var MonthList25 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            DateTime currentDate4 = new DateTime(Year, Month, 01);
            DateTime newDate4 = currentDate.AddYears(+1);
            string currentYear4 = currentDate.Year.ToString();
            string previousYear4 = newDate.Year.ToString();
            String previousMonthName4 = newDate.ToString("MMMM");

            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList25[0].MonthName + "-" + currentYear4);


            byte[] byarry31 = GenerateReport(Page31n32ReportName, rptParam, Page31n32DataSourceName, Page31n32Data);
            lstByte.Add(byarry31);

            // depot wise statment of school buses ,spl hire, tourist, pass and pink ticket earning Page1

            string Page33n34ReportNamePage1 = "rptDWSPLHireTouristPassPinkTicketEarning1.rdlc";
            string Page33n34DataSourceNamePage1 = "DWSPLHireTouristPassPinkTicketEarning";
            DataTable Page33n34DataPage1 = objPageData.GetDataDWSPLHireTouristPassPinkTicketEarning_Page33n34(this.OsbId);

            var MonthList26Page1 = GlobalMaster.GetPrevousMonthList(Month, Year, 2);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList26Page1[0].MonthName + "-" + MonthList26Page1[1].Year);


            byte[] byarry54 = GenerateReport(Page33n34ReportNamePage1, rptParam, Page33n34DataSourceNamePage1, Page33n34DataPage1);
            lstByte.Add(byarry54);

            // depot wise statment of school buses ,spl hire, tourist, pass and pink ticket earning Page2

            string Page33n34ReportNamePage2 = "rptDWSPLHireTouristPassPinkTicketEarning2.rdlc";
            string Page33n34DataSourceNamePage2 = "DWSPLHireTouristPassPinkTicketEarning";
            DataTable Page33n34DataPage2 = objPageData.GetDataDWSPLHireTouristPassPinkTicketEarning_Page33n34(this.OsbId);

            var MonthList26Page2 = GlobalMaster.GetPrevousMonthList(Month, Year, 2);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList26Page2[0].MonthName + "-" + MonthList26Page2[1].Year);


            byte[] byarry55 = GenerateReport(Page33n34ReportNamePage2, rptParam, Page33n34DataSourceNamePage2, Page33n34DataPage2);
            lstByte.Add(byarry55);
            // Statement showing operational data of ncr cng services of the corporation

            string Page35ReportName = "rptStatementShowingOperationalDataOfNcrCngServicesOfTheCorporation.rdlc";
            string Page35DataSourceName = "rptStatementShowingOperationalDataOfNcrCngServicesOfTheCorporation";
            DataTable Page35Data = objPageData.GetDataDWSPLHireTouristPassPinkTicketEarning_Page35(this.OsbId);

            var MonthList27 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList27[0].MonthName + "-" + MonthList27[1].Year);

            byte[] byarry33 = GenerateReport(Page35ReportName, rptParam, Page35DataSourceName, Page35Data);
            lstByte.Add(byarry33);

            // Depot wise operational data of FCMS (cluster buses) Fleet and its utilization

            string Page36ReportName1 = "rptDWODFCMSFleetItsUtilization.rdlc";
            string Page36DataSourceName1 = "DWODFCMSFleetItsUtilization";
            DataTable Page36Data1 = objPageData.GetDataDWODFCMSFleetItsUtilization_Page36_tbl1(this.OsbId);

            var MonthList28 = GlobalMaster.GetPrevousMonthList(Month, Year, 2);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList28[0].MonthName + "-" + MonthList28[1].Year);


            byte[] byarry35 = GenerateReport(Page36ReportName1, rptParam, Page36DataSourceName1, Page36Data1);
            lstByte.Add(byarry35);


            // Depot wise operational data of FCMS (cluster buses) Traffic income

            string Page36ReportName2 = "rptDepotwiseOperationalDataFCMSCluster_busesTrafficIncome.rdlc";
            string Page36DataSourceName2 = "rptDepotwiseOperationalDataFCMSCluster_busesTrafficIncome";
            DataTable Page36Data2 = objPageData.GetDataDWODFCMSTrafficIncome_Page36_tbl2(this.OsbId);

            var MonthList29 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            DateTime currentDate5 = new DateTime(Year, Month, 01);
            DateTime newDate5 = currentDate.AddYears(+1);
            string currentYear5 = currentDate.Year.ToString();
            string previousYear5 = newDate.Year.ToString();
            String previousMonthName5 = newDate.ToString("MMMM");

            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList29[0].MonthName + "-" + currentYear5);

            byte[] byarry36 = GenerateReport(Page36ReportName2, rptParam, Page36DataSourceName2, Page36Data2);
            lstByte.Add(byarry36);


            // Statement Showing The Income Expewditure In Respect Of City NCR Foreign Bus Service 

            string Page37ReportName = "rptStatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs.rdlc";
            string Page37DataSourceName = "rptStatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs";
            DataTable Page37Data = objPageData.GetDataStatShowingIncomeNExpenditureRespectFBS_Page36(this.OsbId);


            byte[] byarry37 = GenerateReport(Page37ReportName, null, Page37DataSourceName, Page37Data);
            lstByte.Add(byarry37);



            //Statement Showing The Income Expewditure In Respect Of City NCR Foreign Bus Service


            //string Page60ReportName = "rptStatementShowingRespectCityNCRForeignBusService.rdlc";
            //string Page60DataSourceName = "rptStatementShowingRespectCityNCRForeignBusService";
            //DataTable Page60Data = objPageData.GetDataStatemShowingIncomeNExpenditureCityNcr_Page39(this.OsbId);

            //rptParam = new ReportParameter[1];
            //rptParam[0] = new ReportParameter("ReportTitle", MonthList[0].MonthName + "-" + MonthList[1].Year);

            //byte[] byarry58 = GenerateReport(Page60ReportName, null, Page60DataSourceName, Page60Data);
            //lstByte.Add(byarry58);









            //<-----------BAR GRAPH PIE CHART----------->


            // Bar Fleet and its utilization

            string Page38ReportName1 = "BarFleetNUtilization.rdlc";
            string Page38DataSourceName1 = "BarFleetNUtilization";
            DataTable Page38Data1 = objPageData.GetDataBarFleetNUtilization_Page38_graph1(Year, Month);

            var MonthList30 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            DateTime currentDate30 = new DateTime(Year, Month, 01);
            DateTime newDate30 = currentDate.AddYears(-1);
            string currentYear30 = currentDate30.Year.ToString();
            string previousYear30 = newDate30.Year.ToString();
            String previousMonthName30 = newDate.ToString("MMMM");

            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList30[0].MonthName + "-" + previousYear30 + " to " + MonthList30[0].MonthName + "-" + currentYear30);

            byte[] byarry38 = GenerateReport(Page38ReportName1, rptParam, Page38DataSourceName1, Page38Data1);
            lstByte.Add(byarry38);

            // Bar operational ratio

            string Page38ReportName2 = "BarOperationalRatio.rdlc";
            string Page38DataSourceName2 = "BarOperationalRatio";
            DataTable Page38Data2 = objPageData.GetDataBarOperationalRatio_Page38_graph2(this.OsbId);

            var MonthList31 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            DateTime currentDate31 = new DateTime(Year, Month, 01);
            DateTime newDate31 = currentDate.AddYears(-1);
            string currentYear31 = currentDate31.Year.ToString();
            string previousYear31 = newDate31.Year.ToString();
            String previousMonthName31 = newDate.ToString("MMMM");

            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList31[0].MonthName + "-" + previousYear31 + " to " + MonthList31[0].MonthName + "-" + currentYear31);

            byte[] byarry39 = GenerateReport(Page38ReportName2, rptParam, Page38DataSourceName2, Page38Data2);
            lstByte.Add(byarry39);

            // BAR KILOMETER EFFICENCY

            string Page38ReportName3 = "BarKilometersefficiency.rdlc";
            string Page38DataSourceName3 = "BarKilometersefficiency";
            DataTable Page38Data3 = objPageData.GetDataBarKilometersefficiency_Page38_graph3(this.OsbId);

            var MonthList32 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            DateTime currentDate32 = new DateTime(Year, Month, 01);
            DateTime newDate32 = currentDate.AddYears(-1);
            string currentYear32 = currentDate32.Year.ToString();
            string previousYear32 = newDate32.Year.ToString();
            String previousMonthName32 = newDate.ToString("MMMM");

            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList32[0].MonthName + "-" + previousYear32 + " to " + MonthList32[0].MonthName + "-" + currentYear32);

            byte[] byarry40 = GenerateReport(Page38ReportName3, rptParam, Page38DataSourceName3, Page38Data3);
            lstByte.Add(byarry40);

            // traffic earning in crore

            string Page39ReportName1 = "BarTrafficEarninginCrore.rdlc";
            string Page39DataSourceName1 = "BarTrafficEarninginCrore";
            DataTable Page39Data1 = objPageData.GetDataBarTrafficEarninginCrore_Page39_graph1(this.OsbId);


            var MonthList33 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            DateTime currentDate33 = new DateTime(Year, Month, 01);
            DateTime newDate33 = currentDate.AddYears(-1);
            string currentYear33 = currentDate33.Year.ToString();
            string previousYear33 = newDate33.Year.ToString();
            String previousMonthName33 = newDate.ToString("MMMM");



            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList33[0].MonthName + "-" + previousYear33 + " to " + MonthList33[0].MonthName + "-" + currentYear33);

            byte[] byarry41 = GenerateReport(Page39ReportName1, rptParam, Page39DataSourceName1, Page39Data1);
            lstByte.Add(byarry41);

            // Earning per bus per day

            string Page40ReportName2 = "BarEarningPerBusPerDay.rdlc";
            string Page40DataSourceName2 = "BarEarningPerBusPerDay";
            DataTable Page40Data2 = objPageData.GetDataBarEarningPerBusPerDay_Page39_graph2(this.OsbId);


            var MonthList34 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            DateTime currentDate34 = new DateTime(Year, Month, 01);
            DateTime newDate34 = currentDate.AddYears(-1);
            string currentYear34 = currentDate34.Year.ToString();
            string previousYear34 = newDate34.Year.ToString();
            String previousMonthName34 = newDate.ToString("MMMM");


            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList34[0].MonthName + "-" + previousYear34 + " to " + MonthList34[0].MonthName + "-" + currentYear34);

            byte[] byarry42 = GenerateReport(Page40ReportName2, rptParam, Page40DataSourceName2, Page40Data2);
            lstByte.Add(byarry42);

            // passenger in carried

            string Page40ReportName3 = "BarPassengerInCarried.rdlc";
            string Page40DataSourceName3 = "BarPassengerInCarried";
            DataTable Page40Data3 = objPageData.GetDataBarPassengerInCarried_Page39_graph3(this.OsbId);

            var MonthList35 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            DateTime currentDate35 = new DateTime(Year, Month, 01);
            DateTime newDate35 = currentDate.AddYears(-1);
            string currentYear35 = currentDate35.Year.ToString();
            string previousYear35 = newDate35.Year.ToString();
            String previousMonthName35 = newDate.ToString("MMMM");
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList35[0].MonthName + "-" + previousYear35 + " to " + MonthList35[0].MonthName + "-" + currentYear35);

            byte[] byarry43 = GenerateReport(Page40ReportName3, rptParam, Page40DataSourceName3, Page40Data3);
            lstByte.Add(byarry43);

            //TRAFFIC EARNING FOR THE MONTH

            string Page41ReportName1 = "PieTrafficEarningForTheMonthOf.rdlc";
            string Page41DataSourceName1 = "PieTrafficEarningForTheMonthOfMonth";
            DataTable Page41Data1 = objPageData.GetDataBarPassengerInCarried_Page41_pie1(OsbId);

            var MonthList36 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);
            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList36[0].MonthName + "-" + MonthList36[0].Year);


            byte[] byarry44 = GenerateReport(Page41ReportName1, rptParam, Page41DataSourceName1, Page41Data1);
            lstByte.Add(byarry44);

            // PIE CHART EXPENDITURE FOR THE MONTH

            string Page41ReportName2 = "PieExpenditureForTheMonthOf.rdlc";
            string Page41DataSourceName2 = "ExpenditureOfTheMonth";
            DataTable Page41Data2 = objPageData.GetDataBarPassengerInCarried_Page41_pie2(OsbId);

            var MonthList37 = GlobalMaster.GetPrevousMonthList(Month, Year, 02);

            rptParam = new ReportParameter[1];
            rptParam[0] = new ReportParameter("ReportTitle", MonthList37[1].MonthName + "-" + MonthList37[0].Year);

            byte[] byarry45 = GenerateReport(Page41ReportName2, rptParam, Page41DataSourceName2, Page41Data2);
            lstByte.Add(byarry45);


            #endregion



            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            string outputPdfPath = @"D:/newFile.pdf";
            MessageBox.Show("PDF GENERATED");
            try
            {


                sourceDocument = new Document();
                pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

                //output file Open  
                sourceDocument.Open();


                //files list wise Loop  
                for (int f = 0; f < lstByte.Count; f++)
                {
                    int pages = countpage(lstByte[f]);

                    if (lstByte[f] != null)
                    {
                        reader = new PdfReader(lstByte[f]);
                        //Add pages in new file  
                        for (int i = 1; i <= pages; i++)
                        {
                            importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                            pdfCopyProvider.AddPage(importedPage);
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            //save the output file  
            sourceDocument.Close();
        }

        private byte[] GenerateReport(string rdlcReportName, ReportParameter[] rptParam, string DataSourceName, DataTable dtReportData)
        {
            ReportViewer rdsAPP = new ReportViewer();

            ReportDataSource datasource = new ReportDataSource(DataSourceName, dtReportData);
            rdsAPP.LocalReport.ReportPath = rdlcReportName;
            rdsAPP.LocalReport.DataSources.Clear();
            rdsAPP.LocalReport.DataSources.Add(datasource);
            if (rptParam != null)
                if (rptParam.Count() > 0)
                    rdsAPP.LocalReport.SetParameters(rptParam);

            try
            {
                byte[] fByte = ConvertReportToPDF(rdsAPP.LocalReport);
                return fByte;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //countpage function is counting the no of pages in single rdlc

        public int countpage(byte[] pdfContent)
        {
            int pageCount;
            MemoryStream stream = new MemoryStream(pdfContent);
            using (var r = new StreamReader(stream))
            {
                string pdfText = r.ReadToEnd();
                System.Text.RegularExpressions.Regex regx = new Regex(@"/Type\s*/Page[^s]");
                System.Text.RegularExpressions.MatchCollection matches = regx.Matches(pdfText);
                pageCount = matches.Count;
            }
            return pageCount;
        }

        private byte[] ConvertReportToPDF(LocalReport rep)
        {
            string reportType = "PDF";
            string mimeType;
            string encoding;

            string deviceInfo = "<DeviceInfo>" +
               "  <OutputFormat>PDF</OutputFormat>" +
               "  <PageWidth>8.3in</PageWidth>" +
               "  <PageHeight>11.7in</PageHeight>" +
               "  <MarginTop>0.1in</MarginTop>" +
               "  <MarginLeft>0.1in</MarginLeft>" +
               "  <MarginRight>0.1in</MarginRight>" +
               "  <MarginBottom>0.1in</MarginBottom>" +
               " <EmbedFonts>None</EmbedFonts>" +
               "</DeviceInfo>";

            Warning[] warnings;
            string[] streamIds;
            string extension = string.Empty;

            byte[] bytes = rep.Render(reportType, deviceInfo, out mimeType, out encoding, out extension, out streamIds, out warnings);
            return bytes;
        }

    }
}
