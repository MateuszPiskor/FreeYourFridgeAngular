using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeYourFridge.API.ExternalModels
{

    public class IncomingRecipe
    {
        public bool vegetarian { get; set; }
        public bool vegan { get; set; }
        public bool glutenFree { get; set; }
        public bool dairyFree { get; set; }
        public bool veryHealthy { get; set; }
        public float spoonacularScore { get; set; } /**/
        public float healthScore { get; set; }
        public ICollection<Extendedingredient> extendedIngredients { get; set; }
        public int id { get; set; } /**/
        public string title { get; set; } /**/
        public int readyInMinutes { get; set; } /**/
        public string sourceUrl { get; set; }
        public string image { get; set; } /**/
        public Nutrition nutrition { get; set; }
        public string summary { get; set; }
        public string instructions { get; set; } /**/
        public ICollection<string> analyzedInstructions { get; set; } /**/
    }

    public class Nutrition
    {
        public ICollection<Nutrient> nutrients { get; set; } /**/
        public ICollection<Ingredient> ingredients { get; set; }
        public Caloricbreakdown caloricBreakdown { get; set; }
        public Weightperserving weightPerServing { get; set; }
    }

    public class Caloricbreakdown
    {
        public float percentProtein { get; set; }
        public float percentFat { get; set; }
        public float percentCarbs { get; set; }
    }

    public class Weightperserving
    {
        public int amount { get; set; }
        public string unit { get; set; }
    }

    public class Nutrient /**/
    {
        public string title { get; set; }
        public float amount { get; set; }
        public string unit { get; set; }
        public float percentOfDailyNeeds { get; set; }
    }

    public class Ingredient
    {
        public string name { get; set; }
        public float amount { get; set; }
        public string unit { get; set; }
    }

    public class Extendedingredient
    {
        public int id { get; set; }
        public string aisle { get; set; }
        public string image { get; set; }
        public string consistency { get; set; }
        public string name { get; set; }
        public string original { get; set; }
        public string originalString { get; set; }
        public string originalName { get; set; }
        public float amount { get; set; }
        public string unit { get; set; }
        public Measures measures { get; set; }
    }

    public class Measures
    {
        public Metric metric { get; set; }
    }


    public class Metric
    {
        public float amount { get; set; }
        public string unitShort { get; set; }
        public string unitLong { get; set; }
    }
}