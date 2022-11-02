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
using WindowsFormsApp1;

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

            dt.Rows.Add(" ", "Index Page", "frmOSBMain");
            dt.Rows.Add(" ", "Performance of DTC at a Glance", "frmPerformanceofDTCGlance");
            dt.Rows.Add(" ", "PROGRESSIVE FINANCIAL RESULTS (Rs. In Lakh)", "progressiveFinancialResults");
            dt.Rows.Add(" ", "Staff Ratio as on 31st July-2022", "StaffRatioAsOn");
            dt.Rows.Add("1.1", "Analysis of causes of Accidents (" + GlobalMaster.FinMaster[1].FinVal + " TO " + GlobalMaster.FinMaster[0].FinVal + ")", "analysisOfCausesAccidents");
            dt.Rows.Add("1.2", "Growith of basic structure of DTC", "SalientFeatureGrowthBasicStructure");
            dt.Rows.Add("1.3", "ROUTES OPERATED BY D.T.C.", "RoutesOperatedByDtc");
            dt.Rows.Add("1.4", "Comparative Financial Results Year (" + GlobalMaster.FinMaster[2].FinVal + " to " + GlobalMaster.FinMaster[0].FinVal + ")", "ComparativeFinancialResultsFrom");
            dt.Rows.Add("1.5", "Comparative operational data for the period (April to March) (" + GlobalMaster.FinMaster[2].FinVal + " to " + GlobalMaster.FinMaster[0].FinVal + ")", "ComparativeOperationalData");
            dt.Rows.Add("1.6", "Distrubution fof fleet by type/make and year of commission", "DistrubutionOfFleetByTypeMakeAndYearOfCommission");
            dt.Rows.Add("1.7", "PRICE AND COST INDICES (" + GlobalMaster.FinMaster[5].FinVal + " to " + GlobalMaster.FinMaster[0].FinVal + ")", "PriceAndCostIndicies");
            dt.Rows.Add("1.8", "Material Consumption from (" + GlobalMaster.FinMaster[2].FinVal + " to " + GlobalMaster.FinMaster[0].FinVal + ")", "MaterialConsumptionFrom");
            dt.Rows.Add("1.9", "Performance of Metopolitan Transport Undertaking (" + GlobalMaster.FinMaster[5].FinVal + ")", "PerformanceMetopolitanTransportUndertaking");
            dt.Rows.Add("1.10", "Accidents and Compensation given to Accident Victims April to March (" + GlobalMaster.FinMaster[9].FinVal + " to " + GlobalMaster.FinMaster[0].FinVal + ")", "AccidentNCompensationGvnAccidentVictims");
            dt.Rows.Add("1.11", "Operational data Depot wise fleet strength & buses on road as on 31st July-2022", "OperationalDepotWiseFleetStrengthNBusesOnRoad");
            dt.Rows.Add("2", "Category wise Staff Position as on 31st January-2021", "CategorywiseStaffPositionAsOn");
            dt.Rows.Add("3.1", "Routes operated by DTC and its Earning per Killometer June-2022", "RoutesOperatedByDTCEarningPerKillometerJune");
            dt.Rows.Add("3.2", "Statement showing Region Wise Operational Data for the month of January 2021", "StatementShowingRegionWiseOperationalDataForTheMonth");
            dt.Rows.Add("3.3", "DETAILS OF OPERATIONAL DATA", "DetailsofOperationaldataforthemonthofJuly");
            dt.Rows.Add("4.1", "Depot Wise Oprational Data(inRespectOfNonAC & AC LowFloor City NCR Service Only For The Month Of January 2021 Fleet & ItsUtillization)", "DepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization");
            dt.Rows.Add("4.2", "Depot-wise Operational Data Trips Scheduled and Operated)", "DepotWiseOperationalDataInRespectOfNonAcAndAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TripsScheduledAndOperated");
            dt.Rows.Add("4.3", "Depot- wise Oprational Data (in respect of Non AC & AC Low Floor City + NCR service only)for the month of January 2021 Analysis of Kilometers", "DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021AnalysisOfKilometers");
            dt.Rows.Add("4.4", "Depot- wise Oprational Data (in respect of Non AC & AC Low Floor City + NCR service only) For the month of january 2021 Traffic Income", "DepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome");
            dt.Rows.Add("4.5", "Accident Analysis Of for the month of (Non AC & AC Low Floor City & NCR service only)", "AccidentAnalysisForTheMonth");
            dt.Rows.Add("4.6", "Depot- wise Oprational Data (in respect of Non AC & AC Low Floor City service only)", "DepotWiseOprationalDataInRespectOfNonAC");
            dt.Rows.Add("4.7", "No. of trips actual operated on time and No. of trips actual operated within two minutes. for the month of Febuary - 2022", "NoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated");
            dt.Rows.Add("4.8", "Depot wise total missed kms and breakdowns for the month of July-2022", "DepotWiseTotalMissedKmsAndBreakdowns");
            dt.Rows.Add("5.1", "Comparative Analysis of causes of Accidents for the month of July - 2022 & July - 2021", "ComparativeAnalysisOfCausesOfAccidents");
            dt.Rows.Add("5.2", "Accident Analysis By Other Party Involvement", "AccidentAnalysisOtherPartyInvolvment");
            dt.Rows.Add("5.3", "Analysis of Accidents by driver group", "AnalysisOfAccidentsByDriverGroup");
            dt.Rows.Add("6.1", "Statement Of for the month of Passes", "StatementOfForTheMonthOfPasses");
            dt.Rows.Add("6.2", "DEPOT WISE STATEMENT OF SCHOOL , SPL. HIRE ,TOURIST, PASS & PINK TICKET EARNING For the month of january 2021", "DeportWiseStatementOfSchoolSPLHireTouristPassPinkTicketEarning");
            dt.Rows.Add("7.1", "Statement Showing Operational Data of NCR CNG Services of the Corporation for the month of January 2021", "StatementShowingOperationalDataOfNcrCngServicesOfTheCorporationForTheMonthOfJuly_2022");
            dt.Rows.Add("8.1", "Depot wise operational data of FCMS Fleet & its utiuzation", "DWODFCMSFleetItsUtilization");
            dt.Rows.Add("8.2", "Depot wise Operational Data FCMS Cluster buses Traffic Income", "DepotwiseOperationalDataFCMSCluster_busesTrafficIncome");
            dt.Rows.Add("9", "Statemnet showing the(Rs. in respect of City, NCR & Foreign bus service(Income & Expewnditure June - 2022 in lakhs)", "StatementShowingTheRsInRespectOfCityNCRForeignBusServiceIncomeExpewditureJune2022InLakhs");
            dt.Rows.Add(" ", "Statemnet showing the in respect of City, NCR & Foreign bus service(Income & Expewnditure June - 2022 in lakhs)", "StatemnetShowingTheInRespectOfCityNcrAndForeignBusServiceRsIncomeAndExpewnditureJune_2022Inlakhs");
            dt.Rows.Add("", "Depot wise operational data of FCMS Fleet & its utiuzation", "DWODFCMSFleetItsUtilization");
            dt.Rows.Add("", "", "");
            dt.Rows.Add(" ", "Fleet Utilization July -2021 to July-2022 ", "rptFleetUtilization");
           

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
            }
        }

        private void PrintAllReportOnClick(object sender, EventArgs e)
        {

            PrintWholePdf objFrm = new PrintWholePdf(OsbId, Year, Month, FinYear, MonthName);
            objFrm.Show();
        }
    }
}
