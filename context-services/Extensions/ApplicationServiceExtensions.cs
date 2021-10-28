using context_services.GraphQL;
using context_services.Interfaces;
using context_services.Models.DbConnection;
using context_services.Repositories;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using LinqToDB.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace context_services.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddLinqToDbContext<ContextDbConnection>((provider, options) =>
            {
                options
                    .UsePostgreSQL(config.GetConnectionString("ContextDbConnectionString"))
                    .UseDefaultLogging(provider);
            });
            
            services.AddLinqToDbContext<RmsDbConnection>((provider, options) =>
            {
                options
                    .UsePostgreSQL(config.GetConnectionString("RmsDbConnectionString"))
                    .UseDefaultLogging(provider);
            });

            services.AddScoped<ICtxRepository, CtxRepository>();
            services.AddScoped<ILupRepository, LupRepository>();
            services.AddScoped<IRmsContextRepository, RmsContextRepository>();
            
            services.AddGraphQLServer()
                .AddQueryType<Queries>()
                .AddMutationType<Mutations>()
                .AddFiltering()
                .AddSorting();

            return services;
        }
    }
}