using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Models;
using DataAccess.SqlDBAccess;

namespace DataAccess.DBAccess
{
    public class CategoryService : ICategoryService
    {
        private readonly string _connectionString;
        private ISqlDbContext _dbContext;
        public CategoryService(ISqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Categories>> GetAllCategoriesAsync()
        {
            _dbContext.SetConnectionString("DefaultConnection");
            var storedProcedureName = "GetAllCategories";
            using (var connection = _dbContext.CreateConnection())
            {
                var results = await connection.QueryAsync<Categories>(storedProcedureName, new { }
                , commandType: CommandType.StoredProcedure);
                return results;
            }
        }



        public async Task<int> InsertCategoryAsync(Categories category)
        {
            _dbContext.SetConnectionString("DefaultConnection");
            var storedProcedureName = "InsertCategory";
            using (var connection = _dbContext.CreateConnection())
            {
                var results = await connection.ExecuteAsync(storedProcedureName, new {
                    category.CategoryName,
                    category.CreateBy
                }
                , commandType: CommandType.StoredProcedure);
                return results;
            }
        }

        public async Task<int> UpdateCategoryAsync(Categories category)
        {
            _dbContext.SetConnectionString("DefaultConnection");
            var storedProcedureName = "UpdateCategory";
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CategoryID", category.CategoryId);
                parameters.Add("@CategoryName", category.CategoryName);
                parameters.Add("@Active", category.Active);
                parameters.Add("@UpdateBy", category.UpdateBy);

                var results = await connection.ExecuteAsync(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
                return results;
            }
        }
    }
}
