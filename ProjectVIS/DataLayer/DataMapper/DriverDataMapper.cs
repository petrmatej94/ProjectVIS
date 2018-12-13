using Newtonsoft.Json;
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
    public static class DriverDataMapper
    {
        public static String SQL_SELECT_ALL = "SELECT * FROM Driver";
        public static String SQL_SELECT_ID = "SELECT * FROM Driver WHERE ID=@id";
        public static String SQL_SELECT_LICENSE = "SELECT * FROM Driver WHERE LicenseNumber=@number";
        public static String SQL_INSERT = "INSERT INTO Driver VALUES (@Name, @Street, @Town, @Country, @Residence, @BirthDate, "
                                        + "@RemainingPoints, @LicenseNumber, @LicenseValidity, @State, @Password);"
                                        + "SELECT CAST(scope_identity() AS int);";

        public static String SQL_UPDATE = "UPDATE Driver SET Name=@Name, Street=@Street, Town=@Town, Country=@Country, "
                                + "Residence=@Residence, BirthDate=@BirthDate, RemainingPoints=@RemainingPoints, "
                                + "LicenseNumber=@LicenseNumber, LicenseValidity=@LicenseValidity, State=@State, Password=@Password "
                                + "WHERE ID=@id";



        private static int freeID = 0;
        private static string filePath = "../XML/Driver.xml";
        private static XmlDocument xmlDoc;

        static DriverDataMapper()
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




        public static List<Driver> FindAll()
        {
            List<Driver> list = null;

            using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(SQL_SELECT_ALL, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(MapDriver(reader));
                    }
                }
            }


            return list;
        }

        public static Driver FindByID(int id)
        {
            if(Settings.DataProvider == DataProviderType.SqlServer)
            {
                Driver driver = null;

                using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(SQL_SELECT_ID, connection);
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            driver = MapDriver(reader);
                        }
                    }
                }
                return driver;
            }
            else
            {
                Driver driver = new Driver();

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
                    driver = XMLMap(objNode);
                }

                return driver;
            }
        }

        public static Driver FindByLicenseNumber(int number)
        {
            Driver driver = null;

            using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(SQL_SELECT_LICENSE, connection);
                command.Parameters.AddWithValue("@number", number);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        driver = MapDriver(reader);
                    }
                }
            }
            return driver;
        }

        public static int Save(Driver obj)
        {
            if(Settings.DataProvider == DataProviderType.SqlServer)
            {
                int driverID = -1;
                using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(SQL_INSERT, connection);
                    //command.Parameters.AddWithValue("@ID", obj.ID); //idk if ID too? Should be autogenerated
                    command.Parameters.AddWithValue("@Name", obj.Name);
                    command.Parameters.AddWithValue("@Street", obj.Street);
                    command.Parameters.AddWithValue("@Town", obj.Street);
                    command.Parameters.AddWithValue("@Country", obj.Country);
                    command.Parameters.AddWithValue("@Residence", obj.Residence);
                    command.Parameters.AddWithValue("@BirthDate", obj.BirthDate);
                    command.Parameters.AddWithValue("@RemainingPoints", obj.RemainingPoints);
                    command.Parameters.AddWithValue("@LicenseNumber", obj.LicenseNumber);
                    command.Parameters.AddWithValue("@LicenseValidity", obj.LicenseValidity);
                    command.Parameters.AddWithValue("@State", obj.State);
                    command.Parameters.AddWithValue("@Password", obj.Password);

                    driverID = (int)command.ExecuteScalar();
                }
                return driverID;
            }
            else
            {
                XMLInsert(obj);
                return freeID;
            }
            
        }

        public static int Update(Driver obj)
        {
            if(Settings.DataProvider == DataProviderType.SqlServer)
            {
                int ret = 0;

                using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(SQL_UPDATE, connection);
                    command.Parameters.AddWithValue("@ID", obj.ID);
                    command.Parameters.AddWithValue("@Name", obj.Name);
                    command.Parameters.AddWithValue("@Street", obj.Street);
                    command.Parameters.AddWithValue("@Town", obj.Street);
                    command.Parameters.AddWithValue("@Country", obj.Country);
                    command.Parameters.AddWithValue("@Residence", obj.Residence);
                    command.Parameters.AddWithValue("@BirthDate", obj.BirthDate);
                    command.Parameters.AddWithValue("@RemainingPoints", obj.RemainingPoints);
                    command.Parameters.AddWithValue("@LicenseNumber", obj.LicenseNumber);
                    command.Parameters.AddWithValue("@LicenseValidity", obj.LicenseValidity);
                    command.Parameters.AddWithValue("@State", obj.State);
                    command.Parameters.AddWithValue("@Password", obj.Password);

                    ret = command.ExecuteNonQuery();
                }
                return ret;
            }
            else
            {
                xmlDoc.Load(filePath);
                XmlNode root = xmlDoc.DocumentElement;
                XmlNodeList list = root.SelectNodes("Driver");

                XmlNode driverNode = null;

                foreach (XmlNode node in list)
                {
                    XmlNodeList childs = node.ChildNodes;

                    foreach (XmlNode child in childs)
                    {
                        if (child.Name == "ID") // && child.InnerText == driver.ID.ToString())
                        {
                            driverNode = (child.InnerText == obj.ID.ToString()) ? node : null;
                            driverNode = node;
                            break;
                        }
                    }

                    if (driverNode != null)
                        break;
                }

                foreach (XmlNode child in driverNode.ChildNodes)
                {
                    if (child.Name == "Name")
                    {
                        child.InnerText = obj.Name;
                    }
                    if (child.Name == "Street")
                    {
                        child.InnerText = obj.Street;
                    }
                    if (child.Name == "Town")
                    {
                        child.InnerText = obj.Town;
                    }
                    if (child.Name == "Country")
                    {
                        child.InnerText = obj.Country;
                    }
                    if (child.Name == "Residence")
                    {
                        child.InnerText = obj.Residence;
                    }
                    if (child.Name == "BirthDate")
                    {
                        child.InnerText = obj.BirthDate.ToString();
                    }
                    if (child.Name == "RemainingPoints")
                    {
                        child.InnerText = obj.RemainingPoints.ToString();
                    }
                    if (child.Name == "LicenseNumber")
                    {
                        child.InnerText = obj.LicenseNumber.ToString();
                    }
                    if (child.Name == "LicenseValidity")
                    {
                        child.InnerText = obj.LicenseValidity.ToString();
                    }
                    if (child.Name == "State")
                    {
                        child.InnerText = obj.State.ToString();
                    }
                    if (child.Name == "Password")
                    {
                        child.InnerText = obj.Password;
                    }
                }

                XMLSaveDocument();

                return 1;
            }

        }

        //not physicaly deleted, only state is changed to false = inactive driver
        public static int DeleteID(int id)
        {
            int ret = 0;

            using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(SQL_UPDATE, connection);
                Driver obj = FindByID(id);
                obj.State = false;
                Update(obj);

                ret = command.ExecuteNonQuery();
            }
            return ret;
        }

        private static Driver MapDriver(SqlDataReader reader)
        {
            int i = 0;
            Driver driver = new Driver();
            driver.ID = reader.GetInt32(i++);
            driver.Name = reader.GetString(i++);
            driver.Street = reader.GetString(i++);
            driver.Town = reader.GetString(i++);
            driver.Country = reader.GetString(i++);
            driver.Residence = reader.GetString(i++);
            driver.BirthDate = reader.GetDateTime(i++);
            driver.RemainingPoints = reader.GetInt32(i++);
            driver.LicenseNumber = reader.GetInt32(i++);
            driver.LicenseValidity = reader.GetDateTime(i++);
            driver.State = reader.GetBoolean(i++);
            driver.Password = reader.GetString(i++);

            return driver;
        }






        //XML PART

        private static void XMLSaveDocument()
        {
            XmlNode root = xmlDoc.DocumentElement;
            XmlNode freeIDNode = root.SelectSingleNode("freeID");
            freeIDNode.InnerText = freeID.ToString();

            xmlDoc.Save(filePath);
        }
        
        private static bool XMLInsert(Driver driver)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            XmlElement root = xmlDoc.DocumentElement;
            XmlElement elem = xmlDoc.CreateElement("Driver");

            XmlElement id = xmlDoc.CreateElement("ID");
            id.InnerText = freeID.ToString();
            driver.ID = freeID;
            freeID = freeID + 1;
            elem.AppendChild(id);

            XmlElement Name = xmlDoc.CreateElement("Name");
            Name.InnerText = driver.Name;
            elem.AppendChild(Name);

            XmlElement Street = xmlDoc.CreateElement("Street");
            Street.InnerText = driver.Street;
            elem.AppendChild(Street);

            XmlElement Town = xmlDoc.CreateElement("Town");
            Town.InnerText = driver.Town;
            elem.AppendChild(Town);

            XmlElement Country = xmlDoc.CreateElement("Country");
            Country.InnerText = driver.Country;
            elem.AppendChild(Country);

            XmlElement Residence = xmlDoc.CreateElement("Residence");
            Residence.InnerText = driver.Residence;
            elem.AppendChild(Residence);

            XmlElement BirthDate = xmlDoc.CreateElement("BirthDate");
            BirthDate.InnerText = driver.BirthDate.ToString();
            elem.AppendChild(BirthDate);

            XmlElement RemainingPoints = xmlDoc.CreateElement("RemainingPoints");
            RemainingPoints.InnerText = driver.RemainingPoints.ToString();
            elem.AppendChild(RemainingPoints);

            XmlElement LicenseNumber = xmlDoc.CreateElement("LicenseNumber");
            LicenseNumber.InnerText = driver.LicenseNumber.ToString();
            elem.AppendChild(LicenseNumber);

            XmlElement LicenseValidity = xmlDoc.CreateElement("LicenseValidity");
            LicenseValidity.InnerText = driver.LicenseValidity.ToString();
            elem.AppendChild(LicenseValidity);

            XmlElement State = xmlDoc.CreateElement("State");
            State.InnerText = driver.State.ToString();
            elem.AppendChild(State);

            XmlElement Password = xmlDoc.CreateElement("Password");
            Password.InnerText = driver.Password;
            elem.AppendChild(Password);


            root.AppendChild(elem);
            XMLSaveDocument();

            return true;
        }
      

        public static Driver XMLMap(XmlNode node)
        {
            Driver driver = new Driver();

            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == "ID")
                {
                    driver.ID = Convert.ToInt32(child.InnerText);
                }
                if (child.Name == "Name")
                {
                    driver.Name = Convert.ToString(child.InnerText);
                }
                if (child.Name == "Street")
                {
                    driver.Street = child.InnerText;
                }
                if (child.Name == "Town")
                {
                    driver.Town = child.InnerText;
                }
                if (child.Name == "Country")
                {
                    driver.Country = child.InnerText;
                }
                if (child.Name == "Residence")
                {
                    driver.Residence = child.InnerText;
                }
                if (child.Name == "BirthDate")
                {
                    driver.BirthDate = Convert.ToDateTime(child.InnerText);
                }
                if (child.Name == "RemainingPoints")
                {
                    driver.RemainingPoints = Convert.ToInt32(child.InnerText);
                }
                if (child.Name == "LicenseNumber")
                {
                    driver.LicenseNumber = Convert.ToInt32(child.InnerText);
                }
                if (child.Name == "LicenseValidity")
                {
                    driver.LicenseValidity = Convert.ToDateTime(child.InnerText);
                }
                if (child.Name == "State")
                {
                    driver.State = Convert.ToBoolean(child.InnerText);
                }
                if (child.Name == "Password")
                {
                    driver.Password = child.InnerText;
                }
            }
            return driver;
        }

    }
}
