
using DET.Booking.Models;

namespace DET.Booking.DataAccess.Interfaces
{
    public interface IUser
    {
        Task<Response<int>> RegisterUser(User usuario);
        Task<User> GetUser(string email);
    }
}
