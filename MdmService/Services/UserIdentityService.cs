using MdmService.Interfaces;

namespace MdmService.Services
{
    public class UserIdentityService : IUserIdentityService
    {
        public string GetUserData(string accessToken)
        {
            return "frequenteen@gmail.com";
        }
    }
}