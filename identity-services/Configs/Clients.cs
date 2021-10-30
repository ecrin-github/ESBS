using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace identity_service.Configs
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "contextServices",
                    ClientName = "The ESBS Context service provider",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {new Secret("yhLe8Qwi5uDxh8xJPyn54ZeveI5XXsi2".Sha256())},
                    AllowedScopes = new List<string> {"contextServices.read"}
                },
                new Client
                {
                    ClientId = "userServices",
                    ClientName = "The ESBS User service provider",
                    ClientSecrets = new List<Secret> {new Secret("KyDpNTYyZGwuoLw82HFyhD94Gc1tSJEW".Sha256())},
    
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string> {"https://localhost:5041/"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "userServices.read"
                    },

                    RequirePkce = true,
                    AllowPlainTextPkce = false
                }
            };
        }
    }
}