using System;
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
    public partial class DriverProfile : Form
    {
        public DriverProfile()
        {
            InitializeComponent();
        }

        private void buttonNewRecord_Click(object sender, EventArgs e)
        {
            //
            NewRecordForm form = new NewRecordForm();
            form.Show();
        }
    }
}
