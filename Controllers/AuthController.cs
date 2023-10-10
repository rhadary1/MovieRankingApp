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
        public IActionResult Register(UserDto dto)
        {
            var user = Model.User.FromDto(dto);
            _userRepository.Create(user); 
            return Ok(user);
        }

        [HttpGet("hello")]
        public IActionResult Hello(User user)
        {
            return Ok("success");
        }
    }
}
