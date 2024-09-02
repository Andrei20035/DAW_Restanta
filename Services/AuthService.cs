using DAW_Restanta.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public class AuthService
{
    private readonly ApplicationDbContext _context;

    public AuthService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> Register(User user)
    {
        user.CreatedAt = DateTime.UtcNow;
        if (string.IsNullOrEmpty(user.Role))
        {
            user.Role = "User"; // Setează rolul implicit ca "User"
        }
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }


    public async Task<string> Login(LoginDto loginDto)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == loginDto.Username && u.PasswordHash == loginDto.Password);
        if (user == null)
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes("YourSecretKey1234567890!@#$%^&*()_+123456");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<User> CreateAdmin(User user)
    {
        user.CreatedAt = DateTime.UtcNow;
        user.Role = "Admin"; // Setează rolul ca "Admin"
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}
