using System.Threading.Tasks;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Data
{
    public class MealRepository : IMealRepository
    {
        private readonly DataContext _context;

        public MealRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Meal> AddMealAsync(Meal meal)
        {
            await _context.Meals.AddAsync(meal);
            await _context.SaveChangesAsync();
            return meal;
        }
    }
}