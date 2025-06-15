
using DET.Booking.Models;

namespace DET.Booking.BusinessLogic.Interfaces
{
    public interface IUser
    {
        Task<Response<int>> RegisterUser(User user);
        Task<Response<Token>> LoginAsync(User user);
    }
}
