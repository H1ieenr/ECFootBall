
using ECFootBall.Dtos.ImageDto;
using ECFootBall.Dtos.ProductVariantDto;

namespace ECFootBall.Dtos.ProductDto
{
    public class UpdateProductDto : CreateProductDto
    {
        public string Id { get; set; }
    }
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? PricePromotion { get; set; }
        public bool IsActive { get; set; }

        public int CategoryId { get; set; }

        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }

        public List<CreateImageDto> Images { get; set; }
        public List<CreateProductVatiantDto> Variants { get; set; }
    }
}
