using FurnitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FurnitureStore.Client.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;
        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<FurnitureStore.Shared.Client>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<FurnitureStore.Shared.Client>>($"api/Client");
        }
    }
}
