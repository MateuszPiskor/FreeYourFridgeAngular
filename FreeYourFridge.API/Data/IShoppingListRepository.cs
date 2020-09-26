using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Data
{
    public interface IShoppingListRepository: IGenericRepository
    {
        Task<ToDoItem> AddIngredientAsync(ToDoItem toDoItem);
        IEnumerable<ToDoItem> GetToDoItems();
        void DeleteToDoItem(int id);
    }
}