using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DAW_Restanta.Services;
using DAW_Restanta.Models;

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

    [Authorize(Roles = "Admin")]
    [HttpPost("createAdmin")]
    public async Task<ActionResult<User>> CreateAdmin(User user)
    {
        user.Role = "Admin"; // Setează rolul ca "Admin"
        var newUser = await _authService.Register(user);
        return CreatedAtAction(nameof(Register), newUser);
    }
}
