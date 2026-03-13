namespace ECFootball.Order.API.Dtos.CartDto
{
    public class CartItemDto
    {
        public Guid? CartId { get; set; }
        public string? ProductId { get; set; }
        public string? NameProduct {  get; set; }
        public string? SizeName {  get; set; }
        public string? Color { get; set; }
        public string SizeId { get; set; }
        public string ColorId { get; set; }
        public int? Quantity { get; set; }
        public string? Avatar { get; set; }
        public decimal? Price { get; set; }
        public decimal? PricePromotion { get; set; }
        public bool? IsPromotion { get; set; }
    }
}
