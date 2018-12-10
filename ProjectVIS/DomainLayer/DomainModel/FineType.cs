using ProjectVIS.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.Models
{
    public class FineType : IdentityField
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int MaxFine { get; set; }
        public int PointPenalty { get; set; }
        public Boolean State { get; set; }



        public override string ToString()
        {
            return ID + " " + Category + " " + Description + " " + MaxFine + " " + PointPenalty + " " + State;
        }
    }
}

