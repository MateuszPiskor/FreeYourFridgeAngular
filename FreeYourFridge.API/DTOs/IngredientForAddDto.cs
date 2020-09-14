namespace FreeYourFridge.API.DTOs
{
    public class IngredientForAddDto
    {
        public int SpoonacularId { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public string Name { get; set; }
    }
}