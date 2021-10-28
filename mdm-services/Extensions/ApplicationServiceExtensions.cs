using mdm_services.GraphQL;
using mdm_services.Interfaces;
using mdm_services.Models.DbConnection;
using mdm_services.Repositories;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using LinqToDB.Configuration;
using mdm_services.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mdm_services.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddLinqToDbContext<MdmDbConnection>((provider, options) =>
            {
                options
                    .UsePostgreSQL(config.GetConnectionString("MdmDbConnectionString"))
                    .UseDefaultLogging(provider);
            });

            services.AddScoped<IStudyRepository, StudyRepository>();
            services.AddScoped<IObjectRepository, ObjectRepository>();

            services.AddScoped<IDataMapper, DataMapper>();
            
            services.AddGraphQLServer()
                .AddQueryType<Queries>()
                .AddMutationType<Mutations>()
                .AddFiltering()
                .AddSorting();

            return services;
        }
    }
}