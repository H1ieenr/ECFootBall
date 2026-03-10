using ECFootball.Identity.API.Dtos.IdentityDto;
using ECFootball.Identity.API.Models;
using static ECFootball.Identity.API.Helpers.Utilities.Utilities;

namespace ECFootball.Identity.API.Helpers.Mapper
{
    public static class UserMappingExtentions
    {
        public static User MapToEntity(this RegisterDto dto)
        {
            return new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Avatar  = dto.Avatar,
                CreatedDate = DateTime.UtcNow,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Address = dto.Address,
                Ward = dto.Ward,
                Province = dto.Province,
                Country     = dto.Country,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                PasswordHash = dto.Password,
                IsActive = false,
                IsDelete = false,
            };
        }
    }
}
