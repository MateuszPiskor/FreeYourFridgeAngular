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
        public FridgeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Fridge> GetFridge(int id)
        {
            var fridge = await _context.Fridges.FirstOrDefaultAsync(fridge => fridge.user.Id == id);
            return fridge;
        }


    }
}