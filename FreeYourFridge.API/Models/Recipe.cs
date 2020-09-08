using System.Collections.Generic;

namespace FreeYourFridge.API.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Summary { get; set; }
        public int ReadyInMinutes { get; set; }
        public double SpoonacularScore { get; set; }
        public string Instructions { get; set; }
        public Missedingredient[] MissedIngredients { get; set; }
        public Usedingredient[] UsedIngredients { get; set; }
    }

}