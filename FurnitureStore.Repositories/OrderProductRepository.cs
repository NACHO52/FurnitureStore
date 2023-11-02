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
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly IDbConnection _dbConnection;
        public OrderProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> DeleteOrderProductByOrder(int id)
        {
            var sql = @"DELETE FROM OrderProducts WHERE OrderId = @id";

            var resutl =  await _dbConnection.ExecuteAsync(sql, new { id });
            return resutl > 0;
        }

        public async Task<IEnumerable<Product>> GetByOrder(int orderId)
        {
            var sql = @"SELECT Id, Name, Price, CategoryId, Quantity FROM OrderProducts
                        INNER JOIN Products p ON p.Id = productId
                        WHERE OrderId = @Id";

            return await _dbConnection.QueryAsync<Product>(sql, new { Id = orderId });
        }

        public async Task<bool> InsertOrderProduct(int orderId, Product product)
        {
            var sql = @"INSERT INTO OrderProducts (OrderId, ProductId, Quantity) VALUES (@OrderId, @ProductId, @Quantity)";
            var result = await _dbConnection.ExecuteAsync(sql, new { OrderId = orderId, ProductId = product.Id, Quantity = product.Quantity});

            return result > 0;
        }
    }
}
