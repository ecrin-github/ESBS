using System.Collections.Generic;
using System.Threading.Tasks;
using mdr_services.Contracts.Requests.v1;
using mdr_services.Contracts.Responses.v1;
using mdr_services.Contracts.Responses.v1.StudyListResponse;


namespace mdr_services.Interfaces
{
    public interface IQueryRepository
    {
        Task<BaseResponse> GetSpecificStudy(SpecificStudyRequest specificStudyRequest);
        Task<BaseResponse> GetByStudyCharacteristics(StudyCharacteristicsRequest studyCharacteristicsRequest);
        Task<BaseResponse> GetViaPublishedPaper(ViaPublishedPaperRequest viaPublishedPaperRequest);
        Task<IEnumerable<StudyListResponse>> GetByStudyId(StudyIdRequest studyIdRequest);
    }
}