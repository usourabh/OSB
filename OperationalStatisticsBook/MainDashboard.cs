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

            GetSinglePagePDF();
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

            //string Page2ReportName = "rptfrmPerformanceofDTCGlance.rdlc";
            //string Page2DataSourceName = "rptfrmPerformanceofDTCGlance";
            //DataTable Page2Data = objPageData.GetDataPerformanceDtcGlance_Page2_tbl1(this.OsbId);
            //byte[] byarry2 = GenerateReport(Page2ReportName, null, Page2DataSourceName, Page1Data);
            //lstByte.Add(byarry2);


            // PROGRESSIVE FINANCIAL RESULT

            string Page2ReportName2 = "rptprogressiveFinancialResults.rdlc";
            string Page2DataSourceName2 = "rptProgressiveFinancialResults";
            DataTable Page2Data2 = objPageData.GetDataProgressiveFinanResult_Page2_tbl2(this.OsbId);
            byte[] byarry3 = GenerateReport(Page2ReportName2, null, Page2DataSourceName2, Page2Data2);
            lstByte.Add(byarry3);


            // STAFF RATIO

            string Page3ReportName1 = "rptStaffRatioAsOn.rdlc";
            string Page3DataSourceName1 = "rptStaffRatioAsOn";
            DataTable Page3Data1 = objPageData.GetDataStaffRatio_Page3_tbl1(this.OsbId, this.Year, this.Month);
            byte[] byarry4 = GenerateReport(Page3ReportName1, null, Page3DataSourceName1, Page3Data1);
            lstByte.Add(byarry4);


            // ANALYSIS OF CAUSES ACCIDENTS FROM

            string Page3ReportName2 = "rptanalysisOfCausesAccidents.rdlc";
            string Page3DataSourceName2 = "rptanalysisOfCausesAccidents";
            DataTable Page3Data2 = objPageData.GetDataAnalysisCausesAccidents_Page3_tbl2(this.OsbId);
            byte[] byarry5 = GenerateReport(Page3ReportName2, null, Page3DataSourceName2, Page3Data2);
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
            byte[] byarry8 = GenerateReport(Page5n6ReportName, null, Page5n6DataSourceName, Page5n6Data);
            lstByte.Add(byarry8);


            // COMPARATIVE OPERATIONAL DATA FOR THE FINANCIAL YEAR

            string Page7ReportName = "rptComparativeOperationalData.rdlc";
            string Page7DataSourceName = "rptComparativeOperationalData";
            DataTable Page7Data = objPageData.GetDataComparativeOperationalData_Page7(this.OsbId);
            byte[] byarry9 = GenerateReport(Page7ReportName, null, Page7DataSourceName, Page7Data);
            lstByte.Add(byarry9);


            // DISTRIBUTION OF FLEET BY TYPE/MAKE AND YEAR OF COMMISION

            string Page8ReportName = "rptDistributionOfFleetByTypeMake.rdlc";
            string Page8DataSourceName = "rptDistributionOfFleetByTypeMake";
            DataTable Page8Data = objPageData.GetDataDistributionFleetTypeMakeYearCommision_Page8(this.OsbId);
            byte[] byarry10 = GenerateReport(Page8ReportName, null, Page8DataSourceName, Page8Data);
            lstByte.Add(byarry10);

            // PRICE AND COST INDICIES

            string Page9ReportName1 = "rptPriceAndCostIndicies.rdlc";
            string Page9DataSourceName1 = "rptPriceAndCostIndicies";
            DataTable Page9Data1 = objPageData.GetDataPriceNCostIndicies_Page9_tbl1(this.OsbId);
            byte[] byarry11 = GenerateReport(Page9ReportName1, null, Page9DataSourceName1, Page9Data1);
            lstByte.Add(byarry11);

            //MATERIAL CONSUMPTION 

            string Page9ReportName2 = "rptMaterialConsumptionFinancial.rdlc";
            string Page9DataSourceName2 = "MaterialConsumptionFinancial";
            DataTable Page9Data2 = objPageData.GetDataMaterialConsumption_Page9_tbl2(this.OsbId);
            byte[] byarry12 = GenerateReport(Page9ReportName2, null, Page9DataSourceName2, Page9Data2);
            lstByte.Add(byarry12);

            //PERFORMANCE OF METROPOLITIN TRANSPORT UNDERTAKING

            string Page10ReportName1 = "rptPerformanceMetopolitanTransportUndertaking.rdlc";
            string Page10DataSourceName1 = "PerformanceMetopolitanTransportUndertaking";
            DataTable Page10Data1 = objPageData.GetDataPerformMetroTransUnder_Page10_tbl1(this.OsbId);
            byte[] byarry13 = GenerateReport(Page10ReportName1, null, Page10DataSourceName1, Page10Data1);
            lstByte.Add(byarry13);

            // ACCIDENTS AND COMPENSATION GIVEN TO ACCIDENT VICTIMS

            string Page10ReportName2 = "rptAccidentNCompensationGvnAccidentVictims.rdlc";
            string Page10DataSourceName2 = "rptAccidentNCompensationGvnAccidentVictims";
            DataTable Page10Data2 = objPageData.GetDataAccidentNCompensGvnAcciVic_Page10_tbl2(this.OsbId);
            byte[] byarry14 = GenerateReport(Page10ReportName2, null, Page10DataSourceName2, Page10Data2);
            lstByte.Add(byarry14);

            // OPERATIONAL DATA DEPOT WISE FLEET STRENGTH & BUSES ON ROAD

            string Page11ReportName = "rptOperationalDepotWiseFleetStrengthNBusesOnRoad.rdlc";
            string Page11DataSourceName = "rptOperationalDepotWiseFleetStrengthNBusesOnRoad";
            DataTable Page11Data = objPageData.GetDataOperaDepotWiseFleetStrenBusesOnRoad_Page11(this.OsbId);
            byte[] byarry15 = GenerateReport(Page11ReportName, null, Page11DataSourceName, Page11Data);
            lstByte.Add(byarry15);

            // CATEGORYWISE STAFF POSITION AS ON 

            string Page12ReportName = "rptCategorywiseStaffPositionAsOn.rdlc";
            string Page12DataSourceName = "rptCategorywiseStaffPositionAsOn";
            DataTable Page12Data = objPageData.GetDataCategorywiseStaffPosition_Page12(this.OsbId);
            byte[] byarry16 = GenerateReport(Page12ReportName, null, Page12DataSourceName, Page12Data);
            lstByte.Add(byarry16);

            // ROUTES OPERATED BY DTC AND ITS EARNING PER KILOMETER

            string Page13ReportName = "rptRoutesOperatedByDTCEarningPerKillometer.rdlc";
            string Page13DataSourceName = "RoutesOperatedByDTCEarningPerKillometer";
            DataTable Page13Data = objPageData.GetDataRoutesOperatedByDTCEarningPerKm_Page13(this.OsbId);
            byte[] byarry17 = GenerateReport(Page13ReportName, null, Page13DataSourceName, Page13Data);
            lstByte.Add(byarry17);

            // Statement Showing Region Wise Operational

            string Page14ReportName = "rptStatementShowingRegionalWiseOperational.rdlc";
            string Page14DataSourceName = "StatementShowingRegionalWiseOperational";
            DataTable Page14Data = objPageData.GetDataStatementShowRegionWiseOpera_Page14(this.OsbId);
            byte[] byarry18 = GenerateReport(Page14ReportName, null, Page14DataSourceName, Page14Data);
            lstByte.Add(byarry18);

            // DETAILS OF OPERATIONAL DATA

            string Page15n16ReportName = "rptDetailsofOperationaldata.rdlc";
            string Page15n16DataSourceName = "DetailsofOperationaldata";
            DataTable Page15n16Data = objPageData.GetDataDetailsofOperationaldata_Page15n16(this.OsbId);
            byte[] byarry19 = GenerateReport(Page15n16ReportName, null, Page15n16DataSourceName, Page15n16Data);
            lstByte.Add(byarry19);

            // Depot Wise Oprational Data Respect Non Ac Low Floor City NCR Service Only For The Month Of January2021FleetItsUtillization

            string Page17n18ReportName = "rptDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization.rdlc";
            string Page17n18DataSourceName = "rptDepotWiseOprationalDataRespectNonALowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021FleetItsUtillization";
            DataTable Page17n18Data = objPageData.GetDataDepotWiseOperDataRespenonACAcLowFloorCityNCRServFleetItsUtillization_Page17n18(this.OsbId);
            byte[] byarry20 = GenerateReport(Page17n18ReportName, null, Page17n18DataSourceName, Page17n18Data);
            lstByte.Add(byarry20);

            //DWODTripsScheduledOperated

            string Page19n20ReportName = "rptDWODTripsScheduledOperated.rdlc";
            string Page19n20DataSourceName = "DWODTripsScheduledOperated";
            DataTable Page19n20Data = objPageData.GetDataDWODTripsScheduledOperated_Page19n20(this.OsbId);
            byte[] byarry21 = GenerateReport(Page19n20ReportName, null, Page19n20DataSourceName, Page19n20Data);
            lstByte.Add(byarry21);

            //DWOD in respect of non ac low floor city & ncr ANALYSIS OF KILOMETER

            string Page21n22ReportName = "rptDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyAnalysisOfKilometers.rdlc";
            string Page21n22DataSourceName = "rptDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyAnalysisOfKilometers";
            DataTable Page21n22Data = objPageData.GetDataDWODResNonAcAcAnalysisOfKilometers_Page21n22(this.OsbId);
            byte[] byarry22 = GenerateReport(Page21n22ReportName, null, Page21n22DataSourceName, Page21n22Data);
            lstByte.Add(byarry22);

            //DWOD in respect of non ac low floor city & ncr TRAFFIC INCOME

            string Page23n24ReportName = "rptDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome.rdlc";
            string Page23n24DataSourceName = "rptDepotWiseOprationalDataInRespectOfNonAcNAcLowFloorCityNCRServiceOnlyForTheMonthOfJanuary2021TrafficIncome";
            DataTable Page23n24Data = objPageData.GetDataDWODResNonAcAcTrafficIncome_Page23n24(this.OsbId);
            byte[] byarry23 = GenerateReport(Page23n24ReportName, null, Page23n24DataSourceName, Page23n24Data);
            lstByte.Add(byarry23);

            // Accident Analysis non ac low floor city & ncr For The Month

            string Page25n26ReportName = "rptAccidentAnalysisForTheMonth.rdlc";
            string Page25n26DataSourceName = "rptAccidentAnalysisForTheMonth";
            DataTable Page25n26Data = objPageData.GetDataAccidentAnalysisForTheMonth_Page25n26(this.OsbId);
            byte[] byarry24 = GenerateReport(Page25n26ReportName, null, Page25n26DataSourceName, Page25n26Data);
            lstByte.Add(byarry24);

            // Depot Wise Oprational Data In Respect Of NonAC

            string Page27ReportName = "rptDepotWiseOprationalDataInRespectOfNonAC.rdlc";
            string Page27DataSourceName = "rptDepotWiseOprationalDataInRespectOfNonAC";
            DataTable Page27Data = objPageData.GetDataDepotWiseOprationalDataInRespectOfNonAC_Page27(this.OsbId, this.Year, this.Month);
            byte[] byarry25 = GenerateReport(Page27ReportName, null, Page27DataSourceName, Page27Data);
            lstByte.Add(byarry25);

            // No Of Trips Actual Operated On Time And No Of Trips Actual Operated

            string Page28ReportName = "rptNoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated.rdlc";
            string Page28DataSourceName = "rptNoOfTripsActualOperatedOnTimeAndNoOfTripsActualOperated";
            DataTable Page28Data = objPageData.GetDataTripsActualOperatedOnTimeNOperated2min_Page28(this.OsbId);
            byte[] byarry26 = GenerateReport(Page28ReportName, null, Page28DataSourceName, Page28Data);
            lstByte.Add(byarry26);

            //DepotWise Total Missed Kms And Breakdowns

            string Page29ReportName = "rptDepotWiseTotalMissedKmsAndBreakdowns.rdlc";
            string Page29DataSourceName = "rptDepotWiseTotalMissedKmsAndBreakdowns";
            DataTable Page29Data = objPageData.GetDataDepotWiseTotalMissedKmsAndBreakdowns_Page29(this.OsbId);
            byte[] byarry27 = GenerateReport(Page29ReportName, null, Page29DataSourceName, Page29Data);
            lstByte.Add(byarry27);


            // Comparative Analysis Of Causes Of Accidents

            string Page30ReportName1 = "rptComparativeAnalysisOfCausesOfAccidents.rdlc";
            string Page30DataSourceName1 = "rptComparativeAnalysisOfCausesOfAccidents";
            DataTable Page30Data1 = objPageData.GetDataComparativeAnalysisOfCausesOfAccidentsMonthly_Page30(this.OsbId);
            byte[] byarry30 = GenerateReport(Page30ReportName1, null, Page30DataSourceName1, Page30Data1);
            lstByte.Add(byarry30);





















            #endregion



            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            string outputPdfPath = @"D:/newFile.pdf";
            MessageBox.Show("PDF GENERATED");

            sourceDocument = new Document();
            pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

            //output file Open  
            sourceDocument.Open();


            //files list wise Loop  
            for (int f = 0; f < lstByte.Count; f++)
            {
                int pages = 1;

                reader = new PdfReader(lstByte[f]);
                //Add pages in new file  
                for (int i = 1; i <= pages; i++)
                {
                    importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                    pdfCopyProvider.AddPage(importedPage);
                }

                reader.Close();
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

            byte[] fByte = ConvertReportToPDF(rdsAPP.LocalReport);

            return fByte;
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
               "</DeviceInfo>";

            Warning[] warnings;
            string[] streamIds;
            string extension = string.Empty;

            byte[] bytes = rep.Render(reportType, deviceInfo, out mimeType, out encoding, out extension, out streamIds, out warnings);
            return bytes;
        }

    }
}
