using Dapper;
using DET.Booking.DataAccess.Interfaces;
using DET.Booking.Models;
using System.Data;

namespace DET.Booking.DataAccess
{
    public class Booking : IBooking
    {
        private IConnectionManager connectionManager;

        public Booking(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public async Task<Response<string>> SaveReserve(Reservation reservation)
        {
            using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

            var resultado = await connection.QueryAsync<Models.ServiceResponse>(

                "[sp_ReservarCita]",
                param: new
                {
                    reservation.PersonName,
                    reservation.PersonEmail,
                    reservation.PersonPhoneNumber,
                    CreateUserCustomer = reservation.CreateUser,
                    reservation.EmployeeID,
                    reservation.ServiceID,
                    reservation.Date,
                    reservation.Hour,
                    CreateUserReservation = reservation.CreateUser
                },
                commandType: CommandType.StoredProcedure
            );

            return new Response<string> { Content = "Reserva guardada correctamente", IsSuccess = true, Message = "Reserva guardada correctamente" };
        }

        public async Task<Response<Reservation>> UpdateStateReserve(Reservation reservation)
        {
            using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

            var resultado = await connection.QueryAsync<Models.Reservation>(

                "[Reservation_UpdateState]",
                param: new
                {
                    reservation.ReservationID,
                    NewStateId = reservation.State,
                    reservation.ModificationUser
                },
                commandType: CommandType.StoredProcedure
            );

            return new Response<Reservation> { Content = resultado.FirstOrDefault(), IsSuccess = true, Message = "Reserva actualizada correctamente" };
        }

        public async Task<Response<List<Reservation>>> GetNextReservations()
        {
            using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

            var resultado = await connection.QueryAsync<Reservation>(

               "[Reservation_GetNextReservations]",
                param: new
                {
                    Id = 1
                },
                commandType: CommandType.StoredProcedure
            );

            return new Response<List<Reservation>> { Content = resultado.ToList(), IsSuccess = true, Message = "Reserva guardada correctamente" };
        }

        public async Task MarkAsNotifiedAsync(int reservaId)
        {
            using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

            var resultado = await connection.QueryAsync<Reservation>(

               "[Reservation_MarkAsNotifiedAsync]",
                param: new
                {
                    Id = 1
                },
                commandType: CommandType.StoredProcedure
            );
        }

    }
}
