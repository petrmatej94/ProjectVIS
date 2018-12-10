using ProjectVIS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.DataLayer.DataMapper
{
    public static class RecordDataMapper
    {

        public static String SQL_INSERT = "INSERT INTO Record VALUES " 
            + "(@Ammount, @PointsTaken, @DateOfEntry, @ExpireDate, @PaidDate, @driverID, @employeeID, @fineTypeID); " 
            + "SELECT CAST(scope_identity() AS int);";

        public static String SQL_SELECT_RECORDS_BY_DRIVER_ID = "SELECT record.ID, Ammount, PointsTaken, DateOfEntry, ExpireDate, PaidDate, record.employeeID, employee.Name, type.Category FROM Driver driver "
            + "JOIN Record record ON record.driverID = driver.ID "
            + "JOIN Employee employee ON employee.ID = record.employeeID "
            + "Join FineType type ON type.ID = record.fineTypeID "
            + "WHERE record.driverID = @ID ORDER BY DateOfEntry DESC";

        public static String SQL_UPDATE = "UPDATE Record SET PaidDate=@PaidDate WHERE ID=@ID";
        public static String SQL_SELECT_ID = "SELECT * FROM Record WHERE ID=@id";


        public static List<Record> FindAllByID(int id)
        {
            List<Record> list = null;

            using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(SQL_SELECT_RECORDS_BY_DRIVER_ID, connection);
                command.Parameters.AddWithValue("@ID", id);
                

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    list = new List<Record>();
                    while (reader.Read())
                    {
                        list.Add(MapCustom(reader));
                    }
                }
            }

            return list;
        }

        public static Record FindByID(int id)
        {
            Record record = null;

            using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(SQL_SELECT_ID, connection);
                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        record = Map(reader);
                    }
                }
            }
            return record;
        }
        
        public static int Save(Record record)
        {
            int recordID = -1;
            using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(SQL_INSERT, connection))
                {
                    command.Parameters.AddWithValue("@Ammount", record.Ammount);
                    command.Parameters.AddWithValue("@PointsTaken", record.PointsTaken);
                    command.Parameters.AddWithValue("@DateOfEntry", record.DateOfEntry);
                    command.Parameters.AddWithValue("@ExpireDate", record.ExpireDate);
                    if(record.PaidDate == null)
                    {
                        command.Parameters.AddWithValue("@PaidDate", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@PaidDate", record.PaidDate);
                    }
                    command.Parameters.AddWithValue("@driverID", record.driverID);
                    command.Parameters.AddWithValue("@employeeID", record.employeeID);
                    command.Parameters.AddWithValue("@fineTypeID", record.fineTypeID);
                    recordID = (int)command.ExecuteScalar();
                }
            }

            return recordID;
        }



        public static int Update(Record obj)
        {
            int ret = 0;

            using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(SQL_UPDATE, connection);
                command.Parameters.AddWithValue("@PaidDate", obj.PaidDate);
                command.Parameters.AddWithValue("@ID", obj.ID);

                ret = command.ExecuteNonQuery();
            }
            return ret;
        }



        private static Record Map(SqlDataReader reader)
        {
            int i = 0;
            Record record = new Record();
            record.ID = reader.GetInt32(i++);
            record.Ammount = reader.GetInt32(i++);
            record.PointsTaken = reader.GetInt32(i++);
            record.DateOfEntry = reader.GetDateTime(i++);
            record.ExpireDate = reader.GetDateTime(i++);
            try
            {
                record.PaidDate = reader.GetDateTime(i++);
            }
            catch
            {
                record.PaidDate = null;
            }
            record.driverID = reader.GetInt32(i++);
            record.employeeID = reader.GetInt32(i++);
            record.fineTypeID = reader.GetInt32(i++);

            return record;
        }



        private static Record MapCustom(SqlDataReader reader)
        {
            int i = 0;
            Record record = new Record();
            record.ID = reader.GetInt32(i++);
            record.Ammount = reader.GetInt32(i++);
            record.PointsTaken = reader.GetInt32(i++);
            record.DateOfEntry = reader.GetDateTime(i++);
            record.ExpireDate = reader.GetDateTime(i++);
            try
            {
                record.PaidDate = reader.GetDateTime(i++);
            }
            catch
            {
                record.PaidDate = null;
            }
            record.employeeID = reader.GetInt32(i++);
            record.EmployeeName = reader.GetString(i++);
            record.FineType = reader.GetString(i++);

            return record;
        }

    }




}
