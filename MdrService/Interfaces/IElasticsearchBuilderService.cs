using System.Collections.Generic;
using MdrService.Contracts.Responses.v1.ApiResponse.StudyListResponse;
using MdrService.Models.Elasticsearch.Study;

namespace MdrService.Interfaces
{
    public interface IElasticsearchBuilderService
    {
        ICollection<StudyListResponse> BuildElasticsearchStudyListResponse(ICollection<Study> studies);
    }
}