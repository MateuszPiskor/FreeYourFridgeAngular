namespace FreeYourFridgeAPI.Tests.IntegrationTests.IntegrationTestsHelper.TestModels
{
    public class ExpectedRecipeToList
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public ExpectedIngredient[] MissedIngredients { get; set; }
        public ExpectedIngredient[] UsedIngredients { get; set; }
    }

    public class ExpectedIngredient
    {
    }
}
