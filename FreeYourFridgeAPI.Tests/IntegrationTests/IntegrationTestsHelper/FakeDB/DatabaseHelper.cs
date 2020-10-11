using System;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.Models;

namespace FreeYourFridgeAPI.Tests.IntegrationTestsHelper.FakeDB
{
    public static class DatabaseHelper
    {
        internal static void InitialiseDbForTests(DataContext db)
        {
            db.Users.Add(new User
            {
                Id = 1,
                Username = "test",
                Email = "test@test.com",
                PasswordHash = new System.Security.Cryptography.HMACSHA512()
                                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes("123456")),
                PasswordSalt = new System.Security.Cryptography.HMACSHA512().Key,
                Gender = "male",
                Age = 18,
                Weight = 70,
                Height = 170
            });

            db.DailyMeals.AddRange(new DailyMeal
            {
                LocalId = Guid.NewGuid(),
                Title = "The first test DM",
                Image = "url1",
                TimeOfLastMeal = DateTime.Now,
                Id = 1,
                Grams = 10,
                UserRemarks = "User remarks 1",
                CaloriesPerPortion = 10,
                Carbs = 20,
                Fat = 30,
                Protein = 40,
                CreatedBy = 1
            },
                new DailyMeal
                {
                    LocalId = Guid.NewGuid(),
                    Title = "The second test DM",
                    Image = "url2",
                    TimeOfLastMeal = DateTime.Now,
                    Id = 2,
                    Grams = 11,
                    UserRemarks = "User remarks 2",
                    CaloriesPerPortion = 11,
                    Carbs = 21,
                    Fat = 31,
                    Protein = 41,
                    CreatedBy = 2
                },
                new DailyMeal
                {
                    LocalId = Guid.NewGuid(),
                    Title = "The third test DM",
                    Image = "url3",
                    TimeOfLastMeal = DateTime.Now,
                    Id = 3,
                    Grams = 12,
                    UserRemarks = "User remarks 3",
                    CaloriesPerPortion = 12,
                    Carbs = 22,
                    Fat = 32,
                    Protein = 42,
                    CreatedBy = 1
                });
            db.SaveChanges();
        }
    }
}
