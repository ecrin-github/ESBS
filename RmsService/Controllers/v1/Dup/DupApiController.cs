using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RmsService.Contracts.Responses;
using RmsService.DTO;
using RmsService.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace RmsService.Controllers.v1.Dup
{
    public class DupApiController : BaseApiController
    {
        
        private readonly IDupRepository _dupRepository;

        public DupApiController(IDupRepository dupRepository)
        {
            _dupRepository = dupRepository;
        }
        
        
        [HttpGet("data-uses/processes")]
        [SwaggerOperation(Tags = new []{"Data use process endpoint"})]
        public async Task<IActionResult> GetDupList()
        {
            var dupList = await _dupRepository.GetAllDup();
            if (dupList == null)
                return NotFound(new ApiResponse<DupDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No DUPs have been found." },
                    Data = null
                });
            return Ok(new ApiResponse<DupDto>()
            {
                Total = dupList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dupList
            });
        }
        
        [HttpGet("data-uses/processes/recent/{number:int}")]
        [SwaggerOperation(Tags = new []{"Data use process endpoint"})]
        public async Task<IActionResult> GetRecentDup(int number)
        {
            var recentData = await _dupRepository.GetRecentDup(number);
            if (recentData == null) return NotFound(new ApiResponse<DupDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });
            return Ok(new ApiResponse<DupDto>()
            {
                Total = recentData.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = recentData
            });
        }
        
        [HttpGet("data-uses/processes/{dupId:int}")]
        [SwaggerOperation(Tags = new []{"Data use process endpoint"})]
        public async Task<IActionResult> GetDup(int dupId)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DupDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });
            var dupList = new List<DupDto>() { dup };
            return Ok(new ApiResponse<DupDto>()
            {
                Total = dupList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dupList
            });
        }

        [HttpPost("data-uses/processes")]
        [SwaggerOperation(Tags = new []{"Data use process endpoint"})]
        public async Task<IActionResult> CreateDup([FromBody] DupDto dupDto)
        {
            var dup = await _dupRepository.CreateDup(dupDto);
            if (dup == null)
                return BadRequest(new ApiResponse<DupDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during DUP creation." },
                    Data = null
                });
            var dupList = new List<DupDto>() { dup };
            return Ok(new ApiResponse<DupDto>()
            {
                Total = dupList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dupList
            });
        }
        
        [HttpPut("data-uses/processes/{dupId:int}")]
        [SwaggerOperation(Tags = new []{"Data use process endpoint"})]
        public async Task<IActionResult> UpdateDup(int dupId, [FromBody] DupDto dupDto)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DupDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });
            var updatedDup = await _dupRepository.UpdateDup(dupDto);
            if (updatedDup == null) return BadRequest(new ApiResponse<DupDto>()
            {
                Total = 0,
                StatusCode = BadRequest().StatusCode,
                Messages = new List<string>() { "Error during DUP update." },
                Data = null
            });
            var dupList = new List<DupDto>() { updatedDup };
            return Ok(new ApiResponse<DupDto>()
            {
                Total = dupList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dupList
            });
        }

        [HttpDelete("data-uses/processes/{dupId:int}")]
        [SwaggerOperation(Tags = new []{"Data use process endpoint"})]
        public async Task<IActionResult> DeleteDup(int dupId)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return NotFound(new ApiResponse<DupDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });
            
            var count = await _dupRepository.DeleteDup(dupId);
            return Ok(new ApiResponse<DupDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "DUP has been removed." },
                Data = null
            });
        }
        
    }
}