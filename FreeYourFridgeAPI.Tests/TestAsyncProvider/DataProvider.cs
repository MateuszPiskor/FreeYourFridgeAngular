using System.Collections.Generic;
using System.Linq;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Tests.TestAsyncProvider
{
    internal struct DataProvider
    {
        internal static IQueryable<DailyMeal> DataDailyMeal { get; } = new List<DailyMeal>
        {
            new DailyMeal {Title = "title1", Id = 1, CreatedBy = 11},
            new DailyMeal {Title = "title2", Id = 2, CreatedBy = 11},
            new DailyMeal { Title = "title3", Id = 3, CreatedBy = 12},
            new DailyMeal { Title = "title4", Id = 4, CreatedBy = 12}
        }.AsQueryable();
    }
}
