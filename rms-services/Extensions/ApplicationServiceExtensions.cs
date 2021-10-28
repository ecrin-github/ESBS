using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using LinqToDB.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using rms_services.GraphQL;
using rms_services.Helpers;
using rms_services.Interfaces;
using rms_services.Models.DbConnection;
using rms_services.Repositories;


namespace rms_services.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddLinqToDbContext<RmsDbConnection>((provider, options) =>
            {
                options
                    .UsePostgreSQL(config.GetConnectionString("RmsDbConnectionString"))
                    .UseDefaultLogging(provider);
            });
            
            services.AddScoped<IDtpRepository, DtpRepository>();
            services.AddScoped<IDupRepository, DupRepository>();
            
            services.AddScoped<IDataMapper, DataMapper>();

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