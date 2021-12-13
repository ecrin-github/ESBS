using MdrService.Helpers;
using MdrService.Interfaces;
using MdrService.Models.DbConnection;
using MdrService.Repositories;
using MdrService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MdrService.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<MdrDbConnection>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("MdrDbConnectionString"));
            });
            
            services.AddScoped<IContextService, ContextService>();
            
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IRawSqlSearchService, RawSqlSearchService>();
            
            services.AddScoped<IBuilderService, BuilderService>();
            
            services.AddScoped<IElasticsearchService, ElasticsearchService>();
            services.AddScoped<IElasticsearchBuilderService, ElasticsearchBuilderService>();
            
            services.AddScoped<IStudyRepository, StudyRepository>();
            services.AddScoped<IObjectRepository, ObjectRepository>();
            
            services.AddScoped<ILinksRepository, LinksRepository>();
            
            services.AddScoped<IDataMapper, DataMapper>();
            services.AddScoped<IElasticsearchDataMapper, ElasticsearchDataMapper>();

            return services;
        }
    }
}