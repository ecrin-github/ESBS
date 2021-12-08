using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityClient.Configs;
using IdentityClient.Contracts.Responses;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IdentityClient.Controllers.ESBS.v1
{
    public class UserApiController : BaseApiController
    {
        [HttpGet("user/login")]
        [SwaggerOperation(Tags = new []{"The ESBS Identity endpoints"})]
        public async Task<IActionResult> UserLogin(string accessToken)
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

            var response = await client.GetUserInfoAsync(new UserInfoRequest
            {
                Address = disco.UserInfoEndpoint,
                Token = accessToken
            });
            if (response.IsError) return Ok(new ApiResponse<UserInfoResponse>
            {
                Total = 0,
                Messages = new List<string>{response.Error},
                StatusCode = 403,
                Data = null
            });
            return Ok(new ApiResponse<Claim>
            {
                Total = response.Claims.Count(),
                StatusCode = 200,
                Messages = null,
                Data = response.Claims
            });
        }
    }
}