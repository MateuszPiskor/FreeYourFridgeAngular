using System.Collections.Generic;

namespace FreeYourFridge.API.Models
{
    /// <summary>
    /// set of classess taking over deserialized objects from ExternalModels
    /// </summary>
    public class AcceptRecipe
    {
        public bool vegetarian { get; set; }
        public bool vegan { get; set; }
        public bool glutenFree { get; set; }
        public bool dairyFree { get; set; }
        public bool veryHealthy { get; set; }
        public float spoonacularScore { get; set; } /**/
        public float healthScore { get; set; }
        public ICollection<AcceptExtendedingredient> extendedIngredients { get; set; }
        public int id { get; set; } /**/
        public string title { get; set; } /**/
        public int readyInMinutes { get; set; } /**/
        public string sourceUrl { get; set; }
        public string image { get; set; } /**/
        public AcceptNutrition nutrition { get; set; }
        public string summary { get; set; }
        public string instructions { get; set; } /**/
        public ICollection<AcceptAnalyzedinstruction> analyzedInstructions { get; set; } /**/
    }
    public class AcceptNutrition
    {
        public ICollection<AcceptNutrient> nutrients { get; set; } /**/
        public ICollection<AcceptIngredient> ingredients { get; set; }
        public AcceptCaloricbreakdown caloricBreakdown { get; set; }
        public ICollection<AcceptProperties> properties { get; set; }
        public AcceptWeightperserving weightPerServing { get; set; }

    }

    public class AcceptWeightperserving
    {
        public int amount { get; set; }
        public string unit { get; set; }
    }

    public class AcceptProperties
    {
        public string title { get; set; }
        public float amount { get; set; }
        public string unit { get; set; }
    }

    public class AcceptCaloricbreakdown
    {
        public float percentProtein { get; set; }
        public float percentFat { get; set; }
        public float percentCarbs { get; set; }
    }


    public class AcceptNutrient
    {
        public string title { get; set; }
        public float amount { get; set; }
        public string unit { get; set; }
        public float percentOfDailyNeeds { get; set; }
    }

    public class AcceptIngredient
    {
        public string name { get; set; }
        public float amount { get; set; }
        public string unit { get; set; }
    }

    public class AcceptExtendedingredient
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
        public AcceptMeasures measures { get; set; }
    }

    public class AcceptMeasures
    {
        public AcceptMetric metric { get; set; }
    }


    public class AcceptMetric
    {
        public float amount { get; set; }
        public string unitShort { get; set; }
        public string unitLong { get; set; }
    }

    public class AcceptAnalyzedinstruction
    {
        //public string name { get; set; }
        public ICollection<AcceptStep> steps { get; set; }
    }

    public class AcceptStep
    {
        public int number { get; set; }
        public string step { get; set; }

    }


    public class Equipment
    {

    }
}
