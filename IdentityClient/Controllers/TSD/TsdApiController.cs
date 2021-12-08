using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IdentityClient.Configs;
using IdentityClient.Contracts.Requests;
using IdentityClient.Contracts.Responses;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace IdentityClient.Controllers.TSD
{
    public class TsdApiController : BaseTsdController
    {
        // POST https://github.uio.no/elixir/sso  --data={"elixir_token": ... , "elixir_info": {"name": ..., "email": ... }, "dataset_id": ... }
        private const string TsdPostUrl = "https://github.uio.no/elixir/sso";
        private const string DatasetId = "RMS1000001";

        [HttpPost("post-data")]
        [SwaggerOperation(Tags = new[] { "The TSD related endpoints" })]
        public async Task<IActionResult> PostDatToTsd(string accessToken)
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
            
            var userInfo = response.Json;
            
            var tsdPostObject = new TsdPostDataRequest()
            {
                ElixirToken = accessToken,
                ElixirInfo = new ElixirInfo()
                {
                    Name = userInfo.GetProperty("name").GetString(),
                    Email = userInfo.GetProperty("email").GetString()
                },
                DatasetId = DatasetId
            };
            
            var json = JsonConvert.SerializeObject(tsdPostObject);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PostAsync(TsdPostUrl, data);

            return Ok(res);
        }
    }
}