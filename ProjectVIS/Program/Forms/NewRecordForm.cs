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


        public NewRecordForm()
        {
            InitializeComponent();
        }

        private void buttonRecordConfirm_Click(object sender, EventArgs e)
        {
            string category = comboRecordCategory.Text;
            int expireDays;
            int ammount;

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

            //vytvorit novy zaznam
            Record record = new Record();
            //ID - najit nejvyssi ID v DB?
            record.ID = 1;
            record.Ammount = ammount;
            //PointsTaken podle typu zaznamu, tj. vyhledat v DB...
            record.PointsTaken = 2;
            record.DateOfEntry = DateTime.Now;
            record.ExpireDate = record.DateOfEntry.AddDays(expireDays);
            record.PaidDate = null;
            //DriverID - get from previous window
            record.driverID = 1;
            //employeeID - get from
            record.employeeID = 1;
            //FineTypeID - search DB by value ID
            record.fineTypeID = 1;


            //record save
            RecordDataMapper.Save(record);


            this.Close();
        }

        private void boxRecordPoints_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
