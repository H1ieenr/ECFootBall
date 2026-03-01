
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
        //[ForeignKey("BrandId")]
        //public virtual Brand? Brand { get; set; }

        //public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

        //public List<Image>? Images { get; set; } = new();
        //public List<ProductVariant> Variants { get; set; }

        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsDelete { get; set; } = false;
        public bool? IsPromotion { get; set; }
        public int? AmountReview { get; set; }
    }
}
