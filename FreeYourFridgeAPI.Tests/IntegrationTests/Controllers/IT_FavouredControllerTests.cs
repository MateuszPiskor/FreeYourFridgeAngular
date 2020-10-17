using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FreeYourFridge.API;
using FreeYourFridgeAPI.Tests.IntegrationTestsHelper;
using Xunit;

namespace FreeYourFridgeAPI.Tests.IntegrationTests.Controllers
{
    public class IT_FavouredControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        private CustomWebApplicationFactory<Startup> _factory;
        private string uri = "http://localhost/api/favoured/";

        public IT_FavouredControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            factory.ClientOptions.BaseAddress = new Uri(uri);
            _httpClient = factory.CreateClient();
            _factory = factory;
        }


        [Fact]
        public async Task GetFavoureds_ReturnSuccessStatusCode()
        {

            var response = await _httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task DeleteFavoured_IfValid_ReturnsOK()
        {

            var response = await _httpClient.DeleteAsync("11168");
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }



    }
}
