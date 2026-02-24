namespace ECFootBall.Dtos.SizeDto
{
    public class UpdateSizeDto : CreateSizeDto
    {
        public int Id { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
    public class CreateSizeDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
