
namespace ECFootball.Identity.API.Dtos.IdentityDto
{
    public class RegisterDto
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName => $"{FirstName} {LastName}";
        public string? Avatar { get; set; }
        public string? Address { get; set; }
        public string? Ward { get; set; }
        public string? Province { get; set; }
        public string? Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }

        public bool IsLoginGoogle { get; set; }
        public string? IdGoogle { get; set; }
    }
}
