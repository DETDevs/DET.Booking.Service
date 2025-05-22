using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DET.Booking.Models
{
    public class BusinessConfigApis
    {
        public int BusinessConfigApisID { get; set; }
        public int BusinessID { get; set; }
        public bool IsActive { get; set; }
        public string CreateUser { get; set; }
        public string CreateDate { get; set; }
        public string ModificationUser { get; set; }
        public string ModificationDate { get; set; }
    }
}
