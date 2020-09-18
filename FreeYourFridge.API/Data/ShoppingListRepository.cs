using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeYourFridge.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace FreeYourFridge.API.Data
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly DataContext _context;

        public ShoppingListRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ToDoItem> AddIngredientAsync(ToDoItem toDoItem)
        {
            await _context.ToDoItems.AddAsync(toDoItem);
            await _context.SaveChangesAsync();

            return toDoItem;
        }
        
        public IEnumerable<ToDoItem> GetToDoItems()
        {
            return  _context.ToDoItems.ToList();
        }
        public void DeleteToDoItem(int id)
        {
            var elements = _context.ToDoItems.ToList();
            var itemToRemove = elements.SingleOrDefault(x => x.SpoonacularId == id);
            
            if (itemToRemove != null) {
                var element = _context.ToDoItems.Remove(itemToRemove);
                _context.SaveChanges();
            }
        }
       
    }
}