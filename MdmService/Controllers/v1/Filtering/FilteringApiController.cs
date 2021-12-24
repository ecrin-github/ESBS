using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MdmService.Contracts.Requests.Filtering;
using MdmService.Contracts.Responses;
using MdmService.DTO.Object;
using MdmService.DTO.Study;
using MdmService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MdmService.Controllers.v1.Filtering
{
    public class FilteringApiController : BaseApiController
    {
        private readonly IObjectRepository _objectRepository;
        private readonly IStudyRepository _studyRepository;

        public FilteringApiController(
            IObjectRepository objectRepository,
            IStudyRepository studyRepository)
        {
            _objectRepository = objectRepository ?? throw new ArgumentNullException(nameof(objectRepository));
            _studyRepository = studyRepository ?? throw new ArgumentNullException(nameof(studyRepository));
        }

        
        [HttpPost("pagination/studies")]
        [SwaggerOperation(Tags = new []{"Pagination"})]
        public async Task<IActionResult> PaginateStudies(PaginationRequest paginationRequest)
        {
            var data = await _studyRepository.PaginateStudies(paginationRequest);
            if (data is {Count: <= 0}) return Ok(new ApiResponse<StudyDto>
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() {"No studies have been found."}
            });
            return Ok(new ApiResponse<StudyDto>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }

        [HttpPost("pagination/data-objects")]
        [SwaggerOperation(Tags = new []{"Pagination"})]
        public async Task<IActionResult> PaginateObjects(PaginationRequest paginationRequest)
        {
            var data = await _objectRepository.PaginateDataObjects(paginationRequest);
            if (data is {Count: <= 0}) return Ok(new ApiResponse<DataObjectDto>
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() {"No data objects have been found."}
            });
            return Ok(new ApiResponse<DataObjectDto>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }

        [HttpPost("filter/studies/by-title")]
        [SwaggerOperation(Tags = new []{"Filtering - by title"})]
        public async Task<IActionResult> FilterStudiesByTitle(FilteringByTitleRequest filteringByTitleRequest)
        {
            var data = await _studyRepository.FilterStudiesByTitle(filteringByTitleRequest);
            if (data is {Count: <= 0}) return Ok(new ApiResponse<StudyDto>
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() {"No studies have been found."}
            });
            return Ok(new ApiResponse<StudyDto>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpPost("filter/data-objects/by-title")]
        [SwaggerOperation(Tags = new []{"Filtering - by title"})]
        public async Task<IActionResult> FilterObjectsByTitle(FilteringByTitleRequest filteringByTitleRequest)
        {
            var data = await _objectRepository.FilterDataObjectsByTitle(filteringByTitleRequest);
            if (data is {Count: <= 0}) return Ok(new ApiResponse<DataObjectDto>
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() {"No data objects have been found."}
            });
            return Ok(new ApiResponse<DataObjectDto>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
    }
}