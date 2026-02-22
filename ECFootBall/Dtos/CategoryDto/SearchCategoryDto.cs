namespace ECFootBall.Dtos.CategoryDto
{
    public class SearchCategoryDto
    {
        public string? FullTextSearch { get; set; }
        public int? CategoryId { get; set; }
        public int? ParentId { get; set; }
        public int? BrandId { get; set; }
        public bool? IsDelete { get; set; }
    }
}
