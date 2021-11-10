using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RmsService.Controllers.v1
{
    [ApiController]
    [Authorize("ClientIdPolicy")]
    public class BaseApiController : ControllerBase
    {
        
    }
}