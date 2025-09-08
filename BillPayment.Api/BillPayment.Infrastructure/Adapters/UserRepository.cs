using BillPayment.Domain.Entities;
using BillPayment.Domain.Ports;
using BillPayment.Infrastructure.Ports;

namespace BillPayment.Infrastructure.Adapters;

public sealed class UserRepository(IGenericRepository<User> userRepository) : IUsersRepository
{
    public async Task<int> AddUserAsync(User user)
    {
        await userRepository.AddAsync(user);
        await userRepository.Save();
        return user.Id;
    }

    public void UpdateUser(User user) => userRepository.Update(user);

    public async Task DeleteUserAsync(int userId)
    {
        var entity = await userRepository.GetByIdAsync(userId);
        await userRepository.DeleteAsync(entity);
        await userRepository.Save();
    }
}
