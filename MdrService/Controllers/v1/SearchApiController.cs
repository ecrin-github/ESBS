using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MdrService.Contracts.Requests.v1.DbSearch;
using MdrService.Contracts.Responses.v1;
using MdrService.Contracts.Responses.v1.ApiResponse.StudyListResponse;
using MdrService.Contracts.Routes.ApiRoutes.v1;
using MdrService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MdrService.Controllers.v1
{
    public class SearchApiController : BaseApiController
    {
        private readonly ISearchService _searchService;
        private readonly IStudyRepository _studyRepository;
        private readonly IBuilderService _builderService;
        
        public SearchApiController(
            ISearchService searchService,
            IStudyRepository studyRepository,
            IBuilderService builderService)
        {
            _searchService = searchService ?? throw new ArgumentNullException(nameof(searchService));
            _studyRepository = studyRepository ?? throw new ArgumentNullException(nameof(studyRepository));
            _builderService = builderService ?? throw new ArgumentNullException(nameof(builderService));
        }
        
        [HttpPost(ApiRoutes.Query.GetSpecificStudy)]
        [SwaggerOperation(Tags = new[] { "Search specific study" })]
        public async Task<IActionResult> GetSpecificStudy(SpecificStudyDbRequest specificStudyRequest)
        {
            var ids = await _searchService.GetSpecificStudy(specificStudyRequest);
            if (ids.StudyIds.Count <= 0) return Ok(new BaseResponse<StudyListResponse>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No records have been found."},
                Data = new List<StudyListResponse>()
            });

            var studies = await _studyRepository.GetStudies(ids.StudyIds);
            if (studies.Count <= 0) return Ok(new BaseResponse<StudyListResponse>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No records have been found."},
                Data = new List<StudyListResponse>()
            });

            var outputResult = await _builderService.BuildStudyResponse(studies);
            return Ok(new BaseResponse<StudyListResponse>()
            {
                Total = ids.Total,
                Data = outputResult,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Size = specificStudyRequest.Size,
                Page = specificStudyRequest.Page
            });
        }
        
        [HttpPost(ApiRoutes.Query.GetByStudyCharacteristics)]
        [SwaggerOperation(Tags = new[] { "Search by study characteristics" })]
        public async Task<object> GetByStudyCharacteristics(StudyCharacteristicsDbRequest studyCharacteristicsRequest)
        {
            var ids = await _searchService.GetByStudyCharacteristics(studyCharacteristicsRequest);
            if (ids.StudyIds.Count <= 0) return Ok(new BaseResponse<StudyListResponse>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No records have been found."},
                Data = new List<StudyListResponse>()
            });

            var studies = await _studyRepository.GetStudies(ids.StudyIds);
            if (studies.Count <= 0) return Ok(new BaseResponse<StudyListResponse>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No records have been found."},
                Data = new List<StudyListResponse>()
            });

            var outputResult = await _builderService.BuildStudyResponse(studies);
            return Ok(new BaseResponse<StudyListResponse>()
            {
                Total = ids.Total,
                Data = outputResult,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Size = studyCharacteristicsRequest.Size,
                Page = studyCharacteristicsRequest.Page
            });
        }
        
        [HttpPost(ApiRoutes.Query.GetViaPublishedPaper)]
        [SwaggerOperation(Tags = new[] { "Search via published paper" })]
        public async Task<IActionResult> GetViaPublishedPaper(ViaPublishedPaperDbRequest viaPublishedPaperRequest)
        {
            var ids = await _searchService.GetViaPublishedPaper(viaPublishedPaperRequest);
            if (ids.StudyIds.Count <= 0) return Ok(new BaseResponse<StudyListResponse>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No records have been found."},
                Data = new List<StudyListResponse>()
            });

            var studies = await _studyRepository.GetStudies(ids.StudyIds);
            if (studies.Count <= 0) return Ok(new BaseResponse<StudyListResponse>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No records have been found."},
                Data = new List<StudyListResponse>()
            });

            var outputResult = await _builderService.BuildStudyResponse(studies);
            return Ok(new BaseResponse<StudyListResponse>()
            {
                Total = ids.Total,
                Data = outputResult,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Size = viaPublishedPaperRequest.Size,
                Page = viaPublishedPaperRequest.Page
            });
        }
        
        [HttpPost(ApiRoutes.Query.GetByStudyId)]
        [SwaggerOperation(Tags = new[] { "Search by study ID" })]
        public async Task<IActionResult> GetByStudyId(StudyIdDbRequest studyIdRequest)
        {
            var studyId = await _searchService.GetByStudyId(studyIdRequest);
            if (studyId == null)
                return Ok(new BaseResponse<StudyListResponse>()
                {
                    Total = 0,
                    Messages = new List<string>(){"Study hasn't been found."},
                    StatusCode = NotFound().StatusCode,
                    Data = new List<StudyListResponse>()
                });
            var study = await _studyRepository.GetStudyById(studyId);
            if (study == null) return Ok(new BaseResponse<StudyListResponse>()
            {
                Total = 0,
                Messages = new List<string>(){"Study hasn't been found."},
                StatusCode = NotFound().StatusCode,
                Data = new List<StudyListResponse>()
            });

            var outputRes = await _builderService.BuildSingleStudyResponse(study);
            return Ok(new BaseResponse<StudyListResponse>()
            {
                Total = 1,
                Data = new List<StudyListResponse>(){outputRes},
                StatusCode = Ok().StatusCode,
                Messages = null,
            });
        }
    }
}