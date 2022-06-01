using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace UserService.Controllers.v1
{
    [ApiController]
    public class IdentityApiController : ControllerBase
    {
        [HttpGet("identity")]
        [SwaggerOperation(Tags = new []{"Identity URLs"})]
        public IActionResult Get()
        {
            return Ok();
        }
        
        [HttpGet("callback")]
        [SwaggerOperation(Tags = new []{"Identity URLs"})]
        public IActionResult Callback()
        {
            return Ok();
        }
    }
}