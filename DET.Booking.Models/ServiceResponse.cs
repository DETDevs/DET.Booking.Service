using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DET.Booking.Models
{
    public class ServiceResponse
    {
        // Campos de Services
        public long ServiceID { get; set; }
        public int? BusinessID { get; set; }
        public int? EmployeeID { get; set; }
        public string ServiceName { get; set; }    
        public string Description { get; set; }
        public string DutarionMin { get; set; }
        public string Price { get; set; }
        public string DiasHabiles { get; set; }
        public bool IsActive { get; set; }
        public string CreateUser { get; set; }
        public string CreateDate { get; set; }
        public string ModificationUser { get; set; }
        public string ModificationDate { get; set; }

        // Campos "combinados" de Business
        public string BusinessName { get; set; }

        // Campos "combinados" de Employee/Person
        public string EmployeeName { get; set; }
        
    }
}
