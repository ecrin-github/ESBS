using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UserService.Contracts.Requests;
using UserService.Contracts.Responses;

namespace UserService.Controllers.v1
{
    [Route("user")]
    public class RmsUserApiController : BaseApiController
    {
        [HttpPost("data-transfers/accesses")]
        [SwaggerOperation(Tags = new []{"User RMS DTP endpoint"})]
        public IActionResult GetUerDtpAccesses(AccessTokenRequest accessTokenRequest)
        {
            return NotFound(new ApiResponse<int>()
            {
                Total = 0,
                Messages = new List<string>(){"No DTP access have been found."},
                StatusCode = NotFound().StatusCode,
                Data = new List<int>()
            });
        }
        
        [HttpPost("data-transfers/processes")]
        [SwaggerOperation(Tags = new []{"User RMS DTP endpoint"})]
        public IActionResult GetUerDtpProcesses(AccessTokenRequest accessTokenRequest)
        {
            return NotFound(new ApiResponse<int>()
            {
                Total = 0,
                Messages = new List<string>(){"No DTP access have been found."},
                StatusCode = NotFound().StatusCode,
                Data = new List<int>()
            });
        }
        
        [HttpPost("data-transfers/datasets")]
        [SwaggerOperation(Tags = new []{"User RMS DTP endpoint"})]
        public IActionResult GetUerDtpDatasets(AccessTokenRequest accessTokenRequest)
        {
            return NotFound(new ApiResponse<int>()
            {
                Total = 0,
                Messages = new List<string>(){"No DTP access have been found."},
                StatusCode = NotFound().StatusCode,
                Data = new List<int>()
            });
        }
        
        [HttpPost("data-transfers/objects")]
        [SwaggerOperation(Tags = new []{"User RMS DTP endpoint"})]
        public IActionResult GetUerDtpObjects(AccessTokenRequest accessTokenRequest)
        {
            return NotFound(new ApiResponse<int>()
            {
                Total = 0,
                Messages = new List<string>(){"No DTP access have been found."},
                StatusCode = NotFound().StatusCode,
                Data = new List<int>()
            });
        }
        
        [HttpPost("data-transfers/studies")]
        [SwaggerOperation(Tags = new []{"User RMS DTP endpoint"})]
        public IActionResult GetUerDtpStudies(AccessTokenRequest accessTokenRequest)
        {
            return NotFound(new ApiResponse<int>()
            {
                Total = 0,
                Messages = new List<string>(){"No DTP access have been found."},
                StatusCode = NotFound().StatusCode,
                Data = new List<int>()
            });
        }
        
        
    }
}