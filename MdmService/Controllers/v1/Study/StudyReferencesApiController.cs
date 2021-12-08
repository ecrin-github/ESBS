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
    public class StudyReferencesApiController : BaseApiController
    {
        
        private readonly IStudyRepository _studyRepository;

        public StudyReferencesApiController(IStudyRepository studyRepository)
        {
            _studyRepository = studyRepository ?? throw new ArgumentNullException(nameof(studyRepository));
        }
        
        [HttpGet("studies/{sdSid}/references")]
        [SwaggerOperation(Tags = new []{"Study references endpoint"})]
        public async Task<IActionResult> GetStudyReferences(string sdSid)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return Ok(new ApiResponse<StudyReferenceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyRefs = await _studyRepository.GetStudyReferences(sdSid);
            if (studyRefs == null)
                return Ok(new ApiResponse<StudyReferenceDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No study references have been found." },
                    Data = null
                });
            
            return Ok(new ApiResponse<StudyReferenceDto>()
            {
                Total = studyRefs.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyRefs
            });
        }
        
        [HttpGet("studies/{sdSid}/references/{id:int}")]
        [SwaggerOperation(Tags = new []{"Study references endpoint"})]
        public async Task<IActionResult> GetStudyReferences(string sdSid, int id)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return Ok(new ApiResponse<StudyReferenceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyRef = await _studyRepository.GetStudyReference(id);
            if (studyRef == null) return Ok(new ApiResponse<StudyReferenceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No study references have been found." },
                Data = null
            });

            var studyRefList = new List<StudyReferenceDto>() { studyRef };
            return Ok(new ApiResponse<StudyReferenceDto>()
            {
                Total = studyRefList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyRefList
            });
        }

        [HttpPost("studies/{sdSid}/references")]
        [SwaggerOperation(Tags = new []{"Study references endpoint"})]
        public async Task<IActionResult> CreateStudyReference(string sdSid,
            [FromBody] StudyReferenceDto studyReferenceDto)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return Ok(new ApiResponse<StudyReferenceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyRef = await _studyRepository.CreateStudyReference(sdSid, studyReferenceDto);
            if (studyRef == null)
                return Ok(new ApiResponse<StudyReferenceDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during study reference creation." },
                    Data = null
                });

            var studyRefList = new List<StudyReferenceDto>() { studyRef };
            return Ok(new ApiResponse<StudyReferenceDto>()
            {
                Total = studyRefList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyRefList
            });
        }

        [HttpPut("studies/{sdSid}/references/{id:int}")]
        [SwaggerOperation(Tags = new []{"Study references endpoint"})]
        public async Task<IActionResult> UpdateStudyReference(string sdSid, int id, [FromBody] StudyReferenceDto studyReferenceDto)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return Ok(new ApiResponse<StudyReferenceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });
            var studyRef = await _studyRepository.GetStudyReference(id);
            if (studyRef == null) return Ok(new ApiResponse<StudyReferenceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No study references have been found." },
                Data = null
            });

            var updatedStudyRef = await _studyRepository.UpdateStudyReference(studyReferenceDto);
            if (updatedStudyRef == null)
                return Ok(new ApiResponse<StudyReferenceDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during study reference update." },
                    Data = null
                });

            var studyRefList = new List<StudyReferenceDto>() { updatedStudyRef };
            return Ok(new ApiResponse<StudyReferenceDto>()
            {
                Total = studyRefList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyRefList
            });
        }

        [HttpDelete("studies/{sdSid}/references/{id:int}")]
        [SwaggerOperation(Tags = new []{"Study references endpoint"})]
        public async Task<IActionResult> DeleteStudyReference(string sdSid, int id)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return Ok(new ApiResponse<StudyReferenceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyRef = await _studyRepository.GetStudyReference(id);
            if (studyRef == null) return Ok(new ApiResponse<StudyReferenceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No study references have been found." },
                Data = null
            });
            
            var count = await _studyRepository.DeleteStudyReference(id);
            return Ok(new ApiResponse<StudyReferenceDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "Study reference has been removed." },
                Data = null
            });
        }

        [HttpDelete("studies/{sdSid}/references")]
        [SwaggerOperation(Tags = new []{"Study references endpoint"})]
        public async Task<IActionResult> DeleteAllStudyReferences(string sdSid)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return Ok(new ApiResponse<StudyReferenceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });
            
            var count = await _studyRepository.DeleteAllStudyReferences(sdSid);
            return Ok(new ApiResponse<StudyReferenceDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "All study references have been removed." },
                Data = null
            });
        }
        
    }
}