using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.Program
{
    public sealed class LoginManager
    {
        private static LoginManager instance = null;
        public int login { get; set; }
        public string password { get; set; }
        public string userType { get; set; }


        private LoginManager()
        {

        }

        public static LoginManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new LoginManager();
                }
                return instance;
            }
        }


    }
}
