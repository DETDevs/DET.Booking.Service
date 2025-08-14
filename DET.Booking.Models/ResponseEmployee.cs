using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DET.Booking.Models
{
    public class ResponseEmployee
    {
        public int? EmployeeID { get; set; }
        public int BusinessID { get; set; }
        public string? BusinessName { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public int Workstation { get; set; }
        public bool? IsActive { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? ModificationUser { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
