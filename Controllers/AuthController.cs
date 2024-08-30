using Microsoft.AspNetCore.Mvc;
namespace DAW_Restanta.Models;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(User user)
    {
        var newUser = await _authService.Register(user);
        return CreatedAtAction(nameof(Register), newUser);
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(LoginDto loginDto)
    {
        var result = await _authService.Login(loginDto);
        if (result == null)
            return Unauthorized();

        return Ok(result);
    }
}
