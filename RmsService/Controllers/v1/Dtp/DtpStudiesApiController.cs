using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RmsService.Contracts.Responses;
using RmsService.DTO;
using RmsService.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace RmsService.Controllers.v1.Dtp
{
    public class DtpStudiesApiController : BaseApiController
    {
        
        private readonly IDtpRepository _dtpRepository;

        public DtpStudiesApiController(IDtpRepository dtpRepository)
        {
            _dtpRepository = dtpRepository ?? throw new ArgumentNullException(nameof(dtpRepository));
        }
        
        
        [HttpGet("data-transfers/{dtpId:int}/studies")]
        [SwaggerOperation(Tags = new []{"Data transfer process studies endpoint"})]
        public async Task<IActionResult> GetDtpStudyList(int dtpId)
        {
            var dtp = await _dtpRepository.GetDtp(dtpId);
            if (dtp == null) return NotFound(new ApiResponse<DtpStudyDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DTP has been found."},
                Data = null
            });
            var dtpStudies = await _dtpRepository.GetAllDtpStudies(dtpId);
            if (dtpStudies == null)
                return NotFound(new ApiResponse<DtpStudyDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No DTP studies have been found." },
                    Data = null
                });
            return Ok(new ApiResponse<DtpStudyDto>()
            {
                Total = dtpStudies.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dtpStudies
            });
        }

        [HttpGet("data-transfers/{dtpId:int}/studies/{id:int}")]
        [SwaggerOperation(Tags = new []{"Data transfer process studies endpoint"})]
        public async Task<IActionResult> GetDtpStudy(int dtpId, int id)
        {
            var dtp = await _dtpRepository.GetDtp(dtpId);
            if (dtp == null) return NotFound(new ApiResponse<DtpStudyDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DTP has been found."},
                Data = null
            });

            var dtpStudy = await _dtpRepository.GetDtpStudy(id);
            if (dtpStudy == null) return NotFound(new ApiResponse<DtpStudyDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DTP study has been found."},
                Data = null
            });
            var dtpStudyList = new List<DtpStudyDto>() { dtpStudy };
            return Ok(new ApiResponse<DtpStudyDto>()
            {
                Total = dtpStudyList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dtpStudyList
            });
        }

        [HttpPost("data-transfers/{dtpId:int}/studies")]
        [SwaggerOperation(Tags = new []{"Data transfer process studies endpoint"})]
        public async Task<IActionResult> CreateDtpStudy(int dtpId, [FromBody] DtpStudyDto dtpStudyDto)
        {
            var dtp = await _dtpRepository.GetDtp(dtpId);
            if (dtp == null) return NotFound(new ApiResponse<DtpStudyDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DTP has been found."},
                Data = null
            });

            var dtpStudy = await _dtpRepository.CreateDtpStudy(dtpId, dtpStudyDto.StudyId, dtpStudyDto);
            if (dtpStudy == null)
                return BadRequest(new ApiResponse<DtpStudyDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during DTP study creation." },
                    Data = null
                });
            var dtpStudyList = new List<DtpStudyDto>() { dtpStudy };
            return Ok(new ApiResponse<DtpStudyDto>()
            {
                Total = dtpStudyList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dtpStudyList
            });
        }

        [HttpPut("data-transfers/{dtpId:int}/studies/{id:int}")]
        [SwaggerOperation(Tags = new []{"Data transfer process studies endpoint"})]
        public async Task<IActionResult> UpdateDtpStudy(int dtpId, int id, [FromBody] DtpStudyDto dtpStudyDto)
        {
            var dtp = await _dtpRepository.GetDtp(dtpId);
            if (dtp == null) return NotFound(new ApiResponse<DtpStudyDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DTP has been found."},
                Data = null
            });
            
            var dtpStudy = await _dtpRepository.GetDtpStudy(id);
            if (dtpStudy == null) return NotFound(new ApiResponse<DtpStudyDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DTP study has been found."},
                Data = null
            });

            var updatedDtpStudy = await _dtpRepository.UpdateDtpStudy(dtpStudyDto);
            if (updatedDtpStudy == null)
                return BadRequest(new ApiResponse<DtpStudyDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during DTP study update." },
                    Data = null
                });
            var dtpStudyList = new List<DtpStudyDto>() { updatedDtpStudy };
            return Ok(new ApiResponse<DtpStudyDto>()
            {
                Total = dtpStudyList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dtpStudyList
            });
        }

        [HttpDelete("data-transfers/{dtpId:int}/studies/{id:int}")]
        [SwaggerOperation(Tags = new []{"Data transfer process studies endpoint"})]
        public async Task<IActionResult> DeleteDtpStudy(int dtpId, int id)
        {
            var dtp = await _dtpRepository.GetDtp(dtpId);
            if (dtp == null) return NotFound(new ApiResponse<DtpStudyDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DTP has been found."},
                Data = null
            });
            
            var dtpStudy = await _dtpRepository.GetDtpStudy(id);
            if (dtpStudy == null) return NotFound(new ApiResponse<DtpStudyDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DTP study has been found."},
                Data = null
            });
            
            var count = await _dtpRepository.DeleteDtpStudy(id);
            return Ok(new ApiResponse<DtpStudyDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>(){"DTP study has been removed."},
                Data = null
            });
        }

        [HttpDelete("data-transfers/{dtpId:int}/studies")]
        [SwaggerOperation(Tags = new []{"Data transfer process studies endpoint"})]
        public async Task<IActionResult> DeleteAllDtpStudies(int dtpId)
        {
            var dtp = await _dtpRepository.GetDtp(dtpId);
            if (dtp == null) return NotFound(new ApiResponse<DtpStudyDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DTP has been found."},
                Data = null
            });
            
            var count = await _dtpRepository.DeleteAllDtpStudies(dtpId);
            return Ok(new ApiResponse<DtpStudyDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>(){"All DTP studies have been found."},
                Data = null
            });
        }
        
    }
}