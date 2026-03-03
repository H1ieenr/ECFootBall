

namespace ECFootBall.Dtos.ProductVariantDto
{
    public class UpdateProductVariantDto : CreateProductVariantDto
    {
        public int Id { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
    public class CreateProductVariantDto
    {
        public string ProductId { get; set; }
        public string SizeId { get; set; }
        public string ColorId { get; set; }
        public int StockQuantity { get; set; }

        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
