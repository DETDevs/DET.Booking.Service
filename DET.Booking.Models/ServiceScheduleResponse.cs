using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DET.Booking.Models
{
    public class ServiceScheduleResponse
    {
        public TimeSpan HoraDesde { get; set; }
        public TimeSpan HoraHasta { get; set; }
    }
}
