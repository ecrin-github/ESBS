using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using IdentityClient.Configs;
using IdentityClient.Contracts.Requests;
using IdentityClient.Contracts.Responses;
using IdentityModel.Client;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IdentityClient.Controllers.Elixir.v1
{
    public class TokenElixirApiController : BaseElixirApiController
    {
        [HttpGet("callback")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> CallbackEndpoint()
        {
            var code = HttpContext.Request.Query["code"].ToString();
            if (string.IsNullOrEmpty(code)) return Ok("No code received.");

            var client = new HttpClient();
            
            var response = await client.RequestAuthorizationCodeTokenAsync(new AuthorizationCodeTokenRequest
            {
                Address = ElixirIdentityConfigs.TokenUrl,
                ClientId = ElixirIdentityConfigs.ClientId,
                GrantType = GrantType.AuthorizationCode,
                Code = code,
                RedirectUri = ElixirIdentityConfigs.RedirectUrlToIdentityCallbackApiGateway,
            });

            if (response.IsError) return Ok(response);
            return Ok(new ApiResponse<JsonElement>()
            {
                StatusCode = 200,
                Messages = null,
                Total = 1,
                Data = new List<JsonElement>(){response.Json}
            });
        }
        
        
        [HttpGet("generate-access-code-url")]
        [SwaggerOperation(Tags = new []{"The Elixir AAI endpoints"})]
        public IActionResult GenerateAuthUrl()
        {
            var ru = new RequestUrl(ElixirIdentityConfigs.AuthorizeUrl);

            var url = ru.CreateAuthorizeUrl(
                clientId: ElixirIdentityConfigs.ClientId,
                responseType: ElixirIdentityConfigs.Code,
                redirectUri: ElixirIdentityConfigs.RedirectUrlToIdentityCallbackApiGateway,
                scope: ElixirIdentityConfigs.Scope);
            
            return Ok(new ApiResponse<AuthStringResponse>
            {
                Total = 1,
                Messages = null,
                StatusCode = 200,
                Data = new List<AuthStringResponse>(){new AuthStringResponse()
                {
                    AuthString = url
                }}
            });
        }
        
        [HttpPost("refresh-token")]
        [SwaggerOperation(Tags = new []{"The Elixir AAI endpoints"})]
        public async Task<IActionResult> GetRefreshToken([FromBody] RefreshTokenBodyRequest refreshTokenBodyRequest)
        {
            var client = new HttpClient();
            
            var response = await client.RequestRefreshTokenAsync(new RefreshTokenRequest
            {
                Address = ElixirIdentityConfigs.TokenUrl,
                ClientId = ElixirIdentityConfigs.ClientId,
                RefreshToken = refreshTokenBodyRequest.RefreshToken,
                GrantType = "refresh_token"
            });
            
            if (response.IsError) return Ok(response);
            
            return Ok(new ApiResponse<JsonElement>()
            {
                StatusCode = 200,
                Messages = null,
                Total = 1,
                Data = new List<JsonElement>(){response.Json}
            });
        }
    }
}