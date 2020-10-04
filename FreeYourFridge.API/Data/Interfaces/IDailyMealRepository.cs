using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.ExternalModels;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Data.Interfaces
{
    public interface IDailyMealRepository
    {
        Task<IEnumerable<DailyMeal>> GetDailyMealsAsync();
        Task<DailyMeal> GetDailyMealAsync(int id);
        void AddMeal(DailyMeal meal);
        Task UpdateMeal(DailyMeal meal);
        Task ClearTable();
        Task<IncomingRecipe> GetExternalDailyMeal(int id);
        void AddDailyMealsToArchive(DailyMealToArchive dMealToArchive);
        Task<bool> SaveChangesAsync();

    }
}