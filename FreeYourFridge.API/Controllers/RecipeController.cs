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
        public async Task<IActionResult> GetRecipes([FromQuery] UserParamsForFilterRecipes userParams, int amount = 12)
        {

            int userId= int.Parse(User.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            IEnumerable<Ingredient> ingredients = _repoFridge.GetIngredients(userId);
            string content = null;

            if (userParams.DietType != null || userParams.CuisineType != null)
            {
               content = await _repo.GetResponeWhenPassParams(ingredients, amount, userParams);
                Root recipesToReturn = JsonConvert.DeserializeObject<Root>(content);
                return Ok(recipesToReturn.Results);
            }

            else
            {
                content = await _repo.GetRespone(ingredients, amount);
            }
            
            if (content == null)
            {
                return NotFound();
            }

            
            IEnumerable<RecipeToList> recipes = JsonConvert.DeserializeObject<IEnumerable<RecipeToList>>(content);
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTimeAndScore(int id)
        {
            string content = await _repo.GetRespone(id, "information");
            if (content == null)
                return NotFound();
            RecipeToDetail recipeDetail = JsonConvert.DeserializeObject<RecipeToDetail>(content);

            RecipeToDetailDto recipesForDetailedDto = _mapper.Map<RecipeToDetailDto>(recipeDetail);
            return Ok(recipesForDetailedDto);
        }

        [HttpGet("{id}/nutritions")]
        public async Task<IActionResult> GetNutritionsById(int id)
        {
            string content = await _repo.GetRespone(id, "nutritionWidget.json");

            if (content == null)
                return NotFound();

            Nutrition nutrition = JsonConvert.DeserializeObject<Nutrition>(content);

            NutriotionForDetailDto recipesForDetailedDto = _mapper.Map<NutriotionForDetailDto>(nutrition);

            return Ok(recipesForDetailedDto);
        }

        [HttpGet("{id}/instruction")]
        public async Task<IActionResult> GetInstructionStepsById(int id)
        {
            string content = await _repo.GetRespone(id, "analyzedInstructions");

            if (content == null)
                return NotFound();

            Instruction instruction = JsonConvert.DeserializeObject<IEnumerable<Instruction>>(content).First();

            return Ok(instruction.steps);
        }
    }
}