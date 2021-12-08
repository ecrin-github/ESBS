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
    public class ObjectRightsApiController : BaseApiController
    {
        
        private readonly IObjectRepository _dataObjectRepository;

        public ObjectRightsApiController(IObjectRepository objectRepository)
        {
            _dataObjectRepository = objectRepository ?? throw new ArgumentNullException(nameof(objectRepository));
        }
        
        
        [HttpGet("data-objects/{sdOid}/rights")]
        [SwaggerOperation(Tags = new []{"Object rights endpoint"})]
        public async Task<IActionResult> GetObjectRights(string sdOid)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectRightDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objRights = await _dataObjectRepository.GetObjectRights(sdOid);
            if (objRights == null) return Ok(new ApiResponse<ObjectRightDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object rights have been found." },
                Data = null
            });
            
            return Ok(new ApiResponse<ObjectRightDto>()
            {
                Total = objRights.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objRights
            });
        }
        
        [HttpGet("data-objects/{sdOid}/rights/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object rights endpoint"})]
        public async Task<IActionResult> GetObjectRight(string sdOid, int id)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectRightDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objRight = await _dataObjectRepository.GetObjectRight(id);
            if (objRight == null) return Ok(new ApiResponse<ObjectRightDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object rights have been found." },
                Data = null
            });

            var objRightList = new List<ObjectRightDto>() { objRight };
            return Ok(new ApiResponse<ObjectRightDto>()
            {
                Total = objRightList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objRightList
            });
        }

        [HttpPost("data-objects/{sdOid}/rights")]
        [SwaggerOperation(Tags = new []{"Object rights endpoint"})]
        public async Task<IActionResult> CreateObjectRight(string sdOid,
            [FromBody] ObjectRightDto objectRightDto)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectRightDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objRight = await _dataObjectRepository.CreateObjectRight(sdOid, objectRightDto);
            if (objRight == null) return Ok(new ApiResponse<ObjectRightDto>()
            {
                Total = 0,
                StatusCode = BadRequest().StatusCode,
                Messages = new List<string>() { "Error during object right creation." },
                Data = null
            });

            var objRightList = new List<ObjectRightDto>() { objRight };
            return Ok(new ApiResponse<ObjectRightDto>()
            {
                Total = objRightList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objRightList
            });
        }

        [HttpPut("data-objects/{sdOid}/rights/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object rights endpoint"})]
        public async Task<IActionResult> UpdateObjectRight(string sdOid, int id, [FromBody] ObjectRightDto objectRightDto)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectRightDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });
            
            var objRight = await _dataObjectRepository.GetObjectRight(id);
            if (objRight == null) return Ok(new ApiResponse<ObjectRightDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object rights have been found." },
                Data = null
            });

            var updatedObjRight = await _dataObjectRepository.UpdateObjectRight(objectRightDto);
            if (updatedObjRight == null)
                return Ok(new ApiResponse<ObjectRightDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during object right update." },
                    Data = null
                });

            var objRightList = new List<ObjectRightDto>() { updatedObjRight };
            return Ok(new ApiResponse<ObjectRightDto>()
            {
                Total = objRightList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objRightList
            });
        }
        
        [HttpDelete("data-objects/{sdOid}/rights/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object rights endpoint"})]
        public async Task<IActionResult> DeleteObjectRight(string sdOid, int id)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectRightDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });
            
            var objRight = await _dataObjectRepository.GetObjectRight(id);
            if (objRight == null) return Ok(new ApiResponse<ObjectRightDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object rights have been found." },
                Data = null
            });
            
            var count = await _dataObjectRepository.DeleteObjectRight(id);
            return Ok(new ApiResponse<ObjectRightDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "Object right has been removed." },
                Data = null
            });
        }

        [HttpDelete("data-objects/{sdOid}/rights")]
        [SwaggerOperation(Tags = new []{"Object rights endpoint"})]
        public async Task<IActionResult> DeleteAllObjectRights(string sdOid)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectRightDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });
            
            var count = await _dataObjectRepository.DeleteAllObjectRights(sdOid);
            return Ok(new ApiResponse<ObjectRightDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "All object rights have been removed." },
                Data = null
            });
        }
        
    }
}