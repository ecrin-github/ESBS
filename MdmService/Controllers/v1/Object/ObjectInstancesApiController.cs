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
    public class ObjectInstancesApiController : BaseApiController
    {
        
        private readonly IObjectRepository _dataObjectRepository;

        public ObjectInstancesApiController(IObjectRepository objectRepository)
        {
            _dataObjectRepository = objectRepository ?? throw new ArgumentNullException(nameof(objectRepository));
        }
        
        
        [HttpGet("data-objects/{sdOid}/instances")]
        [SwaggerOperation(Tags = new []{"Object instances endpoint"})]
        public async Task<IActionResult> GetObjectInstances(string sdOid)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectInstanceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objInstances = await _dataObjectRepository.GetObjectInstances(sdOid);
            if (objInstances == null)
                return Ok(new ApiResponse<ObjectInstanceDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No data object instances have been found." },
                    Data = null
                });

            return Ok(new ApiResponse<ObjectInstanceDto>()
            {
                Total = objInstances.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objInstances
            });
        }
        
        [HttpGet("data-objects/{sdOid}/instances/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object instances endpoint"})]
        public async Task<IActionResult> GetObjectInstance(string sdOid, int id)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectInstanceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objInstance = await _dataObjectRepository.GetObjectInstance(id);
            if (objInstance == null) return Ok(new ApiResponse<ObjectInstanceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object instances have been found." },
                Data = null
            });

            var objInstanceList = new List<ObjectInstanceDto>() { objInstance };
            return Ok(new ApiResponse<ObjectInstanceDto>()
            {
                Total = objInstanceList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objInstanceList
            });
        }

        [HttpPost("data-objects/{sdOid}/instances")]
        [SwaggerOperation(Tags = new []{"Object instances endpoint"})]
        public async Task<IActionResult> CreateObjectInstance(string sdOid,
            [FromBody] ObjectInstanceDto objectInstanceDto)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectInstanceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var accessTokenRes = await HttpContext.GetTokenAsync("access_token");
            var accessToken = accessTokenRes?.ToString();

            objectInstanceDto.SdOid ??= sdOid;
            var objInstance = await _dataObjectRepository.CreateObjectInstance(objectInstanceDto, accessToken);
            if (objInstance == null) return Ok(new ApiResponse<ObjectInstanceDto>()
            {
                Total = 0,
                StatusCode = BadRequest().StatusCode,
                Messages = new List<string>() { "Error during object instance creation." },
                Data = null
            });

            var objInstList = new List<ObjectInstanceDto>() { objInstance };
            return Ok(new ApiResponse<ObjectInstanceDto>()
            {
                Total = objInstList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objInstList
            });
        }

        [HttpPut("data-objects/{sdOid}/instances/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object instances endpoint"})]
        public async Task<IActionResult> UpdateObjectInstance(string sdOid, int id, [FromBody] ObjectInstanceDto objectInstanceDto)
        {
            objectInstanceDto.Id ??= id;
            objectInstanceDto.SdOid ??= sdOid;
            
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectInstanceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });
            
            var objInstance = await _dataObjectRepository.GetObjectInstance(id);
            if (objInstance == null) return Ok(new ApiResponse<ObjectInstanceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object instances have been found." },
                Data = null
            });

            var accessTokenRes = await HttpContext.GetTokenAsync("access_token");
            var accessToken = accessTokenRes?.ToString();

            var updatedObjInst = await _dataObjectRepository.UpdateObjectInstance(objectInstanceDto, accessToken);
            if (updatedObjInst == null)
                return Ok(new ApiResponse<ObjectInstanceDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during object instance update." },
                    Data = null
                });

            var objInstList = new List<ObjectInstanceDto>() { updatedObjInst };
            return Ok(new ApiResponse<ObjectInstanceDto>()
            {
                Total = objInstList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objInstList
            });
        }
        
        [HttpDelete("data-objects/{sdOid}/instances/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object instances endpoint"})]
        public async Task<IActionResult> DeleteObjectInstance(string sdOid, int id)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectInstanceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });
            
            var objInstance = await _dataObjectRepository.GetObjectInstance(id);
            if (objInstance == null) return Ok(new ApiResponse<ObjectInstanceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object instances have been found." },
                Data = null
            });
            
            var count = await _dataObjectRepository.DeleteObjectInstance(id);
            return Ok(new ApiResponse<ObjectInstanceDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "Object instance has been removed." },
                Data = null
            });
        }

        [HttpDelete("data-objects/{sdOid}/instances")]
        [SwaggerOperation(Tags = new []{"Object instances endpoint"})]
        public async Task<IActionResult> DeleteAllObjectInstances(string sdOid)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectInstanceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });
            
            var count = await _dataObjectRepository.DeleteAllObjectInstances(sdOid);
            return Ok(new ApiResponse<ObjectInstanceDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "All object instances have been removed." },
                Data = null
            });
        }
        
    }
}