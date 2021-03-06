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
    public class ObjectTitlesApiController : BaseApiController
    {
        
        private readonly IObjectRepository _dataObjectRepository;

        public ObjectTitlesApiController(IObjectRepository objectRepository)
        {
            _dataObjectRepository = objectRepository ?? throw new ArgumentNullException(nameof(objectRepository));
        }
        
        
        [HttpGet("data-objects/{sdOid}/titles")]
        [SwaggerOperation(Tags = new []{"Object titles endpoint"})]
        public async Task<IActionResult> GetObjectTitles(string sdOid)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objTitles = await _dataObjectRepository.GetObjectTitles(sdOid);
            if (objTitles == null)
                return Ok(new ApiResponse<ObjectTitleDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No data object titles have been found." },
                    Data = null
                });
            
            return Ok(new ApiResponse<ObjectTitleDto>()
            {
                Total = objTitles.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objTitles
            });
        }
        
        [HttpGet("data-objects/{sdOid}/titles/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object titles endpoint"})]
        public async Task<IActionResult> GetObjectTitle(string sdOid, int id)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objTitle = await _dataObjectRepository.GetObjectTitle(id);
            if (objTitle == null) return Ok(new ApiResponse<ObjectTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object titles have been found." },
                Data = null
            });

            var objTitleList = new List<ObjectTitleDto>() { objTitle };
            return Ok(new ApiResponse<ObjectTitleDto>()
            {
                Total = objTitleList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objTitleList
            });
        }

        [HttpPost("data-objects/{sdOid}/titles")]
        [SwaggerOperation(Tags = new []{"Object titles endpoint"})]
        public async Task<IActionResult> CreateObjectTitle(string sdOid,
            [FromBody] ObjectTitleDto objectTitleDto)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            objectTitleDto.SdOid ??= sdOid;

            var accessTokenRes = await HttpContext.GetTokenAsync("access_token");
            var accessToken = accessTokenRes?.ToString();
            
            var objTitle = await _dataObjectRepository.CreateObjectTitle(objectTitleDto, accessToken);
            if (objTitle == null)
                return Ok(new ApiResponse<ObjectTitleDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during object title creation." },
                    Data = null
                });

            var objTitleList = new List<ObjectTitleDto>() { objTitle };
            return Ok(new ApiResponse<ObjectTitleDto>()
            {
                Total = objTitleList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objTitleList
            });
        }

        [HttpPut("data-objects/{sdOid}/titles/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object titles endpoint"})]
        public async Task<IActionResult> UpdateObjectTitle(string sdOid, int id, [FromBody] ObjectTitleDto objectTitleDto)
        {
            objectTitleDto.Id ??= id;
            objectTitleDto.SdOid ??= sdOid;
            
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objTitle = await _dataObjectRepository.GetObjectTitle(id);
            if (objTitle == null) return Ok(new ApiResponse<ObjectTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object titles have been found." },
                Data = null
            });

            var accessTokenRes = await HttpContext.GetTokenAsync("access_token");
            var accessToken = accessTokenRes?.ToString();

            var updatedObjectTitle = await _dataObjectRepository.UpdateObjectTitle(objectTitleDto, accessToken);
            if (updatedObjectTitle == null)
                return Ok(new ApiResponse<ObjectTitleDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during object title update." },
                    Data = null
                });

            var objTitleList = new List<ObjectTitleDto>() { updatedObjectTitle };
            return Ok(new ApiResponse<ObjectTitleDto>()
            {
                Total = objTitleList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objTitleList
            });
        }
        
        [HttpDelete("data-objects/{sdOid}/titles/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object titles endpoint"})]
        public async Task<IActionResult> DeleteObjectTitle(string sdOid, int id)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objTitle = await _dataObjectRepository.GetObjectTitle(id);
            if (objTitle == null) return Ok(new ApiResponse<ObjectTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object titles have been found." },
                Data = null
            });
            
            var count = await _dataObjectRepository.DeleteObjectTitle(id);
            return Ok(new ApiResponse<ObjectTitleDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "Object title has been removed." },
                Data = null
            });
        }

        [HttpDelete("data-objects/{sdOid}/titles")]
        [SwaggerOperation(Tags = new []{"Object titles endpoint"})]
        public async Task<IActionResult> DeleteAllObjectTitles(string sdOid)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });
            
            var count = await _dataObjectRepository.DeleteAllObjectTitles(sdOid);
            return Ok(new ApiResponse<ObjectTitleDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "All object titles have been removed." },
                Data = null
            });
        }
    }
}