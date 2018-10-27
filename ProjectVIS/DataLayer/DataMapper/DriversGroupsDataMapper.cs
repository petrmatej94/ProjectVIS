using ProjectVIS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.DataLayer.DataMapper
{
    public class DriversGroupsDataMapper
    {




        private DriversLicenseGroups Map(SqlDataReader reader)
        {
            int i = 0;
            DriversLicenseGroups obj = new DriversLicenseGroups();
            obj.driverID = reader.GetInt32(i++);
            obj.groupID = reader.GetInt32(i++);

            return obj;
        }
    }
}
