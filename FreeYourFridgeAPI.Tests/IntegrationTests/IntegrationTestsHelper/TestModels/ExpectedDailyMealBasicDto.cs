using System;

namespace FreeYourFridgeAPI.Tests.IntegrationTestsHelper.TestModels
{
    class ExpectedDailyMealBasicDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }

        public DateTime TimeOfLastMeal { get; set; }
        public int Grams { get; set; }
    }
}
