using static ECFootball.Order.API.Helpers.Utilities.Utilities;

namespace ECFootball.Order.API.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string OrderCode { get; set; }
        public string UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } 
        public DateTime CreatedDate { get; set; }
        public string ShippingAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
