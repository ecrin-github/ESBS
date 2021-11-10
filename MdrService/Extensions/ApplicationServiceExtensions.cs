using MdrService.Helpers;
using MdrService.Interfaces;
using MdrService.Repositories;
using MdrService.Services;
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

            return services;
        }
    }
}