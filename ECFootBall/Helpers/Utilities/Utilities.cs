namespace ECFootBall.Helpers.Utilities
{
    public static class Utilities
    {
        public static string GenerateProductId(string brandName, string nameProduct)
        {
            var initials = string.Concat(nameProduct
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(word => word[0]))
                .ToUpper();

            var random = new Random();
            var randomNumber = random.Next(100000, 999999); // Tạo số từ 100000 đến 999999S
            return $"{brandName.ToUpper()}-{initials}{randomNumber}";
        }
    }
}
