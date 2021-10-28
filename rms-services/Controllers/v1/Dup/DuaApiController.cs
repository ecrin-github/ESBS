using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rms_services.Contracts.Responses;
using rms_services.DTO;
using rms_services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rms_services.Controllers.v1.Dup
{
    public class DuaApiController : BaseApiController
    {
        
        private readonly IDupRepository _dupRepository;

        public DuaApiController(IDupRepository dupRepository)
        {
            _dupRepository = dupRepository;
        }
        
        
        [HttpGet("data-uses/{dupId:int}/accesses")]
        [SwaggerOperation(Tags = new []{"Data use access endpoint"})]
        public async Task<IActionResult> GetDuaList(int dupId)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DuaDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DUP has been found."},
                Data = null
            });

            var duaList = await _dupRepository.GetAllDua(dupId);
            if (duaList == null)
                return NotFound(new ApiResponse<DuaDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No DUA have been found." },
                    Data = null
                });
            
            return Ok(new ApiResponse<DuaDto>()
            {
                Total = duaList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = duaList
            });
        }

        [HttpGet("data-uses/{dupId:int}/accesses/{id:int}")]
        [SwaggerOperation(Tags = new []{"Data use access endpoint"})]
        public async Task<IActionResult> GetDua(int dupId, int id)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DuaDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DUP has been found."},
                Data = null
            });

            var dua = await _dupRepository.GetDua(id);
            if (dua == null) return NotFound(new ApiResponse<DuaDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DUA has been found."},
                Data = null
            });
            var duaList = new List<DuaDto>() { dua };
            return Ok(new ApiResponse<DuaDto>()
            {
                Total = duaList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = duaList
            });
        }

        [HttpPost("data-uses/{dupId:int}/accesses")]
        [SwaggerOperation(Tags = new []{"Data use access endpoint"})]
        public async Task<IActionResult> CreateDua(int dupId, [FromBody] DuaDto duaDto)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DuaDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DUP has been found."},
                Data = null
            });

            var dua = await _dupRepository.CreateDua(dupId, duaDto);
            if (dua == null) return BadRequest(new ApiResponse<DuaDto>()
            {
                Total = 0,
                StatusCode = BadRequest().StatusCode,
                Messages = new List<string>(){"Error during DUA creation."},
                Data = null
            });
            
            var duaList = new List<DuaDto>() { dua };
            return Ok(new ApiResponse<DuaDto>()
            {
                Total = duaList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = duaList
            });
        }

        [HttpPut("data-uses/{dupId:int}/accesses/{id:int}")]
        [SwaggerOperation(Tags = new []{"Data use access endpoint"})]
        public async Task<IActionResult> UpdateDua(int dupId, int id, [FromBody] DuaDto duaDto)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DuaDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DUP has been found."},
                Data = null
            });

            var dua = await _dupRepository.GetDua(id);
            if (dua == null) return NotFound(new ApiResponse<DuaDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DUA has been found."},
                Data = null
            });

            var updatedDua = await _dupRepository.UpdateDua(duaDto);
            if (updatedDua == null)
                return BadRequest(new ApiResponse<DuaDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during DUA update." },
                    Data = null
                });

            var duaList = new List<DuaDto>() { updatedDua };
            return Ok(new ApiResponse<DuaDto>()
            {
                Total = duaList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = duaList
            });
        }

        [HttpDelete("data-uses/{dupId:int}/accesses/{id:int}")]
        [SwaggerOperation(Tags = new []{"Data use access endpoint"})]
        public async Task<IActionResult> DeleteDua(int dupId, int id)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DuaDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DUP has been found."},
                Data = null
            });

            var dua = await _dupRepository.GetDua(id);
            if (dua == null) return NotFound(new ApiResponse<DuaDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DUA has been found."},
                Data = null
            });
            
            var count = await _dupRepository.DeleteDua(id);
            return Ok(new ApiResponse<DuaDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>(){"DUA has been removed."},
                Data = null
            });
        }

        [HttpDelete("data-uses/{dupId:int}/accesses")]
        [SwaggerOperation(Tags = new []{"Data use access endpoint"})]
        public async Task<IActionResult> DeleteAllDua(int dupId)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DuaDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DUP has been found."},
                Data = null
            });
            
            var count = await _dupRepository.DeleteAllDua(dupId);
            return Ok(new ApiResponse<DuaDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>(){"All DUAs have been removed."},
                Data = null
            });
        }
        
    }
}