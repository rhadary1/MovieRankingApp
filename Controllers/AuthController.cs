using Microsoft.AspNetCore.Mvc;
using RankingApp.Database;
using RankingApp.Dto;
using RankingApp.Model;

namespace RankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository repository) 
        { 
            _userRepository = repository;   
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            _userRepository.Create(user); 
            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Register(LoginDto dto)
        {
            var user = _userRepository.GetUserByEmail(dto.Email);
            
            if (user == null)
            {
                return BadRequest("Invalid Credentials");
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest("Invalid Credentials");
            }

            return Ok(user);
        }
    }
}
