using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DET.Booking.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public long BusinessID { get; set; }
        public long PersonaID { get; set; }
        public long Puesto { get; set; }
        public bool IsActive { get; set; }
        public string CreateUser { get; set; }
        public string CreateDate { get; set; }
        public string ModificationUser { get; set; }
        public string ModificationDate { get; set; }
    }
}
