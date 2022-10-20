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
    public partial class rptFleetUtilization : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);


        public rptFleetUtilization(int OsbId, int Year, int Month, string finYear, string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;
        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void rptFleetUtilization_Load(object sender, EventArgs e)
        {
            var MonthList = GlobalMaster.GetPrevousMonthList(Month, Year, 5);
            //  dt.Rows.Add("Physical Parameter", MonthList[4].MonthName + "-" + MonthList[4].Year, MonthList[3].MonthName + "-" + MonthList[3].Year, MonthList[2].MonthName + "-" + MonthList[2].Year, MonthList[1].MonthName + "-" + MonthList[1].Year, MonthList[0].MonthName + "-" + MonthList[0].Year);
            string date1 = MonthList[4].MonthName + "-" + MonthList[4].Year;
            string date2 = MonthList[4].MonthName + "-" + MonthList[4].Year;
            string date3 = MonthList[4].MonthName + "-" + MonthList[4].Year;
           
            chart1.Series["Series1"].Points.AddY(87.75);
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            chart1.Series["Series1"].Points[0].Color = Color.Red;
            chart1.Series["Series1"].Points[0].AxisLabel = date1;
            chart1.Series["Series1"].Points[0].Label = "87.75";

            chart1.Series["Series1"].Points.AddY(87.19);
            chart1.Series["Series1"].Points[1].Color = Color.Red;
            chart1.Series["Series1"].Points[1].AxisLabel = date2;
            chart1.Series["Series1"].Points[1].Label = "87.19";

            chart1.Series["Series1"].Points.AddY(87.01);
            chart1.Series["Series1"].Points[2].Color = Color.Red;
            chart1.Series["Series1"].Points[2].AxisLabel = date3;
            chart1.Series["Series1"].Points[2].Label = "87.01";

            chart1.Series["Series1"].Points.AddY(84.13);
            chart1.Series["Series1"].Points[3].Color = Color.Red;
            chart1.Series["Series1"].Points[3].AxisLabel = this.finYear;
            chart1.Series["Series1"].Points[3].Label = "84.13";


            chart1.Series["Series1"].Points.AddY(85.32);
            chart1.Series["Series1"].Points[4].Color = Color.Red;
            chart1.Series["Series1"].Points[4].AxisLabel = this.finYear;
            chart1.Series["Series1"].Points[4].Label = "85.32";

            chart1.Series["Series1"].Points.AddY(90.43);
            chart1.Series["Series1"].Points[5].Color = Color.Red;
            chart1.Series["Series1"].Points[5].AxisLabel = this.finYear;
            chart1.Series["Series1"].Points[5].Label = "90.43";

            chart1.Series["Series1"].Points.AddY(87.11);
            chart1.Series["Series1"].Points[6].Color = Color.Red;
            chart1.Series["Series1"].Points[6].AxisLabel = this.finYear;
            chart1.Series["Series1"].Points[6].Label = "87.11";

            chart1.Series["Series1"].Points.AddY(89.19);
            chart1.Series["Series1"].Points[7].Color = Color.Red;
            chart1.Series["Series1"].Points[7].AxisLabel = this.finYear;
            chart1.Series["Series1"].Points[7].Label = "89.19";

            chart1.Series["Series1"].Points.AddY(83.95);
            chart1.Series["Series1"].Points[8].Color = Color.Red;
            chart1.Series["Series1"].Points[8].AxisLabel = this.finYear;
            chart1.Series["Series1"].Points[8].Label = "83.95";

            chart1.Series["Series1"].Points.AddY(83.24);
            chart1.Series["Series1"].Points[9].Color = Color.Red;
            chart1.Series["Series1"].Points[9].AxisLabel = this.finYear;
            chart1.Series["Series1"].Points[9].Label = "83.24";

            chart1.Series["Series1"].Points.AddY(79.78);
            chart1.Series["Series1"].Points[10].Color = Color.Red;
            chart1.Series["Series1"].Points[10].AxisLabel = this.finYear;
            chart1.Series["Series1"].Points[10].Label = "89.78";

            chart1.Series["Series1"].Points.AddY(80.77);
            chart1.Series["Series1"].Points[11].Color = Color.Red;
            chart1.Series["Series1"].Points[11].AxisLabel = this.finYear;
            chart1.Series["Series1"].Points[11].Label = "80.77";

            chart1.Series["Series1"].Points.AddY(82.76);
            chart1.Series["Series1"].Points[12].Color = Color.Red;
            chart1.Series["Series1"].Points[12].AxisLabel = this.finYear;
            chart1.Series["Series1"].Points[12].Label = "82.76";





          //  chart1.Series["Series1"].Points.AddXY(87.75, date1);
          

        }
    }
}
