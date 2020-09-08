using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Helpers
{
    public class UrlMaker : IMakePartialUrl
    {
        public string UrlIngredientMaker(IEnumerable<Ingredients> ingredients)
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
