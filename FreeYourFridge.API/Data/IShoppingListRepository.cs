using System.Threading.Tasks;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Data
{
    public interface IShoppingListRepository    
    {
        Task<Ingredient> AddIngredientAsync(Ingredient ingredient);
    }
}