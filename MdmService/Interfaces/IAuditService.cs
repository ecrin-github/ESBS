using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MdmService.DTO.Audit;
using MdmService.Models.Audit;

namespace MdmService.Interfaces
{
    public interface IAuditService
    {
        Task<bool> AddAuditRecord(AuditDto auditDto);
        Task<ICollection<RecordChange>> GetUserAuditHistory(string userName);
        Task<ICollection<RecordChange>> GetTableAuditHistory(string tableName);
    }
}