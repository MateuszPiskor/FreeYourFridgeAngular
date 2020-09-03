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
        private readonly string _apiKey ="apiKey=410c59bf9317462d8f0c3a0b3b0f0586";
        private readonly RestClient client=new RestClient();

        public RecipeRepository()
        {
            ;
        }

        public async Task<IEnumerable<Recipes>> GetRecipesByIndegrients(IEnumerable<Ingredients> ingredients, int numberOfRecipes)
        {
            string partUrlPath = "";
            foreach(var ingredient in ingredients)
            {
                partUrlPath +=",+"+ingredient.Name;
            }
            partUrlPath = partUrlPath.Substring(2);
            RestClient client = new RestClient($"{_baseUrl}findByIngredients?{_apiKey}&ingredients={partUrlPath}"+"&number=" + numberOfRecipes);
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

        public async Task<string> GetResponseById(int id, string information)
        {
            RestClient client = new RestClient($"{_baseUrl}{id}/{information}/?{_apiKey}");
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return response.Content;
            }

            //TODO: log error, throw exception or do other stuffs for failed requests here.
            //Console.WriteLine(response.Content);

            return null;
        }
    }
}