using ECFootball.Identity.API._Service.Interface;
using ECFootball.Identity.API.Models;
using Microsoft.AspNetCore.Identity;

namespace ECFootball.Identity.API._Service.Service
{
    public class SeedDataService : ISeedDataService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public SeedDataService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
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
