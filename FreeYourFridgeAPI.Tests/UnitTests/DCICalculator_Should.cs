using System;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.Data.Interfaces;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Models;
using FreeYourFridge.API.Services;
using Moq;
using Xunit;

namespace FreeYourFridge.API.Tests
{
    public class DCICalculator_Should
    {
        [Fact]
        public void Cannot_CalculateIdArgumentsAreNull()
        {
            UserForUpdateDto userDto = null;
            UserDetails user = null;
            var mockUser = new Mock<IUserRepository>();
            var mockDMRepo = new Mock<IDailyMealRepository>();
            var _sut = new DCICalculator(mockUser.Object, mockDMRepo.Object);

            Assert.Throws<ArgumentNullException>(() => _sut.CalculateDailyDemand(userDto, user));
        }

        [Fact]
        public void Can_CalculateProperValueIfMaleHighActivity()
        {
            var userDto = new UserForUpdateDto
            {
                ActivityLevel = ActivityLevel.High

            };
            var user = new UserDetails
            {
                User = new User
                {
                    Weight = 70,
                    Height = 180,
                    Age = 40,
                    Gender = "Male"
                }
            };

            var mockUser = new Mock<IUserRepository>();
            var mockDMRepo = new Mock<IDailyMealRepository>();
            var _sut = new DCICalculator(mockUser.Object, mockDMRepo.Object);

            var result = _sut.CalculateDailyDemand(userDto, user);
            Assert.Equal(3554, result);
        }

        [Fact]
        public void Can_CalculateProperValueIfFemaleHighActivity()
        {
            var userDto = new UserForUpdateDto
            {
                ActivityLevel = ActivityLevel.High

            };
            var user = new UserDetails
            {
                User = new User
                {
                    Weight = 60,
                    Height = 160,
                    Age = 40,
                    Gender = "Female"
                }
            };

            var mockUser = new Mock<IUserRepository>();
            var mockDMRepo = new Mock<IDailyMealRepository>();
            var _sut = new DCICalculator(mockUser.Object, mockDMRepo.Object);

            var result = _sut.CalculateDailyDemand(userDto, user);
            Assert.Equal(2830, result);
        }

        //[Theory]
        //[InlineData(123, 50)]
        public void Can_CalculateCaloriesPerPortion(int mealId, int grams)
        {
            var mockUser = new Mock<IUserRepository>();
            var mockDMRepo = new Mock<IDailyMealRepository>();
            var _sut = new DCICalculator(mockUser.Object, mockDMRepo.Object);
            //var incomMeal = new Mock<IncomingRecipe>();


            //var result = _sut.CalculateDailyDemand(userDto, user);
            //Assert.Equal(2830, result);
        }
    }
}
