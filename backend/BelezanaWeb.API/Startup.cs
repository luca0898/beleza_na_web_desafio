using BelezanaWeb.API.Middlewares;
using BelezanaWeb.Middlewares;
using BelezanaWeb.Registers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BelezanaWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddLogging(config =>
            {
                config.ClearProviders();

                config.AddConfiguration(Configuration.GetSection("Logging"));
                config.AddEventSourceLogger();

                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                {
                    config.AddDebug();
                    config.AddConsole();
                }
            });

            LoadRegistrations.ConfigureContainers(services);
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory logger)
        {
            app.UseMiddleware<RequestLoggingMiddleware>();

            app.UseAuthentication();

            app.UseCors((builder) =>
            {
                builder.WithOrigins(Configuration["CorsAllowedHosts"].Split(','));
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowCredentials();
                builder.SetPreflightMaxAge(TimeSpan.FromSeconds(2520));
            });

            app.ConfigureExceptionHandler(logger);

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", context =>
                {
                    context.Response.StatusCode = 200;
                    return Task.CompletedTask;
                });

                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.OAuthClientId(Configuration["authenticationSettings:KeycloakSettings:ClientId"]);
                c.OAuthClientSecret(Configuration["authenticationSettings:KeycloakSettings:ClientSecret"]);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BelezanaWeb API V1");
            });
        }
    }
}
