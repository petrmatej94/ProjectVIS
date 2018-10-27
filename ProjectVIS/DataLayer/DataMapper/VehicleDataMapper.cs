using ProjectVIS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.DataLayer.DataMapper
{
    public class VehicleDataMapper
    {





        private Vehicle Map(SqlDataReader reader)
        {
            int i = 0;
            Vehicle obj = new Vehicle();
            obj.ID = reader.GetInt32(i++);
            obj.Vin = reader.GetString(i++);
            obj.Spz = reader.GetString(i++);
            obj.Brand = reader.GetString(i++);
            obj.Model = reader.GetString(i++);
            obj.Type = reader.GetString(i++);
            obj.Color = reader.GetString(i++);
            obj.driverID = reader.GetInt32(i++);
            obj.State = reader.GetBoolean(i++);

            return obj;
        } 
    }
}
