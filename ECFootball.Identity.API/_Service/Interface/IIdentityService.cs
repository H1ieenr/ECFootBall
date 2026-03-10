using ECFootball.Identity.API.Dtos.IdentityDto;
using ECFootball.Identity.API.Helpers.Utilities;

namespace ECFootball.Identity.API._Service.Interface
{
    public interface IIdentityService
    {
        Task<OperationResult> RegisterAsync(RegisterDto dto);
    }
}
