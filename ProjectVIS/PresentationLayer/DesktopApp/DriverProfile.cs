using ProjectVIS.DataLayer.DataMapper;
using ProjectVIS.Models;
using ProjectVIS.PresentationLayer.DesktopApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        LoginManager manager;
        Driver driver;
        private int licenseNumber;
        

        public DriverProfile(int licenseNumber = 0)
        {
            InitializeComponent();
            manager = LoginManager.Instance;

            if(manager.userType == "employee")
            {
                this.licenseNumber = licenseNumber;
                if (licenseNumber != 0)
                {
                    OpenRecord(licenseNumber);
                }
            }
            else if(manager.userType == "driver")
            {
                buttonNewRecord.Hide();
                OpenRecord(manager.login);
            }
        }

        public bool OpenRecord(int number)
        {
            driver = new DriverDataMapper().FindByLicenseNumber(number);
            LoadData();

            return true;
        }

        public bool LoadData()
        {
            NameLabel.Text = driver.Name;
            BoxStreet.Text = driver.Street;
            BoxTown.Text = driver.Town;
            BoxCountry.Text = driver.Country;
            BoxResidence.Text = driver.Residence;
            BoxBirthDate.Text = driver.BirthDate.ToString();
            BoxLicenseNumber.Text = driver.LicenseNumber.ToString();
            BoxLicenseValidity.Text = driver.LicenseValidity.ToString();
            BoxRemainingPoints.Text = driver.RemainingPoints.ToString();
            CheckState.Checked = driver.State;


            List<LicenseGroup> list = LicenseGroupDataMapper.FindAllByID(driver.ID);

            if (list != null)
            {
                foreach (LicenseGroup obj in list)
                {
                    listBox1.Items.Add("  " + obj.Group + "\t-\t" + obj.Description);
                }
            }

            return true;
        }



       

        private void buttonNewRecord_Click(object sender, EventArgs e)
        {
            //NewRecordForm form = new NewRecordForm(this.licenseNumber);
            //form.Show();
        }

        private void buttonShowVehicles_Click(object sender, EventArgs e)
        {
            DriverVehiclesForm form = new DriverVehiclesForm(driver.ID);
            form.Show();
        }

        private void buttonShowRecords_Click(object sender, EventArgs e)
        {
            DriverRecordsForm form = new DriverRecordsForm(driver.ID);
            form.Show();
        }

        private void buttonNewRecord_Click_1(object sender, EventArgs e)
        {
            NewRecordForm form = new NewRecordForm(driver.ID);
            form.Owner = this;
            form.Show();
        }

        private void buttonPayments_Click(object sender, EventArgs e)
        {
            //pass
        }
    }
}
