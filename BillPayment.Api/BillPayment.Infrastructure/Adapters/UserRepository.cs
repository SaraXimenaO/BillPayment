using BillPayment.Domain.Entities;
using BillPayment.Domain.Ports;
using BillPayment.Infrastructure.Ports;

namespace BillPayment.Infrastructure.Adapters
{
    public class UserRepository : IUsersRepository
    {
        readonly IGenericRepository<User> _userRepository;

        public UserRepository(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            User entity = await _userRepository.GetByIdAsync(userId);
            await _userRepository.DeleteAsync(entity);
        }
    }
}
