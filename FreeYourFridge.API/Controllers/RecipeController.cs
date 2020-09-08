using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreeYourFridge.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _repo;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("")]
        [HttpGet("number={amount}")]
        public async Task<IActionResult> GetRecipes(int amount = 10)
        {
            List<Ingredients> ingredients = new List<Ingredients>()
            {
                new Ingredients()
                {
                    Name="apple"
                },
                new Ingredients()
                {
                    Name="orange"
                },
                new Ingredients()
                {
                    Name="milk"
                }
            };
            IEnumerable<Recipe> model = await _repo.GetRecipesByIndegrients(ingredients, amount);
            if (model == null)
                return NotFound();

            IEnumerable<RecipeForDetailDto> recipesForDetailedDto = _mapper.Map<IEnumerable<RecipeForDetailDto>>(model);

            return Ok(recipesForDetailedDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAditionalInforationAboutRecipeById(int id)
        {
            string content = await _repo.GetResponseById(id, "information");
            if (content == null)
                return NotFound();
            Recipe recipes = JsonConvert.DeserializeObject<Recipe>(content);

            RecipeForDetailDto recipesForDetailedDto = _mapper.Map<RecipeForDetailDto>(recipes);
            return Ok(recipesForDetailedDto);
        }

        [HttpGet("{id}/nutritions")]
        public async Task<IActionResult> GetNutritionsById(int id)
        {
            string content = await _repo.GetResponseById(id, "nutritionWidget.json");

            if (content == null)
                return NotFound();

            Nutrition nutrition = JsonConvert.DeserializeObject<Nutrition>(content);

            NutriotionForDetailDto recipesForDetailedDto = _mapper.Map<NutriotionForDetailDto>(nutrition);

            return Ok(recipesForDetailedDto);
        }

        [HttpGet("{id}/instruction")]
        public async Task<IActionResult> GetInstructionStepsById(int id)
        {
            string content = await _repo.GetResponseById(id, "analyzedInstructions");

            if (content == null)
                return NotFound();

            Instruction instruction = JsonConvert.DeserializeObject<IEnumerable<Instruction>>(content).First();

            return Ok(instruction.steps);
        }

        [HttpGet("{id}/ingredients")]
        public async Task<IActionResult> GetIngredients(int id)
        {
            IActionResult recipes = await GetRecipes();
            if (recipes == null)
            {
                return NotFound();
            }
            var okResult = recipes as OkObjectResult;
            IEnumerable<RecipeForDetailDto> result = (IEnumerable<RecipeForDetailDto>)okResult.Value;

            RecipeForDetailDto recipeForDetailedDto = result.FirstOrDefault(x => x.Id == id);
            return Ok(recipeForDetailedDto);
        }
    }
}