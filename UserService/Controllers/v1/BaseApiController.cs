using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers.v1
{
    [ApiController]
    [Authorize]
    public class BaseApiController : ControllerBase
    {
        
    }
}