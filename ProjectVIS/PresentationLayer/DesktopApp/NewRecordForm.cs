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
    public partial class NewRecordForm : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();
        LoginManager manager;
        private int driverID;
        FineTypeDataMapper fineMapper;

        public NewRecordForm(int id)
        {
            InitializeComponent();
            manager = LoginManager.Instance;
            fineMapper = new FineTypeDataMapper();
            driverID = id;
            loadData();
        }

        private bool loadData()
        {
            bool ret = false;

            List<FineType> list = fineMapper.FindAll();
            comboRecordCategory.DisplayMember = "Category";
            comboRecordCategory.ValueMember = "ID";
            comboRecordCategory.DataSource = list;

            //Vyplnit tabulku
            FineType type = fineMapper.FindByID((int)comboRecordCategory.SelectedValue);
            boxRecordAmmount.Text = type.MaxFine.ToString();
            boxRecordPoints.Text = type.PointPenalty.ToString();

            return ret;
        }

        private void buttonRecordConfirm_Click(object sender, EventArgs e)
        {
            string category = comboRecordCategory.Text;
            int expireDays;
            int ammount;
            int points;

            try
            {
                expireDays = Convert.ToInt32(boxRecordExpire.Text);
                errorProvider.Clear();
            }
            catch
            {
                errorProvider.SetError(boxRecordExpire, "Field must contains number");
                return;
            }

            try
            {
                ammount = Convert.ToInt32(boxRecordAmmount.Text);
                errorProvider.Clear();
            }
            catch
            {
                errorProvider.SetError(boxRecordAmmount, "Field must contains number");
                return;
            }

            try
            {
                points = Convert.ToInt32(boxRecordPoints.Text);
                errorProvider.Clear();
            }
            catch
            {
                errorProvider.SetError(boxRecordPoints, "Field must contains number");
                return;
            }
            

            //vytvorit novy zaznam
            Record record = new Record();
            record.Ammount = ammount;
            record.PointsTaken = points;
            record.DateOfEntry = DateTime.Now;
            record.ExpireDate = record.DateOfEntry.AddDays(expireDays);

            if(checkBoxPaid.Checked)
            {
                record.PaidDate = DateTime.Now;
            }
            else
            {
                record.PaidDate = null;
            }
            record.driverID = driverID;
            record.employeeID = manager.login;
            record.fineTypeID = (int)comboRecordCategory.SelectedValue;

            
            RecordDataMapper.Save(record);


            if (record.PointsTaken > 0)
            {
                //odebrat body ridici
                DriverDataMapper driverMapper = new DriverDataMapper();
                Driver driver = driverMapper.FindByID(record.driverID);
                driver.SubtractPoints(record.PointsTaken);
                driverMapper.Save(driver);  //UPDATE

                
                if (driver.PointsLessThenZero())
                {
                    string message = "Body ridice <= 0. Odebrat RP";
                    MessageBox.Show(message, "Upozornění", MessageBoxButtons.OK);
                }
            }

            this.Owner.Refresh();
            this.Close();
        }

        private void boxRecordPoints_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboRecordCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FineType type = fineMapper.FindByID((int)comboRecordCategory.SelectedValue);
            boxRecordAmmount.Text = type.MaxFine.ToString();
            boxRecordPoints.Text = type.PointPenalty.ToString();
        }
    }
}
