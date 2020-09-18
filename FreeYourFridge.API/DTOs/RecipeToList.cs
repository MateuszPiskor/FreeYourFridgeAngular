using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.DTOs
{
    public class RecipeToList
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public Ingredient[] MissedIngredients { get; set; }
        public Ingredient[] UsedIngredients { get; set; }
    }
}