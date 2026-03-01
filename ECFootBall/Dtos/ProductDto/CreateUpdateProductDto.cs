namespace ECFootball.Product.API.Dtos.ProductDto
{
    public class UpdateProductDto : CreateProductDto
    {
        public string Id { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }

    public class CreateProductDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? PricePromotion { get; set; }
        public bool IsActive { get; set; }
        public required IFormFile FileAvatar { get; set; }
        public List<IFormFile> FileImage { get; set; }

        public bool? IsPromotion { get; set; }
        public int BrandId { get; set; }
        internal string? Avatar { get; set; }
        internal string? BrandName { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
