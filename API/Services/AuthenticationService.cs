using API.Authenctication;
using API.Model;
using API.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IContactRepository _contactRepository;
        private readonly ITokenAuthentication _tokenAuthentication;

        public AuthenticationService(IContactRepository contactRepository, ITokenAuthentication tokenAuthentication)
        {
            this._contactRepository = contactRepository;
            this._tokenAuthentication = tokenAuthentication;
        }
        public async Task<TokenJWT> LoginAsync(LoginDto loginDto)
        {
            Contact contact = (await _contactRepository.GetByQuery(x => x.Email == loginDto.Email));

            if (contact != null && BCrypt.Net.BCrypt.Verify(loginDto.Password, contact.Password))
            {
                return new TokenJWT { Token = _tokenAuthentication.CreateToken(contact) };
            }
            else
            {
                throw new Exception("Invalid email or password");
            }
        }


    }
}
