namespace ECFootball.Order.API.Dtos.ProductDto
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? PricePromotion { get; set; }
        public bool IsActive { get; set; }
        public string? Avatar { get; set; }
        public int BrandId { get; set; }
        public bool? IsPromotion { get; set; }
    }
}
