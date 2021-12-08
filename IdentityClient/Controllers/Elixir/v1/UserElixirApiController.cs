using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using IdentityClient.Configs;
using IdentityClient.Contracts.Responses;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IdentityClient.Controllers.Elixir.v1
{
    public class UserElixirApiController : BaseElixirApiController
    {
        [HttpGet("user-info")]
        [SwaggerOperation(Tags = new []{"The Elixir AAI endpoints"})]
        public async Task<IActionResult> UserInfo(string accessToken)
        {
            var client = new HttpClient();
            
            var response = await client.GetUserInfoAsync(new UserInfoRequest
            {
                Address = ElixirIdentityConfigs.UserInfoUrl,
                Token = accessToken
            });
            if (response.IsError) return Ok(new ApiResponse<UserInfoResponse>
            {
                Total = 0,
                Messages = new List<string>{response.Error},
                StatusCode = 403,
                Data = null
            });
            return Ok(new ApiResponse<JsonElement>()
            {
                Messages = null,
                Total = 1,
                StatusCode = 200,
                Data = new List<JsonElement>(){response.Json}
            });
        }
    }
    
    
}