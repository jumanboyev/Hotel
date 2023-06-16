using System;

namespace Hotel.Security;

public class PasswordHasher
{
    public static (string PasswordHash, string Salt) Hash(string Password)
    {
        string salt = GenerateSalt();
        var hash = BCrypt.Net.BCrypt.HashPassword(Password+salt);
        return (PasswordHash:hash,Salt: salt);
    }
    public static string GenerateSalt()
    {
        return Guid.NewGuid().ToString();
    }
}
