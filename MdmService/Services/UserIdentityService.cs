using System.Threading.Tasks;
using MdmService.Interfaces;

namespace MdmService.Services
{
    public class UserIdentityService : IUserIdentityService
    {
        public async Task<string> GetUserData(string accessToken)
        {
            return "user";
        }
    }
}