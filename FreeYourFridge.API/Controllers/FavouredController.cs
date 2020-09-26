using System;
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
    [Route("api/[controller]")]
    //[ApiController]

    public class FavouredController : Controller
    {
        private readonly IFavouredRepository _repo;
        private readonly IMapper _mapper;

        //private readonly DataContext _context;

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
                await _repo.AddFavoured(favoured);
                return StatusCode(201);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetFavoureds()
        {
            IEnumerable<Favoured> favoureds = await _repo.GetFavoureds();
            return Ok(favoureds);
        }
       
    }
}