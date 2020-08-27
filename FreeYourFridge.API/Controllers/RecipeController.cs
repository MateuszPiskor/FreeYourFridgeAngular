using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreeYourFridge.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _repo;

        public RecipeController(IRecipeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipe()
        {
            var model = await _repo.GetRecipes();
            if (model == null)
                return NotFound();
                
            return Ok(model);
        }
        
    }
}