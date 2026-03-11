using ECFootball.Identity.API.Dtos.IdentityDto;
using ECFootball.Identity.API.Models;

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
                IsActive = true,
                IsDelete = false,
                UserCode = Utilities.Utilities.GenerateUserCode()
            };
        }

        public static void MapToEntity(this UpdateUserDto dto, User entity)
        {
            entity.UserName = dto.UserName;
            entity.Email = dto.Email;
            entity.PhoneNumber = dto.PhoneNumber;
            entity.Avatar = dto.Avatar;
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.Address = dto.Address;
            entity.Ward = dto.Ward;
            entity.Province = dto.Province;
            entity.Country = dto.Country;
            entity.DateOfBirth = dto.DateOfBirth;
            entity.Gender = dto.Gender;
            entity.PasswordHash = dto.Password;
            entity.IsActive = dto.IsActive;
        }

        public static UserDto MapToDto(this User entity)
        {
            return new UserDto
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                Avatar = entity.Avatar,
                CreatedDate = entity.CreatedDate,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Address = entity.Address,
                Ward = entity.Ward,
                Province = entity.Province,
                Country = entity.Country,
                DateOfBirth = entity.DateOfBirth,
                Gender = entity.Gender,
                IsActive = entity.IsActive,
                UserCode = entity.UserCode,
                FullName = entity.FullName,
                UpdateBy = entity.UpdateBy,
                UpdatedDate = entity.UpdatedDate,
            };
        }

        public static void MapDelete(this User entity, string deletedBy)
        {
            entity.IsDelete = true;
            entity.UpdatedDate = DateTime.Now;
            entity.UpdateBy = deletedBy;
        }
    }
}
