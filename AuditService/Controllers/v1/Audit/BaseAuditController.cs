using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuditService.Controllers.v1.Audit;

[ApiController]
[Authorize]
public class BaseAuditController : ControllerBase
{
    
}