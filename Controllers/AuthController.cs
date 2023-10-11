using Microsoft.AspNetCore.Mvc;
using RankingApp.Database;
using RankingApp.Dto;
using RankingApp.Helpers;
using RankingApp.Model;

namespace RankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepository repository, JwtService jwtService) 
        { 
            _userRepository = repository;   
            _jwtService = jwtService;
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
        public IActionResult Login(LoginDto dto)
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

            var jwtToken = _jwtService.Generate(user.Id); 

            Response.Cookies.Append("jwt", jwtToken, new CookieOptions { HttpOnly = true });

            return Ok(new { message = "success" });    
        }

        [HttpGet("user")]
        public IActionResult GetUser()
        {
            try
            {
                var jwtToken = Request.Cookies["jwt"];
                var validatedToken = _jwtService.Verify(jwtToken);
                var userId = int.Parse(validatedToken.Issuer);
                var user = _userRepository.GetUserById(userId);

                return (user == null)
                    ? Unauthorized()
                    : Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized(); 
            }
        }
    }
}
