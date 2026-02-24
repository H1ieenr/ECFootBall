
namespace ECFootball.Product.API.Dtos.ImageDto
{
    public class ImageDto
    {
        public Guid Id { get; set; }
        public string? ProductId { get; set; }

        public string? UrlImage { get; set; }
        public int? Position { get; set; }

        public string? PublicId { get; set; }

        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
