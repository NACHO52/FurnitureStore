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
    }
}
