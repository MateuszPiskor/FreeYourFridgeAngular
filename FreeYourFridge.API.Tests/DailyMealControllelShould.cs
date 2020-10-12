using System.Threading.Tasks;
using AutoMapper;
using FreeYourFridge.API.Controllers;
using FreeYourFridge.API.Data.Interfaces;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FreeYourFridge.API.Tests
{
    public class DailyMealControllelShould
    {
        private readonly Mock<IDailyMealRepository> repository = new Mock<IDailyMealRepository>();
        private readonly Mock<IMapper> mapper = new Mock<IMapper>();
        private readonly DCICalculator _calc;
        private DailyMealController controller
        {
            get => new DailyMealController(repository.Object, mapper.Object, _calc);
        }




        [Fact]
        public async Task Cannot_AddNullModel()
        {
            DailyMealToAddDto dmeal = null;

            var result = await controller.AddDailyMeal(dmeal) as ObjectResult;
            Assert.Equal((int)System.Net.HttpStatusCode.BadRequest, result.StatusCode);
        }


    }
}
