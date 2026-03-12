namespace ECFootball.Order.API.Dtos.CartDto
{
    public class CartDto
    {
        public Guid CartId {  get; set; }
        public string? UserId { get; set;  }
        public DateTime? LastUpdate { get; set; }
        public List<CartItemDto>? CartItems { get; set; }
    }
}
