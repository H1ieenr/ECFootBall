namespace ECFootBall.Dtos.ColorDto
{
    public class UpdateColorDto : CreateColorDto
    {
        public int Id { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
    public class CreateColorDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
