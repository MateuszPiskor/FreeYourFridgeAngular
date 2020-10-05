using System;
using System.Linq;
using System.Threading.Tasks;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.Data.Interfaces;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Services
{
    public class DCICalculator
    {
        private readonly IUserRepository _repoUser;
        private readonly IDailyMealRepository _repoDailyMeal;

        public DCICalculator(IUserRepository repository, IDailyMealRepository repoDailyMeal)
        {
            _repoUser = repository;
            _repoDailyMeal = repoDailyMeal;
        }

        /// <summary>
        /// Calculates Daily Calories Intake, used in DailyMealController
        /// </summary>
        /// <param name="userDto">User dispatching by Front </param>
        /// <param name="user">User from DB</param>
        /// <returns>Daily Calories Intake (int) </returns>
        public int CalculateDailyDemand(UserForUpdateDto userDto, UserDetails user)
        {
            int localDD = (user.User.Gender == "Female") ? (int)(447.593 + (9.247 * (double)user.User.Weight) +
                (3.098 * (double)user.User.Height) - (4.330 * user.User.Age)) :
            localDD = (int)(88.362 + (13.397 * (double)user.User.Weight) +
                (4.799 * (double)user.User.Height) - (5.667 * user.User.Age));

            switch (userDto.ActivityLevel)
            {
                case ActivityLevel.Medium:
                    localDD = (int)(localDD * 1.76);
                    break;
                case ActivityLevel.Low:
                    localDD = (int)(localDD * 1.53);
                    break;
                case ActivityLevel.High:
                    localDD = (int)(localDD * 2.25);
                    break;
            }

            localDD = Convert.ToInt32(localDD * 0.95);
            return localDD;
        }

        public async Task<int> CalculaCaloriesPerPortion(int mealId, int grams)
        {
            var incomingMeal = await _repoDailyMeal.GetExternalDailyMeal(mealId);
            int fullportion = incomingMeal.nutrition.weightPerServing.amount;
            var totalcalories = incomingMeal.nutrition.nutrients.ToList()[0].amount;
            return Convert.ToInt32((totalcalories * grams) / fullportion);
        }

        public async Task AdjustDailyDemand(int userId)
        {
            var caloriesFromCurrentDM = await _repoDailyMeal.GetDailyMealsAsync();
            var userDetails = await _repoUser.GetUserDetail(userId) ?? throw new ArgumentNullException(nameof(userId));
            var adjustedDD = userDetails.DailyDemand - caloriesFromCurrentDM.ToList().Select(dm => dm.CaloriesPerPortion).Sum();
            userDetails.DailyDemandToRealize = adjustedDD;
            await _repoUser.SaveAll();
        }
    }
}
