﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class BarTrafficEarninginCrore : Form
    {
        public BarTrafficEarninginCrore()
        {
            InitializeComponent();
        }

        private void BarTrafficEarninginCrore_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
