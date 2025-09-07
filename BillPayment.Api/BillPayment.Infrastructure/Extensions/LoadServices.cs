using Microsoft.Extensions.DependencyInjection;
using BillPayment.Infrastructure.Adapters;
using BillPayment.Infrastructure.Ports;
using BillPayment.Domain.Ports;
using BillPayment.Infrastructure.Services;

namespace BillPayment.Infrastructure.Extensions;

public static class LoadServices
{
   public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IUsersRepository, UserRepository>();
        services.AddTransient<IPasswordHasherService, PasswordHasherService>();

        return services;
    }

}
