using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreeYourFridge.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class WidgetController : ControllerBase
    {
        private readonly IWidgetRepository _repo;

        public WidgetController(IWidgetRepository repo)
        {
            _repo = repo;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetIndegrientsWidget(int id)
        {
            string model = await _repo.GetIndegrientsWidget(id);
            if (model == null)
                return NotFound();

            return Ok(model);
        }
    }
}