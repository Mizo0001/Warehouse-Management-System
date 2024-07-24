using DataAccess.Models;
using DataAccess.SqlDBAccess;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBAccess
{
    public class TransactionTypeService : ITransactionTypeService
    {
        private readonly string _connectionString;
        private ISqlDbContext _dbContext;
        public TransactionTypeService(ISqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TransactionTypes>> GetAllTransactionTypeAsync()
        {
            _dbContext.SetConnectionString("DefaultConnection");
            var storedProcedureName = "GetAllTransactionTypes";
            using (var connection = _dbContext.CreateConnection())
            {
                var results = await connection.QueryAsync<TransactionTypes>(storedProcedureName, new { }
                , commandType: CommandType.StoredProcedure);
                return results;
            }
        }
        public async Task<TransactionTypes> GetTransactionTypeByIdAsync(int id)
        {
            _dbContext.SetConnectionString("DefaultConnection");
            var storedProcedureName = "GetTransactionTypeById";
            using (var connection = _dbContext.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<TransactionTypes>(
                    storedProcedureName,
                    new { TransactionTypeID = id },
                    commandType: CommandType.StoredProcedure
                );
                return result;
            }
        }

    }
}
