using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.Helpers;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Data
{
    public interface IRecipeRepository
    {
        Task<string> GetRespone(IEnumerable<Ingredient> ingredients, int numberOfResipes);

        Task<string> GetRespone(int id, string kindOfInformation);
        Task<string> GetResponeWhenPassParams(IEnumerable<Ingredient> ingredients, int numberOfRecipes, UserParamsForFilterRecipes userParams);

        //Task<string> GetResponse(string kindOfInformation, string[] optional=null);
    }
}