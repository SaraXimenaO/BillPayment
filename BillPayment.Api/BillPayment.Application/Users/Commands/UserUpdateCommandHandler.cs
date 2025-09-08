using AutoMapper;
using BillPayment.Domain.Entities;
using BillPayment.Infrastructure.Ports;
using MediatR;

namespace BillPayment.Application.Users.Commands
{
    public sealed class UserUpdateCommandHandler(IGenericRepository<User> userRepository, IMapper mapper) : IRequestHandler<UserUpdateCommand, int>
    {
        public async Task<int> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
           User entity = await userRepository.GetByIdAsync(request.Id);
            entity = mapper.Map(request, entity);
            userRepository.Update(entity);
            await userRepository.Save();
            return entity.Id;
        }
    }
}
