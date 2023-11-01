using FurnitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FurnitureStore.Client.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Save(Order order)
        {
            if(order.Id == 0)
            {
                await _httpClient.PostAsJsonAsync<Order>($"api/order", order);
            }
            else
            {

            }
            
        }
    }
}
