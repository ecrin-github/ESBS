using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RmsService.Configs;
using RmsService.Helpers;
using RmsService.Interfaces;
using RmsService.Models.DbConnection;
using RmsService.Repositories;


namespace RmsService.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<RmsDbConnection>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("RmsDbConnectionString"));
            });

            services.AddScoped<IDtpRepository, DtpRepository>();
            services.AddScoped<IDupRepository, DupRepository>();
            
            services.AddScoped<IDataMapper, DataMapper>();

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = IdentityConfigs.OidcUrl;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = false
                    };
                });
            
            return services;
        }
    }
}