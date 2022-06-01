using AuditService.Helpers;
using AuditService.Interfaces;
using AuditService.Models.DbConnection;
using AuditService.Repositories;
using AuditService.Services;
using AuditService.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


namespace AuditService.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AuditDbConnection>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("AuditDbConnectionString"));
            });

            services.AddScoped<IMdrAuditRepository, MdrAuditRepository>();
            services.AddScoped<IRmsAuditRepository, RmsAuditRepository>();

            services.AddScoped<IUserIdentityService, UserIdentityService>();

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

            services.AddAuthorization(options => 
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "AuditService");
                });
            });
            
            return services;
        }
    }
}