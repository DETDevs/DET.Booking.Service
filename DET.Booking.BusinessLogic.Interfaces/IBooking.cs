using DET.Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DET.Booking.BusinessLogic.Interfaces
{
    public interface IBooking
    {
        Task<Response<string>> SaveReserve(Reservation reservation);
    }
}
