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
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly IDbConnection _dbConnection;
        public ProductCategoryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            var sql = "SELECT Id, [Name] FROM ProductCategories";

            return await _dbConnection.QueryAsync<ProductCategory>(sql, new { });
        }
    }
}
