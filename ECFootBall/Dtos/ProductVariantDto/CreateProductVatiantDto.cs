using ECFootBall.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECFootBall.Dtos.ProductVariantDto
{
    public class CreateProductVatiantDto
    {
        public string ProductId { get; set; }
        public string SizeId { get; set; } = string.Empty; // Cần 1 bảng riêng
        public string ColorId { get; set; } = string.Empty; // Bảng riêng
        public int StockQuantity { get; set; }

        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
