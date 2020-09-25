using System.Threading.Tasks;
using FreeYourFridge.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeYourFridge.API.Data
{
    public class FavouredRepository : IFavouredRepository
    {
        private DataContext _context;

        public FavouredRepository(DataContext context)
        {
             _context = context;

        }
        public async Task<Favoured> AddFavoured(Favoured favoured)
        {
            await _context.Favoureds.AddAsync(favoured);
            await _context.SaveChangesAsync();

            return favoured;
        }
    }
}