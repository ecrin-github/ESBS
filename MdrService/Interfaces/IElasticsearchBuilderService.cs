using System.Collections.Generic;
using MdrService.Contracts.Responses.v1.ApiResponse.ObjectListResponse;
using MdrService.Contracts.Responses.v1.ApiResponse.StudyListResponse;
using MdrService.Models.Elasticsearch.Study;
using MdrService.Models.Elasticsearch.Object;


namespace MdrService.Interfaces
{
    public interface IElasticsearchBuilderService
    {
        ObjectListResponse BuildElasticsearchObjectResponse(DataObject dataObject);
        IEnumerable<ObjectListResponse> BuildElasticsearchObjectListResponse(IEnumerable<DataObject> dataObjects);

        StudyListResponse BuildElasticsearchStudyResponse(Study study);
        ICollection<StudyListResponse> BuildElasticsearchStudyListResponse(ICollection<Study> studies);
    }
}