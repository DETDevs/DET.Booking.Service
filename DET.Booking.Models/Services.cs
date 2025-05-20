using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DET.Booking.Models
{
    public class Services
    {
        public long ServiceID { get; set; }
        public string BusinessID { get; set; }
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DutarionMin { get; set; }
        public string Price { get; set; }
        public string DiasHabiles { get; set; }
        public bool IsActive { get; set; }
        public string CreateUser { get; set; }
        public string CreateDate { get; set; }
        public string ModificationUser { get; set; }
        public string ModificationDate { get; set; }
    }
}
