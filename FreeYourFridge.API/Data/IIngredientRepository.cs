using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Data
{
    public interface IIngredientRepository
    {
        Task<IngredientDto> GetIngredientsFromAPI(int id);
        Task<List<ListOfIngredients>> GetAllIngredients();
    }
}