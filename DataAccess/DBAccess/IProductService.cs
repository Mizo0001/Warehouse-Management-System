using DataAccess.Models;

namespace DataAccess.DBAccess
{
    public interface IProductService
    {
        Task<IEnumerable<Products>> GetAllProductsAsync();
        Task<int> InsertProductAsync(Products product);
        Task<int> UpdateProductAsync(Products product);
    }
}