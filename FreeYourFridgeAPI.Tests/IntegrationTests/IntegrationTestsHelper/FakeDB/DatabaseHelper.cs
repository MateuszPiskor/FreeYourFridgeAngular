using System;
using System.Linq;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.Models;

namespace FreeYourFridgeAPI.Tests.IntegrationTestsHelper.FakeDB
{
    public class DatabaseHelper
    {
        internal DatabaseHelper GetDefaultDb()
        {
            var db = new DatabaseHelper();
            return db;
        }

        internal void InitialiseDbForTests(DataContext db)
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

            db.UsersDetails.Add(new UserDetails
            {
                Id = 1,
                DailyDemand = 1900,
                DailyDemandToRealize = 1900,
                Carbohydrates = 21,
                Fats = 21,
                Protein = 21,
                Description = "",
                User = db.Users.Where(u => u.Id == 1) as User,
                ActivityLevel = ActivityLevel.Medium,
                UserId = 1
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

            db.Favoureds.AddRange(
            new Favoured
            {
                Id = "1",
                Score = 74,
                SpoonacularId = 11168,
                Image = "imageUrl",
                Title = "title",
                CreateTime = new DateTime(2020, 07, 01),
                CreatedBy = 1
            },
            new Favoured
            {
                Id = "2",
                Score = 34,
                SpoonacularId = 1077,
                Image = "imageUrl2",
                Title = "title2",
                CreateTime = new DateTime(2020, 07, 02),
                CreatedBy = 2
            }
                );

            db.Fridges.AddRange(
                new Fridge
                {
                    Id = 1,
                    UserId = 1,
                    user = db.Users.Where(u => u.Id == 1) as User,
                    ListIgredients = db.Ingredients.Where(i => i.FridgeId == 1).ToList()
                },
                new Fridge
                {
                    Id = 2,
                    UserId = 2,
                    user = db.Users.Where(u => u.Id == 2) as User,
                    ListIgredients = db.Ingredients.Where(i => i.FridgeId == 2).ToList()
                });

            db.Ingredients.AddRange(
                new Ingredient
                {
                    Id = 1,
                    SpoonacularId = 11168,
                    Amount = 120,
                    Unit = "g",
                    Name = "corn",
                    FridgeId = 1,
                    Fridge = db.Fridges.Where(f => f.Id == 1) as Fridge
                },
                new Ingredient
                {
                    Id = 2,
                    SpoonacularId = 11169,
                    Amount = 820,
                    Unit = "g",
                    Name = "ingredient2",
                    FridgeId = 2,
                    Fridge = db.Fridges.Where(f => f.Id == 1) as Fridge
                },
                new Ingredient
                {
                    Id = 3,
                    SpoonacularId = 11170,
                    Amount = 520,
                    Unit = "g",
                    Name = "ingredient3",
                    FridgeId = 2,
                    Fridge = db.Fridges.Where(f => f.Id == 2) as Fridge
                });

            db.SaveChanges();
        }
    }
}
