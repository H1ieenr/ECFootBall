using ECFootBall.Dtos.CategoryDto;
using ECFootBall.Models;

namespace ECFootBall.Helpers.Mapper
{
    public static class CategoryMappingExtensions
    {
        public static Category MapToEntity(this CreateCategoryDto dto)
        {
            return new Category
            {
               Name = dto.Name,
               Description = dto.Description,
               BrandId = dto.BrandId > 0 ? dto.BrandId : null,
               DisplayOrder = dto.DisplayOrder,
               ParentId = dto.ParentId > 0 ? dto.ParentId : null,

               CreateBy = dto.CreateBy,
               CreateDate = DateTime.UtcNow,
               IsActive = false,
               IsDelete = false,
            };
        }

        public static void MapToEntity(this UpdateCategoryDto dto, Category entity)
        {
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.BrandId = dto.BrandId;
            entity.DisplayOrder = dto.DisplayOrder;
            entity.ParentId = (dto.ParentId > 0 && dto.ParentId != entity.Id) ? dto.ParentId : null;
            entity.IsActive = dto.IsActive;

            entity.UpdateDate = DateTime.UtcNow;
            entity.UpdateBy = dto.UpdateBy;
        }

        public static CategoryDto MapToDto(this Category entity)
        {
            return new CategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                BrandId = entity.BrandId,
                ParentId = entity.ParentId,
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

        public static void MapDelete(this Category entity, string deletedBy)
        {
            entity.IsDelete = true;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateBy = deletedBy;
        }
    }
}
