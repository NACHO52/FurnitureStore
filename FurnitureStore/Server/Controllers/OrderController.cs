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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository repository)
        {
            _orderRepository = repository;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            if (order == null)
                return BadRequest();
            if (order.OrderNumber == 0)
                ModelState.AddModelError("OrderNumber", "Order number can't be empty.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _orderRepository.Insert(order);
            return NoContent();
        }
    }
}
