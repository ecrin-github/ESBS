using System.Collections.Generic;
using System.Threading.Tasks;
using MdrService.Contracts.Responses.v1.ObjectListResponse;
using MdrService.Contracts.Responses.v1.SearchServiceResponse;
using MdrService.Contracts.Responses.v1.StudyListResponse;
using MdrService.Models.Object;
using MdrService.Models.Study;

namespace MdrService.Interfaces
{
    public interface IBuilderService
    {
        Task<StudyListResponse> BuildSingleStudyResponse(Study study);
        Task<ICollection<StudyListResponse>> BuildStudyResponse(ICollection<Study> studies);

        Task<ObjectListResponse> BuildSingleObjectResponse(DataObject dataObject);
        Task<ICollection<ObjectListResponse>> BuildObjectResponse(ICollection<DataObject> dataObjects);
        
        Task<SearchStudyListResponse> BuildSingleSearchStudyResponse(Study study);
        Task<ICollection<SearchStudyListResponse>> BuildSearchStudyResponse(ICollection<Study> studies);

        Task<SearchDataObjectListResponse> BuildSingleSearchObjectResponse(DataObject dataObject);
        Task<ICollection<SearchDataObjectListResponse>> BuildSearchObjectResponse(ICollection<DataObject> dataObjects);

    }
}