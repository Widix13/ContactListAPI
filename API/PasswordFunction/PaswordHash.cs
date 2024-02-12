
namespace API.PasswordFunction
{
    public class PaswordHash
    {
        public static bool VerifyPassword(string LoginPassword, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, LoginPassword);
        }
        public static string HashPassword(string Password)
        {
            return BCrypt.Net.BCrypt.HashPassword(Password);
        }
    }
}
