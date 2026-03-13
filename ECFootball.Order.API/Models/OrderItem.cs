namespace ECFootball.Order.API.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string SizeId { get; set; }
        public string ColorId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Avatar { get; set; }
        public Order Order { get; set; }
    }
}
