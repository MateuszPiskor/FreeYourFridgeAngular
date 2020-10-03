using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.ExternalModels;
using FreeYourFridge.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeYourFridge.API.Data.Interfaces
{
    public interface IDailyMealRepository
    {
        Task<IEnumerable<DailyMeal>> GetDailyMealsAsync();
        Task<DailyMeal> GetDailyMealAsync(int id);
        Task AddMeal(DailyMeal meal);
        Task UpdateMeal(DailyMeal meal);
        Task ClearTable();
        Task<IncomingRecipe> GetExternalDailyMeal(int id);
    }
}