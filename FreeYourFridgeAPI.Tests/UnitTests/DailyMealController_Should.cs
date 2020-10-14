using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FreeYourFridge.API.Controllers;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.Data.Interfaces;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Models;
using FreeYourFridge.API.Services;
using FreeYourFridge.API.Tests.TestAsyncProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace FreeYourFridge.API.Tests
{
    public class DailyMealController_Should
    {
        private DCICalculator _calc;
        private DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>().Options;

        [Fact]
        public async Task Cannot_AddNullModel()
        {
            DailyMealToAddDto dmeal = null;
            var repository = new Mock<IDailyMealRepository>();
            var mapper = new Mock<IMapper>();
            var controller = new DailyMealController(repository.Object, mapper.Object, _calc);


            var result = await controller.AddDailyMeal(dmeal) as ObjectResult;
            Assert.Equal((int)System.Net.HttpStatusCode.BadRequest, result.StatusCode);
        }


        [Fact]
        public async Task Should_ReturnAllDailyMeals()
        {
            IMapper mapper = new Mapper(
                new MapperConfiguration(
                    cfg => cfg.CreateMap<DailyMeal, DailyMealBasicDto>()));

            var mockSet = new Mock<DbSet<DailyMeal>>();
            mockSet = MockDbProvider<DailyMeal>.ProvideMockDb(DataProvider.DataDailyMeal, mockSet);
            var mockCtx = new Mock<DataContext>(options);
            mockCtx.SetupGet(ctx => ctx.DailyMeals).Returns(mockSet.Object);


            var repository = new Mock<DailyMealRepository>(mockCtx.Object);


            var controller = new DailyMealController(repository.Object, mapper, _calc);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(MockDbProvider<DailyMeal>.identity)
            };


            var result = await controller.GetDailyMeals() as ObjectResult;
            var value = result.Value as List<DailyMealBasicDto>;
            Assert.NotNull(result);
            Assert.Equal(2, value.Count);
        }


    }
}
