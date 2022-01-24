namespace MdmService.Interfaces
{
    public interface IUserIdentityService
    {
        string GetUserData(string accessToken);
    }
}