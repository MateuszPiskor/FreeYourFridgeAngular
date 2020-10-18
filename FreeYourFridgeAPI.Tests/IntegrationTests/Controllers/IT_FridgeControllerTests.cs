using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FreeYourFridge.API;
using FreeYourFridge.API.Models;
using FreeYourFridgeAPI.Tests.IntegrationTestsHelper;
using Xunit;

namespace FreeYourFridgeAPI.Tests.IntegrationTests.Controllers
{
    public class IT_FridgeControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        private CustomWebApplicationFactory<Startup> _factory;
        private string uri = "http://localhost/api/fridge/";

        public IT_FridgeControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            factory.ClientOptions.BaseAddress = new Uri(uri);
            _httpClient = factory.CreateClient();
            _factory = factory;
        }


        [Fact]
        public async Task AddItemToFridge_IfValidDailyMeal_ReturnsOK()
        {
            var content = JsonContent.Create(ReturnValidIngredientToPass());

            var response = await _httpClient.PostAsync("addIngredient/11168", content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetIngredients_ReturnsSuccessStatusCode()
        {

            var response = await _httpClient.GetAsync("GetIngridients");
            response.EnsureSuccessStatusCode();
        }


        private Ingredient ReturnValidIngredientToPass()
        {
            return new Ingredient
            {
                Id = 11168,
                SpoonacularId = 11,
                Amount = 300,
                Unit = "g",
                Name = "ingredient added"
            };
        }
    }
}
