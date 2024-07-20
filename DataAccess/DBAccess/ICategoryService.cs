using DataAccess.Models;

namespace DataAccess.DBAccess
{
    public interface ICategoryService
    {
        Task<IEnumerable<Categories>> GetAllCategoriesAsync();
        Task<int> InsertCategoryAsync(Categories category);
        Task<int> UpdateCategoryAsync(Categories category);
    }
}