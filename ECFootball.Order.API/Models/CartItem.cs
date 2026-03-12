using System.ComponentModel.DataAnnotations;

namespace ECFootball.Order.API.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public string ProductId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "The number must be greater than 0.")]
        public int Quantity { get; set; }

        public Cart Cart { get; set; }
    }
}
