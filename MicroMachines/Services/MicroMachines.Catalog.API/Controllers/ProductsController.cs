using MicroMachines.Catalog.API.Entities;
using MicroMachines.Catalog.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroMachines.Catalog.API.Controllers
{
    [Route("api/catalog/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository, ICategoryRepository categories)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }    

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id:Guid}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var product = await _repository.GetSingle(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpGet("category/{categoryId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(Guid categoryId)
        {
            var products = await _repository.GetByCategory(categoryId);
            return Ok(products);
        }
    }
}
