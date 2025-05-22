using DET.Booking.BusinessLogic.Interfaces;
using DET.Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DET.Booking.BusinessLogic
{
    public class Service : IService
    {
        private readonly DataAccess.Interfaces.IService? _servicio;

        public Service(DataAccess.Interfaces.IService? servicio)
        {
            this._servicio = servicio;
        }

        public async Task<Response<IEnumerable<ServiceResponse>>> GetAsyncServices(ServiceResponse services)
        {
            return await this._servicio.GetAsyncServices(services);
        }

        public async Task<Response<IEnumerable<ServiceScheduleResponse>>> GetServiceSchedule(int employeeID, DateTime fecha)
        {
            return await this._servicio.GetServiceSchedule(employeeID, fecha);
        }
    }
}
