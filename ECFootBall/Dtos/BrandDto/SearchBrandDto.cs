namespace ECFootBall.Dtos.BrandDto
{
    public class SearchBrandDto
    {
        public string? FullTextSearch { get; set; }
        public int? BrandId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
}
