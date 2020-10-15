using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Helpers;
using FreeYourFridge.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreeYourFridge.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _repo;
        private readonly IMapper _mapper;
        private readonly IFridgeRepository _repoFridge;

        public RecipeController(IRecipeRepository repo, IMapper mapper, IFridgeRepository repoFridge)
        {
            _repo = repo;
            _mapper = mapper;
            _repoFridge = repoFridge;
        }

        [HttpGet("")]
        [HttpGet("number={amount}")]
        public async Task<IActionResult> GetRecipes([FromQuery] UserParamsForFilterRecipes userParams)
        {
            int userId = int.Parse(User.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            IEnumerable<Ingredient> ingredients = _repoFridge.GetIngredients(userId);
            IEnumerable<RecipeToList> recipes = new List<RecipeToList>();

            if (userParams.DietType != null || userParams.CuisineType != null )
            {
                recipes = await _repo.GetResponeWhenPassParams(ingredients, userParams);
            }
            else
            {
                recipes = await _repo.GetRecipes(ingredients, userParams);
            }

            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTimeAndScore(int id)
        {
            RecipeToDetail recipeToDetail = await _repo.GetRecipeTimeAndScore(id);
            if(recipeToDetail != null)
            {
                return Ok(_mapper.Map<RecipeToDetailDto>(recipeToDetail));
            }
            return NotFound();
        }

        [HttpGet("{id}/nutritions")]
        public async Task<IActionResult> GetNutritionsById(int id)
        {
            Nutrition nutrition = await _repo.GetNutritionById(id);
            if(nutrition != null)
            {
                return Ok(_mapper.Map<NutriotionForDetailDto>(nutrition));
            }
            return NotFound();
        }

        [HttpGet("{id}/instruction")]
        public async Task<IActionResult> GetInstructionSteps(int id)
        {
            IEnumerable<Instructionstep> steps = await _repo.GetInstructionSteps(id);
            if(steps != null)
            {
                return Ok(_mapper.Map<IEnumerable<StepDto>>(steps));
            }
            return NotFound();
            
        }
    }
}