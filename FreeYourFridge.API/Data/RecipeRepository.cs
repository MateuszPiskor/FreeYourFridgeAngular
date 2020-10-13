using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.Helpers;
using FreeYourFridge.API.Models;
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

        public async Task<string> GetRespone(IEnumerable<Ingredient> ingredients, int numberOfRecipes)
        {
            string igredientUrl = _makePartialUrl.UrlIngredientMaker(ingredients);
            RestClient client = new RestClient($"{_baseUrl}findByIngredients?{_apiKey}&ingredients={igredientUrl}" + "&number=" + numberOfRecipes+ "&limitLicense=true");
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return response.Content;
            }
            return null;
        }

        public async Task<string> GetResponeWhenPassParams(IEnumerable<Ingredient> ingredients, int numberOfRecipes, UserParamsForFilterRecipes userParams)
        {
            string igredientUrl = _makePartialUrl.UrlIngredientMaker(ingredients);
            string parameters = userParams.ToString();
            RestClient client = new RestClient();
            client.BaseUrl = new Uri($"{_baseUrl}complexSearch?{_apiKey}&includeIngredients={igredientUrl}&fillIngredients=true&number={numberOfRecipes}{parameters}");
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return response.Content;
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

        //To use letter - not delete
        //public async Task<string> GetResponse(string kindOfinformation, string[] optional = null)
        //{
        //    string path = optional == null ? $"{_baseUrl}/{kindOfinformation}/?{_apiKey}" : $"{_baseUrl}/{kindOfinformation}/?{_apiKey}+{genertatePartialUrl(optional)}";

        //    RestClient client = new RestClient(path);
        //    RestRequest request = new RestRequest(Method.GET);
        //    IRestResponse response = await client.ExecuteAsync(request);
        //    if (response.IsSuccessful)
        //    {
        //        return response.Content;
        //    }
        //    return null;
        //}

        //private static string genertatePartialUrl(string[] optional)
        //{
        //    string path = "";
        //    foreach (var parametr in optional)
        //    {
        //        path += "&" + parametr;
        //    }

        //    return path;
        //}
    }
}