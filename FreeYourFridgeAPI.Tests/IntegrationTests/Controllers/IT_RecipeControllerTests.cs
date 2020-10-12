using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FreeYourFridge.API;
using FreeYourFridgeAPI.Tests.IntegrationTests.IntegrationTestsHelper.TestModels;
using FreeYourFridgeAPI.Tests.IntegrationTestsHelper;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
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
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddAuthentication("test")
                        .AddScheme<TestAuthenticationSchemeOptions, TestAuthenticationHandler>("test",
                            options => options.NameIdentifier = "1");
                });
            }).CreateClient();

            var response = await client.GetAsync("");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetRecipes_ReturnsExactNumberOfRecipes()
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

            var response = await client.GetFromJsonAsync<List<ExpectedRecipeToList>>("number=3");
            Assert.Equal(3, response.Count);
        }


    }
}
