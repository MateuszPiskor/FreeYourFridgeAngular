using System.Collections.Generic;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Helpers
{
    public class UrlMaker : IMakePartialUrl
    {
        public string UrlIngredientMaker(IEnumerable<Ingredient> ingredients)
        {
            string partUrlPath = "";
            foreach (var ingredient in ingredients)
            {
                partUrlPath += ",+" + ingredient.Name;
            }
            return partUrlPath.Substring(2);
        }
    }
}