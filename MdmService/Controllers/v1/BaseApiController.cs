using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MdmService.Controllers.v1
{
    [ApiController]
    [Authorize("ClientIdPolicy")]
    public class BaseApiController : ControllerBase
    {
        
    }
}