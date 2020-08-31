using System.Collections.Generic;
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
        private readonly int _numberOfResipes=8;

        public RecipeController(IRecipeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            //later change to frige.getIndgredients
            List<Ingredients> ingredients = new List<Ingredients>()
            {
                new Ingredients()
                {
                    Name="chicken"
                },
                new Ingredients()
                {
                    Name="orange"
                }
            };
            var model = await _repo.GetRecipesByIndegrients(ingredients, _numberOfResipes);
            if (model == null)
                return NotFound();

            var recipesForDetailedDto = _mapper.Map<IEnumerable<RecipeForListDto>>(model);
            return Ok(recipesForDetailedDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeById(int id)
        {
            string content = await _repo.GetResponseById(id, "information");
            if (content == "")
                return NotFound();
            Recipes recipes = JsonConvert.DeserializeObject<Recipes>(content);

            RecipeForDetailDto recipesForDetailedDto = _mapper.Map<RecipeForDetailDto>(recipes);

            content = await _repo.GetResponseById(id, "nutritionWidget.json");

            Nutrition nutrition = JsonConvert.DeserializeObject<Nutrition>(content);

            recipesForDetailedDto.Calories = nutrition.Calories;
            recipesForDetailedDto.Fat = nutrition.Fat;
            recipesForDetailedDto.Carbs = nutrition.Carbs;
            recipesForDetailedDto.Protein = nutrition.Protein;
            
            return Ok(recipesForDetailedDto);
        }
    }
}