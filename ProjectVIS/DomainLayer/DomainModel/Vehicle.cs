using ProjectVIS.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.Models
{
    public class Vehicle : IdentityField
    {
        public int ID { get; set; }
        public string Vin { get; set; }
        public string Spz { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public int driverID { get; set; }
        public Boolean State { get; set; }


        public override string ToString()
        {
            return ID + " " + Vin + " " + Spz + " " + Brand + " " + Model + " " + Type + " " + Color + " " + driverID + " " + State;
        }
    }
}
