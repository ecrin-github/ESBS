using AuditService.Contracts.Request.v1;
using AuditService.Contracts.Response.v1;

namespace AuditService.Interfaces;

public interface IMdrAuditRepository
{
    Task<AuditResponseDto> CreateMdrAuditRecordChange(AuditRequestDto auditRequestDto);
    Task<AuditResponseDto[]?> GetMdrTableAuditHistory(string tableName);
    Task<AuditResponseDto[]?> GetUserMdrAuditHistory(string accessToken);
}