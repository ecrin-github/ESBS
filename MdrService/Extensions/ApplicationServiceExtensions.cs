using MdrService.Helpers;
using MdrService.Interfaces;
using MdrService.Repositories;
using MdrService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MdrService.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IElasticSearchService, ElasticSearchService>();

            services.AddScoped<IDataMapper, DataMapper>();
            
            services.AddScoped<IQueryRepository, QueryRepository>();
            services.AddScoped<IRawQueryRepository, RawQueryRepository>();
            services.AddScoped<IFetchedDataRepository, FetchedDataRepository>();
            
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.ApiName = "mdrService";
                    options.Authority = "https://localhost:7001";
                });

            return services;
        }
    }
}