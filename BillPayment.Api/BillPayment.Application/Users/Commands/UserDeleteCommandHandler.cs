using BillPayment.Domain.Entities;
using BillPayment.Infrastructure.Adapters;
using BillPayment.Infrastructure.Ports;
using MediatR;

namespace BillPayment.Application.Users.Commands
{
    public class UserDeleteCommandHandler(IGenericRepository<User> userRepository) : IRequestHandler<UserDeleteCommand>
    {
        public async Task<Unit> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            User entity = await userRepository.GetByIdAsync(request.Id);
            await userRepository.DeleteAsync(entity);
            await userRepository.Save(); 

            return Unit.Value;
        }
    }
}
