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
    public class ObjectDatesApiController : BaseApiController
    {
        private readonly IObjectRepository _dataObjectRepository;

        public ObjectDatesApiController(IObjectRepository objectRepository)
        {
            _dataObjectRepository = objectRepository ?? throw new ArgumentNullException(nameof(objectRepository));
        }
        
        [HttpGet("data-objects/{sdOid}/dates")]
        [SwaggerOperation(Tags = new []{"Object dates endpoint"})]
        public async Task<IActionResult> GetObjectDates(string sdOid)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectDateDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objDates = await _dataObjectRepository.GetObjectDates(sdOid);
            if (objDates == null)
                return Ok(new ApiResponse<ObjectDateDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No data object dates have been found." },
                    Data = null
                });
            
            return Ok(new ApiResponse<ObjectDateDto>()
            {
                Total = objDates.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objDates
            });
        }
        
        [HttpGet("data-objects/{sdOid}/dates/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object dates endpoint"})]
        public async Task<IActionResult> GetObjectDate(string sdOid, int id)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectDateDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objDate = await _dataObjectRepository.GetObjectDate(id);
            if (objDate == null) return Ok(new ApiResponse<ObjectDateDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object dates have been found." },
                Data = null
            });

            var objDateList = new List<ObjectDateDto>() { objDate };
            return Ok(new ApiResponse<ObjectDateDto>()
            {
                Total = objDateList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objDateList
            });
        }

        [HttpPost("data-objects/{sdOid}/dates")]
        [SwaggerOperation(Tags = new []{"Object dates endpoint"})]
        public async Task<IActionResult> CreateObjectDate(string sdOid,
            [FromBody] ObjectDateDto objectDateDto)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectDateDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var accessTokenRes = await HttpContext.GetTokenAsync("access_token");
            var accessToken = accessTokenRes?.ToString();
            
            objectDateDto.SdOid ??= sdOid;
            var objDate = await _dataObjectRepository.CreateObjectDate(objectDateDto, accessToken);
            if (objDate == null)
                return Ok(new ApiResponse<ObjectDateDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during object date creation." },
                    Data = null
                });

            var objDateList = new List<ObjectDateDto>() { objDate };
            return Ok(new ApiResponse<ObjectDateDto>()
            {
                Total = objDateList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objDateList
            });
        }

        [HttpPut("data-objects/{sdOid}/dates/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object dates endpoint"})]
        public async Task<IActionResult> UpdateObjectDate(string sdOid, int id, [FromBody] ObjectDateDto objectDateDto)
        {
            objectDateDto.Id ??= id;
            objectDateDto.SdOid ??= sdOid;
            
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectDateDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objDate = await _dataObjectRepository.GetObjectDate(id);
            if (objDate == null) return Ok(new ApiResponse<ObjectDateDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object dates have been found." },
                Data = null
            });

            var accessTokenRes = await HttpContext.GetTokenAsync("access_token");
            var accessToken = accessTokenRes?.ToString();

            var updatedObjDate = await _dataObjectRepository.UpdateObjectDate(objectDateDto, accessToken);
            if (updatedObjDate == null)
                return Ok(new ApiResponse<ObjectDateDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during object date update." },
                    Data = null
                });

            var objDateList = new List<ObjectDateDto>() { updatedObjDate };
            return Ok(new ApiResponse<ObjectDateDto>()
            {
                Total = objDateList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objDateList
            });
        }
        
        [HttpDelete("data-objects/{sdOid}/dates/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object dates endpoint"})]
        public async Task<IActionResult> DeleteObjectDate(string sdOid, int id)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectDateDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objDate = await _dataObjectRepository.GetObjectDate(id);
            if (objDate == null) return Ok(new ApiResponse<ObjectDateDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object dates have been found." },
                Data = null
            });
            
            var count = await _dataObjectRepository.DeleteObjectDate(id);
            return Ok(new ApiResponse<ObjectDateDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "Object date has been removed." },
                Data = null
            });
        }

        [HttpDelete("data-objects/{sdOid}/dates")]
        [SwaggerOperation(Tags = new []{"Object dates endpoint"})]
        public async Task<IActionResult> DeleteAllObjectDates(string sdOid)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectDateDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });
            
            var count = await _dataObjectRepository.DeleteAllObjectDates(sdOid);
            return Ok(new ApiResponse<ObjectDateDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "All object dates have been removed." },
                Data = null
            });
        }
    }
}