using ProjectVIS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.DataLayer.DataMapper
{
    public static class VehicleDataMapper
    {

        private static String SQL_SELECT_ID = "SELECT * FROM Vehicle WHERE driverID=@driverID";
        private static String SQL_SELECT_SPZ = "SELECT * FROM Vehicle WHERE SPZ=@SPZ";


        public static List<Vehicle> FindAllDriverVehicles(int driverID)
        {
            List<Vehicle> list = null;

            using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(SQL_SELECT_ID, connection);
                command.Parameters.AddWithValue("@driverID", driverID);


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    list = new List<Vehicle>();
                    while (reader.Read())
                    {
                        list.Add(Map(reader));
                    }
                }
            }

            return list;
        }

        public static Vehicle FindBySPZ(string SPZ)
        {
            Vehicle vehicle = null;

            using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(SQL_SELECT_SPZ, connection);
                command.Parameters.AddWithValue("@SPZ", SPZ);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vehicle = Map(reader);
                    }
                }
            }
            return vehicle;
        }

        private static Vehicle Map(SqlDataReader reader)
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
