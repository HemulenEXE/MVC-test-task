using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_mvc.Models;
using тестовое_mvc.Models.DTO;
namespace тестовое_mvc.Repositories
{
    public interface IProductRepositories
    {
        Task AddProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetProducts(ProductFilter filter);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);

    }
}