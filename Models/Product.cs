using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMvc.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public float Price { get; set; }

        public Product() { }

        public Product(string Name, string Description, float Price)
        {
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
        }
    }
}