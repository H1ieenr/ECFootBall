using ECFootBall.Dtos.BrandDto;
using ECFootBall.Models;

namespace ECFootBall.Helpers.Mapper
{
    public static class BrandMappingExtensions
    {
        public static Brand MapToEntity(this CreateBrandDto dto)
        {
            return new Brand
            {
                Name = dto.Name,
                Description = dto.Description,
                DisplayOrder = dto.DisplayOrder,
                
                CreateBy = dto.CreateBy,
                CreateDate = DateTime.UtcNow,
                IsActive = false,
                IsDelete = false,
            };
        }

        public static void MapToEntity(this UpdateBrandDto dto, Brand entity)
        {
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.DisplayOrder = dto.DisplayOrder;
            entity.IsActive = dto.IsActive;
            
            entity.UpdateDate = DateTime.UtcNow;
            entity.UpdateBy = dto.UpdateBy;
        }

        public static BrandDto MapToDto(this Brand entity)
        {
            return new BrandDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CreateBy = entity.CreateBy,
                CreateDate = entity.CreateDate,
                DisplayOrder = entity.DisplayOrder,
                IsActive = entity.IsActive,
                IsDelete = entity.IsDelete,
                Products = entity.Products,
                UpdateBy = entity.UpdateBy,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static void MapDelete(this Brand entity, string deletedBy)
        {
            entity.IsDelete = true;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateBy = deletedBy;
        }
    }
}
