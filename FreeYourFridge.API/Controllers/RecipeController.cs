using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeYourFridge.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _repo;
        private readonly IMapper _mapper;
        private readonly int _numberOfResipes=10;

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
            var model = await _repo.GetRecipeById(id);
            if (model == null)
                return NotFound();

            var recipesForDetailedDto = _mapper.Map<RecipeForDetailDto>(model);
            return Ok(recipesForDetailedDto);
        }
    }
}