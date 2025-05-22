using System.Data;

namespace DET.Booking.DataAccess.Interfaces
{
    public interface IConnectionManager
    {
        IDbConnection GetConnectionString(string key);
    }
}
