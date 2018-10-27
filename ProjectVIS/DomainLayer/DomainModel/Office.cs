using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.Models
{
    public class Office
    {
        public int ID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public Boolean State { get; set; }


        public override string ToString()
        {
            return ID + " " + Street + " " + City + " " + Country + " " + Type + " " + State;
        }
    }
}
