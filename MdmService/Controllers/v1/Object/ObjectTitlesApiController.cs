using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MdmService.Contracts.Responses;
using MdmService.DTO.Object;
using MdmService.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

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
            if (dataObj == null) return NotFound(new ApiResponse<ObjectTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objTitles = await _dataObjectRepository.GetObjectTitles(sdOid);
            if (objTitles == null)
                return NotFound(new ApiResponse<ObjectTitleDto>()
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
            if (dataObj == null) return NotFound(new ApiResponse<ObjectTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objTitle = await _dataObjectRepository.GetObjectTitle(id);
            if (objTitle == null) return NotFound(new ApiResponse<ObjectTitleDto>()
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
            if (dataObj == null) return NotFound(new ApiResponse<ObjectTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objTitle = await _dataObjectRepository.CreateObjectTitle(sdOid, objectTitleDto);
            if (objTitle == null)
                return BadRequest(new ApiResponse<ObjectTitleDto>()
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
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return NotFound(new ApiResponse<ObjectTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objTitle = await _dataObjectRepository.GetObjectTitle(id);
            if (objTitle == null) return NotFound(new ApiResponse<ObjectTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object titles have been found." },
                Data = null
            });

            var updatedObjectTitle = await _dataObjectRepository.UpdateObjectTitle(objectTitleDto);
            if (updatedObjectTitle == null)
                return BadRequest(new ApiResponse<ObjectTitleDto>()
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
            if (dataObj == null) return NotFound(new ApiResponse<ObjectTitleDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objTitle = await _dataObjectRepository.GetObjectTitle(id);
            if (objTitle == null) return NotFound(new ApiResponse<ObjectTitleDto>()
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
            if (dataObj == null) return NotFound(new ApiResponse<ObjectTitleDto>()
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