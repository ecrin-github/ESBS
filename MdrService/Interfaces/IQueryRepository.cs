using System.Collections.Generic;
using System.Threading.Tasks;
using MdrService.Contracts.Requests.v1;
using MdrService.Contracts.Responses.v1;
using MdrService.Contracts.Responses.v1.StudyListResponse;


namespace MdrService.Interfaces
{
    public interface IQueryRepository
    {
        Task<BaseResponse> GetSpecificStudy(SpecificStudyRequest specificStudyRequest);
        Task<BaseResponse> GetByStudyCharacteristics(StudyCharacteristicsRequest studyCharacteristicsRequest);
        Task<BaseResponse> GetViaPublishedPaper(ViaPublishedPaperRequest viaPublishedPaperRequest);
        Task<IEnumerable<StudyListResponse>> GetByStudyId(StudyIdRequest studyIdRequest);
    }
}