using MediatR;

namespace BillPayment.Application.Users.Commands;

public record UserCreateCommand(
    string Name,
    string Document,
    string UserName,
    string PasswordHash,
    int UserRoleId
    ) : IRequest<int>;