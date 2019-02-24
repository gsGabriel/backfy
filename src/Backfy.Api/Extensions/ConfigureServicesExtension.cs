using Backfy.Albums.Query.Handler;
using Backfy.Albums.Repository;
using Backfy.Albums.Repository.Interfaces;
using Backfy.Api.Configs;
using Backfy.Common.Infra.Services;
using Backfy.Common.Infra.Services.Interfaces;
using Backfy.Sales.Command.Handler;
using Backfy.Sales.Query.Handler;
using Backfy.Sales.Repository;
using Backfy.Sales.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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
        /// <returns>The service of application</returns>
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAlbumQueryHandler).Assembly);
            services.AddMediatR(typeof(GetSaleQueryHandler).Assembly);
            services.AddMediatR(typeof(AddSaleCommandHandler).Assembly);

            services.AddTransient<ISpotifyService>(x =>
            {
                //Code for get a settings provider
                var spotify = x.GetService<IOptions<SpotifySettings>>().Value;
                return new SpotifyService(spotify.ClientId, spotify.ClientSecret);
            });

            services.AddSingleton<IGenreRepository, GenreRepository>();
            services.AddSingleton<ISaleRepository, SaleRepository>();

            return services;
        }
    }
}
