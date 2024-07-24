using DataAccess.Models;

namespace DataAccess.DBAccess
{
    public interface ITransactionTypeService
    {
        Task<IEnumerable<TransactionTypes>> GetAllTransactionTypeAsync();
        Task<TransactionTypes> GetTransactionTypeByIdAsync(int id);
    }
}