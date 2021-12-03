using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MdrService.Contracts.Requests.v1;
using MdrService.Contracts.Responses.v1;
using MdrService.Contracts.Responses.v1.SearchServiceResponse;
using MdrService.Contracts.Responses.v1.StudyListResponse;
using MdrService.Contracts.Routes.ApiRoutes.v1;
using MdrService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MdrService.Controllers.v1
{
    public class RawSqlSearchApiController : BaseApiController
    {
        private readonly IRawSqlSearchService _searchService;
        private readonly IStudyRepository _studyRepository;
        private readonly IBuilderService _builderService;
        
        public RawSqlSearchApiController(
            IRawSqlSearchService searchService,
            IStudyRepository studyRepository,
            IBuilderService builderService)
        {
            _searchService = searchService ?? throw new ArgumentNullException(nameof(searchService));
            _studyRepository = studyRepository ?? throw new ArgumentNullException(nameof(studyRepository));
            _builderService = builderService ?? throw new ArgumentNullException(nameof(builderService));
        }
        
        [HttpPost(ApiRoutes.RawSqlQuery.GetSpecificStudy)]
        [SwaggerOperation(Tags = new[] { "Raw SQL - Search specific study" })]
        public async Task<IActionResult> GetSpecificStudy(SpecificStudyRequest specificStudyRequest)
        {
            var ids = await _searchService.GetSpecificStudy(specificStudyRequest);
            if (ids.StudyIds.Count <= 0) return Ok(new RawSqlSearchApiResponse<StudyListResponse>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No records have been found."},
                Data = new List<StudyListResponse>()
            });

            var studies = await _studyRepository.GetStudies(ids.StudyIds);
            if (studies.Count <= 0) return Ok(new RawSqlSearchApiResponse<StudyListResponse>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No records have been found."},
                Data = new List<StudyListResponse>()
            });

            var outputResult = await _builderService.BuildSearchStudyResponse(studies);
            return Ok(new RawSqlSearchApiResponse<SearchStudyListResponse>()
            {
                Total = ids.Total,
                Data = outputResult,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Size = specificStudyRequest.Size,
                Page = specificStudyRequest.Page
            });
        }
        
        [HttpPost(ApiRoutes.RawSqlQuery.GetByStudyCharacteristics)]
        [SwaggerOperation(Tags = new[] { "Raw SQL - Search by study characteristics" })]
        public async Task<IActionResult> GetByStudyCharacteristics(StudyCharacteristicsRequest studyCharacteristicsRequest)
        {
            var ids = await _searchService.GetByStudyCharacteristics(studyCharacteristicsRequest);
            if (ids.StudyIds.Count <= 0) return Ok(new RawSqlSearchApiResponse<StudyListResponse>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No records have been found."},
                Data = new List<StudyListResponse>()
            });

            var studies = await _studyRepository.GetStudies(ids.StudyIds);
            if (studies.Count <= 0) return Ok(new RawSqlSearchApiResponse<StudyListResponse>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No records have been found."},
                Data = new List<StudyListResponse>()
            });

            var outputResult = await _builderService.BuildSearchStudyResponse(studies);
            return Ok(new RawSqlSearchApiResponse<SearchStudyListResponse>()
            {
                Total = ids.Total,
                Data = outputResult,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Size = studyCharacteristicsRequest.Size,
                Page = studyCharacteristicsRequest.Page
            });
        }
        
        [HttpPost(ApiRoutes.RawSqlQuery.GetViaPublishedPaper)]
        [SwaggerOperation(Tags = new[] { "Raw SQL - Search via published paper" })]
        public async Task<IActionResult> GetViaPublishedPaper(ViaPublishedPaperRequest viaPublishedPaperRequest)
        {
            var ids = await _searchService.GetViaPublishedPaper(viaPublishedPaperRequest);
            if (ids.StudyIds.Count <= 0) return Ok(new RawSqlSearchApiResponse<StudyListResponse>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No records have been found."},
                Data = new List<StudyListResponse>()
            });

            var studies = await _studyRepository.GetStudies(ids.StudyIds);
            if (studies.Count <= 0) return Ok(new RawSqlSearchApiResponse<StudyListResponse>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No records have been found."},
                Data = new List<StudyListResponse>()
            });

            var outputResult = await _builderService.BuildSearchStudyResponse(studies);
            return Ok(new RawSqlSearchApiResponse<SearchStudyListResponse>()
            {
                Total = ids.Total,
                Data = outputResult,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Size = viaPublishedPaperRequest.Size,
                Page = viaPublishedPaperRequest.Page
            });
        }
    }
}