using ProjectVIS.DataLayer.DataMapper;
using ProjectVIS.Models;
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
    public partial class LoginForm : Form
    {

        LoginManager manager = LoginManager.Instance;
        ErrorProvider errorProvider = new ErrorProvider();



        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            int login = -1;

            try
            {
                login = Convert.ToInt32(loginBox.Text);
            }
            catch
            {
                errorProvider.SetError(loginBox, "Wrong credentials");
            }

            string password = passBox.Text;
            Employee employee = null;
            Driver driver = null;

            driver = DriverDataMapper.FindByLicenseNumber(login);
            if (driver == null)
            {
                employee = EmployeeDataMapper.FindByID(login);
            }

            if (driver != null)
            {
                if (driver.Password == password)
                {
                    //prihlasen ridic
                    manager.login = login;
                    manager.password = password;
                    manager.userType = "driver";

                    DriverProfile form = new DriverProfile();
                    form.Show();
                    this.Hide();
                }
            }
            else if (employee != null)
            {
                if (employee.Password == password)
                {
                    //prihlasen zamestnanec
                    manager.login = login;
                    manager.password = password;
                    manager.userType = "employee";

                    EmployeeInterfaceForm form = new EmployeeInterfaceForm();
                    form.Show();
                    this.Hide();
                }
            }
            else
            {
                errorProvider.SetError(loginBox, "Wrong credentials");
                errorProvider.SetError(passBox, "Wrong credentials");
                return;
            }


            //EmployeeInterfaceForm form = new EmployeeInterfaceForm();
            //form.Show();
            //this.Hide();


        }
    }
}
