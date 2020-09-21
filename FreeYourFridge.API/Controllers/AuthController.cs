using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FreeYourFridge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
<<<<<<< HEAD
        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
=======
        private readonly IUserRepository _user;
        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper, IUserRepository user)
>>>>>>> Merge/feature-user-with-feature-recpices
        {
            _repo = repo;
            _config = config;
            _mapper = mapper;
<<<<<<< HEAD

=======
            _user = user;
>>>>>>> Merge/feature-user-with-feature-recpices
        }

        [HttpPost("register")]
        [Consumes("application/json")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //validate request
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            if (await _repo.UserExists(userForRegisterDto.Username))
                return BadRequest("Username already exists");

            var userToCreate = _mapper.Map<User>(userForRegisterDto);

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
            var userToReturn = _mapper.Map<UserForListDto>(createdUser);
<<<<<<< HEAD
            return CreatedAtRoute("GetUser", new {Controller= "User", id = createdUser.Id}, userToReturn);
=======
            var newUserDetail = new UserDetails(){
                UserId = createdUser.Id
            };
            _user.Add(newUserDetail);
            await _user.SaveAll();

            return CreatedAtRoute("GetUser", new { Controller = "User", id = createdUser.Id }, userToReturn);
>>>>>>> Merge/feature-user-with-feature-recpices
        }

        [HttpPost("login")]
        [Consumes("application/json")]
        
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);
            if(userFromRepo ==null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new{
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}