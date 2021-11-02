using ContextService.GraphQL;
using ContextService.Interfaces;
using ContextService.Models.DbConnection;
using ContextService.Repositories;
using Microsoft.AspNetCore.Builder;
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
            
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.ApiName = "contextService";
                    options.Authority = "https://localhost:7001";
                });

            services.AddScoped<Queries>();
            services.AddScoped<Mutations>();

            services.AddGraphQLServer()
                .AddQueryType<Queries>()
                .AddMutationType<Mutations>()
                .AddFiltering()
                .AddSorting();

            return services;
        }
    }
}