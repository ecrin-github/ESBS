using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using IdentityClient.Configs;
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
            if (string.IsNullOrEmpty(code)) return BadRequest();

            var client = new HttpClient();
            
            var response = await client.RequestAuthorizationCodeTokenAsync(new AuthorizationCodeTokenRequest
            {
                Address = ElixirIdentityConfigs.TokenUrl,
                ClientId = ElixirIdentityConfigs.ClientId,
                GrantType = GrantType.AuthorizationCode,
                Code = code,
                RedirectUri = ElixirIdentityConfigs.RedirectUrlToIdentityCallback,
            });

            if (response.IsError) return BadRequest(response);
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
                redirectUri: ElixirIdentityConfigs.RedirectUrlToIdentityCallback,
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
    }
}