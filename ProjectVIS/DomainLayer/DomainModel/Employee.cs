using ProjectVIS.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.Models
{
    public class Employee : IdentityField
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public int officeID { get; set; }
        public Boolean State { get; set; }


        public int PocetPokut { get; set; }



        public Employee()
        {

        }


        public override string ToString()
        {
            return ID + " " + Name + " " + Rank + " " + officeID + " " + State;
        }

        public string ToString2()
        {
            return ID + " " + Name + " " + PocetPokut;
        }
    }
}
