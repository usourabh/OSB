using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperationalStatisticsBook
{
    public partial class rptPriceAndCostIndicies : Form
    {
        public rptPriceAndCostIndicies()
        {
            InitializeComponent();
        }

        private void rptPriceAndCostIndicies_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
