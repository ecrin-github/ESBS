using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RmsService.Contracts.Requests.Filtering;
using RmsService.Contracts.Responses;
using RmsService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using RmsService.DTO;

namespace RmsService.Controllers.v1.Filtering
{
    public class FilteringApiController : BaseApiController
    {
        private readonly IDtpRepository _dtpRepository;
        private readonly IDupRepository _dupRepository;

        public FilteringApiController(
            IDtpRepository dtpRepository,
            IDupRepository dupRepository)
        {
            _dtpRepository = dtpRepository ?? throw new ArgumentNullException(nameof(dtpRepository));
            _dupRepository = dupRepository ?? throw new ArgumentNullException(nameof(dupRepository));
        }

        
        [HttpPost("pagination/dtp")]
        [SwaggerOperation(Tags = new []{"Pagination"})]
        public async Task<IActionResult> PaginateStudies(PaginationRequest paginationRequest)
        {
            var data = await _dtpRepository.PaginateDtp(paginationRequest);
            if (data.Total == 0) return Ok(new ApiResponse<DtpDto>
            {
                Total = 0,
                Data = null,
                Page = paginationRequest.Page,
                Size = paginationRequest.Size,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() {"No DTPs have been found."}
            });
            return Ok(new ApiResponse<DtpDto>
            {
                Total = data.Total,
                Data = data.Data,
                Page = paginationRequest.Page,
                Size = paginationRequest.Size,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }

        [HttpPost("pagination/dup")]
        [SwaggerOperation(Tags = new []{"Pagination"})]
        public async Task<IActionResult> PaginateObjects(PaginationRequest paginationRequest)
        {
            var data = await _dupRepository.PaginateDup(paginationRequest);
            if (data.Total == 0) return Ok(new ApiResponse<DupDto>
            {
                Total = 0,
                Data = null,
                Page = paginationRequest.Page,
                Size = paginationRequest.Size,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() {"No DUPs have been found."}
            });
            return Ok(new ApiResponse<DupDto>
            {
                Total = data.Total,
                Data = data.Data,
                Page = paginationRequest.Page,
                Size = paginationRequest.Size,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }

        [HttpPost("filter/dtp/by-title")]
        [SwaggerOperation(Tags = new []{"Filtering - by title"})]
        public async Task<IActionResult> FilterDtpByTitle(FilteringByTitleRequest filteringByTitleRequest)
        {
            var data = await _dtpRepository.FilterDtpByTitle(filteringByTitleRequest);
            if (data.Total == 0) return Ok(new ApiResponse<DtpDto>
            {
                Total = 0,
                Data = null,
                Page = filteringByTitleRequest.Page,
                Size = filteringByTitleRequest.Size,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() {"No DTPs have been found."}
            });
            return Ok(new ApiResponse<DtpDto>
            {
                Total = data.Total,
                Data = data.Data,
                Page = filteringByTitleRequest.Page,
                Size = filteringByTitleRequest.Size,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpPost("filter/dup/by-title")]
        [SwaggerOperation(Tags = new []{"Filtering - by title"})]
        public async Task<IActionResult> FilterDupByTitle(FilteringByTitleRequest filteringByTitleRequest)
        {
            var data = await _dupRepository.FilterDupByTitle(filteringByTitleRequest);
            if (data.Total == 0) return Ok(new ApiResponse<DupDto>
            {
                Total = 0,
                Data = null,
                Page = filteringByTitleRequest.Page,
                Size = filteringByTitleRequest.Size,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() {"No DUPs have been found."}
            });
            return Ok(new ApiResponse<DupDto>
            {
                Total = data.Total,
                Data = data.Data,
                Page = filteringByTitleRequest.Page,
                Size = filteringByTitleRequest.Size,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
    }
}