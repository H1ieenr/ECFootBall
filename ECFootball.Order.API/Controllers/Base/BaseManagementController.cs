using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECFootball.Order.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Staff,Customer")]
    public class BaseManagementController : ControllerBase
    {
        protected string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
