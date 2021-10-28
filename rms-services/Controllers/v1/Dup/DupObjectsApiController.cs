using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rms_services.Contracts.Responses;
using rms_services.DTO;
using rms_services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rms_services.Controllers.v1.Dup
{
    public class DupObjectsApiController : BaseApiController
    {
        
        private readonly IDupRepository _dupRepository;

        public DupObjectsApiController(IDupRepository dupRepository)
        {
            _dupRepository = dupRepository;
        }
        
        
        [HttpGet("data-uses/{dupId:int}/objects")]
        [SwaggerOperation(Tags = new []{"Data use process objects endpoint"})]
        public async Task<IActionResult> GetDupObjectList(int dupId)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DupObjectDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });

            var dupObjects = await _dupRepository.GetDupObjects(dupId);
            if (dupObjects == null)
                return NotFound(new ApiResponse<DupObjectDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No DUP objects have been found." },
                    Data = null
                });
            
            return Ok(new ApiResponse<DupObjectDto>()
            {
                Total = dupObjects.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dupObjects
            });
        }

        [HttpGet("data-uses/{dupId:int}/objects/{id}")]
        [SwaggerOperation(Tags = new []{"Data use process objects endpoint"})]
        public async Task<IActionResult> GetDupObject(int dupId, int id)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DupObjectDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });

            var dupObj = await _dupRepository.GetDupObject(id);
            if (dupObj == null) return NotFound(new ApiResponse<DupObjectDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP objects has been found." },
                Data = null
            });

            var dupObjectList = new List<DupObjectDto>() { dupObj };
            return Ok(new ApiResponse<DupObjectDto>()
            {
                Total = dupObjectList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dupObjectList
            });
        }

        [HttpPost("data-uses/{dupId:int}/objects")]
        [SwaggerOperation(Tags = new []{"Data use process objects endpoint"})]
        public async Task<IActionResult> CreateDupObject(int dupId, [FromBody] DupObjectDto dupObjectDto)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DupObjectDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });

            var dupObj = await _dupRepository.CreateDupObject(dupId, dupObjectDto);
            if (dupObj == null)
                return BadRequest(new ApiResponse<DupObjectDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during DUP object creation." },
                    Data = null
                });

            var dupObjList = new List<DupObjectDto>() { dupObj };
            return Ok(new ApiResponse<DupObjectDto>()
            {
                Total = dupObjList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dupObjList
            });
        }

        [HttpPut("data-uses/{dupId:int}/objects/{id:int}")]
        [SwaggerOperation(Tags = new []{"Data use process objects endpoint"})]
        public async Task<IActionResult> UpdateDupObject(int dupId, int id, [FromBody] DupObjectDto dupObjectDto)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DupObjectDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });
            
            var dupObj = await _dupRepository.GetDupObject(id);
            if (dupObj == null) return NotFound(new ApiResponse<DupObjectDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP object has been found." },
                Data = null
            });

            var updatedDupObject = await _dupRepository.UpdateDupObject(dupObjectDto);
            if (updatedDupObject == null) return BadRequest(new ApiResponse<DupObjectDto>()
            {
                Total = 0,
                StatusCode = BadRequest().StatusCode,
                Messages = new List<string>() { "Error during DUP object update." },
                Data = null
            });

            var dupObjList = new List<DupObjectDto>() { updatedDupObject };
            return Ok(new ApiResponse<DupObjectDto>()
            {
                Total = dupObjList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dupObjList
            });
        }

        [HttpDelete("data-uses/{dupId:int}/objects/{id}")]
        [SwaggerOperation(Tags = new []{"Data use process objects endpoint"})]
        public async Task<IActionResult> DeleteDupObject(int dupId, int id)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DupObjectDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });
            
            var dupObj = await _dupRepository.GetDupObject(id);
            if (dupObj == null) return NotFound(new ApiResponse<DupObjectDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP object has been found." },
                Data = null
            });
            
            var count = await _dupRepository.DeleteDupObject(id);
            return Ok(new ApiResponse<DupObjectDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "DUP object has been removed." },
                Data = null
            });
        }

        [HttpDelete("data-uses/{dupId:int}/objects")]
        [SwaggerOperation(Tags = new []{"Data use process objects endpoint"})]
        public async Task<IActionResult> DeleteAllDupObjects(int dupId)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DupObjectDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });
            
            var count = await _dupRepository.DeleteAllDupObjects(dupId);
            return Ok(new ApiResponse<DupObjectDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "All DUP objects have been removed." },
                Data = null
            });
        }
        
        
    }
}