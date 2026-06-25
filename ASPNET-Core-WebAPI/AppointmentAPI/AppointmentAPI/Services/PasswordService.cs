using System.Security.Cryptography;
using System.Text;

namespace AppointmentAPI.Services;

public class PasswordService : IPasswordService
{
    public string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);

        return Convert.ToBase64String(hash);
    }


    public bool VerifyPassword(string password,string passwordHash)
    {
        var hashedPassword = HashPassword(password);

        return hashedPassword == passwordHash;
    }
}