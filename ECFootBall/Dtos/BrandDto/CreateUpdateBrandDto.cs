using ECFootBall.Models;

namespace ECFootBall.Dtos.BrandDto
{
    public class UpdateBrandDto : CreateBrandDto
    {
        public int Id { get; set; }
        //public virtual List<Product> Products { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
    }
    public class CreateBrandDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int? DisplayOrder { get; set; }

        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
