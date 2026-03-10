namespace ECFootBall.Dtos.ImageDto
{
    public class CreateImageObjectDto : CreateImageDto
    {
        public string? ObjectId { get; set; }
        public string? ObjectName { get; set; }
    }
    public class UpdateImageDto : CreateImageDto
    {
        public string? PublicId { get; set; }
    }
    public class CreateImageDto
    {
        public string? ProductId { get; set; }

        public string? UrlImage { get; set; }
        public int? Position { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }


}
