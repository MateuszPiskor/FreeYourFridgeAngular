using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    [ApiController]
    public class FavouredController : Controller
    {
        private readonly IFavouredRepository _repo;
        private readonly IMapper _mapper;

        public FavouredController(IFavouredRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddFavaoured([FromBody] FavouredDto favaouredDto)
        {
            if (favaouredDto != null)
            {
                Favoured favoured = _mapper.Map<Favoured>(favaouredDto);
                var userId = User.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
                favoured.CreatedBy = int.Parse(userId);
                _repo.Add<Favoured>(favoured);
                var saveResult = _repo.SaveAll();
                return StatusCode(201);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetFavoureds()
        {
            IEnumerable<Favoured> favoureds = await _repo.GetFavoureds();
            var favouredsFiltered = favoureds.Where(f =>
                f.CreatedBy == int.Parse(User.FindFirst(claim =>
                   claim.Type == ClaimTypes.NameIdentifier).Value));
            return Ok(favouredsFiltered);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoured(int id)
        {
            if (id != 0)
            {
                var userId = int.Parse(User.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
                _repo.Delete(id, userId);
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditFavoured(int id, [FromBody] int score)
        {
            var userId = int.Parse(User.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            _repo.UpdateFavaoured(id, score, userId);
            return NoContent();
        }
    }
}