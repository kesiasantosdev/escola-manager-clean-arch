using EscolaManager.Application.Services;

namespace EscolaManager.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool Verify(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}