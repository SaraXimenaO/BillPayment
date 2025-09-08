using BillPayment.Domain.Ports;
using BillPayment.Domain.Entities;
using MediatR;

namespace BillPayment.Application.Users.Commands;

public sealed class UserCreateCommandHandler(IUsersRepository usersRepository, IPasswordHasherService passwordHasher)
    : IRequestHandler<UserCreateCommand, int>
{
    public async Task<int> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = passwordHasher.Hash(request.PasswordHash);
        var user = new User(
            request.Name,
            request.Document,
            request.UserName,
            hashedPassword,
            request.UserRoleId
        );

        await usersRepository.AddUserAsync(user);
        return user.Id;
    }
}
