using DET.Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DET.Booking.DataAccess.Interfaces
{
    public interface IBusiness
    {
        Task<Response<IEnumerable<Business>>> GetBusiness(Business business);
        Task<Response<Business>> SaveBusiness(Business business);
        Task<Response<BusinessSetting<T>>> SaveBusinessSettings<T>(BusinessSetting<T> businessSettings);
        Task<BusinessSettingResponse> GetByKeyAsync(int businessId, string key);
    }
}
