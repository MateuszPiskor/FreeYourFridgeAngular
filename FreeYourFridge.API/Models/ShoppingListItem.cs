﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeYourFridge.API.Models
{
    public class ShoppingListItem
    {
        public long Id { get; set; }
        public int SpoonacularId { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public string Name { get; set; }
        public bool IsOnShoppingList { get; set; }
        public int CreatedBy { get; set; }
        public string Image {get;set;}
    }
}
