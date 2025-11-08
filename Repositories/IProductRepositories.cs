using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMvc.Models;
using TestMvc.Models.DTO;
namespace TestMvc.Repositories
{
    public interface IProductRepositories
    {
        Task AddProduct(Product product);
        Task<Product?> GetProductById(int id);
        Task<IEnumerable<Product>> GetProducts(ProductFilter filter);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);

    }
}