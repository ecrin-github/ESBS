using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MdmService.Contracts.Responses;
using MdmService.DTO.Study;
using MdmService.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace MdmService.Controllers.v1.Study
{
    public class StudyRelationshipsApiController : BaseApiController
    {
        
        private readonly IStudyRepository _studyRepository;

        public StudyRelationshipsApiController(IStudyRepository studyRepository)
        {
            _studyRepository = studyRepository;
        }
        
        [HttpGet("studies/{sdSid}/relationships")]
        [SwaggerOperation(Tags = new []{"Study relationships endpoint"})]
        public async Task<IActionResult> GetStudyRelationships(string sdSid)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyRelationshipDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyRelationships = await _studyRepository.GetStudyRelationships(sdSid);
            if (studyRelationships == null)
                return NotFound(new ApiResponse<StudyRelationshipDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No study relationships have been found." },
                    Data = null
                });
            
            return Ok(new ApiResponse<StudyRelationshipDto>()
            {
                Total = studyRelationships.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyRelationships
            });
        }
        
        [HttpGet("studies/{sdSid}/relationships/{id:int}")]
        [SwaggerOperation(Tags = new []{"Study relationships endpoint"})]
        public async Task<IActionResult> GetStudyRelationship(string sdSid, int id)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyRelationshipDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyRel = await _studyRepository.GetStudyRelationship(id);
            if (studyRel == null) return NotFound(new ApiResponse<StudyRelationshipDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No study relationships have been found." },
                Data = null
            });

            var studyRelList = new List<StudyRelationshipDto>() { studyRel };
            return Ok(new ApiResponse<StudyRelationshipDto>()
            {
                Total = studyRelList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyRelList
            });
        }

        [HttpPost("studies/{sdSid}/relationships")]
        [SwaggerOperation(Tags = new []{"Study relationships endpoint"})]
        public async Task<IActionResult> CreateStudyRelationship(string sdSid,
            [FromBody] StudyRelationshipDto studyRelationshipDto)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyRelationshipDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyRel = await _studyRepository.CreateStudyRelationship(sdSid, studyRelationshipDto);
            if (studyRel == null)
                return BadRequest(new ApiResponse<StudyRelationshipDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during study relationship creation." },
                    Data = null
                });

            var studyRelList = new List<StudyRelationshipDto>() { studyRel };
            return Ok(new ApiResponse<StudyRelationshipDto>()
            {
                Total = studyRelList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyRelList
            });
        }

        [HttpPut("studies/{sdSid}/relationships/{id:int}")]
        [SwaggerOperation(Tags = new []{"Study relationships endpoint"})]
        public async Task<IActionResult> UpdateStudyRelationship(string sdSid, int id, [FromBody] StudyRelationshipDto studyRelationshipDto)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyRelationshipDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyRel = await _studyRepository.GetStudyRelationship(id);
            if (studyRel == null) return NotFound(new ApiResponse<StudyRelationshipDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No study relationships have been found." },
                Data = null
            });

            var updatedStudyRel = await _studyRepository.UpdateStudyRelationship(studyRelationshipDto);
            if (updatedStudyRel == null)
                return BadRequest(new ApiResponse<StudyRelationshipDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during study relationship update." },
                    Data = null
                });

            var studyRelList = new List<StudyRelationshipDto>() { updatedStudyRel };
            return Ok(new ApiResponse<StudyRelationshipDto>()
            {
                Total = studyRelList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyRelList
            });
        }

        [HttpDelete("studies/{sdSid}/relationships/{id:int}")]
        [SwaggerOperation(Tags = new []{"Study relationships endpoint"})]
        public async Task<IActionResult> DeleteStudyRelationship(string sdSid, int id)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyRelationshipDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyRel = await _studyRepository.GetStudyRelationship(id);
            if (studyRel == null) return NotFound(new ApiResponse<StudyRelationshipDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No study relationships have been found." },
                Data = null
            });
            
            var count = await _studyRepository.DeleteStudyRelationship(id);
            return Ok(new ApiResponse<StudyRelationshipDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "Study relationship has been removed." },
                Data = null
            });
        }

        [HttpDelete("studies/{sdSid}/relationships")]
        [SwaggerOperation(Tags = new []{"Study relationships endpoint"})]
        public async Task<IActionResult> DeleteAllStudyRelationships(string sdSid)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyRelationshipDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var count = await _studyRepository.DeleteAllStudyRelationships(sdSid);
            return Ok(new ApiResponse<StudyRelationshipDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "All study relationships have been removed." },
                Data = null
            });
        }

    }
}