
using DET.Booking.DataAccess.Interfaces;
using DET.Booking.Models;
using System.Data;
using Dapper;

namespace DET.Booking.DataAccess
{
    public class Employee : IEmployee
    {
        private IConnectionManager connectionManager;
        public Employee(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public async Task<Response<IEnumerable<ResponseEmployee>>> GetEmployee(ResponseEmployee employee)
        {
            using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

            var resultado = await connection.QueryAsync<Models.ResponseEmployee>(

                "[Employee_Listar]",
                param: new
                {
                    employee.EmployeeID
                },
                commandType: CommandType.StoredProcedure
            );

            return new Response<IEnumerable<ResponseEmployee>> { Content = resultado, IsSuccess = true, Message = "Empleados listados correctamente" };
        }

        public async Task<Response<ResponseEmployee>> SaveEmployee(ResponseEmployee employee)
        {
            using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

            var resultado = await connection.QueryAsync<Models.ResponseEmployee>(

                "[Employee_Guardar]",
                param: new
                {
                    employee.PersonID,
                    employee.BusinessID,
                    Name = employee.EmployeeName,
                    Email = employee.EmployeeEmail,
                    PhoneNumber = employee.EmployeePhoneNumber,
                    Puesto = employee.Workstation,
                    employee.CreateUser

                },
                commandType: CommandType.StoredProcedure
            );

            return new Response<ResponseEmployee> { Content = resultado.FirstOrDefault(), IsSuccess = true, Message = "Empleado guardadado correctamente" };
        }
    }
}
