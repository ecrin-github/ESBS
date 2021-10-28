using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mdm_services.Contracts.Responses;
using mdm_services.DTO.Object;
using mdm_services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace mdm_services.Controllers.v1.Object
{
    public class ObjectInstancesApiController : BaseApiController
    {
        
        private readonly IObjectRepository _dataObjectRepository;

        public ObjectInstancesApiController(IObjectRepository objectRepository)
        {
            _dataObjectRepository = objectRepository;
        }
        
        
        [HttpGet("data-objects/{sdOid}/instances")]
        [SwaggerOperation(Tags = new []{"Object instances endpoint"})]
        public async Task<IActionResult> GetObjectInstances(string sdOid)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return NotFound(new ApiResponse<ObjectInstanceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objInstances = await _dataObjectRepository.GetObjectInstances(sdOid);
            if (objInstances == null)
                return NotFound(new ApiResponse<ObjectInstanceDto>()
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
            if (dataObj == null) return NotFound(new ApiResponse<ObjectInstanceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objInstance = await _dataObjectRepository.GetObjectInstance(id);
            if (objInstance == null) return NotFound(new ApiResponse<ObjectInstanceDto>()
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
            if (dataObj == null) return NotFound(new ApiResponse<ObjectInstanceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objInstance = await _dataObjectRepository.CreateObjectInstance(sdOid, objectInstanceDto);
            if (objInstance == null) return BadRequest(new ApiResponse<ObjectInstanceDto>()
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
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return NotFound(new ApiResponse<ObjectInstanceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });
            
            var objInstance = await _dataObjectRepository.GetObjectInstance(id);
            if (objInstance == null) return NotFound(new ApiResponse<ObjectInstanceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object instances have been found." },
                Data = null
            });

            var updatedObjInst = await _dataObjectRepository.UpdateObjectInstance(objectInstanceDto);
            if (updatedObjInst == null)
                return BadRequest(new ApiResponse<ObjectInstanceDto>()
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
            if (dataObj == null) return NotFound(new ApiResponse<ObjectInstanceDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });
            
            var objInstance = await _dataObjectRepository.GetObjectInstance(id);
            if (objInstance == null) return NotFound(new ApiResponse<ObjectInstanceDto>()
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
            if (dataObj == null) return NotFound(new ApiResponse<ObjectInstanceDto>()
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