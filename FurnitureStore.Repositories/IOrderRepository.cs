using FurnitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStore.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> Insert(Order order);
        public Task<bool> UpdateOrder(Order order);
        Task<bool> DeleteOrder(int order);
        Task<int> GetNextNumber();
        Task<int> GetNextId();
        Task<IEnumerable<Order>> GetAll();
        Task<Order> OrderGet(int id);
    }
}
