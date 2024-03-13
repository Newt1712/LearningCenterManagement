using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utils
{
    public static class PasswordHelper
    {
        const int keySize = 64;
        const int iterations = 350000;
        private static HashAlgorithmName algorithmName = HashAlgorithmName.SHA512;
        public static string HashPasword(this string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                algorithmName,
                keySize);
            return Convert.ToHexString(hash);
        }

        public static bool VerifyPassword(this string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, algorithmName, keySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }
    }
}
