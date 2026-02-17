using ECFootBall.Models;

namespace ECFootBall.Dtos.CategoryDto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public int? DisplayOrder { get; set; }
        public virtual List<Product> Products { get; set; }

        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsDelete { get; set; }
    }
}
