using ProjectVIS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.DataLayer.DataMapper
{
    public class OfficeDataMapper
    {
        private static String SQL_SELECT_ALL = "SELECT * FROM Office";
        private static String SQL_SELECT_ID = "SELECT * FROM Office WHERE ID=@id";

        public List<Office> FindAll()
        {
            List<Office> list = null;

            using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(SQL_SELECT_ALL, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(Map(reader));
                    }
                }
            }


            return list;
        }

        public Office FindByID(int id)
        {
            Office obj = null;

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

        public int Save(Office obj)
        {

            return 0;
        }

        public int Delete()
        {
            return 0;
        }

        private Office Map()
        {
            return null;
        }






        private Office Map(SqlDataReader reader)
        {
            int i = 0;
            Office obj = new Office();
            obj.ID = reader.GetInt32(i++);
            obj.Street = reader.GetString(i++);
            obj.City = reader.GetString(i++);
            obj.Country = reader.GetString(i++);
            obj.Type = reader.GetString(i++);
            obj.State = reader.GetBoolean(i++);

            return obj;
        }
    }
}
