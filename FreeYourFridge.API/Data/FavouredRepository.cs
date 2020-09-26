using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeYourFridge.API.Helpers;
using FreeYourFridge.API.Models;
using Microsoft.EntityFrameworkCore;
using RestSharp;

namespace FreeYourFridge.API.Data
{
    public class FavouredRepository : GenericRepository, IFavouredRepository
    {
        private readonly string _baseUrl = "https://api.spoonacular.com/recipes/";
        private DataContext _context;
        private readonly string _apiKey;

        public FavouredRepository(DataContext context, ApiKeyReader apiKeyReader): base(context)
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

        public async Task<IEnumerable<Favoured>> GetFavoureds()
        {
            return await _context.Favoureds.ToListAsync();
        }

        public async Task<string> GetRecipesByIds(string idsString)
        {
            RestClient client= new RestClient($"{_baseUrl}informationBulk?{_apiKey}&ids={idsString}");
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return response.Content;
            }
            return null;
        }
    }
}