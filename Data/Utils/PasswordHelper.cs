using System.Security.Cryptography;
using System.Text;

namespace Data.Utils;

public static class PasswordHelper
{
    private const int keySize = 64;
    private const int iterations = 350000;
    private static readonly HashAlgorithmName algorithmName = HashAlgorithmName.SHA512;

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