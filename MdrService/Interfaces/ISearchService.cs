using System.Collections.Generic;
using System.Threading.Tasks;
using MdrService.Contracts.Requests.v1;

namespace MdrService.Interfaces
{
    public interface ISearchService
    {
        Task<ICollection<int>> GetSpecificStudy(SpecificStudyRequest specificStudyRequest);
        Task<ICollection<int>> GetByStudyCharacteristics(StudyCharacteristicsRequest studyCharacteristicsRequest);
        Task<ICollection<int>> GetViaPublishedPaper(ViaPublishedPaperRequest viaPublishedPaperRequest);
        Task<int?> GetByStudyId(StudyIdRequest studyIdRequest);
    }
}