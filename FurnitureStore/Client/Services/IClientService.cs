using FurnitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStore.Client.Services
{
    public interface IClientService
    {
        Task<IEnumerable<FurnitureStore.Shared.Client>> GetAll();
    }
}
