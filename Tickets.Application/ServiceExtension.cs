using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tickets.Application.Facades;
using Tickets.Domain.Settings;

namespace Tickets.Application
{
    public static class ServiceExtension
    {
        

        public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<EmailFacade>();
            services.Configure<AccountSetting>(opt => configuration.GetSection("Account").Bind(opt));
            return services;
        }
    }
}
