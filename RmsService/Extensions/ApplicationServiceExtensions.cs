using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RmsService.GraphQL;
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
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.ApiName = "rmsService";
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