using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MdmService.Contracts.Responses;
using MdmService.DTO.Study;
using MdmService.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace MdmService.Controllers.v1.Study
{
    public class StudyDataApiController : BaseApiController
    {
        private readonly IStudyRepository _studyRepository;

        public StudyDataApiController(IStudyRepository studyRepository)
        {
            _studyRepository = studyRepository;
        }
        
        [HttpGet("studies/data")]
        [SwaggerOperation(Tags = new []{"Study data endpoint"})]
        public async Task<IActionResult> GetStudyData()
        {
            var studyData = await _studyRepository.GetStudiesData();
            if (studyData == null)
                return NotFound(new ApiResponse<StudyDataDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No studies have been found." },
                    Data = null
                });
            return Ok(new ApiResponse<StudyDataDto>()
            {
                Total = studyData.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyData
            });
        }

        [HttpGet("studies/{sdSid}/data")]
        [SwaggerOperation(Tags = new []{"Study data endpoint"})]
        public async Task<IActionResult> GetStudyData(string sdSid)
        {
            var study = await _studyRepository.GetStudyData(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyDataDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyList = new List<StudyDataDto>() { study };
            return Ok(new ApiResponse<StudyDataDto>()
            {
                Total = studyList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyList
            });
        }
        
        [HttpGet("studies/data/recent/{number:int}")]
        [SwaggerOperation(Tags = new []{"Study data endpoint"})]
        public async Task<IActionResult> GetRecentStudyData(int number)
        {
            var recentData = await _studyRepository.GetRecentStudyData(number);
            if (recentData == null) return NotFound(new ApiResponse<StudyDataDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });
            return Ok(new ApiResponse<StudyDataDto>()
            {
                Total = recentData.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = recentData
            });
        }

        [HttpPost("studies/data")]
        [SwaggerOperation(Tags = new []{"Study data endpoint"})]
        public async Task<IActionResult> CreateStudyData([FromBody] StudyDataDto studyDataDto)
        {
            var studyData = await _studyRepository.CreateStudyData(studyDataDto);
            if (studyData == null)
                return BadRequest(new ApiResponse<StudyDataDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during study creation." },
                    Data = null
                });

            var studyList = new List<StudyDataDto>() { studyData };
            return Ok(new ApiResponse<StudyDataDto>()
            {
                Total = studyList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyList
            });
        }

        [HttpPut("studies/{sdSid}/data")]
        [SwaggerOperation(Tags = new []{"Study data endpoint"})]
        public async Task<IActionResult> UpdateStudyData(string sdSid, [FromBody] StudyDataDto studyDataDto)
        {
            var study = await _studyRepository.GetStudyData(sdSid);
            if (study == null) return NotFound(new ApiResponse<StudyDataDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var updatedStudy = await _studyRepository.UpdateStudyData(studyDataDto);
            if (updatedStudy == null)
                return BadRequest(new ApiResponse<StudyDataDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during study update." },
                    Data = null
                });

            var studyList = new List<StudyDataDto>() { updatedStudy };
            return Ok(new ApiResponse<StudyDataDto>()
            {
                Total = studyList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyList
            });
        }
    }
}