using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MdmService.Contracts.Responses;
using MdmService.DTO.Object;
using MdmService.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authentication;

namespace MdmService.Controllers.v1.Object
{
    public class ObjectTopicsApiController : BaseApiController
    {
        
        private readonly IObjectRepository _dataObjectRepository;

        public ObjectTopicsApiController(IObjectRepository objectRepository)
        {
            _dataObjectRepository = objectRepository ?? throw new ArgumentNullException(nameof(objectRepository));
        }
        
        
        [HttpGet("data-objects/{sdOid}/topics")]
        [SwaggerOperation(Tags = new []{"Object topics endpoint"})]
        public async Task<IActionResult> GetObjectTopics(string sdOid)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectTopicDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objTopics = await _dataObjectRepository.GetObjectTopics(sdOid);
            if (objTopics == null)
                return Ok(new ApiResponse<ObjectTopicDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No data object topics have been found." },
                    Data = null
                });
            
            return Ok(new ApiResponse<ObjectTopicDto>()
            {
                Total = objTopics.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objTopics
            });
        }
        
        [HttpGet("data-objects/{sdOid}/topics/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object topics endpoint"})]
        public async Task<IActionResult> GetObjectTopic(string sdOid, int id)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectTopicDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objTopic = await _dataObjectRepository.GetObjectTopic(id);
            if (objTopic == null) return Ok(new ApiResponse<ObjectTopicDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object topics have been found." },
                Data = null
            });

            var objTopicList = new List<ObjectTopicDto>() { objTopic };
            return Ok(new ApiResponse<ObjectTopicDto>()
            {
                Total = objTopicList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objTopicList
            });
        }

        [HttpPost("data-objects/{sdOid}/topics")]
        [SwaggerOperation(Tags = new []{"Object topics endpoint"})]
        public async Task<IActionResult> CreateObjectTopic(string sdOid,
            [FromBody] ObjectTopicDto objectTopicDto)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectTopicDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            objectTopicDto.SdOid ??= sdOid;

            var accessTokenRes = await HttpContext.GetTokenAsync("access_token");
            var accessToken = accessTokenRes?.ToString();
            
            var objTopic = await _dataObjectRepository.CreateObjectTopic(objectTopicDto, accessToken);
            if (objTopic == null) return Ok(new ApiResponse<ObjectTopicDto>()
            {
                Total = 0,
                StatusCode = BadRequest().StatusCode,
                Messages = new List<string>() { "Error during object topic creation." },
                Data = null
            });

            var objTopicList = new List<ObjectTopicDto>() { objTopic };
            return Ok(new ApiResponse<ObjectTopicDto>()
            {
                Total = objTopicList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objTopicList
            });
        }

        [HttpPut("data-objects/{sdOid}/topics/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object topics endpoint"})]
        public async Task<IActionResult> UpdateObjectTopic(string sdOid, int id, [FromBody] ObjectTopicDto objectTopicDto)
        {
            objectTopicDto.Id ??= id;
            objectTopicDto.SdOid ??= sdOid;
            
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectTopicDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objTopic = await _dataObjectRepository.GetObjectTopic(id);
            if (objTopic == null) return Ok(new ApiResponse<ObjectTopicDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object topics have been found." },
                Data = null
            });

            var accessTokenRes = await HttpContext.GetTokenAsync("access_token");
            var accessToken = accessTokenRes?.ToString();

            var updatedObjectTopic = await _dataObjectRepository.UpdateObjectTopic(objectTopicDto, accessToken);
            if (updatedObjectTopic == null)
                return Ok(new ApiResponse<ObjectTopicDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during object topic update." },
                    Data = null
                });

            var objTopicList = new List<ObjectTopicDto>() { updatedObjectTopic };
            return Ok(new ApiResponse<ObjectTopicDto>()
            {
                Total = objTopicList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objTopicList
            });
        }
        
        [HttpDelete("data-objects/{sdOid}/topics/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object topics endpoint"})]
        public async Task<IActionResult> DeleteObjectTopic(string sdOid, int id)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectTopicDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objTopic = await _dataObjectRepository.GetObjectTopic(id);
            if (objTopic == null) return Ok(new ApiResponse<ObjectTopicDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object topics have been found." },
                Data = null
            });
            
            var count = await _dataObjectRepository.DeleteObjectTopic(id);
            return Ok(new ApiResponse<ObjectTopicDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "Object topic has been removed." },
                Data = null
            });
        }

        [HttpDelete("data-objects/{sdOid}/topics")]
        [SwaggerOperation(Tags = new []{"Object topics endpoint"})]
        public async Task<IActionResult> DeleteAllObjectTopics(string sdOid)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectTopicDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var count = await _dataObjectRepository.DeleteAllObjectTopics(sdOid);
            return Ok(new ApiResponse<ObjectTopicDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "All object topics have been removed." },
                Data = null
            });
        }
        
    }
}