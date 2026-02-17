using ECFootBall.Models;

namespace ECFootBall.Dtos.CategoryDto
{
    public class UpdateCategoryDto : CreateCategoryDto
    {

    }
    public class CreateCategoryDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int? DisplayOrder { get; set; }

        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsDelete { get; set; }
    }
}
