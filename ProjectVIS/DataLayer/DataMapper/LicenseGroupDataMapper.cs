using ProjectVIS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.DataLayer.DataMapper
{
    public class LicenseGroupDataMapper
    {



        private LicenseGroup Map(SqlDataReader reader)
        {
            int i = 0;
            LicenseGroup obj = new LicenseGroup();
            obj.ID = reader.GetInt32(i++);
            obj.Group = reader.GetString(i++);
            obj.Description = reader.GetString(i++);

            return obj;
        }
    }
}
