using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeYourFridge.API.Models
{
    public class Ingredient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SpoonacularId { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public string Name { get; set; }
        public Nullable<int> FridgeId{get;set;}
        public virtual Fridge Fridge{get;set;}
    }
}