using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.Models;
using Newtonsoft.Json;
using RestSharp;

namespace FreeYourFridge.API.Data
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly string _baseUrl = "https://api.spoonacular.com/recipes/";
        private readonly string _apiKey = "apiKey=ab1efb6fc9184c32b51bd7ee08cc8891";

        public async Task<IEnumerable<Recipes>> GetRecipesByIndegrients(int number)
        {
            RestClient client = new RestClient($"{_baseUrl}findByIngredients?{_apiKey}&ingredients=apples&number=" + number);
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                IEnumerable<Recipes> recipes = JsonConvert.DeserializeObject<IEnumerable<Recipes>>(response.Content);
                return recipes;
            }

            //TODO: log error, throw exception or do other stuffs for failed requests here.
            //Console.WriteLine(response.Content);

            return null;
        }

        public async Task<Recipes> GetRecipeById(int id)
        {
            RestClient client = new RestClient($"{_baseUrl}{id}/information?{_apiKey}");
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                Recipes recipes = JsonConvert.DeserializeObject<Recipes>(response.Content);
                return recipes;
            }

            //TODO: log error, throw exception or do other stuffs for failed requests here.
            //Console.WriteLine(response.Content);

            return null;
        }
    }
}