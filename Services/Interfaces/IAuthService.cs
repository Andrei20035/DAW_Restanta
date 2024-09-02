using DAW_Restanta.Models;

namespace DAW_Restanta.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> Register(User user, string password);
        Task<string> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
