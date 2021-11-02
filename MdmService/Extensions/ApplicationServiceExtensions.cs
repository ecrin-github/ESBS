using MdmService.GraphQL;
using MdmService.Interfaces;
using MdmService.Models.DbConnection;
using MdmService.Repositories;
using MdmService.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MdmService.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<MdmDbConnection>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("MdmDbConnectionString"));
            });

            services.AddScoped<IStudyRepository, StudyRepository>();
            services.AddScoped<IObjectRepository, ObjectRepository>();

            services.AddScoped<IDataMapper, DataMapper>();
            
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.ApiName = "mdmService";
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