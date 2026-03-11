namespace ECFootball.Identity.API.Dtos.IdentityDto
{
    public class SearchUserDto
    {
        public string? FullTextSearch { get; set; }
        public string? UserId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
}
