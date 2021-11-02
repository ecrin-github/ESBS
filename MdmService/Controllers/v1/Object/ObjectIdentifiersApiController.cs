using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MdmService.Contracts.Responses;
using MdmService.DTO.Object;
using MdmService.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace MdmService.Controllers.v1.Object
{
    public class ObjectIdentifiersApiController : BaseApiController
    {
        
        private readonly IObjectRepository _dataObjectRepository;

        public ObjectIdentifiersApiController(IObjectRepository objectRepository)
        {
            _dataObjectRepository = objectRepository;
        }
        
        
        [HttpGet("data-objects/{sdOid}/identifiers")]
        [SwaggerOperation(Tags = new []{"Object identifiers endpoint"})]
        public async Task<IActionResult> GetObjectIdentifiers(string sdOid)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return NotFound(new ApiResponse<ObjectIdentifierDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objIdentifiers = await _dataObjectRepository.GetObjectIdentifiers(sdOid);
            if (objIdentifiers == null)
                return NotFound(new ApiResponse<ObjectIdentifierDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No data object identifiers have been found." },
                    Data = null
                });
            
            return Ok(new ApiResponse<ObjectIdentifierDto>()
            {
                Total = objIdentifiers.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objIdentifiers
            });
        }
        
        [HttpGet("data-objects/{sdOid}/identifiers/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object identifiers endpoint"})]
        public async Task<IActionResult> GetObjectIdentifier(string sdOid, int id)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return NotFound(new ApiResponse<ObjectIdentifierDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objIdentifier = await _dataObjectRepository.GetObjectIdentifier(id);
            if (objIdentifier == null) return NotFound(new ApiResponse<ObjectIdentifierDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object identifiers have been found." },
                Data = null
            });

            var objIdentList = new List<ObjectIdentifierDto>() { objIdentifier };
            return Ok(new ApiResponse<ObjectIdentifierDto>()
            {
                Total = objIdentList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objIdentList
            });
        }

        [HttpPost("data-objects/{sdOid}/identifiers")]
        [SwaggerOperation(Tags = new []{"Object identifiers endpoint"})]
        public async Task<IActionResult> CreateObjectIdentifier(string sdOid,
            [FromBody] ObjectIdentifierDto objectIdentifierDto)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return NotFound(new ApiResponse<ObjectIdentifierDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objIdent = await _dataObjectRepository.CreateObjectIdentifier(sdOid, objectIdentifierDto);
            if (objIdent == null) return BadRequest(new ApiResponse<ObjectIdentifierDto>()
            {
                Total = 0,
                StatusCode = BadRequest().StatusCode,
                Messages = new List<string>() { "Error during object identifier creation." },
                Data = null
            });

            var objIdentList = new List<ObjectIdentifierDto>() { objIdent };
            return Ok(new ApiResponse<ObjectIdentifierDto>()
            {
                Total = objIdentList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objIdentList
            });
        }

        [HttpPut("data-objects/{sdOid}/identifiers/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object identifiers endpoint"})]
        public async Task<IActionResult> UpdateObjectIdentifier(string sdOid, int id, [FromBody] ObjectIdentifierDto objectIdentifierDto)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return NotFound(new ApiResponse<ObjectIdentifierDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objIdentifier = await _dataObjectRepository.GetObjectIdentifier(id);
            if (objIdentifier == null) return NotFound(new ApiResponse<ObjectIdentifierDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object identifiers have been found." },
                Data = null
            });

            var updatedObjectIdentifier = await _dataObjectRepository.UpdateObjectIdentifier(objectIdentifierDto);
            if (updatedObjectIdentifier == null)
                return BadRequest(new ApiResponse<ObjectIdentifierDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during object identifier update." },
                    Data = null
                });

            var objIdentList = new List<ObjectIdentifierDto>() { updatedObjectIdentifier };
            return Ok(new ApiResponse<ObjectIdentifierDto>()
            {
                Total = objIdentList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objIdentList
            });
        }
        
        [HttpDelete("data-objects/{sdOid}/identifiers/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object identifiers endpoint"})]
        public async Task<IActionResult> DeleteObjectIdentifier(string sdOid, int id)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return NotFound(new ApiResponse<ObjectIdentifierDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objIdentifier = await _dataObjectRepository.GetObjectIdentifier(id);
            if (objIdentifier == null) return NotFound(new ApiResponse<ObjectIdentifierDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object identifiers have been found." },
                Data = null
            });
            
            var count = await _dataObjectRepository.DeleteObjectIdentifier(id);
            return Ok(new ApiResponse<ObjectIdentifierDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "Object identifier has been removed." },
                Data = null
            });
        }

        [HttpDelete("data-object/{sdOid}/identifiers")]
        [SwaggerOperation(Tags = new []{"Object identifiers endpoint"})]
        public async Task<IActionResult> DeleteAllObjectIdentifiers(string sdOid)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return NotFound(new ApiResponse<ObjectIdentifierDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var count = await _dataObjectRepository.DeleteAllObjectIdentifiers(sdOid);
            return Ok(new ApiResponse<ObjectIdentifierDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "All object identifiers have been removed." },
                Data = null
            });
        }
        
    }
}