using ECFootball.Identity.API._Service.Interface;
using ECFootball.Identity.API.Dtos.IdentityDto;
using ECFootball.Identity.API.Helpers.Mapper;
using ECFootball.Identity.API.Helpers.Utilities;
using ECFootball.Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECFootball.Identity.API._Service.Service
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public IdentityService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager; 
            _roleManager = roleManager;
            _configuration = configuration;
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

                if (user == null) return new OperationResult { Success = false, Message = "Tài khoản không tồn tại" };

                if (user.IsDelete) return new OperationResult { Success = false, Message = "The account has been deleted." };
                if (!user.IsActive) return new OperationResult { Success = false, Message = "the account locked" };

                var isPasswordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
                if (!isPasswordValid) return new OperationResult { Success = false, Message = "Mật khẩu không đúng" };

                var roles = await _userManager.GetRolesAsync(user);
                var token = GenerateJwtToken(user, roles);

                return new OperationResult { Success = true, Message = "Login Success", Data = token };
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

        public async Task SeedRolesAsync()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
                await _roleManager.CreateAsync(new IdentityRole("Admin"));

            if (!await _roleManager.RoleExistsAsync("Staff"))
                await _roleManager.CreateAsync(new IdentityRole("Staff"));

            if (!await _roleManager.RoleExistsAsync("Customer"))
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
        }

        public async Task SeedAdminUserAsync()
        {
            var adminEmail = _configuration["SeedData:AdminEmail"];
            var adminPassword = _configuration["SeedData:AdminPassword"];

            if (string.IsNullOrEmpty(adminEmail)) return;

            var adminUser = await _userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var user = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "System",
                    LastName = "Admin",
                    IsActive = true
                };

                var result = await _userManager.CreateAsync(user, adminPassword!);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
