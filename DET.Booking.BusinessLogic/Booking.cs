using DET.Booking.BusinessLogic.Interfaces;
using DET.Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DET.Booking.BusinessLogic
{
    public class Booking : IBooking
    {
        private readonly DataAccess.Interfaces.IBooking? _booking;

        public Booking(DataAccess.Interfaces.IBooking? booking)
        {
            this._booking = booking;
        }

        public async Task<Response<string>> SaveReserve(Reservation reservation)
        {
            return await _booking.SaveReserve(reservation);
        }
    }
}
