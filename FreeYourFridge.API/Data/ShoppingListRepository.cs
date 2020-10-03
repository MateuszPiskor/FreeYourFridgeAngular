using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeYourFridge.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace FreeYourFridge.API.Data
{
    public class ShoppingListRepository : GenericRepository, IShoppingListRepository
    {
        private readonly DataContext _context;

        public ShoppingListRepository(DataContext context): base(context)
        {
            _context = context;
        }

        public async Task<ShoppingListItem> AddIngredientAsync(ShoppingListItem shoppingListItem)
        {
            await _context.ShoppingListItems.AddAsync(shoppingListItem);
            await _context.SaveChangesAsync();

            return shoppingListItem;
        }
        
        public IEnumerable<ShoppingListItem> GetShoppingListItems()
        {
            return  _context.ShoppingListItems.ToList();
        }
        public void DeleteShoppingListItem(int id,int userId)
        {
            var elements = _context.ShoppingListItems.ToList();
            var itemToRemove = elements.FirstOrDefault(x => x.SpoonacularId == id && x.CreatedBy == userId);
            
            if (itemToRemove != null) {
                var element = _context.ShoppingListItems.Remove(itemToRemove);
                _context.SaveChanges();
            }
        }
       
    }
}