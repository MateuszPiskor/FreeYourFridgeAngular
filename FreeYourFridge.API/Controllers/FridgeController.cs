using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreeYourFridge.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class FridgeController : ControllerBase
    {
        private readonly IFridgeRepository _repo;
        private readonly IIngredientRepository _ingridientRepo;
        private DataContext _data {get;set;}
        public Ingredient newIgredient{get;set;}
        private readonly IMapper _mapper;

        public FridgeController(IFridgeRepository repo, DataContext data, IMapper mapper, IIngredientRepository ingridientRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _data = data;
            newIgredient = new Ingredient();
            _ingridientRepo = ingridientRepo;
        }
        [HttpGet("GetFridgeByUserId/{id}")]
        public async Task<IActionResult> GetFridgeByUserId(int id)
        {
            var fridge = await _repo.GetFridge(id);
            var allIgredients = _data.Ingredients
                                            .Where(i => i.FridgeId == fridge.Id)
                                            .ToList();
            fridge.ListIgredients = allIgredients;
            return Ok(fridge);
        }
        [HttpPost("AddItemToFridge/{userId}")]
        public async Task<ActionResult<Ingredient>> AddItemToFridge(int userId, [FromBody]Ingredient newIgredients)
        {
            var fridge = await _repo.GetFridge(userId);
            newIgredient.FridgeId = fridge.Id;
            newIgredient.Fridge = fridge;
            newIgredient.Amount = newIgredients.Amount;
            newIgredient.Name = newIgredients.Name;
            newIgredient.Unit = newIgredients.Unit;
            newIgredient.SpoonacularId = 25;
            _repo.Add(newIgredients);
            await _repo.SaveAll();
            return Ok();
        }

        [HttpDelete("{ingredientId}")]
        public async void DeleteItemFromFridge(int ingredientId)
        {
            var item = await _repo.GetIngredient(ingredientId);
            _repo.Delete(item);
            await _repo.SaveAll();
        }
        [HttpPost("{ingredientId}")]
        public async Task<IActionResult> UpdateIngredient(int ingredientId, [FromBody]double amount)
        {
            _repo.UpdateIngredient(ingredientId, amount);
            return NoContent();
        }

        [HttpGet("GetIngridients")]
        public async Task<IActionResult> GetIngridients()
        {
            var ListOfIngredients = await _ingridientRepo.GetAllIngredients();
            if (ListOfIngredients == null)
                return NotFound();
                
            return Ok(ListOfIngredients);
        }
        [HttpGet("GetUnits/{id}")]
        public async Task<IActionResult> GetIngridientUnits(int id)
        {
            var ingredientUnits = await _ingridientRepo.GetIngredientsFromAPI(id);
            if (ingredientUnits == null)
                return NotFound();
                
            return Ok(ingredientUnits);
        }

    }
}