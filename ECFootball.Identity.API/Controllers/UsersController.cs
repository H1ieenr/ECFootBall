using ECFootball.Identity.API._Service.Interface;
using ECFootball.Identity.API.Dtos.IdentityDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static ECFootball.Identity.API.Helpers.Utilities.PagingnationUtility;

namespace ECFootball.Identity.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize(Roles = "Admin,Staff")]
    public class UsersController : ControllerBase
    {
        private IIdentityService _identityService;
        protected string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        public UsersController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var result = await _identityService.RegisterAsync(dto);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _identityService.LoginAsync(dto);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequestDto model)
        {
            var result = await _identityService.RefreshTokenAsync(model);
            if (result == null)
                return Unauthorized("Phiên đăng nhập đã hết hạn, vui lòng login lại.");

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateUserDto dto)
        {
            dto.UpdateBy = CurrentUserId;
            var result = await _identityService.UpdateAsync(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _identityService.DeleteAsync(id, CurrentUserId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserAsync([FromQuery] PaginationParam pagination, [FromQuery] SearchUserDto dto)
        {
            var result = await _identityService.GetPagedUsersAsync(pagination, dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Staff,Customer")]
        public async Task<IActionResult> GetUserByIdAsync(string id)
        {
            var result = await _identityService.GetUserByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            dto.UserId = CurrentUserId;
            var result = await _identityService.ChangePasswordAsync(dto);
            return Ok(result);
        }
    }
}
