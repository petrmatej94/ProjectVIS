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
    public static class VehicleDataMapper
    {

        private static String SQL_SELECT_ID = "SELECT * FROM Vehicle WHERE driverID=@driverID";
        private static String SQL_SELECT_SPZ = "SELECT * FROM Vehicle WHERE SPZ=@SPZ";

        
        private static int freeID = 0;
        private static string filePath = "../XML/Vehicle.xml";
        private static XmlDocument xmlDoc;

        static VehicleDataMapper()
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
            if(Settings.DataProvider == DataProviderType.SqlServer)
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
            else
            {
                Vehicle obj = new Vehicle();

                XmlNode root = xmlDoc.DocumentElement;
                XmlNodeList list = root.SelectNodes("Vehicle");

                XmlNode objNode = null;

                foreach (XmlNode node in list)
                {
                    XmlNodeList childs = node.ChildNodes;

                    foreach (XmlNode child in childs)
                    {
                        if (child.Name == "Spz")
                        {
                            objNode = (child.InnerText == SPZ.ToString()) ? node : null;
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


        
        public static Vehicle XMLMap(XmlNode node)
        {
            Vehicle obj = new Vehicle();

            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == "ID")
                {
                    obj.ID = Convert.ToInt32(child.InnerText);
                }
                if (child.Name == "Vin")
                {
                    obj.Vin = child.InnerText;
                }
                if (child.Name == "SPZ")
                {
                    obj.Spz = child.InnerText;
                }
                if (child.Name == "Brand")
                {
                    obj.Brand = child.InnerText;
                }
                if (child.Name == "Model")
                {
                    obj.Model = child.InnerText;
                }
                if (child.Name == "Type")
                {
                    obj.Type = child.InnerText;
                }
                if (child.Name == "Color")
                {
                    obj.Color = child.InnerText;
                }
                if (child.Name == "driverID")
                {
                    obj.driverID = Convert.ToInt32(child.InnerText);
                }
            }
            return obj;
        }
    }
}
