using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeYourFridge.API.DTOs;
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
            _apiKey = apiKeyReader.getKey();
            _makePartialUrl = makePartialUrl;
        }

        public async Task<IEnumerable<RecipeToList>> GetRecipes(IEnumerable<Ingredient> ingredients, UserParamsForFilterRecipes userParams)
          {
            string igredientUrl = _makePartialUrl.UrlIngredientMaker(ingredients);
            RestClient client = new RestClient($"{_baseUrl}findByIngredients?{_apiKey}&ingredients={igredientUrl}" +"&number=" +userParams.Number + "&limitLicense=true");
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<IEnumerable<RecipeToList>>(response.Content);
            }
            return null;
        }

        public async Task<IEnumerable<RecipeToList>> GetResponeWhenPassParams(IEnumerable<Ingredient> ingredients, UserParamsForFilterRecipes userParams)
        {
            string igredientUrl = _makePartialUrl.UrlIngredientMaker(ingredients);
            string parameters = userParams.ToString();
            RestClient client = new RestClient();
            client.BaseUrl = new Uri($"{_baseUrl}complexSearch?{_apiKey}&includeIngredients={igredientUrl}&fillIngredients=true&number={userParams.Number}{parameters}");
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                Root root = JsonConvert.DeserializeObject<Root>(response.Content);
                return root.Results;
            }
            return null;
        }

        public async Task<string> GetRespone(int id, string kindOfInformation)
        {
            RestClient client = new RestClient($"{_baseUrl}{id}/{kindOfInformation}/?{_apiKey}");
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return response.Content;
            }
            return null;
        }

        public async Task<RecipeToDetail> GetRecipeTimeAndScore(int id)
        {
            string response = await GetRespone(id, "information");
            if (response != null)
            {
                return JsonConvert.DeserializeObject<RecipeToDetail>(response);
            }
            return null;
        }

        public async Task<Nutrition> GetNutritionById(int id)
        {
            var response = await GetRespone(id, "nutritionWidget.json");
            if(response != null)
            {
                return JsonConvert.DeserializeObject<Nutrition>(response);
            }
            return null;
        }

        public async Task<IEnumerable<Instructionstep>> GetInstructionSteps(int id)
        {
           var response = await GetRespone(id, "analyzedInstructions");

            if (response != null)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Instruction>>(response).First().steps;
            }
            return null;
        }

    }
}