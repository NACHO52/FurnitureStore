using FurnitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStore.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAll();
    }
}
