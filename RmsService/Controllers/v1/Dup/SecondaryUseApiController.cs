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
    public class SecondaryUseApiController : BaseApiController
    {
        
        private readonly IDupRepository _dupRepository;

        public SecondaryUseApiController(IDupRepository dupRepository)
        {
            _dupRepository = dupRepository ?? throw new ArgumentNullException(nameof(dupRepository));
        }
        
        
        [HttpGet("data-uses/{dupId:int}/secondary-use")]
        [SwaggerOperation(Tags = new []{"Secondary use endpoint"})]
        public async Task<IActionResult> GetSecondaryUseList(int dupId)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });

            var secUses = await _dupRepository.GetSecondaryUses(dupId);
            if (secUses == null)
                return Ok(new ApiResponse<SecondaryUseDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No secondary uses have been found." },
                    Data = null
                });
            
            return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = secUses.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = secUses
            });
        }

        [HttpGet("data-uses/{dupId:int}/secondary-use/{id:int}")]
        [SwaggerOperation(Tags = new []{"Secondary use endpoint"})]
        public async Task<IActionResult> GetSecondaryUse(int dupId, int id)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });

            var secUse = await _dupRepository.GetSecondaryUse(id);
            if (secUse == null) return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No secondary use has been found." },
                Data = null
            });

            var secUseList = new List<SecondaryUseDto>() { secUse };
            return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = secUseList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = secUseList
            });
        }

        [HttpPost("data-uses/{dupId:int}/secondary-use")]
        [SwaggerOperation(Tags = new []{"Secondary use endpoint"})]
        public async Task<IActionResult> CreateSecondaryUse(int dupId, [FromBody] SecondaryUseDto secondaryUseDto)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });

            var secUse = await _dupRepository.CreateSecondaryUse(dupId, secondaryUseDto);
            if (secUse == null)
                return Ok(new ApiResponse<SecondaryUseDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during secondary use creation." },
                    Data = null
                });

            var secUseList = new List<SecondaryUseDto>() { secUse };
            return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = secUseList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = secUseList
            });
        }

        [HttpPut("data-uses/{dupId:int}/secondary-use/{id:int}")]
        [SwaggerOperation(Tags = new []{"Secondary use endpoint"})]
        public async Task<IActionResult> UpdateSecondaryUse(int dupId, int id, [FromBody] SecondaryUseDto secondaryUseDto)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });
            
            var secUse = await _dupRepository.GetSecondaryUse(id);
            if (secUse == null) return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No secondary use has been found." },
                Data = null
            });

            var updateSecUse = await _dupRepository.UpdateSecondaryUse(secondaryUseDto);
            if (updateSecUse == null)
                return Ok(new ApiResponse<SecondaryUseDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during secondary use update." },
                    Data = null
                });

            var secUseList = new List<SecondaryUseDto>() { updateSecUse };
            return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = secUseList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = secUseList
            });
        }

        [HttpDelete("data-uses/{dupId:int}/secondary-use/{id:int}")]
        [SwaggerOperation(Tags = new []{"Secondary use endpoint"})]
        public async Task<IActionResult> DeleteSecondaryUse(int dupId, int id)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });
            
            var secUse = await _dupRepository.GetSecondaryUse(id);
            if (secUse == null) return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No secondary use has been found." },
                Data = null
            });
            
            var count = await _dupRepository.DeleteSecondaryUse(id);
            return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "Secondary use has been removed." },
                Data = null
            });
        }

        [HttpDelete("data-uses/{dupId:int}/secondary-use")]
        [SwaggerOperation(Tags = new []{"Secondary use endpoint"})]
        public async Task<IActionResult> DeleteAllSecondaryUses(int dupId)
        {
            var dup = await _dupRepository.GetDup(dupId);
            if (dup == null) return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No DUP has been found." },
                Data = null
            });
            
            var count = await _dupRepository.DeleteAllSecondaryUses(dupId);
            return Ok(new ApiResponse<SecondaryUseDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "All secondary uses have been removed." },
                Data = null
            });
        }

    }
}