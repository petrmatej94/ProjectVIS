using ProjectVIS.Program.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectVIS.Program
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            LoginForm form = new LoginForm();
            form.Show();
            form.MdiParent = this; 
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
