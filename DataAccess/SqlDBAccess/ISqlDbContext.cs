using System.Data;

namespace DataAccess.SqlDBAccess
{
    public interface ISqlDbContext
    {
        IDbConnection CreateConnection();
        void SetConnectionString(string connectionName);
    }
}