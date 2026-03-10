namespace ECFootball.Identity.API.Dtos.IdentityDto
{
    public class RegisterDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
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
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsLoginGoogle { get; set; }
        public string? IdGoogle { get; set; }
    }
}
