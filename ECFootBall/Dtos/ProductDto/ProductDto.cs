
using ECFootBall.Dtos.BrandDto;

namespace ECFootball.Product.API.Dtos.ProductDto
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
        public string BrandName { get; set; }
        public string Images { get; set; }
        public List<ProductVariantDto.ProductVariantDto> Variants { get; set; }

        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsDelete { get; set; } = false;
        public bool? IsPromotion { get; set; }
        public int? AmountReview { get; set; }
    }
}
