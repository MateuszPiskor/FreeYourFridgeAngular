using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Data
{
    public interface IShoppingListRepository: IGenericRepository
    {
        Task<ShoppingListItem> AddIngredientAsync(ShoppingListItem shoppingListItem);
        IEnumerable<ShoppingListItem> GetShoppingListItems();
        void DeleteShoppingListItem(int id, int userId);
    }
}