using DAW_Restanta.Models;
using DAW_Restanta.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DAW_Restanta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterDto registerDto)
        {
            var user = new User
            {
                Username = registerDto.Username,
                Name = registerDto.Name,
                Address = registerDto.Address,
                Email = registerDto.Email
            };

            var newUser = await _authService.Register(user, registerDto.Password);
            return CreatedAtAction(nameof(Register), newUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto loginDto)
        {
            var result = await _authService.Login(loginDto.Username, loginDto.Password);
            if (result == null)
                return Unauthorized();

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("createAdmin")]
        public async Task<ActionResult<User>> CreateAdmin(RegisterDto registerDto)
        {
            var user = new User
            {
                Username = registerDto.Username,
                Name = registerDto.Name,
                Address = registerDto.Address,
                Email = registerDto.Email,
                Role = "Admin" 
            };

            var newUser = await _authService.Register(user, registerDto.Password);
            return CreatedAtAction(nameof(Register), newUser);
        }
    }
}
