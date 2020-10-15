using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Helpers;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Data
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<RecipeToList>> GetRecipes(IEnumerable<Ingredient> ingredients, UserParamsForFilterRecipes userParams);

        Task<string> GetRespone(int id, string kindOfInformation);
        Task<IEnumerable<RecipeToList>> GetResponeWhenPassParams(IEnumerable<Ingredient> ingredients, UserParamsForFilterRecipes userParams);
        Task<RecipeToDetail> GetRecipeTimeAndScore(int id);
        Task<Nutrition> GetNutritionById(int id);
        Task<IEnumerable<Instructionstep>> GetInstructionSteps(int id);
    }
}