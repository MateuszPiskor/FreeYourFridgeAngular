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
        public async Task<IActionResult> AddFavaoured([FromBody] FavouredForCreationDto favaouredForCreationDto)
        {
                Favoured favoured = _mapper.Map<Favoured>(favaouredForCreationDto);
                var userId = User.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
                favoured.CreatedBy = int.Parse(userId);
                _repo.Add<Favoured>(favoured);
                var saveResult = _repo.SaveAll();
                return StatusCode(201);
        }

        [HttpGet]
        public async Task<IActionResult> GetFavoureds()
        {
            IEnumerable<Favoured> favoureds = await _repo.GetFavoureds();
            var favouredsFiltered = favoureds.Where(f =>
                f.CreatedBy == int.Parse(User.FindFirst(claim =>
                   claim.Type == ClaimTypes.NameIdentifier).Value));

            return Ok(_mapper.Map<IEnumerable<FavouredDto>>(favouredsFiltered));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoured(int id)
        {
            if (!await _repo.FavouredExist(id))
            {
                return NotFound();
            }
            ;
            var userId = int.Parse(User.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            _repo.DeleteFavoured(id, userId);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditFavoured(int id, [FromBody] int score)
        {
            if (!await _repo.FavouredExist(id))
            {
                return NotFound();
            }
            var userId = int.Parse(User.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            _repo.UpdateFavaoured(id, score, userId);
            return NoContent();
        }
    }
}