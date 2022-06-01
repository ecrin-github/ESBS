using AuditService.Contracts.Response.v1;
using AuditService.Models.Audit.MDR;
using AuditService.Models.Audit.RMS;

namespace AuditService.Interfaces;

public interface IDataMapper
{
    AuditResponseDto[] MapRmsAuditRecords(ICollection<RmsRecordChange> rmsRecordChanges);
    AuditResponseDto[] MapMdrAuditRecords(ICollection<MdrRecordChange> mdrRecordChanges);
    AuditResponseDto BuildRmsAuditResponse(RmsRecordChange rmsRecordChange);
    AuditResponseDto BuildMdrAuditResponse(MdrRecordChange mdrRecordChange);
}