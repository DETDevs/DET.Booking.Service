using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DET.Booking.Models
{
    public class User
    {
        public long UsuarioID { get; set; }
        public long BusinessID { get; set; }
        public long PersonID { get; set; }
        public int RolID { get; set; }
        public string ContraseñaHash { get; set; }
        public string CreateUser { get; set; }
        public string CreateDate { get; set; }
        public string ModificationUser { get; set; }
        public string ModificationDate { get; set; }
    }
}
