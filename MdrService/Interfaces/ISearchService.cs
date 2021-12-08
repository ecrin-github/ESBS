using System.Threading.Tasks;
using MdrService.Contracts.Requests.v1.DbSearch;
using MdrService.Contracts.Responses.v1.SearchServiceResponse;

namespace MdrService.Interfaces
{
    public interface ISearchService
    {
        Task<SearchServiceResponse> GetSpecificStudy(SpecificStudyRequest specificStudyRequest);
        Task<SearchServiceResponse> GetByStudyCharacteristics(StudyCharacteristicsRequest studyCharacteristicsRequest);
        Task<SearchServiceResponse> GetViaPublishedPaper(ViaPublishedPaperRequest viaPublishedPaperRequest);
        Task<int?> GetByStudyId(StudyIdRequest studyIdRequest);
    }
}