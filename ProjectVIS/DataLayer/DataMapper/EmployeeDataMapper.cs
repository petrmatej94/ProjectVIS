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
    public static class EmployeeDataMapper
    {
        public static String SQL_SELECT_ID = "SELECT * FROM Employee WHERE ID=@id";


        public static Employee FindByID(int id)
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




        private static Employee MapEmployee(SqlDataReader reader)
        {
            int i = 0;
            Employee employee = new Employee();
            employee.ID = reader.GetInt32(i++);
            employee.Name = reader.GetString(i++);
            employee.Rank = reader.GetString(i++);
            employee.officeID = reader.GetInt32(i++);
            employee.State = reader.GetBoolean(i++);
            employee.Password = reader.GetString(i++);


            return employee;
        }




        // XML PART

        private static int freeID = 0;
        private static string filePath;
        private static XmlDocument xmlDoc;

        public static bool LoadXMLDocument(string path)
        {
            filePath = path;
            xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            XmlNode root = xmlDoc.DocumentElement;
            XmlNode freeIDNode = root.SelectSingleNode("freeID");

            freeID = Convert.ToInt32(freeIDNode.InnerText);

            return true;
        }

        public static Employee XMLSelect(int ID)
        {
            Employee obj = new Employee();

            XmlNode root = xmlDoc.DocumentElement;
            XmlNodeList list = root.SelectNodes("Employee");

            XmlNode objNode = null;

            foreach (XmlNode node in list)
            {
                XmlNodeList childs = node.ChildNodes;

                foreach (XmlNode child in childs)
                {
                    if (child.Name == "ID")
                    {
                        objNode = (child.InnerText == ID.ToString()) ? node : null;
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

        public static Employee XMLMap(XmlNode node)
        {
            Employee obj = new Employee();

            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == "ID")
                {
                    obj.ID = Convert.ToInt32(child.InnerText);
                }
                if (child.Name == "Password")
                {
                    obj.Password = child.InnerText;
                }
                if (child.Name == "Name")
                {
                    obj.Name = child.InnerText;
                }
                if (child.Name == "Rank")
                {
                    obj.Rank = child.InnerText;
                }
            }
            return obj;
        }
    }
}
