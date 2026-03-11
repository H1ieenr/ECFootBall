using Microsoft.AspNetCore.Identity;

namespace ECFootball.Identity.API.Dtos.IdentityDto
{
    public class UserDto
    {
        public string Id { get; set; } 
        public string? UserName { get; set; }
        public string? UserCode { get; set; } 
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Ward { get; set; }
        public string? Province { get; set; }
        public string? Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public bool IsActive { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        //public bool IsLoginGoogle { get; set; }
        //public string? IdGoogle { get; set; }
        //public string? AvatarPublicId { get; set; }

        //public bool PhoneNumberIsVerified { get; set; }
        //public string? CodeSMSVerify { get; set; }
        //public DateTime TimeCodeSMSVerify { get; set; }
        //public bool EmailIsVerified { get; set; }
        //public string? CodeEmailVerify { get; set; }
        //public DateTime TimeCodeEmailVerify { get; set; }
    }
}
