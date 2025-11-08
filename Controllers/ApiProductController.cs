using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestMvc.Models;
using TestMvc.Models.DTO;
using TestMvc.Repositories;

namespace TestMvc.Controllers
{
    [ApiController]
    [Route("api/Product")]
    public class ApiProductController : ControllerBase
    {
        IProductRepositories _products;

        public ApiProductController(IProductRepositories products)
        {
            _products = products;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            Product? product = await _products.GetProductById(id);
            if (product == null)
            {
                return NotFound($"Not found product with id {id}");
            }
            return Ok(product);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] ProductFilter productFilter)
        {
            IEnumerable<Product> products = await _products.GetProducts(productFilter);
            return Ok(products.Select(p => new ShortProduct(p.Id,p.Name,p.Price)));
        }


    }
}