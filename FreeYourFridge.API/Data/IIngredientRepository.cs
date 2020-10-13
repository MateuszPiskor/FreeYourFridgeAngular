using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeYourFridge.API.Data
{
    public interface IIngredientRepository
    {
        Task<IngredientDto> GetIngredientsFromAPI(int id);
        Task<List<ListOfIngredients>> GetAllIngredients();
        void Add(Ingredient newIngredient, Fridge fridge, string image);
        Task<bool> SaveAll();
    }
}