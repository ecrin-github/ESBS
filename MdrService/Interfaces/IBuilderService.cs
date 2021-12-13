using System.Collections.Generic;
using System.Threading.Tasks;
using MdrService.Contracts.Responses.v1.SearchResponse;
using MdrService.Contracts.Responses.v1.ApiResponse.StudyListResponse;
using MdrService.Models.Study;

namespace MdrService.Interfaces
{
    public interface IBuilderService
    {
        Task<StudyListResponse> BuildSingleStudyResponse(Study study);
        Task<ICollection<StudyListResponse>> BuildStudyResponse(ICollection<Study> studies);
        Task<ICollection<SearchStudyListResponse>> BuildSearchStudyResponse(ICollection<Study> studies);
    }
}