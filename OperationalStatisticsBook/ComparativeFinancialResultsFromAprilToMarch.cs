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
    public partial class ComparativeFinancialResultsFromAprilToMarch : Form
    {
        int OsbId = 0;
        int Year = 0;
        int Month = 0;
        string MonthName = "";
        string finYear = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ConnectionString);

        public ComparativeFinancialResultsFromAprilToMarch(int OsbId, int Year, int Month, string finYear, string MonthName)
        {
            InitializeComponent();
            this.OsbId = OsbId;
            this.Year = Year;
            this.Month = Month;
            this.finYear = finYear;
            this.MonthName = MonthName;
        }






        private void ResetOnClick(object sender, EventArgs e)
        {

        }

        private void SaveOnClick(object sender, EventArgs e)
        {

        }

        private void ComparativeFinancialResultsFromAprilToMarch_Load(object sender, EventArgs e)
        {

        }
    }
}
