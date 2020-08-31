using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Data
{
    public interface IRecipeRepository
    {
         Task<IEnumerable<Recipes>> GetRecipesByIndegrients(int v);
         Task<Recipes> GetRecipeById(int id);

    }
}