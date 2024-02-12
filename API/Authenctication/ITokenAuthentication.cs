using API.Model;

namespace API.Authenctication
{
    public interface ITokenAuthentication
    {
        public string CreateToken(Contact contact);
    }
}
