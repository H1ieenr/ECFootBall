namespace ECFootBall.Dtos.SizeDto
{
    public class SearchSizeDto
    {
        public string? FullTextSearch { get; set; }
        public int? SizeId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
}
