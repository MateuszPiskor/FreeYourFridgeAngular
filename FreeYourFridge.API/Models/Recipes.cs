using System.Collections.Generic;

namespace FreeYourFridge.API.Models
{
    public class Recipes
    {
        public int Id{get;set;}
        public string Title{get;set;}
        public string Image { get; set; }
        public string Summary { get; set; }
        public int ReadyInMinutes { get; set; }
        public double SpoonacularScore { get; set; }
        public string Instructions { get; set; }
        public string Cheap { get; set; }
        public object Calories { get; set; }
        public string Carbs { get; set; }
        public string Fat { get; set; }
        public string Protein { get; set; }       

    }
}