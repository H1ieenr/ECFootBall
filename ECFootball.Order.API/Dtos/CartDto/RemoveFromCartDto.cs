namespace ECFootball.Order.API.Dtos.CartDto
{
    public class RemoveFromCartDto
    {
        internal string UserId { get; set; }
        public string ProductId { get; set; }
        public string SizeId { get; set; }
        public string ColorId { get; set; }
    }
}
