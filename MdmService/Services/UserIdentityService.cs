using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using MdmService.Configs;
using MdmService.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MdmService.Services
{
    public class UserIdentityService : IUserIdentityService
    {
        public async Task<string> GetUserData(string accessToken)
        {
            var client = new HttpClient();
            
            var response = await client.GetUserInfoAsync(new UserInfoRequest
            {
                Address = ElixirIdentityConfigs.UserInfoUrl,
                Token = accessToken
            });
            if (response.IsError) return null;
            
            return response.Json.GetProperty("email").ToString();
        }
    }
}