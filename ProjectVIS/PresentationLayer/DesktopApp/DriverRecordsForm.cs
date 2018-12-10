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
    public partial class DriverRecordsForm : Form
    {
        private int ID;

        public DriverRecordsForm(int id)
        {
            InitializeComponent();
            ID = id;
            LoadData();
        }

        public void LoadData()
        {
            List<Record> list = RecordDataMapper.FindAllByID(ID);

            if(list != null)
            {
                BindingList<Record> bindingList = new BindingList<Record>(list);
                dataGrid.AutoGenerateColumns = false;
                dataGrid.DataSource = bindingList;
            }
        }

        private Record GetSelectedRecord()
        {
            if (dataGrid.SelectedRows.Count == 1)
            {
                Record record = dataGrid.SelectedRows[0].DataBoundItem as Record;
                return record;
            }
            else
            {
                return null;
            }
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Record record = GetSelectedRecord();
            if(record != null) {
                PaymentForm form = new PaymentForm(record);
                form.Owner = this;
                form.Show();
            }
        }
    }
}
