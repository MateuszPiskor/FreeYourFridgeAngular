using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FreeYourFridge.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreeYourFridge.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class FridgeController : ControllerBase
    {
        private readonly IFridgeRepository _repo;
        private DataContext _data {get;set;}

        public FridgeController(IFridgeRepository repo, DataContext data)
        {
            _repo = repo;
            _data = data;
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
    }
}