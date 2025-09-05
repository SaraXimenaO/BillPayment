using BillPayment.Domain.Entities;

namespace BillPayment.Domain.Ports
{
    public interface IUsersRepository
    {
        Task AddUserAsync(User user);
        void UpdateUser(User user);
        Task DeleteUserAsync(int userId);
    }
}
