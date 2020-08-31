using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeYourFridge.API.Models;
using Newtonsoft.Json;
using RestSharp;

namespace FreeYourFridge.API.Data
{
    public class WidgetRepository : IWidgetRepository
    {
        private readonly string _baseUrl = "https://api.spoonacular.com/recipes/";
        private readonly string _apiKey = "apiKey=ab1efb6fc9184c32b51bd7ee08cc8891";

        public async Task<string> GetIndegrientsWidget(int recipeId)
        {
            //RestClient client = new RestClient($"{_baseUrl}{recipeId}/ingredientWidget?{_apiKey}");
            RestClient client = new RestClient("https://api.spoonacular.com/recipes/749013/ingredientWidget?apiKey=ab1efb6fc9184c32b51bd7ee08cc8891");
            RestRequest request = new RestRequest(Method.GET);
            IRestRequest sth = request.AddHeader("Accept", "text/html");
            IRestResponse response = await client.ExecuteAsync(sth);
            if (response.IsSuccessful)
            {
                string widget = response.Content;
                return widget;
            }
            return null;
        }

    }
}
