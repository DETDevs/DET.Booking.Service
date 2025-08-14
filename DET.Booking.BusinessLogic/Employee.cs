using DET.Booking.BusinessLogic.Interfaces;
using DET.Booking.DataAccess.Interfaces;
using DET.Booking.Models;

namespace DET.Booking.BusinessLogic
{
    public class Employee : DET.Booking.BusinessLogic.Interfaces.IEmployee
    {
        private readonly DataAccess.Interfaces.IEmployee _employee;

        public Employee(DataAccess.Interfaces.IEmployee employeeDataAccess)
        {
            this._employee = employeeDataAccess;
        }

        public async Task<Response<IEnumerable<ResponseEmployee>>> GetEmployee(ResponseEmployee employee)
        {
            return await this._employee.GetEmployee(employee);
        }

        public async Task<Response<ResponseEmployee>> SaveEmployee(ResponseEmployee employee)
        {
            return await this._employee.SaveEmployee(employee);
        }
    }
}
