// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using IdentityServer4;

namespace IdentityServerHost.Quickstart.UI
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "5 rue Watt",
                    locality = "Paris",
                    postal_code = 75013,
                    country = "France"
                };
                
                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "818727",
                        Username = "user",
                        Password = "user",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "John Doe"),
                            new Claim(JwtClaimTypes.GivenName, "John"),
                            new Claim(JwtClaimTypes.FamilyName, "Doe"),
                            new Claim(JwtClaimTypes.Email, "john.doe@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://website.com"),
                            new Claim(JwtClaimTypes.Role, "user"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "88421113",
                        Username = "admin",
                        Password = "admin",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Sergei Gorianin"),
                            new Claim(JwtClaimTypes.GivenName, "Sergei"),
                            new Claim(JwtClaimTypes.FamilyName, "Gorianin"),
                            new Claim(JwtClaimTypes.Email, "sergei.gorianin@ecrin.org"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://ecrin.org"),
                            new Claim(JwtClaimTypes.Role, "admin"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    }
                };
            }
        }
    }
}