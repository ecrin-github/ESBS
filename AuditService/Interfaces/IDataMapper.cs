using AuditService.Contracts.Response.v1;
using AuditService.Models.Audit.MDR;
using AuditService.Models.Audit.RMS;

namespace AuditService.Interfaces;

public interface IDataMapper
{
    ICollection<AuditResponseDto> MapRmsAuditRecords(ICollection<RmsRecordChange> rmsRecordChanges);
    ICollection<AuditResponseDto> MapMdrAuditRecords(ICollection<MdrRecordChange> mdrRecordChanges);
    AuditResponseDto BuildRmsAuditResponse(RmsRecordChange rmsRecordChange);
    AuditResponseDto BuildMdrAuditResponse(MdrRecordChange mdrRecordChange);
}