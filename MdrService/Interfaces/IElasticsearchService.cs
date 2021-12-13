using System.Threading.Tasks;
using MdrService.Contracts.Requests.v1.Elasticsearch;
using MdrService.Contracts.Responses.v1.SearchResponse;

namespace MdrService.Interfaces
{
    public interface IElasticsearchService
    {
        Task<ElasticsearchServiceResponse> GetSpecificStudy(SpecificStudyEsRequest specificStudyRequest);
        Task<ElasticsearchServiceResponse> GetByStudyCharacteristics(StudyCharacteristicsEsRequest studyCharacteristicsRequest);
        Task<ElasticsearchServiceResponse> GetViaPublishedPaper(ViaPublishedPaperEsRequest viaPublishedPaperRequest);
        Task<ElasticsearchServiceResponse> GetByStudyId(StudyIdEsRequest studyIdRequest);
    }
}