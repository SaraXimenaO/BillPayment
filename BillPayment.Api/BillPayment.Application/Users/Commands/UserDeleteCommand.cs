using MediatR;

namespace BillPayment.Application.Users.Commands;

public record UserDeleteCommand(int Id): IRequest;

