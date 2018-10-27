using ProjectVIS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.DataLayer.DataMapper
{
    public class FineTypeDataMapper
    {




        private FineType Map(SqlDataReader reader)
        {
            int i = 0;
            FineType obj = new FineType();
            obj.ID = reader.GetInt32(i++);
            obj.Category = reader.GetString(i++);
            obj.Description = reader.GetString(i++);
            obj.MaxFine = reader.GetInt32(i++);
            obj.PointPenalty = reader.GetInt32(i++);
            obj.State = reader.GetBoolean(i++);

            return obj;
        }
    }
}
