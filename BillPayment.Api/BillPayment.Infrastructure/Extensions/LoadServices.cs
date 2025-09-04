using Azure.Core;
using Microsoft.Extensions.DependencyInjection;
using BillPayment.Infrastructure.Adapters;
using BillPayment.Infrastructure.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPayment.Infrastructure.Extensions;

public static class LoadServices
{
   public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
  

        return services;
    }

}
