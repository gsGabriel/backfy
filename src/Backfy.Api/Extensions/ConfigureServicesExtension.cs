using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backfy.Api.Extensions
{
    /// <summary>
    /// Extension for configurations in configure services of startup
    /// </summary>
    public static class ConfigureServicesExtension
    {
        /// <summary>
        /// Configure assembly for MediatR
        /// </summary>
        /// <param name="services">The collection of services to configure the application with</param>
        /// <returns></returns>
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            //TODO: Referenciar assembly dos handlers
            //services.AddMediatR(typeof(GetTodoQueryHandler).Assembly);

            return services;
        }
    }
}
