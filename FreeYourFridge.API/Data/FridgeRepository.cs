using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeYourFridge.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeYourFridge.API.Data
{
    public class FridgeRepository : IFridgeRepository
    {
        private readonly DataContext _context;
        public FridgeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Fridge> GetFridge(int id)
        {
            var fridge = await _context.Fridges.FirstOrDefaultAsync(fridge => fridge.user.Id == id);
            return fridge;
        }
        public async Task<Ingredient> GetIngredient(int id)
        {
            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(ingredient => ingredient.Id == id);
            return ingredient;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async void UpdateIngredient(Ingredient ingredientToUpdate, int id)
        {
            var updateIngredient = await _context.Ingredients.FirstOrDefaultAsync(iD => iD.Id == id);
            if (updateIngredient == null)
            {
                ingredientToUpdate.Id = id;
                _context.Add(ingredientToUpdate);
                _context.SaveChanges();
                return;
            }
            _context.SaveChanges();
        }
    }
}