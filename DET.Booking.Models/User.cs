using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DET.Booking.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int BusinessID { get; set; }
        public int RolID { get; set; }
        public string? RolName { get; set; }
        public string Password { get; set; } // Solo para uso interno, no se guarda así
        public string PasswordHash { get; set; } // Se genera en la capa lógica

        public string CreateUser { get; set; }
    }
}
