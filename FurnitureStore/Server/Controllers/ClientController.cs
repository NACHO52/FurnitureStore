using FurnitureStore.Repositories;
using FurnitureStore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStore.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _repository;
        public ClientController(IClientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<FurnitureStore.Shared.Client>> Get()
        {
            return await _repository.GetAll();
        }
    }
}
