using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TCP_Chat.Date {
    public class AuthOptions {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "https://localhost:5001"; // потребитель токена
        const string KEY = "mytcp_secretkey!799"; // ключ для шифрации
        public const int LIFETIME = 1; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey () {
            return new SymmetricSecurityKey (Encoding.ASCII.GetBytes (KEY));
        }
    }
}