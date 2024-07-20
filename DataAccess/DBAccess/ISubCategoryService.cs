using DataAccess.Models;

namespace DataAccess.DBAccess
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategories>> GetAllSubCategoriesAsync();
        Task<int> InsertSubCategoryAsync(SubCategories subcategory);
        Task<int> UpdateSubCategoryAsync(SubCategories subcategory);
    }
}