using System.Collections.Generic;

namespace FreeYourFridgeAPI.Tests.IntegrationTestsHelper.TestModels
{
    public class ExpectedAcceptRecipeTestModel
    {
        public int readyInMinutes { get; set; }
        public AcceptNutritionTestModel nutrition { get; set; }

        public ICollection<AcceptAnalyzedinstructionTestModel> analyzedInstructions { get; set; } /**/
    }

    public class AcceptAnalyzedinstructionTestModel
    {
        public ICollection<AcceptStepTestModel> steps { get; set; }
    }

    public class AcceptStepTestModel
    {
        public int number { get; set; }
        public string step { get; set; }

    }

    public class AcceptNutritionTestModel
    {
        public ICollection<AcceptNutrientTestModel> nutrients { get; set; }
        public AcceptCaloricbreakdownTestModel caloricBreakdown { get; set; }
        public ICollection<AcceptPropertiesTestModel> properties { get; set; }
        public AcceptWeightperservingTestModel weightPerServing { get; set; }
    }

    public class AcceptWeightperservingTestModel
    {
        public int amount { get; set; }
        public string unit { get; set; }
    }

    public class AcceptPropertiesTestModel
    {
        public string title { get; set; }
        public float amount { get; set; }
        public string unit { get; set; }
    }

    public class AcceptCaloricbreakdownTestModel
    {
        public float percentProtein { get; set; }
        public float percentFat { get; set; }
        public float percentCarbs { get; set; }
    }

    public class AcceptNutrientTestModel
    {
        public string title { get; set; }
        public float amount { get; set; }
        public string unit { get; set; }
        public float percentOfDailyNeeds { get; set; }
    }
}
