using ContextService.Interfaces;
using ContextService.Models.DbConnection;
using ContextService.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContextService.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ContextDbConnection>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("ContextDbConnectionString"));
            });
            
            services.AddDbContext<RmsDbConnection>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("RmsDbConnectionString"));
            });

            services.AddScoped<ICtxRepository, CtxRepository>();
            services.AddScoped<ILupRepository, LupRepository>();
            services.AddScoped<IRmsContextRepository, RmsContextRepository>();

            return services;
        }
    }
}