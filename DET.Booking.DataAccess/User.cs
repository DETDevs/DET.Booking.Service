

using Dapper;
using DET.Booking.DataAccess.Interfaces;
using DET.Booking.Models;
using System.Data;

namespace DET.Booking.DataAccess
{
    public class User : Interfaces.IUser
    {
        private IConnectionManager connectionManager;

        public User(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public async Task<Response<int>> RegisterUser(Models.User user)
        {
            using var connection = this.connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

            var resultado = await connection.ExecuteAsync(

                "[User_Register]",
                param: new
                {
                   user.Name,
                   user.Email,
                   user.PhoneNumber,
                   user.BusinessID,
                   user.RolID,
                   user.PasswordHash,
                   user.CreateUser
                },
                commandType: CommandType.StoredProcedure
            );

            return new Response<int> { Content = resultado, IsSuccess = true, Message = "Usuario registrado correctamente." };
        }


        public async Task<Models.User> GetUser(string email)
        {
            using var connection = connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

            var result = await connection.QueryFirstOrDefaultAsync<Models.User>(
                "[User_SearchByEmail]",
                new { Email= email },
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}
