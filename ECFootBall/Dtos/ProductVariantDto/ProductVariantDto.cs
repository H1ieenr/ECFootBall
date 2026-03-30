
namespace ECFootball.Product.API.Dtos.ProductVariantDto
{
    public class ProductVariantDto
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string SizeId { get; set; } 
        public string SizeName { get; set; }
        public string ColorId { get; set; }
        public string ColorName { get; set; }
        public int StockQuantity { get; set; }

        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsDelete { get; set; }
    }
    
}
