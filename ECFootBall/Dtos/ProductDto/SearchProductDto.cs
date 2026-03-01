namespace ECFootball.Product.API.Dtos.ProductDto
{
    public class SearchProductDto
    {
        public string? FullTextSearch { get; set; }
        public string? ProductId { get; set; }
        public decimal? FromPrice { get; set; }
        public decimal? ToPrice { get; set; }
        public int? BrandId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsPromotion { get; set; }
    }
}
