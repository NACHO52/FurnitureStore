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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository repository)
        {
            _productRepository = repository;
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IEnumerable<Product>> GetByCategory(int categoryId)
        {
            return await _productRepository.GetByCategoryId(categoryId);
        }

        [HttpGet("{id}")]
        public async Task<Product> ProductGet(int id)
        {
            return await _productRepository.GetDetails(id);
        }
    }
}
