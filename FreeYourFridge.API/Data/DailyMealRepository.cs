using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.Data.Interfaces;
using FreeYourFridge.API.ExternalModels;
using FreeYourFridge.API.Helpers;
using FreeYourFridge.API.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;

namespace FreeYourFridge.API.Data
{
    public class DailyMealRepository : IDailyMealRepository
    {
        private readonly DataContext _context;
        private const string UrlToSpoon = "https://api.spoonacular.com/recipes/";
        private const string QueryContent = "information?includeNutrition=true&";
        private readonly ApiKeyReader _apiKeyReader;


        public DailyMealRepository(DataContext context,
            ApiKeyReader apiKeyReader)
        {
            _context = context;
            _apiKeyReader = apiKeyReader;
        }

        /// <summary>
        /// Gets a list of DailyMeals from localDB
        /// </summary>
        /// <returns>a list of DailyMeals</returns>
        public async Task<IEnumerable<DailyMeal>> GetDailyMealsAsync()
            => await _context.DailyMeals.ToListAsync();

        /// <summary>
        /// Gets one DailyMeal from localDB
        /// </summary>
        /// <param name="id"></param>
        /// <returns>single DailyMeal</returns>
        public async Task<DailyMeal> GetDailyMealAsync(int id)
            => await _context.DailyMeals.FirstOrDefaultAsync(m => m.Id == id);

        /// <summary>
        /// Add meal to localDB
        /// </summary>
        /// <param name="dailyMeal"></param>
        /// <returns>void</returns>
        public void AddMeal(DailyMeal dailyMeal)
        {
            if (dailyMeal == null)
            {
                throw new ArgumentNullException(nameof(dailyMeal));
            }
            _context.DailyMeals.Add(dailyMeal);
        }

        public void UpdateMeal(DailyMeal meal)
            => _context.DailyMeals.Update(meal);

        /// <summary>
        /// Removes all elements from the entity "DailyMeals"
        /// </summary>
        /// <returns>void</returns>

        public async Task ClearTable()
        {
            var dmealsToRemove = await _context.DailyMeals.ToListAsync();
            _context.DailyMeals.RemoveRange(dmealsToRemove);
        }

        /// <summary>
        /// Pulls single meal from Api.Spoonacular
        /// </summary>
        /// <param name="id"> it's SpoonacularId</param>
        /// <returns>deserialized class IncomingRecipe</returns>
        public async Task<IncomingRecipe> GetExternalDailyMeal(int id)
        {

            //var incom2 = JsonConvert.DeserializeObject<IncomingRecipe>(await File.ReadAllTextAsync("response.json"));

            var client = new RestClient($"{UrlToSpoon}/{id}/{QueryContent}{_apiKeyReader.getKey()}");
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteAsync<IncomingRecipe>(request);
            if (response.IsSuccessful)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<IncomingRecipe>(response.Content);

        }

        public void AddDailyMealsToArchive(DailyMealToArchive dMealToArchive)
            => _context.ArchivedDailyMeals.Add(dMealToArchive);

        public async Task<bool> SaveChangesAsync()
            => await _context.SaveChangesAsync() > 0;
    }
}