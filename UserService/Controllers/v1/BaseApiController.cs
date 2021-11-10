using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers.v1
{
    [ApiController]
    [Authorize("ClientIdPolicy")]
    public class BaseApiController : ControllerBase
    {
        
    }
}