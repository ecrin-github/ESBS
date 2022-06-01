using IdentityServer.Configs;

namespace IdentityServer.Extensions;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddIdentityServer()
            .AddInMemoryClients(IdentityConfigs.Clients)
            .AddInMemoryIdentityResources(IdentityConfigs.IdentityResources)
            .AddInMemoryApiResources(IdentityConfigs.ApiResources)
            .AddInMemoryApiScopes(IdentityConfigs.ApiScopes)
            .AddTestUsers(IdentityConfigs.TestUsers)
            .AddDeveloperSigningCredential();
        
        return services;
    }
}