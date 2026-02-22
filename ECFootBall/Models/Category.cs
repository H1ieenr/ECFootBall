using System.ComponentModel.DataAnnotations.Schema;

namespace ECFootBall.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int? BrandId {  get; set; }

        public required string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public virtual List<Product> Products { get; set; } = new();

        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual Category? Parent { get; set; }
        public virtual List<Category> Children { get; set; } = new();

        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsDelete { get; set; } = false;
    }
}