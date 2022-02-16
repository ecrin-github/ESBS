namespace AuditService.Interfaces;

public interface IUserIdentityService
{
    Task<string> GetUserIdentity(string accessToken);
}