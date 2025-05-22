using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DET.Booking.Models
{
    public class Business
    {
        public int BusinessID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondColor { get; set; }
        public string Logo { get; set; }
        public bool IsActive { get; set; }
        public string CreateUser { get; set; }
        public string CreateDate { get; set; }
        public string ModificationUser { get; set; }
        public string ModificationDate { get; set; }
    }
}
