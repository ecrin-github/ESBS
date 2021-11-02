using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MdmService.Contracts.Responses;
using MdmService.DTO.Study;
using MdmService.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace MdmService.Controllers.v1.Study
{
    public class StudyTopicsApiController : BaseApiController
    {
        private readonly IStudyRepository _studyRepository;

        public StudyTopicsApiController(IStudyRepository studyRepository)
        {
            _studyRepository = studyRepository;
        }
        
        
        [HttpGet("studies/{sdSid}/topics")]
        [SwaggerOperation(Tags = new []{"Study topics endpoint"})]
        public async Task<IActionResult> GetStudyTopics(string sdSid)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyTopicDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyTopics = await _studyRepository.GetStudyTopics(sdSid);
            if (studyTopics == null)
                return NotFound(new ApiResponse<StudyTopicDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No study topics have been found." },
                    Data = null
                });
            
            return Ok(new ApiResponse<StudyTopicDto>()
            {
                Total = studyTopics.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyTopics
            });
        }
        
        [HttpGet("studies/{sdSid}/topics/{id:int}")]
        [SwaggerOperation(Tags = new []{"Study topics endpoint"})]
        public async Task<IActionResult> GetStudyTopic(string sdSid, int id)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyTopicDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyTopic = await _studyRepository.GetStudyTopic(id);
            if (studyTopic == null) return NotFound(new ApiResponse<StudyTopicDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No study topics have been found." },
                Data = null
            });

            var studyTopicList = new List<StudyTopicDto>() { studyTopic };
            return Ok(new ApiResponse<StudyTopicDto>()
            {
                Total = studyTopicList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyTopicList
            });
        }

        [HttpPost("studies/{sdSid}/topics")]
        [SwaggerOperation(Tags = new []{"Study topics endpoint"})]
        public async Task<IActionResult> CreateStudyTopic(string sdSid, [FromBody] StudyTopicDto studyTopicDto)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyTopicDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyTopic = await _studyRepository.CreateStudyTopic(sdSid, studyTopicDto);
            if (studyTopic == null) return BadRequest(new ApiResponse<StudyTopicDto>()
            {
                Total = 0,
                StatusCode = BadRequest().StatusCode,
                Messages = new List<string>() { "Error during study topic creation." },
                Data = null
            });

            var studyTopicList = new List<StudyTopicDto>() { studyTopic };
            return Ok(new ApiResponse<StudyTopicDto>()
            {
                Total = studyTopicList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyTopicList
            });
        }

        [HttpPut("studies/{sdSid}/topics/{id:int}")]
        [SwaggerOperation(Tags = new []{"Study topics endpoint"})]
        public async Task<IActionResult> UpdateStudyTopic(string sdSid, int id, [FromBody] StudyTopicDto studyTopicDto)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyTopicDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyTopic = await _studyRepository.GetStudyTopic(id);
            if (studyTopic == null) return NotFound(new ApiResponse<StudyTopicDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No study topics have been found." },
                Data = null
            });

            var updatedStudyTopic = await _studyRepository.UpdateStudyTopic(studyTopicDto);
            if (updatedStudyTopic == null)
                return BadRequest(new ApiResponse<StudyTopicDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during study topic update." },
                    Data = null
                });

            var studyTopicList = new List<StudyTopicDto>() { updatedStudyTopic };
            return Ok(new ApiResponse<StudyTopicDto>()
            {
                Total = studyTopicList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyTopicList
            });
        }

        [HttpDelete("studies/{sdSid}/topics/{id:int}")]
        [SwaggerOperation(Tags = new []{"Study topics endpoint"})]
        public async Task<IActionResult> DeleteStudyTopic(string sdSid, int id)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyTopicDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyTopic = await _studyRepository.GetStudyTopic(id);
            if (studyTopic == null) return NotFound(new ApiResponse<StudyTopicDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No study topics have been found." },
                Data = null
            });
            
            var count = await _studyRepository.DeleteStudyTopic(id);
            return Ok(new ApiResponse<StudyTopicDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "Study topic has been found." },
                Data = null
            });
        }

        [HttpDelete("studies/{sdSid}/topics")]
        [SwaggerOperation(Tags = new []{"Study topics endpoint"})]
        public async Task<IActionResult> DeleteAllStudyTopics(string sdSid)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyTopicDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });
            
            var count = await _studyRepository.DeleteAllStudyTopics(sdSid);
            return Ok(new ApiResponse<StudyTopicDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "All study topics have been removed." },
                Data = null
            });
        }
    }
}