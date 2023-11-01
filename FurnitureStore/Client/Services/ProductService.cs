using FurnitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FurnitureStore.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Product>> GetByCategory(int categoryId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>($"api/Product/category/{categoryId}");
        }

        public async Task<Product> ProductGet(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/Product/{id}");
        }
    }
}
