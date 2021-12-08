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
    public class StudyFeaturesApiController : BaseApiController
    {
        
        private readonly IStudyRepository _studyRepository;

        public StudyFeaturesApiController(IStudyRepository studyRepository)
        {
            _studyRepository = studyRepository ?? throw new ArgumentNullException(nameof(studyRepository));
        }

        [HttpGet("studies/{sdSid}/features")]
        [SwaggerOperation(Tags = new[] { "Study features endpoint" })]
        public async Task<IActionResult> GetStudyFeatures(string sdSid)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return Ok(new ApiResponse<StudyFeatureDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });
            
            var studyFeatures = await _studyRepository.GetStudyFeatures(sdSid);
            if (studyFeatures == null)
                return Ok(new ApiResponse<StudyFeatureDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No study features have been found." },
                    Data = null
                });
            
            return Ok(new ApiResponse<StudyFeatureDto>()
            {
                Total = studyFeatures.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyFeatures
            });
        }

        [HttpGet("studies/{sdSid}/features/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Study features endpoint" })]
        public async Task<IActionResult> GetStudyFeature(string sdSid, int id)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return Ok(new ApiResponse<StudyFeatureDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyFeature = await _studyRepository.GetStudyFeature(id);
            if (studyFeature == null) return Ok(new ApiResponse<StudyFeatureDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No study features have been found." },
                Data = null
            });

            var studyFeatureList = new List<StudyFeatureDto>() { studyFeature };
            return Ok(new ApiResponse<StudyFeatureDto>()
            {
                Total = studyFeatureList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyFeatureList
            });
        }

        [HttpPost("studies/{sdSid}/features")]
        [SwaggerOperation(Tags = new []{"Study features endpoint"})]
        public async Task<IActionResult> CreateStudyFeature(string sdSid, [FromBody] StudyFeatureDto studyFeatureDto)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return Ok(new ApiResponse<StudyFeatureDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });

            var studyFeature = await _studyRepository.CreateStudyFeature(sdSid, studyFeatureDto);
            if (studyFeature == null)
                return Ok(new ApiResponse<StudyFeatureDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during study feature creation." },
                    Data = null
                });

            var studyFeatureList = new List<StudyFeatureDto>() { studyFeature };
            return Ok(new ApiResponse<StudyFeatureDto>()
            {
                Total = studyFeatureList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyFeatureList
            });
        }

        [HttpPut("studies/{sdSid}/features/{id:int}")]
        [SwaggerOperation(Tags = new []{"Study features endpoint"})]
        public async Task<IActionResult> UpdateStudyFeature(string sdSid, int id, [FromBody] StudyFeatureDto studyFeatureDto)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return Ok(new ApiResponse<StudyFeatureDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });
            
            var studyFeature = await _studyRepository.GetStudyFeature(id);
            if (studyFeature == null) return Ok(new ApiResponse<StudyFeatureDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No study features have been found." },
                Data = null
            });

            var updatedStudyFeature = await _studyRepository.UpdateStudyFeature(studyFeatureDto);
            if (updatedStudyFeature == null)
                return Ok(new ApiResponse<StudyFeatureDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during study feature update." },
                    Data = null
                });

            var studyFeatureList = new List<StudyFeatureDto>() { updatedStudyFeature };
            return Ok(new ApiResponse<StudyFeatureDto>()
            {
                Total = studyFeatureList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = studyFeatureList
            });
        }

        [HttpDelete("studies/{sdSid}/features/{id:int}")]
        [SwaggerOperation(Tags = new []{"Study features endpoint"})]
        public async Task<IActionResult> DeleteStudyFeature(string sdSid, int id)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return Ok(new ApiResponse<StudyFeatureDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });
            
            var studyFeature = await _studyRepository.GetStudyFeature(id);
            if (studyFeature == null) return Ok(new ApiResponse<StudyFeatureDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No study features have been found." },
                Data = null
            });
            
            var count = await _studyRepository.DeleteStudyFeature(id);
            return Ok(new ApiResponse<StudyFeatureDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "Study feature has been removed." },
                Data = null
            });
        }

        [HttpDelete("studies/{sdSid}/features")]
        [SwaggerOperation(Tags = new []{"Study features endpoint"})]
        public async Task<IActionResult> DeleteAllStudyFeatures(string sdSid)
        {
            var study = await _studyRepository.GetStudyById(sdSid);
            if (study == null) return Ok(new ApiResponse<StudyFeatureDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No studies have been found." },
                Data = null
            });
            
            var count = await _studyRepository.DeleteAllStudyFeatures(sdSid);
            return Ok(new ApiResponse<StudyFeatureDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "All study features have been removed." },
                Data = null
            });
        }
        
    }
}