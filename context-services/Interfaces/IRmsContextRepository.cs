using System.Collections.Generic;
using System.Threading.Tasks;
using context_services.Models.Rms;

namespace context_services.Interfaces
{
    public interface IRmsContextRepository
    {
        Task<ICollection<AccessPrereqType>> GetAccessPrereqTypes();
        Task<AccessPrereqType> GetAccessPrereqType(int id);
        
        Task<ICollection<CheckStatusType>> GetCheckStatusTypes();
        Task<CheckStatusType> GetCheckStatusType(int id);
        
        Task<ICollection<DtpStatusType>> GetDtpStatusTypes();
        Task<DtpStatusType> GetDtpStatusType(int id);
        
        Task<ICollection<DupStatusType>> GetDupStatusTypes();
        Task<DupStatusType> GetDupStatusType(int id);
        
        Task<ICollection<LegalStatusType>> GetLegalStatusTypes();
        Task<LegalStatusType> GetLegalStatusType(int id);
        
        Task<ICollection<RepoAccessType>> GetRepoAccessTypes();
        Task<RepoAccessType> GetRepoAccessType(int id);
    }
}