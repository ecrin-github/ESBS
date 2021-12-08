using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UserService.Contracts.Responses;

namespace UserService.Controllers.v1
{
    [Route("user")]
    public class RmsUserApiController : BaseApiController
    {
        [HttpPost("data-transfers/accesses")]
        [SwaggerOperation(Tags = new []{"User RMS DTP endpoint"})]
        public async Task<IActionResult> GetUerDtpAccesses()
        {
            var accessTokenRes = await HttpContext.GetTokenAsync("access_token");
            var accessToken = accessTokenRes?.ToString();
            
            return Ok(new ApiResponse<int>()
            {
                Total = 0,
                Messages = new List<string>(){"No DTP access have been found."},
                StatusCode = NotFound().StatusCode,
                Data = new List<int>()
            });
        }
        
        [HttpPost("data-transfers/processes")]
        [SwaggerOperation(Tags = new []{"User RMS DTP endpoint"})]
        public async Task<IActionResult> GetUerDtpProcesses()
        {
            var accessTokenRes = await HttpContext.GetTokenAsync("access_token");
            var accessToken = accessTokenRes?.ToString();
            
            return Ok(new ApiResponse<int>()
            {
                Total = 0,
                Messages = new List<string>(){"No DTP access have been found."},
                StatusCode = NotFound().StatusCode,
                Data = new List<int>()
            });
        }
        
        [HttpPost("data-transfers/datasets")]
        [SwaggerOperation(Tags = new []{"User RMS DTP endpoint"})]
        public async Task<IActionResult> GetUerDtpDatasets()
        {
            var accessTokenRes = await HttpContext.GetTokenAsync("access_token");
            var accessToken = accessTokenRes?.ToString();
            
            return Ok(new ApiResponse<int>()
            {
                Total = 0,
                Messages = new List<string>(){"No DTP access have been found."},
                StatusCode = NotFound().StatusCode,
                Data = new List<int>()
            });
        }
        
        [HttpPost("data-transfers/objects")]
        [SwaggerOperation(Tags = new []{"User RMS DTP endpoint"})]
        public async Task<IActionResult> GetUerDtpObjects()
        {
            var accessTokenRes = await HttpContext.GetTokenAsync("access_token");
            var accessToken = accessTokenRes?.ToString();
            
            return Ok(new ApiResponse<int>()
            {
                Total = 0,
                Messages = new List<string>(){"No DTP access have been found."},
                StatusCode = NotFound().StatusCode,
                Data = new List<int>()
            });
        }
        
        [HttpPost("data-transfers/studies")]
        [SwaggerOperation(Tags = new []{"User RMS DTP endpoint"})]
        public async Task<IActionResult> GetUerDtpStudies()
        {
            var accessTokenRes = await HttpContext.GetTokenAsync("access_token");
            var accessToken = accessTokenRes?.ToString();
            
            return Ok(new ApiResponse<int>()
            {
                Total = 0,
                Messages = new List<string>(){"No DTP access have been found."},
                StatusCode = NotFound().StatusCode,
                Data = new List<int>()
            });
        }
        
        
    }
}