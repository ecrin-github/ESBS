using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MdmService.Contracts.Responses;
using MdmService.DTO.Study;
using MdmService.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authentication;

namespace MdmService.Controllers.v1.Study
{
    public class StudyApiController : BaseApiController
    {
        private readonly IStudyRepository _studyRepository;

        public StudyApiController(IStudyRepository studyRepository)
        {
            _studyRepository = studyRepository ?? throw new ArgumentNullException(nameof(studyRepository));
        }
        
        [HttpGet("studies")]
        [SwaggerOperation(Tags = new []{"Study endpoint"})]
        public async Task<IActionResult> GetAllStudies()
        {
            var studies = await _studyRepository.GetAllStudies();
            if (studies == null)
                return Ok(new ApiResponse<StudyDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No studies have been found." },
                    Data = null
                });
            return Ok(new ApiResponse<StudyDto>()
            {
                Total = studies.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studies
            });
        }

        [HttpGet("studies/{sdSid}")]
        [SwaggerOperation(Tags = new []{"Study endpoint"})]
        public async Task<IActionResult> GetStudyById(string sdSid)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return Ok(new ApiResponse<StudyDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyList = new List<StudyDto>() { study };
            return Ok(new ApiResponse<StudyDto>()
            {
                Total = studyList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyList
            });
        }

        [HttpPost("studies")]
        [SwaggerOperation(Tags = new []{"Study endpoint"})]
        public async Task<IActionResult> CreateStudy([FromBody] StudyDto studyDto)
        {
            var accessTokenRes = await HttpContext.GetTokenAsync("access_token");
            var accessToken = accessTokenRes?.ToString();

            var study = await _studyRepository.CreateStudy(studyDto, accessToken);
            if (study == null)
                return Ok(new ApiResponse<StudyDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during study creation." },
                    Data = null
                });

            var studyList = new List<StudyDto>() { study };
            return Ok(new ApiResponse<StudyDto>()
            {
                Total = studyList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyList
            });
        }
        
        [HttpPut("studies/{sdSid}")]
        [SwaggerOperation(Tags = new []{"Study endpoint"})]
        public async Task<IActionResult> UpdateStudy(string sdSid, [FromBody] StudyDto studyDto)
        {
            studyDto.SdSid ??= sdSid;
            
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null)
                return Ok(new ApiResponse<StudyDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No studies have been found." },
                    Data = null
                });

            var accessTokenRes = await HttpContext.GetTokenAsync("access_token");
            var accessToken = accessTokenRes?.ToString();

            var updatedStudy = await _studyRepository.UpdateStudy(studyDto, accessToken);
            if (updatedStudy == null)
                return Ok(new ApiResponse<StudyDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during study update." },
                    Data = null
                });

            var studyList = new List<StudyDto>() { updatedStudy };
            return Ok(new ApiResponse<StudyDto>()
            {
                Total = studyList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyList
            });
        }

        [HttpDelete("studies/{sdSid}")]
        [SwaggerOperation(Tags = new []{"Study endpoint"})]
        public async Task<IActionResult> DeleteStudy(string sdSid)
        {
            var studyDto = await _studyRepository.GetStudyById(sdSid);
            if (studyDto == null) return Ok(new ApiResponse<StudyDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });
            var count = await _studyRepository.DeleteStudy(sdSid);
            return Ok(new ApiResponse<StudyDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "Study has been removed." },
                Data = null
            });
        }
    }
}