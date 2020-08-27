using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Data
{
    public interface IRecipeRepository
    {
         Task<RecipeDto> GetRecipes();
    }
}