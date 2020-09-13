using System.Threading.Tasks;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Data
{
    public interface IMealRepository
    {
        Task<Meal> AddMealAsync(Meal meal);
    }
}