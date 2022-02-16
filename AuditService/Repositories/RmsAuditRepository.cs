using AuditService.Contracts.Request.v1;
using AuditService.Contracts.Response.v1;
using AuditService.Interfaces;

namespace AuditService.Repositories;

public class RmsAuditRepository : IRmsAuditRepository
{
    public Task<AuditResponseDto> CreateRmsAuditRecordChange(AuditRequestDto auditRequestDto)
    {
        throw new NotImplementedException();
    }
}