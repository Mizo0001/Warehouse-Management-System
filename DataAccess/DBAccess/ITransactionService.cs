using DataAccess.Models;

namespace DataAccess.DBAccess
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transactions>> GetAllTransactionsAsync();
        Task<int> InsertTransactionAsync(Transactions transaction);
    }
}