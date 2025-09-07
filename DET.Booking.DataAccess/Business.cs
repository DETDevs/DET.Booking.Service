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
    public class Business : IBusiness
    {
        private IConnectionManager _connectionManager;

        public Business(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public async Task<Response<IEnumerable<Models.Business>>> GetBusiness(Models.Business business)
        {
            using var connection = this._connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

            var result = await connection.QueryAsync<Models.Business>(

                "[Business_Listar]",
                param: new
                {
                    business.Code,
                },
                commandType: System.Data.CommandType.StoredProcedure
            );

            return new Response<IEnumerable<Models.Business>>
            {
                Content = result,
                IsSuccess = true,
                Message = "Businesses listed successfully"
            };
        }

        public async Task<Response<Models.Business>> SaveBusiness(Models.Business business)
        {
            using var connection = this._connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

            var result = await connection.QueryAsync<Models.Business>(

                "[Business_Guardar]",
                param: new
                {
                    business.Name,
                    business.Code,
                    business.PrimaryColor,
                    business.SecondColor,
                    business.Logo,
                    business.CreateUser

                },
                commandType: System.Data.CommandType.StoredProcedure
            );

            return new Response<Models.Business>
            {
                Content = result.FirstOrDefault(),
                IsSuccess = true,
                Message = "Businesses save successfully"
            };
        }

        public async Task<Response<Models.BusinessSetting<T>>> SaveBusinessSettings<T>(Models.BusinessSetting<T> setting)
        {
            using var connection = this._connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

            var result = await connection.QueryAsync<Models.BusinessSetting<T>>(
                "BusinessSettings_Guardar",
                new
                {
                    setting.SettingID,
                    setting.BusinessID,
                    setting.Key,
                    Value = setting.ValueJson,
                    setting.CreateUser,
                },
                commandType: CommandType.StoredProcedure
            );

            return new Response<Models.BusinessSetting<T>>
            {
                Content = result.FirstOrDefault(),
                IsSuccess = true,
                Message = "Settings save successfully"
            };
        }

        public async Task<BusinessSettingResponse> GetByKeyAsync(int businessId, string key)
        {
            using var connection = _connectionManager.GetConnectionString(ConnectionManager.connectionStringKey);

            var result = await connection.QueryFirstOrDefaultAsync<BusinessSettingResponse>(
                "SELECT * FROM BusinessSettings WHERE BusinessID = @BusinessID AND [Key] = @Key AND IsActive = 1",
                new { BusinessID = businessId, Key = key }
            );

            return result;
        }
    }
}
