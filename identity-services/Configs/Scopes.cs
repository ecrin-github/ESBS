using System.Collections.Generic;
using IdentityServer4.Models;

namespace identity_service.Configs
{
    public class Scopes
    {
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("contextServices.read", "Read Access to the ESBS Context API"),
            };
        }
    }
}