using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FreeYourFridge.API;
using FreeYourFridge.API.Models;
using FreeYourFridgeAPI.Tests.IntegrationTestsHelper;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
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
        public async Task GetFridgeByUserId_ForbiddenForUnauthenticated()
        {
            var response = await _httpClient.GetAsync("GetFridgeByUserId/1");
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }


        [Fact]
        public async Task AddItemToFridge_IfValidDailyMeal_ReturnsOK()
        {
            var content = JsonContent.Create(ReturnValidIngredientToPass());

            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddAuthentication("test")
                        .AddScheme<TestAuthenticationSchemeOptions, TestAuthenticationHandler>("test",
                            options => options.NameIdentifier = "1");
                });
            }).CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("test");

            var response = await client.PostAsync("addIngredient/1", content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetIngredients_ReturnsSuccessStatusCode()
        {
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddAuthentication("test")
                        .AddScheme<TestAuthenticationSchemeOptions, TestAuthenticationHandler>("test",
                            options => options.NameIdentifier = "1");
                });
            }).CreateClient();

            var response = await client.GetAsync("GetIngridients");
            response.EnsureSuccessStatusCode();
        }


        private Ingredient ReturnValidIngredientToPass()
        {
            return new Ingredient
            {
                Id = 4,
                SpoonacularId = 11,
                Amount = 300,
                Unit = "g",
                Name = "ingredient added"
            };
        }
    }
}
