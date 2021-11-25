using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MdmService.Contracts.Responses;
using MdmService.DTO.Study;
using MdmService.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace MdmService.Controllers.v1.Study
{
    public class StudyTitlesApiController : BaseApiController
    {
        private readonly IStudyRepository _studyRepository;

        public StudyTitlesApiController(IStudyRepository studyRepository)
        {
            _studyRepository = studyRepository ?? throw new ArgumentNullException(nameof(studyRepository));
        }
        
        [HttpGet("studies/{sdSid}/titles")]
        [SwaggerOperation(Tags = new []{"Study titles endpoint"})]
        public async Task<IActionResult> GetStudyTitles(string sdSid)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyTitles = await _studyRepository.GetStudyTitles(sdSid);
            if (studyTitles == null)
                return NotFound(new ApiResponse<StudyTitleDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No study titles have been found." },
                    Data = null
                });
            
            return Ok(new ApiResponse<StudyTitleDto>()
            {
                Total = studyTitles.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyTitles
            });
        }
        
        [HttpGet("studies/{sdSid}/titles/{id:int}")]
        [SwaggerOperation(Tags = new []{"Study titles endpoint"})]
        public async Task<IActionResult> GetStudyTitle(string sdSid, int id)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyTitle = await _studyRepository.GetStudyTitle(id);
            if (studyTitle == null) return NotFound(new ApiResponse<StudyTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No study titles have been found." },
                Data = null
            });

            var studyTitleList = new List<StudyTitleDto>() { studyTitle };
            return Ok(new ApiResponse<StudyTitleDto>()
            {
                Total = studyTitleList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyTitleList
            });
        }

        [HttpPost("studies/{sdSid}/titles")]
        [SwaggerOperation(Tags = new []{"Study titles endpoint"})]
        public async Task<IActionResult> CreateStudyTitle(string sdSid, [FromBody] StudyTitleDto studyTitleDto)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyTitle = await _studyRepository.CreateStudyTitle(sdSid, studyTitleDto);
            if (studyTitle == null) return BadRequest(new ApiResponse<StudyTitleDto>()
            {
                Total = 0,
                StatusCode = BadRequest().StatusCode,
                Messages = new List<string>() { "Error during study title creation." },
                Data = null
            });

            var studyTitleList = new List<StudyTitleDto>() { studyTitle };
            return Ok(new ApiResponse<StudyTitleDto>()
            {
                Total = studyTitleList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyTitleList
            });
        }

        [HttpPut("studies/{sdSid}/titles/{id:int}")]
        [SwaggerOperation(Tags = new []{"Study titles endpoint"})]
        public async Task<IActionResult> UpdateStudyTitle(string sdSid, int id, [FromBody] StudyTitleDto studyTitleDto)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyTitle = await _studyRepository.GetStudyTitle(id);
            if (studyTitle == null) return NotFound(new ApiResponse<StudyTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No study titles have been found." },
                Data = null
            });

            var updatedStudyTitle = await _studyRepository.UpdateStudyTitle(studyTitleDto);
            if (updatedStudyTitle == null)
                return BadRequest(new ApiResponse<StudyTitleDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during study title update." },
                    Data = null
                });

            var studyTitleList = new List<StudyTitleDto>() { updatedStudyTitle };
            return Ok(new ApiResponse<StudyTitleDto>()
            {
                Total = studyTitleList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyTitleList
            });
        }

        [HttpDelete("studies/{sdSid}/titles/{id:int}")]
        [SwaggerOperation(Tags = new []{"Study titles endpoint"})]
        public async Task<IActionResult> DeleteStudyTitle(string sdSid, int id)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyTitle = await _studyRepository.GetStudyTitle(id);
            if (studyTitle == null) return NotFound(new ApiResponse<StudyTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No study titles have been found." },
                Data = null
            });
            
            var count = await _studyRepository.DeleteStudyTitle(id);
            return Ok(new ApiResponse<StudyTitleDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "Study title has been removed." },
                Data = null
            });
        }

        [HttpDelete("studies/{sdSid}/titles")]
        [SwaggerOperation(Tags = new []{"Study titles endpoint"})]
        public async Task<IActionResult> DeleteAllStudyTitles(string sdSid)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });
            
            var count = await _studyRepository.DeleteAllStudyTitles(sdSid);
            return Ok(new ApiResponse<StudyTitleDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "All study titles have been removed." },
                Data = null
            });
        }
        
    }
}