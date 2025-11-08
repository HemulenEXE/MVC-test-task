using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestMvc.Models.DTO;
using TestMvc.Repositories;
using TestMvc.Models;

namespace TestMvc.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductRepositories _products;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, IProductRepositories products)
        {
            _logger = logger;
            _products = products;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var products = await _products.GetProducts(null);
            return View(products);
        }

        [HttpGet("Create")]
        public IActionResult Create() => View(new Product());

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Product product)
        {
            await _products.AddProduct(product);
            _logger.LogInformation($"добавлен новый продукт {product.Name}");
            return RedirectToAction("Index");

        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _products.GetProductById(id);
            return View(product);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(Product product)
        {
            await _products.UpdateProduct(product);
            _logger.LogInformation($"Изменен продукт с id {product.Id}");
            return RedirectToAction("Index");
        }
    }
}