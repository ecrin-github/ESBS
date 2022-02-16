using AuditService.Contracts.Request.v1;
using AuditService.Contracts.Response.v1;
using AuditService.Interfaces;

namespace AuditService.Repositories;

public class MdrAuditRepository : IMdrAuditRepository
{
    public Task<AuditResponseDto> CreateMdrAuditRecordChange(AuditRequestDto auditRequestDto)
    {
        throw new NotImplementedException();
    }
}