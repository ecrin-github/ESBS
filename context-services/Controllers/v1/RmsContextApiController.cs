using System.Collections.Generic;
using System.Threading.Tasks;
using context_services.Contracts.Responses;
using context_services.Interfaces;
using context_services.Models.Rms;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace context_services.Controllers.v1
{
    public class RmsContextApiController : BaseApiController
    {

        private readonly IRmsContextRepository _rmsRepository;

        public RmsContextApiController(IRmsContextRepository rmsRepository)
        {
            _rmsRepository = rmsRepository;
        }
        
        [HttpGet("rms/access-prereq-types")]
        [SwaggerOperation(Tags = new[] { "RMS Context - Access prereq types" })]
        public async Task<IActionResult> GetAccessPrereqTypes()
        {
            var data = await _rmsRepository.GetAccessPrereqTypes();
            if (data == null) return NotFound(new ApiResponse<AccessPrereqType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<AccessPrereqType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("rms/access-prereq-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "RMS Context - Access prereq types" })]
        public async Task<IActionResult> GetAccessPrereqType(int id)
        {
            var data = await _rmsRepository.GetAccessPrereqType(id);
            if (data == null) return NotFound(new ApiResponse<AccessPrereqType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<AccessPrereqType>()
            {
                Total = 1,
                Data = new List<AccessPrereqType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("rms/check-status-types")]
        [SwaggerOperation(Tags = new[] { "RMS Context - Check status types" })]
        public async Task<IActionResult> GetCheckStatusTypes()
        {
            var data = await _rmsRepository.GetCheckStatusTypes();
            if (data == null) return NotFound(new ApiResponse<CheckStatusType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<CheckStatusType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("rms/check-status-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "RMS Context - Check status types" })]
        public async Task<IActionResult> GetCheckStatusType(int id)
        {
            var data = await _rmsRepository.GetCheckStatusType(id);
            if (data == null) return NotFound(new ApiResponse<CheckStatusType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<CheckStatusType>()
            {
                Total = 1,
                Data = new List<CheckStatusType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("rms/dtp-status-types")]
        [SwaggerOperation(Tags = new[] { "RMS Context - DTP status types" })]
        public async Task<IActionResult> GetDtpStatusTypes()
        {
            var data = await _rmsRepository.GetDtpStatusTypes();
            if (data == null) return NotFound(new ApiResponse<DtpStatusType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<DtpStatusType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("rms/dtp-status-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "RMS Context - DTP status types" })]
        public async Task<IActionResult> GetDtpStatusType(int id)
        {
            var data = await _rmsRepository.GetDtpStatusType(id);
            if (data == null) return NotFound(new ApiResponse<DtpStatusType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<DtpStatusType>()
            {
                Total = 1,
                Data = new List<DtpStatusType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("rms/dup-status-types")]
        [SwaggerOperation(Tags = new[] { "RMS Context - DUP status types" })]
        public async Task<IActionResult> GetDupStatusTypes()
        {
            var data = await _rmsRepository.GetDupStatusTypes();
            if (data == null) return NotFound(new ApiResponse<DupStatusType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<DupStatusType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("rms/dup-status-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "RMS Context - DUP status types" })]
        public async Task<IActionResult> GetDupStatusType(int id)
        {
            var data = await _rmsRepository.GetDupStatusType(id);
            if (data == null) return NotFound(new ApiResponse<DupStatusType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<DupStatusType>()
            {
                Total = 1,
                Data = new List<DupStatusType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("rms/legal-status-types")]
        [SwaggerOperation(Tags = new[] { "RMS Context - Legal status types" })]
        public async Task<IActionResult> GetLegalStatusTypes()
        {
            var data = await _rmsRepository.GetLegalStatusTypes();
            if (data == null) return NotFound(new ApiResponse<LegalStatusType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<LegalStatusType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("rms/legal-status-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "RMS Context - Legal status types" })]
        public async Task<IActionResult> GetLegalStatusType(int id)
        {
            var data = await _rmsRepository.GetLegalStatusType(id);
            if (data == null) return NotFound(new ApiResponse<LegalStatusType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<LegalStatusType>()
            {
                Total = 1,
                Data = new List<LegalStatusType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        
        [HttpGet("rms/repo-access-types")]
        [SwaggerOperation(Tags = new[] { "RMS Context - Repo access types" })]
        public async Task<IActionResult> GetRepoStatusTypes()
        {
            var data = await _rmsRepository.GetRepoAccessTypes();
            if (data == null) return NotFound(new ApiResponse<RepoAccessType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<RepoAccessType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("rms/repo-access-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "RMS Context - Repo access types" })]
        public async Task<IActionResult> GetRepoStatusType(int id)
        {
            var data = await _rmsRepository.GetRepoAccessType(id);
            if (data == null) return NotFound(new ApiResponse<RepoAccessType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<RepoAccessType>()
            {
                Total = 1,
                Data = new List<RepoAccessType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
    }
}