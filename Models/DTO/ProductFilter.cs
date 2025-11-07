using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace тестовое_mvc.Models.DTO
{
    public record class ProductFilter(string? Name, float? MinCost, float? MaxCost);
}