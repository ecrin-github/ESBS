using System.Threading.Tasks;
using MdrService.Contracts.Requests.v1.DbSearch;
using MdrService.Contracts.Responses.v1.SearchResponse;

namespace MdrService.Interfaces
{
    public interface IRawSqlSearchService
    {
        Task<SearchServiceResponse> GetSpecificStudy(SpecificStudyDbRequest specificStudyRequest);
        Task<SearchServiceResponse> GetByStudyCharacteristics(StudyCharacteristicsDbRequest studyCharacteristicsRequest);
        Task<SearchServiceResponse> GetViaPublishedPaper(ViaPublishedPaperDbRequest viaPublishedPaperRequest);
    }
}