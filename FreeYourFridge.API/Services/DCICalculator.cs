using FreeYourFridge.API.Data;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Services
{
    public class DCICalculator
    {
        private IUserRepository _repository;

        public DCICalculator(IUserRepository repository)
        {
            _repository = repository;
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

            return localDD;
        }
    }
}
