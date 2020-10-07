using System.Linq;
using System.Threading.Tasks;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.Models;
using FreeYourFridge.API.Tests.TestAsyncProvider;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace FreeYourFridgeAPI.Tests
{
    public class DailyMealRepository_Should
    {
        private DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>().Options;

        [Fact]
        public void Can_AddDeailyMealToDB()
        {
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var dMeal = new Mock<DailyMeal>();
            var mockSet = new Mock<DbSet<DailyMeal>>();

            var mockContext = new Mock<DataContext>(options);
            mockContext.Setup(m => m.DailyMeals).Returns(mockSet.Object);

            var repository = new DailyMealRepository(mockContext.Object);
            repository.AddMeal(dMeal.Object);

            mockSet.Verify(m => m.Add(It.IsAny<DailyMeal>()), Times.Once());
        }

        [Fact]
        public void Can_UpdateDeailyMeaInDB()
        {
            DbContextOptions<DataContext> options = new DbContextOptions<DataContext>();
            var dMeal = new Mock<DailyMeal>();
            var mockSet = new Mock<DbSet<DailyMeal>>();

            var mockContext = new Mock<DataContext>(options);
            mockContext.Setup(m => m.DailyMeals).Returns(mockSet.Object);

            var repository = new DailyMealRepository(mockContext.Object);
            repository.UpdateMeal(dMeal.Object);

            mockSet.Verify(m => m.Update(It.IsAny<DailyMeal>()), Times.Once());
        }

        [Fact]
        public void Can_AddDeailyMealsToArchive()
        {

            var dMeal = new Mock<DailyMealToArchive>();
            var mockSet = new Mock<DbSet<DailyMealToArchive>>();

            var mockContext = new Mock<DataContext>(options);
            mockContext.Setup(m => m.ArchivedDailyMeals).Returns(mockSet.Object);

            var repository = new DailyMealRepository(mockContext.Object);
            repository.AddDailyMealsToArchive(dMeal.Object);

            mockSet.Verify(m => m.Add(It.IsAny<DailyMealToArchive>()), Times.Once());
        }

        [Fact]
        public async Task Can_GetAll()
        {
            var mockSet = new Mock<DbSet<DailyMeal>>();
            mockSet = MockDbProvider<DailyMeal>.ProvideMockDb(DataProvider.DataDailyMeal, mockSet);

            var mockCtx = new Mock<DataContext>(options);
            mockCtx.SetupGet(ctx => ctx.DailyMeals).Returns(mockSet.Object);

            //var dailyMeals = await mockCtx.Object.DailyMeals.ToListAsync();
            var repository = new DailyMealRepository(mockCtx.Object);
            var dailyMeals = await repository.GetDailyMealsAsync();

            Assert.NotNull(dailyMeals);
            Assert.Equal(4, dailyMeals.Count());
            Assert.Equal("title1", dailyMeals.ToList()[0].Title);
            Assert.Equal("title2", dailyMeals.ToList()[1].Title);
            Assert.Equal("title3", dailyMeals.ToList()[2].Title);
        }



    }
}
