using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContextService.Controllers.v1
{
    [ApiController]
    [Authorize]
    public class BaseApiController : ControllerBase
    {
        
    }
}