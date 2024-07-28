using DataAccess.Models;

namespace DataAccess.DBAccess
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transactions>> GetAllTransactionsAsync(DateTime? startDate, DateTime? endDate);
        Task<int> InsertTransactionAsync(Transactions transaction);
    }
}