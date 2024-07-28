using Dapper;
using DataAccess.Models;
using DataAccess.SqlDBAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBAccess
{
    public class TransactionService : ITransactionService
    {
        private readonly string _connectionString;
        private ISqlDbContext _dbContext;
        public TransactionService(ISqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Transactions>> GetAllTransactionsAsync(DateTime? startDate, DateTime? endDate)
        {
            _dbContext.SetConnectionString("DefaultConnection");
            var storedProcedureName = "GetAllTransactions";

            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new
                {
                    StartDate = startDate,
                    EndDate = endDate
                };

                // Call stored procedure with parameters for filtering
                var results = await connection.QueryAsync<Transactions>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
                return results;
            }
        }


        public async Task<int> InsertTransactionAsync(Transactions transaction)
        {
            _dbContext.SetConnectionString("DefaultConnection");
            var storedProcedureName = "InsertTransaction";
            using (var connection = _dbContext.CreateConnection())
            {
                var results = await connection.ExecuteAsync(storedProcedureName, new
                {
                    transaction.ProductId,
                    transaction.TransactionTypeID,
                    transaction.Quantity,
                    transaction.CreateBy
                }
                , commandType: CommandType.StoredProcedure);
                return results;
            }
        }
    }
}
