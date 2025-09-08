using System.Security.Cryptography;
using BillPayment.Domain.Ports;

namespace BillPayment.Infrastructure.Services;

public sealed class PasswordHasherService : IPasswordHasherService
{
    private const int Iterations = 100_000;
    private const int SaltSize = 16;
    private const int KeySize = 32;

    public string Hash(string password)
    {
        ArgumentNullException.ThrowIfNull(password);

        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var key = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256).GetBytes(KeySize);

        return $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(key)}";
    }

    public bool Verify(string hashedPassword, string providedPassword)
    {
        ArgumentNullException.ThrowIfNull(hashedPassword);
        ArgumentNullException.ThrowIfNull(providedPassword);

        var parts = hashedPassword.Split('.', 3);
        if (parts.Length != 3) return false;
        if (!int.TryParse(parts[0], out var iterations)) return false;
        var salt = Convert.FromBase64String(parts[1]);
        var key = Convert.FromBase64String(parts[2]);

        var testKey = new Rfc2898DeriveBytes(providedPassword, salt, iterations, HashAlgorithmName.SHA256).GetBytes(key.Length);
        return CryptographicOperations.FixedTimeEquals(key, testKey);
    }
}
