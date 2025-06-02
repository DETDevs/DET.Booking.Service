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
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public string? PersonName { get; set; }
        public string? PersonEmail{ get; set; }
        public string PersonPhoneNumber{ get; set; }
        public string? IsActive { get; set; }
        public int State { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public string? ModificationUser { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
