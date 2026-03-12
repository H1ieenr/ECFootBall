namespace ECFootball.Order.API.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public Guid? GuestId { get; set; }
        public DateTime LastUpdate {  get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
