using AuditService.Interfaces;

namespace AuditService.Services;

public class UserIdentityService : IUserIdentityService
{
    public Task<string> GetUserIdentity(string accessToken)
    {
        throw new NotImplementedException();
    }
}