namespace FreeYourFridge.API.Models
{
    public class Ingredients
    {
        public int Id{get;set;}
        public string Name {get;set;}
        public Recipe Recipe {get;set;}
        public int RecipeId {get;set;}
    }
}