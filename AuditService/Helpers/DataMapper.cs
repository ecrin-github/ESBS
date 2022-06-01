using AuditService.Contracts.Response.v1;
using AuditService.Interfaces;
using AuditService.Models.Audit.MDR;
using AuditService.Models.Audit.RMS;

namespace AuditService.Helpers;

public class DataMapper : IDataMapper
{
    public AuditResponseDto[] MapRmsAuditRecords(ICollection<RmsRecordChange> rmsRecordChanges)
    {
        throw new NotImplementedException();
    }

    public AuditResponseDto[] MapMdrAuditRecords(ICollection<MdrRecordChange> mdrRecordChanges)
    {
        throw new NotImplementedException();
    }

    public AuditResponseDto BuildRmsAuditResponse(RmsRecordChange rmsRecordChange)
    {
        throw new NotImplementedException();
    }

    public AuditResponseDto BuildMdrAuditResponse(MdrRecordChange mdrRecordChange)
    {
        throw new NotImplementedException();
    }
}