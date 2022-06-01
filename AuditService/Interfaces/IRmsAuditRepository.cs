using AuditService.Contracts.Request.v1;
using AuditService.Contracts.Response.v1;

namespace AuditService.Interfaces;

public interface IRmsAuditRepository
{
    Task<AuditResponseDto> CreateRmsAuditRecordChange(AuditRequestDto auditRequestDto);
    Task<AuditResponseDto[]?> GetRmsTableAuditHistory(string tableName);
    Task<AuditResponseDto[]?> GetUserRmsAuditHistory(string accessToken);
}