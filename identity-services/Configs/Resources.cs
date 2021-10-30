using System.Collections.Generic;
using IdentityServer4.Models;

namespace identity_service.Configs
{
    public class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "contextServices",
                    DisplayName = "The ESBS Context service provider",
                    Description = "Allow the application to access the ESBS Context service provider on your behalf",
                    Scopes = new List<string> { "contextServices.read"},
                    ApiSecrets = new List<Secret> {new Secret("yhLe8Qwi5uDxh8xJPyn54ZeveI5XXsi2".Sha256())},
                    UserClaims = new List<string> {"role"}
                }
            };
        }
    }
}