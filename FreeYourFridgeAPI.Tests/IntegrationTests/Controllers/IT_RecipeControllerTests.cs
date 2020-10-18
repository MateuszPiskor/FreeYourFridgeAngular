using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FreeYourFridge.API;
using FreeYourFridgeAPI.Tests.IntegrationTests.IntegrationTestsHelper.TestModels;
using FreeYourFridgeAPI.Tests.IntegrationTestsHelper;
using Xunit;

namespace FreeYourFridgeAPI.Tests.IntegrationTests.Controllers
{
    public class IT_RecipeControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        private CustomWebApplicationFactory<Startup> _factory;
        private string uri = "http://localhost/api/recipe/";

        public IT_RecipeControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            factory.ClientOptions.BaseAddress = new Uri(uri);
            _httpClient = factory.CreateClient();
            _factory = factory;
        }

        [Fact]
        public async Task GetRecipes_ReturnsSuccessStatusCode()
        {
            var response = await _httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetRecipes_ReturnsExactNumberOfRecipes()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ExpectedRecipeToList>>("number=3");
            Assert.Equal(3, response.Count);
        }


    }
}
