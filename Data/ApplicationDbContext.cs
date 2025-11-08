using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using TestMvc.Models;

namespace TestMvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}