using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccess.SqlDBAccess;


namespace DataAccess.DBAccess
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly string _connectionString;
        private ISqlDbContext _dbContext;

        public SubCategoryService(ISqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SubCategories>> GetAllSubCategoriesAsync()
        {
            _dbContext.SetConnectionString("DefaultConnection");
            var storedProcedureName = "GetAllSubCategories";
            using (var connection = _dbContext.CreateConnection())
            {
                var results = await connection.QueryAsync<SubCategories>(storedProcedureName, new { }
                , commandType: CommandType.StoredProcedure);
                return results;
            }
        }



        public async Task<int> InsertSubCategoryAsync(SubCategories subcategory)
        {
            _dbContext.SetConnectionString("DefaultConnection");
            var storedProcedureName = "InsertSubCategory";
            using (var connection = _dbContext.CreateConnection())
            {
                var results = await connection.ExecuteAsync(storedProcedureName, new
                {
                    subcategory.SubCategoryName,
                    subcategory.CategoryId,
                    subcategory.CreateBy
                }
                , commandType: CommandType.StoredProcedure);
                return results;
            }
        }

        public async Task<int> UpdateSubCategoryAsync(SubCategories subcategory)
        {
            _dbContext.SetConnectionString("DefaultConnection");
            var storedProcedureName = "UpdateSubCategory";
            using (var connection = _dbContext.CreateConnection())
            {
                var results = await connection.ExecuteAsync(storedProcedureName, new
                {
                    subcategory.SubCategoryId,
                    subcategory.SubCategoryName,
                    subcategory.CategoryId,
                    subcategory.Active,
                    subcategory.UpdateBy
                }
                , commandType: CommandType.StoredProcedure);
                return results;
            }
        }
    }
}
