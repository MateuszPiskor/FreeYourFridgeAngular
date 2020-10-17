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
        private readonly IUserRepository _userRepo;
        public FridgeRepository(DataContext context,  IUserRepository userRepo)
        {
            _context = context;
            _userRepo = userRepo;
        }

        public async Task<Fridge> GetFridge(int id)
        {
            var userForNewFridge = await _userRepo.GetUser(id);
            var fridge = await _context.Fridges.FirstOrDefaultAsync(fridge => fridge.user.Id == id);
            if (fridge == null)
            {
                var newFridge = new Fridge(){
                    UserId = id,
                    user = userForNewFridge
                };
                this.Add(newFridge);
                await this.SaveAll();
                return newFridge;
            }

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

        public async void UpdateIngredient(int id, Ingredient updateIngredient)
        {
            var ingredientToUpdate = await _context.Ingredients.FirstOrDefaultAsync(iD => iD.Id == id);
            ingredientToUpdate.Amount = updateIngredient.Amount;
            ingredientToUpdate.Unit = updateIngredient.Unit;
            _context.SaveChanges();
        }
        
        public IEnumerable<Ingredient> GetIngredients(int userId)
        {
            var allIgredients = _context.Ingredients.Where(i => i.FridgeId == userId).ToList();
            return allIgredients;
        }
    }
}