using BillPayment.Domain.Ports;
using BillPayment.Domain.Entities;
using MediatR;

namespace BillPayment.Application.Users.Commands
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, int>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IPasswordHasherService _passwordHasher;

        public UserCreateCommandHandler(IUsersRepository usersRepository, IPasswordHasherService passwordHasher) {
            _usersRepository = usersRepository;
            _passwordHasher = passwordHasher;

        }
        public async Task<int> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var hashedPassword = _passwordHasher.Hash(request.PasswordHash);
            User user = new User(request.Name, request.Document, request.UserName, hashedPassword, request.UserRoleId);
           
            await _usersRepository.AddUserAsync(user);
            return user.Id;

        }
    }
}
