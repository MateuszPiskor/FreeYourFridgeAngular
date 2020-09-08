using System.Collections.Generic;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Helpers
{
    public interface IMakePartialUrl
    {
        string UrlIngredientMaker(IEnumerable<Ingredients> ingredients);
    }
}