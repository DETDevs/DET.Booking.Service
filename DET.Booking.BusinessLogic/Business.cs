using DET.Booking.BusinessLogic.Interfaces;
using DET.Booking.Models;
using System.Text.Json;

namespace DET.Booking.BusinessLogic
{
    public class Business : IBusiness
    {
        private readonly DataAccess.Interfaces.IBusiness _business;

        public Business(DataAccess.Interfaces.IBusiness businessDataAccess)
        {
            this._business = businessDataAccess;
        }

        public async Task<Response<IEnumerable<Models.Business>>> GetBusiness(Models.Business business)
        {
            return await this._business.GetBusiness(business);
        }

        public async Task<Response<Models.Business>> SaveBusiness(Models.Business business)
        {
            return await this._business.SaveBusiness(business);
        }

        public async Task<Response<BusinessSetting<T>>> SaveBusinessSettings<T>(BusinessSetting<T> businessSetting)
        {
            string jsonValue = JsonSerializer.Serialize(businessSetting.Value, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            businessSetting.ValueJson = jsonValue;

            return await this._business.SaveBusinessSettings(businessSetting);
        }

        public async Task<T> ObtenerConfiguracion<T>(int businessId, string key)
        {
            var setting = await _business.GetByKeyAsync(businessId, key);

            if (setting == null)
                throw new KeyNotFoundException($"No se encontró configuración para la clave {key}");

            return JsonSerializer.Deserialize<T>(setting.Value, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
    }
}