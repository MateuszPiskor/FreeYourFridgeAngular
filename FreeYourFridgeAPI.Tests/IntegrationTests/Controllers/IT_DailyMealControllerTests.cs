using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Models;
using FreeYourFridgeAPI.Tests.IntegrationTestsHelper;
using FreeYourFridgeAPI.Tests.IntegrationTestsHelper.FakeDB;
using FreeYourFridgeAPI.Tests.IntegrationTestsHelper.TestModels;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace FreeYourFridge.API.Tests.Controllers
{
    public class IT_DailyMealControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        private CustomWebApplicationFactory<Startup> _factory;
        private string uri = "http://localhost/api/dailymeal/";

        public IT_DailyMealControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            factory.ClientOptions.BaseAddress = new Uri(uri);
            _httpClient = factory.CreateClient();
            _factory = factory;
        }

        [Fact]
        public async Task Get_ForbiddenForUnauthenticatedUser()
        {
            var response = await _httpClient.GetAsync("");
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task GetDailyMeals_ReturnSuccessStatusCode()
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

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("test");

            var response = await client.GetAsync("");
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task GetDailyMeals_AssignedToCreator()
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

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("test");

            var response = await client.GetAsync("");
            var model = JsonSerializer
                        .Deserialize<List<ExpectedDailyMealBasicDto>>(await response.Content.ReadAsStringAsync());
            var expectedNumber = DatabaseToTest
                                    .GetDailyMealsToTest().Count(dm => dm.CreatedBy == 1);
            Assert.Equal(expectedNumber, model.Count);
        }


        [Fact]
        public async Task GetSingleDailyMeal_ReturnsSuccessStatusCode()
        {
            var dmToBeAssessed = DatabaseToTest.GetDailyMealsToTest().First();

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

            var response = await client.GetAsync($"{uri}{dmToBeAssessed.Id}");
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task GetSingleDailyMeal_GetExpectedDailyMeal()
        {
            var dmToBeAssessed = DatabaseToTest.GetDailyMealsToTest().First();

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

            var response = await client.GetFromJsonAsync<ExpectedDailyMealBasicDto>($"{uri}{dmToBeAssessed.Id}");

            Assert.NotNull(response);
            Assert.Equal(dmToBeAssessed.Title, response.Title);
            Assert.Equal(dmToBeAssessed.Grams, response.Grams);
            Assert.Equal(dmToBeAssessed.Id, response.Id);
        }

        [Fact]
        public async Task AddDailyMeal_IfDailyMealInDatabase_ReturnsConflict()
        {
            var dailyMealToPass = DatabaseToTest.GetDailyMealToAddToTest().First();
            var content = JsonContent.Create(dailyMealToPass);

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

            var response = await client.PostAsync("", content);

            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
        }

        [Fact]
        public async Task AddDailyMeal_IfValidDailyMeal_ReturnsCreatedResult()
        {
            var content = JsonContent.Create(ReturnValidDailyMealToAddDtoToPass());

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

            var response = await client.PostAsync("", content);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }


        [Fact]
        public async Task UpdateDailyMeal_IfUpdatedNotExistInDb_ReturnsBadRequest()
        {
            var model = ReturnValidDailyMealToAddDtoToPass();
            model.Id = 11;

            var content = JsonContent.Create(model);
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

            var response = await client.PutAsync("", content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }


        [Fact]
        public async Task UpdateDailyMeal_IfValidModel_ReturnsNoContent()
        {
            var model = ReturnValidDailyMealToAddDtoToPass();
            model.Id = 1;

            var content = JsonContent.Create(model);
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

            var response = await client.PutAsync("", content);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }


        private DailyMealToAddDto ReturnValidDailyMealToAddDtoToPass()
        {
            return new DailyMealToAddDto
            {
                Id = 5,
                Title = "Title to update",
                Image = "url_new",
                Grams = 14,
                UserRemarks = "User remarks new",
                Calories = 14,
            };
        }

        private DailyMeal ReturnInvalidDailyMealToPass()
        {
            return new DailyMeal
            {
                LocalId = Guid.NewGuid(),
                Title = null,
                Image = "url_new to update",
                TimeOfLastMeal = DateTime.Now,
                Id = 4,
                Grams = 14,
                UserRemarks = "User remarks to update",
                CaloriesPerPortion = 14,
                Carbs = 24,
                Fat = 34,
                Protein = 44,
                CreatedBy = 1
            };
        }

    }
}
