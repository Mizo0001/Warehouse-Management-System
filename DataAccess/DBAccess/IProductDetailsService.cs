using DataAccess.Models;

namespace DataAccess.DBAccess
{
    public interface IProductDetailsService
    {
        Task<IEnumerable<ProductDetails>> GetAllProductDetailsAsync();
        Task<IEnumerable<ProductDetails>> GetExpiryDatesByProductIdAsync(int productId);
        Task<IEnumerable<ProductDetails>> GetProductDetailByIdAndExpiryDateAsync(int productId);
        Task<int> InsertProductDetailsAsync(ProductDetails productdetail);
    }
}