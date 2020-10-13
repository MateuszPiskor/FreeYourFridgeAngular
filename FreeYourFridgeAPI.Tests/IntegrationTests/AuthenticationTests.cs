using System;
using System.Net;
using System.Threading.Tasks;
using FreeYourFridge.API;
using FreeYourFridgeAPI.Tests.IntegrationTestsHelper;
using Xunit;

namespace FreeYourFridgeAPI.Tests.IntegrationTests
{
    public class AuthenticationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public AuthenticationTests(CustomWebApplicationFactory<Startup> factory)
        {
            factory.ClientOptions.BaseAddress = new Uri("http://localhost/api");
            _factory = factory;
        }

        [Theory]
        [InlineData("/dailymeal")]
        [InlineData("/favoured")]
        [InlineData("/fridge")]
        [InlineData("/recipe")]
        [InlineData("/shoppinglist")]
        [InlineData("/user")]
        public async Task Get_ForbiddenForUnauthenticatedUser(string uri)
        {
            var httpClient = _factory.CreateClient();

            var response = await httpClient.GetAsync(uri);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
