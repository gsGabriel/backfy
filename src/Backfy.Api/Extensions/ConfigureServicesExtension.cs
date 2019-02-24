using Backfy.Albums.Query.Handler;
using Backfy.Albums.Repository;
using Backfy.Albums.Repository.Interfaces;
using Backfy.Common.Infra.Services;
using Backfy.Common.Infra.Services.Interfaces;
using Backfy.Sales.Command.Handler;
using Backfy.Sales.Query.Handler;
using Backfy.Sales.Repository;
using Backfy.Sales.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddMediatR(typeof(GetAlbumQueryHandler).Assembly);
            services.AddMediatR(typeof(GetSaleQueryHandler).Assembly);
            services.AddMediatR(typeof(AddSaleCommandHandler).Assembly);

            services.AddTransient<ISpotifyService>(x => new SpotifyService("c8e8a0d059ee431d943dc5dba1bfbde0", "9972bc2d6c674ab48a3a5a74262b451c"));
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<ISaleRepository, SaleRepository>();

            return services;
        }
    }
}
