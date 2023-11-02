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
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection _dbConnection;
        public OrderRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var sql = @"DELETE Orders
                        WHERE Id = @Id";

            return await _dbConnection.ExecuteAsync(sql,
                new
                {
                    Id = id
                }) > 0;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var sql = @"SELECT * FROM Orders";

            return await _dbConnection.QueryAsync<Order>(sql, new { });
        }

        public async Task<int> GetNextId()
        {
            var sql = @"SELECT IDENT_CURRENT('Orders')+1";
            return await _dbConnection.QueryFirstOrDefaultAsync<int>(sql, new { });
        }

        public async Task<int> GetNextNumber()
        {
            var sql = @"SELECT MAX(OrderNumber) + 1 FROM Orders";
            return await _dbConnection.QueryFirstAsync<int>(sql, new { });
        }

        public async Task<bool> Insert(Order order)
        {
            var sql = @"INSERT INTO Orders (OrderNumber, ClientId, OrderDate, DeliveryDate, Total) 
                        VALUES (@orderNumber, @clientId, @orderDate, @deliveryDate, @total)";

            return await _dbConnection.ExecuteAsync(sql, 
                new { 
                    orderNumber = order.OrderNumber,
                    clientId = order.ClientId,
                    orderDate = order.OrderDate,
                    deliveryDate = order.DeliveryDate,
                    total = order.Total
                }) > 0;
        }

        public async Task<Order> OrderGet(int id)
        {
            var sql = @"SELECT * FROM Orders WHERE Id = @id";
            return await _dbConnection.QueryFirstAsync<Order>(sql, new { id });
        }

        public async  Task<bool> UpdateOrder(Order order)
        {
            var sql = @"UPDATE Orders SET 
                        ClientId = @clientId, 
                        OrderDate = @orderDate, 
                        DeliveryDate = @deliveryDate
                        WHERE Id = @Id";

            return await _dbConnection.ExecuteAsync(sql,
                new
                {
                    clientId = order.ClientId,
                    orderDate = order.OrderDate,
                    deliveryDate = order.DeliveryDate,
                    Id = order.Id
                }) > 0;
        }
    }
}
