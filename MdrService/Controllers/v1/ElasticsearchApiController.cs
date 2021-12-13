using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MdrService.Contracts.Requests.v1.Elasticsearch;
using MdrService.Contracts.Responses.v1;
using MdrService.Contracts.Responses.v1.ApiResponse.StudyListResponse;
using MdrService.Contracts.Routes.ApiRoutes.v1;
using MdrService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MdrService.Controllers.v1
{
    public class ElasticsearchApiController : BaseApiController
    {
        private readonly IElasticsearchService _elasticsearchService;
        
        public ElasticsearchApiController(IElasticsearchService elasticsearchService)
        {
            _elasticsearchService = elasticsearchService ?? throw new ArgumentNullException(nameof(elasticsearchService));
        }

        [HttpPost(ApiRoutes.ElasticsearchQuery.GetSpecificStudy)]
        [SwaggerOperation(Tags = new[] { "ES - Search specific study" })]
        public async Task<IActionResult> GetSpecificStudy(SpecificStudyEsRequest specificStudyRequest)
        {
            var data = await _elasticsearchService.GetSpecificStudy(specificStudyRequest);
            return Ok(new BaseResponse<StudyListResponse>()
            {
                Total = data.Total,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>(),
                Page = specificStudyRequest.Page,
                Size = specificStudyRequest.Size,
                Data = data.Studies
            });
        }

        
        [HttpPost(ApiRoutes.ElasticsearchQuery.GetByStudyCharacteristics)]
        [SwaggerOperation(Tags = new[] { "ES - Search by study characteristics" })]
        public async Task<IActionResult> GetByStudyCharacteristics(StudyCharacteristicsEsRequest studyCharacteristicsRequest)
        {
            var data = await _elasticsearchService.GetByStudyCharacteristics(studyCharacteristicsRequest);
            return Ok(new BaseResponse<StudyListResponse>()
            {
                Total = data.Total,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>(),
                Page = studyCharacteristicsRequest.Page,
                Size = studyCharacteristicsRequest.Size,
                Data = data.Studies
            });
        }
        
        
        [HttpPost(ApiRoutes.ElasticsearchQuery.GetViaPublishedPaper)]
        [SwaggerOperation(Tags = new[] { "ES - Search via published paper" })]
        public async Task<IActionResult> GetViaPublishedPaper(ViaPublishedPaperEsRequest viaPublishedPaperRequest)
        {
            var data = await _elasticsearchService.GetViaPublishedPaper(viaPublishedPaperRequest);
            return Ok(new BaseResponse<StudyListResponse>()
            {
                Total = data.Total,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>(),
                Page = viaPublishedPaperRequest.Page,
                Size = viaPublishedPaperRequest.Size,
                Data = data.Studies
            });
        }
        
        
        [HttpPost(ApiRoutes.ElasticsearchQuery.GetByStudyId)]
        [SwaggerOperation(Tags = new[] { "ES - Search by study ID" })]
        public async Task<IActionResult> GetByStudyId(StudyIdEsRequest studyIdRequest)
        {
            var data = await _elasticsearchService.GetByStudyId(studyIdRequest);
            return Ok(new BaseResponse<StudyListResponse>()
            {
                Total = data.Total,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>(),
                Data = data.Studies
            });
        }
    }
}