﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectVIS.Program.Forms
{
    public partial class EmployeeInterfaceForm : Form
    {
        public EmployeeInterfaceForm()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

            //logika hledani atd
            DriverProfile form = new DriverProfile();
            form.Show();
        }
    }
}
