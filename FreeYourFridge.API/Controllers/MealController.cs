//using System.Threading.Tasks;
//using FreeYourFridge.API.Data;
//using FreeYourFridge.API.DTOs;
//using FreeYourFridge.API.Models;
////using FreeYourFridge.API.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace FreeYourFridge.API.Controllers
//{
//    [Route("api/[controller]")]
//    public class MealController : Controller
//    {
//        private readonly IMealRepository _repo;

//        //private readonly DataContext _context;

//        public MealController(IMealRepository repo)
//        {
//            _repo = repo;
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddMealAsync([FromBody] MealForAddDto mealforAddDto)
//        {
//            Meal meal = new Meal()
//            {
//                Grams = mealforAddDto.Grams,
//                SpoonacularId = mealforAddDto.SpoonacularId
//            };
//            Meal createdMeal = await _repo.AddMealAsync(meal);
//            return StatusCode(201);
//        }
//    }
//}