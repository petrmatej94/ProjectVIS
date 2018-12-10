using ProjectVIS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.DataLayer.DataMapper
{
    public static class FineTypeDataMapper
    {
        public static String SQL_SELECT_ALL = "SELECT * FROM FineType";
        private static String SQL_SELECT_ID = "SELECT * FROM FineType WHERE ID=@id";


        public static List<FineType> FindAll()
        {
            List<FineType> list = null;

            using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQL_SELECT_ALL, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    list = new List<FineType>();
                    while (reader.Read())
                    {
                        list.Add(Map(reader));
                    }
                }
            }
            
            return list;
        }

        public static FineType FindByID(int id)
        {
            FineType obj = null;

            using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(SQL_SELECT_ID, connection);
                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        obj = Map(reader);
                    }
                }
            }
            return obj;
        }



        private static FineType Map(SqlDataReader reader)
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
