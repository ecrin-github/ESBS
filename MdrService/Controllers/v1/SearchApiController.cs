using System.Collections.Generic;
using System.Threading.Tasks;
using MdrService.Contracts.Requests.v1;
using MdrService.Contracts.Responses.v1;
using MdrService.Contracts.Responses.v1.StudyListResponse;
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
            IBuilderService builderService
            )
        {
            _searchService = searchService;
            _studyRepository = studyRepository;
            _builderService = builderService;
        }
        
        [HttpPost(ApiRoutes.Query.GetSpecificStudy)]
        [SwaggerOperation(Tags = new[] { "Search specific study" })]
        public async Task<IActionResult> GetSpecificStudy(SpecificStudyRequest specificStudyRequest)
        {
            var ids = await _searchService.GetSpecificStudy(specificStudyRequest);
            if (ids.Count <= 0) return NotFound(new ApiResponse<StudyListResponse>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No records have been found."},
                Data = new List<StudyListResponse>()
            });

            var studies = await _studyRepository.GetStudies(ids);
            
            if (studies.Count <= 0) return NotFound(new ApiResponse<StudyListResponse>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No records have been found."},
                Data = new List<StudyListResponse>()
            });

            var outputResult = await _builderService.BuildStudyResponse(studies);
            return Ok(new ApiResponse<StudyListResponse>()
            {
                Total = outputResult.Count,
                Data = outputResult,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Size = specificStudyRequest.Size,
                Page = specificStudyRequest.Page
            });
        }
        
        [HttpPost(ApiRoutes.Query.GetByStudyCharacteristics)]
        [SwaggerOperation(Tags = new[] { "Search by study characteristics" })]
        public async Task<IActionResult> GetByStudyCharacteristics(StudyCharacteristicsRequest studyCharacteristicsRequest)
        {
            var ids = await _searchService.GetByStudyCharacteristics(studyCharacteristicsRequest);
            if (ids.Count <= 0) return NotFound(new ApiResponse<StudyListResponse>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No records have been found."},
                Data = new List<StudyListResponse>()
            });

            var studies = await _studyRepository.GetStudies(ids);
            
            if (studies.Count <= 0) return NotFound(new ApiResponse<StudyListResponse>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No records have been found."},
                Data = new List<StudyListResponse>()
            });

            var outputResult = await _builderService.BuildStudyResponse(studies);
            return Ok(new ApiResponse<StudyListResponse>()
            {
                Total = outputResult.Count,
                Data = outputResult,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Size = studyCharacteristicsRequest.Size,
                Page = studyCharacteristicsRequest.Page
            });            
        }
        
        [HttpPost(ApiRoutes.Query.GetViaPublishedPaper)]
        [SwaggerOperation(Tags = new[] { "Search via published paper" })]
        public async Task<IActionResult> GetViaPublishedPaper(ViaPublishedPaperRequest viaPublishedPaperRequest)
        {
            var ids = await _searchService.GetViaPublishedPaper(viaPublishedPaperRequest);
            if (ids.Count <= 0) return NotFound(new ApiResponse<StudyListResponse>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No records have been found."},
                Data = new List<StudyListResponse>()
            });

            var studies = await _studyRepository.GetStudies(ids);
            
            if (studies.Count <= 0) return NotFound(new ApiResponse<StudyListResponse>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No records have been found."},
                Data = new List<StudyListResponse>()
            });

            var outputResult = await _builderService.BuildStudyResponse(studies);
            return Ok(new ApiResponse<StudyListResponse>()
            {
                Total = outputResult.Count,
                Data = outputResult,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Size = viaPublishedPaperRequest.Size,
                Page = viaPublishedPaperRequest.Page
            });
        }
        
        [HttpPost(ApiRoutes.Query.GetByStudyId)]
        [SwaggerOperation(Tags = new[] { "Search by study ID" })]
        public async Task<IActionResult> GetByStudyId(StudyIdRequest studyIdRequest)
        {
            var studyId = await _searchService.GetByStudyId(studyIdRequest);
            if (studyId == null)
                return NotFound(new ApiResponse<StudyListResponse>()
                {
                    Total = 0,
                    Messages = new List<string>(){"Study hasn't been found."},
                    StatusCode = NotFound().StatusCode,
                    Data = new List<StudyListResponse>()
                });
            var study = await _studyRepository.GetStudyById(studyId);
            if (study == null) return NotFound(new ApiResponse<StudyListResponse>()
            {
                Total = 0,
                Messages = new List<string>(){"Study hasn't been found."},
                StatusCode = NotFound().StatusCode,
                Data = new List<StudyListResponse>()
            });

            var outputRes = await _builderService.BuildSingleStudyResponse(study);
            return Ok(new ApiResponse<StudyListResponse>()
            {
                Total = 1,
                Data = new List<StudyListResponse>(){outputRes},
                StatusCode = Ok().StatusCode,
                Messages = null,
            });
        }
    }
}