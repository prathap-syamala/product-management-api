using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ProductApi.Security
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password, salt,
                KeyDerivationPrf.HMACSHA256,
                10000, 32));

            return $"{Convert.ToBase64String(salt)}.{hash}";
        }

        public static bool Verify(string password, string stored)
        {
            var parts = stored.Split('.');
            var salt = Convert.FromBase64String(parts[0]);
            var hash = parts[1];

            var newHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password, salt,
                KeyDerivationPrf.HMACSHA256,
                10000, 32));

            return newHash == hash;
        }
    }
}
