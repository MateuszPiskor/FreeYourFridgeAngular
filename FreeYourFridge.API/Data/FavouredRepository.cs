using System.Linq;
using System.Threading.Tasks;
using FreeYourFridge.API.Helpers;
using FreeYourFridge.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeYourFridge.API.Data
{
    public class FavouredRepository : GenericRepository, IFavouredRepository
    {
        private readonly string _baseUrl = "https://api.spoonacular.com/recipes/";
        private DataContext _context;
        private readonly string _apiKey;

        public FavouredRepository(DataContext context, ApiKeyReader apiKeyReader) : base(context)
        {
            _context = context;
            _apiKey = apiKeyReader.getKey();
        }

        public async Task<Favoured> AddFavoured(Favoured favoured)
        {
            await _context.Favoureds.AddAsync(favoured);
            await _context.SaveChangesAsync();

            return favoured;
        }

        public async Task<PagedList<Favoured>> GetFavoureds(UserParams userParams)
        {
            DbSet<Favoured> favoureds = _context.Favoureds;

            return await PagedList<Favoured>.CreateListAsync(favoureds, userParams.PageNumber, userParams.PageSize);
        }

        public void DeleteFavoured(int id, int userId)
        {
            var favoureds = _context.Favoureds.ToList();

            var itemToRemove = favoureds.FirstOrDefault(x => x.SpoonacularId == id && x.CreatedBy == userId);

            if (itemToRemove != null)
            {
                _context.Favoureds.Remove(itemToRemove);
                _context.SaveChanges();
            }
        }

        public async Task UpdateFavaoured(int id, int score, int userId)
        {
            var updateFavoured = await _context.Favoureds.FirstOrDefaultAsync(x => x.SpoonacularId == id && x.CreatedBy == userId);
            updateFavoured.Score = score;
            _context.Favoureds.Update(updateFavoured);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FavouredExist(int id)
        {
            if (await _context.Favoureds.AnyAsync(x => x.SpoonacularId == id))
            {
                return true;
            }
            return false;
        }

        public async Task<Favoured> GetFavoured(int id, int userId)
        {
            return await _context.Favoureds.FirstOrDefaultAsync(f => f.SpoonacularId == id && f.CreatedBy == userId);
        }
    }
}