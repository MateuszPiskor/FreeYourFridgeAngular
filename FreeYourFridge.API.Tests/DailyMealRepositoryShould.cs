using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.Models;
using Moq;

namespace FreeYourFridge.API.Tests
{
    public class DailyMealRepositoryShould
    {
        public async Task Should_AskDbOnce()
        {
            var testData = new List<DailyMeal>
            {
                //new DailyMeal
                //{
                //    LocalId = Guid.NewGuid(),
                //    Title = "title",
                //    Image = "image",
                //    TimeOfLastMeal = DateTime.UtcNow,
                //    Id = 1,
                //    Grams = 1,
                //    UserRemarks = "remarks",
                //    CaloriesPerPortion = 1,
                //    Carbs = 1,
                //    Fat = 1,
                //    Protein = 1,
                //    CreatedBy = 1
                //},
                //new DailyMeal
                //{
                //    LocalId = Guid.NewGuid(),
                //    Title = "title2",
                //    Image = "image2",
                //    TimeOfLastMeal = DateTime.UtcNow,
                //    Id = 2,
                //    Grams = 2,
                //    UserRemarks = "remarks2",
                //    CaloriesPerPortion = 2,
                //    Carbs = 2,
                //    Fat = 2,
                //    Protein = 2,
                //    CreatedBy = 2
                //}
            };
            var mockdb = new Mock<DataContext>();
            //mockdb.SetupGet(m => m.DailyMeals).Returns( );
        }
    }
}
