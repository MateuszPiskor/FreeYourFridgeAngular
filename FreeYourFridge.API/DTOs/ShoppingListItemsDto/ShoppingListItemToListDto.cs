using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeYourFridge.API.DTOs
{
    public class ShoppingListItemDto
    {
        public double Amount { get; set; }
        public string Unit { get; set; }
        public string Name { get; set; }
        public int SpoonacularId { get; set; }
    }
}
