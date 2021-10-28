using mdr_services.Helpers;
using mdr_services.Interfaces;
using mdr_services.Repositories;
using mdr_services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mdr_services.Extensions
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
            
            return services;
        }
    }
}