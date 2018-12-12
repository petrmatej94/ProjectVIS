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

        public static FineType XMLSelect(int ID)
        {
            FineType obj = new FineType();

            XmlNode root = xmlDoc.DocumentElement;
            XmlNodeList list = root.SelectNodes("FineType");

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

        public static FineType XMLMap(XmlNode node)
        {
            FineType obj = new FineType();

            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == "ID")
                {
                    obj.ID = Convert.ToInt32(child.InnerText);
                }
                if (child.Name == "Category")
                {
                    obj.Category = child.InnerText;
                }
                if (child.Name == "Description")
                {
                    obj.Description = child.InnerText;
                }
                if (child.Name == "MaxFine")
                {
                    obj.MaxFine = Convert.ToInt32(child.InnerText);
                }
                if (child.Name == "PointPenalty")
                {
                    obj.PointPenalty = Convert.ToInt32(child.InnerText);
                }
            }
            return obj;
        }
    }


}
