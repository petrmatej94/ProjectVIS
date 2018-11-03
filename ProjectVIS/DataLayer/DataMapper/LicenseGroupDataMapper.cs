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

        public static String SQL_SELECT_ID = "SELECT * FROM LicenseGroup WHERE ID=@id";


        public static List<LicenseGroup> FindAllByID(int id)
        {
            List<LicenseGroup> list = null;

            using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(SQL_SELECT_ID, connection);
                command.Parameters.AddWithValue("@ID", id);


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    list = new List<LicenseGroup>();
                    while (reader.Read())
                    {
                        list.Add(Map(reader));
                    }
                }
            }

            return list;
        }




        private static LicenseGroup Map(SqlDataReader reader)
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
