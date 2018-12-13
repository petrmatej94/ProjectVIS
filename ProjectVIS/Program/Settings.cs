using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.DataLayer.Repository
{
    public static class Settings
    {
        public static DataProviderType DataProvider { get; set; }

        static Settings()
        {
            DataProvider = DataProviderType.XmlFileStore;
            //DataProvider = DataProviderType.SqlServer;
        }
    }

    public enum DataProviderType
    {
        SqlServer,
        XmlFileStore
    }
}
