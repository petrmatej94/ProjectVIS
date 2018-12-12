using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectVIS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JsonTest
{
    class Program
    {
        public static int freeID = 1;

        static void Main(string[] args)
        {
            xmlDoc.Load(filePath);
            Driver driver = new Driver();
            driver.Town = "Petr";
            driver.Country = "Petr";
            driver.BirthDate = new DateTime(1994, 10, 12);
            driver.LicenseNumber = 123156464;


            Console.WriteLine(XMLSelect(1).Town);



            Console.ReadKey();
        }


        static string filePath = "../../Driver.xml";
        static XmlDocument xmlDoc = new XmlDocument();

        public static bool Insert(Driver driver)
        {
            xmlDoc.Load(filePath);

            XmlElement root = xmlDoc.DocumentElement;
            XmlElement elem = xmlDoc.CreateElement("Driver");

            XmlElement id = xmlDoc.CreateElement("ID");
            id.InnerText = freeID.ToString();
            driver.ID = freeID;
            freeID = freeID + 1;
            elem.AppendChild(id);
            
            XmlElement Town = xmlDoc.CreateElement("Town");
            Town.InnerText = driver.Town;
            elem.AppendChild(Town);

            XmlElement Country = xmlDoc.CreateElement("Country");
            Country.InnerText = driver.Country;
            elem.AppendChild(Country);
            
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

            xmlDoc.Save(filePath);

            return true;
        }

        private static void SaveDocument()
        {
            XmlNode root = xmlDoc.DocumentElement;
            XmlNode freeIDNode = root.SelectSingleNode("freeID");
            freeIDNode.InnerText = freeID.ToString();

            xmlDoc.Save(filePath);
        }



        public static Driver XMLSelect(int ID)
        {
            Driver driver = new Driver();

            XmlNode root = xmlDoc.DocumentElement;
            XmlNodeList list = root.SelectNodes("Driver");

            XmlNode guestNode = null;

            foreach (XmlNode guest in list)
            {
                XmlNodeList childs = guest.ChildNodes;

                foreach (XmlNode child in childs)
                {
                    if (child.Name == "ID")
                    {
                        guestNode = (child.InnerText == ID.ToString()) ? guest : null;
                        break;
                    }
                }

                if (guestNode != null)
                {
                    break;
                }
            }

            if (guestNode != null)
            {
                driver = XMLMap(guestNode);
            }

            return driver;
        }


        public static Driver XMLMap(XmlNode node)
        {
            Driver driver = new Driver();

            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == "Name")
                {
                    driver.Name = child.InnerText;
                }
                //if (child.Name == "Street")
                //{
                //    driver.Street = child.InnerText;
                //}
                if (child.Name == "Town")
                {
                    driver.Town = child.InnerText;
                }
                if (child.Name == "Country")
                {
                    driver.Country = child.InnerText;
                }
                //if (child.Name == "Residence")
                //{
                //    driver.Residence = child.InnerText;
                //}
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



        public static bool Update(Driver driver)
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
                    if (child.Name == "ID" && child.InnerText == driver.ID.ToString())
                    {
                        driverNode = node;
                        Console.WriteLine(driverNode.InnerXml);
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
                    child.InnerText = driver.Name;
                }
                //if (child.Name == "Street")
                //{
                //    child.InnerText = driver.Street;
                //}
                if (child.Name == "Town")
                {
                    child.InnerText = driver.Town;
                }
                if (child.Name == "Country")
                {
                    child.InnerText = driver.Country;
                }
                //if (child.Name == "Residence")
                //{
                //    child.InnerText = driver.Residence;
                //}
                if (child.Name == "BirthDate")
                {
                    child.InnerText = driver.BirthDate.ToString();
                }
                if (child.Name == "RemainingPoints")
                {
                    child.InnerText = driver.RemainingPoints.ToString();
                }
                if (child.Name == "LicenseNumber")
                {
                    child.InnerText = driver.LicenseNumber.ToString();
                }
                if (child.Name == "LicenseValidity")
                {
                    child.InnerText = driver.LicenseValidity.ToString();
                }
                if (child.Name == "State")
                {
                    child.InnerText = driver.State.ToString();
                }
                if (child.Name == "Password")
                {
                    child.InnerText = driver.Password;
                }
            }

            SaveDocument();

            return true;
        }
    }
}
