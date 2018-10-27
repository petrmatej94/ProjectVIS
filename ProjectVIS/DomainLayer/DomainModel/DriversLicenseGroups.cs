using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.Models
{
    public class DriversLicenseGroups
    {
        public int driverID { get; set; }
        public int groupID { get; set; }


        public override string ToString()
        {
            return driverID + " " + groupID;
        }
    }
}
