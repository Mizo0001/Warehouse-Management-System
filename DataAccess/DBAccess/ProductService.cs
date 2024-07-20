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
    public class ProductService : IProductService
    {
        private readonly string _connectionString;
        private ISqlDbContext _dbContext;

        public ProductService(ISqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Products>> GetAllProductsAsync()
        {
            _dbContext.SetConnectionString("DefaultConnection");
            var storedProcedureName = "GetAllProducts";
            using (var connection = _dbContext.CreateConnection())
            {
                var results = await connection.QueryAsync<Products>(storedProcedureName, new { }
                , commandType: CommandType.StoredProcedure);
                return results;
            }
        }



        public async Task<int> InsertProductAsync(Products product)
        {
            _dbContext.SetConnectionString("DefaultConnection");
            var storedProcedureName = "InsertProduct";
            using (var connection = _dbContext.CreateConnection())
            {
                var results = await connection.ExecuteAsync(storedProcedureName, new
                {
                    product.ProductName,
                    product.SubCategoryId,
                    product.CreateBy
                }
                , commandType: CommandType.StoredProcedure);
                return results;
            }
        }

        public async Task<int> UpdateProductAsync(Products product)
        {
            _dbContext.SetConnectionString("DefaultConnection");
            var storedProcedureName = "UpdateProduct";
            using (var connection = _dbContext.CreateConnection())
            {
                var results = await connection.ExecuteAsync(storedProcedureName, new
                {
                    product.ProductId,
                    product.ProductName,
                    product.SubCategoryId,
                    product.Active,
                    product.UpdateBy
                }
                , commandType: CommandType.StoredProcedure);
                return results;
            }
        }
    }
}
