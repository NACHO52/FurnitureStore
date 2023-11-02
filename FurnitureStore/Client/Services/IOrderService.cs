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
        Task<int> GetNextNumber();
        Task<IList<Order>> GetAll();
        Task<Order> OrderGet(int id);
        Task DeleteOrder(int id);
    }
}
