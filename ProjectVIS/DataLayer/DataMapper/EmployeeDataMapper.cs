using ProjectVIS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.DataLayer.DataMapper
{
    public class EmployeeDataMapper
    {
        public static String SQL_SELECT_ID = "SELECT * FROM Employee WHERE zID=@id";


        public Employee FindByID(int id)
        {
            Employee employee = null;

            using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(SQL_SELECT_ID, connection);
                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employee = MapEmployee(reader);
                    }
                }
            }
            return employee;
        }




        private Employee MapEmployee(SqlDataReader reader)
        {
            int i = 0;
            Employee employee = new Employee();
            employee.ID = reader.GetInt32(i++);
            employee.Rank = reader.GetString(i++);
            employee.officeID = reader.GetInt32(i++);
            employee.Password = reader.GetString(i++);


            return employee;
        }
    }
}
