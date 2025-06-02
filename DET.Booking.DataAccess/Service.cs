using DET.Booking.DataAccess.Interfaces;
using DET.Booking.Models;
using System.Data;
using Dapper;

namespace DET.Booking.DataAccess
{
    public class Service : IService
    {
        private IConnectionManager connectionManager;

        public Service(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }


        public async Task<Response<IEnumerable<ServiceResponse>>> GetAsyncServices(ServiceResponse services)
        {
            using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

            var resultado = await connection.QueryAsync<Models.ServiceResponse>(

                "[Services_Listar]",
                param: new
                {
                    services.BusinessID,
                    services.EmployeeID
                },
                commandType: CommandType.StoredProcedure
            );

            return new Response<IEnumerable<ServiceResponse>> { Content = resultado, IsSuccess = true, Message = "Servicios listados correctamente" };
        }

        public async Task<Response<IEnumerable<ServiceScheduleResponse>>> GetServiceSchedule(int employeeID, DateTime fecha)
        {
            using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

            var resultado = await connection.QueryAsync<ServiceScheduleResponse>(

                "[ListAvailableSchedulesEmployee]",
                param: new
                {
                    employeeID,
                    fecha
                },
                commandType: CommandType.StoredProcedure
            );

            return new Response<IEnumerable<ServiceScheduleResponse>> { Content = resultado, IsSuccess = true, Message = "Horario disponibles listados correctamente" };
        }
    }
}
