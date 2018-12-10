using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIS.Models
{
    public class Record
    {
        public int ID { get; set; }
        public int Ammount{ get; set; }
        public int PointsTaken { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public int driverID { get; set; }
        public int employeeID { get; set; }
        public int fineTypeID { get; set; }


        public string EmployeeName { get; set; }
        public string FineType { get; set; }



        public override string ToString()
        {
            return ID + " " + Ammount + " " + " " + PointsTaken + DateOfEntry + " " + ExpireDate + " " + PaidDate + " " + driverID + " " + employeeID + " " + fineTypeID;
        }

        public string ToStringVypis()
        {
            return ID + " " + Ammount + " " + PointsTaken + " " + DateOfEntry + " " + employeeID + " " + EmployeeName + " " + FineType;
        }

        public void SetPaidDate(DateTime date)
        {
            this.PaidDate = date;
        }
    }
}
