using System.Threading.Tasks;

namespace MdmService.Interfaces
{
    public interface IUserIdentityService
    {
        Task<string> GetUserData(string accessToken);
    }
}