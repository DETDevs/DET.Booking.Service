using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DET.Booking.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int EmployeeID { get; set; }
        public int ServiceID { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string? Name { get; set; }
        public string? Emailo{ get; set; }
        public string PhoneNumber{ get; set; }
        public string? IsActive { get; set; }
        public bool Estado { get; set; } = true;
        public string CreateUser { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public string? ModificationUser { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
