using ECFootball.Identity.API.Dtos.IdentityDto;
using ECFootball.Identity.API.Helpers.Utilities;
using static ECFootball.Identity.API.Helpers.Utilities.PagingnationUtility;

namespace ECFootball.Identity.API._Service.Interface
{
    public interface IIdentityService
    {
        Task<OperationResult> RegisterAsync(RegisterDto dto);
        Task<OperationResult> LoginAsync(LoginDto dto);
        Task<OperationResult> UpdateAsync(UpdateUserDto dto);
        Task<OperationResult> DeleteAsync(string userId, string deletedBy);
        Task<UserDto> GetUserByIdAsync(string userId);
        Task<PaginationUtility<UserDto>> GetPagedUsersAsync(PaginationParam pagination, SearchUserDto searchDto, bool isPaging = true);
    }
}
