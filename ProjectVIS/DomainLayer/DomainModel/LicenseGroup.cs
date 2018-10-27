using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.Models
{
    public class LicenseGroup
    {
        public int ID { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }


        public override string ToString()
        {
            return ID + " " + Group + " " + Description;
        }
    }
}
