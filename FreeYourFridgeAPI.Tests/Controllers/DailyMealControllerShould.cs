using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace FreeYourFridge.API.Tests.Controllers
{
    public class DailyMealControllerShould : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;

        public DailyMealControllerShould(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateDefaultClient();
        }

        [Fact]
        public async Task GetDailyMeals_ReturnSuccessStatusCode()
        {
            var response = await _httpClient.GetAsync("/api/dailymeal");
            response.EnsureSuccessStatusCode();
        }
    }
}
