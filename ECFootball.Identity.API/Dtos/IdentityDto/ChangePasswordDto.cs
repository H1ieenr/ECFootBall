using System.ComponentModel.DataAnnotations;

namespace ECFootball.Identity.API.Dtos.IdentityDto
{
    public class ChangePasswordDto
    {
        public required string UserId { get; set; }
        public required string OldPassword { get; set; }

        [MinLength(6)]
        public required string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "The password doesn't match.")]
        public string ConfirmPassword { get; set; }
    }
}
