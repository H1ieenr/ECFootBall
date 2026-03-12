using ECFootball.Identity.API._Service.Interface;
using ECFootball.Identity.API.Dtos.IdentityDto;
using ECFootball.Identity.API.Helpers.Mapper;
using ECFootball.Identity.API.Helpers.Utilities;
using ECFootball.Identity.API.Models;
using ECFootball.Infrastructure.Shared._Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static ECFootball.Identity.API.Helpers.Utilities.PagingnationUtility;

namespace ECFootball.Identity.API._Service.Service
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IFileService _fileService;
        public IdentityService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IFileService fileService)
        {
            _userManager = userManager; 
            _roleManager = roleManager;
            _configuration = configuration;
            _fileService = fileService;
        }

        public async Task<OperationResult> RegisterAsync(RegisterDto dto)
        {
            try
            {
                User user = dto.MapToEntity();

                var result = await _userManager.CreateAsync(user, dto.Password);
                if (result.Succeeded) 
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                    return new OperationResult { Success = true, Message = "Register Success" };
                }
                return new OperationResult { Success = false, Message = string.Join(", ", result.Errors.Select(e => e.Description)) };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult> LoginAsync(LoginDto dto)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u =>
                    u.Email == dto.UserName || u.PhoneNumber == dto.UserName || u.UserName == dto.UserName);

                if (user == null) return new OperationResult { Success = false, Message = "The account does not exist" };

                if (user.IsDelete) return new OperationResult { Success = false, Message = "The account has been deleted." };
                if (!user.IsActive) return new OperationResult { Success = false, Message = "the account locked" };

                var isPasswordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
                if (!isPasswordValid) return new OperationResult { Success = false, Message = "Incorrect password" };

                var roles = await _userManager.GetRolesAsync(user);
                var token = GenerateJwtToken(user, roles);

                return new OperationResult { Success = true, Message = "Login Success", Data = token };
            }
            catch (Exception ex) 
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<UserDto> GetUserByIdAsync(string userId)
        {
            var query = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return query?.MapToDto();
        }

        public async Task<PaginationUtility<UserDto>> GetPagedUsersAsync(PaginationParam pagination, SearchUserDto searchDto, bool isPaging = true)
        {
            var query = _userManager.Users.AsNoTracking();

            if (!string.IsNullOrEmpty(searchDto.FullTextSearch))
                query = query.Where(c => c.Id == searchDto.UserId);
            if (searchDto.IsDelete.HasValue)
                query = query.Where(c => c.IsDelete == searchDto.IsDelete);
            if (searchDto.IsActive.HasValue)
                query = query.Where(c => c.IsActive == searchDto.IsActive);
            if (!string.IsNullOrEmpty(searchDto.FullTextSearch))
                query = query.Where(c => c.UserCode.Contains(searchDto.FullTextSearch) ||
                                            c.Email.Contains(searchDto.FullTextSearch) ||
                                            c.PhoneNumber.Contains(searchDto.FullTextSearch) ||
                                            c.UserName.Contains(searchDto.FullTextSearch) ||
                                            c.FullName.Contains(searchDto.FullTextSearch));

            var queryDto = query.Select(c => c.MapToDto());
            return await PaginationUtility<UserDto>.CreateAsync(queryDto, pagination.PageNumber, pagination.PageSize, isPaging);
        }


        public async Task<OperationResult> UpdateAsync(UpdateUserDto dto)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == dto.Id);
                if (user == null) return new OperationResult { Success = false, Message = "The account does not exist" };

                dto.MapToEntity(user);
                if (dto.FileAvatar != null)
                {
                    var uploadResult = await _fileService.UploadImageAsync(dto.FileAvatar, $"User/{dto.UserCode}");
                    if (uploadResult.Error != null) return new OperationResult() { Success = false, Message = "Upload Image error" };
                    if(user.AvatarPublicId != null) await _fileService.DeleteImageAsync(user.AvatarPublicId);

                    user.AvatarPublicId = uploadResult.PublicId;
                    user.Avatar = uploadResult.SecureUrl.AbsoluteUri;
                }
                await _userManager.UpdateAsync(user);
                return new OperationResult { Success = true, Message = "Update Success"};
            }
            catch(Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public async Task<OperationResult> DeleteAsync(string userId, string deletedBy)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u =>  userId == u.Id);
                if (user == null) return new OperationResult() { Success = false, Message = "No data" };

                user.MapDelete(deletedBy);

                await _userManager.UpdateAsync(user);
                return new OperationResult() { Success = true, Message = "Delete Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }
        public async Task<OperationResult> ChangePasswordAsync(ChangePasswordDto dto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(dto.UserId);
                if (user == null) return new OperationResult { Success = false, Message = "User not found" };

                var result = await _userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);

                if (result.Succeeded) return new OperationResult { Success = true, Message = "Password changed successfully" };
                return new OperationResult { Success = false, Message = result.Errors.ToString() };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }
        private string GenerateJwtToken(User user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("FullName", user.FullName)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
