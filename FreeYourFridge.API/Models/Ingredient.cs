namespace FreeYourFridge.API.Models
{
    public class Ingredient
    {
        public long Id { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public string Name { get; set; }
    }
}