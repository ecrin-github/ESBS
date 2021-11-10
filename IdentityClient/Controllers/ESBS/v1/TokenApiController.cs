using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityClient.Contracts.Responses;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IdentityClient.Controllers.ESBS.v1
{
    public class TokenApiController : BaseApiController
    {
        [HttpGet("token")]
        [SwaggerOperation(Tags = new []{"The ESBS Token endpoints"})]
        public async Task<IActionResult> UserLogin(string username, string password)
        {
            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:7001");
            if (disco.IsError)
            {
                return Ok(new ApiResponse<DiscoveryDocumentResponse>
                {
                    Total = 0,
                    Messages = new List<string>{disco.Error},
                    StatusCode = 403,
                    Data = null
                });
            }

            var tokenClient = await client.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = disco.TokenEndpoint,
                ClientId = "the_rms_client",
                ClientSecret = "r6DBdwHD7OsnUq39p7u0ECw877YSfC7A",
                UserName = username,
                Password = password,
                Scope = "openid profile email address mdmAPI rmsAPI userAPI roles"
            });

            if (tokenClient.IsError) return Ok(new ApiResponse<TokenResponse>
            {
                Total = 0,
                Messages = new List<string>{tokenClient.Error},
                StatusCode = 403,
                Data = null
            });
            return Ok(new ApiResponse<TokenResponse>
            {
                Total = 1,
                StatusCode = 200,
                Messages = null,
                Data = new List<TokenResponse>{tokenClient}
            });
        }
    }
}