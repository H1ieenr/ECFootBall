namespace ECFootball.Product.API.Dtos.OrderDto
{
    public class OrderCreatedEvent
    {
        public Guid OrderId { get; set; }
        public List<OrderItemStockDto> Items { get; set; } = new();
    }

    public class OrderItemStockDto
    {
        public string ProductId { get; set; }
        public string SizeId { get; set; }
        public string ColorId { get; set; }
        public int Quantity { get; set; }
    }
}
