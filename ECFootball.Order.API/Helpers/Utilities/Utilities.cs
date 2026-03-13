namespace ECFootball.Order.API.Helpers.Utilities
{
    public static class Utilities
    {
        public static string GenerateOrderCode()
        {
            var random = new Random();
            var randomNumber = random.Next(100000, 999999);
            return $"{"ORECF"}-{randomNumber}";
        }

        public enum OrderStatus
        {
            Pending,
            Shipping, 
            Completed, 
            Cancelled
        }
    }
}
