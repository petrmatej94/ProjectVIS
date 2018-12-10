using ProjectVIS.DataLayer.DataMapper;
using ProjectVIS.Models;
using ProjectVIS.Program;
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
    public partial class DriverVehiclesForm : Form
    {
        private int ID;


        public DriverVehiclesForm(int id)
        {
            InitializeComponent();
            ID = id;

            LoadData();
        }

        public void LoadData()
        {
            List<Vehicle> list = VehicleDataMapper.FindAllDriverVehicles(ID);

            if(list != null)
            {
                BindingList<Vehicle> bindingList = new BindingList<Vehicle>(list);
                dataGrid.AutoGenerateColumns = false;
                dataGrid.DataSource = bindingList;
            }
        }
    }
}
