using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlDBAccess
{
    public class SqlDbContext : ISqlDbContext
    {
        private readonly IConfiguration _configuration;
        private string? _connectionString;
        public SqlDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
        public void SetConnectionString(string connectionName)
        {
            _connectionString = _configuration.GetConnectionString(connectionName);

        }
    }
}
