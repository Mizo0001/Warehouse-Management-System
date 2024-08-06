using DataAccess.Models;
using DataAccess.SqlDBAccess;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBAccess
{
    public class ProductDetailsService : IProductDetailsService
    {
        private readonly string _connectionString;
        private ISqlDbContext _dbContext;
        public ProductDetailsService(ISqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductDetails>> GetAllProductDetailsAsync()
        {
            _dbContext.SetConnectionString("DefaultConnection");
            var storedProcedureName = "GetAllProductDetails";
            using (var connection = _dbContext.CreateConnection())
            {
                var results = await connection.QueryAsync<ProductDetails>(storedProcedureName, new { }
                , commandType: CommandType.StoredProcedure);
                return results;
            }
        }
        public async Task<IEnumerable<ProductDetails>> GetExpiryDatesByProductIdAsync(int productId)
        {
            _dbContext.SetConnectionString("DefaultConnection");
            var storedProcedureName = "GetExpiryDatesOfProduct";

            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new { ProductId = productId };
                var results = await connection.QueryAsync<ProductDetails>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
                return results;
            }
        }
        public async Task<IEnumerable<ProductDetails>> GetProductDetailByIdAndExpiryDateAsync(int productId)
        {
            _dbContext.SetConnectionString("DefaultConnection");
            var storedProcedureName = "GetProductDetailByProductIdAndExpiryDate";

            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new { ProductId = productId };
                var results = await connection.QueryAsync<ProductDetails>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
                return results;
            }
        }
        public async Task<int> InsertProductDetailsAsync(ProductDetails productdetail)
        {
            _dbContext.SetConnectionString("DefaultConnection");
            var storedProcedureName = "InsertProductDetail";
            using (var connection = _dbContext.CreateConnection())
            {
                var results = await connection.ExecuteAsync(storedProcedureName, new
                {
                    productdetail.ProductId,
                    productdetail.ExpiryDate,
                    productdetail.CreateBy
                }
                , commandType: CommandType.StoredProcedure);
                return results;
            }
        }
    }
}
