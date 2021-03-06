﻿using Backfy.Albums.Query;
using Backfy.Api.Configs;
using Backfy.Api.Extensions;
using Backfy.Api.Filters;
using Backfy.Api.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Reflection;

namespace Backfy.Api
{
    /// <summary>
    /// Represents the startup process for the application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The current configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the current configuration.
        /// </summary>
        /// <value>The current application configuration.</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures services for the application.
        /// </summary>
        /// <param name="services">The collection of services to configure the application with.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => 
            {
                options.EnableEndpointRouting = true;
                options.Filters.Add(new ExceptionFilter());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddApiVersioning(
                options =>
                {
                    options.ReportApiVersions = true;
                });
            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    //Add support for a uuid params
                    options.MapType<Guid>(() => new Schema { Type = "string", Format = "uuid" });

                    options.OperationFilter<SwaggerDefaultValues>();

                    options.IncludeXmlComments(GetXmlCommentPath(Assembly.GetExecutingAssembly().GetName().Name));
                    options.IncludeXmlComments(GetXmlCommentPath(typeof(GetAlbumQuery).GetTypeInfo().Assembly.GetName().Name));
                    options.IncludeXmlComments(GetXmlCommentPath(typeof(GetAlbumQuery).GetTypeInfo().Assembly.GetName().Name));
                });

            services.Configure<SpotifySettings>(Configuration.GetSection("Spotify"));

            services.AddMediatR();
        }

        /// <summary>
        /// Configures the application using the provided builder, hosting environment, and API version description provider.
        /// </summary>
        /// <param name="app">The current application builder.</param>
        /// <param name="env">The current hosting environment.</param>
        /// <param name="provider">The API version descriptor provider used to enumerate defined API versions.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    // build a swagger endpoint for each discovered API version
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
        }


        /// <summary>
        /// Helper to get a xml comment path
        /// </summary>
        /// <param name="assemblyName">Name of assembly</param>
        /// <returns>The path of xml comment</returns>
        private static string GetXmlCommentPath(string assemblyName) => Path.Combine(AppContext.BaseDirectory, assemblyName + ".xml");
    }
}
