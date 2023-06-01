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
    public partial class AccidentAnalysisForTheMonth : Form
    {

        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);

        public AccidentAnalysisForTheMonth(int OsbId, int Year, int Month, string finYear, string MonthName)
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
                SqlCommand cmd = new SqlCommand("SELECT [S_No],[Param1],[Param2],[Param3],[Param4] ,[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16],[Param17],[Param18],[Param19],[Param20],[Param21],[Param22],[Param23],[Param24],[Param25],[Param26],[Param27],[Param28],[Param29],[Param30],[Param31],[Param32],[Param33],[Param34],[Param35],[Param36],[Param37],[Param38],[Param39],[Param40],[Param41] FROM [rpt].[tbl_AccidentAnalysisForTheMonth] where OsbId=@OsbId", con);
                cmd.Parameters.AddWithValue("@OsbId", OsbId);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                DataTable autoSpTable = new DataTable();
                if (dt.Rows.Count < 1)
                {
                    SqlCommand cmd1 = new SqlCommand("[dbo].[AccidentAnalysisAcNonAcforTheMonth4_5]", con);
                    cmd1.Parameters.AddWithValue("@month", Month);
                    cmd1.Parameters.AddWithValue("@year", Year);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandTimeout = 200;
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                    sda1.Fill(autoSpTable);
                }

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    Save.BackColor = Color.Green;
                }
                else if (autoSpTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = BindAccidentAnalysisForTheMonth_AutoSpTable(autoSpTable);
                }
                else
                {
                    dataGridView1.DataSource = BindAccidentAnalysisForTheMonth();
                }

                setRowColNonEditable();
                CalcalculateTotal();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        DataTable BindAccidentAnalysisForTheMonth_AutoSpTable(DataTable sp)
        {
            DataTable table = new DataTable();

            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Name of Depot", typeof(string));
            table.Columns.Add("MINOR*", typeof(string));
            table.Columns.Add("MINOR* ", typeof(string));
            table.Columns.Add("MINOR*  ", typeof(string));
            table.Columns.Add("MINOR*   ", typeof(string));
            table.Columns.Add("MINOR*     ", typeof(string));
            table.Columns.Add("MAJOR**", typeof(string));
            table.Columns.Add("MAJOR** ", typeof(string));
            table.Columns.Add("MAJOR**  ", typeof(string));
            table.Columns.Add("MAJOR**   ", typeof(string));
            table.Columns.Add("MAJOR**    ", typeof(string));
            table.Columns.Add("FATAL***", typeof(string));
            table.Columns.Add("FATAL*** ", typeof(string));
            table.Columns.Add("FATAL***  ", typeof(string));
            table.Columns.Add("FATAL***   ", typeof(string));
            table.Columns.Add("FATAL***    ", typeof(string));
            table.Columns.Add("TOTAL", typeof(string));
            table.Columns.Add("TOTAL ", typeof(string));
            table.Columns.Add("TOTAL  ", typeof(string));
            table.Columns.Add("TOTAL   ", typeof(string));
            table.Columns.Add("TOTAL     ", typeof(string));
            table.Columns.Add("RATIO PER ONE LAKH KMS.", typeof(string));
            table.Columns.Add("RATIO PER ONE LAKH KMS. ", typeof(string));
            table.Columns.Add("RATIO PER ONE LAKH KMS.  ", typeof(string));
            table.Columns.Add("RATIO PER ONE LAKH KMS.   ", typeof(string));
            table.Columns.Add("RATIO PER ONE LAKH KMS.    ", typeof(string));
            table.Columns.Add("PERSONS INJURED", typeof(string));
            table.Columns.Add("PERSONS INJURED ", typeof(string));
            table.Columns.Add("PERSONS INJURED  ", typeof(string));
            table.Columns.Add("PERSONS INJURED   ", typeof(string));
            table.Columns.Add("PERSONS INJURED    ", typeof(string));
            table.Columns.Add("PERSONS KILLED ", typeof(string));
            table.Columns.Add("PERSONS KILLED  ", typeof(string));
            table.Columns.Add("PERSONS KILLED   ", typeof(string));
            table.Columns.Add("PERSONS KILLED    ", typeof(string));
            table.Columns.Add("PERSONS KILLED      ", typeof(string));
            table.Columns.Add("FATALITIES PER 100000 KMS", typeof(string));
            table.Columns.Add("FATALITIES PER 100000 KMS ", typeof(string));
            table.Columns.Add("FATALITIES PER 100000 KMS  ", typeof(string));
            table.Columns.Add("FATALITIES PER 100000 KMS   ", typeof(string));
            table.Columns.Add("FATALITIES PER 100000 KMS    ", typeof(string));

            ///Rows here........ 
            // table.Rows.Add(" ", " ", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total");
            // table.Rows.Add(" ", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ");
            // table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22","23","24","25","26","27","28","29","30","31","32","33","34","35","36","37","38","39","40","41","42");

            for (int i = 0; i < sp.Rows.Count; i++)
            {
                if (Convert.ToInt32(sp.Rows[i]["CirleCode"]) != 22 && Convert.ToInt32(sp.Rows[i]["CirleCode"]) != 40 && Convert.ToInt32(sp.Rows[i]["CirleCode"]) != 41)
                {
                    int totalCityNac = Convert.ToInt32(sp.Rows[i]["MinorCityNonAc"]) + Convert.ToInt32(sp.Rows[i]["MajorCityNonAc"]) + Convert.ToInt32(sp.Rows[i]["FatalCityNonAc"]);
                    int totalCityAc = Convert.ToInt32(sp.Rows[i]["MinorCityAc"]) + Convert.ToInt32(sp.Rows[i]["MajorCityAc"]) + Convert.ToInt32(sp.Rows[i]["FatalCityAc"]);
                    int totalNcrNac = Convert.ToInt32(sp.Rows[i]["MinorNcrNonAc"]) + Convert.ToInt32(sp.Rows[i]["MajorNcrNonAc"]) + Convert.ToInt32(sp.Rows[i]["FatalNcrNonAc"]);
                    int totalNcrAc = Convert.ToInt32(sp.Rows[i]["MinorNcrAc"]) + Convert.ToInt32(sp.Rows[i]["MajorNcrAc"]) + Convert.ToInt32(sp.Rows[i]["FatalNcrAc"]);

                    int operatedKmCityNac = Convert.ToInt32(sp.Rows[i]["RationPerLakhCityNac"] ?? 1);
                    int operatedKmCityAc = Convert.ToInt32(sp.Rows[i]["RationPerLakhCityAc"] ?? 1);
                    int operatedKmNcrNac = Convert.ToInt32(sp.Rows[i]["RationPerLakhNcrNac"] ?? 1);
                    int operatedKmNcrAc = Convert.ToInt32(sp.Rows[i]["RationPerLakhNcrAc"] ?? 1);

                    table.Rows.Add(i + 1, sp.Rows[i]["CircleName"],

                    sp.Rows[i]["MinorCityNonAc"], sp.Rows[i]["MinorCityAc"], sp.Rows[i]["MinorNcrNonAc"], sp.Rows[i]["MinorNcrAc"], "0",
                    sp.Rows[i]["MajorCityNonAc"], sp.Rows[i]["MajorCityAc"], sp.Rows[i]["MajorNcrNonAc"], sp.Rows[i]["MajorNcrAc"], "0",
                    sp.Rows[i]["FatalCityNonAc"], sp.Rows[i]["FatalCityAc"], sp.Rows[i]["FatalNcrNonAc"], sp.Rows[i]["FatalNcrAc"], "0",

                    Convert.ToString(totalCityNac), Convert.ToString(totalCityAc), Convert.ToString(totalNcrNac), Convert.ToString(totalNcrAc), "0",

                    (operatedKmCityNac != 0) ? Convert.ToString((totalCityNac * 100000) / operatedKmCityNac) : "1",
                    (operatedKmCityAc != 0) ? Convert.ToString((totalCityAc * 100000) / operatedKmCityAc) : "1",
                    (operatedKmNcrNac != 0) ? Convert.ToString((totalNcrNac * 100000) / operatedKmNcrNac) : "1",
                    (operatedKmNcrAc != 0) ? Convert.ToString((totalNcrAc * 100000) / operatedKmNcrAc) : "1",

                    sp.Rows[i]["PersonInjuredCityNonAc"], sp.Rows[i]["PersonInjuredCityAc"], sp.Rows[i]["PersonInjuredNcrNonAc"], sp.Rows[i]["PersonInjuredNcrAc"], "0",

                    sp.Rows[i]["FatalCityNonAc"], sp.Rows[i]["FatalCityAc"], sp.Rows[i]["FatalNcrNonAc"], sp.Rows[i]["FatalNcrAc"], "0",

                    (operatedKmCityNac != 0) ? Convert.ToString((Convert.ToInt32(sp.Rows[i]["FatalCityNonAc"]) * 100000) / operatedKmCityNac) : "1",
                    (operatedKmCityAc != 0) ? Convert.ToString((Convert.ToInt32(sp.Rows[i]["FatalCityAc"]) * 100000) / operatedKmCityAc) : "1",
                    (operatedKmNcrNac != 0) ? Convert.ToString((Convert.ToInt32(sp.Rows[i]["FatalNcrNonAc"]) * 100000) / operatedKmNcrNac) : "1",
                    (operatedKmNcrAc != 0) ? Convert.ToString((Convert.ToInt32(sp.Rows[i]["FatalNcrAc"]) * 100000) / operatedKmNcrAc) : "1"
                    );
                }

            }

            table.Rows.Add(" ", "Total ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add(" Electric Buses", " ", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");



            //////////////////////////////////
            ///   ROHINI 2
            //////////////////////////////////
            if (true)
            {
                int totalCityNac = Convert.ToInt32(sp.Rows[22]["MinorCityNonAc"]) + Convert.ToInt32(sp.Rows[22]["MajorCityNonAc"]) + Convert.ToInt32(sp.Rows[22]["FatalCityNonAc"]);
                int totalCityAc = Convert.ToInt32(sp.Rows[22]["MinorCityAc"]) + Convert.ToInt32(sp.Rows[22]["MajorCityAc"]) + Convert.ToInt32(sp.Rows[22]["FatalCityAc"]);
                int totalNcrNac = Convert.ToInt32(sp.Rows[22]["MinorNcrNonAc"]) + Convert.ToInt32(sp.Rows[22]["MajorNcrNonAc"]) + Convert.ToInt32(sp.Rows[22]["FatalNcrNonAc"]);
                int totalNcrAc = Convert.ToInt32(sp.Rows[22]["MinorNcrAc"]) + Convert.ToInt32(sp.Rows[22]["MajorNcrAc"]) + Convert.ToInt32(sp.Rows[22]["FatalNcrAc"]);

                int operatedKmCityNac = Convert.ToInt32(sp.Rows[22]["RationPerLakhCityNac"] ?? 1);
                int operatedKmCityAc = Convert.ToInt32(sp.Rows[22]["RationPerLakhCityAc"] ?? 1);
                int operatedKmNcrNac = Convert.ToInt32(sp.Rows[22]["RationPerLakhNcrNac"] ?? 1);
                int operatedKmNcrAc = Convert.ToInt32(sp.Rows[22]["RationPerLakhNcrAc"] ?? 1);

                table.Rows.Add(1, sp.Rows[22]["CircleName"],

                    sp.Rows[22]["MinorCityNonAc"], sp.Rows[22]["MinorCityAc"], sp.Rows[22]["MinorNcrNonAc"], sp.Rows[22]["MinorNcrAc"], "0",
                    sp.Rows[22]["MajorCityNonAc"], sp.Rows[22]["MajorCityAc"], sp.Rows[22]["MajorNcrNonAc"], sp.Rows[22]["MajorNcrAc"], "0",
                    sp.Rows[22]["FatalCityNonAc"], sp.Rows[22]["FatalCityAc"], sp.Rows[22]["FatalNcrNonAc"], sp.Rows[22]["FatalNcrAc"], "0",

                    Convert.ToString(totalCityNac), Convert.ToString(totalCityAc), Convert.ToString(totalNcrNac), Convert.ToString(totalNcrAc), "0",

                    (operatedKmCityNac != 0) ? Convert.ToString((totalCityNac * 100000) / operatedKmCityNac) : "1",
                    (operatedKmCityAc != 0) ? Convert.ToString((totalCityAc * 100000) / operatedKmCityAc) : "1",
                    (operatedKmNcrNac != 0) ? Convert.ToString((totalNcrNac * 100000) / operatedKmNcrNac) : "1",
                    (operatedKmNcrAc != 0) ? Convert.ToString((totalNcrAc * 100000) / operatedKmNcrAc) : "1",

                    sp.Rows[22]["PersonInjuredCityNonAc"], sp.Rows[22]["PersonInjuredCityAc"], sp.Rows[22]["PersonInjuredNcrNonAc"], sp.Rows[22]["PersonInjuredNcrAc"], "0",

                    sp.Rows[22]["FatalCityNonAc"], sp.Rows[22]["FatalCityAc"], sp.Rows[22]["FatalNcrNonAc"], sp.Rows[22]["FatalNcrAc"], "0",

                    (operatedKmCityNac != 0) ? Convert.ToString((Convert.ToInt32(sp.Rows[22]["FatalCityNonAc"]) * 100000) / operatedKmCityNac) : "1",
                    (operatedKmCityAc != 0) ? Convert.ToString((Convert.ToInt32(sp.Rows[22]["FatalCityAc"]) * 100000) / operatedKmCityAc) : "1",
                    (operatedKmNcrNac != 0) ? Convert.ToString((Convert.ToInt32(sp.Rows[22]["FatalNcrNonAc"]) * 100000) / operatedKmNcrNac) : "1",
                    (operatedKmNcrAc != 0) ? Convert.ToString((Convert.ToInt32(sp.Rows[22]["FatalNcrAc"]) * 100000) / operatedKmNcrAc) : "1"
                    );
            }


            //////////////////////////////////
            ///   ROHINI SEC - 37
            //////////////////////////////////
            if (true)
            {
                int totalCityNac = Convert.ToInt32(sp.Rows[35]["MinorCityNonAc"]) + Convert.ToInt32(sp.Rows[35]["MajorCityNonAc"]) + Convert.ToInt32(sp.Rows[35]["FatalCityNonAc"]);
                int totalCityAc = Convert.ToInt32(sp.Rows[35]["MinorCityAc"]) + Convert.ToInt32(sp.Rows[35]["MajorCityAc"]) + Convert.ToInt32(sp.Rows[35]["FatalCityAc"]);
                int totalNcrNac = Convert.ToInt32(sp.Rows[35]["MinorNcrNonAc"]) + Convert.ToInt32(sp.Rows[35]["MajorNcrNonAc"]) + Convert.ToInt32(sp.Rows[35]["FatalNcrNonAc"]);
                int totalNcrAc = Convert.ToInt32(sp.Rows[35]["MinorNcrAc"]) + Convert.ToInt32(sp.Rows[35]["MajorNcrAc"]) + Convert.ToInt32(sp.Rows[35]["FatalNcrAc"]);

                int operatedKmCityNac = Convert.ToInt32(sp.Rows[35]["RationPerLakhCityNac"] ?? 1);
                int operatedKmCityAc = Convert.ToInt32(sp.Rows[35]["RationPerLakhCityAc"] ?? 1);
                int operatedKmNcrNac = Convert.ToInt32(sp.Rows[35]["RationPerLakhNcrNac"] ?? 1);
                int operatedKmNcrAc = Convert.ToInt32(sp.Rows[35]["RationPerLakhNcrAc"] ?? 1);

                table.Rows.Add(1, sp.Rows[35]["CircleName"],

                    sp.Rows[35]["MinorCityNonAc"], sp.Rows[35]["MinorCityAc"], sp.Rows[35]["MinorNcrNonAc"], sp.Rows[35]["MinorNcrAc"], "0",
                    sp.Rows[35]["MajorCityNonAc"], sp.Rows[35]["MajorCityAc"], sp.Rows[35]["MajorNcrNonAc"], sp.Rows[35]["MajorNcrAc"], "0",
                    sp.Rows[35]["FatalCityNonAc"], sp.Rows[35]["FatalCityAc"], sp.Rows[35]["FatalNcrNonAc"], sp.Rows[35]["FatalNcrAc"], "0",

                    Convert.ToString(totalCityNac), Convert.ToString(totalCityAc), Convert.ToString(totalNcrNac), Convert.ToString(totalNcrAc), "0",

                    (operatedKmCityNac != 0) ? Convert.ToString((totalCityNac * 100000) / operatedKmCityNac) : "1",
                    (operatedKmCityAc != 0) ? Convert.ToString((totalCityAc * 100000) / operatedKmCityAc) : "1",
                    (operatedKmNcrNac != 0) ? Convert.ToString((totalNcrNac * 100000) / operatedKmNcrNac) : "1",
                    (operatedKmNcrAc != 0) ? Convert.ToString((totalNcrAc * 100000) / operatedKmNcrAc) : "1",

                    sp.Rows[35]["PersonInjuredCityNonAc"], sp.Rows[35]["PersonInjuredCityAc"], sp.Rows[35]["PersonInjuredNcrNonAc"], sp.Rows[35]["PersonInjuredNcrAc"], "0",

                    sp.Rows[35]["FatalCityNonAc"], sp.Rows[35]["FatalCityAc"], sp.Rows[35]["FatalNcrNonAc"], sp.Rows[35]["FatalNcrAc"], "0",

                    (operatedKmCityNac != 0) ? Convert.ToString((Convert.ToInt32(sp.Rows[35]["FatalCityNonAc"]) * 100000) / operatedKmCityNac) : "1",
                    (operatedKmCityAc != 0) ? Convert.ToString((Convert.ToInt32(sp.Rows[35]["FatalCityAc"]) * 100000) / operatedKmCityAc) : "1",
                    (operatedKmNcrNac != 0) ? Convert.ToString((Convert.ToInt32(sp.Rows[35]["FatalNcrNonAc"]) * 100000) / operatedKmNcrNac) : "1",
                    (operatedKmNcrAc != 0) ? Convert.ToString((Convert.ToInt32(sp.Rows[35]["FatalNcrAc"]) * 100000) / operatedKmNcrAc) : "1"
                    );
            }

            //////////////////////////////////
            ///   MUNDHELA KALAN
            //////////////////////////////////
            if (true)
            {
                int totalCityNac = Convert.ToInt32(sp.Rows[36]["MinorCityNonAc"]) + Convert.ToInt32(sp.Rows[36]["MajorCityNonAc"]) + Convert.ToInt32(sp.Rows[36]["FatalCityNonAc"]);
                int totalCityAc = Convert.ToInt32(sp.Rows[36]["MinorCityAc"]) + Convert.ToInt32(sp.Rows[36]["MajorCityAc"]) + Convert.ToInt32(sp.Rows[36]["FatalCityAc"]);
                int totalNcrNac = Convert.ToInt32(sp.Rows[36]["MinorNcrNonAc"]) + Convert.ToInt32(sp.Rows[36]["MajorNcrNonAc"]) + Convert.ToInt32(sp.Rows[36]["FatalNcrNonAc"]);
                int totalNcrAc = Convert.ToInt32(sp.Rows[36]["MinorNcrAc"]) + Convert.ToInt32(sp.Rows[36]["MajorNcrAc"]) + Convert.ToInt32(sp.Rows[36]["FatalNcrAc"]);

                int operatedKmCityNac = Convert.ToInt32(sp.Rows[36]["RationPerLakhCityNac"] ?? 1);
                int operatedKmCityAc = Convert.ToInt32(sp.Rows[36]["RationPerLakhCityAc"] ?? 1);
                int operatedKmNcrNac = Convert.ToInt32(sp.Rows[36]["RationPerLakhNcrNac"] ?? 1);
                int operatedKmNcrAc = Convert.ToInt32(sp.Rows[36]["RationPerLakhNcrAc"] ?? 1);

                table.Rows.Add(1, sp.Rows[36]["CircleName"],

                    sp.Rows[36]["MinorCityNonAc"], sp.Rows[36]["MinorCityAc"], sp.Rows[36]["MinorNcrNonAc"], sp.Rows[36]["MinorNcrAc"], "0",
                    sp.Rows[36]["MajorCityNonAc"], sp.Rows[36]["MajorCityAc"], sp.Rows[36]["MajorNcrNonAc"], sp.Rows[36]["MajorNcrAc"], "0",
                    sp.Rows[36]["FatalCityNonAc"], sp.Rows[36]["FatalCityAc"], sp.Rows[36]["FatalNcrNonAc"], sp.Rows[36]["FatalNcrAc"], "0",

                    Convert.ToString(totalCityNac), Convert.ToString(totalCityAc), Convert.ToString(totalNcrNac), Convert.ToString(totalNcrAc), "0",

                    (operatedKmCityNac != 0) ? Convert.ToString((totalCityNac * 100000) / operatedKmCityNac) : "1",
                    (operatedKmCityAc != 0) ? Convert.ToString((totalCityAc * 100000) / operatedKmCityAc) : "1",
                    (operatedKmNcrNac != 0) ? Convert.ToString((totalNcrNac * 100000) / operatedKmNcrNac) : "1",
                    (operatedKmNcrAc != 0) ? Convert.ToString((totalNcrAc * 100000) / operatedKmNcrAc) : "1",

                    sp.Rows[36]["PersonInjuredCityNonAc"], sp.Rows[36]["PersonInjuredCityAc"], sp.Rows[36]["PersonInjuredNcrNonAc"], sp.Rows[36]["PersonInjuredNcrAc"], "0",

                    sp.Rows[36]["FatalCityNonAc"], sp.Rows[36]["FatalCityAc"], sp.Rows[36]["FatalNcrNonAc"], sp.Rows[36]["FatalNcrAc"], "0",

                    (operatedKmCityNac != 0) ? Convert.ToString((Convert.ToInt32(sp.Rows[36]["FatalCityNonAc"]) * 100000) / operatedKmCityNac) : "1",
                    (operatedKmCityAc != 0) ? Convert.ToString((Convert.ToInt32(sp.Rows[36]["FatalCityAc"]) * 100000) / operatedKmCityAc) : "1",
                    (operatedKmNcrNac != 0) ? Convert.ToString((Convert.ToInt32(sp.Rows[36]["FatalNcrNonAc"]) * 100000) / operatedKmNcrNac) : "1",
                    (operatedKmNcrAc != 0) ? Convert.ToString((Convert.ToInt32(sp.Rows[36]["FatalNcrAc"]) * 100000) / operatedKmNcrAc) : "1"
                    );
            }

            table.Rows.Add(" ", "Total Electric ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "Total DTC ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add(" International", " ", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

            table.Rows.Add("1", "Kathmandu", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "Grand Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");


            return table;
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

        DataTable BindAccidentAnalysisForTheMonth()
        {
            DataTable table = new DataTable();

            table.Columns.Add("S.No", typeof(string));
            table.Columns.Add("Name of Depot", typeof(string));
            table.Columns.Add("MINOR*", typeof(string));
            table.Columns.Add("MINOR* ", typeof(string));
            table.Columns.Add("MINOR*  ", typeof(string));
            table.Columns.Add("MINOR*   ", typeof(string));
            table.Columns.Add("MINOR*     ", typeof(string));
            table.Columns.Add("MAJOR**", typeof(string));
            table.Columns.Add("MAJOR** ", typeof(string));
            table.Columns.Add("MAJOR**  ", typeof(string));
            table.Columns.Add("MAJOR**   ", typeof(string));
            table.Columns.Add("MAJOR**    ", typeof(string));
            table.Columns.Add("FATAL***", typeof(string));
            table.Columns.Add("FATAL*** ", typeof(string));
            table.Columns.Add("FATAL***  ", typeof(string));
            table.Columns.Add("FATAL***   ", typeof(string));
            table.Columns.Add("FATAL***    ", typeof(string));
            table.Columns.Add("TOTAL", typeof(string));
            table.Columns.Add("TOTAL ", typeof(string));
            table.Columns.Add("TOTAL  ", typeof(string));
            table.Columns.Add("TOTAL   ", typeof(string));
            table.Columns.Add("TOTAL     ", typeof(string));
            table.Columns.Add("RATIO PER ONE LAKH KMS.", typeof(string));
            table.Columns.Add("RATIO PER ONE LAKH KMS. ", typeof(string));
            table.Columns.Add("RATIO PER ONE LAKH KMS.  ", typeof(string));
            table.Columns.Add("RATIO PER ONE LAKH KMS.   ", typeof(string));
            table.Columns.Add("RATIO PER ONE LAKH KMS.    ", typeof(string));
            table.Columns.Add("PERSONS INJURED", typeof(string));
            table.Columns.Add("PERSONS INJURED ", typeof(string));
            table.Columns.Add("PERSONS INJURED  ", typeof(string));
            table.Columns.Add("PERSONS INJURED   ", typeof(string));
            table.Columns.Add("PERSONS INJURED    ", typeof(string));
            table.Columns.Add("PERSONS KILLED ", typeof(string));
            table.Columns.Add("PERSONS KILLED  ", typeof(string));
            table.Columns.Add("PERSONS KILLED   ", typeof(string));
            table.Columns.Add("PERSONS KILLED    ", typeof(string));
            table.Columns.Add("PERSONS KILLED      ", typeof(string));
            table.Columns.Add("FATALITIES PER 100000 KMS", typeof(string));
            table.Columns.Add("FATALITIES PER 100000 KMS ", typeof(string));
            table.Columns.Add("FATALITIES PER 100000 KMS  ", typeof(string));
            table.Columns.Add("FATALITIES PER 100000 KMS   ", typeof(string));
            table.Columns.Add("FATALITIES PER 100000 KMS    ", typeof(string));

            ///Rows here........ 
            // table.Rows.Add(" ", " ", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total", "City", "City", "NCR", "NCR", "Total");
            // table.Rows.Add(" ", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ", "NAC ", "AC ", "NAC", "AC", " ");
            // table.Rows.Add("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22","23","24","25","26","27","28","29","30","31","32","33","34","35","36","37","38","39","40","41","42");
            table.Rows.Add("2", "BBM ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Rohini-I ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("4", "Rohini-II ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("5", "Rohini-III ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("6", "Rohini-IV ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("7", "Wazir Pur", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("8", "Subhash Place", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("9", "G.T.K. Rd. ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("10", "Nangloi ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("11", "Kanjhawla", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("12", "Narela", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("13", "Kalka Ji", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("14", "Sri Niwas puri", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("15", "AND", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("16", "Vasant Vihar", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("17", "Tehkhand ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("18", "Sukhdev Vihar  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("19", "Sarojni Nagar   ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("20", "Nand Nagri ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("21", "NOIDA ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("22", "EVND ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("23", "Hasan Pur ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("24", "Gazi Pur ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("25", "Rajghat I ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("26", "Hari Nagar I ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("27", "Hari Nagar II", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("28", "Kesho Pur ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("29", "Naraina", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("30", "Shadi Pur  ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("31", "BAGDOLA", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("32", "DW. SEC.-II ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("33", "Maya Puri ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("34", "Dichaon Kalan", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("35", "Peera Garhi", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "Total ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add(" Electric Buses", " ", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

            table.Rows.Add("1", " Rohini sec. 37", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("2", "Rajghat II ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add("3", "Mundhela kalan ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add(" ", "Total Electric ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            table.Rows.Add(" ", "Total DTC ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add(" International", " ", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

            table.Rows.Add("1", "Kathmandu", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");

            table.Rows.Add("", "Grand Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");


            return table;
        }

        private void ResetOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_AccidentAnalysisForTheMonth", OsbId);
            dataGridView1.DataSource = BindAccidentAnalysisForTheMonth();
            setRowColNonEditable();
            MessageBox.Show("Done");
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            DeleteExisitingTableRecord("tbl_AccidentAnalysisForTheMonth", OsbId);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null || row.Cells[3].Value != null || row.Cells[4].Value != null || row.Cells[5].Value != null || row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null || row.Cells[9].Value != null || row.Cells[10].Value != null || row.Cells[11].Value != null || row.Cells[12].Value != null || row.Cells[13].Value != null || row.Cells[14].Value != null || row.Cells[15].Value != null || row.Cells[16].Value != null || row.Cells[17].Value != null || row.Cells[18].Value != null || row.Cells[19].Value != null || row.Cells[20].Value != null || row.Cells[21].Value != null || row.Cells[22].Value != null || row.Cells[23].Value != null || row.Cells[24].Value != null || row.Cells[25].Value != null || row.Cells[26].Value != null || row.Cells[27].Value != null || row.Cells[28].Value != null || row.Cells[27].Value != null || row.Cells[28].Value != null || row.Cells[30].Value != null || row.Cells[31].Value != null || row.Cells[32].Value != null || row.Cells[33].Value != null || row.Cells[34].Value != null || row.Cells[35].Value != null || row.Cells[36].Value != null || row.Cells[37].Value != null || row.Cells[38].Value != null || row.Cells[39].Value != null || row.Cells[40].Value != null || row.Cells[41].Value != null)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [rpt].[tbl_AccidentAnalysisForTheMonth] ([OsbId],[S_No],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16],[Param17],[Param18],[Param19],[Param20],[Param21],[Param22],[Param23],[Param24],[Param25],[Param26],[Param27],[Param28],[Param29],[Param30],[Param31],[Param32],[Param33],[Param34],[Param35],[Param36],[Param37],[Param38],[Param39],[Param40],[Param41]) VALUES (@OsbId,@S_No,@Param1,@Param2,@Param3,@Param4,@Param5,@Param6,@Param7,@Param8,@Param9,@Param10,@Param11,@Param12,@Param13,@Param14,@Param15,@Param16,@Param17,@Param18,@Param19,@Param20,@Param21,@Param22,@Param23,@Param24,@Param25,@Param26,@Param27,@Param28,@Param29,@Param30,@Param31,@Param32,@Param33,@Param34,@Param35,@Param36,@Param37,@Param38,@Param39,@Param40,@Param41)", con);
                        cmd.Parameters.AddWithValue("@OsbId", OsbId);
                        cmd.Parameters.AddWithValue("@S_No", row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString());
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
                        cmd.Parameters.AddWithValue("@Param13", row.Cells[13].Value == null ? "" : row.Cells[13].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param14", row.Cells[14].Value == null ? "" : row.Cells[14].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param15", row.Cells[15].Value == null ? "" : row.Cells[15].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param16", row.Cells[16].Value == null ? "" : row.Cells[16].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param17", row.Cells[17].Value == null ? "" : row.Cells[17].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param18", row.Cells[18].Value == null ? "" : row.Cells[18].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param19", row.Cells[19].Value == null ? "" : row.Cells[19].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param20", row.Cells[20].Value == null ? "" : row.Cells[20].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param21", row.Cells[21].Value == null ? "" : row.Cells[21].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param22", row.Cells[22].Value == null ? "" : row.Cells[22].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param23", row.Cells[23].Value == null ? "" : row.Cells[23].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param24", row.Cells[24].Value == null ? "" : row.Cells[24].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param25", row.Cells[25].Value == null ? "" : row.Cells[25].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param26", row.Cells[26].Value == null ? "" : row.Cells[26].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param27", row.Cells[27].Value == null ? "" : row.Cells[27].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param28", row.Cells[28].Value == null ? "" : row.Cells[28].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param29", row.Cells[29].Value == null ? "" : row.Cells[29].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param30", row.Cells[30].Value == null ? "" : row.Cells[30].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param31", row.Cells[31].Value == null ? "" : row.Cells[31].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param32", row.Cells[32].Value == null ? "" : row.Cells[32].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param33", row.Cells[33].Value == null ? "" : row.Cells[33].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param34", row.Cells[34].Value == null ? "" : row.Cells[34].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param35", row.Cells[35].Value == null ? "" : row.Cells[35].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param36", row.Cells[36].Value == null ? "" : row.Cells[36].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param37", row.Cells[37].Value == null ? "" : row.Cells[37].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param38", row.Cells[38].Value == null ? "" : row.Cells[38].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param39", row.Cells[39].Value == null ? "" : row.Cells[39].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param40", row.Cells[40].Value == null ? "" : row.Cells[40].Value.ToString());
                        cmd.Parameters.AddWithValue("@Param41", row.Cells[41].Value == null ? "" : row.Cells[41].Value.ToString());
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
            DeleteExisitingTableRecord("tbl_AccidentAnalysisForTheMonth", OsbId);
            dataGridView1.DataSource = BindAccidentAnalysisForTheMonth();
            MessageBox.Show("Done");
        }

        private void AccidentAnalysisForTheMonth_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = BindAccidentAnalysisForTheMonth();
            BindIndexPage(OsbId);
        }

        private void Print_ReportOnClick(object sender, EventArgs e)
        {
            rptAccidentAnalysisForTheMonth objFrm = new rptAccidentAnalysisForTheMonth(OsbId, Year, Month, finYear, MonthName);
            objFrm.Show();
        }

        void CalcalculateTotal()
        {
            var row = dataGridView1.Rows;

            #region Calculating_VerticalSum

            for (int i = 2; i <= 36; i++)
            {
                if (i <= 21)
                {
                    dataGridView1.Rows[34].Cells[i].Value = Common.GetSum(row, 0, 33, i);
                }
                if (i >= 27 && i < 37)
                {
                    dataGridView1.Rows[34].Cells[i].Value = Common.GetSum(row, 0, 33, i);
                }

            }

            #endregion

            #region Calculating_HorizontalSum
            for (int i = 0; i < (row.Count - 1); i++)
            {

                if (i >= 0)
                {
                    if (i != 35 && i != 40 && i != 39 && i != 42)
                    {
                        dataGridView1.Rows[i].Cells[6].Value = Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[5].Value.ToString());
                        dataGridView1.Rows[i].Cells[11].Value = Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[8].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[9].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[10].Value.ToString());

                        dataGridView1.Rows[i].Cells[16].Value = Common.ConvertToDecimal(row[i].Cells[12].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[13].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[14].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[15].Value.ToString());

                        dataGridView1.Rows[i].Cells[17].Value = Common.ConvertToDecimal(row[i].Cells[2].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[7].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[12].Value.ToString());
                        dataGridView1.Rows[i].Cells[18].Value = Common.ConvertToDecimal(row[i].Cells[3].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[8].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[13].Value.ToString());
                        dataGridView1.Rows[i].Cells[19].Value = Common.ConvertToDecimal(row[i].Cells[4].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[9].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[14].Value.ToString());
                        dataGridView1.Rows[i].Cells[20].Value = Common.ConvertToDecimal(row[i].Cells[5].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[10].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[15].Value.ToString());
                        dataGridView1.Rows[i].Cells[21].Value = Common.ConvertToDecimal(row[i].Cells[17].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[18].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[19].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[20].Value.ToString());


                        dataGridView1.Rows[i].Cells[31].Value = Common.ConvertToDecimal(row[i].Cells[27].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[28].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[29].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[30].Value.ToString());
                        dataGridView1.Rows[i].Cells[36].Value = Common.ConvertToDecimal(row[i].Cells[32].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[33].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[34].Value.ToString()) + Common.ConvertToDecimal(row[i].Cells[35].Value.ToString());

                    }
                }
            }
            #endregion

            // grand total
            for (int i = 2; i <= 41; i++)
            {
                // Total Electric
                dataGridView1.Rows[39].Cells[i].Value = Common.GetSum(row, 36, 38, i);

                // Total DTC
                dataGridView1.Rows[40].Cells[i].Value = Common.ConvertToDecimal(dataGridView1.Rows[34].Cells[i].Value.ToString()) + Common.ConvertToDecimal(dataGridView1.Rows[39].Cells[i].Value.ToString());

                // For Grand Total
                dataGridView1.Rows[43].Cells[i].Value = Common.ConvertToDecimal(row[40].Cells[i].Value.ToString()) + Common.ConvertToDecimal(row[42].Cells[i].Value.ToString());

            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcalculateTotal();
        }

        private void setRowColNonEditable()
        {

            Common.SetColumnNonEditable(dataGridView1, 6, 42);
            Common.SetColumnNonEditable(dataGridView1, 11, 42);
            Common.SetColumnNonEditable(dataGridView1, 16, 42);
            Common.SetColumnNonEditable(dataGridView1, 17, 42);
            Common.SetColumnNonEditable(dataGridView1, 18, 42);
            Common.SetColumnNonEditable(dataGridView1, 19, 42);
            Common.SetColumnNonEditable(dataGridView1, 20, 42);
            Common.SetColumnNonEditable(dataGridView1, 21, 42);
            Common.SetColumnNonEditable(dataGridView1, 31, 42);
            Common.SetColumnNonEditable(dataGridView1, 36, 42);

            Common.SetRowNonEditable(dataGridView1, 34);
            Common.SetRowNonEditable(dataGridView1, 35);
            Common.SetRowNonEditable(dataGridView1, 39);
            Common.SetRowNonEditable(dataGridView1, 40);
            Common.SetRowNonEditable(dataGridView1, 41);
            Common.SetRowNonEditable(dataGridView1, 43);
        }
    }
}
