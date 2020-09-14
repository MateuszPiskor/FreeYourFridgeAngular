using System.Threading.Tasks;
using AutoMapper;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeYourFridge.API.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListRepository _repo;

        public ShoppingListController(IShoppingListRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> AddMealAsync([FromBody] IngredientForAddDto ingredientforAddDto)
        {
            Ingredient ingredient = new Ingredient()
            {
                SpoonacularId = ingredientforAddDto.SpoonacularId,
                Amount = ingredientforAddDto.Amount,
                Name = ingredientforAddDto.Name,
                Unit = ingredientforAddDto.Unit
                
            };
            Ingredient createdMeal = await _repo.AddIngredientAsync(ingredient);
            return StatusCode(201);
        }
    }
}