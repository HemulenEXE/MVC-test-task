using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMvc.Models.DTO
{
    public record class ShortProduct(int Id, string Name, float Price);
}