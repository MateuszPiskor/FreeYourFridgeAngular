using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FreeYourFridge.API;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace FreeYourFridgeAPI.Tests.IntegrationTests
{
    public class AuthenticationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public AuthenticationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("api/dailymeal")]
        [InlineData("api/favoured")]
        [InlineData("api/recipe")]
        [InlineData("api/shoppinglist")]
        [InlineData("api/user")]
        public async Task Get_ForbiddenForUnauthenticatedUser(string uri)
        {
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(AuthenticationManager));
                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }
                });
            }).CreateClient();

            var response = await client.GetAsync(uri);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        //[Fact] 
        public async Task Get_ForbiddenForUnauthenticatedUserToFridge()
        {
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(AuthenticationManager));
                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }
                });
            }).CreateClient();

            var response = await client.GetAsync("/api/fridge");
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}