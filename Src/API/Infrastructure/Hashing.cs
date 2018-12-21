using System;

namespace APISmartCity.Infra
{
    public class Hashing
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string passwordHash, string password)
        {
            return BCrypt.Net.BCrypt.Verify(passwordHash, password);
        }
    }
}