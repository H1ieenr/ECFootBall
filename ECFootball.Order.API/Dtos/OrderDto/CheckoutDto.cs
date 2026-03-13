namespace ECFootball.Order.API.Dtos.OrderDto
{
    public class CheckoutDto
    {
        internal string UserId { get; set;  }
        public string ShippingAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
    }
}
