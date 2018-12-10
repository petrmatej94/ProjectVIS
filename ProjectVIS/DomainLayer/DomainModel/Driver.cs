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
        public string Street { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public string Residence { get; set; }
        public DateTime BirthDate { get; set; }
        public int RemainingPoints { get; set; }
        public int LicenseNumber { get; set; }
        public DateTime LicenseValidity { get; set; }
        public Boolean State { get; set; }
        public string Password { get; set; }





        public override string ToString()
        {
            return ID + " " + Name + " " + Street + " " + Town + " " + Country + " " + Residence +
                   " " + BirthDate + " " + RemainingPoints + " " + LicenseNumber + " " + LicenseValidity + " " + State;
        }


        public bool PointsLessThenZero()
        {
            return RemainingPoints <= 0 ? true : false;
        }

        public void SubtractPoints(int cnt)
        {
            this.RemainingPoints -= cnt;
        }

        public void ConfiscateLicense()
        {
            this.State = false;
        }
    }
}
