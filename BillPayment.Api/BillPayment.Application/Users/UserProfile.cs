using AutoMapper;
using BillPayment.Application.Users.Commands;
using BillPayment.Domain.Entities;

namespace BillPayment.Application.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserUpdateCommand>();
            CreateMap<UserUpdateCommand, User>();
        }
    }
}
