using API.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace API.Authenctication
{
    public class TokenAuthentication : ITokenAuthentication
    {
        private readonly IConfiguration _configuration;

        public TokenAuthentication(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string CreateToken(Contact contact)
        {
            List<Claim> claims = new List<Claim>() {
            new Claim(ClaimTypes.Name, contact.Name),
            new Claim(ClaimTypes.Email, contact.Email),
            new Claim(ClaimTypes.Surname, contact.Surname)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
