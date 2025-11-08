using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestMvc.Data;
using TestMvc.Models;
using TestMvc.Models.DTO;
using AutoMapper;

namespace TestMvc.Repositories
{
    public class ProductMSSqlRepository : IProductRepositories
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductMSSqlRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts(ProductFilter filter)
        {
            IQueryable<Product> products = _context.Products;

            if(filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    products = products.Where(p => filter.Name == p.Name);
                }
                if (filter.MinCost.HasValue)
                {
                    products = products.Where(p => p.Price >= filter.MinCost);
                }
                if(filter.MaxCost.HasValue)
                {
                    products = products.Where(p => p.Price <= filter.MaxCost);
                }
            }

            return await products.ToListAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            Product? oldProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (oldProduct != null)
            {
                oldProduct.Name = product.Name;
                oldProduct.Description = product.Description;
                oldProduct.Price = product.Price;
                await _context.SaveChangesAsync();
            }
            return;
        }
    }
}