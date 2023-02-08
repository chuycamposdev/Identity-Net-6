using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tickets.Application.Behaviors;
using Tickets.Application.Facades;
using Tickets.Domain.Settings;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace Tickets.Application
{
    public static class ServiceExtension
    {
        

        public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<EmailFacade>();
            services.Configure<AccountSetting>(opt => configuration.GetSection("Account").Bind(opt));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
