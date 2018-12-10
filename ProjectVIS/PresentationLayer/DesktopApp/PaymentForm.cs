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

namespace ProjectVIS.PresentationLayer.DesktopApp
{
    public partial class PaymentForm : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        Record record;

        public PaymentForm(Record record)
        {
            InitializeComponent();
            this.record = record;
            boxPaymentAmmount.Text = record.Ammount.ToString();

            boxPaymentCardNumber.Text = "";
            boxPaymentCardNumber.ReadOnly = true;

            boxPaymentCSV.Text = "";
            boxPaymentCSV.ReadOnly = true;

            labelDetails.Hide();
        }

        private void buttonPaymentConfirm_Click(object sender, EventArgs e)
        {
            int cardNumber;
            int csv;

            try
            {
                cardNumber = Convert.ToInt32(boxPaymentCardNumber.Text);
            }
            catch
            {
                errorProvider.SetError(boxPaymentCardNumber, "Wrong format of Card Number");
                return;
            }

            try
            {
                csv = Convert.ToInt32(boxPaymentCSV.Text);
            }
            catch
            {
                errorProvider.SetError(boxPaymentCSV, "Wrong format of CSV");
                return;
            }


            //pseudo validace karty...
            Random rnd = new Random();
            int value = rnd.Next(10);
            if (value < 4)
            {
                //uspesna platba - pridat PaidDate do Record
                record.SetPaidDate(DateTime.Now);
                RecordDataMapper.Update(record);

                MessageBox.Show("Platba probehla v poradku", "Potvrzeni", MessageBoxButtons.OK);

                this.Owner.Refresh();
                this.Close();
            }
            else
            {
                //neuspesna platba
                MessageBox.Show("Platba se nezdarila", "Chyba", MessageBoxButtons.OK);
                return;
            }
        }

        private void comboRecordCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)comboPaymentType.SelectedItem == "Account Transfer")
            {
                labelDetails.Text = "Transfer Details:\n" +
                    "Account Number: 123456789 / 1234\n" +
                    "Variable code: 1234567\n" +
                    "Constant symbol: 0300";

                boxPaymentCardNumber.Text = "";
                boxPaymentCardNumber.ReadOnly = true;

                boxPaymentCSV.Text = "";
                boxPaymentCSV.ReadOnly = true;

                labelDetails.Show();
            }
            else if ((string)comboPaymentType.SelectedItem == "In Person")
            {
                labelDetails.Text = "Please visit our office until " + record.ExpireDate;

                boxPaymentCardNumber.Text = "";
                boxPaymentCardNumber.ReadOnly = true;

                boxPaymentCSV.Text = "";
                boxPaymentCSV.ReadOnly = true;

                labelDetails.Show();
            }
            else if ((string)comboPaymentType.SelectedItem == "Online Payment by Card")
            {
                boxPaymentCardNumber.Text = "";
                boxPaymentCardNumber.ReadOnly = false;

                boxPaymentCSV.Text = "";
                boxPaymentCSV.ReadOnly = false;

                labelDetails.Hide();
            }
        }
    }
}
