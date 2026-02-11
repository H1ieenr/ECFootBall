using System.ComponentModel.DataAnnotations.Schema;

namespace ECFootBall.Models
{
    public class ProductVariant
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string SizeId { get; set; } = string.Empty; // Cần 1 bảng riêng
        public string ColorId { get; set; } = string.Empty; // Bảng riêng
        public int StockQuantity { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsDelete { get; set; } = false;
    }
}
