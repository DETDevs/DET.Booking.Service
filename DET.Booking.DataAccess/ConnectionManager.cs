using DET.Booking.DataAccess.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DET.Booking.DataAccess
{
    public class ConnectionManager : IConnectionManager
    {
        public const string connectionStringKey = "BD_KEY";
        private readonly IConfiguration configuration;

        public ConnectionManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IDbConnection GetConnectionString(string key)
        {
            return new SqlConnection(ConfigurationExtensions.GetConnectionString(configuration, $"{key}"));
        }
    }
}
