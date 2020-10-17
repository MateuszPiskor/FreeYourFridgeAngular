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
using FreeYourFridge.API.Helpers;
using Newtonsoft.Json;

namespace FreeYourFridge.API.Controllers
{
    [Authorize]
    [Route("api/favoured")]
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

        [HttpGet]
        public async Task<IActionResult> GetFavoureds([FromQuery] UserParams userParams)
        {
            PagedList<Favoured> favoureds = await _repo.GetFavoureds(userParams);

            var paginationMetadata = new
            {
                totalCount = favoureds.TotalCount,
                pageSize = favoureds.PageSize,
                currentPage = favoureds.CurrentPage,
                totalPages = favoureds.TotalPages
            };

            HttpContext.Response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationMetadata));
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
            return Ok(favoureds);
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

        [HttpPost]
        public async Task<IActionResult> AddFavaoured([FromBody] FavouredForCreationDto favaouredForCreationDto)
        {
            Favoured favoured = _mapper.Map<Favoured>(favaouredForCreationDto);
            var userId = User.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            favoured.CreatedBy = int.Parse(userId);
            _repo.Add<Favoured>(favoured);
            var saveResult = _repo.SaveAll();

            var favouredToReturn = _mapper.Map<FavouredDto>(favoured);

            return CreatedAtRoute("GetFavoured", new { id = favouredToReturn.SpoonacularId }, favouredToReturn);
        }
    }
}