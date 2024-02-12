using API.Model;

namespace API.Services
{
    public interface IAuthenticationService
    {
        Task<TokenJWT> LoginAsync(LoginDto loginDto);
    }
}
