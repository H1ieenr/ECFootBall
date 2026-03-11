namespace ECFootball.Identity.API.Dtos.IdentityDto
{
    public class UpdateUserDto : RegisterDto
    {
        public string Id { get; set; }
        public string? UserCode { get; set; }
        public IFormFile? FileAvatar {  get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
