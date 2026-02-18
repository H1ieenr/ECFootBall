using ECFootBall.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECFootBall.Dtos.ProductDto
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? PricePromotion { get; set; }
        public bool IsActive { get; set; }

        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        public List<Image> Images { get; set; }
        public List<ProductVariant> Variants { get; set; }


        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsDelete { get; set; }
        public int? AmountReview { get; set; }
    }
}
