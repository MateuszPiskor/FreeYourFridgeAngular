using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace FreeYourFridge.API.Data
{
    public class RecipeRepository : IRecipeRepository
    {
        public async Task<RecipeDto> GetRecipes()
        {
            var client = new RestClient($"https://api.spoonacular.com/recipes/findByIngredients?apiKey=410c59bf9317462d8f0c3a0b3b0f0586&ingredients=apples&number=1");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);
                
                var id = content[0]["id"].Value<int>();
                var title =  content[0]["title"].Value<string>();


                return new RecipeDto
                {
                    Id = id,
                    Title = title
                };
            }

        //TODO: log error, throw exception or do other stuffs for failed requests here.
        Console.WriteLine(response.Content);

        return null;
        }
    }
}