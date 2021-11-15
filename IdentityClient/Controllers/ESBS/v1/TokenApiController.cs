using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityClient.Configs;
using IdentityClient.Contracts.Responses;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IdentityClient.Controllers.ESBS.v1
{
    public class TokenApiController : BaseApiController
    {
        [HttpGet("token")]
        [SwaggerOperation(Tags = new []{"The ESBS Identity endpoints"})]
        public async Task<IActionResult> GetAccessToken(string username, string password)
        {
            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync(EsbsIdentityConfigs.EsbsIdentityServerUrl);
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
                ClientId = EsbsIdentityConfigs.EsbsClientId,
                ClientSecret = EsbsIdentityConfigs.EsbsClientSecret,
                UserName = username,
                Password = password,
                Scope = EsbsIdentityConfigs.EsbsScope
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