using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreeYourFridge.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserController(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            var userToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(userToReturn);
        }
        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _repo.GetUser(id);
            var userDetail = await _repo.GetUserDetail(id);
            var model = _mapper.Map<UserForListDto>(user);
            _mapper.Map(userDetail, model);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserDetails(int id, UserForUpdateDto userforUpdateDto)
        {
            if(id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)) 
                return Unauthorized();

            var userFromRepo = await _repo.GetUserDetail(id);
            _mapper.Map(userforUpdateDto, userFromRepo);

            if(await _repo.SaveAll())
                return NoContent();
                
            throw new Exception($"Updating user with {id} failed on save");  
        }
    }
}