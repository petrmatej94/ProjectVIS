using ProjectVIS.DataLayer.Repository;
using ProjectVIS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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




        private static int freeID = 0;
        private static string filePath = "../XML/Record.xml";
        private static XmlDocument xmlDoc;

        static RecordDataMapper()
        {
            if (Settings.DataProvider == DataProviderType.XmlFileStore)
            {
                xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);

                XmlNode root = xmlDoc.DocumentElement;
                XmlNode freeIDNode = root.SelectSingleNode("freeID");

                freeID = Convert.ToInt32(freeIDNode.InnerText);
            }
        }




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
            if(Settings.DataProvider == DataProviderType.SqlServer)
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
            else
            {
                Record obj = new Record();

                XmlNode root = xmlDoc.DocumentElement;
                XmlNodeList list = root.SelectNodes("Driver");

                XmlNode objNode = null;

                foreach (XmlNode node in list)
                {
                    XmlNodeList childs = node.ChildNodes;

                    foreach (XmlNode child in childs)
                    {
                        if (child.Name == "ID")
                        {
                            objNode = (child.InnerText == id.ToString()) ? node : null;
                            break;
                        }
                    }

                    if (objNode != null)
                    {
                        break;
                    }
                }

                if (objNode != null)
                {
                    obj = XMLMap(objNode);
                }

                return obj;
            }
        }
        
        public static int Save(Record obj)
        {
            if (Settings.DataProvider == DataProviderType.SqlServer)
            {
                int recordID = -1;
                using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL_INSERT, connection))
                    {
                        command.Parameters.AddWithValue("@Ammount", obj.Ammount);
                        command.Parameters.AddWithValue("@PointsTaken", obj.PointsTaken);
                        command.Parameters.AddWithValue("@DateOfEntry", obj.DateOfEntry);
                        command.Parameters.AddWithValue("@ExpireDate", obj.ExpireDate);
                        if (obj.PaidDate == null)
                        {
                            command.Parameters.AddWithValue("@PaidDate", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@PaidDate", obj.PaidDate);
                        }
                        command.Parameters.AddWithValue("@driverID", obj.driverID);
                        command.Parameters.AddWithValue("@employeeID", obj.employeeID);
                        command.Parameters.AddWithValue("@fineTypeID", obj.fineTypeID);
                        recordID = (int)command.ExecuteScalar();
                    }
                }

                return recordID;
            }
            else
            {
                XmlElement root = xmlDoc.DocumentElement;
                XmlElement elem = xmlDoc.CreateElement("Record");

                XmlElement id = xmlDoc.CreateElement("ID");
                id.InnerText = freeID.ToString();
                obj.ID = freeID;
                freeID = freeID + 1;
                elem.AppendChild(id);

                XmlElement Ammount = xmlDoc.CreateElement("Ammount");
                Ammount.InnerText = obj.Ammount.ToString();
                elem.AppendChild(Ammount);

                XmlElement PointsTaken = xmlDoc.CreateElement("PointsTaken");
                PointsTaken.InnerText = obj.PointsTaken.ToString();
                elem.AppendChild(PointsTaken);

                XmlElement DateOfEntry = xmlDoc.CreateElement("DateOfEntry");
                DateOfEntry.InnerText = obj.DateOfEntry.ToString();
                elem.AppendChild(DateOfEntry);

                XmlElement ExpireDate = xmlDoc.CreateElement("ExpireDate");
                ExpireDate.InnerText = obj.ExpireDate.ToString();
                elem.AppendChild(ExpireDate);

                XmlElement PaidDate = xmlDoc.CreateElement("PaidDate");
                PaidDate.InnerText = obj.PaidDate.ToString();
                elem.AppendChild(PaidDate);

                XmlElement driverID = xmlDoc.CreateElement("driverID");
                driverID.InnerText = obj.driverID.ToString();
                elem.AppendChild(driverID);

                XmlElement employeeID = xmlDoc.CreateElement("employeeID");
                employeeID.InnerText = obj.employeeID.ToString();
                elem.AppendChild(employeeID);

                XmlElement fineTypeID = xmlDoc.CreateElement("fineTypeID");
                fineTypeID.InnerText = obj.fineTypeID.ToString();
                elem.AppendChild(fineTypeID);

                root.AppendChild(elem);
                XMLSaveDocument();

                return 1;
            }
                
        }



        public static int Update(Record obj)
        {

            if (Settings.DataProvider == DataProviderType.SqlServer)
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
            else
            {
                xmlDoc.Load(filePath);
                XmlNode root = xmlDoc.DocumentElement;
                XmlNodeList list = root.SelectNodes("Record");

                XmlNode objNode = null;

                foreach (XmlNode node in list)
                {
                    XmlNodeList childs = node.ChildNodes;

                    foreach (XmlNode child in childs)
                    {
                        if (child.Name == "ID" && child.InnerText == obj.ID.ToString())
                        {
                            objNode = node;
                            Console.WriteLine(objNode.InnerXml);
                            break;
                        }
                    }

                    if (objNode != null)
                        break;
                }

                foreach (XmlNode child in objNode.ChildNodes)
                {
                    if (child.Name == "Ammount")
                    {
                        child.InnerText = obj.Ammount.ToString();
                    }
                    if (child.Name == "PointsTaken")
                    {
                        child.InnerText = obj.PointsTaken.ToString();
                    }
                    if (child.Name == "DateOfEntry")
                    {
                        child.InnerText = obj.DateOfEntry.ToString();
                    }
                    if (child.Name == "ExpireDate")
                    {
                        child.InnerText = obj.ExpireDate.ToString();
                    }
                    if (child.Name == "PaidDate")
                    {
                        child.InnerText = obj.PaidDate.ToString();
                    }
                    if (child.Name == "driverID")
                    {
                        child.InnerText = obj.driverID.ToString();
                    }
                    if (child.Name == "employeeID")
                    {
                        child.InnerText = obj.employeeID.ToString();
                    }
                    if (child.Name == "fineTypeID")
                    {
                        child.InnerText = obj.fineTypeID.ToString();
                    }

                }

                XMLSaveDocument();

                return 1;
            }

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



        private static void XMLSaveDocument()
        {
            XmlNode root = xmlDoc.DocumentElement;
            XmlNode freeIDNode = root.SelectSingleNode("freeID");
            freeIDNode.InnerText = freeID.ToString();

            xmlDoc.Save(filePath);
        }
        

        public static Record XMLMap(XmlNode node)
        {
            Record obj = new Record();

            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == "ID")
                {
                    obj.ID = Convert.ToInt32(child.InnerText);
                }
                if (child.Name == "Ammount")
                {
                    obj.Ammount = Convert.ToInt32(child.InnerText);
                }
                if (child.Name == "PointsTaken")
                {
                    obj.PointsTaken = Convert.ToInt32(child.InnerText);
                }
                if (child.Name == "DateOfEntry")
                {
                    obj.DateOfEntry = Convert.ToDateTime(child.InnerText);
                }
                if (child.Name == "ExpireDate")
                {
                    obj.ExpireDate = Convert.ToDateTime(child.InnerText);
                }
                if (child.Name == "PaidDate")
                {
                    obj.PaidDate = Convert.ToDateTime(child.InnerText);
                }
                if (child.Name == "driverID")
                {
                    obj.driverID = Convert.ToInt32(child.InnerText);
                }
                if (child.Name == "employeeID")
                {
                    obj.employeeID = Convert.ToInt32(child.InnerText);
                }
                if (child.Name == "fineTypeID")
                {
                    obj.fineTypeID = Convert.ToInt32(child.InnerText);
                }
                
            }
            return obj;
        }

    }




}
