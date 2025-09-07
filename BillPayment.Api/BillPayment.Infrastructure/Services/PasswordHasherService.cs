using System.Security.Cryptography;
using BillPayment.Domain.Ports;

namespace BillPayment.Infrastructure.Services;

public class PasswordHasherService : IPasswordHasherService
{
    // Use PBKDF2 with HMACSHA256
    // Format: {iterations}.{saltBase64}.{hashBase64}
    private const int Iterations = 100_000; // reasonable default
    private const int SaltSize = 16; // 128-bit salt
    private const int KeySize = 32; // 256-bit key

    public string Hash(string password)
    {
        if (password == null) throw new ArgumentNullException(nameof(password));

        using var rng = RandomNumberGenerator.Create();
        var salt = new byte[SaltSize];
        rng.GetBytes(salt);

        using var deriveBytes = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
        var key = deriveBytes.GetBytes(KeySize);

        var saltB64 = Convert.ToBase64String(salt);
        var keyB64 = Convert.ToBase64String(key);

        return $"{Iterations}.{saltB64}.{keyB64}";
    }

    public bool Verify(string hashedPassword, string providedPassword)
    {
        if (hashedPassword == null) throw new ArgumentNullException(nameof(hashedPassword));
        if (providedPassword == null) throw new ArgumentNullException(nameof(providedPassword));

        var parts = hashedPassword.Split('.', 3);
        if (parts.Length != 3) return false;

        if (!int.TryParse(parts[0], out var iterations)) return false;
        var salt = Convert.FromBase64String(parts[1]);
        var key = Convert.FromBase64String(parts[2]);

        using var deriveBytes = new Rfc2898DeriveBytes(providedPassword, salt, iterations, HashAlgorithmName.SHA256);
        var testKey = deriveBytes.GetBytes(key.Length);

        return CryptographicOperations.FixedTimeEquals(key, testKey);
    }
}
