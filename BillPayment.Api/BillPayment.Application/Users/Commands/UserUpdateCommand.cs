using MediatR;

namespace BillPayment.Application.Users.Commands
{
    public record UserUpdateCommand
    (
        int Id,
        string Name,
        string UserName,
        int UserRoleId
    ) : IRequest<int>;
}
