using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Data
{
    public interface IFridgeRepository
    {
        Task<Fridge> GetFridge(int id);
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        IEnumerable<Ingredient> GetIngredients(int userId);
        Task<Ingredient> GetIngredient(int id);
        void UpdateIngredient(int id, Ingredient updateIngredient);
    }
}