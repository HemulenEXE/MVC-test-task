using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_mvc.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        private Product() { }

        public Product(string Name, string Description, float Price)
        {
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
        }
    }
}