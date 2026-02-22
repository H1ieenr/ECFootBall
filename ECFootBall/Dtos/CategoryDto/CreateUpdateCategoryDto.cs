using ECFootBall.Models;

namespace ECFootBall.Dtos.CategoryDto
{
    public class UpdateCategoryDto : CreateCategoryDto
    {
        public int Id { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
    public class CreateCategoryDto
    {
        public required string Name { get; set; }
        public int? BrandId { get; set; }

        public int? ParentId { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int? DisplayOrder { get; set; }

        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
