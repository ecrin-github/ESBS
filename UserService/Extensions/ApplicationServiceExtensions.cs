using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace UserService.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            return services;
        }
    }
}