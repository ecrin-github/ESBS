using System.Threading.Tasks;
using MdrService.Contracts.Requests.v1;
using MdrService.Contracts.Responses.v1;
using MdrService.Contracts.Responses.v1.StudyListResponse;
using MdrService.Contracts.Routes.ApiRoutes.v1;
using MdrService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MdrService.Controllers.Elasticsearch.v1
{
    [ApiController]
    [Authorize]
    public class QueryController : ControllerBase
    {
        
        private readonly IQueryRepository _queryRepository;
        public QueryController(IQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        [HttpPost(ApiRoutes.Query.GetSpecificStudy)]
        public async Task<ActionResult<SearchResponse>> GetSpecificStudy(SpecificStudyRequest specificStudyRequest)
        {
            var response = await _queryRepository.GetSpecificStudy(specificStudyRequest);
            return Ok(new SearchResponse()
            {
                Total = response.Total,
                Page = specificStudyRequest.Page,
                Size = specificStudyRequest.Size,
                Data = response.Data
            });
        }
        
        [HttpPost(ApiRoutes.Query.GetByStudyCharacteristics)]
        public async Task<ActionResult<SearchResponse>> GetByStudyCharacteristics(StudyCharacteristicsRequest studyCharacteristicsRequest)
        {
            var response = await _queryRepository.GetByStudyCharacteristics(studyCharacteristicsRequest);
            return Ok(new SearchResponse()
            {
                Total = response.Total,
                Page = studyCharacteristicsRequest.Page,
                Size = studyCharacteristicsRequest.Size,
                Data = response.Data
            });
        }
        
        [HttpPost(ApiRoutes.Query.GetViaPublishedPaper)]
        public async Task<ActionResult<SearchResponse>> GetViaPublishedPaper(ViaPublishedPaperRequest viaPublishedPaperRequest)
        {
            var response = await _queryRepository.GetViaPublishedPaper(viaPublishedPaperRequest);
            return Ok(new SearchResponse()
            {
                Total = response.Total,
                Page = viaPublishedPaperRequest.Page,
                Size = viaPublishedPaperRequest.Size,
                Data = response.Data
            });

        }
        
        [HttpPost(ApiRoutes.Query.GetByStudyId)]
        public async Task<ActionResult<StudyListResponse>> GetByStudyId(StudyIdRequest studyIdRequest)
        {
            var response = await _queryRepository.GetByStudyId(studyIdRequest);
            return Ok(response);
        }
    }
}