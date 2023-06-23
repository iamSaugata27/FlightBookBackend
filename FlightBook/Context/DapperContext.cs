using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace FlightBook.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionstring);
    }
}
