using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RmsService.Contracts.Responses;
using RmsService.DTO;
using RmsService.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace RmsService.Controllers.v1.Dup
{
    public class DupPrereqsApiController : BaseApiController
    {
        
        private readonly IDupRepository _dupRepository;

        public DupPrereqsApiController(IDupRepository dupRepository)
        {
            _dupRepository = dupRepository ?? throw new ArgumentNullException(nameof(dupRepository));
        }
        
        
        [HttpGet("data-uses/{dupId:int}/prereqs")]
        [SwaggerOperation(Tags = new []{"Data use process prereqs endpoint"})]
        public async Task<IActionResult> GetDupPrereqList(int dupId)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DupPrereqDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });

            var dupPrereqs = await _dupRepository.GetDupPrereqs(dupId);
            if (dupPrereqs == null)
                return NotFound(new ApiResponse<DupPrereqDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No DUP prereqs have been found." },
                    Data = null
                });
            
            return Ok(new ApiResponse<DupPrereqDto>()
            {
                Total = dupPrereqs.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dupPrereqs
            });
        }

        [HttpGet("data-uses/{dupId:int}/prereqs/{id:int}")]
        [SwaggerOperation(Tags = new []{"Data use process prereqs endpoint"})]
        public async Task<IActionResult> GetDupPrereq(int dupId, int id)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DupPrereqDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });

            var dupPrereq = await _dupRepository.GetDupPrereq(id);
            if (dupPrereq == null) return NotFound(new ApiResponse<DupPrereqDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP prereq has been found." },
                Data = null
            });

            var dupPrereqList = new List<DupPrereqDto>() { dupPrereq };
            return Ok(new ApiResponse<DupPrereqDto>()
            {
                Total = dupPrereqList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dupPrereqList
            });
        }

        [HttpPost("data-uses/{dupId:int}/prereqs")]
        [SwaggerOperation(Tags = new []{"Data use process prereqs endpoint"})]
        public async Task<IActionResult> CreateDupPrereq(int dupId, [FromBody] DupPrereqDto dupPrereqDto)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DupPrereqDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });

            var dupPrereq = await _dupRepository.CreateDupPrereq(dupId, dupPrereqDto);
            if (dupPrereq == null)
                return BadRequest(new ApiResponse<DupPrereqDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during DUP prereq creation." },
                    Data = null
                });

            var dupPrereqList = new List<DupPrereqDto>() { dupPrereq };
            return Ok(new ApiResponse<DupPrereqDto>()
            {
                Total = dupPrereqList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dupPrereqList
            });
        }

        [HttpPut("data-uses/{dupId:int}/prereqs/{id:int}")]
        [SwaggerOperation(Tags = new []{"Data use process prereqs endpoint"})]
        public async Task<IActionResult> UpdateDupPrereq(int dupId, int id, [FromBody] DupPrereqDto dupPrereqDto)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DupPrereqDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });
            
            var dupPrereq = await _dupRepository.GetDupPrereq(id);
            if (dupPrereq == null) return NotFound(new ApiResponse<DupPrereqDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP prereq has been found." },
                Data = null
            });

            var updatedDupPrereq = await _dupRepository.UpdateDupPrereq(dupPrereqDto);
            if (updatedDupPrereq == null) return BadRequest(new ApiResponse<DupPrereqDto>()
            {
                Total = 0,
                StatusCode = BadRequest().StatusCode,
                Messages = new List<string>() { "Error during DUP prereq update." },
                Data = null
            });

            var dupPrereqList = new List<DupPrereqDto>() { updatedDupPrereq };
            return Ok(new ApiResponse<DupPrereqDto>()
            {
                Total = dupPrereqList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dupPrereqList
            });
        }

        [HttpDelete("data-uses/{dupId:int}/prereqs/{id:int}")]
        [SwaggerOperation(Tags = new []{"Data use process prereqs endpoint"})]
        public async Task<IActionResult> DeleteDupPrereq(int dupId, int id)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DupPrereqDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });
            
            var dupPrereq = await _dupRepository.GetDupPrereq(id);
            if (dupPrereq == null) return NotFound(new ApiResponse<DupPrereqDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP prereq has been found." },
                Data = null
            });
            
            var count = await _dupRepository.DeleteDupPrereq(id);
            return Ok(new ApiResponse<DupPrereqDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "DUP prereq has been removed." },
                Data = null
            });
        }

        [HttpDelete("data-uses/{dupId:int}/prereqs")]
        [SwaggerOperation(Tags = new []{"Data use process prereqs endpoint"})]
        public async Task<IActionResult> DeleteAllDupPrereqs(int dupId)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DupPrereqDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });
            
            var count = await _dupRepository.DeleteAllDupPrereqs(dupId);
            return Ok(new ApiResponse<DupPrereqDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "All DUP prereqs have been removed." },
                Data = null
            });
        }
        
    }
}