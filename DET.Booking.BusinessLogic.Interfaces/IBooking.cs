using DET.Booking.Models;


namespace DET.Booking.BusinessLogic.Interfaces
{
    public interface IBooking
    {
        Task<Response<string>> SaveReserve(Reservation reservation);
        Task<Response<Reservation>> UpdateStateReserve(Reservation reservation);

        Task<List<Reservation>> GetNextReservations();
        Task SendAsyncReminder(Reservation reserva);
    }
}
