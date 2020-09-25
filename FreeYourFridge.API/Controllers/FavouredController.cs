using System.Threading.Tasks;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeYourFridge.API.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]

    public class FavouredController : Controller
    {
        private readonly IFavouredRepository _repo;

        //private readonly DataContext _context;

        public FavouredController(IFavouredRepository repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public async Task<IActionResult> AddFavaoured([FromBody] FavouredDto favaouredDto)
        {
            if (favaouredDto != null)
            {
                var favoured = new Favoured()
                {
                    SpoonacularId = favaouredDto.score,
                    Score = favaouredDto.spoonacularId
                };
            await _repo.AddFavoured(favoured);
            }
            return StatusCode(201);
        }
    }
}