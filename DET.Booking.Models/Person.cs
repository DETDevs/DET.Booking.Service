using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DET.Booking.Models
{
    public class Person
    {
        public int PK_Person { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public string CreateUser { get; set; }
        public string CreateDate { get; set; }
        public string ModificationUser { get; set; }
        public string ModificationDate { get; set; }
    }
}
