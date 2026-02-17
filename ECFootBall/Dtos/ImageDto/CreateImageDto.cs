namespace ECFootBall.Dtos.ImageDto
{
    public class CreateImageDto
    {
        public string ProductId { get; set; }

        public string? UrlImage { get; set; }
        public int? Position { get; set; }

        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
