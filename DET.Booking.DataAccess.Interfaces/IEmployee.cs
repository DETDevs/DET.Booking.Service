
using DET.Booking.Models;

namespace DET.Booking.DataAccess.Interfaces
{
    public interface IEmployee
    {
        Task<Response<IEnumerable<ResponseEmployee>>> GetEmployee(ResponseEmployee employee);
        Task<Response<ResponseEmployee>> SaveEmployee(ResponseEmployee employee);
    }
}
