using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.Models
{
    public class Driver 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public int RemainingPoints { get; set; }
        public int LicenseNumber { get; set; }
        public DateTime LicenseValidity { get; set; }
        public Boolean State { get; set; }
        public string Password { get; set; }
    }
}
