using ECFootball.Order.API.Models;

namespace ECFootball.Order.API.Dtos.CartDto
{
    public class AddToCartDto
    {
        internal string? UserId { get; set; }
        internal Guid? GuestId { get; set; }
        public string? ProductId { get; set; }
        public int? Quantity { get; set; }
    }
}
