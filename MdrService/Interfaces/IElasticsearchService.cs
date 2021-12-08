using System.Collections.Generic;
using System.Threading.Tasks;
using MdrService.Contracts.Requests.v1.Elasticsearch;
using MdrService.Models.Elasticsearch.Study;

namespace MdrService.Interfaces
{
    public interface IElasticsearchService
    {
        Task<ICollection<Study>> GetSpecificStudy(SpecificStudyRequest specificStudyRequest);
        Task<ICollection<Study>> GetByStudyCharacteristics(StudyCharacteristicsRequest studyCharacteristicsRequest);
        Task<ICollection<Study>> GetViaPublishedPaper(ViaPublishedPaperRequest viaPublishedPaperRequest);
        Task<IEnumerable<Study>> GetByStudyId(StudyIdRequest studyIdRequest);
    }
}