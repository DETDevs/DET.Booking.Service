using Dapper;
using DET.Booking.DataAccess.Interfaces;
using DET.Booking.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    reservation.EmployeeID,
                    reservation.ServiceID,
                    reservation.Fecha,
                    reservation.Hora,
                    reservation.Cliente,
                    reservation.CreateUser
                },
                commandType: CommandType.StoredProcedure
            );

            return new Response<string> { Content = "Reserva guardada correctamente", IsSuccess = true, Message = "Reserva guardada correctamente" };
        }
    }
}
