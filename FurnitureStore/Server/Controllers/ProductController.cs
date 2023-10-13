using FurnitureStore.Repositories;
using FurnitureStore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productCategoryRepository)
        {
            _productRepository = productCategoryRepository;
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IEnumerable<Product>> GetByCategory(int categoryId)
        {
            return await _productRepository.GetByCategoryId(categoryId);
        }
    }
}
