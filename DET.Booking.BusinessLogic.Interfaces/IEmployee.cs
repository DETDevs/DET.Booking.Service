using DET.Booking.Models;

namespace DET.Booking.BusinessLogic.Interfaces
{
    public interface IEmployee
    {
        Task<Response<IEnumerable<ResponseEmployee>>> GetEmployee(ResponseEmployee employee);
    }
}
