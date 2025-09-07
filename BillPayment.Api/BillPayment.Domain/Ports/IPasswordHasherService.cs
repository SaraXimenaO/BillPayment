namespace BillPayment.Domain.Ports
{
    public interface IPasswordHasherService
    {
        string Hash(string password);
        bool Verify(string hashedPassword, string providedPassword);
    }
}
