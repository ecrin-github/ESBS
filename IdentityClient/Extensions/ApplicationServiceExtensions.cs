using IdentityClient.Configs;
using IdentityClient.Interfaces;
using IdentityClient.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace IdentityClient.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            
            services.AddScoped<IElixirRepository, ElixirRepository>();
            services.AddScoped<IEsbsRepository, EsbsRepository>();
            
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = ElixirIdentityConfigs.OidcUrl;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ClientIdPolicy", policy => policy.RequireClaim("client_id", "mdmClient", "the_rms_client"));
            });

            return services;
        }
    }
}