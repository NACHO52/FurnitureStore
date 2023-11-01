using FurnitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStore.Client.Services
{
    public interface IOrderService
    {
        Task Save(Order order);
    }
}
