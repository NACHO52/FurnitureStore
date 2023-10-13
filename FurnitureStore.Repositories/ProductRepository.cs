using Dapper;
using FurnitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;
        public ProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<Product>> GetByCategoryId(int categoryId)
        {
            var sql = "SELECT Id, Name, Price, CategoryId FROM Products WHERE CategoryId = @categoryId";

            return await _dbConnection.QueryAsync<Product>(sql, new { categoryId});
        }
    }
}
