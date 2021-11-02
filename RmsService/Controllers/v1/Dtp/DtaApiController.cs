using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RmsService.Contracts.Responses;
using RmsService.DTO;
using RmsService.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace RmsService.Controllers.v1.Dtp
{
    public class DtaApiController : BaseApiController
    {
        
        private readonly IDtpRepository _dtpRepository;

        public DtaApiController(IDtpRepository dtpRepository)
        {
            _dtpRepository = dtpRepository;
        }
        
        
        [HttpGet("data-transfers/{dtpId:int}/accesses")]
        [SwaggerOperation(Tags = new []{"Data transfer access endpoint"})]
        public async Task<IActionResult> GetDtaList(int dtpId)
        {
            var dt = await _dtpRepository.GetDtp(dtpId);
            if (dt == null) return NotFound(new ApiResponse<DtaDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No related DTPs have been found."},
                Data = null
            });

            var data = await _dtpRepository.GetAllDta(dtpId);
            
            return Ok(new ApiResponse<DtaDto>()
            {
                Total = data.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = data
            });
        }

        [HttpGet("data-transfers/{dtpId:int}/accesses/{id:int}")]
        [SwaggerOperation(Tags = new []{"Data transfer access endpoint"})]
        public async Task<IActionResult> GetDta(int dtpId, int id)
        {
            var dt = await _dtpRepository.GetDtp(dtpId);
            if (dt == null) return NotFound(new ApiResponse<DtaDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No related DTPs have been found."},
                Data = null
            });

            var dta = await _dtpRepository.GetDta(id);
            if (dta == null) return NotFound(new ApiResponse<DtaDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No related DTAs have been found."},
                Data = null
            });

            var dtaList = new List<DtaDto> { dta };

            return Ok(new ApiResponse<DtaDto>()
            {
                Total = dtaList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dtaList
            });
        }

        [HttpPost("data-transfers/{dtpId:int}/accesses")]
        [SwaggerOperation(Tags = new []{"Data transfer access endpoint"})]
        public async Task<IActionResult> CreateDta(int dtpId, [FromBody] DtaDto dtaDto)
        {
            var dt = await _dtpRepository.GetDtp(dtpId);
            if (dt == null) return NotFound(new ApiResponse<DtaDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No related DTPs have been found."},
                Data = null
            });

            var dta = await _dtpRepository.CreateDta(dtpId, dtaDto);
            if (dta == null)
                return BadRequest(new ApiResponse<DtaDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during DTA creation." },
                    Data = null
                });

            var dtaList = new List<DtaDto>() { dta };
            
            return Ok(NotFound(new ApiResponse<DtaDto>()
            {
                Total = dtaList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dtaList
            }));
        }

        [HttpPut("data-transfers/{dtpId:int}/accesses/{id:int}")]
        [SwaggerOperation(Tags = new []{"Data transfer access endpoint"})]
        public async Task<IActionResult> UpdateDta(int dtpId, int id, [FromBody] DtaDto dtaDto)
        {
            var dt = await _dtpRepository.GetDtp(dtpId);
            if (dt == null) return NotFound(
                new ApiResponse<DtaDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>(){"No related DTPs have been found."},
                    Data = null
                });

            var dta = await _dtpRepository.GetDta(id);
            if (dta == null) return NotFound(new ApiResponse<DtaDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No related DTAs have been found."},
                Data = null
            });

            var updatedDta = await _dtpRepository.UpdateDta(dtaDto);
            if (updatedDta == null) return BadRequest(new ApiResponse<DtaDto>()
            {
                Total = 0,
                StatusCode = BadRequest().StatusCode,
                Messages = new List<string>(){"Error during DTA update."},
                Data = null
            });

            var dtaList = new List<DtaDto>() { updatedDta };
            
            return Ok(new ApiResponse<DtaDto>()
            {
                Total = dtaList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dtaList
            });
        }

        [HttpDelete("data-transfers/{dtpId:int}/accesses/{id:int}")]
        [SwaggerOperation(Tags = new []{"Data transfer access endpoint"})]
        public async Task<IActionResult> DeleteDta(int dtpId, int id)
        {
            var dt = await _dtpRepository.GetDtp(dtpId);
            if (dt == null) return NotFound(new ApiResponse<DtaDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No related DTA have been found."},
                Data = null
            });

            var dta = await _dtpRepository.GetDta(id);
            if (dta == null) return NotFound(new ApiResponse<DtaDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No related DTA have been found."},
                Data = null
            });
            
            var count = await _dtpRepository.DeleteDta(id);
            return Ok(new ApiResponse<DtpDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>(){"DTA has been removed."},
                Data = null
            });
        }

        [HttpDelete("data-transfers/{dtpId:int}/accesses")]
        [SwaggerOperation(Tags = new []{"Data transfer access endpoint"})]
        public async Task<IActionResult> DeleteAllDta(int dtpId)
        {
            var dt = await _dtpRepository.GetDtp(dtpId);
            if (dt == null) return NotFound(new ApiResponse<DtaDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No related DTA have been found."},
                Data = null
            });

            var count = await _dtpRepository.DeleteAllDta(dtpId);
            return Ok(new ApiResponse<DtpDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>(){"All DTAs have been removed."},
                Data = null
            });
        }
        
    }
}