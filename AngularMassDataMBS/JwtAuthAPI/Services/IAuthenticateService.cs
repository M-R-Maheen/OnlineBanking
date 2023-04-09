using JwtAuthAPI.Models;

namespace JwtAuthAPI.Services
{
    public interface IAuthenticateService
    {
        User Authenticate(string username, string password);
    }
}
