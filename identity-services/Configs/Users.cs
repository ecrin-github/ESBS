using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Test;

namespace identity_service.Configs
{
    public class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser> 
            {
                new TestUser 
                {
                    SubjectId = "56892347",
                    Username = "admin",
                    Password = "admin",
                    Claims = new List<Claim> 
                    {
                        new Claim(JwtClaimTypes.Email, "frequenteen@gmail.com"),
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim(JwtClaimTypes.WebSite, "https://ecrin.org")
                    }
                }
            };
        }
    }
}