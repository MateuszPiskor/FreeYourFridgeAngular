using System;
using System.Collections.Generic;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Models;

namespace FreeYourFridgeAPI.Tests.IntegrationTestsHelper.FakeDB
{
    public struct DatabaseToTest
    {
        internal static List<DailyMeal> GetDailyMealsToTest()
        {
            return new List<DailyMeal>
            {
                new DailyMeal
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
                },
            };
        }

        internal static List<DailyMealToAddDto> GetDailyMealToAddToTest()
        {
            return new List<DailyMealToAddDto>
            {
                new DailyMealToAddDto
                {
                    Title = "The first test DM",
                    Image = "url1",
                    Id = 1,
                    Grams = 10,
                    UserRemarks = "User remarks 1",
                    Calories = 10,
                }
            };
        }

        internal static List<FridgeDTO> GetFridgeDtoToTest()
        {
            return new List<FridgeDTO>
            {
                new FridgeDTO
                {
                    Id = 1,
                    UserId = 1
                },
                new FridgeDTO
                {
                    Id = 2,
                    UserId = 1
                }
            };
        }

        internal static List<IngredientDto> GetIngredientDtoToTest()
        {
            return new List<IngredientDto>
            {
                new IngredientDto
                {
                    //Id = 1,
                    //SpoonacularId = 1,
                    //Amount = 120,
                    //Unit = "g",
                    //Name = "ingredient1",
                    //FridgeId = 1,
                    //Fridge = db.Fridges.Where(f => f.Id == 1) as Fridge
                },
                new IngredientDto
                {
                    //Id = 2,
                    //SpoonacularId = 2,
                    //Amount = 820,
                    //Unit = "g",
                    //Name = "ingredient2",
                    //FridgeId = 1,
                    //Fridge = db.Fridges.Where(f => f.Id == 1) as Fridge
                },
                new IngredientDto
                {
                    //Id = 3,
                    //SpoonacularId = 3,
                    //Amount = 520,
                    //Unit = "g",
                    //Name = "ingredient3",
                    //FridgeId = 2,
                    //Fridge = db.Fridges.Where(f => f.Id == 2) as Fridge
                }
            };
        }
    }
}
