using DET.Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DET.Booking.DataAccess.Interfaces
{
    public interface IService
    {
        Task<Response<IEnumerable<ServiceResponse>>> GetAsyncServices(ServiceResponse services);
        Task<Response<IEnumerable<ServiceScheduleResponse>>> GetServiceSchedule(int employeeID, DateTime fecha);
    }
}
