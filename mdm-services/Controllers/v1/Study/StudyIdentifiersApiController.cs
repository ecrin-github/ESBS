using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mdm_services.Contracts.Responses;
using mdm_services.DTO.Study;
using mdm_services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace mdm_services.Controllers.v1.Study
{
    public class StudyIdentifiersApiController : BaseApiController
    {

        private readonly IStudyRepository _studyRepository;

        public StudyIdentifiersApiController(IStudyRepository studyRepository)
        {
            _studyRepository = studyRepository;
        }
        
        
        [HttpGet("studies/{sdSid}/identifiers")]
        [SwaggerOperation(Tags = new []{"Study identifiers endpoint"})]
        public async Task<IActionResult> GetStudyIdentifiers(string sdSid)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyIdentifierDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyIdents = await _studyRepository.GetStudyIdentifiers(sdSid);
            if (studyIdents == null)
                return NotFound(new ApiResponse<StudyIdentifierDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No study identifiers have been found." },
                    Data = null
                });
            
            return Ok(new ApiResponse<StudyIdentifierDto>()
            {
                Total = studyIdents.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyIdents
            });
        }
        
        [HttpGet("studies/{sdSid}/identifiers/{id:int}")]
        [SwaggerOperation(Tags = new []{"Study identifiers endpoint"})]
        public async Task<IActionResult> GetStudyIdentifier(string sdSid, int id)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyIdentifierDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyIdent = await _studyRepository.GetStudyIdentifier(id);
            if (studyIdent == null) return NotFound(new ApiResponse<StudyIdentifierDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No study features have been found." },
                Data = null
            });

            var studyIdentList = new List<StudyIdentifierDto>() { studyIdent };
            return Ok(new ApiResponse<StudyIdentifierDto>()
            {
                Total = studyIdentList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyIdentList
            });
        }

        [HttpPost("studies/{sdSid}/identifiers")]
        [SwaggerOperation(Tags = new []{"Study identifiers endpoint"})]
        public async Task<IActionResult> CreateStudyIdentifier(string sdSid, [FromBody] StudyIdentifierDto studyIdentifierDto)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyIdentifierDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyIdent = await _studyRepository.CreateStudyIdentifier(sdSid, studyIdentifierDto);
            if (studyIdent == null)
                return BadRequest(new ApiResponse<StudyIdentifierDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during study identifier creation." },
                    Data = null
                });

            var studyIdentList = new List<StudyIdentifierDto>() { studyIdent };
            return Ok(new ApiResponse<StudyIdentifierDto>()
            {
                Total = studyIdentList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyIdentList
            });
        }

        [HttpPut("studies/{sdSid}/identifiers/{id:int}")]
        [SwaggerOperation(Tags = new []{"Study identifiers endpoint"})]
        public async Task<IActionResult> UpdateStudyIdentifier(string sdSid, int id, [FromBody] StudyIdentifierDto studyIdentifierDto)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyIdentifierDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });
            
            var studyIdent = await _studyRepository.GetStudyIdentifier(id);
            if (studyIdent == null) return NotFound(new ApiResponse<StudyIdentifierDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No study identifiers have been found." },
                Data = null
            });

            var updatedStudyIdent = await _studyRepository.UpdateStudyIdentifier(studyIdentifierDto);
            if (updatedStudyIdent == null)
                return BadRequest(new ApiResponse<StudyIdentifierDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during study identifier update." },
                    Data = null
                });

            var studyIdentList = new List<StudyIdentifierDto>() { updatedStudyIdent };
            return Ok(new ApiResponse<StudyIdentifierDto>()
            {
                Total = studyIdentList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyIdentList
            });
        }

        [HttpDelete("studies/{sdSid}/identifiers/{id:int}")]
        [SwaggerOperation(Tags = new []{"Study identifiers endpoint"})]
        public async Task<IActionResult> DeleteStudyIdentifier(string sdSid, int id)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyIdentifierDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });
            
            var studyIdent = await _studyRepository.GetStudyIdentifier(id);
            if (studyIdent == null) return NotFound(new ApiResponse<StudyIdentifierDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No study identifiers have been found." },
                Data = null
            });
            
            var count = await _studyRepository.DeleteStudyIdentifier(id);
            return Ok(new ApiResponse<StudyIdentifierDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "Study identifier has been removed." },
                Data = null
            });
        }

        [HttpDelete("studies/{sdSid}/identifiers")]
        [SwaggerOperation(Tags = new []{"Study identifiers endpoint"})]
        public async Task<IActionResult> DeleteAllStudyIdentifiers(string sdSid)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyIdentifierDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });
            
            var count = await _studyRepository.DeleteAllStudyIdentifiers(sdSid);
            return Ok(new ApiResponse<StudyIdentifierDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "All study identifiers have been removed." },
                Data = null
            });
        }
        
    }
}