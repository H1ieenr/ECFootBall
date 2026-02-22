namespace ECFootBall.Dtos.ColorDto
{
    public class SearchColorDto
    {
        public string? FullTextSearch { get; set; }
        public int? ColorId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
}
