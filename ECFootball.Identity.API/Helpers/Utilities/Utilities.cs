namespace ECFootball.Identity.API.Helpers.Utilities
{
    public static class Utilities
    {
        public enum Gender : int 
        {
            Unknown = 0,
            Male = 1,
            Female = 2
        }

        public static string GenerateUserCode()
        {
            var random = new Random();
            var randomNumber = random.Next(100000, 999999);
            return $"ECF-{randomNumber}";
        }

    }
}
