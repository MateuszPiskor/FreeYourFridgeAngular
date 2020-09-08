using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.Helpers;
using FreeYourFridge.API.Models;
using Newtonsoft.Json;
using RestSharp;

namespace FreeYourFridge.API.Data
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly string _baseUrl = "https://api.spoonacular.com/recipes/";
        private readonly string _apiKey;
        private readonly IMakePartialUrl _makePartialUrl;

        public RecipeRepository(ApiKeyReader apiKeyReader, IMakePartialUrl makePartialUrl)
        {
            _apiKey =apiKeyReader.getKey();
            _makePartialUrl = makePartialUrl;
        }

        public async Task<IEnumerable<Recipe>> GetRecipesByIndegrients(IEnumerable<Ingredients> ingredients, int numberOfRecipes)
        {
            string igredientUrl=_makePartialUrl.UrlIngredientMaker(ingredients);

            RestClient client = new RestClient($"{_baseUrl}findByIngredients?{_apiKey}&ingredients={igredientUrl}" + "&number=" + numberOfRecipes);
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                IEnumerable<Recipe> recipes = JsonConvert.DeserializeObject<IEnumerable<Recipe>>(response.Content);
                return recipes;
            }

            //TODO: log error, throw exception or do other stuffs for failed requests here.
            //Console.WriteLine(response.Content);
           
            return null;
        }

        public async Task<string> GetResponseById(int id, string information)
        {
            RestClient client = new RestClient($"{_baseUrl}{id}/{information}/?{_apiKey}");
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