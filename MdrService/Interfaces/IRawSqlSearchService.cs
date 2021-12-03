using System.Threading.Tasks;
using MdrService.Contracts.Requests.v1;
using MdrService.Contracts.Responses.v1.SearchServiceResponse;

namespace MdrService.Interfaces
{
    public interface IRawSqlSearchService
    {
        Task<RawSqlSearchServiceResponse> GetSpecificStudy(SpecificStudyRequest specificStudyRequest);
        Task<RawSqlSearchServiceResponse> GetByStudyCharacteristics(StudyCharacteristicsRequest studyCharacteristicsRequest);
        Task<RawSqlSearchServiceResponse> GetViaPublishedPaper(ViaPublishedPaperRequest viaPublishedPaperRequest);
    }
}